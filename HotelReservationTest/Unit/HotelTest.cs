namespace HotelReservationTest.Unit
{
    using HotelReservation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void CheckRoomAvailabilityAcceptTest()
        {
            //Arrange
            var hotel = new Hotel(2);
            var reservation = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2) };

            //Act
            var availableRoomNumber = hotel.CheckRoomAvailability(reservation, hotel.Rooms);

            //Assert
            Assert.AreEqual(0, availableRoomNumber);
        }
        [TestMethod]
        public void CheckRoomAvailabilityDeclineTest()
        {
            //Arrange
            var hotel = new Hotel(1);
            var reservation = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2) };

            //Act
            var reservationStatus = hotel.MakeReservation(1, 2);
            var availableRoomNumber = hotel.CheckRoomAvailability(reservation, hotel.Rooms);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(-1, availableRoomNumber);

        }
        [TestMethod]
        public void CheckRoomAvailabilityAcceptOfReseravationListTest()
        {
            //Arrange
            var hotel = new Hotel(1);
            var reservation = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2),new Tuple<int, int>(3,4) };

            //Act
            var availableRoomNumber = hotel.CheckRoomAvailability(reservation, hotel.Rooms);

            //Assert
            Assert.AreEqual(0, availableRoomNumber);

        }
        [TestMethod]
        public void CheckRoomAvailabilityDeclineOfReseravationListTest()
        {
            //Arrange
            var hotel = new Hotel(2);
            var reservation = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 4) };

            //Act
            var reservationStatus =  hotel.MakeReservation(1, 2);
            var reservationStatus1 = hotel.MakeReservation(1, 2);
            var availableRoomNumber = hotel.CheckRoomAvailability(reservation, hotel.Rooms);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(true, reservationStatus1);
            Assert.AreEqual(-1, availableRoomNumber);

        }
    }
}
