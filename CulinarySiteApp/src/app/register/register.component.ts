import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;

  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly router: Router
  ) {}

  public ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  public register(): void {
    this.authService.register(this.registerForm.value).subscribe(() => {
      this.router.navigate(['login']);
    });
  }

  public get username() {
    return this.registerForm.get('username');
  }

  public get email() {
    return this.registerForm.get('email');
  }

  public get password() {
    return this.registerForm.get('password');
  }
}
