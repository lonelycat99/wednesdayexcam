import { Component } from '@angular/core';

import { ProductPage } from '../product/product';
import { HomePage } from '../home/home';

@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {

  tab1Root = HomePage;
  tab3Root = ProductPage;

  constructor() {

  }
}
