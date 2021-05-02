using Microsoft.VisualStudio.TestTools.UnitTesting;
using dog_Race_assign_k;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dog_Race_assign_k.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void resultTest()
        {
            ground obj = new ground();
            if (obj.genStep() > 10)
            {
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }
            
            
        }

        [TestMethod()]
        public void resultTest2()
        {
            ground obj = new ground();
            if (obj.stp(800) == 1)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }


        }
    }
}