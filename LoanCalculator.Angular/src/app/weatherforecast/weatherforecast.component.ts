import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from '../interfaces/weatherforecast';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weatherforecast',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './weatherforecast.component.html',
  styleUrl: './weatherforecast.component.css'
})
export class WeatherforecastComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/api/weatherforecast').subscribe(result => {
      next: this.forecasts = result;
      error: console.error
    });
  }

  title = 'WeatherForecast';

}
