import { Component, OnInit } from '@angular/core';
import { BooksService } from '../services/books.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  public books: BookData[];

  constructor(private booksService: BooksService, private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    var token = this.tokenStorage.getToken();
    var userId = this.tokenStorage.getUser().id;
    this.booksService.getBooksByAuthor(token, userId).subscribe(
      data => {
        var result = JSON.parse(data._body);
        var resultData = result.result.data;
        this.books = resultData.booksObj;
      },
      err => {
        console.log(err.error.message);
      }
    );
  }
}
