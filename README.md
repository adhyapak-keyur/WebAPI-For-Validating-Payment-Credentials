# WebApi-For-Validating-Payment-Credentials
This WebApi is developed using Asp.Net Core and EF Core using Code First Approach with all necessary migrations. 
It used for validating the payment credentials and provides response accordingly.
Also  this Web Api can be used over cross origin. 

Frameworks and technologies used for developing this WebApi:
Asp.Net Core 3.1
Entity FrameWorkCore 3.1.11
Regex Operations

This WebApi will validate following Things:
1. CardNumber :- Mandatory and It should be 16 digit longnumber and the first 4 digits must be one of these: 1298, 1267, 4512, 4567, 8901, 8933
2. SecurityCode :- Security code must be 3 digit numeric.
3. ExpiryDate :- Expiration date must be 2 digits for the month, 4 digits for the year. The month must be between 1 - 12. The year must begin with "20".
4. CardolderName :- Mandatory
5. Amount :- Mandatory

