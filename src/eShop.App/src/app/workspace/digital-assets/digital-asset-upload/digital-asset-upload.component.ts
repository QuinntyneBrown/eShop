import { Component, ElementRef, forwardRef, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { fromEvent, Subject } from 'rxjs';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { DigitalAsset } from '@api';
import { DigitalAssetService } from '@api';

@Component({
  selector: 'app-digital-asset-upload',
  templateUrl: './digital-asset-upload.component.html',
  styleUrls: ['./digital-asset-upload.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DigitalAssetUploadComponent),
      multi: true
    }
  ]
})
export class DigitalAssetUploadComponent implements ControlValueAccessor {

  private readonly _destroyed$: Subject<void> = new Subject();
  public digitalAsset$: Subject<DigitalAsset> = new  Subject();

  constructor(
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _elementRef: ElementRef
  ) {
    this.onDragOver = this.onDragOver.bind(this);
    this.onDrop = this.onDrop.bind(this);
  }

  writeValue(obj: any): void { }

  public registerOnChange(fn: any): void {

    this.digitalAsset$
    .pipe(
      tap(x => fn(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  registerOnTouched(fn: any): void {

  }

  setDisabledState?(isDisabled: boolean): void {

  }


  public ngAfterViewInit(): void {
    fromEvent(this._elementRef.nativeElement,"dragover")
    .pipe(
      tap((x: DragEvent) => this.onDragOver(x)),
      takeUntil(this._destroyed$)
    ).subscribe();

    fromEvent(this._elementRef.nativeElement,"drop")
    .pipe(
      tap((x: DragEvent) => this.onDrop(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
    this._destroyed$.complete();
  }

  public onDragOver(e: DragEvent): void {
    e.stopPropagation();
    e.preventDefault();
  }

  public async onDrop(e: DragEvent): Promise<any> {
    e.stopPropagation();
    e.preventDefault();

    if (e.dataTransfer && e.dataTransfer.files) {
      const packageFiles = function (fileList: FileList): FormData {
        const formData = new FormData();
        for (var i = 0; i < fileList.length; i++) {
          formData.append(fileList[i].name, fileList[i]);
        }
        return formData;
      }

      const data = packageFiles(e.dataTransfer.files);

      this._digitalAssetService.upload({ data })
        .pipe(
          switchMap((x) => this._digitalAssetService.getByIds({ digitalAssetIds: x.digitalAssetIds })),
          tap(x => this.digitalAsset$.next(x[0])),
          takeUntil(this._destroyed$)
        )
        .subscribe();
    }
  }
}
