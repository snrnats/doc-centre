# Getting Started with PRO's Shipments APIs

Welcome to SortedPRO! Here you'll find a brief overview of PRO's Shipments APIs and how you can call them.

---

## Shipments API Overview

PRO's Shipments functionality was introduced as an extension to the previous Consignments suite of APIs. PRO's Shipments API collection offers unparalleled flexibility, with support for on-demand collections from multiple smaller locations (e.g. a ship-from-store model) as well the regular scheduled fulfilment centre collections supported by Consignments.

Shipments also offers the ability to auto-manifest with carriers, the ability to group shipments together for ease of management, and improved dangerous goods and customs functionality, among many other features.

> <span class="note-header">More Information:</span>
>
> For more information on the differences between PRO's Shipments API suite and the older Consignments API suite, see the <a href="/pro/api/shipments/consignments_vs_shipments.html">Consignments vs Shipments</a> page.

PRO's Shipments APIs enable you to:

* **Manage Shipments** - Create, update, clone, cancel and delete shipment records, and manually modify their shipment states where required.
* **Allocate Shipments** - Allocate shipments to the most appropriate carrier service, allocate within a service group, manually filter services to allocate to, or allocate based on a previous delivery quote.
* **Manage Quotes** - Create and receive delivery quotes for shipments.
* **Get Customs Docs** - Get customs documents for allocated international shipments. 
* **Get Labels** - Get delivery labels for an allocated shipment in either ZPL or PDF format.
* **Manifest Shipments** - Manually manifest an individual shipment, all shipments that meet a particular query, or all shipments in a particular shipment group. 
* **Manage Shipment Groups** - Group shipments together so they can be operated on as a single unit, and edit or delete shipment groups as required.
* **Get Collection Notes** - Retrieve collection notes (aka a driver's manifest) by search query, or by shipment group.
* **Track Shipments** - Return tracking updates for a given shipment. 

<span class="highlight">NEED SOME SORT ODF NOTE ABOUT REACT TRACKING IN HERE</span>

> <span class="note-header">More Information</span>
>
> * For example API call flows, see LINK HERE.
> * For API reference information, see LINK HERE.

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

## Request Headers



## Response Headers



<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/copy.js"></script>