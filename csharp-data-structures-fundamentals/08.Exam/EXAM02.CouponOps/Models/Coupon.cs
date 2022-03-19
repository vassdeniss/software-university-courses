namespace EXAM02.CouponOps.Models
{
    public class Coupon
    {
        public Coupon(string code, int discountPercentage, int validity)
        {
            Code = code;
            DiscountPercentage = discountPercentage;
            Validity = validity;
        }

        public Website Website { get; set; }
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public int Validity { get; set; }
    }
}
