import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Order } from '../models/Order.model';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-seller-orders',
  templateUrl: './seller-orders.component.html',
  styleUrls: ['./seller-orders.component.css']
})
export class SellerOrdersComponent implements OnInit {

  // variable decalaration
  orders: Order[];
  sellerId: number;

  // initialzed constructor with paramaters
  constructor(private router: Router, private orderService: OrderService, 
    private route: ActivatedRoute) { }

  ngOnInit() {
     // seller id 
     this.route.queryParams.subscribe(params => {
        this.sellerId=this.route.snapshot.params['sellerId'];
        console.log(this.sellerId);
    });
    
    // display Order Details
    if(localStorage.getItem("sellerEmail") != null){
      this.orderService.getOrderBySellerId(this.sellerId)
        .subscribe(data=> {
          this.orders = data;
        });
      }
  }
}
