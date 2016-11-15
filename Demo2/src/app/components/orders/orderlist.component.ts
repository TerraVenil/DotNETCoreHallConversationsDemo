import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

import { Order, IOrderType } from './index.model';

@Component({
    selector: 'order-list',
    template: require('./orderlist.component.html')
})
export class OrderListComponent implements OnInit {
    @Input()
    orders: Array<Order>;

    @Output()
    selectOrder = new EventEmitter();

    constructor() {
    }

    ngOnInit() {
    }

    onSelect(order: Order) {
        this.selectOrder.next(order);
    }
}