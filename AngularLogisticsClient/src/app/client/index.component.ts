import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class IndexComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
