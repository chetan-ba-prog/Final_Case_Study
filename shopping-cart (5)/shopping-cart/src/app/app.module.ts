import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SellerLoginComponent } from './seller-login/seller-login.component';
import { HomeComponent } from './home/home.component';
import { SellerSignUpComponent } from './seller-sign-up/seller-sign-up.component';
import { SellerHomeComponent } from './seller-home/seller-home.component';
import { SellerService } from './services/seller.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomerLoginComponent } from './customer-login/customer-login.component';
import { CustomerSignUpComponent } from './customer-sign-up/customer-sign-up.component';
import { CustomerProfileComponent } from './customer-profile/customer-profile.component';
import { CustomerService } from './services/customer.service';
import { ProductService } from './services/product.service';
import { SellerOuterNavBarComponent } from './navbar/seller-outer-nav-bar/seller-outer-nav-bar.component';
import { HomeCardComponent } from './home-card/home-card.component';
import { SellerDashComponent } from './seller-dash/seller-dash.component';
import { SellerDashHeaderComponent } from './seller-dash-header/seller-dash-header.component';
import { FooterComponent } from './footer/footer.component';
import { SellersProfileComponent } from './sellers-profile/sellers-profile.component';
import { SellerAddProductComponent } from './seller-add-product/seller-add-product.component';
import { SellerViewProductComponent } from './seller-view-product/seller-view-product.component';
import { SellerPaymentDetailsComponent } from './seller-payment-details/seller-payment-details.component';
import { CustomerNavBarComponent } from './navbar/customer-nav-bar/customer-nav-bar.component';
import { CustomerCartComponent } from './customer-cart/customer-cart.component';
import { ProductsComponent } from './products/products.component';
import { CustomerCheckoutComponent } from './customer-checkout/customer-checkout.component';
import { CustomerPaymentComponent } from './customer-payment/customer-payment.component';
import { CustomerMyOrderComponent } from './customer-my-order/customer-my-order.component';
import { CustomerFeedbackComponent } from './customer-feedback/customer-feedback.component';
import { CustomerInvoiceComponent } from './customer-invoice/customer-invoice.component';
import { CustomerInnerNavbarComponent } from './navbar/customer-inner-navbar/customer-inner-navbar.component';
import { ProductCategoriesComponent } from './product-categories/product-categories.component';
import { ProductDescriptionComponent } from './product-description/product-description.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';

@NgModule({
  declarations: [
    AppComponent,
    SellerLoginComponent,
    HomeComponent,
    SellerSignUpComponent,
    SellerHomeComponent,
    CustomerLoginComponent,
    CustomerSignUpComponent,
    CustomerProfileComponent,
    SellerOuterNavBarComponent,
    HomeCardComponent,
    SellerDashComponent,
    SellerDashHeaderComponent,
    FooterComponent,
    SellersProfileComponent,
    SellerAddProductComponent,
    SellerViewProductComponent,
    SellerPaymentDetailsComponent,
    CustomerNavBarComponent,
    CustomerCartComponent,
    ProductsComponent,
    CustomerCheckoutComponent,
    CustomerPaymentComponent,
    CustomerMyOrderComponent,
    CustomerFeedbackComponent,
    CustomerInvoiceComponent,
    CustomerInnerNavbarComponent,
    ProductCategoriesComponent,
    ProductDescriptionComponent,
    SellerOrdersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [SellerService, CustomerService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
