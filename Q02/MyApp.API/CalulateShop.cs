using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.API
{
    public class CalulateShop
    {
        public int CalTotalPrice(int price, int amount)
        {
            return price * amount;
        }

        public double CalTotalAmountBeForeDeductingDiscounts(List<Cart> carts)
        {
            var sum = 0.00;
            foreach (var item in carts)
            {
                sum += item.Total;
            }
            return sum;
        }

        public double CalDiscounts(Cart carts)
        {
            var discount = carts.Amount / 4;
            return discount * carts.Item.Price;
        }

        public double CalAmountToBePaid(List<Cart> carts)
        {
            var sum = 0.00;
            foreach (var item in carts)
            {
                sum += (item.Amount * item.Item.Price) - item.Discount;
            }
            return sum;
        }
    }
}