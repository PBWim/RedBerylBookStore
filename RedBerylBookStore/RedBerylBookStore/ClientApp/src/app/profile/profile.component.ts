import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  form: any = {};
  isSuccessful = false;

  constructor(private userService: UserService, private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    var user = this.tokenStorage.getUser();
    this.form.id = user.id;
    this.form.firstName = user.firstName;
    this.form.lastName = user.lastName;
    this.form.email = user.email;
    this.form.password = "dummy";
  }

  onSubmit(): void {
    this.isSuccessful = false;
    var token = this.tokenStorage.getToken();
    this.userService.updateUser(token, this.form).subscribe(
      data => {
        console.log(data);
        this.isSuccessful = true;
        var user = this.tokenStorage.getUser();
        user.firstName = this.form.firstName;
        user.lastName = this.form.lastName;
        this.tokenStorage.saveUser(user)
      },
      err => {
        console.log(err.error.message);
        this.isSuccessful = false;
      }
    );
  }
}
