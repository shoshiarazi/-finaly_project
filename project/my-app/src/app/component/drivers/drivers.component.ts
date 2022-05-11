import { Component, OnInit } from '@angular/core';
import { DriversService } from 'src/app/services/drivers.service';

@Component({
  selector: 'app-drivers',
  templateUrl: './drivers.component.html',
  styleUrls: ['./drivers.component.css']
})
export class DriversComponent implements OnInit {
  // books=new Array<any>()
  // constructor(private booksService:BooksService) {

  // }

  // ngOnInit(): void {
  //   this.booksService.getAllBook().subscribe(ans=>{ 
  //     this.books=ans})
  // }
  drivers=new Array<any>()
  constructor(private driversService:DriversService) { }

  ngOnInit(): void {
    this.driversService.getAlldrivers().subscribe(ans=>{
      this.drivers=ans
    })
  }

}
