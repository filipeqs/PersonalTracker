import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';

@NgModule({
    declarations: [AppComponent],
    imports: [CoreModule, BrowserModule, AppRoutingModule, HttpClientModule],
    providers: [{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }],
    bootstrap: [AppComponent],
})
export class AppModule {}
