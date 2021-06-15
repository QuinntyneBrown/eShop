import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer.component';
import { SharedModule } from '@shared/shared.module';
import { HtmlContentSectionModule } from '@shared/sections';
import { FollowUsSectionModule } from '@shared/sections/follow-us-section/follow-us-section.module';



@NgModule({
  declarations: [FooterComponent],
  exports: [FooterComponent],
  imports: [
    CommonModule,
    SharedModule,
    HtmlContentSectionModule,
    FollowUsSectionModule
  ]
})
export class FooterModule { }
