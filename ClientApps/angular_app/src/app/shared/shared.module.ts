import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoaderComponent } from './components/loader/loader.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';

@NgModule({
  declarations: [
    NavbarComponent,
    LoaderComponent,
    SidenavComponent,
    ConfirmDialogComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
  ],
  exports: [
    NavbarComponent,
    LoaderComponent,
    SidenavComponent,
  ]
})
export class SharedModule { }
