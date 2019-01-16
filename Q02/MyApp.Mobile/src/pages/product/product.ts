import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';
import { Stock } from '../../app/models';

@Component({
  selector: 'page-product',
  templateUrl: 'product.html'
})
export class ProductPage {
  public stocks = [];
  constructor(public navCtrl: NavController, public http: HttpClient) {
    this.getProduct();
  }

  ionViewDidLoad() {
    this.getProduct();
  }
  
  AddCart(data: Stock) {
    this.navCtrl.push('CartsPage', data);
  }

  getProduct() {
    this.http.get<Stock[]>("https://localhost:5001/api/Shop/GetStocks")
      .subscribe(data => {
        this.stocks = data
      });
  }
}
