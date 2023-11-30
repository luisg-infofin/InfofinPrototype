import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AngularMaterialModule } from './shared/angular-material/angular-material.module';
import { PersonsModule } from './persons/persons.module';
import { AppAuthModule } from './auth/auth.module';
import { SharedModule } from './shared/shared.module';
import { StoreService } from './store/store.service';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { appStore } from './store/app.stores';
import { LoaderInterceptor } from './shared/interceptors/loader.interceptor';
import { AuthInterceptor, AuthModule } from 'angular-auth-oidc-client';
import { oidConfig } from './auth/services/oidConfig';
import { AppHttpInterceptor } from './shared/interceptors/app.http.interceptor';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    StoreModule.forRoot(appStore),
    StoreDevtoolsModule.instrument({ maxAge: 50 }),
    AngularMaterialModule,
    PersonsModule,
    SharedModule,
    AppAuthModule,
    AuthModule.forRoot({
      config: oidConfig
    })
  ],
  providers: [
    {
      useClass: LoaderInterceptor,
      provide: HTTP_INTERCEPTORS,
      multi: true
    },
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true },
    StoreService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
