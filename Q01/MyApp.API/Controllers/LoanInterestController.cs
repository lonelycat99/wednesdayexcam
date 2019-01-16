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
    public class LoanInterestController : ControllerBase
    {
        public static List<AnnualAmount> loans = new List<AnnualAmount>();
        [HttpPost]
        public void AddLoanInterest([FromBody]AnnualAmount data)
        {
            var cal = new CalculateAnnualAmount();
            var result = cal.CalLoanInterest(data.PrincipalAmount, data.InterestRate, data.NumberOfYears);
            foreach (var item in result)
            {
                loans.Add(new AnnualAmount()
                {
                    InterestRate = item.InterestRate,
                    PrincipalAmount = item.PrincipalAmount,
                    NumberOfYears = item.NumberOfYears,
                    Paid = item.Paid
                });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnnualAmount>> GetLoanInterest()
        {
            return loans;
        }
    }
}
