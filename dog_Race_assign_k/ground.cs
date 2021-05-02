using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dog_Race_assign_k
{
    public class ground
    {
        public static int endPoint=780;
        Random rd = new Random();
        //this code is used to  make random wins 
        
        public int genStep() {
            return rd.Next(1,40);
        }

        //here we step the end point 
        public int stp(int post) {
            if (post > endPoint)
            {
                return 1;
            }
            else {
                return 0;
            }
        }
    }
}
