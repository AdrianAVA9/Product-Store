import { Component,Input, OnChanges } from '@angular/core';

@Component({
  selector: 'po-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges{
  @Input() rating: number;
  starWidth: number;

  constructor() { }

  ngOnChanges(): void{
    this.starWidth = 15 * this.rating;
  }
}
