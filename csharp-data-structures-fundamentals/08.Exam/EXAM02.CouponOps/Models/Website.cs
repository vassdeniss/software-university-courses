using System.Collections.Generic;

namespace EXAM02.CouponOps.Models
{
    public class Website
    {
        public List<Coupon> coupons = new List<Coupon>();

        public Website(string domain, int usersCount)
        {
            Domain = domain;
            UsersCount = usersCount;
        }

        public string Domain { get; set; }
        public int UsersCount { get; set; }
    }
}
