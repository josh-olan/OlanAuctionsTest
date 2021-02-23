using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlanAuctions.Tests
{
    class Car
    {
        //Properties
        public string numberOfTyres = null;

        //Constructor(s)
        public Car(int numOfTyres = 4) 
        {
            numberOfTyres = Convert.ToString(numOfTyres);
        }

        //Functions/Methods
        public bool IsNumberOfTyresGreaterThanFour()
        {
            return Convert.ToInt32(numberOfTyres) > 4;
        }

    }

    [TestClass]
    public class Test
    {

        [TestMethod]
        public void TestCar()
        {
            Car myCar = new Car(3);
            Console.WriteLine($"Number of tyres is-> {myCar.numberOfTyres}");
            Console.WriteLine(myCar.IsNumberOfTyresGreaterThanFour());
        }
    }
}
