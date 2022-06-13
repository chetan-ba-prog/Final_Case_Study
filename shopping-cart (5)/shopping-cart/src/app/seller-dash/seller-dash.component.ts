import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-seller-dash',
  templateUrl: './seller-dash.component.html',
  styleUrls: ['./seller-dash.component.css']
})
export class SellerDashComponent implements OnInit {

  // variable declaration
  sellerId: number;

  // constructor initialization
  constructor( private route: ActivatedRoute) { }

  ngOnInit(): void {
    //storing the parameter details
    this.route.queryParams.subscribe(params => {
      this.sellerId=this.route.snapshot.params['sellerId'];
    });
  }
}
