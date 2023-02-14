import { Component } from '@angular/core';
import { BooksserviceService } from '../services/booksservice.service';
import { Item } from './books.model';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent {
  bookList: Item[] = [];
  searchText: any;
  loadingSymbol: boolean = false;
  toggle: boolean = true;
  atomImageUrl="../../assets/Image.png";

  constructor(private service: BooksserviceService) {
    this.getbooksonload();
  }

  getbooksonload() {
    this.loadingSymbol= true;
    this.service.getBooks().subscribe({
      next: (data) => {
        this.bookList = data;
        console.log(this.bookList);
      },
      error: () => {
        console.log('Error');
        alert("Error while fetching data. Retry again after sometime.");
        this.loadingSymbol = false;

      },
      complete: () => {
        this.loadingSymbol = false;
        console.log('Data retuned successfully');
      },
    });
  }

  toggling() {
    this.toggle = !this.toggle;
  }
}
