namespace HotelReservation
{
    using System;

    public class Program
    {
        static void Main()
        {
            //Reading hotel size
            Console.WriteLine("Enter size of hotel.");
            var hotelSizeStr = ReadLine();
            int hotelSize;           
            while (!int.TryParse(hotelSizeStr, out hotelSize) || hotelSize > 1000 || hotelSize < 1) {
                Console.WriteLine("Invalid input. Enter size of hotel again.");
                hotelSizeStr = ReadLine();
            }
            
            var hotel = new Hotel(hotelSize);
            //Reading reservation
            while (true) { 
                //Reading start date for reservation 
                Console.WriteLine("Enter reservation start date of resevation.");
                var startDateString = ReadLine();
                int startDate, endDate;
                while (!int.TryParse(startDateString, out startDate))
                {
                    Console.WriteLine("Invalid input. Enter integer number for resevation start day.");
                    startDateString = ReadLine();
                }
                //Reading end date for reservation
                Console.WriteLine("Enter reservation end date of resevation.");
                var endDateString = ReadLine();
                while (!int.TryParse(endDateString, out endDate))
                {
                    Console.WriteLine("Invalid input. Enter integer number for resevation end day.");
                    endDateString = ReadLine();
                }
                //Checking reservation status
                var resrvationSatus = hotel.MakeReservation(startDate, endDate);
                if (resrvationSatus)
                {
                    Console.WriteLine("Accept");
                }
                else 
                {
                    Console.WriteLine("Decline");
                }
            }
        }

        /// <summary>
        /// Checking is input equals to "Exit Hotel" for exiting from application 
        /// </summary>
        /// <returns>[string] Input string</returns>
        public static string ReadLine() { 
            var input = Console.ReadLine();
            
            if (input.Equals("Exit Hotel")) {
                //Exiting from application
                Environment.Exit(0);
            }
            return input;
        }
    }
}
