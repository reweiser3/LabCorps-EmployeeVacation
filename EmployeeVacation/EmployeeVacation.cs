using System;

namespace EmployeeVacation
{
    /// <summary>
    /// Represents a base class for an employee.
    /// </summary>
    public abstract class Employee
    {
        private float _vacationDays;

        /// <summary>
        /// Gets the number of vacation days accumulated.
        /// </summary>
        public float VacationDays
        {
            get { return _vacationDays; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(VacationDays), "Vacation days cannot be negative.");
                _vacationDays = value;
            }
        }

        /// <summary>
        /// Gets the number of vacation days accumulated per work year.
        /// </summary>
        protected abstract float VacationDaysPerYear { get; }

        public Employee()
        {
            _vacationDays = 0;
        }

        /// <summary>
        /// Updates the number of vacation days accumulated based on the days worked.
        /// </summary>
        /// <param name="daysWorked">Number of days worked.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when daysWorked is not between 0 and 260.</exception>
        public void Work(int daysWorked)
        {
            if (daysWorked < 0 || daysWorked > 260)
                throw new ArgumentOutOfRangeException(nameof(daysWorked), "Days worked must be between 0 and 260.");

            VacationDays += (VacationDaysPerYear / 260) * daysWorked;
        }

        /// <summary>
        /// Updates the number of vacation days after taking vacation.
        /// </summary>
        /// <param name="daysTaken">Number of vacation days taken.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when daysTaken is greater than available vacation days.</exception>
        public void TakeVacation(float daysTaken)
        {
            if (daysTaken < 0 || daysTaken > VacationDays)
                throw new ArgumentOutOfRangeException(nameof(daysTaken), "Cannot take more vacation than accumulated.");

            VacationDays -= daysTaken;
        }
    }

    /// <summary>
    /// Represents an hourly employee.
    /// </summary>
    public class HourlyEmployee : Employee
    {
        protected override float VacationDaysPerYear => 10;
    }

    /// <summary>
    /// Represents a salaried employee.
    /// </summary>
    public class SalariedEmployee : Employee
    {
        protected override float VacationDaysPerYear => 15;
    }

    /// <summary>
    /// Represents a manager, considered a salaried employee with more vacation days.
    /// </summary>
    public class Manager : SalariedEmployee
    {
        protected override float VacationDaysPerYear => 30;
    }
}
