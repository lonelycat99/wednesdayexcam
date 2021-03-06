import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  public InterestRate: Number;
  constructor(public navCtrl: NavController) {
  }

  goAnnualPage() {
    this.navCtrl.push("AnnualAmountPage", this.InterestRate);
  }
}
