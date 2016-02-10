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
        Basket basket;

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

        [TestInitialize()]
        public void TestInitialize() 
        {
            basket = new Basket();
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenNoBookAddedThenBasketSizeIsZero()
        {
            // Arrange
            // Act
            // Assert            
            Assert.AreEqual(0, basket.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGivenAValidBasketWhenNullIsAddedThenExceptionIsThrown()
        {
            // Arrange
            // Act
            basket.Add(null);
            // Assert            
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenOneBookAddedThenBasketSizeIsOne()
        {
            // Arrange
            basket.Add(new Book());
            // Act
            // Assert            
            Assert.AreEqual(1, basket.Size);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenTwoBooksAddedThenBasketSizeIsTwo()
        {
            // Arrange
            basket.Add(new Book());
            basket.Add(new Book());
            // Act
            // Assert            
            Assert.AreEqual(2, basket.Size);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenNoBookAddedThenGetBooksIsNotNull()
        {
            // Arrange
            // Act
            // Assert            
            Assert.IsNotNull(basket.GetBooks(), "test expected that GetBooks() would not return null");
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenNoBookAddedThenGetBooksLengthIsZero()
        {
            // Arrange
            // Act
            Book[] books = basket.GetBooks();
            // Assert            
            Assert.AreEqual(0, books.Length);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenOneBookAddedThenGetBooksLengthIsOne()
        {
            // Arrange
            basket.Add(new Book());
            // Act
            Book[] books = basket.GetBooks();
            // Assert            
            Assert.AreEqual(1, books.Length);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenThreeBookAddedThenGetBooksLengthIsThree()
        {
            // Arrange
            basket.Add(new Book());
            basket.Add(new Book());
            basket.Add(new Book());
            // Act
            Book[] books = basket.GetBooks();
            // Assert
            Assert.AreEqual(3, books.Length);
        }
    }
}
