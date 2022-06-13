import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-inner-navbar',
  templateUrl: './customer-inner-navbar.component.html',
  styleUrls: ['./customer-inner-navbar.component.css']
})
export class CustomerInnerNavbarComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

   // logOff user
   logOutUser():void{
    if(localStorage.getItem("custEmail")!=null){
      localStorage.removeItem("custEmail");
      this.router.navigate(['/home']);
    }
  }

  profile(){
    this.router.navigate(['/customer-profile',{custId: 1}]);
  }
}
