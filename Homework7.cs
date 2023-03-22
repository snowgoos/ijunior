using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior
{
    internal class Homework7
    {
        static void Main(string[] args)
        {
            int peopleInQueue;
            int serviceTimeInMinutes = 10;
            int minutesInHour = 60;
            int waitingTime;
            int waitingHours;
            int waitingMinutes;

            Console.Write("Please enter people count in queue: ");
            peopleInQueue = Convert.ToInt32(Console.ReadLine());

            waitingTime = peopleInQueue * serviceTimeInMinutes;
            waitingHours = waitingTime / minutesInHour;
            waitingMinutes = waitingTime % minutesInHour;

            Console.WriteLine($"Total waiting time in queue {waitingHours}h {waitingMinutes}m");
        }
    }
}
