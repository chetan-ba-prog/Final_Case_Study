import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerCartComponent } from './customer-cart/customer-cart.component';
import { CustomerCheckoutComponent } from './customer-checkout/customer-checkout.component';
import { CustomerFeedbackComponent } from './customer-feedback/customer-feedback.component';
import { CustomerInvoiceComponent } from './customer-invoice/customer-invoice.component';
import { CustomerLoginComponent } from './customer-login/customer-login.component';
import { CustomerMyOrderComponent } from './customer-my-order/customer-my-order.component';
import { CustomerPaymentComponent } from './customer-payment/customer-payment.component';
import { CustomerProfileComponent } from './customer-profile/customer-profile.component';
import { CustomerSignUpComponent } from './customer-sign-up/customer-sign-up.component';
import { HomeComponent } from './home/home.component';
import { ProductCategoriesComponent } from './product-categories/product-categories.component';
import { ProductDescriptionComponent } from './product-description/product-description.component';
import { ProductsComponent } from './products/products.component';
import { SellerAddProductComponent } from './seller-add-product/seller-add-product.component';
import { SellerDashHeaderComponent } from './seller-dash-header/seller-dash-header.component';
import { SellerDashComponent } from './seller-dash/seller-dash.component';
import { SellerHomeComponent } from './seller-home/seller-home.component';
import { SellerLoginComponent } from './seller-login/seller-login.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';
import { SellerPaymentDetailsComponent } from './seller-payment-details/seller-payment-details.component';
import { SellerSignUpComponent } from './seller-sign-up/seller-sign-up.component';
import { SellerViewProductComponent } from './seller-view-product/seller-view-product.component';
import { SellersProfileComponent } from './sellers-profile/sellers-profile.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},

  {path: 'seller-login', component: SellerLoginComponent},
  {path: 'seller-home', component: SellerHomeComponent},
  {path : 'seller-sign-up', component: SellerSignUpComponent},
  {path: 'seller-dash', component: SellerDashComponent},
  {path: 'seller-dash-header', component: SellerDashHeaderComponent},
  {path: 'sellers-profile', component: SellersProfileComponent},
  {path: 'seller-add-product', component: SellerAddProductComponent},
  {path: 'seller-payment-details', component: SellerPaymentDetailsComponent},
  {path: 'seller-view-product', component: SellerViewProductComponent},
  {path: 'seller-orders', component: SellerOrdersComponent},

  {path: 'customer-login', component: CustomerLoginComponent},
  {path: 'customer-sign-up', component: CustomerSignUpComponent},
  {path: 'customer-profile', component: CustomerProfileComponent},
  {path: 'customer-cart', component: CustomerCartComponent},
  {path: 'customer-checkout', component: CustomerCheckoutComponent},
  {path: 'customer-my-order', component: CustomerMyOrderComponent},
  {path: 'customer-feedback', component: CustomerFeedbackComponent},
  {path: 'customer-payment', component: CustomerPaymentComponent},
  {path: 'customer-invoice', component: CustomerInvoiceComponent},

  {path: 'products', component: ProductsComponent},
  {path: 'product-categories', component: ProductCategoriesComponent},
  {path: 'product-description', component: ProductDescriptionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
