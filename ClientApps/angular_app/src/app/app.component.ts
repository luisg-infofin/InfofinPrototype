import { Component, OnInit, ViewChild } from '@angular/core';
import { MenuService } from './services/menu.service';
import { Observable } from 'rxjs';
import { MatDrawer } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  @ViewChild('drawer', { static: true }) drawer!: MatDrawer;
  title = 'angular_app';
  isSideNavOpen: Observable<boolean>;

  constructor(public menuService: MenuService) {
    this.isSideNavOpen = this.menuService.asObservable();
  }

  ngOnInit(): void {
    this.drawer.closedStart.subscribe((_) => {
      this.menuService.closeSideNav();
    });
  }
}
