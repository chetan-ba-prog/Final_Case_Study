import { Injectable }           from '@angular/core';
import { HttpClient, 
         HttpHeaders, 
         HttpErrorResponse }    from "@angular/common/http";
import { Observable, 
         throwError }           from 'rxjs';
import { catchError, 
         tap }                  from 'rxjs/operators';
//service
import { Router }               from '@angular/router';
import { SecurityService }      from './security.service';
import { Response }             from '../models/response.model'

const baseUrl = 'https://localhost:44353/api/Seller';

// Implementing a Retry-Circuit breaker policy 
// is pending to do for the SPA app
@Injectable({
    providedIn: 'root'
  })

export class DataService {
    
    constructor(private http: HttpClient, private securityService: SecurityService, public router: Router) { }

    public get(url: string, params?: any, isEnableLoader: boolean = true): Observable<Response> {
        return this.doGet(baseUrl + url, false, params, isEnableLoader);
        //return this.doPost(baseUrl+url, data, false, params);
    }

    post(url: string, data: any, params?: any, isEnableLoader: boolean = true): Observable<Response> {
        return this.doPost(baseUrl + url, data, false, params, isEnableLoader);
        //return this.doPost(baseUrl+url, data, false, params);
    }

    postWithId(url: string, data: any, params?: any, isEnableLoader: boolean = true): Observable<Response> {
        return this.doPost(baseUrl + url, data, true, params, isEnableLoader);
        //return this.doPost(baseUrl+url, data, true, params);
    }

    putWithId(url: string, data: any, params?: any, isEnableLoader: boolean = true): Observable<Response> {
        return this.doPut(baseUrl + url, data, true, params, isEnableLoader);
        // return this.doPut(baseUrl+url, data, true, params);
    }

    private doGet(url: string, needId: boolean = false, params?: any, isEnableLoader: boolean = true): Observable<Response> {

        let headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');

        let httpOptions = {
            headers: headers
        };

        //httpOptions = this.securityService.setHeaders(true);

        return this.http.get(url, httpOptions)
            .pipe(
                // retry(3), // retry a failed request up to 3 times
                tap((res: Response) => {                  
                    return res;
                }),
                catchError(this.handleError)
            );
    }

    private doPost(url: string, data: any, needId: boolean, params?: any, isEnableLoader: boolean = true): Observable<Response> {
      
        let httpOptions = {
            headers: new HttpHeaders()
        };

        httpOptions = this.securityService.setHeaders(needId);
        return this.http.post(url, data, httpOptions)
            .pipe(
                tap((res: Response) => {
                    console.log(res);
                    
                    return res;
                }),
                catchError(this.handleError)
            );
    }

    public delete(url: string, params?: any, isEnableLoader: boolean = true) {
       
        let httpOptions = {
            headers: new HttpHeaders()
        };

        httpOptions = this.securityService.setHeaders(true);

        console.log('data.service deleting');

        this.http.delete(url, httpOptions)
            .subscribe((res) => {
                console.log('deleted');
                
            });
    }

    private doPut(url: string, data: any, needId: boolean, params?: any, isEnableLoader: boolean = true): Observable<Response> {
      
        let httpOptions = {
            headers: new HttpHeaders()
        };

        httpOptions = this.securityService.setHeaders(true);


        return this.http.put(baseUrl + url, data, httpOptions)
            .pipe(
                tap((res: Response) => {
                    
                    return res;
                }),
                catchError(this.handleError)
            );
    }

    private handleError(error: any) {
      
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('Client side network error occurred:', error.error.message);
        }else {
            console.error('Backend - ' +
                `status: ${error.status}, ` +
                `statusText: ${error.statusText}, ` +
                `message: ${error.error.message}`);
        }

        // return an observable with a user-facing error message
        return throwError(error || 'server error');
    }

}