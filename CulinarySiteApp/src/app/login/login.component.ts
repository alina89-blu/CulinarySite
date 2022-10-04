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
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required],
    });
    console.log(this.loginForm);
  }

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginForm.value).subscribe(
      (data) => {
        this.authService.saveToken(data['token']);
        //this.router.navigateByUrl('book');
      },
      () => this.router.navigateByUrl('')
    );
  }

  public get username() {
    console.log(this.loginForm.get('username'));
    return this.loginForm.get('username');
  }

  public get password() {
    return this.loginForm.get('password');
  }
}
