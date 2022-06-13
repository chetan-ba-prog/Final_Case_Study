import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  constructor(private http: HttpClient) { }
  baseUrl:string = 'https://localhost:44353/api/Product';

  // Get All Users
  getUsers(){
    return this.http.get<Product[]>(this.baseUrl+'/GetUsers');
  }

  // Get User By Id
  getUserById(id: number){
    return this.http.get<Product>(this.baseUrl+'/'+id);
  }

  // Create User
  createUser(user: Product) {
    console.log(user);
    return this.http.post(this.baseUrl +'/CreateUser', user);
  }

  // Modify User
  updateUser(user: Product) {
    return this.http.put(this.baseUrl + '/' + user.prodId, user);
  }

  // Delete User
  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  getProduct(id: number) {
    return this.http.get<Product[]>(this.baseUrl + '/GetProduct?id=' + id);
  }
}