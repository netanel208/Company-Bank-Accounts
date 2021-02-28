import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { CounterComponent } from "./components/counter/counter.component";
import { FetchDataComponent } from "./components/fetch-data/fetch-data.component";
import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";
import { PersonalDetailsComponent } from "./components/personal-details/personal-details.component";
import { AuthGuard } from "./shared/guards/auth.guard";

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'personal-details' },
  { path: 'login', component: LoginComponent },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
  { path: 'personal-details', component: PersonalDetailsComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
