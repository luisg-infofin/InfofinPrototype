import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';
import { SignoutCallbackComponent } from './components/signout-callback/signout-callback.component';


const routes: Routes = [
  { path: 'auth-callback', component: AuthCallbackComponent },
  { path: 'logout-callback', component: SignoutCallbackComponent },  
  { path: '**', redirectTo: '/persons/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
