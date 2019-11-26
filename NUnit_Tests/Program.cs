using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;


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
       




        public void ArraylistDictionaryGetTotal(int a, int b, int c , int d, int e , int expected) 
        {
            // call method in other project
            // get answer
            // see if answer is the correct or not
            int actual = TestCollections.ArrayListDictionaryGetTotal(a, b, c, d, e);       

            Assert.AreEqual(expected, actual);
        }
        #region rabbitgrowthtest
        [TestCase(3,7,8)]
        public void RabbitGrowthTests(int totalYears, int expectedRabbitAge, int expectedRabbitCount) 
        {
            // Arrange

            //Act
            (int actualCumulativeRabbitAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);
            //Assert
            Assert.AreEqual(expectedRabbitAge, actualCumulativeRabbitAge);
            Assert.AreEqual( expectedRabbitCount, actualRabbitCount);
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

    }
}
