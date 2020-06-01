namespace HotelReservation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        public Room()
        {
            RoomReservation = new Dictionary<int, int>();
        }
        public Dictionary<int, int> RoomReservation { get; set; }
        
        /// <summary>
        /// Make reservation in room
        /// </summary>
        /// <param name="startDate">Start date of reservation</param>
        /// <param name="endDate">End date of reservation</param>
        /// <param name="resevationNumber">Number of reservation</param>
        public void MakeReservation(int startDate, int endDate,int resevationNumber)
        {
            for (int i = startDate; i < endDate + 1; i++)
            {
                RoomReservation.Add(i, resevationNumber);
            }
        }
        /// <summary>
        /// Find all reservation in room in period 
        /// </summary>
        /// <param name="startDate">Start date of period</param>
        /// <param name="endDate">End date of period</param>
        /// <returns>[List<Tuple<int,int>>] List of reservation in room for period betwean startDate and EndDate</returns>
        public List<Tuple<int,int>> GetReservationForPeriod(int startDate, int endDate)
        {
            var returnListOfReservations = new List<Tuple<int, int>>();
            var tempReservationNumber = -1;
            
            for (int i = startDate; i < endDate + 1; i++)
            {
                if (RoomReservation.TryGetValue(i, out var value))
                {
                    if (tempReservationNumber != value)
                    {
                        //Geting start date and end date of reservation
                        returnListOfReservations.Add(new Tuple<int, int>(RoomReservation.Where(r => r.Value == value).Min(r => r.Key), RoomReservation.Where(r => r.Value == value).Max(r => r.Key)));
                        tempReservationNumber = value;
                    }
                }                      
            }
            return returnListOfReservations;
        }
        
    }
}
