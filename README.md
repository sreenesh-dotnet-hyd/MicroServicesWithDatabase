LOAD BALANCING: Steps to Run the Solution

1. Configure Database Connections

* Open the following files and update the connection strings to match your environment:

  * ProductService->Models -> DbContext file
  *  OrdersService->Model -> DbContext file

2. Run Multiple Instances of OrderService

* Navigate to the **OrdersService** project directory in File Explorer.
* Open **PowerShell** in that directory. Example:

e.g C:\Users\Sreenesh.Reddy\source\repos_nov\MicroServicesWithDatabase\OrdersService>

* Run the first instance:
dotnet run --urls https://localhost:5004

* Open **another PowerShell** window and run the second instance:
dotnet run --urls https://localhost:5003

* Verify both instances are running. You should see output like:
Microsoft.Hosting.Lifetime[14]
Now listening on: https://localhost:5004
info: Microsoft.Hosting.Lifetime[0]
Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
Content root path: C:\Users\Sreenesh.Reddy\source\repos_nov\MicroServicesWithDatabase\OrdersService

3. Configure and Run the Solution in Visual Studio
* Open the solution in **Visual Studio**.
* Ensure **multiple startup projects** are selected:

  * `API_GATEWAY`
  * `OrderService`
  * `ProductService`
* Run the solution.
  
4. Verify Ocelot Configuration
* Make sure the port numbers in `ocelot.json` match the ports on which your services are running (e.g., 5003 and 5004 for OrderService).

5. Test the Load Balancing

* Use **Postman** or any API client to call the API via the gateway:
e.g
https://localhost:7157/api/Orders

> Note: `7157` is the **API Gateway port**. Make sure it matches the port configured in your project.


