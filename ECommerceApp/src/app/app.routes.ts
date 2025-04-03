import { Routes } from '@angular/router';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { ProductComponent } from './component/product/product.component';
import { CartComponent } from './component/cart/cart.component';
import { MyOrdersComponent } from './component/my-orders/my-orders.component';

export const routes: Routes = [
    {path:'login',component:LoginComponent},
    {path:'register',component:RegisterComponent},
    {path:'product',component:ProductComponent},
    {path:'cart',component:CartComponent},
    {path:'order',component:MyOrdersComponent},
    
];
