import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class EmployeeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
