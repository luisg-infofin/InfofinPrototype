import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ListComponent } from './pages/list/list.component';
import { AutoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';



const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'list', component: ListComponent, canActivate: [AutoLoginPartialRoutesGuard] },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonsRoutingModule { }
