# Online Sales Application Overview
## What the sample is intended to demonstrate
This sample is intended to illustrate the required components of an application which:
* Facilitates an administrator to create, read, update/edit and delete entries to a catalogue of products 
	* The administrator must assign a valid Software Potential Sku Id to each catalogue entry. As such, the product details and associated Sku Id should relate to a similar product SKU created at the Software Potential portal.
	* The administrator can assign a License type to the catalog entries
* Facilitates a customer to view a list of products, select a product of interest and to ‘buy’ this product	
	* At the point of sale of a product, the Software Potential Web APIs are utilised to provide the customer with licensing information (Activation Key and License Id)

# Using the Sample
## Initial Set-up
* A valid set of Software Potentials credentials must be configured within this application in order to commence working with it. These credentials may be configured in one of the following ways:-
	* Run the application in your browser and follow the instructions at the error page to a credentials entry page, and insert your username and password in the relevant text boxes
	* Execute the configureSoftwarePotentialCredentials.ps1 file( a PowerShell Script ) and enter your username and password when prompted.
	* Note: On entering the user credentials using these methods, the password is encrypted in the SoftwarePotential.config file and as such, you should not edit add the username and password values in the SoftwarePotential.config file manually.
	

## Buying a product / Obtaining License Info
* Navigate to the ‘Buy’ section of the site
* Select and ‘buy’ a product from the list of products on offer
* License information is returned from the Software Potential Web Service (this sample application includes an Activation Key and a License Id) and added to a purchase record, which is displayed to the customer

# Troubleshooting
The most common problems reported with the sample are:
### License information is not obtained
* Ensure the user credentials you provide to the application are accurate and for a valid Software Potential account
* Ensure that the account for which you included user credentials contains valid products and SKUs to make use of the Web APIs
