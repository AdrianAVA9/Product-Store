import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';
import { ProductService } from './product.service';

@Component({
  selector: 'po-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  errorMessage = '';

  _searchTerm = '';
  get searchTerm():string{
    return this._searchTerm;
  }
  set searchTerm(value: string){
    this._searchTerm = value;
  }

  filteredProduct: IProduct[] = [];
  products: IProduct[] = []; 

  constructor(private service: ProductService) { }

  performFilter(filterBy: string): IProduct[]{
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((product: IProduct) => 
      product.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  search():void{
    this.filteredProduct = this._searchTerm ? this.performFilter(this._searchTerm) : this.products;
  }

  ngOnInit() {
     this.service.getProducts().subscribe(
       products => {
         this.products = products;
         this.filteredProduct = this.products;
       },
       error => this.errorMessage = <any>error 
     );
  }

}