import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { BaseService } from './base.service';
import { CompanyHolding } from '../models';
import { AppConfig } from '../../config/config';
import { AuthHelper } from '../helpers/auth.helper';

@Injectable()
export class CompanyHoldingService extends BaseService {
  private pathAPI = this.config.setting['PathAPI'];

  constructor(private http: HttpClient, private config: AppConfig, helper: AuthHelper) { super(helper); }

  getCompanyHolding(userId: string, companyId: string): Observable<CompanyHolding> {
    let headerses = super.header(); 
    let params = new HttpParams().set("userId", userId).set("companyId", companyId);
    let options = { params: params, headers: headerses.headers };
    return this.http.get<CompanyHolding>(this.pathAPI + 'CompanyHolding', options).pipe(catchError(super.handleError));
  }

  saveCompanyHolding(userId: string, companyHolding: CompanyHolding): Observable<any>{
    let headerses = super.header();
    return this.http.post(this.pathAPI + 'CompanyHolding/' + userId, companyHolding, headerses).pipe(catchError(super.handleError));
  }
}