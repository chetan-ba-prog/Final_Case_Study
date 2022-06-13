import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cart } from '../models/cart.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient ) { }
  baseUrl:string = 'https://localhost:44353/api/Cart';

  // Get All Users
  getUsers(){
    return this.http.get<Cart[]>(this.baseUrl+'/GetUsers');
  }

  // Get User By Id
  getUserById(id: number){
    return this.http.get<Cart>(this.baseUrl+'/'+id);
  }

  // Create User
  createUser(user: Cart) {
    console.log(user);
    return this.http.post(this.baseUrl +'/CreateUser', user);
  }

  // Modify User
  updateUser(user: Cart, sellerId: number) {
    return this.http.put(this.baseUrl + '/UpdateUser?id=' + sellerId, user);
  }

  // Delete User
  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  // Get User By Id
  getCartById(id: number){
    return this.http.get<Cart[]>(this.baseUrl+'/GetCartByCust?id='+id);
  }

}
