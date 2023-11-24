import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';
import { SignoutCallbackComponent } from './components/signout-callback/signout-callback.component';
import { PersonsComponent } from './pages/persons/persons.component';

const routes: Routes = [
  { path: 'auth-callback', component: AuthCallbackComponent },
  { path: 'logout-callback', component: SignoutCallbackComponent },
  { path: 'persons', component: PersonsComponent },
  { path: '*', redirectTo: '/', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
