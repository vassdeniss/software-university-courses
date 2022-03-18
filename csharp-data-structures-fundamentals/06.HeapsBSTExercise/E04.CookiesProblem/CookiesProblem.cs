using Wintellect.PowerCollections;

namespace E04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            OrderedBag<int> cookieBag = new OrderedBag<int>();
            cookieBag.AddMany(cookies);

            int steps = 0;
            int currSweetness = cookieBag.GetFirst();
            while (currSweetness < minSweetness && cookieBag.Count > 1)
            {
                int firstCookie = cookieBag.RemoveFirst();
                int secondCookie = cookieBag.RemoveFirst();

                int newCookie = firstCookie + 2 * secondCookie;
                cookieBag.Add(newCookie);
                currSweetness = cookieBag.GetFirst();

                steps++;
            }

            return currSweetness < minSweetness ? -1 : steps;
        }
    }
}
