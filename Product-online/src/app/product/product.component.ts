import { Component, Input } from '@angular/core';
import {IProduct} from './product';

@Component({
  selector: 'po-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent{
  @Input() product: IProduct;

  constructor() {
  }
}
