# Carriers API

`https://api.electioapp.com/carriers/`

The **Carriers** API enables you to get details of the carriers and carrier services that you have access to. It has two endpoints:

* **[Get Carriers](/api/carriers/getCarriers.html)** - `GET https://api.electioapp.com/carriers/getcarriers` <br/> Returns a list of all the carriers you have access to. 
* **[Get MPD Carrier Services for Subscription](/api/carriers/getMPDCarrierServicesforSubscription.html)** - `GET https://api.electioapp.com/carriers` <br/> Returns a list of all the carrier services you have access to. 

Neither of the **Carriers** API endpoints require any request parameters - they simply return the carriers and carrier services available with your subscription.

This information could be particularly useful when building back-end integrations to customer service systems. 

<span class="highlight">WHAT'S THE DIFFERENCE BETWEEN GET MPD CARRIER SERVICES AND THE CARRIER SERVICE API? </span>