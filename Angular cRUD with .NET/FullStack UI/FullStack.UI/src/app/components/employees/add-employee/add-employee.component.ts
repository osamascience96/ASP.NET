import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  employee: Employee = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    department: ''
  };

  constructor(private employeeService: EmployeesService, private router: Router) { }

  ngOnInit(): void {
  }

  addEmployee(){
    this.employeeService.addEmployee(this.employee)
    .subscribe({
      next: (employee) => {
        this.router.navigate(['employees']);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
