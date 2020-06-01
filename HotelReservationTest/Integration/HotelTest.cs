namespace HotelReservationTest.Integration
{
    using HotelReservation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void StartDateValidation()
        {
            //Arrange
            var hotel = new Hotel(1);
            //Act
            var reservationStatus = hotel.MakeReservation(-4, 2);
            //Assert
            Assert.AreEqual(false, reservationStatus);

        }
        [TestMethod]
        public void EndDateValidation()
        {
            //Arrange
            var hotel = new Hotel(1);
            //Act
            var reservationStatus = hotel.MakeReservation(200, 400);
            //Assert
            Assert.AreEqual(false, reservationStatus);

        }
        [TestMethod]
        public void TestCaseWithoutChangingReservationRoom()
        {
            //Arrange
            var hotel = new Hotel(3);

            //Act
            var reservationStatus = hotel.MakeReservation(0, 5);
            var reservationStatus1 = hotel.MakeReservation(7, 13);
            var reservationStatus2 = hotel.MakeReservation(3, 9);
            var reservationStatus3 = hotel.MakeReservation(5, 7);
            var reservationStatus4 = hotel.MakeReservation(6, 6);
            var reservationStatus5 = hotel.MakeReservation(0, 4);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(true, reservationStatus1);
            Assert.AreEqual(true, reservationStatus2);
            Assert.AreEqual(true, reservationStatus3);
            Assert.AreEqual(true, reservationStatus4);
            Assert.AreEqual(true, reservationStatus5);
        }

        [TestMethod]
        public void TestCaseWithoutChangingReservationRoomWithDeclineResevation()
        {
            //Arrange
            var hotel = new Hotel(3);

            //Act
            var reservationStatus = hotel.MakeReservation(1, 3);
            var reservationStatus1 = hotel.MakeReservation(2, 5);
            var reservationStatus2 = hotel.MakeReservation(1, 9);
            var reservationStatus3 = hotel.MakeReservation(0, 15);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(true, reservationStatus1);
            Assert.AreEqual(true, reservationStatus2);
            Assert.AreEqual(false, reservationStatus3);

        }
        [TestMethod]
        public void TestCaseWithoutChangingReservationAcceptAfterDecline()
        {
            //Arrange
            var hotel = new Hotel(3);

            //Act
            var reservationStatus = hotel.MakeReservation(1, 3);
            var reservationStatus1 = hotel.MakeReservation(0, 15);
            var reservationStatus2 = hotel.MakeReservation(1, 9);
            var reservationStatus3 = hotel.MakeReservation(2, 5);
            var reservationStatus4 = hotel.MakeReservation(4, 9);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(true, reservationStatus1);
            Assert.AreEqual(true, reservationStatus2);
            Assert.AreEqual(false, reservationStatus3);
            Assert.AreEqual(true, reservationStatus4);

        }
        [TestMethod]
        public void TestCaseWithChangingReservation()
        {
            //Arrange
            var hotel = new Hotel(2);

            //Act
            var reservationStatus = hotel.MakeReservation(1, 3);
            var reservationStatus1 = hotel.MakeReservation(0, 4);
            var reservationStatus2 = hotel.MakeReservation(2, 3);
            var reservationStatus3 = hotel.MakeReservation(5, 5);
            var reservationStatus4 = hotel.MakeReservation(4, 10);
            var reservationStatus5 = hotel.MakeReservation(10, 10);
            var reservationStatus6 = hotel.MakeReservation(6, 7);
            var reservationStatus7 = hotel.MakeReservation(8, 10);
            var reservationStatus8 = hotel.MakeReservation(8, 9);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(true, reservationStatus1);
            Assert.AreEqual(false, reservationStatus2);
            Assert.AreEqual(true, reservationStatus3);
            Assert.AreEqual(true, reservationStatus4);
            Assert.AreEqual(true, reservationStatus5);
            Assert.AreEqual(true, reservationStatus6);
            Assert.AreEqual(false, reservationStatus7);
            Assert.AreEqual(true, reservationStatus8);

        }
        [TestMethod]
        public void TestCaseWithChangingReservationMovingToResevations()
        {
            //Arrange
            var hotel = new Hotel(2);

            //Act
            var reservationStatus = hotel.MakeReservation(1, 3);
            var reservationStatus1 = hotel.MakeReservation(0, 4);
            var reservationStatus2 = hotel.MakeReservation(2, 3);
            var reservationStatus3 = hotel.MakeReservation(5, 5);
            var reservationStatus4= hotel.MakeReservation(6, 6);
            var reservationStatus5 = hotel.MakeReservation(4, 10);

            //Assert
            Assert.AreEqual(true, reservationStatus);
            Assert.AreEqual(true, reservationStatus1);
            Assert.AreEqual(false, reservationStatus2);
            Assert.AreEqual(true, reservationStatus3);
            Assert.AreEqual(true, reservationStatus4);
            Assert.AreEqual(true, reservationStatus5);

        }
    }
}
