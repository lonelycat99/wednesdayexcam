export class Stock {
    name: string;
    price: string;
}

export class Cart {
    item: Stock;
    amount: Number;
    total: Number;
    discount: Number;
}