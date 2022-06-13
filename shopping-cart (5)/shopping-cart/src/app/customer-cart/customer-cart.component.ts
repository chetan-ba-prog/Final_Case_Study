import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { CartService } from '../services/cart.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-customer-cart',
  templateUrl: './customer-cart.component.html',
  styleUrls: ['./customer-cart.component.css']
})
export class CustomerCartComponent implements OnInit {

  // variable declaration
  products: Product[];
  product: Product;
  custId: number;
  prodId: number;

  // constructor initialization
  constructor( private router: Router, 
               private productService: ProductService,
               private cartService : CartService,
               private route: ActivatedRoute) { }

  ngOnInit(): void {

    // storing the query parameters value to variable
    this.route.queryParams.subscribe(params => {
      this.custId = this.route.snapshot.params['custId'];
      this.prodId = this.route.snapshot.params['productId'];
    });
    
    // fetching the product details by Product ID
    this.productService.getUserById(this.prodId).subscribe(data=> {
      this.product = data;
    });
  }

  // routing to next page (Payment page)
  buyNow(){
    this.router.navigate(['/customer-payment',{custId: this.custId, prodId: this.prodId}]);
  }
  
}
