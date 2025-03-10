using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoA
{
    public class SpeedCamera
    {
        // Checks the car speed against the speed limit and calculates demerit points
        public void CheckSpeed(int speedLimit, int carSpeed)
        {
            if (carSpeed <= speedLimit)
            {
                Console.WriteLine("Ok");
                return;
            }

            // Calculate demerit points for every 5 km/hr above the limit
            int demeritPoints = (carSpeed - speedLimit) / 5;
            Console.WriteLine($"Demerit Points: {demeritPoints}");

            // Check for license suspension
            if (demeritPoints > 12)
            {
                Console.WriteLine("License Suspended");
            }
        }
    }
}
