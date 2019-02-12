import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common'
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product/product-list.component';
import { WelcomeComponent } from './Home/welcome.component';
import { ProductComponent } from './product/product.component';
import { StarComponent } from './shared/star.component';
import { ProductDetailComponent } from './product/product-detail.component';
import { ProductDetailGuard } from './product/product-detail.guard';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    WelcomeComponent,
    ProductComponent,
    StarComponent,
    ProductDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      {path:'welcome', component:WelcomeComponent},
      {path:'products', component:ProductListComponent},
      {path:'products/:id',
      canActivate: [ProductDetailGuard],
      component:ProductDetailComponent},
      {path:'', redirectTo:'welcome', pathMatch:'full'},
      {path:'**', redirectTo:'welcome', pathMatch:'full'}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
