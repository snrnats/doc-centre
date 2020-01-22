# PRO Call Flows

Ready to get started with SortedPRO? This guide explains some common use cases for PRO's APIs, helping you to see what PRO can do for your business. 

We will cover:

* [Creating and manifesting a consignment with the Classic flow](/api/flows/classic_flow.html)
   
   A simple flow to create a consignment, allocate it to a carrier service using criteria of your choosing, retrieve delivery labels, and confirm the delivery with the carrier. 

* [Offering and using delivery options with the Consumer Options flow](/api/flows/consumer_options_flow.html) 

   Used when you want to present delivery options to your customer at point of purchase. PRO creates and allocates consignments based on the options the customer selects.

* [Offering and using pickup options with the Consumer Options Pickup flow](/api/flows/consumer_options_pickup_flow.html)

   Similar to the **Consumer Options** flow, but used when offering delivery to a pickup/drop-off (PUDO) location rather than home delivery. 

* [Creating a pack order flow from a PRO order with the Order Flex flow](/api/flows/order_flex_flow.html)

   Used when you can't guarantee that all parts of a customer's order will be picked, packed and dispatched from the same place at the same time. PRO can generate multiple consignments from a single customer order where required.

* [Using delivery options to create a pack order flow with the Consumer Options Flex flow](/api/flows/consumer_options_flex_flow.html)

   Used when you can't guarantee that all parts of a customer's order will be picked, packed and dispatched from the same place at the same time, and you want to present delivery options to your customer at point of purchase.

* [Obtaining and selecting delivery quotes with the Quotes flow](/api/flows/quotes_flow.html)

   Used to obtain a full list of potential delivery services for a consignment. Often used to validate a consignment's detail or to enable a customer service operator to get quotes for a customer manually and act on the customer's response.

> <span class="note-header">Note:</span>
> This guide is intended as a primer for PRO. If you're already familiar with the basics of PRO, or you just need reference info for PRO's APIs, see the <a href="https://docs.electioapp.com/#/api">API reference</a>.
>
> Sample requests and responses are available in both <strong>JSON</strong> and <strong>XML</strong>. To switch between the two, use the tabs at the top of the right-hand panel.

## Authentication

You will need to provide a valid API key in every API call you make to SortedPRO. When a new user account is created, PRO generates a unique API key and allocates it to the new user. To view your API key:

1. Log in to the PRO dashboard and select **Settings > Users & Roles > [User Accounts](https://www.electioapp.com/Company/UserAccounts)** to display the **User Accounts** page. A list of the user accounts that you have access to is displayed.
2. Click the **Edit User** button for your account to display your account details.
3. Click **Show API Key**. PRO prompts you to re-enter your UI password.
4. Enter your password and click **Retrieve API Key** to display your API key.

To use your API key, include it in an `ocp-apim-subscription-key` header when making calls to PRO. If you make an API call to PRO without including an API key, then PRO returns an error with a status code of _401 (Unauthorized)_.

<div class="tab">
    <button class="staticTabButton">Example API Key</button>
</div>
<div id="apikeyexample" class="staticTabContent">

   ```
   ocp-apim-subscription-key: [qwerrtyuiioop0987654321]
   ```

</div>   

## Specifying Request / Response Format

PRO's APIs support both JSON and XML content types. PRO expects `application/json` data by default, but you can specify which content type you are sending for each API request if required. To do so, pass a `content-type` header with a value of `application/json`, `text/xml` or `application/xml` (as applicable) in your request. All other content types are invalid.

You can also specify the content type that you want PRO to use in API responses. To do so, pass an `accept` header with a value of `application/json`, `text/xml`, or `application/xml` in your request. If you don't pass an `accept` header then PRO responds with `application/json`.

<div class="tab">
    <button class="requestTabLinks" onclick="openRequestTab(event, 'json')" id="defaultRequest">JSON Example</button>
    <button class="requestTabLinks" onclick="openRequestTab(event, 'xml')">XML Example</button>
</div>

<div id="json"  class="requestTabContent">

```json
content-type: application/json
accept: application/json
```

</div>

<div id="xml"  class="requestTabContent">

```xml
content-type: application/xml
accept: application/xml
```
</div>

## Specifying API version

You should include an `electio-api-version` header specifying the API version to use in all PRO API calls. The current version is _1.1_.

<div class="tab">
    <button class="staticTabButton">Example API Version Header</button>
</div>
<div id="apikeyexample" class="staticTabContent">

   ```
   electio-api-version: 1.1
   ```

</div>   

[!include[scripts](../includes/scripts.md)]