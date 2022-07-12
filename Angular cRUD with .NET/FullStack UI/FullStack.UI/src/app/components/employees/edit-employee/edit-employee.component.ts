import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  employee: Employee = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    department: ''
  };

  constructor(private route: ActivatedRoute, private router: Router, private employeeService: EmployeesService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.employeeService.getEmployee(id).
          subscribe({
            next: (employee) => {
              this.employee = employee;
            },
            error: (response) => {
              console.log(response);
            }
          })
        }
      }
    });
  }

  updateEmployee(){
    this.employeeService.updateEmployee(this.employee.id, this.employee)
    .subscribe({
      next: (employee) => {
        this.router.navigate(['employees', 'View', employee.id]);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
