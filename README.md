# Employee Vacation Management System

## Requirements

### Employee Classes
Write classes in C# to represent 3 different types of employees: hourly employees, salaried employees, and managers (also considered salaried employees).

### Vacation Days
- Each employee has a floating-point property for the number of vacation days accumulated for the work year (defined as 260 workdays), which cannot be a negative value and is not writable externally.
- Upon creation, its value should be set to 0.

### Vacation Days Accumulation
- **Hourly employees** accumulate 10 vacation days during the work year.
- **Salaried employees** accumulate 15 vacation days during the work year.
- **Managers** accumulate 30 vacation days during the work year.

### Work Method
Each employee has a `Work()` method that takes a single integer parameter that defines the number of days worked, which should be a value between 0 and 260. When this method is called, the number of vacation days accumulated should be updated appropriately.

### TakeVacation Method
Each employee also has a `TakeVacation()` method that takes a single floating-point parameter that defines the number of vacation days used. When this method is called, the number of vacation days accumulated should be updated appropriately.

### Constraints
- An employee cannot work more than the number of workdays in a work year.
- An employee cannot take more vacation than is available.

### Unit Tests
Unit tests should prove the correctness of the code. At a minimum, the methods for `Work()` and `TakeVacation()` should have tests that check for corner cases.

## Project Structure

The solution is structured into two projects:
1. **EmployeeVacation**: This project contains the implementation of the Employee classes.
2. **EmployeeVacation.Tests**: This project contains the unit tests for validating the functionality of the Employee classes.

## Implementation Details

### EmployeeVacation Project

- **Employee.cs**: Defines the `Employee` base class and its derived classes `HourlyEmployee`, `SalariedEmployee`, and `Manager`.
  - Each class defines the appropriate vacation days accumulation logic.
  - The `Work()` method updates the vacation days based on the days worked.
  - The `TakeVacation()` method updates the vacation days based on the days taken.

### EmployeeVacation.Tests Project

- **EmployeeTests.cs**: Contains unit tests to validate the correct implementation of the Employee classes.
  - Tests include boundary conditions, normal functionality, and corner cases for both `Work()` and `TakeVacation()` methods.
  
### Intentional Tests
- **EmployeeTests.cs**: Contains tests designed to pass, verifying the correct behavior of the methods.
- **EmployeeIntentionalFailureTests.cs**: Contains tests designed to fail, demonstrating the importance of correct logic in the implementation and testing.

## Approach to Testing

1. **Boundary Tests**: Ensure that the methods handle boundary conditions correctly, such as negative days worked or vacation days exceeding the allowed limit.
2. **Functionality Tests**: Validate the normal functionality of the `Work()` and `TakeVacation()` methods, ensuring they update vacation days accurately.
3. **Corner Case Tests**: Check for unusual or extreme cases, such as working zero days or taking zero vacation days.
4. **Intentional Failures**: Include tests that intentionally fail to confirm the robustness of the implementation and highlight the importance of accurate testing.

## Running the Tests

1. **Build the Solution**: Ensure there are no compilation errors by building the solution.
2. **Run the Tests**: Open the Test Explorer in Visual Studio (`Test -> Test Explorer`) and click on `Run All` to execute the unit tests.

These tests ensure that the Employee classes are correctly managing vacation days according to the specified requirements and constraints.
