import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';
import { AnnualAmount, AnnualAmountPost, AmountPaid } from '../../app/models';
/**
 * Generated class for the AnnualAmountPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-annual-amount',
  templateUrl: 'annual-amount.html',
})
export class AnnualAmountPage {
  public inputData = new AnnualAmountPost()
  public interest: Number;
  public annualAmounts = [];
  constructor(public navCtrl: NavController, public navParams: NavParams, public http: HttpClient, public toastCtrl: ToastController) {
    this.interest = navParams.data;
  }

  ionViewDidLoad() {
    this.getAllInterest();
  }

  CalculateInterest() {
    this.inputData.interestRate = this.interest;
    this.http.post("https://localhost:5001/api/LoanInterest/AddLoanInterest", this.inputData)
      .subscribe(data => {
        this.presentToastSuccess();
        this.getAllInterest();
      });
  }

  presentToastSuccess() {
    const toast = this.toastCtrl.create({
      message: 'Success!',
      duration: 3000,
      position: 'top'
    });
    toast.present();
  }

  getAllInterest() {
    this.http.get<AmountPaid[]>("https://localhost:5001/api/LoanInterest/GetLoanInterest")
      .subscribe(data => {
        this.annualAmounts = data;
      });
  }
}
