import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-seller-view-product',
  templateUrl: './seller-view-product.component.html',
  styleUrls: ['./seller-view-product.component.css']
})
export class SellerViewProductComponent implements OnInit {

  // variable decalaration
  products: Product[];
  sellerId: number;

  // constructor initialization
  constructor( private router: Router, 
              private productService: ProductService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {

     // storing parameter details
     this.route.queryParams.subscribe(params => {
      this.sellerId=this.route.snapshot.params['sellerId'];
    });

    if(localStorage.getItem('sellerEmail')!=null){
      
      // fetching the product details
      this.productService.getProduct(this.sellerId)
        .subscribe(data=> {
          this.products = data;
        });
      }
  }
}
