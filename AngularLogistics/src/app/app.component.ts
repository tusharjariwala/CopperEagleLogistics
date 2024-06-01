import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'AngularLogistics';
  isLoggedIn= false;
  user_type:string | undefined;


  ngOnInit(): void {
    if(sessionStorage.getItem("isLoggedIn")?.toString() === "true"){
      this.isLoggedIn = true;
      this.user_type = sessionStorage.getItem("user_type")?.toString();
    }
  }
}
