import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PersonalDetailsService, User, UserService } from 'src/app/shared';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html',
  styleUrls: ['./personal-details.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class PersonalDetailsComponent implements OnInit{
  user: User = {
    firstName: '',
    familyName: '',
    email: '',
    companyName: '',
    companyNumber: '',
    dateOfBirth: null,
    id: '',
    phoneNumber: ''
  };
  personalDetailsForm: FormGroup;
  submitted = false;
  isError = false;
  error = '';

  constructor(private formBuilder: FormBuilder, private userService: UserService, private personalDetailsService: PersonalDetailsService, private router: Router) {
    // http.get('https://localhost:44315/' + 'weatherforecast').subscribe(result => {
    //   console.log(result);
    // }, error => console.error(error));
  }

  ngOnInit(): void {
    this.personalDetailsForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      familyName: ['', Validators.required],
      id: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(12), Validators.pattern('[0-9]+')]],
      dateOfBirth: ['', [Validators.required, Validators.pattern('^(?:(?:10|12|0?[13578])/(?:3[01]|[12][0-9]|0?[1-9])/(?:1[8-9]\\d{2}|[2-9]\\d{3})|(?:11|0?[469])/(?:30|[12][0-9]|0?[1-9])/(?:1[8-9]\\d{2}|[2-9]\\d{3})|0?2/(?:2[0-8]|1[0-9]|0?[1-9])/(?:1[8-9]\\d{2}|[2-9]\\d{3})|0?2/29/[2468][048]00|0?2/29/[3579][26]00|0?2/29/[1][89][0][48]|0?2/29/[2-9][0-9][0][48]|0?2/29/1[89][2468][048]|0?2/29/[2-9][0-9][2468][048]|0?2/29/1[89][13579][26]|0?2/29/[2-9][0-9][13579][26])$')]],
      phoneNumber: ['', null],
      email: ['', [Validators.required, Validators.email]],
      companyName: ['', Validators.required],
      companyNumber: ['', Validators.required]
    });

    const id = localStorage.getItem("id");
    if(!id){
      return;
    }
    this.userService.getUser(id).subscribe(user => {
       this.user = user;
       this.personalDetailsForm.patchValue(user);
    }, err => console.log(err));
  }

  get f() { return this.personalDetailsForm.controls; }

  onSubmit(){
    this.submitted = true;
    this.isError = false;

    // stop here if form is invalid
    if (this.personalDetailsForm.invalid) {
      return;
    }

    this.user = this.personalDetailsForm.value;
    this.userService.updateUser(this.personalDetailsService.userId, this.user).subscribe(res =>{
      // this fields will be used in next screen
      this.personalDetailsService.companyName = this.personalDetailsForm.value.companyName;
      this.personalDetailsService.companyNumber = this.personalDetailsForm.value.companyNumber;
      this.router.navigate(['/bank-accounts']);
    });
  }

  getToolTipError(control: AbstractControl, controlName: String): String{
    if(this.submitted && control.errors){
      switch (controlName) {
        case 'firstName':
          return control.errors.required ? 'שם פרטי הינו שדה חובה' : '';
        case 'familyName':
          return control.errors.required ? 'שם משפחה הינו שדה חובה' : '';
        case 'id':{
          if(control.errors.required) return 'תעודת זהות הינה שדה חובה';
          if(control.errors.minlength || control.errors.maxlength || control.errors.pattern) return 'תעודת זהות חייבת להכיל 8-12 ספרות';
        }
        case 'dateOfBirth':{
          if(control.errors.required) return 'תאריך לידה הינו שדה חובה';
          if(control.errors.pattern) return 'dd/mm/yyyy :אנא הכנס/י תאריך לידה תקין';
        }
        case 'phoneNumber':
          return control.errors.required ? 'טלפון הינו שדה חובה' : '';
        case 'email':{
          if(control.errors.required) return 'דואר אלקטרוני הינו שדה חובה';
          if(control.errors.email) return 'example@domain.com :אנא הכנס/י דואר אלקטרוני תקין';
        }
        case 'companyName':
          return control.errors.required ? 'שם העסק הינו שדה חובה' : '';
        case 'companyNumber':
          return control.errors.required ? 'ח.פ/שותפות/עמותה הינו שדה חובה' : '';
      }
    }
    return '';
  }
}
