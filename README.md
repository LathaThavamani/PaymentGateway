## **Payment Gateway**
---
Payment Gateway is an API based application that will allow a merchant to offer a way for their shoppers to pay for their Product.

### **Features**
---
- ***Process payment*** : The payment gateway is used to provide merchants with a way to process a payment. The merchant is able to submit a request to the payment gateway. A payment request contains fields such as the card number, expiry month/date,amount,current & CVV.
- ***Retrieving payment details*** : The payment gateway allows a merchant to retrieve details of a already processed payment using payment identifier (Id). Additionally have one more feature to retrieve all the processed payments
The response includes a ``masked card number`` along with other payment fields.
- ***Retrieving payment details*** : Built Bank simulator to simulate the Acquiring Bank. Used EFCore in-memory DB to store & retrieve payment details during runtime.

### **Tech Library Used**
---
- C#
- .Net Core 6
- EF Core In-memory package
- OOPs Concept
- LINQ
- Postman or other API testing Tool

  
### **Installation and Setup instruction**
---

- [Installation and Setup Guide](./Documentation/PaymentGateway-ProjectSetupGuide.pdf) : Please read the instructions and setup the project locally to test API.
- [API Documentation](./Documentation/PaymentGateway-APIDoucmentation.pdf) : This file contains clear information about all the APIs, Authentication, Request & Response, Validations and attached screenshots for your reference.

### **Areas of improvement**
---
- Payment Gateway version 2 will be available soon with extended features.
- avoid in-memory and use cloud service/Relational SQL/NoSql databases.
- Expand simulator and API with more payment gateway functionalities

### **Extra Mile**
---
- Included ``BasicAuth`` Authorization to access all API
- Incorporated ``Data Model`` validations for Payment Model

### **Contributors**
---
[Latha Thavamani](https://github.com/LathaThavamani)

### **Acknowledgments**
---
I will take all the responsibility for every single line of code.

