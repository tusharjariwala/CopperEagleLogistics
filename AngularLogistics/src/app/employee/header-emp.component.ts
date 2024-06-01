import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-header-emp',
  templateUrl: './header-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class HeaderEmpComponent implements OnInit {

  constructor(private service:restapiemployee,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
  }
  logout()
  {
    sessionStorage.clear();
    this.router.navigate(['/login']).then(() => {
      window.location.reload();
    });
  }

}
