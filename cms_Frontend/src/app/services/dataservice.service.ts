import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DataserviceService {
  role: string = '';
  userdata: any = null;

  constructor() {}

  dataparser(data: any) {
    for (let i of data) {
      if (i.speakers) {
        let x = JSON.parse(i.speakers);
        i.speakers=x;
      }
      if (i.hotels) {
        let x= JSON.parse(i.hotels);
        i.hotels=x
      }
      return data;
    }
  }
}
