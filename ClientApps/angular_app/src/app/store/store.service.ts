import { Injectable } from '@angular/core';
import { Action, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../shared/interfaces/appState.interface';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private store: Store<AppState>) { }

  executeAction(action: Action) {
    this.store.dispatch(action);
  }

  getState<T>(selector: (state: AppState) => T): Observable<T> {
    return this.store.select(selector);
  }

}
