import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksService } from '../services/books.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {
  form: any = {};

  constructor(private router: Router, private booksService: BooksService,
    private tokenStorage: TokenStorageService) { }

  ngOnInit() {
  }

  onSubmit(): void {
    var token = this.tokenStorage.getToken();
    var userId = this.tokenStorage.getUser().id;
    this.booksService.createBook(token, this.form, userId).subscribe(
      data => {
        this.cancel();
      },
      err => {
        console.log(err.error.message);
      }
    );
  }

  cancel() {
    this.router.navigate(['/view-books']);
  }
}
