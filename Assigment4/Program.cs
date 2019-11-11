using System;
using System.Collections.Generic;

namespace COMP10066_Lab4
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */


    //All Rules are from https://www.dofactory.com/reference/csharp-coding-standards
    //Pascal Casing: Applied
    //Camel Casing: Applied
    //Hungarion Notation: Not Applied
    //Screaming Caps: Not Applied
    //Abbreviation Rules: Applied
    //Pascal Casing for Abbreviations: Applied
    //Underscores: Not Applied
    //Predefined Type Names: Applied
    //Implicit var rules: Applied
    //Noun for class: Applied
    //Prefix Interfaces: Applied
    //Source File Naming: Applied
    //Namespace Organization: Applied
    //vertically align curly brackets: Applied
    //Declare member variables: Applied
    //Enum rules: Applied

    public class A4
    {
        /// <summary>
        /// this method calculate the average by calling a method that
        /// calculates the sum, then checks how many elements are in the list
        /// then divides the sum and the number of elements by eachother
        /// to give us the average of the set
        /// </summary>
        /// <param name="testDataD"></param>
        /// <param name="notNegative"></param>
        /// <returns>the average value of the set</returns>
        public static double CalculateAverage(List<double> testDataD, bool notNegative)
        {

            double sum = CalculateSum(testDataD, notNegative);
            int counter = 0;
            for (int i = 0; i < testDataD.Count; i++)
            {
                if (notNegative || testDataD[i] >= 0)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new ArgumentException("Test data cannot be empty");
            }
            return sum / counter;
        }
        /// <summary>
        /// this method calaculates the total sum by adding each value 
        /// in the set to a total value variable
        /// </summary>
        /// <param name="testDataD"></param>
        /// <param name="notNegative"></param>
        /// <returns>The total sum of the values in the set</returns>
        public static double CalculateSum(List<double> testDataD, bool notNegative)
        {
            //if statment used to check if test data is empty, sends error message if true
            if (testDataD.Count < 0)
            {
                throw new ArgumentException("Test data cannot be empty");
            }


            double sum = 0.0;
            //foreach loops adds all values to a total value for each value in set
            foreach (double value in testDataD)
            {
                if (notNegative || value >= 0)
                {
                    sum += value;
                }
            }

            //returns the total value of all numbers in set 
            return sum;
        }

        /// <summary>
        /// this method gets the value located in the middle of the set
        /// this is done by sorted the set from greatest to least
        /// then getting the number of elements in the set and dividing by 2
        /// if number of element are odd it takes the the average of the number in the position
        /// middle +1 and middle -1
        /// </summary>
        /// <param name="testDataD"></param>
        /// <returns>the median of the set</returns>
        public static double CalculateMedian(List<double> testDataD)
        {
            //if statment used to check if test data is empty, sends error message if true
            if (testDataD.Count == 0)
            {
                throw new ArgumentException("Test data cannot be empty");
            }

            //sorts data greatest to least
            testDataD.Sort();

            //finds the middle position of the set
            double median = testDataD[testDataD.Count / 2];
            //if the set is odd  it will take the average of the two numbers in position middle+1 and middle-1
            if (testDataD.Count % 2 == 0)
                median = (testDataD[testDataD.Count / 2] + testDataD[testDataD.Count / 2 - 1]) / 2;

            //returns median
            return median;
        }
        /// <summary>
        /// this method calculate the standard deviation by calling a method that calculates the average
        /// then takes each value of the set subtracts it from the average and raises it to the power of 2
        /// and adds the answer to a total variable
        /// then the total is divided by the number of elements in the list -1 
        /// and square rooted
        /// </summary>
        /// <param name="testDataD"></param>
        /// <returns>the standard deviation of the set</returns>
        public static double CalculateStandardDeviation(List<double> testDataD)
        {
            //if the test set has 1 or less numbers in the set throws error message
            if (testDataD.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int ListSize = testDataD.Count;
            double total = 0;
            double average = CalculateAverage(testDataD, true);

            //for loop adds all (values- average)^2 to a total 
            for (int i = 0; i < ListSize; i++)
            {
                double value = testDataD[i];
                total += Math.Pow(value - average, 2);
            }

            //square roots the (total/ sizeOfList -1) 
            double standardDeviation = Math.Sqrt(total / (ListSize - 1));

            //returns standard deviation
            return standardDeviation;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<double> testDataD = new List<double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            Console.WriteLine("The sum of the array = {0}", CalculateSum(testDataD, true));

            Console.WriteLine("The average of the array = {0}", CalculateAverage(testDataD, true));

            Console.WriteLine("The median value of the Double data set = {0}", CalculateMedian(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", CalculateStandardDeviation(testDataD));
        }
    }
}