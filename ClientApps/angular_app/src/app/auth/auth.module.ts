import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';
import { SignoutCallbackComponent } from './components/signout-callback/signout-callback.component';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
  declarations: [
    AuthCallbackComponent,
    SignoutCallbackComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
  ],
  exports: [AuthRoutingModule]
})
export class AppAuthModule { }
