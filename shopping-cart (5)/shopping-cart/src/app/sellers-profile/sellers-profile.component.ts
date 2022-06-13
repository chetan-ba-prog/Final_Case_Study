import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Seller, sellerVM } from '../models/seller.model';
import { SellerLoginComponent } from '../seller-login/seller-login.component';
import { SellerService } from '../services/seller.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-sellers-profile',
  templateUrl: './sellers-profile.component.html',
  styleUrls: ['./sellers-profile.component.css']
})

export class SellersProfileComponent implements OnInit {

  // variable decalaration
  addSellerForm: FormGroup;
  submitted: boolean = false;
  seller: Seller;
  sellerVM = new sellerVM();
  sellerModel = new Seller();
  sellerId: number;

  // constructor initialization
  constructor(private formBuilder: FormBuilder, 
              private router: Router, 
              private sellerService: SellerService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    
    // storing the parameter details
    this.route.queryParams.subscribe(params => {
      this.sellerId=this.route.snapshot.params['sellerId'];
    });
    this.get();
  }

  get()
  {
    if(localStorage.getItem('sellerEmail')!=null){

      // fetching the seller details by sellerId
      this.sellerService.getUserById( this.sellerId)
      .subscribe(data=> {
        this.seller = data;
    });

    // saving the form details
    this.addSellerForm = this.formBuilder.group({
      sellerId: ['', Validators.required],
      sellerName: ['', Validators.required],
      sellerMobile: ['', Validators.required],
      sellerEmail:['', Validators.required],
      sellerCategory: ['', Validators.required],
      sellerAddress: ['', Validators.required],
      sellerPassword: ['', Validators.required],
      sellerConfPass: ['', Validators.required]
    });
    }
  }

  // Udpade Details 
  profileUpdate()
  {
    this.sellerModel.sellerId = this.sellerId;
   
    this.sellerService.updateUser(this.addSellerForm.value, this.sellerId).subscribe(res => {  
      {
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Your Profile Update Successfully',
          showConfirmButton: false,
          timer: 1500
        })
      }
    });
  }
}

