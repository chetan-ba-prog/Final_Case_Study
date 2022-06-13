import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer, customerVM } from '../models/customer.mode';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-login',
  templateUrl: './customer-login.component.html',
  styleUrls: ['./customer-login.component.css']
})

export class CustomerLoginComponent implements OnInit {

  // variable decalaration
  customerLoginForm: FormGroup;
  submitted: boolean = false;
  isUserValid : boolean = false;
  customer = new customerVM();
  customerModel = new Customer();

  // constructor initialization
  constructor(private formBuilder: FormBuilder, 
              private router: Router, 
              public customerService : CustomerService) { }

  ngOnInit() {
    this.customerLoginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // login validation
  loginSubmitted() 
  {
    this.customerService.loginuser(this.customer)
    .subscribe(res => {
      if(res.isSuccess == true){
        this.getRecord(res.response);
          console.log(res);
          this.router.navigate(['/products',{custId: this.customerModel.custId}]);      }
      else{
        console.log("failure");
      }
    });
  }

  // get Details
  getRecord(customerModel:Customer)
  {
    this.customerModel.custId = customerModel.custId;
    this.customerModel.custName = customerModel.custName;
    this.customerModel.gender = customerModel.gender;
    this.customerModel.custAddress = customerModel.custAddress;
    this.customerModel.custEmail = customerModel.custEmail;
    this.customerModel.custMobile = customerModel.custMobile;
    this.customerModel.custPassword = customerModel.custPassword;
    this.customerModel.custConfPass = customerModel.custConfPass;

    // store session 
    localStorage.setItem('custEmail',this.customerModel.custEmail);
  }
}
