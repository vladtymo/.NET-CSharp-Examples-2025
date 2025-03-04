using _10_classes;

namespace _22_test_project
{
    [TestClass]
    public class ConditionerTest
    {
        [TestMethod]
        public void IncreaseTest()
        {
            Conditioner c = new("Test Model", "Test Model");

            c.Increase();
            c.Increase();
            c.Increase();

            // expected result: 19
            const int expectedT = 19;

            // check result: Assert, CollectionAssert, StringAssert

            Assert.AreEqual(expectedT, c.Temperature);
        }

        [TestMethod]
        public void DecreaseTest()
        {
            Conditioner c = new("Test Model", "Test Model");

            c.Temperature = Conditioner.MAX_T;
            c.Decrease();
            c.Decrease();
            c.Decrease();

            Assert.AreEqual(29, c.Temperature);
        }

        [TestMethod]
        public void TopLimitTest()
        {
            Conditioner c = new("Test Model", "Test Model");

            int count = (Conditioner.MAX_T - Conditioner.MIN_T) * 2;

            for (int i = 0; i < count; i++)
                c.Increase();

            Assert.AreEqual(Conditioner.MAX_T, c.Temperature);
        }
    }
}