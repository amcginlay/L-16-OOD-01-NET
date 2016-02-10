using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore;

namespace BookStoreTest
{
    /// <summary>
    /// Summary description for CheckoutTest
    /// </summary>
    [TestClass]
    public class CheckoutTest
    {
        public CheckoutTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGivenAValidCheckoutWhenANullBasketIsProcessedThenAnExceptionIsThrown()
        {
            // Arrange
            var checkout = new Checkout();
            // Act
            double total = checkout.Process(null);
            // Assert
        }

        [TestMethod]
        public void TestGivenAValidCheckoutWhenAnEmptyBasketIsProcessedThenTotalIsZero()
        {
            // Arrange
            var checkout = new Checkout();
            // Act
            double total = checkout.Process(new Basket());
            // Assert
            Assert.AreEqual(0.0, total);
        }

        [TestMethod]
        public void TestGivenAValidCheckoutWhenBasketWithOneBookIsProcessedThenTotalIsSameAsPriceOfBook()
        {
            // Arrange
            const double PRICE = 1.99;
            var checkout = new Checkout();
            var basket = new Basket();
            basket.Add(new Book() { Price = PRICE });
            // Act
            double total = checkout.Process(basket);
            // Assert
            Assert.AreEqual(PRICE, total);
        }

        [TestMethod]
        public void TestGivenAValidCheckoutWhenBasketWithOneBookIsProcessedThenTotalIsSameAsPriceOfBookSecondAttempt()
        {
            // Arrange
            const double PRICE = 1.97;
            var checkout = new Checkout();
            var basket = new Basket();
            basket.Add(new Book() { Price = PRICE });
            // Act
            double total = checkout.Process(basket);
            // Assert
            Assert.AreEqual(PRICE, total);
        }

        [TestMethod]
        public void TestGivenAValidCheckoutWhenBasketWithTwoSameBooksIsProcessedThenTotalIsSameAsTwoTimesThePriceOfThatBook()
        {
            // Arrange
            const double PRICE = 1.99;
            var checkout = new Checkout();
            var basket = new Basket();
            basket.Add(new Book() { Price = PRICE });
            basket.Add(new Book() { Price = PRICE });
            // Act
            double total = checkout.Process(basket);
            // Assert
            Assert.AreEqual(PRICE * 2, total, 0.0001);
        }
    }
}
