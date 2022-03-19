using EXAM02.CouponOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM02.CouponOps.Core
{
    public class CouponOperations : ICouponOperations
    {
        private readonly HashSet<Coupon> coupons;
        private readonly Dictionary<Website, HashSet<Coupon>> websitesDic;

        public CouponOperations()
        {
            coupons = new HashSet<Coupon>();
            websitesDic = new Dictionary<Website, HashSet<Coupon>>();
        }

        public void RegisterSite(Website w)
        {
            if (websitesDic.ContainsKey(w)) throw new ArgumentException();
            websitesDic.Add(w, new HashSet<Coupon>());
        }

        public void AddCoupon(Website w, Coupon c)
        {
            if (!websitesDic.ContainsKey(w) || coupons.Contains(c)) throw new ArgumentException();
            websitesDic[w].Add(c);
            coupons.Add(c);
            c.Website = w;
        }

        public Website RemoveWebsite(string domain)
        {
            Website site = websitesDic.Keys.FirstOrDefault(x => x.Domain == domain);
            if (site == null) throw new ArgumentException();

            foreach (Coupon c in websitesDic[site])
            {
                c.Website = null;
                coupons.Remove(c);
            }

            websitesDic.Remove(site);
            return site;
        }

        public Coupon RemoveCoupon(string code)
        {
            Coupon coupon = coupons.FirstOrDefault(x => x.Code == code);
            if (coupon == null) throw new ArgumentException();

            websitesDic[coupon.Website].Remove(coupon);
            coupon.Website = null;
            coupons.Remove(coupon);
            return coupon;
        }

        public bool Exist(Website w)
        {
            return websitesDic.ContainsKey(w);
        }

        public bool Exist(Coupon c)
        {
            return coupons.Contains(c);
        }

        public IEnumerable<Website> GetSites()
        {
            return websitesDic.Keys;
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website w)
        {
            if (!websitesDic.ContainsKey(w))
            {
                throw new ArgumentException();
            }

            return websitesDic[w];
        }

        public void UseCoupon(Website w, Coupon c)
        {
            if (!websitesDic.ContainsKey(w) || !coupons.Contains(c))
            {
                throw new ArgumentException();
            }

            if (!websitesDic[w].Contains(c))
            {
                throw new ArgumentException();
            }

            websitesDic[w].Remove(c);
            c.Website = null;
            coupons.Remove(c);
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return coupons.OrderByDescending(x => x.Validity).ThenByDescending(x => x.DiscountPercentage);
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return websitesDic
                .OrderBy(x => x.Key.UsersCount)
                .ThenByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value)
                .Keys.ToList();
        }
    }
}
