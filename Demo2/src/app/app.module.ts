import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrderListComponent } from './components/orders/orderlist.component';
import { ClientsComponent } from './components/clients/clients.component';
import { SettingsComponent } from './components/settings/settings.component';
import { OrderNewComponent } from './components/orders/ordernew.component';
import { OrderService } from './components/orders/services/orderService';

import { ModalModule } from 'ng2-bootstrap/components/modal';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';

import { routing } from './app.routes';

@NgModule({
  declarations: [
        AppComponent,
        NavMenuComponent,
        OrdersComponent,
        OrderListComponent,
        OrderNewComponent,
        ClientsComponent,
        SettingsComponent
    ],
  imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ModalModule,
        NKDatetimeModule,
        routing
    ],
  providers: [ OrderService ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
}