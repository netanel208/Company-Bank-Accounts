import { Component } from '@angular/core';
import { User, UserService } from 'src/app/shared';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html'
})
export class PersonalDetailsComponent {
  public user: User;

  constructor(private userService: UserService) {
    // http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
    const id = localStorage.getItem("id");
    userService.getUser(id).subscribe(user => { this.user = user }, err => console.log(err));
  }
}
