import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders }      from '@angular/common/http';
import { Observable, Subject }          from 'rxjs';
import { Router }                       from '@angular/router';
import { ActivatedRoute }               from '@angular/router';
import { StorageService }               from './storage.service';

@Injectable({
    providedIn: 'root'
  })
export class SecurityService {

    private actionUrl: string;
    private headers: HttpHeaders;
    private storage: StorageService;
    private authenticationSource = new Subject<boolean>();
    authenticationChallenge$ = this.authenticationSource.asObservable();
    private authorityUrl = '';

    constructor(private _http: HttpClient, private _router: Router, private route: ActivatedRoute, private _storageService: StorageService) {
        this.headers = new HttpHeaders();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        this.storage = _storageService;

      
        if (this.storage.retrieve('IsAuthorized') !== '') {
            this.IsAuthorized = this.storage.retrieve('IsAuthorized');
            this.authenticationSource.next(true);
            this.UserData = this.storage.retrieve('userData');
        }
    }

    public IsAuthorized: boolean;

    public GetToken(): any {
        return this.storage.retrieve('authorizationDataIdToken');
    }

    public ResetAuthorizationData() {
       
        this.storage.store('authorizationDataIdToken', '');

        this.IsAuthorized = false;
        this.storage.store('IsAuthorized', false);
    }

    public UserData: any;

    public SetAuthorizationData(token: any, id_token: any) {
        if (this.storage.retrieve('authorizationDataIdToken') !== '') {
            this.storage.store('authorizationDataIdToken', '');
        }

       
        this.storage.store('authorizationDataIdToken', id_token);
        this.IsAuthorized = true;
        this.storage.store('IsAuthorized', true);

      
    }

   
    

    public Logoff() {
        let authorizationUrl = this.authorityUrl + '/connect/endsession';
        let id_token_hint = this.storage.retrieve('authorizationDataIdToken');
        let post_logout_redirect_uri = location.origin + '/';

        let url =
            authorizationUrl + '?' +
            'id_token_hint=' + encodeURI(id_token_hint) + '&' +
            'post_logout_redirect_uri=' + encodeURI(post_logout_redirect_uri);

        this.ResetAuthorizationData();

        // emit observable
        this.authenticationSource.next(false);
        window.location.href = url;
    }

    public HandleError(error: any) {
        console.log(error);
        if (error.status == 403) {
            this._router.navigate(['/Forbidden']);
        }
        else if (error.status == 401) {
            // this.ResetAuthorizationData();
            this._router.navigate(['/Unauthorized']);
        }
    }

    private urlBase64Decode(str: string) {
        let output = str.replace('-', '+').replace('_', '/');
        switch (output.length % 4) {
            case 0:
                break;
            case 2:
                output += '==';
                break;
            case 3:
                output += '=';
                break;
            default:
                throw 'Illegal base64url string!';
        }

        return window.atob(output);
    }

    private getDataFromToken(token: any) {
        let data = {};

        if (typeof token !== 'undefined') {
            let encoded = token.split('.')[1];
            
            data = JSON.parse(this.urlBase64Decode(encoded));
        }

        return data;
    }

  

   
    public setHeaders(needId:boolean): any {
        const httpOptions = {
            headers: new HttpHeaders()
        };

        httpOptions.headers = httpOptions.headers.set('Content-Type', 'application/json');
    

        //const token = this.GetToken();

        // if (token !== '' &&  token!==undefined && needId===true) {
        //     httpOptions.headers = httpOptions.headers.set('Authorization', 'Bearer '+token);
        // }

        return httpOptions;
    }
}