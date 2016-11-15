import { Component, ViewChild, OnInit, EventEmitter, Output } from '@angular/core';
import { Http } from '@angular/http';

import { IOrderType, Order } from './index.model';
import { OrderService } from './services/orderService';

@Component({
    selector: 'order-new',
    template: require('./ordernew.component.html'),
    styles: [ require('./ordernew.component.css') ],
    exportAs: 'child'
})
export class OrderNewComponent implements OnInit {
    public orderTypes: IOrderType[];
    public newOrder: Order;
    public orderTypesLoaded: boolean = false;
    public minDate: Date = new Date();

    @ViewChild('childModal') childModal;

    @Output()
    public createOrder = new EventEmitter();

    constructor(private orderService: OrderService) {
    }

    ngOnInit() {
        this.orderService.getOrderTypes(result => {
                this.orderTypesLoaded = true;
                this.orderTypes = result;
                this.createNewOrder();
            }
        );
    }

    public onCreate(order: Order) {
        this.childModal.hide();
        this.createOrder.next(order);
    }

    public show(): void {
        this.createNewOrder();
        this.childModal.show(); 
    }

    public hide(): void {
        console.log("New Order: " + JSON.stringify(this.newOrder));
        this.childModal.hide();
    }

    private createNewOrder(): void {
        this.newOrder = {
            orderTypeId: 1,
            number: "AAGHKK-45ygHHHl",
            orderTypeName: "Paid",
            status: "New",
            comment: "",
            callMasterTime: new Date(),
            deadlineTime: new Date(),
            price: null,
            prepaidExpense: null,
            isUrgently: false
        };
    }
}