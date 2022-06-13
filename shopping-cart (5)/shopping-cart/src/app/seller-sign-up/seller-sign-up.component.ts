import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SellerService } from '../services/seller.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-seller-sign-up',
  templateUrl: './seller-sign-up.component.html',
  styleUrls: ['./seller-sign-up.component.css']
})

export class SellerSignUpComponent implements OnInit {

  // variable declaration
  addSellerForm: FormGroup;
  submitted: boolean = false;

  // constructo initialization
  constructor(private formBuilder: FormBuilder, 
              private router: Router, 
              private sellerService: SellerService) { }

  ngOnInit() {

    // save form details
    this.addSellerForm = this.formBuilder.group({
      sellerName: ['', Validators.required],
      sellerMobile: ['', Validators.required],
      sellerEmail:['', Validators.required],
      sellerCategory: ['', Validators.required],
      sellerAddress: ['', Validators.required],
      sellerPassword: ['', Validators.required],
      sellerConfPass: ['', Validators.required],
    });
  }
  
  // Post Submit -> Save Detils 
  onSubmit() {
    this.submitted = true;
    if(this.addSellerForm.invalid){
      return;
    }

    // save details to tables
    this.sellerService.createUser(this.addSellerForm.value)
      .subscribe( data => {
        this.router.navigate(['seller-login']);
        this.singupAlert();
    });
  }

  singupAlert()
  {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Account Created Successfully!',
      showConfirmButton: false,
      timer: 1500
    })
  }
}
