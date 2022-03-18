using NUnit.Framework;
using E04.CookiesProblem;

public class CookiesProblemTests
{
    [Test]
    public void Solve_HasSolution()
    {
        int result = new CookiesProblem().Solve(7, new int[] { 1, 2, 3, 9, 10, 12 });
        Assert.AreEqual(2, result);
    }

    [Test]
    public void Solve_HasNoSolution()
    {
        int result = new CookiesProblem().Solve(10, new int[] { 1, 1, 1, 1 });
        Assert.AreEqual(-1, result);
    }
}
