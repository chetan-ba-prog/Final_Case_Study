import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Customer, customerVM } from '../models/customer.mode';
import { Result } from '../models/response.model';
import { CustomerDataService } from './customer-data.service';

@Injectable({
  providedIn: 'root'
})

@Injectable()
export class CustomerService {

  constructor(private http:HttpClient, public service : CustomerDataService) { }
  baseUrl:string = 'https://localhost:44353/api/Customer';

  // Get All Users
  getUsers(){
    return this.http.get<Customer[]>(this.baseUrl+'/GetUsers');
  }

  // Get User By Id
  getUserById(id: number){
    return this.http.get<Customer>(this.baseUrl+'/'+id);
  }

  // Create User
  createUser(user: Customer) {
    console.log(user);
    return this.http.post(this.baseUrl +'/CreateUser', user);
  }

  // Modify User
  updateUser(user: Customer, custId: number) {
    return this.http.put(this.baseUrl + '/UpdateUser?id=' + custId, user);
  }

  // Delete User
  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  public loginuser(customer:customerVM):Observable<Result>
  {
    let url='/LoginUser' ;
    return this.service.post(url,customer,true).pipe<Result>(tap((response:any)=>{
      return response;
    }))
  }
  
}
