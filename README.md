﻿## Dignity Health - Curbside API

Curbside Product provides patient case submision and review features to ouside and inhouse Doctors as Providers.Administrative users to manage access and previlage to submit and review patientcase from Curbside mobile Apps.Submitter app allows to submit patient case along with images,which will be reviewed by the Dignity inshouse doctors through the reviewer app and submitter will be notified once the patient case is reviewed. 

Curbside API is the restful API suite serves the mobile apps and web portal. Core domain would be driven by the apis thus making the Apps light weight.  



### Getting Started

These instructions will get you a copy of the project up and 
running on your local machine for development and testing purposes.

 ##### 1. Installation process

**Step 1:-** Get the code base from Microsoft visual studio team services by logging into
your dignity health microsoft account.

**Step 2:-** Get the curbside-keyvault.pfx (KeyVault certificate) certificate from https://smailer.dignityhealth.org/enduser/def/en/login.html

**Step 3:-** Install the pfx certificate into your local system to Personal folder by entering
the password which is available in the above portal.

**Step 4:-** Rebuild the project and verify that the build is succeeded.
    	
**Step 5:-** Set the Web API project as start up project and run the project now. Check for the Swagger documentation in the browser, this
confirms that the project is setup successfully.

**Note:-** If your network is not able to access DignityHealth network please register your IP
in Azure portal Local Network Gateways.



##### 2. Dependencies

 1. CIAM API - Identity Management System 
 2. Sendgrid Emailing API - Email integration
 3. Azure Blob Storage - Image storage for helpdesk tickets and user profile pictures
 4. KeyVault - Storing connection strings in a secured manner.
 5. Application Insights - Logging app errors.

##### 3. Latest releases

**MVP:-** YTD

**Version 1.1:-**  YTD

##### 4. API references

http://web-usw1-curbsideapi-slot2-tst.ase-usw1-shared-ppe.p.azurewebsites.net

### Build and Test

Build the application and run in a browser. Application can be manually tested through swagger documentation. 
In order to run unit test cases there are two projects available DH.Curbside.API.UnitTest and DH.Curbside.Core.Application.UnitTest. One for the 
API level and other for Application level. Please run these tests.

### Contribute

 Please read Dignity Health coding standards, and the process for submitting pull requests to us.