import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';
import { Cart } from '../../app/models';
import { HttpClient } from '@angular/common/http';

@IonicPage()
@Component({
  selector: 'page-carts',
  templateUrl: 'carts.html',
})
export class CartsPage {

  public items = new Cart();
  public productName: string;
  public amountItem: Number;
  public carts = [];
  public shouldPaid: any;
  public noDiscounts:any;
  constructor(public navCtrl: NavController, public navParams: NavParams, public http: HttpClient, public toastCtrl: ToastController) {
    if (this.navParams.data.name == null) {
      this.productName = "กรุณาเลือกสินค้า"
    } else {
      this.productName = this.navParams.data.name;
    }

    this.getCart();
  }

  AddToCart() {
    this.http.post("https://localhost:5001/api/Shop/AddItemToCart", {
      item: {
        name: this.navParams.data.name,
        price: this.navParams.data.price
      },
      amount: this.amountItem
    })
      .subscribe((success) => {
        this.presentToastAddSuccess();
        this.getCart();
      });
  }

  presentToastAddSuccess() {
    const toast = this.toastCtrl.create({
      message: 'เพิ่มสินค้าลงตระกร้าสำเร็จ!',
      duration: 3000,
      position: 'top'
    });
    toast.present();
  }

  getCart() {
    this.http.get<Cart[]>("https://localhost:5001/api/Shop/GetCart")
      .subscribe(data => {
        this.carts = data
      });

    this.http.get("https://localhost:5001/api/Shop/GetAmountToBePaid")
      .subscribe(data => {
        this.shouldPaid = data;
      
      });

    this.http.get("https://localhost:5001/api/Shop/GetTotalAmountBeForeDeductingDiscounts")
      .subscribe(data => {
        this.noDiscounts = data;
      
      });
  }
}
