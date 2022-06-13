import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Seller, sellerVM } from '../models/seller.model';
import { Observable, tap } from 'rxjs';
import { Result } from '../models/response.model';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class SellerService {

  constructor(private http:HttpClient,public service : DataService ) { }
  baseUrl:string = 'https://localhost:44353/api/Seller';

  // Get All Users
  getUsers(){
    return this.http.get<Seller[]>(this.baseUrl+'/GetUsers');
  }

  // Get User By Id
  getUserById(id: number){
    return this.http.get<Seller>(this.baseUrl+'/'+id);
  }

  // Create User
  createUser(user: Seller) {
    console.log(user);
    return this.http.post(this.baseUrl +'/CreateUser', user);
  }

  // Modify User
  updateUser(user: Seller, sellerId: number) {
    return this.http.put(this.baseUrl + '/UpdateUser?id=' + sellerId, user);
  }

  // Delete User
  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  public loginuser(saller:sellerVM):Observable<Result>
  {
    let url='/LoginUser' ;
    return this.service.post(url,saller,true).pipe<Result>(tap((response:any)=>{
      return response;
    }))
  }
} 
