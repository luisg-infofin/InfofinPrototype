import { Component } from '@angular/core';
import { Observable, combineLatest } from 'rxjs';
import { Person } from '../../../../../shared/models/person.model';
import { PersonsService } from '../../../../services/persons.service';
import { MatDialog } from '@angular/material/dialog';
import { AddPersonComponent } from '../add-person/add-person.component';
import { ConfirmDialogComponent } from '../../../../../shared/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-persons-table',
  templateUrl: './persons-table.component.html',
  styleUrl: './persons-table.component.css'
})
export class PersonsTableComponent {
  displayedColumns: string[] = ['name', 'email', 'address', 'actions'];
  persons$: Observable<ReadonlyArray<Person>>;
  dataSource: ReadonlyArray<Person> = [];

  constructor(private personsService: PersonsService, private dialog: MatDialog) {
    this.persons$ = this.personsService.getPersonsAsObservable();
    this.personsService.getPersons();
    this.persons$.subscribe((persons) => {
      this.dataSource = persons;
    });
  }


  onDelete(person: Person) {
    this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: 'Delete',
        message: 'Are you sure to delete this person?'
      }
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.personsService.deletePerson(person.id).subscribe((_) => {
          this.personsService.getPersons();
        });
      }
    });
  }

  onEdit(person: Person) {
    const dialogRef = this.dialog.open(AddPersonComponent, {
      data: person
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.isCancel) return;
      if (result.isEdit) {
        this.personsService.putPerson(result.person).subscribe((_) => {
          this.personsService.getPersons();
        });
      }
    });
  }
}
