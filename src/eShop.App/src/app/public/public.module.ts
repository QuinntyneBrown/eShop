import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingComponent } from './landing/landing.component';
import { PublicComponent } from './public/public.component';
import { PublicRoutingModule } from './public-routing.module';
import { HeaderModule } from '@shared/header/header.module';
import { FooterModule } from '@shared/footer/footer.module';
import { ProductGridModule } from '@shared/product-grid/product-grid.module';


@NgModule({
  declarations: [LandingComponent, PublicComponent],
  imports: [
    CommonModule,
    PublicRoutingModule,
    HeaderModule,
    FooterModule,
    ProductGridModule
  ]
})
export class PublicModule { }
