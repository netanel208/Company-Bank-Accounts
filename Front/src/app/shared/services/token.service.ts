import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AppConfig } from '../../config/config';
import { BaseService } from './base.service';
import { AuthHelper } from '../helpers';


@Injectable()
export class TokenService extends BaseService {
  private pathAPI = this.config.setting['PathAPI'];
  public errorMessage: string;

  constructor(private http: HttpClient, private config: AppConfig, helper: AuthHelper) {
    super(helper);
  }

  auth(data: any): Observable<any> {
    let body = JSON.stringify(data);
    return this.getToken(body);
  }

  private getToken(body: any): Observable<any> {
    return this.http.post<any>(this.pathAPI + 'Auth', body, super.header()).pipe(
      catchError(super.handleError)
    );
  }
}
