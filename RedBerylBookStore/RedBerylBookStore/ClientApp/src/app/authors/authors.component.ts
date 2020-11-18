import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {
  public authors: AuthorData[];

  constructor(private userService: UserService, private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    var token = this.tokenStorage.getToken();
    this.userService.getAuthors(token).subscribe(
      data => {
        var result = JSON.parse(data._body);
        var resultData = result.result.data;
        this.authors = resultData.usersObj;
      },
      err => {
        console.log(err.error.message);
      }
    );
  }

  activate(userId) {
    var isConfirmed = confirm("Do you want to Activate this user ?");
    if (isConfirmed) {
      var token = this.tokenStorage.getToken();
      this.userService.activateAuthor(token, userId).subscribe((data) => {
        window.location.reload();
      }, err => {
          console.log(err.error.message);
      })
    }
  }

  deactivate(userId) {
    var isConfirmed = confirm("Do you want to Deactivate this user ?");
    if (isConfirmed) {
      var token = this.tokenStorage.getToken();
      this.userService.deactivateAuthor(token, userId).subscribe((data) => {
        window.location.reload();
      }, err => {
          console.log(err.error.message);
      })
    }
  }

}
