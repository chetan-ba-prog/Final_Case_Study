import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Payment } from '../models/payment.model';
import { PaymentService } from '../services/payment.service';

@Component({
  selector: 'app-seller-payment-details',
  templateUrl: './seller-payment-details.component.html',
  styleUrls: ['./seller-payment-details.component.css']
})
export class SellerPaymentDetailsComponent implements OnInit {

  sellerId : number;
  payments: Payment[];

  constructor(private router: Router, private paymentService: PaymentService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

     // seller id 
     this.route.queryParams.subscribe(params => {
      this.sellerId=this.route.snapshot.params['sellerId'];
      console.log("SellerId: " +this.sellerId);
    });

    if(localStorage.getItem('sellerEmail') != null){

      this.paymentService.getPaymentById(this.sellerId)
        .subscribe(data=> {
          this.payments = data;
        });
        
      }
  }
}
