import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Cart } from '../models/cart.model';
import { Customer } from '../models/customer.mode';
import { Product } from '../models/product.model';
import { CartService } from '../services/cart.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  // variable decalaration
  products: Product[];
  productId: number;
  customer : Customer;
  custId : number;
  cart = new Cart;

  // constructor initialization
  constructor(private router: Router,
              private productService: ProductService,
              public cartService : CartService, 
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    
    // storing the parameters
    this.route.queryParams.subscribe(params => {
      this.custId=this.route.snapshot.params['custId'];
    });

    // fetching all the products
    this.productService.getUsers()
      .subscribe(data=> {
        this.products = data;
      });
  }

  // adding the product to cart
  addToCart(prodId : number){
    this.productId = prodId;
    if(localStorage.getItem('custEmail') != null && this.custId != undefined){
      this.cart.cartId = 0;
      this.cart.custId = this.custId;
      this.cart.prodId=  prodId ;

      // saving the details to cart table
      this.cartService.createUser(this.cart)
      .subscribe( data => {
        this.router.navigate(['/customer-cart',{productId: this.productId, custId: this.custId}]);
        this.addToCartAlert();
      });
    } 
    else {
      console.log("failure");
      this.router.navigate(['/customer-login']);
    }
  }

  addToCartAlert()
  {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Product Added to Cart!',
      showConfirmButton: false,
      timer: 1500
    })
  }
}
