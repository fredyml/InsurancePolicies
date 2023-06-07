# InsurancePolicies
Insurance Policies API
This API provides a RESTful service for managing auto insurance policies in a MongoDB database. Each insurance policy contains the following information:

Policy Number
Client Name
Client Identification
Client Birth Date
Policy Start Date
Policy End Date
Covered Coverages
Maximum Coverage Value
Policy Plan Name
Client City
Client Address
Vehicle License Plate
Vehicle Model
Vehicle Inspection Indicator
The service allows registering new insurance policies only if they are currently active.

The service includes an endpoint to retrieve policy information by policy number or vehicle license plate.

Endpoints
The following endpoints are available:

POST /api/policies: Creates a new insurance policy. The request must include the policy details in the request body in JSON format.
GET /api/policies/number/{policyNumber}: Retrieves policy information by policy number.
GET /api/policies/vehicle/{licensePlate}: Retrieves policy information by vehicle license plate.
Environment Variables
Before running the API, make sure to set the following environment variables:

MONGO_HOST: MongoDB host address.
MONGO_PORT: MongoDB port.
MONGO_DATABASE: MongoDB database name.
Requirements
Before running the API, make sure you have the following requirements met:

MongoDB installed and configured on your system.
.NET Core SDK installed on your machine.
Configuration
Before running the API, make sure to configure the MongoDB connection in the application. Since the connection string is stored in environment variables, there is no need for an appsettings.json file.

Execution
Follow these steps to run the API:

Open a terminal and navigate to the project's root folder.

Run the following command to restore the dependencies:

bash
Copy code
dotnet restore
Next, run the following command to build the project:

bash
Copy code
dotnet build
Finally, run the following command to start the API:

bash
Copy code
dotnet run
The API will run on http://localhost:5000 or https://localhost:5001 using HTTPS.

API Documentation
You can find the complete API documentation automatically generated at http://localhost:5000/swagger or https://localhost:5001/swagger. This documentation describes all available endpoints and data models.

Contributions
Contributions to this project are welcome. Please fork the repository and submit pull requests with your improvements.

License
This project is licensed under the MIT License.
