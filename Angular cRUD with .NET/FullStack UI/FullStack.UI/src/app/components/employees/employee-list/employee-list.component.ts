import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employee[] = [];

  constructor(private employeeService: EmployeesService, private router: Router) { }

  ngOnInit(): void {
    // on component load

    // get all employees from the endpoint
    this.employeeService.getAllEmployees()
    .subscribe({
      next: (employees) => {
        this.employees = employees;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  deleteEmployee(id: string){
    this.employeeService.deleteEmployee(id).
    subscribe({
      next: (employee) => {
        console.log(employee);
        this.router.navigate(['/']);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
