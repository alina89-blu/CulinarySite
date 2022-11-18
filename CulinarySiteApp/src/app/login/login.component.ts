import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;

  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly router: Router
  ) {}

  public ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required],
    });
    console.log(this.loginForm);
  }

  public login(): void {
    this.authService.login(this.loginForm.value).subscribe((data) => {
      this.authService.saveToken(data.token);
      this.router.navigateByUrl('');
    });
  }

  public get username() {
    return this.loginForm.get('username');
  }

  public get password() {
    return this.loginForm.get('password');
  }
}
