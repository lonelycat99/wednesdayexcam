namespace MyApp.API.Models
{
    public class AnnualAmount
    {

        ///<summary>
        ///อัตราดอกเบี้ย
        ///</summary>
        public int InterestRate { get; set; }
        ///<summary>
        ///ยอดเงินต้น
        ///</summary>
        public double PrincipalAmount { get; set; }
        ///<summary>
        ///จำนวนปี
        ///</summary>
        public int NumberOfYears { get; set; }
        ///<summary>
        ///ยอดที่ต้องชำระ
        ///</summary>
        public double Paid { get; set; }

    }
}