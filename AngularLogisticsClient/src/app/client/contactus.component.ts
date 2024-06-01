import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { restapi } from 'src/app/services/restapiservice';
import { insertcontactresponse } from '../models/insertcontactresponse';
import { showcontactdata } from '../models/showcontactdata';

@Component({
  selector: 'app-contactus',
  templateUrl: './contactus.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ContactusComponent implements OnInit {

  insertresponse! : insertcontactresponse
  contactdata: showcontactdata = {
    contact_id_pk: 0,
    contact_name:"",
    contact_email:"",
    contact_subject: "",
    contact_message:"",
    isactive: 1
  }
  contact_id_pk=0;

  constructor(public service :restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    
      this.contactdata = new showcontactdata()
  }

  onsubmit(form:NgForm)
  {

    
      this.insertdetails(form)

  }

  insertdetails(form:NgForm)
  {
    this.service.AddContact(this.contactdata).subscribe(res=>{
      this.insertresponse = res as insertcontactresponse
      if(this.insertresponse.result === "success")
      {
        this.resetform(form)
        this.router.navigate(['/client/thank-you'],{relativeTo:this.route});
      }
      else
      {
        console.log(res)
      }
      },err => {
        console.log(err)
     })
  }

  resetform(form:NgForm)
{
  form.form.reset();
  this.contactdata = new showcontactdata();
}


}
