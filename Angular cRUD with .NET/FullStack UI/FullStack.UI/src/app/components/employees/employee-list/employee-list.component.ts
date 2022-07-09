import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employee[] = [
    {
      id: '80c60d85-6615-486d-8b92-ca0ac1d0c686',
      name: 'Osama Ahmad',
      email: 'osamahu96@gmail.com',
      phone: 998855669,
      salary: 750000,
      department: 'IT'
    },
    {
      id: 'eb9c13e3-740a-4b0a-9b8e-54484edaac02',
      name: 'Ali Raza',
      email: 'aliraza88@gmail.com',
      phone: 998855669,
      salary: 850000,
      department: 'IT'
    },
    {
      id: '901619eb-726a-4e4e-8701-4fb3e1519a62',
      name: 'Hamza Jafri',
      email: 'hamzajafri97@gmail.com',
      phone: 998855669,
      salary: 950000,
      department: 'IT'
    },
    {
      id: 'fa186d59-e7ac-4dbc-8ad7-8b3d72c67d0d',
      name: 'Saad Salman',
      email: 'saadsalman95@gmail.com',
      phone: 998855669,
      salary: 100000,
      department: 'IT'
    },
  ];

  constructor() { }

  ngOnInit(): void {
    // on component load

  }

}
