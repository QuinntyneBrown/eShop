import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginModule } from './login/login.module';
import { NotFoundModule } from './not-found/not-found.module';
import { baseUrl } from '@core';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LoginModule,
    NotFoundModule
  ],
  providers: [
    { provide: baseUrl, useValue: 'https://localhost:5001/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
