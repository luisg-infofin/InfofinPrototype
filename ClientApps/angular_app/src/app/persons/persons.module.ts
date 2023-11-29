import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { AngularMaterialModule } from '../shared/angular-material/angular-material.module';
import { PersonsRoutingModule } from './persons-routing.module';
import { ListComponent } from './pages/list/list.component';
import { AddPersonComponent } from './pages/list/components/add-person/add-person.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { PersonsTableComponent } from './pages/list/components/persons-table/persons-table.component';

@NgModule({
  declarations: [
    HomeComponent,
    ListComponent,
    AddPersonComponent,
    PersonsTableComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    PersonsRoutingModule,
    FormsModule,
    ReactiveFormsModule,    
    MatFormFieldModule
  ],
  exports: [PersonsRoutingModule]
})
export class PersonsModule { }
