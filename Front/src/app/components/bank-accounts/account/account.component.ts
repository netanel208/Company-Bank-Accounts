import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  @Input() account = '';
  @Output() deleteAccount = new EventEmitter<any>();
  bankAccountForm: FormGroup;


  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.bankAccountForm = this.formBuilder.group({
      holding: ['', Validators.required],
      bankBranch: ['', Validators.required],
      accountNumber: ['', Validators.required],
    });
  }

  deleteAccountClick(id) {
    this.deleteAccount.emit(id);
  }

}
