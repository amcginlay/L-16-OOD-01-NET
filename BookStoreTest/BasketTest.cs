using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore;

namespace BookStoreTest
{
    /// <summary>
    /// Summary description for BasketTest
    /// </summary>
    [TestClass]
    public class BasketTest
    {
        public BasketTest()
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
        public void TestGivenAValidBasketWhenNoBookAddedThenBasketSizeIsZero()
        {
            // Arrange
            Basket basket;
            // Act
            basket = new Basket();
            // Assert            
            Assert.AreEqual(0, basket.Size);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenOneBookAddedThenBasketSizeIsOne()
        {
            // Arrange
            Basket basket = new Basket();
            // Act
            basket.Add(new Book());
            // Assert            
            Assert.AreEqual(1, basket.Size);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenTwoBooksAddedThenBasketSizeIsTwo()
        {
            // Arrange
            Basket basket = new Basket();
            // Act
            basket.Add(new Book());
            basket.Add(new Book());
            // Assert            
            Assert.AreEqual(2, basket.Size);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenNoBookAddedThenGetBooksIsNotNull()
        {
            // Arrange
            Basket basket;
            // Act
            basket = new Basket();
            // Assert            
            Assert.IsNotNull(basket.GetBooks());
        }
    }
}
