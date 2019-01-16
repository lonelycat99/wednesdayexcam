export class AnnualAmount {
    interestRate: Number;
    principalAmount: Number;
    numberOfYears: Number;
    paid: Number;
}

export class AnnualAmountPost {
    interestRate: Number;
    principalAmount: Number;
    numberOfYears: Number;
    
}

export class AmountPaid {
    annualAmounts: AnnualAmount[];
}