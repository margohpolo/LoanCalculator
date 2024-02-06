import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WeatherforecastComponent } from './weatherforecast/weatherforecast.component';
import { LoanFormComponent } from './loan-form/loan-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, WeatherforecastComponent, LoanFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'LoanCalculator.Angular';
}
