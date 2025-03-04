using _21_relations;

namespace _22_test_project
{
    [TestClass]
    public class SmartPhoneTest
    {
        SmartPhone phone = new("iPhone", "Green", 12, 325, 2.2F);
        SimCard card = new() { Number = "123", Provider = "Test" };

        [TestMethod]
        public void TestInjectSIM()
        {
            phone.InjectSIM(card);
            Assert.IsTrue(phone.IsSimExists, "SIM inject methods does not work correctly!");
        }

        [TestMethod]
        public void TestEjectSIM()
        {
            phone.InjectSIM(card);
            phone.EjectSIM();
            Assert.IsFalse(phone.IsSimExists, "SIM eject methods does not work correctly!");
        }
    }
}