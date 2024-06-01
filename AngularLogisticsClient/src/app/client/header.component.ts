import { Component, OnInit, ViewEncapsulation } from '@angular/core';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class HeaderComponent implements OnInit {

  IsLoggedIn=false;
  constructor() { }

  ngOnInit(): void {
    console.log('isLoggedIn');
    console.log(sessionStorage.getItem('isLoggedIn'));
    if(sessionStorage.getItem('isLoggedIn') == "true"){

      this.IsLoggedIn = true;
    }
  }
  

}
