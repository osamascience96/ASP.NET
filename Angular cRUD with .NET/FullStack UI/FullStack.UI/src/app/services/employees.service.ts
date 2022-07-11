import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl: String = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.baseApiUrl + "api/Employees");
  }

  addEmployee(employee: Employee): Observable<Employee>{
    return this.http.post<Employee>(this.baseApiUrl + "api/Employees", employee);
  }
}
