import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingComponent } from './landing/landing.component';
import { PublicComponent } from './public/public.component';
import { PublicRoutingModule } from './public-routing.module';
import { HeaderModule } from '@shell/header/header.module';
import { FooterModule } from '@shell/footer/footer.module';


@NgModule({
  declarations: [LandingComponent, PublicComponent],
  imports: [
    CommonModule,
    PublicRoutingModule,
    HeaderModule,
    FooterModule
  ]
})
export class PublicModule { }
