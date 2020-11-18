import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';
import { BooksService } from '../services/books.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  role: string;
  name: '';
  searchText: '';
  public books: BookData[];

  constructor(private tokenStorage: TokenStorageService, private booksService: BooksService) { }

  ngOnInit() {
    if (this.tokenStorage.getToken()) {
      var user = this.tokenStorage.getUser();
      this.name = user.firstName;
      this.role = user.role == 1 ? 'Administrator' : 'Author';
    }

    this.booksService.getBooks("").subscribe(
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

  isLoggedIn(): boolean {
    return this.tokenStorage.getToken() == null ? false : true;
  }

  search() {
    this.booksService.getBooks(this.searchText).subscribe(
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
