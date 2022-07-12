import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { EmployeeListComponent } from './components/employees/employee-list/employee-list.component';
import { ViewEmployeeComponent } from './components/employees/view-employee/view-employee.component';

const routes: Routes = [
  {
    path: 'employees',
    component: EmployeeListComponent
  },
  {
    path: 'employees/Add',
    component: AddEmployeeComponent
  },
  {
    path: 'employees/View/:id',
    component: ViewEmployeeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
