using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeVacation.Tests
{
    [TestClass]
    public class EmployeeIntentionalFailureTests
    {
        /// <summary>
        /// Intentionally fails by asserting an incorrect number of vacation days for an hourly employee.
        /// </summary>
        [TestMethod]
        public void Work_HourlyEmployeeAccumulatesIncorrectVacation()
        {
            // Arrange
            var employee = new HourlyEmployee();

            // Act
            employee.Work(130);

            // Assert
            Assert.AreEqual(6, employee.VacationDays); // This should fail as the correct value is 5
        }

        /// <summary>
        /// Intentionally fails by allowing more vacation days to be taken than accumulated.
        /// </summary>
        [TestMethod]
        public void TakeVacation_AllowsMoreVacationThanAccumulated()
        {
            // Arrange
            var employee = new SalariedEmployee();
            employee.Work(130);

            // Act
            employee.TakeVacation(8); // This should fail as only 7.5 vacation days are accumulated

            // Assert
            Assert.AreEqual(-0.5f, employee.VacationDays); // This should fail as vacation days cannot be negative
        }
    }
}