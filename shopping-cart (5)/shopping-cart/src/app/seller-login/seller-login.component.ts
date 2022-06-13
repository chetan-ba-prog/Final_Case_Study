import { Component, 
         OnInit, 
         ViewChild}           from '@angular/core';
import { FormBuilder, 
         FormGroup, 
         Validators }       from '@angular/forms';
import { Router }           from '@angular/router';
import { Seller, sellerVM } from '../models/seller.model';
import { SellersProfileComponent } from '../sellers-profile/sellers-profile.component';
import { SellerService }    from '../services/seller.service';
import { StorageService }   from '../services/storage.service';

@Component({
  selector: 'app-seller-login',
  templateUrl: './seller-login.component.html',
  styleUrls: ['./seller-login.component.css']
})

export class SellerLoginComponent implements OnInit 
{
  @ViewChild(SellersProfileComponent)data:SellersProfileComponent
  sellerLoginForm     : FormGroup;
  submitted           : boolean = false;
  isUserValid         : boolean = false;
  SellerPersonId      : number;
  seller = new sellerVM();
  sellerModel = new Seller();

  constructor(
              private formBuilder: FormBuilder, 
              private router: Router, 
              public sellerService:SellerService,
              public StorageService:StorageService ) 
              { }
  
  ngOnInit() 
  {
    this.sellerLoginForm = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
      }
    );
  }
  
  // login validation
  loginSubmitted() 
  {
    this.sellerService.loginuser(this.seller)
    .subscribe(res => {
      if(res.isSuccess == true){
        this.getRecord(res.response);
          this.router.navigate(['/seller-dash-header',{sellerId: this.sellerModel.sellerId}]);
      }
      else{
        console.log("failure");
      }
    });
  }

  getRecord(sellerModel:Seller)
  {
    this.sellerModel.sellerId = sellerModel.sellerId;
    this.sellerModel.sellerAddress = sellerModel.sellerAddress;
    this.sellerModel.sellerConfPass = sellerModel.sellerConfPass;
    this.sellerModel.sellerCategory = sellerModel.sellerCategory;
    this.sellerModel.sellerEmail = sellerModel.sellerEmail;
    this.sellerModel.sellerMobile = sellerModel.sellerMobile;
    this.sellerModel.sellerName = sellerModel.sellerName;
    this.sellerModel.sellerPassword = sellerModel.sellerPassword;

    localStorage.setItem('sellerEmail',this.sellerModel.sellerEmail);
  }
}