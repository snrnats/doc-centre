# Getting Started with PRO Consignments APIs

Welcome to SortedPRO! Here you'll find a brief overview of PRO's Consignments APIs and how you can call them.

---

## Consignments Overview

In PRO, a _consignment_ is a collection of one or more packages that are shipped from the same origin address, to the same destination address, on behalf of the same Sorted customer, using the same carrier service, on the same day. Consignments form the basis of PRO's Consignments API suite, which enables you to build flexible shipping workflows that manage a consignment's journey from customer order right through to delivery. 

PRO's Consignments suite offers the following APIs:

* **Allocation** - Allocates consignments to an appropriate carrier services.
* **Carrier Services** - Returns available carrier services.
* **Carriers** - Returns available carriers.
* **Consignments** - Adds, gets, updates and deletes consignment information.
* **Customs Docs** - Returns customs docs for international consignments.
* **Delivery Options** - Returns potential delivery timeslots for consignments.
* **Events** - Searches for specified consignment events.
* **Labels** - Returns labels for a consignment.
* **Manifest** - Adds consignments to the relevant carrier manifest.
* **Orders** - Adds, gets, updates and deletes order information.
* **Package Sizes** - Returns standardised package sizes.
* **Packages** - Deletes a package from a consignment.
* **Pickup Options** - Returns potential pickup locations and timeslots for a consignment.
* **Quotes** - Returns manual delivery quotes for a consignment. 
* **Shipping Locations** - Returns pre-configured shipping locations.
* **Tracking** - Returns tracking information for a consignment.

> <span class="note-header">More Information</span>
>
> * For example API call flows, see the [PRO Call Flows](/pro/api/help/flows.html) section.
> * For API reference information, see the [API Reference](https://docs.electioapp.com/#/api/PostTrackingEvents).

## Authentication

You will need to provide a valid API key in every call you make to SortedPRO. When a new user account is created, PRO generates a unique API key and allocates it to the new user. To view your API key:

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

PRO's APIs support both JSON and XML content types. You should state which content type you are sending for each API request sent to PRO. To do so, pass a `content-type` header with a value of `application/json`, `text/xml` or `application/xml` (as applicable) in your request. All other content types are invalid.

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

## Specifying API Version

You should include an `electio-api-version` header specifying the API version to use in all PRO API calls. The current version is _1.1_.

<div class="tab">
    <button class="staticTabButton">Example API Version Header</button>
</div>
<div id="apikeyexample" class="staticTabContent">

```
electio-api-version: 1.1
```

</div>

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/copy.js"></script>
