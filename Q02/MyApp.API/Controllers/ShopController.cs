using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.Models;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public static List<Stock> stocks = new List<Stock>();
        public static List<Cart> carts = new List<Cart>();

        [HttpPost]
        public void AddItemInStock([FromBody]Stock data)
        {
            stocks.Add(data);
        }

        [HttpPost]
        public void AddItemToCart(Cart data)
        {
            var cal = new CalulateShop();
            data.Total = cal.CalTotalPrice(data.Item.Price, data.Amount);
            data.Discount = cal.CalDiscounts(data);
            carts.Add(data);
        }

        [HttpGet]
        public IEnumerable<Stock> GetStocks()
        {
            return stocks;
        }

        [HttpGet]
        public IEnumerable<Cart> GetCart()
        {
            return carts;
        }

        [HttpGet]
        public double GetTotalAmountBeForeDeductingDiscounts()
        {
            var cal = new CalulateShop();
            return cal.CalTotalAmountBeForeDeductingDiscounts(carts);
        }

        [HttpGet]
        public double GetAmountToBePaid()
        {
            var cal = new CalulateShop();
            return cal.CalAmountToBePaid(carts);
        }
    }
}
