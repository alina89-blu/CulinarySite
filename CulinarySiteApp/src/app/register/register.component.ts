import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  public ngOnInit(): void {}

  public register(): void {
    this.authService.register(this.registerForm.value).subscribe((data) => {
      console.log(data);
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
