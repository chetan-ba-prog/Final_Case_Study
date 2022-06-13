import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-seller-add-product',
  templateUrl: './seller-add-product.component.html',
  styleUrls: ['./seller-add-product.component.css']
})
export class SellerAddProductComponent implements OnInit {

   // variable declaration
   addProductForm: FormGroup;
   submitted: boolean = false;
   sellerId: number;

  // constructor initialization
  constructor( private formBuilder: FormBuilder, 
              private router: Router, 
              private productService: ProductService, 
              private route: ActivatedRoute) { }

  ngOnInit(): void {

    // storing the parameter details
    this.route.queryParams.subscribe(params => {
      this.sellerId=this.route.snapshot.params['sellerId'];
      console.log(this.sellerId);
    });

    // storing the form value
    this.addProductForm = this.formBuilder.group({
      prodName: ['', Validators.required], 
      prodDesc: ['', Validators.required], 
      prodImage:['', Validators.required], 
      prodCategory: ['', Validators.required], 
      prodPrice: ['', Validators.required], 
      prodDiscount: ['', Validators.required], 
      prodStatus: ['', Validators.required],
      sellerId: ['', Validators.required], 
    });
  }

   // Post Submit -> Save Detils 
   onSubmit() {
    this.submitted = true;
    if(this.addProductForm.invalid){
      return;
    }
    this.productService.createUser(this.addProductForm.value)
      .subscribe( data => {
        this.addProductAlert();
        this.ngOnInit();
    });
  }

  addProductAlert()
  {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Product Added Successfully!',
      showConfirmButton: false,
      timer: 1500
    })
  }

}
