import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seller-dash-header',
  templateUrl: './seller-dash-header.component.html',
  styleUrls: ['./seller-dash-header.component.css']
})
export class SellerDashHeaderComponent implements OnInit {

  // variable decalaration
  currentpage = 'app-seller-dash';

  // constructor initialization
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.currentpage = 'app-seller-dash';
  }

   // logOff user
   logOutUser():void{
    if(localStorage.getItem("sellerEmail")!=null){
      localStorage.removeItem("sellerEmail");
      this.router.navigate(['/seller-home']);
    }
  }

  // onclick header action
  OnClickOfHeader(orientation : string)
  {
    this.currentpage = orientation;
  }
}
