
 # CandidateHubApi Descriprtion
 CandidateHubApi is a RESTful API built using .NET Core 6 and Entity Framework Core for managing job candidate information. 
 This API allows you to create and update candidate profiles, storing data in a SQL Server database. 
 It is designed to scale and handle a large volume of candidate records in the long term.

# Features

 Create and update candidate profiles using a single API endpoint.
 Unique identification of candidates by email.
 Stores the following candidate information:
 First Name
 Last Name
 Phone Number
 Email (used as the unique identifier)
 Time interval for preferred contact
 LinkedIn and GitHub profile URLs
 Additional comments
 Extensible architecture allowing future support for different databases.
 Unit tests for core functionality.


# Technologies Used

 .NET Core 6
 Entity Framework Core
 SQL Server (with future support for other databases)
 xUnit for unit testing


# Ensure you have the following installed:

 .NET 6 SDK
 SQL Server (or SQL Server LocalDB)
 Postman (for API testing) or Swagger (comes built-in with the project)

# SETUP INSTRUCTION
 git clone https://github.com/nic-maharjan/CandidateHubApi.git
# Set up the Database:
 Open appsettings.json and configure the DefaultConnection string to point to your SQL Server instance: