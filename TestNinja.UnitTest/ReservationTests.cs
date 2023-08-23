using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();
            
            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });
            
            // Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CanBeCancelledBy_UserIsAuthor_ReturnsTrue()
        {
            // Arrange
            var user = new User()
            {
                IsAdmin = false
            };
            
            var reservation = new Reservation()
            {
                MadeBy = user
            };
            
            // Act
            var result = reservation.CanBeCancelledBy(user);
            
            // Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CannotBeCancelledBy_UserIsNotAdminOrAuthor_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation
            {
                MadeBy = new User()
            };

            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = false });
            
            // Assert
            Assert.IsFalse(result);
        }
    }
}