import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdersComponent } from './components/orders/orders.component';
import { ClientsComponent } from './components/clients/clients.component';
import { SettingsComponent } from './components/settings/settings.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'orders', pathMatch: 'full' },
    { path: 'orders', component: OrdersComponent },
    { path: 'clients', component: ClientsComponent },
    { path: 'settings', component: SettingsComponent },
    { path: '**', redirectTo: 'orders' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);