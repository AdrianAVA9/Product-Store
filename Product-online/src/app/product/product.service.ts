import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, tap} from 'rxjs/operators';

import{IProduct} from './product';

@Injectable({
    providedIn: 'root'
})

export class ProductService{
    private productUrl = 'http://localhost:50336/api/products';

    constructor(private http: HttpClient) {}

    getProducts():Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.productUrl).pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
    }

    getProduct(id: number): Observable<IProduct | undefined>{
        var url = this.productUrl + '?id=' + id;

        return this.http.get<IProduct>(url).pipe(
            catchError(this.handleError)
        );
    }

    private handleError(err: HttpErrorResponse){
        let errorMessage = '';
        
        if(err.error instanceof ErrorEvent){
            errorMessage = `An error occurred: ${err.status}`;
        }else{
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }

        console.log(errorMessage);
        return throwError(errorMessage);
    }
}