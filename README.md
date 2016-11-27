# Requirements
Implement Web Api for creating user and his phone subscriptions.<br>
The logic for getting/writing data from/to DB should be in a separate WCF service.<br>
Database can be MS SQL Server or MS SQL Server Express.<br>
 
Client will POST/GET/PUT/DELETE data to Web Api, Web Api will connect to WCF service to write/read data from database.
 
User:
 
Base-URI will be /users
 
API should do the following:
 
Get all users (GET -> /users)
Get current user (GET -> /users/some-url-friendly-identifier)
Create user (POST -> /users)
Add subscription to user (PUT -> /users/subscriptionId)
Delete user (DELETE -> /users/some-url-friendly-identifier)
 
 
JSON-structure for user resource:
 
{
  "id":"some-url-friendly-identifier",
  "firstname":"First name",
  "lastname":"Last name",
  "email":"email",
  "subscriptions": [
{
  "id":"2712e86a-d519-48af-b50b-194e9a2102de",
  "price":24.0,
  "totalPriceIncVatAmount":30.0,
  "callminutes":50
},
{
  "id":"4712e86a-d519-48af-b50b-194e9a2102dd",
  "price":14.0,
  "priceIncVatAmount":20.0,
  "callminutes":20
},
  ],
"totalPriceIncVatAmount":50.0,  //30 + 20
"totalcallminutes":70  // 50 + 20
}
 
totalPriceIncVatAmount is a summary of the price for all subscriptions
totalcallminutes is a summary of call minutes for all subscriptions
 
 
Subscription
 
Base-URI will be /subscriptions
 
API should do the following:
 
Get all subscriptions (GET -> /subscriptions)
Get current subscription (GET -> /subscriptions/some-url-friendly-identifier)
Create subscription (POST -> /subscriptions)
Update subscription data such  (PUT -> /subscriptions/some-url-friendly-identifier)
Delete subscription (DELETE -> /subscriptions/some-url-friendly-identifier)
 
JSON-structure for subscription resource:
 
{
  "id":"2712e86a-d519-48af-b50b-194e9a2102de",
  "name":"50 min deal",
  "price":24.0,
  "priceIncVatAmount":30.0,
  "callminutes":50
}

# Testing
 
 Download project and open with Visual Studio 2015.
 Open SQL SERVER 2012 express and restore database. 
 Database file located in project directory.
 Run the project and you will see all API reference.
 Call API by using PostMan tools.
 
 # Using Technology
 
 ASP.NET Web API
 WCF
 Entity Framework (Code first database)
 .Net Framework 4.5

  
