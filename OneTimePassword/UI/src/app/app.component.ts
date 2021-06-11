import { Component, OnDestroy, OnInit } from '@angular/core';
import { User } from './models/user';
import { UserService } from './services/user.service';
import { take } from 'rxjs/operators';
import { pipe } from 'rxjs';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  userList: User[];
  currentTime: Date;
  intervalId: any;

  constructor(private readonly userService: UserService) {

  }
  ngOnInit(): void {

    this.userService.GetUsers().pipe(take(1)).subscribe(result => {
      this.userList = result;
    }, err => {
      window.alert("An error occured");
    })

    this.intervalId = setInterval(() => {
      this.currentTime = new Date();
      this.userList.forEach(f => {
        
        var diff = (this.currentTime.getTime() - (new Date(f.password.dateCreation)).getTime())/1000;

        f.password.remainingTime = Math.round(31 - diff);

        if (f.password.remainingTime < 0) {
          f.password.remainingTime = 0;
          f.password.isDisplayed = false;
        }
      });
    }, 1000);

  }

  generatePasswordForUser(user: User) {
    this.userService.GetUserPassword(user.id).pipe(take(1)).subscribe(result => {
      user.password = result;
      user.password.dateCreation = new Date(user.password.dateCreation);
    })
  }


  ngOnDestroy(): void {
    clearInterval(this.intervalId);
  }


}
