import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BankAccount, BankAccountsService, PersonalDetailsService } from 'src/app/shared';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  @Input() account: BankAccount = {
    id: '',
    userId: '',
    companyId: '',
    accountNumber: '',
    bankBranch: '',
    bankName: ''
  };
  @Output() deleteAccount = new EventEmitter<any>();
  bankAccountForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private bankAccountsService: BankAccountsService, private personalDetailsService: PersonalDetailsService) { }

  ngOnInit() {
    this.bankAccountForm = this.formBuilder.group({
      bankName: ['', Validators.required],
      bankBranch: ['', Validators.required],
      accountNumber: ['', Validators.required],
    });

    console.log(this.account)
  }

  get f(){ return this.bankAccountForm.controls; }

  deleteAccountClick(id) {
    this.deleteAccount.emit(id);
  }

  changeAccount(){
    if(this.bankAccountForm.errors){
      return;
    }

    if(this.bankAccountForm.value.bankName != '' && this.bankAccountForm.value.bankName != null &&
        this.bankAccountForm.value.bankBranch != '' && this.bankAccountForm.value.bankBranch != null &&
        this.bankAccountForm.value.accountNumber != '' && this.bankAccountForm.value.accountNumber != null)
      {
        const userId = this.personalDetailsService.userId;
        const companyId = this.personalDetailsService.companyNumber;
        this.account.userId = userId;
        this.account.companyId = companyId;
        this.account.bankName = this.bankAccountForm.value.bankName;
        this.account.bankBranch = this.bankAccountForm.value.bankBranch;
        this.account.accountNumber = this.bankAccountForm.value.accountNumber;
        this.bankAccountsService.SaveBankAccount(userId, this.account).subscribe(res => {
          alert('Success!');
        })
      }
  }
}
