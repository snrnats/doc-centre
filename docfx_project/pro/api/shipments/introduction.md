# Getting Started with PRO's Shipments APIs

Welcome to SortedPRO! Here you'll find a brief overview of PRO's Shipments APIs and how you can call them.

---

## Shipments API Collection Overview

PRO's Shipments functionality was introduced as an extension to the previous Consignments suite of APIs. PRO's Shipments API collection offers unparalleled flexibility, with support for on-demand collections from multiple smaller locations (e.g. a ship-from-store model) as well the regular scheduled fulfilment centre collections supported by Consignments.

Shipments also offers the ability to auto-manifest with carriers, the ability to group shipments together for ease of management, and improved dangerous goods and customs functionality, among many other features.

> <span class="note-header">More Information:</span>
>
> For more information on the differences between PRO's Shipments API suite and the older Consignments API suite, see the [Consignments vs Shipments](/pro/api/shipments/consignments_vs_shipments.html) page.

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

<span class="highlight">NEED SOME SORT OF NOTE ABOUT REACT TRACKING IN HERE</span>

> <span class="note-header">More Information</span>
>
> * For example API call flows, see LINK HERE.
> * For API reference information, see LINK HERE.


## Making an API Request in PRO

This section explains the various API headers used when making a request to one of PRO's Shipments APIs.

<div class="tab">
    <button class="staticTabButton">Example PRO Shipments API Headers</button>
</div>
<div id="apikeyexample" class="staticTabContent">

```
x-api-key: [qwerrtyuiioop0987654321]
Accept: application/json
Content-Type: application/json 
Accept-Encoding: gzip 
x-api-version: 1.1

```

</div>

### Authentication

You will need to provide a valid API key in every call you make to SortedPRO. When a new user account is created, PRO generates a unique API key and allocates it to the new user. You can view your API key in the PRO UI.

To use your API key, include it in an `x-api-key` header when making calls to PRO. If you make an API call to PRO without including an API key, then PRO returns an error with a status code of _401 (Unauthorized)_.

### Formats

This Shipments APIs only work with JSON data. This is a change from the Consignments APIs, which supported XML requests and responses as well as JSON. 

If you provide an `Accept` header to indicate request format and/or a `Content-Type` format to indicate response format, then these keys must have a value of _application/json_. PRO will return an error if you provide any other values in these headers. If you do not provide `Accept` and/or `Content-Type` headers, then PRO uses its default value of _application/json_ anyway.

PRO is designed to work with GZIP encoding. We strongly recommend that you provide an `Accept-Encoding` header with a value of _gzip_ in all requests.

### Versioning

You must provide an `x-api-version` header indicating the version of PRO's APIs you want to use in all requests. The current API version is _1.1_.

## Response Headers

Depending on the content returned, PRO's responses may include the following headers:

* `x-api-version` - The version of the API that served the request 
* `Content-Type` -  The format of the response body. This will ordinarily have the value _application/json_. 
* `Content-Encoding` -  If you request responses in GZIP format, the `Content-Encoding` response header returns a value of _gzipped_. 

## Next Steps

* Learn more about the differences between shipments and consignments: [Shipments vs Consignments](/pro/api/shipments/consignments_vs_shipments.html)
* Learn how to create, update and delete shipments: [Managing Shipments](/pro/api/shipments/managing_shipments.html)
* Learn how to allocate shipments to carrier services: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>