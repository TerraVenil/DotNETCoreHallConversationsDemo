import { Component, ViewChild, OnInit } from '@angular/core';

import { OrderListComponent } from './orderlist.component';
import { ModalDirective } from 'ng2-bootstrap/components/modal/modal.component';
import { Order } from './index.model';
import { OrderService } from './services/orderService';

@Component({
    selector: 'orders',
    template: require('./orders.component.html'),
    styles: [ require('./orders.component.css') ]
})
export class OrdersComponent implements OnInit {
    title = "Orders";

    orders: Array<Order>;

    constructor(private orderService: OrderService) {
    }

    ngOnInit() {
        this.getOrders();
    }

    public onSelectOrder(order: Order) : void {
        console.log("Order is " + JSON.stringify(order));
    }

    public onCreateOrder(order: Order) : void {
        console.log("Order is " + JSON.stringify(order));
        this.orderService.createOrder(order, result => this.getOrders());
    }

    public exportToExcel() : void {
        this.orderService.exportToExcel();
    }

    private getOrders() {
        this.orderService.getOrders(result => {
                this.orders = result;
            }
        );
    }
}