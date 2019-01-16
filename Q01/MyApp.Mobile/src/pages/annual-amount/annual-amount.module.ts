import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { AnnualAmountPage } from './annual-amount';

@NgModule({
  declarations: [
    AnnualAmountPage,
  ],
  imports: [
    IonicPageModule.forChild(AnnualAmountPage),
  ],
})
export class AnnualAmountPageModule {}
