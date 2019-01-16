using System;
using MyApp.API;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10, 5, 50)]
        [InlineData(55, 5, 275)]
        [InlineData(95, 9, 855)]
        [InlineData(50, 8, 400)]
        [InlineData(250, 10, 2500)]
        public void TestCalTotalPrice(int price, int amount, int expected)
        {
            var sut = new CalulateShop();
            var result = sut.CalTotalPrice(price, amount);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(DataBeForeDeductingDiscountsTest))]
        public void CalTotalAmountBeForeDeductingDiscountsTest(List<Cart> carts, double expected)
        {
            var sut = new CalulateShop();
            var result = sut.CalTotalAmountBeForeDeductingDiscounts(carts);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(DataDiscount))]
        public void CalDiscountsTest(Cart carts, double expected)
        {
            var sut = new CalulateShop();
            var result = sut.CalDiscounts(carts);
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DataAmountToBePaid))]
        public void CalAmountToBePaidTest(List<Cart> carts, double expected)
        {
            var sut = new CalulateShop();
            var result = sut.CalAmountToBePaid(carts);
           Assert.Equal(expected,result);
        }


        public static IEnumerable<object[]> DataDiscount = new List<object[]>{
            new object[] {
                new Cart{
                    Item = new Stock {
                        Name = "ก๋วยเตี๋ยว",
                        Price = 35
                    },
                    Amount = 10,
                    Total = 350,

                },
                70,
            },
             new object[] {
                new Cart{
                    Item = new Stock {
                        Name = "ส้มตำ",
                        Price = 45
                    },
                    Amount = 3,
                    Total = 135,
                },
                0,
            },
             new object[] {
                new Cart{
                    Item = new Stock {
                        Name = "ช็อคโกแลต",
                        Price = 19
                    },
                    Amount = 9,
                    Total = 171,
                },
                38,
            },
             new object[] {
                new Cart{
                    Item = new Stock {
                        Name = "โค้ก",
                        Price = 12
                    },
                    Amount = 10,
                    Total = 120,
                },
                24,
            },
             new object[] {
                new Cart{
                    Item = new Stock {
                        Name = "โปเต้",
                        Price = 5
                    },
                    Amount = 10,
                    Total = 55,
                },
                10,
            },
        };
        public static IEnumerable<object[]> DataBeForeDeductingDiscountsTest = new List<object[]>{
            new object[] {
                new List<Cart>
                 {
                     new Cart{
                        Item = new Stock {
                            Name = "โค้ก",
                            Price = 12
                        },
                        Amount = 10,
                        Total = 120,
                        Discount = 24,

                    },
                     new Cart{
                        Item = new Stock {
                            Name = "เลย์",
                            Price = 20
                        },
                        Amount = 5,
                        Total = 100,
                        Discount = 20,

                    },
                     new Cart{
                        Item = new Stock {
                            Name = "โปเต้",
                            Price = 5
                        },
                        Amount = 11,
                        Total = 55,
                        Discount = 10,

                    },
                 },
                 275
            },
        };
        public static IEnumerable<object[]> DataAmountToBePaid = new List<object[]>
        {
            new object[] {new List<Cart>
                 {
                     new Cart{
                        Item = new Stock {
                            Name = "ก๋วยเตี๋ยว",
                            Price = 35
                        },
                        Amount = 10,
                        Total = 350,
                        Discount = 70,

                    },
                 },
                280
            },
            new object[] {
                new List<Cart>
                 {
                     new Cart{
                        Item = new Stock {
                            Name = "โค้ก",
                            Price = 12
                        },
                        Amount = 10,
                        Total = 120,
                        Discount = 24,
                    },
                     new Cart{
                        Item = new Stock {
                            Name = "เลย์",
                            Price = 20
                        },
                        Amount = 5,
                        Total = 100,
                        Discount = 20,
                    },
                     new Cart{
                        Item = new Stock {
                            Name = "โปเต้",
                            Price = 5
                        },
                        Amount = 11,
                        Total = 55,
                        Discount = 10,

                    },
                 },
                 221
            },
        };
    }
}
