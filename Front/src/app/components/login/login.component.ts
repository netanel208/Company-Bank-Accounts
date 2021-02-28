import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthHelper, TokenService } from 'src/app/shared';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  isError = false;
  error = '';

  constructor(private formBuilder: FormBuilder, private tokenService: TokenService, private authHelper: AuthHelper, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      id: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(12)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.isError = false;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    let authData = { "Id": this.loginForm.value.id, "Password": this.loginForm.value.password };
    this.tokenService.auth(authData).subscribe(token => {
      this.authHelper.setToken(token);
      localStorage.setItem("id", authData.Id);
      this.router.navigate(['/']);
    }, error => {
        localStorage.clear();
        this.isError = true;
        this.loading = false;
        this.error = 'Invalid details'; //need to return here object from server that contains the error messages
    });

    this.loading = true;
  }
}
