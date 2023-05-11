using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPhinchukovLobutev9_14
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal num1 = 640;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)614.40;

            num1 =  PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod2()
        {
            decimal num1 = (decimal)100.125;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)96.12;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod3()
        {
            decimal num1 = 1234;
            decimal num2 = (decimal)0.14;
            decimal disc = (decimal)1061.24;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod4()
        {
            decimal num1 = -150;
            decimal num2 = (decimal)0.10;
            decimal disc = (decimal)-135;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod5()
        {
            decimal num1 = -6400;
            decimal num2 = (decimal)10.04;
            decimal disc = (decimal)57856.00;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }

        [TestMethod]
        public void TestMethod6()
        {
            decimal num1 = 640;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)614.40;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod7()
        {
            decimal num1 = 640;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)614.40;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod8()
        {
            decimal num1 = 640;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)614.40;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod9()
        {
            decimal num1 = 640;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)614.40;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
        [TestMethod]
        public void TestMethod10()
        {
            decimal num1 = 640;
            decimal num2 = (decimal)0.04;
            decimal disc = (decimal)614.40;

            num1 = PinchukovLobutev9_14.ClassHelper.MyDiscount.Discount(num1, num2);

            Assert.AreEqual(num1, disc);
        }
    }
}
