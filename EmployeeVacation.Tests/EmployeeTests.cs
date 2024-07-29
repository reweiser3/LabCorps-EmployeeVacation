using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeVacation.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        /// <summary>
        /// Tests that an exception is thrown when a negative number of days worked is provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Work_DaysWorkedNegative_ThrowsException()
        {
            // Arrange
            var employee = new HourlyEmployee();

            // Act
            employee.Work(-1);

            // Assert: Exception is expected
        }

        /// <summary>
        /// Tests that an exception is thrown when the number of days worked exceeds 260.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Work_DaysWorkedExceeds260_ThrowsException()
        {
            // Arrange
            var employee = new SalariedEmployee();

            // Act
            employee.Work(261);

            // Assert: Exception is expected
        }

        /// <summary>
        /// Tests that hourly employees accumulate the correct number of vacation days after working.
        /// </summary>
        [TestMethod]
        public void Work_HourlyEmployeeAccumulatesCorrectVacation()
        {
            // Arrange
            var employee = new HourlyEmployee();

            // Act
            employee.Work(130);

            // Assert
            Assert.AreEqual(5, employee.VacationDays);
        }

        /// <summary>
        /// Tests that salaried employees accumulate the correct number of vacation days after working.
        /// </summary>
        [TestMethod]
        public void Work_SalariedEmployeeAccumulatesCorrectVacation()
        {
            // Arrange
            var employee = new SalariedEmployee();

            // Act
            employee.Work(130);

            // Assert
            Assert.AreEqual(7.5f, employee.VacationDays);
        }

        /// <summary>
        /// Tests that managers accumulate the correct number of vacation days after working.
        /// </summary>
        [TestMethod]
        public void Work_ManagerAccumulatesCorrectVacation()
        {
            // Arrange
            var employee = new Manager();

            // Act
            employee.Work(130);

            // Assert
            Assert.AreEqual(15, employee.VacationDays);
        }

        /// <summary>
        /// Tests that an exception is thrown when attempting to take more vacation days than accumulated.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TakeVacation_DaysTakenExceedsVacationDays_ThrowsException()
        {
            // Arrange
            var employee = new Manager();
            employee.Work(130);

            // Act
            employee.TakeVacation(20);

            // Assert: Exception is expected
        }

        /// <summary>
        /// Tests that the number of vacation days is correctly reduced when vacation days are taken.
        /// </summary>
        [TestMethod]
        public void TakeVacation_VacationDaysReducedCorrectly()
        {
            // Arrange
            var employee = new SalariedEmployee();
            employee.Work(260);

            // Act
            employee.TakeVacation(5);

            // Assert
            Assert.AreEqual(10, employee.VacationDays);
        }
    }
}
