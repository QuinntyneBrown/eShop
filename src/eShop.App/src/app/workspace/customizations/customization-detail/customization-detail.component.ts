import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Customization } from '../customization';
import { CustomizationService } from '../customization.service';

@Component({
  selector: 'app-customization-detail',
  templateUrl: './customization-detail.component.html',
  styleUrls: ['./customization-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class CustomizationDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public customization$: BehaviorSubject<Customization> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.customization$
  ]).pipe(
    map(([customization]) => {
      return {
        form: new FormGroup({
          customization: new FormControl(customization, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _customizationService: CustomizationService) {     
  }

  public save(vm: { form: FormGroup}) {
    const customization = vm.form.value.customization;
    let obs$: Observable<{ customization: Customization }>;
    if(customization.customizationId) {
      obs$ = this._customizationService.update({ customization })
    }   
    else {
      obs$ = this._customizationService.create({ customization })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.customization);
        this._overlayRef.dispose();
      })
    ).subscribe();
  }

  public cancel() {
    this._overlayRef.dispose();
  }

  ngOnDestroy() {
    this._destroyed.complete();
    this._destroyed.next();
  }
}
