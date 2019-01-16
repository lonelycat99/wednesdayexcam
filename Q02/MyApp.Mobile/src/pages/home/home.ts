import { Component } from '@angular/core';
import { NavController, ToastController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';
import { Stock } from '../../app/models';
@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  public product = new Stock();
  constructor(public navCtrl: NavController, public http: HttpClient, public toastCtrl: ToastController) {

  }
  
  AddStocks() {
    this.http.post("https://localhost:5001/api/Shop/AddItemInStock", this.product).subscribe(data => {
      this.presentToastAddSuccess();
    });
  }

  presentToastAddSuccess() {
    const toast = this.toastCtrl.create({
      message: 'เพิ่มรายการสินค้าสำเร็จ!',
      duration: 3000,
      position: 'top'
    });
    toast.present();
  }

}
