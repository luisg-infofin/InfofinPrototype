import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { AddPersonComponent } from './components/add-person/add-person.component';
import { MatDialog } from '@angular/material/dialog';
import { Person } from '../../../shared/models/person.model';
import { PersonsService } from '../../services/persons.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {

  constructor(public dialog: MatDialog, public personsService: PersonsService) {
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddPersonComponent, {
      data: { name: '', email: '', address: '' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if(result.isCancel) return;
      if (!result.isEdit) {
        this.personsService.postPerson(result.person).subscribe((_) => {
          this.personsService.getPersons();
        });
      }
    });
  }

}
