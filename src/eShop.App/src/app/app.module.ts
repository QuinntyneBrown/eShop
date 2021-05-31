import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginModule } from './login/login.module';
import { NotFoundModule } from './not-found/not-found.module';
import { baseUrl, HeadersInterceptor, JwtInterceptor } from '@core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

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
    { provide: baseUrl, useValue: 'https://oliviarosehomedecor.azurewebsites.net/' },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HeadersInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
