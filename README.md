# Scheduling System for Global Consulting

A C# Windows Forms application developed for a global consulting organization to manage customer records and schedule appointments across multiple time zones.

## Screenshots

![Login Form (English)](https://github.com/MatthewMorrow/C969-scheduling-system/blob/main/Screenshots/LoginForm%20-%20English.png)
![Login Form (German)](https://github.com/MatthewMorrow/C969-scheduling-system/blob/main/Screenshots/LoginForm%20-%20German.png)
![Main Form](https://github.com/MatthewMorrow/C969-scheduling-system/blob/main/Screenshots/MainForm.png)
![Customer Form](https://github.com/MatthewMorrow/C969-scheduling-system/blob/main/Screenshots/CustomerForm.png)
![Appointment Form](https://github.com/MatthewMorrow/C969-scheduling-system/blob/main/Screenshots/AppointmentForm.png)
![Report Form](https://github.com/MatthewMorrow/C969-scheduling-system/blob/main/Screenshots/ReportForm.png)

## Features

* **Multilingual Interface**: Supports English and German localization for login screen and error messages
* **User Authentication**: Secure login with credentials verification and activity logging
  
**Customer Management**:
 * Add, update, and delete customer records with validation
 * Tracks customer details including name, address, and contact information
   
**Appointment Scheduling**:
 * Schedule appointments linked to customer records
 * Business hour validation (9:00 AM - 5:00 PM ET, Monday-Friday)
 * Prevents overlapping appointments
   
**Calendar View**:
 * Toggle between daily and monthly views using radio buttons
 * Select specific dates to view appointments
   
**Time Zone Management**:
 * Automatic adjustment of appointment times based on user's time zone
 * Handles daylight saving time considerations
   
**Notification System**:
 * Alerts for upcoming appointments within 15 minutes of login
   
**Reporting Functionality**:
 * 3 types of reports utilizing lambda expressions:
   * Appointment types by month
   * Schedule for each user
   * Appointments by customer

## Technical Details

* Built with C# and .NET Framework
* Connects to MySQL database for data persistence
* Implements exception handling for database operations
* Records login activity in "Login_History.txt"
* Uses collection classes and lambda expressions for reporting
* Data validation for all user inputs
* Supports localization and globalization

## Database Setup

Run the included `SchedulingSystem.sql` script to create the necessary database structure. The script creates the `client_schedule` database with all required tables and relationships.

## Usage

1. **Login**: Use credentials (username: "test", password: "test")
2. **Main Dashboard**: View the calendar and appointments
3. **Manage Customers**: Add, edit, or delete customer records
4. **Schedule Appointments**: Create appointments linked to customers
5. **Generate Reports**: View business intelligence reports

## System Requirements

* Windows OS
* .NET Framework 4.5 or higher
* MySQL database connection

---

*This application was developed to meet the needs of a mock global consulting organization with offices in Phoenix, New York, and London.*
