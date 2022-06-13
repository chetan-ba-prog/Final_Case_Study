import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Payment } from '../models/payment.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient ) { }
  baseUrl:string = 'https://localhost:44353/api/Payments';

  // Get All Users
  getUsers(){
    return this.http.get<Payment[]>(this.baseUrl+'/GetOrders');
  }

  // Get User By Id
  getUserById(id: number){
    return this.http.get<Payment>(this.baseUrl+'/'+id);
  }

  // Create User
  createUser(user: Payment) {
    console.log(user);
    return this.http.post(this.baseUrl +'/CreateOrders', user);
  }

  // Modify User
  updateUser(user: Payment, sellerId: number) {
    return this.http.put(this.baseUrl + '/UpdateOrders?id=' + sellerId, user);
  }

  // Delete User
  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  // Get User By Id
  getPaymentById(id: number){
    return this.http.get<Payment[]>(this.baseUrl+'/GetPaymentsBySellerId?id='+id);
  }
}
