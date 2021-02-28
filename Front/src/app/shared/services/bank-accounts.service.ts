import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { BaseService } from './base.service';
import { BankAccount, User } from '../models';
import { AppConfig } from '../../config/config';
import { AuthHelper } from '../helpers/auth.helper';

@Injectable()
export class BankAccountsService extends BaseService {
  private pathAPI = this.config.setting['PathAPI'];

  constructor(private http: HttpClient, private config: AppConfig, helper: AuthHelper) { super(helper); }

  getBankAccounts(userId: string): Observable<BankAccount[]> {
    return this.http.get<BankAccount[]>(this.pathAPI + 'BankAccounts/'+ userId, super.header()).pipe(catchError(super.handleError));
  }

  SaveBankAccount(id: string, bankAccount: BankAccount): Observable<any> {
    return this.http.post(this.pathAPI + 'BankAccounts/'+ id, bankAccount, super.header()).pipe(catchError(super.handleError));
  }

  deleteBankAccount(userId: string, bankId: string): Observable<any> {
    let headerses = super.header(); 
    let params = new HttpParams().set("userId", userId).set("bankId", bankId);
    let options = { params: params, headers: headerses.headers };
    return this.http.delete(this.pathAPI + 'BankAccounts', options).pipe(catchError(super.handleError));
  }
}