# template-net-core-webapi

* Authentication
* Fluent validation
* Swagger
* Fluent migrator
* MediatQR

With additionals

* Adapter email with amazon ses
* Custom identity implementation
* Repository generic pattern with Postgresql
* Resources for messages multiples languages
* Exception Middleware And more

#For Credentials of Amazon AWS

you must create a user in amazon iam with the following permissions in s3, ses, sns. 
And add in the environment variables the following: AWS_ACCESS_KEY_ID / AWS_SECRET_ACCESS_KEY / AWS_SESSION_TOKEN
see the file WebApi\Properties\launchSettings.json


you must add the connection Default to DB in WebApi\appsettins.json\appsettings.Development.json

The project has a postman file with the executed examples of the services. Evidence of them is still left.

*The project does not have unit tests, AND the dockerfile is not working. The net version was 3.1, it is being updated to 6.0.*

*Migrations run automatically, you just have to add the connection string*

# Swagger
![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/3a663ee0-d0b2-46c3-b831-40c85e1ebd11)

# Create Roulette

![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/937deebf-0a99-4ef7-b13d-d516d8e827c4)

# Get All Roulette

![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/ba11acc3-abdd-4600-aec7-491471840aab)

# Open Roulette

![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/5d6b1225-a2b1-413c-a0e0-b57b87cc1b34)

# Roulette Has Open - Error

![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/04c098aa-10c5-41a4-aee6-2cb2d14dc17a)

# Roulette Bet
![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/19ebb084-f8d6-4424-8a9c-f7f1211eb543)

# Roulette Bet Error - Validations
![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/e1e7f276-b6c5-4756-b393-b82e5dd2cefa)

# Roulette Bet Error - Not Open
![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/66912230-48b1-49f7-b09e-b07faf691f4b)

# Roulette Close

![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/0ee9605d-90eb-46bb-a38c-c1bda05e540f)

# Roulette Close - Success Winner

![image](https://github.com/harrinson-gutierrez/cautious-octo-giggle/assets/46534751/eb2cc9c7-1d87-4e13-979a-100d8008e243)

