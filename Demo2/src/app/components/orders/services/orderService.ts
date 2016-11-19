import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import { Order } from '../index.model';

@Injectable()
export class OrderService {

    constructor(private http: Http) {
    }

    public getOrders(onNext: (json: any) => void) : void {
        this.http.get('/api/v1/orders')
            .map(response => response.json())
            .subscribe(onNext);
    }

    public createOrder(order: Order, onNext: (json: any) => void) : void {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let requestOptions = new RequestOptions({ headers: headers });

        this.http.post('/api/v1/orders', JSON.stringify(order), requestOptions)
            .map(response => response.json())
            .subscribe(onNext);
    }

    public getOrderTypes(onNext: (json: any) => void) : void {
        this.http.get('/api/v1/order_types')
            .map(response => response.json())
            .subscribe(onNext);
    }

    public exportToExcel() : void {
        window.open('http://localhost:5000/api/v1/orders/ExportOrdersToExcelDocument');
    }
}

export interface IUser {
    name: string;
    avatar: string;
    orderTypeId: number;
}