import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private menuIsOPen$: Subject<boolean>;
  private menuIsOPen = false;

  constructor() {
    this.menuIsOPen$ = new Subject<boolean>();
  }

  public openSideNav() {
    this.menuIsOPen$.next(true);
    this.menuIsOPen = true;
  }

  public closeSideNav() {
    this.menuIsOPen$.next(false);
    this.menuIsOPen = false;
  }

  public asObservable() {
    return this.menuIsOPen$.asObservable();
  }

  public toggle() {
    this.menuIsOPen = !this.menuIsOPen;
    this.menuIsOPen$.next(this.menuIsOPen);
  }
}
