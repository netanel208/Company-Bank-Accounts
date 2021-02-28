import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import {MatTooltipModule } from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { BankAccountsComponent } from './components/bank-accounts/bank-accounts.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthGuard, AuthHelper, BankAccountsService, CompanyHoldingService, PersonalDetailsService, TokenService, UserService } from './shared';
import { LoginComponent } from './components/login/login.component';
import { AppConfig } from './config/config';
import { PersonalDetailsComponent } from './components/personal-details/personal-details.component';
import { AccountComponent } from './components/bank-accounts/account/account.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BankAccountsComponent,
    FetchDataComponent,
    PersonalDetailsComponent,
    LoginComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTooltipModule,
    MatSelectModule,
    AppRoutingModule
  ],
  providers: [AuthGuard, AuthHelper, AppConfig, TokenService, UserService, PersonalDetailsService, CompanyHoldingService, BankAccountsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
