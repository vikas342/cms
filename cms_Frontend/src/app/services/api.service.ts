import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }



  login(form:any){
     return this.http.post("https://localhost:7157/api/User/loging",form);
  }

  signup(form:any){
    return this.http.post("https://localhost:7157/api/User/signup",form);
 }


 getcities(){
  return this.http.get("https://localhost:7157/api/Conf/getcities");
 }



 getstates(){
  return this.http.get("https://localhost:7157/api/Conf/getstates");
 }


 add_address(formdata:any){
  return this.http.post("https://localhost:7157/api/Conf/add_address",formdata);
 }


 add_confdetails(formdata:any){
  return this.http.post("https://localhost:7157/api/Conf/add_conf",formdata);
 }
 add_hoteldetails(formdata:any){
  return this.http.post("https://localhost:7157/api/Conf/add_hotels",formdata);
 }



 add_speakerdetails(formdata:any,cid:number){
  return this.http.post("https://localhost:7157/api/Conf/add_speakers?cid="+cid,formdata);
 }


 get_allevents(){
 return this.http.get("https://localhost:7157/api/Conf/getallData");
 }


 get_perticular(cid:number){
  return this.http.get("https://localhost:7157/api/Conf/getData?cid="+cid);
  }

 delete(cid:number){
  return this.http.put("https://localhost:7157/api/Conf/delete?cid="+cid,null)
 }

 edit_confdetails(id:number,formdata:any){
  return this.http.put("https://localhost:7157/api/Conf/edit_conf?cid="+id,formdata)
 }

 edit_addressdetails(id:number,formdata:any){
  return this.http.put("https://localhost:7157/api/Conf/edit_address?addid="+id,formdata)
 }


 edit_hoteldetails(id:number,formdata:any){
  return this.http.put("https://localhost:7157/api/Conf/edit_hotel?hid="+id,formdata)
 }


 edit_speakerdetails(cid:number,sid:number,formdata:any){
  return this.http.put("https://localhost:7157/api/Conf/editspeker?sid="+sid+"&cid="+cid,formdata)
 }

 addspeaker_edit(cid:number,formdata:any){
  return this.http.post("https://localhost:7157/api/Conf/addspeker?cid="+cid,formdata)
 }



 delete_speaker(id:number){
  return this.http.delete("https://localhost:7157/api/Conf/del_speaker?sid="+id)
 }



 add_order(uname:string,email:string,formdata:any){
  return this.http.post("https://localhost:7157/api/Conf/add_order?name="+uname+"&email="+email,formdata);
 }

get_orders(id:number){
  return this.http.get("https://localhost:7157/api/Conf/orderDetails?uid="+id);
}


postimage(file:any){
  return this.http.post('https://localhost:7157/api/Conf/ImageUrl',file)
}

}
