import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

import {IProduct} from './product';
import { ProductService } from './product.service';

@Component({
  selector: 'po-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  product: IProduct | undefined;
  errorMessage: '';
  pageTitle: string = 'Product detail';

  constructor(private route: ActivatedRoute,
              private router: Router,
              private productService: ProductService) { }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('id');

    if(param){
      const id = +param;
      this.productService.getProduct(id).subscribe(
        product => {
          this.product = product;
        },
        error => this.errorMessage = <any>error
      );
    }
  }

  onBack():void{
    this.router.navigate(['/products']);
  }
}
