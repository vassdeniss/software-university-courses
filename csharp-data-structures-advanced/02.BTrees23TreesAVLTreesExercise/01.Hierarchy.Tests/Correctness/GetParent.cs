using System;

using NUnit.Framework;

namespace _01.Hierarchy.Tests.Correctness
{
    public class GetParent : BaseTest
    {
        [Test]
        public void GetParent_WithNonExistentElement_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.Hierarchy.GetParent(-17);
            });
        }

        [Test]
        public void GetParent_WithRoot_ShouldReturnDefault()
        {
            int result = this.Hierarchy.GetParent(DefaultRootValue);

            Assert.AreEqual(default(int), result, "GetParent command returned a wrong result!");
        }

        [Test]
        public void GetParent_WithANodeWithAParent_ShouldReturnParentValue()
        {
            this.Hierarchy.Add(DefaultRootValue, 17);
            this.Hierarchy.Add(DefaultRootValue, 20);
            this.Hierarchy.Add(17, 22);
            this.Hierarchy.Add(20, 15);
            this.Hierarchy.Add(20, -33);

            int result = this.Hierarchy.GetParent(-33);

            Assert.AreEqual(20, result, "GetParent command returned a wrong result!");
        }
    }
}
