import { Component, OnInit } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Customer } from '../models/customer.mode';
import { Product } from '../models/product.model';
import { CustomerService } from '../services/customer.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-customer-checkout',
  templateUrl: './customer-checkout.component.html',
  styleUrls: ['./customer-checkout.component.css']
})

export class CustomerCheckoutComponent implements OnInit {

  // variable declaration
  custId: number;
  prodId: number;
  product: Product;
  customer: Customer;

  // constructor intialization
  constructor(private router: Router, 
              private route: ActivatedRoute,
              private productService: ProductService,
              private customerService: CustomerService,) { }

  ngOnInit(): void {

    // storing the query parameters value to variable
    this.route.queryParams.subscribe(params => {
      this.custId = this.route.snapshot.params['custId'];
      this.prodId = this.route.snapshot.params['prodId'];
    });
    
    // fetching the product details by Product ID
    this.productService.getUserById(this.prodId).subscribe(data=> {
      this.product = data;
    });

    // fetching the customer details by Product ID
    this.customerService.getUserById(this.custId).subscribe(data=> {
      this.customer = data;
    });
  }

  // submit function
  submit(){
    this.router.navigate(['customer-invoice', {custId: this.custId, prodId: this.prodId}]);
    this.placeOrder();
  }

  //alert for Place Order
  placeOrder()
  {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Order is Placed Successfully!',
      showConfirmButton: false,
      timer: 1500
    })
  }
}