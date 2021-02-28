import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BankAccount, BankAccountsService, CompanyHolding, CompanyHoldingService, PersonalDetailsService } from 'src/app/shared';

@Component({
  selector: 'app-bank-accounts-component',
  templateUrl: './bank-accounts.component.html',
  styleUrls: ['./bank-accounts.component.scss']
})

export class BankAccountsComponent implements OnInit{
  companyHoldingForm: FormGroup;
  companyName: string = '';
  companyNumber: string = '';
  accounts: BankAccount[] = [];

  constructor(private formBuilder: FormBuilder, private personalDetailsService: PersonalDetailsService, private companyHoldingService: CompanyHoldingService, private bankAccountsService: BankAccountsService){}
  
  ngOnInit(): void {
    this.companyHoldingForm = this.formBuilder.group({
      holding: ['', Validators.required],
    });

    this.companyName = this.personalDetailsService.companyName + '';
    this.companyNumber = this.personalDetailsService.companyNumber + '';
    this.companyNumber = this.companyNumber.slice(0, 2) + '-' + this.companyNumber.slice(2);

    const userId = this.personalDetailsService.userId;
    const companyId = this.personalDetailsService.companyNumber;
    this.companyHoldingService.getCompanyHolding(userId, companyId).subscribe(companyHolding => {
      let formVal = { holding: companyHolding.holding };
      this.companyHoldingForm.patchValue(formVal);
    });

    this.bankAccountsService.getBankAccounts(userId).subscribe(bankAccounts => {
      this.accounts = bankAccounts ? bankAccounts : [];
    });
  }

  get f(){ return this.companyHoldingForm.controls; }
  get holdingRange(){ return Array.from(Array(101).keys()); }
  
  changeHolding(e){
    if(e.target.value >= 0 && e.target.value <= 100){
      const userId = this.personalDetailsService.userId;
      const companyId = this.personalDetailsService.companyNumber;
      const companyHolding : CompanyHolding = {
        userId: userId,
        companyId: companyId, 
        holding: e.target.value
      };

      //need to wrap response with global response that contains: is_success, error_messages, response
      this.companyHoldingService.saveCompanyHolding(userId, companyHolding).subscribe(res => {
        
      }, err => {
        
      });
    }
  }

  addAccount(){
    this.accounts.push({
      accountNumber: '',
      bankBranch: '',
      bankName: '',
      companyId: '',
      id: '',
      userId: ''
    });
  }

  deleteAccount(e: string){
    if(e === undefined || e === ''){
      const index = this.accounts.findIndex(el => el.id === '');
      if(index == -1) return;
      this.accounts.splice(index, 1);
      console.log(this.accounts)
    }
  }
}
