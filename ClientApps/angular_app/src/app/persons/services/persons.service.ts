import { Injectable } from '@angular/core';
import { Person } from '../../shared/models/person.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../env/enviroment';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  private persons: Subject<ReadonlyArray<Person>>;

  constructor(private _httpClient: HttpClient) {
    this.persons = new Subject<ReadonlyArray<Person>>();
  }

  postPerson(person: Person) {
    return this._httpClient.post<Person>(environment.apiUrl + '/crud', person);
  }

  putPerson(person: Person) {
    return this._httpClient.put<Person>(environment.apiUrl + '/crud?id=' + person.id, person);
  }

  deletePerson(id: string) {
    return this._httpClient.delete<Person>(environment.apiUrl + '/crud?id=' + id);
  }  

  getPersons() {
    this._httpClient.get<Person[]>(environment.apiUrl + '/search').subscribe(persons => {
      this.persons.next(persons);
    });
  }

  getPersonsAsObservable() {
    return this.persons.asObservable();
  }

}
