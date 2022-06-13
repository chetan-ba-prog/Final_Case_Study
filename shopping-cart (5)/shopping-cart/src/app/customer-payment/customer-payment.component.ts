import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-customer-payment',
  templateUrl: './customer-payment.component.html',
  styleUrls: ['./customer-payment.component.css']
})
export class CustomerPaymentComponent implements OnInit {

  // variable declaration
  custId: number;
  prodId: number;

  // customer initialization
  constructor(private router: Router, 
              private route: ActivatedRoute) { }

  ngOnInit(): void {

    // storing the query parameters value to variable
    this.route.queryParams.subscribe(params => {
      this.custId = this.route.snapshot.params['custId'];
      this.prodId = this.route.snapshot.params['prodId'];
    });

  }

  // navigation to next page -> Checkout Page
  continue(){
      this.router.navigate(['/customer-checkout',{custId: this.custId, prodId: this.prodId}]);
    }

}
