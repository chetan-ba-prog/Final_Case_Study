import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { CustomerLoginComponent } from '../customer-login/customer-login.component';
import { Customer, customerVM } from '../models/customer.mode';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-profile',
  templateUrl: './customer-profile.component.html',
  styleUrls: ['./customer-profile.component.css']
})

export class CustomerProfileComponent implements OnInit {

  // variable decalaration
  addCustomerForm: FormGroup;
  submitted: boolean = false;
  customer: Customer;
  customerVM = new customerVM();
  customerModel = new Customer();
  custId: number;

  // constructor initialization
  constructor(private formBuilder: FormBuilder, 
              private router: Router, 
              private customerService: CustomerService,
              private route: ActivatedRoute) { }

  ngOnInit() {

    // storing the customer id
    this.route.queryParams.subscribe(params => {
      this.custId=this.route.snapshot.params['custId'];
    });
    this.get();
  }

  get()
  {
    if(localStorage.getItem('custEmail')!=null){

      // fetching the details of customer by Id
      this.customerService.getUserById(this.custId)
      .subscribe(data=> {
        this.customer = data;

    });

    this.addCustomerForm = this.formBuilder.group({
      custId: ['', Validators.required],
      custName: ['', Validators.required],
      custMobile: ['', Validators.required],
      custEmail:['', Validators.required],
      gender: ['', Validators.required],
      custAddress: ['', Validators.required],
      custPassword: ['', Validators.required],
      custConfPass: ['', Validators.required]
    });
    }
  }

  // Udpade Details Code
  profileUpdate()
  {
    this.customerModel.custId = this.custId;
    // updating the details
    this.customerService.updateUser(this.addCustomerForm.value, this.custId).subscribe(res => {  
      {
        alert();
      }
    });
  }

   // Alert Code 
   alert()
   {
     Swal.fire({
       position: 'top-end',
       icon: 'success',
       title: 'Your profile has been updated successfully!',
       showConfirmButton: false,
       timer: 1500
     })
   }
 
}
