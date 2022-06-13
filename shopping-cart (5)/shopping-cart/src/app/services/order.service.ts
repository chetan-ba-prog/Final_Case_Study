import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/Order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient ) { }
  baseUrl:string = 'https://localhost:44353/api/Orders';

  // Get All Users
  getUsers(){
    return this.http.get<Order[]>(this.baseUrl+'/GetOrders');
  }

  // Get User By Id
  getUserById(id: number){
    return this.http.get<Order>(this.baseUrl+'/'+id);
  }

  // Create User
  createUser(user: Order) {
    console.log(user);
    return this.http.post(this.baseUrl +'/CreateOrders', user);
  }

  // Modify User
  updateUser(user: Order, sellerId: number) {
    return this.http.put(this.baseUrl + '/UpdateOrders?id=' + sellerId, user);
  }

  // Delete User
  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  // Get User By Id
  getOrderBySellerId(id: number){
    return this.http.get<Order[]>(this.baseUrl+'/GetOrdersBySellerId?id='+id);
  }

}
