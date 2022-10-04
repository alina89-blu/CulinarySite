import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent {
  public hide: boolean = this.authService.isAuthenticated();
  constructor(private authService: AuthService) {}

  /* public showss() {
    if (this.authService.isAuthenticated()) {
      this.hide = true;
    }
    this.hide = false;
  }

  met() {
    this.hide = !this.hide;
  }*/
}
