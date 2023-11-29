import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../../../../../shared/models/person.model';
import { PersonsService } from '../../../../services/persons.service';

@Component({
  selector: 'app-persons-table',
  templateUrl: './persons-table.component.html',
  styleUrl: './persons-table.component.css'
})
export class PersonsTableComponent {
  displayedColumns: string[] = ['name', 'email', 'address'];
  persons$: Observable<ReadonlyArray<Person>>;
  dataSource: ReadonlyArray<Person> = [];

  constructor(private personsService: PersonsService) {
    this.persons$ = this.personsService.getPersonsAsObservable();
    this.personsService.getPersons();    
    this.persons$.subscribe((persons) => {
      this.dataSource = persons;  
    });
  }
}
