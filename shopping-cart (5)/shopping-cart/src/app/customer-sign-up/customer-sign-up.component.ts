import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-sign-up',
  templateUrl: './customer-sign-up.component.html',
  styleUrls: ['./customer-sign-up.component.css']
})

export class CustomerSignUpComponent implements OnInit {

  // variable declaration
  addCustomerForm: FormGroup;
  submitted: boolean = false;

  // constructor initialization
  constructor(private formBuilder: FormBuilder, 
              private router: Router, 
              private customerService: CustomerService) { }

  ngOnInit() {

    // add form value
    this.addCustomerForm = this.formBuilder.group({
      custName: ['', Validators.required],
      gender: ['', Validators.required],
      custAddress: ['', Validators.required],
      custEmail:['', Validators.required],
      custMobile: ['', Validators.required],
      custPassword: ['', Validators.required],
      custConfPass: ['', Validators.required],
    });
  }
  
  // Post Submit -> Save Details
  onSubmit() {
    this.submitted = true;
    if(this.addCustomerForm.invalid){
      return;
    }
    this.customerService.createUser(this.addCustomerForm.value)
      .subscribe( data => {
        alert('Customer Account Created Successfully!');
        this.router.navigate(['customer-login']);
      });
  }
}
