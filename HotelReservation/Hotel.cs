namespace HotelReservation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Hotel
    {
        public Hotel(int sizeOfHotel)
        {
            SizeOfHotel = sizeOfHotel;
            Rooms = new Room[sizeOfHotel];
            for (int i = 0; i < sizeOfHotel; i++)
            {
                Rooms[i] = new Room();
            }
        }

        public int SizeOfHotel { get; private set; }
        public Room[] Rooms { get; set; }
        
        private int ResevationNumber = 0;

        /// <summary>
        /// Making reservation
        /// </summary>
        /// <param name="startDate">Start date of reservation</param>
        /// <param name="endDate">End date of reservation</param>
        /// <returns>[bool] true - accept reservation, false - decline reservation</returns>
        public bool MakeReservation(int startDate, int endDate) {
            //Validatevalue of start and end date
            if (startDate < 0 || endDate > 365) {
                ResevationNumber++;
                return false;
            }

            var resevation = new List<Tuple<int, int>> { new Tuple<int, int>(startDate, endDate) };
            //Check availability for reservation
            var availableRoomNumber = CheckRoomAvailability(resevation, Rooms);

            if (availableRoomNumber > -1) {
                //Making  reservation
                Rooms[availableRoomNumber].MakeReservation(startDate, endDate, ResevationNumber);
                ResevationNumber++;
                return true;
            }

            //Trying to find new arrange of reservations to free space for temporary resevation

            //Get all reservations in hotel for requested period
            var posibleMovementOfResevations = Rooms.Select(r => r.GetReservationForPeriod(startDate, endDate)).ToArray();
            for (int i = 0; i < SizeOfHotel - 1; i++) {
               
                var availableRoomNumberForReorder = CheckRoomAvailability(posibleMovementOfResevations[i], Rooms);
                if (availableRoomNumberForReorder > -1) {
                    // Move already accepted reservation in other room to free space for temporary resevation
                    MoveReservation(posibleMovementOfResevations[i], i, availableRoomNumberForReorder);
                    Rooms[i].MakeReservation(startDate, endDate, ResevationNumber);
                    ResevationNumber++;
                    return true;
                }
            }

            ResevationNumber++;
            return false;
        }

        /// <summary>
        /// Checking availability for resevations in list of rooms
        /// </summary>
        /// <param name="resevations">Reservationd to reserve</param>
        /// <param name="rooms">Rooms to check for reservation</param>
        /// <returns>[int] Index of room in array that can recieve reservation , -1 - if there is no free space for reservations in list of rooms</returns>
        public int CheckRoomAvailability(List<Tuple<int, int>> resevations, Room[] rooms) {
            for (int i = 0; i < rooms.Length; i++)
            {
                var successReservations = 0;
                foreach (var reservation in resevations)
                {
                    //Checking is space free in room for reservation
                    if (rooms[i].RoomReservation == null || !rooms[i].RoomReservation.Any(k => k.Key >= reservation.Item1 && k.Key <= reservation.Item2))
                    {
                        successReservations++;
                    }                   
                }
                //Checking is temporary room can recevie all resevations from list
                if (successReservations == resevations.Count) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Move list of reservations from one source room to destination room
        /// </summary>
        /// <param name="reservations">List of resevations for moving</param>
        /// <param name="sourceRoom">Index of room in hotel which is source for moving resevations</param>
        /// <param name="destinationRoom">Index of room in hotel which is destination for moving resevations</param>
        public void MoveReservation(List<Tuple<int, int>> reservations, int sourceRoom, int destinationRoom)
        {
            foreach (var reservation in reservations)
            {
                //Get reservation number which is going to be moved
                Rooms[sourceRoom].RoomReservation.TryGetValue(reservation.Item1, out var reservatioNumber);
                //Make reservation in destination room
                Rooms[destinationRoom].MakeReservation(reservation.Item1, reservation.Item2, reservatioNumber);
                //Remove reservation from source room
                foreach (var item in Rooms[sourceRoom].RoomReservation.Where(kvp => kvp.Value == reservatioNumber).ToList())
                {
                    Rooms[sourceRoom].RoomReservation.Remove(item.Key);
                }
            }
        }
    }
}
