using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;
using Lab_17_Northwind_Test;
using Lab14_Linq;
using Lab_20_Northwind_Products;



namespace NUnit_Tests
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}
    }


    class NUnit_Tests
    {
        //annotations
        [SetUp]
        public void Setup()
        {
            // eg get data from database for all tests
        }


        #region array to dictionary
        [Test]
        public void RunThisTest()
        {
            // Arrange (data)

            //Act (run test)

            // assert
            Assert.AreEqual(true, true);


        }

        [TestCase(10, 11, 12, 13, 14, -1)]
        [TestCase(20, 21, 22, 23, 24, -1)]
        [TestCase(30, 31, 32, 33, 34, -1)]
        [TestCase(40, 41, 42, 43, 44, -1)]

        public void ArraylistDictionaryGetTotal(int a, int b, int c, int d, int e, int expected)
        {
            // call method in other project
            // get answer
            // see if answer is the correct or not
            int actual = TestCollections.ArrayListDictionaryGetTotal(a, b, c, d, e);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region rabbitgrowthtest
        [TestCase(3, 7, 8)]
        public void RabbitGrowthTests(int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            // Arrange

            //Act
            (int actualCumulativeRabbitAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);
            //Assert
            Assert.AreEqual(expectedRabbitAge, actualCumulativeRabbitAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        #endregion

        #region rabbitgrowthAfterReachedMaturatytest
        [TestCase(3, 3, 1)]
        [TestCase(4, 4, 2)]
        [TestCase(5, 6, 3)]
        [TestCase(6, 9, 4)]
        public void RabbitGrowthAfterachedAtTheAgeOfThreeTests(int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            // Arrange

            //Act
            (int actualCumulativeRabbitAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbitsAfterAgeThreeReached(totalYears);
            //Assert
            Assert.AreEqual(expectedRabbitAge, actualCumulativeRabbitAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        #endregion

        #region testNumberOfNorthwindCUstomers
        /* create a class to read in northwind customers and return the total 
         * Then repeat for just customers
         * 
         */
        [TestCase(null, 98)]     // how many customers total
        [TestCase("london", 13)]  // how many customers in London

        public void TestNUmberOfNorthwindCustomers(string city, int expected)
        {

            // arrange
            var testing = new Lab14_Linq.AllCustomerTest();

            // act
            var actual = testing.CustomerCount(city);
            //assert
            Assert.AreEqual(expected, actual);

        }

        #endregion

        #region testNumberOfproducts
        [TestCase(3)]
        public void  testNumberOfProductsStartingWithP(int expected) 
        {
            //range(instance)
            var testing = new Lab_20_Northwind_Products.NorthwindTesting();
            // act (method)
            var actual = testing.TestingProductNorthwind();
            //assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region testNumberOfproductsStartingwithAnyLetter
        [TestCase("p", 17)]
        [TestCase("a", 58)]
        [TestCase("d", 30)]
        public void testNumberOfProductsWithAnyLetter(String letters, int expected)
        {
            //range(instance)
            var testing = new Lab_20_Northwind_Products.NorthwindTesting();
            // act (method)
            var actual = testing.TestingProductNorthwindWithAnyLetter(letters);
            //assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

    }
}
