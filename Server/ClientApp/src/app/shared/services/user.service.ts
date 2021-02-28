import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { BaseService } from './base.service';
import { User } from '../models';
import { AppConfig } from '../../config/config';
import { AuthHelper } from '../helpers/auth.helper';

@Injectable()
export class UserService extends BaseService {
  private pathAPI = this.config.setting['PathAPI'];

  constructor(private http: HttpClient, private config: AppConfig, helper: AuthHelper) { super(helper); }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(this.pathAPI + 'User/'+ id, super.header()).pipe(catchError(super.handleError));
  }
}
