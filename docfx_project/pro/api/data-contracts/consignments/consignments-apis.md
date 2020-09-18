---
uid: pro-api-data-contracts-consignments-consignments-apis
title: Consignments API Reference
tags: consignments,pro,api,reference,data-contract
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 12/08/2020
---
# Consignments API Reference

---

# Calling APIs in PRO

---

# Allocation

## Allocate Consignments

Allocates the specified consignment using default rules.

### Request

| Endpoint | `PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/allocate-consignments-200)
# [202 - Accepted](#tab/allocate-consignments-202)
# [400 - Bad Request](#tab/allocate-consignments-400)
---

## Allocate Consignment With Service Group

Allocates the specified consignment with the specified Carrier Service Group.

### Request

| Endpoint | `PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}` |
|---|---|
| Parameters: | Consignment Reference	string
Mpd Carrier Service Group Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/allocate-consignment-with-service-group-200)
# [202 - Accepted](#tab/allocate-consignment-with-service-group-202)
# [400 - Bad Request](#tab/allocate-consignment-with-service-group-400)
---

## Allocate Using Default Rules

Allocates the specified consignments using your default rules.

### Request

| Endpoint | `PUT https://api.electioapp.com/allocation/allocate` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/allocate-using-default-rules-200)
# [202 - Accepted](#tab/allocate-using-default-rules-202)
# [400 - Bad Request](#tab/allocate-using-default-rules-400)
# [429 - Not Known](#tab/allocate-using-default-rules-429)
---

## Allocate With Carrier Service

Allocates the specified consignments with the specified carrier service.

### Request

| Endpoint | `PUT https://api.electioapp.com/allocation/allocatewithcarrierservice` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/allocate-with-carrier-service-200)
# [202 - Accepted](#tab/allocate-with-carrier-service-202)
# [400 - Bad Request](#tab/allocate-with-carrier-service-400)
---

## Allocate With Quote

Allocates the consignment with the specified quote.

### Request

| Endpoint | `PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithquote/{quoteReference}` |
|---|---|
| Parameters: | Consignment Reference	string
Quote Reference	Guid |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/allocate-with-quote-200)
# [202 - Accepted](#tab/allocate-with-quote-202)
# [400 - Bad Request](#tab/allocate-with-quote-400)
---

## Deallocate Consignment

Deallocates the specified consignment. Note: the consignment must be in an allocated state for this to be successful.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/{consignmentReference}/deallocate` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/deallocate-consignment-200)
# [202 - Accepted](#tab/deallocate-consignment-202)
# [404 - Not Found](#tab/deallocate-consignment-404)
---

## Deallocate Consignments

Deallocates the specified consignments

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/deallocatelist` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/deallocate-consignments-200)
---

---

# Carrier Services

## Get Available MPD Carrier Services

Returns the available MPD Carrier Services for your subscription.

### Request

| Endpoint | `GET https://api.electioapp.com/carrierservices` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-available-mpd-carrier-services-200)
# [404 - Not Found](#tab/get-available-mpd-carrier-services-404)
---

---

# Carriers

## Get Carriers

Returns all Carriers

### Request

| Endpoint | `GET https://api.electioapp.com/carriers/getcarriers` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-carriers-200)
# [404 - Not Found](#tab/get-carriers-404)
---

## Get MPD Carrier Services for Subscription

Returns all MPD Carrier Services in a subscription

### Request

| Endpoint | `GET https://api.electioapp.com/carriers` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-mpd-carrier-services-for-subscription-200)
# [404 - Not Found](#tab/get-mpd-carrier-services-for-subscription-404)
---

---

# Collection Calendar

## Get Collection Calendar

Gets the collection calendar for the specified shipping location and MPD Carrier.

### Request

| Endpoint | `GET https://api.electioapp.com/collectioncalendar/{shippingLocationReference}/{mpdCarrierReference}` |
|---|---|
| Parameters: | Shipping Location Reference	string
Mpd Carrier Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-collection-calendar-200)
# [404 - Not Found](#tab/get-collection-calendar-404)
---

---

# Consignments

## Add Package

Add a new package to an existing consignment.

### Request

| Endpoint | `POST https://api.electioapp.com/consignments/{consignmentReference}/addpackage` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/add-package-201)
# [400 - Bad Request](#tab/add-package-400)
# [404 - Not Found](#tab/add-package-404)
---

## Cancel Consignment

Cancels the specified consignment.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/{consignmentReference}/cancel` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/cancel-consignment-201)
# [400 - Bad Request](#tab/cancel-consignment-400)
# [404 - Not Found](#tab/cancel-consignment-404)
---

## Cancel Consignments

Cancels the specified consignments

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/cancellist` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/cancel-consignments-201)
# [400 - Bad Request](#tab/cancel-consignments-400)
# [404 - Not Found](#tab/cancel-consignments-404)
---

## Create Consignment

Create a new consignment

### Request

| Endpoint | `POST https://api.electioapp.com/consignments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/create-consignment-201)
# [400 - Bad Request](#tab/create-consignment-400)
# [500 - Internal Server Error](#tab/create-consignment-500)
---

## Dispatch Consignments

Dispatches the specified consignments.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/Dispatch` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/dispatch-consignments-200)
# [202 - Accepted](#tab/dispatch-consignments-202)
# [404 - Not Found](#tab/dispatch-consignments-404)
---

## Get Consignment

Retrieve the details of the specified consignment

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-consignment-200)
# [404 - Not Found](#tab/get-consignment-404)
---

## Get Consignment Status

Returns the status of the specified consignment

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/{consignmentReference}/status` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-consignment-status-200)
# [404 - Not Found](#tab/get-consignment-status-404)
---

## Get Consignment With Metadata

Returns the consignment including associated metadata.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/getconsignmentwithmetadata/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-consignment-with-metadata-200)
# [404 - Not Found](#tab/get-consignment-with-metadata-404)
---

## Get Consignments References

Returns a list of consignment references based off search criteria

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/getConsignmentReferences` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-consignments-references-200)
# [400 - Bad Request](#tab/get-consignments-references-400)
# [404 - Not Found](#tab/get-consignments-references-404)
---

## Get Customer Manifest

Returns the specified manifest.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/customer/manifest/{manifestReference}` |
|---|---|
| Parameters: | Manifest Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-customer-manifest-200)
# [404 - Not Found](#tab/get-customer-manifest-404)
---

## Get Customer Manifests

Returns all customer manifests with an optional shipping location query string parameter.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/customer/manifests?shippingLocationReference=string` |
|---|---|
| Parameters: | None |
| Query Strings: | Shipping Location Reference	string | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-customer-manifests-200)
# [404 - Not Found](#tab/get-customer-manifests-404)
---

## Search Consignments

Search for matching consignments.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/{take}/{skip}?startFrom=date&endAt=date&pageSize=int&startPage=int&createdDateFrom=date&createdDateTo=date&scheduledDeliveryDateFrom=date&scheduledDeliveryDateTo=date&shippedDateFrom=date&shippedDateTo=date&shippingDateFrom=date&shippingDateTo=date&requestedDeliveryDateFrom=date&requestedDeliveryDateTo=date&reference=string&referenceProvidedByCustomer=string&trackingReference=string&state=string&weightInGramsFrom=int&weightInGramsTo=int&carrierService=string&source=string&postCode=string&valueFrom=decimal&valueTo=decimal&labelsPrinted=boolean&searchTerm=string&stateAttribute=string&shippingLocationReference=string&destinationCountryCode=string&destinationRegion=string&packageNumber=string&consignmentNumber=string&creference=string&preference=string` |
|---|---|
| Parameters: | Take	int
Skip	int |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/search-consignments-200)
# [404 - Not Found](#tab/search-consignments-404)
---

## Set Not Ready to Ship

Sets the specified consignments as 'Allocated' from 'Ready to Ship'.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/setnotreadytoship` |
|---|---|
| Parameters: | None |
| Query Strings: | Start From	date
End At	date
Page Size	int
Start Page	int
Created Date From	date
Created Date To	date
Scheduled Delivery Date From	date
Scheduled Delivery Date To	date
Shipped Date From	date
Shipped Date To	date
Shipping Date From	date
Shipping Date To	date
Requested Delivery Date From	date
Requested Delivery Date To	date
Reference	string
Reference Provided By Customer	string
Tracking Reference	string
State	string
Weight In Grams From	int
Weight In Grams To	int
Carrier Service	string
Source	string
Post Code	string
Value From	decimal
Value To	decimal
Labels Printed	boolean
Search Term	string
State Attribute	string
Shipping Location Reference	string
Destination Country Code	string
Destination Region	string
Package Number	string
Consignment Number	string
Creference	string
Preference	string | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/set-not-ready-to-ship-200)
# [404 - Not Found](#tab/set-not-ready-to-ship-404)
---

## Set Ready to Ship

Sets the specified consignments as 'Ready to Ship'. Only applicable to consignments in an 'Allocated' state.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/setreadytoship` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/set-ready-to-ship-200)
# [404 - Not Found](#tab/set-ready-to-ship-404)
---

## Update Consignment

Updates the specified consignment. Note: this method will replace any provided properties and you should therefore ensure you pass the entire consignment as you would like it to be.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/update-consignment-200)
# [400 - Bad Request](#tab/update-consignment-400)
# [404 - Not Found](#tab/update-consignment-404)
---

---

# Customs Docs

## Get Commercial Invoice

Returns the commercial invoice for the specified consignment.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/docs/commercialinvoice/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-commercial-invoice-200)
# [404 - Not Found](#tab/get-commercial-invoice-404)
---

## Get Customs Document

Gets the document of the requested type.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/docs/{customsDocumentType}/{consignmentReference}/{packageReference}` |
|---|---|
| Parameters: | Customs Document Type	string
Consignment Reference	string
Package Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-customs-document-200)
# [404 - Not Found](#tab/get-customs-document-404)
---

## Get Customs Documents

Returns all customs documents for the specified consignment.

### Request

| Endpoint | `GET https://api.electioapp.com/consignments/docs/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-customs-documents-200)
# [404 - Not Found](#tab/get-customs-documents-404)
---

---

# Delivery Options

## Delivery Option Summary

Return a summary of delivery options matching the request details.

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/summary` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/delivery-option-summary-201)
---

## Delivery Options

Returns delivery options matching the request details.

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

201 - Created

## Get Existing Delivery Option

Returns the details of an existing delivery option.

### Request

| Endpoint | `GET https://api.electioapp.com/deliveryoptions/details/{deliveryOptionReference}` |
|---|---|
| Parameters: | Delivery Option Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-existing-delivery-option-200)
# [404 - Not Found](#tab/get-existing-delivery-option-404)
---

## Select Delivery Option as an Order

Select orders using delivery option references

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/selectorder` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/select-delivery-option-as-an-order-201)
# [207 - Multi Status](#tab/select-delivery-option-as-an-order-207)
# [400 - Bad Request](#tab/select-delivery-option-as-an-order-400)
---

## Select Option

Select a delivery option by reference

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}` |
|---|---|
| Parameters: | Delivery Option Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/select-option-200)
---

---

# Events

## Get Consignment Events of specified type

Returns Consignment Events of specified type

### Request

| Endpoint | `POST https://api.electioapp.com/events/consignments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-consignment-events-of-specified-type-200)
# [400 - Bad Request](#tab/get-consignment-events-of-specified-type-400)
---

## Get Consignment State Events of specified type

Returns Consignment State Events of specified type

### Request

| Endpoint | `POST https://api.electioapp.com/events/consignments/stateevents` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-consignment-state-events-of-specified-type-200)
# [400 - Bad Request](#tab/get-consignment-state-events-of-specified-type-400)
---

---

# Labels

## Get Labels

Returns labels for the specified consignment.

### Request

| Endpoint | `GET https://api.electioapp.com/labels/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-labels-200)
# [404 - Not Found](#tab/get-labels-404)
---

## Get Labels in Format

Returns labels for the specified consignment in the specified format.

### Request

| Endpoint | `GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}` |
|---|---|
| Parameters: | Consignment Reference	string
Label Format	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-labels-in-format-200)
# [404 - Not Found](#tab/get-labels-in-format-404)
---

## Get Package Label

Returns the label for the specified package.

### Request

| Endpoint | `GET https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}` |
|---|---|
| Parameters: | Consignment Reference	string
Package Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-package-label-200)
# [404 - Not Found](#tab/get-package-label-404)
---

## Get Package Label in Format

Returns the label for the specified package in the specified format.

### Request

| Endpoint | `GET https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}/{labelFormat}` |
|---|---|
| Parameters: | Consignment Reference	string
Package Reference	string
Label Format	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-package-label-in-format-200)
# [404 - Not Found](#tab/get-package-label-in-format-404)
---

---

# Manifest

## Manifest Consignments

Manifests the specified consignments.

### Request

| Endpoint | `PUT https://api.electioapp.com/consignments/manifest` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/manifest-consignments-200)
# [202 - Accepted](#tab/manifest-consignments-202)
# [404 - Not Found](#tab/manifest-consignments-404)
---

## Manifest Consignments From Query

Manifests all consignments that match the given criteria.

### Request

| Endpoint | `POST https://api.electioapp.com/consignments/manifestFromQuery` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/manifest-consignments-from-query-200)
# [400 - Bad Request](#tab/manifest-consignments-from-query-400)
---

---

# Orders

## Add Address to Order

Adds an Address to an Order

### Request

| Endpoint | `POST https://api.electioapp.com/orders/{orderReference}/address` |
|---|---|
| Parameters: | Order Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/add-address-to-order-201)
# [400 - Bad Request](#tab/add-address-to-order-400)
# [404 - Not Found](#tab/add-address-to-order-404)
---

## Create Order

Creates an order

### Request

| Endpoint | `POST https://api.electioapp.com/orders` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/create-order-201)
# [400 - Bad Request](#tab/create-order-400)
---

## Get Order

Retrieve the details of the specified order

### Request

| Endpoint | `GET https://api.electioapp.com/orders/{orderReference}` |
|---|---|
| Parameters: | Order Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-order-200)
# [400 - Bad Request](#tab/get-order-400)
# [404 - Not Found](#tab/get-order-404)

## Pack Order

Packs a consignment from an order

### Request

| Endpoint | `POST https://api.electioapp.com/orders/{orderReference}/pack` |
|---|---|
| Parameters: | Order Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/pack-order-201)
# [400 - Bad Request](#tab/pack-order-400)

## Select Delivery Option as an Order

Select orders using delivery option references

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/selectorder` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/select-delivery-option-as-an-order-201)
# [207 - Multi Status](#tab/select-delivery-option-as-an-order-207)
# [400 - Bad Request](#tab/select-delivery-option-as-an-order-400)
---

## Update Address on Order

Updates an Address on an Order

### Request

| Endpoint | `PUT https://api.electioapp.com/orders/{orderReference}/address` |
|---|---|
| Parameters: | Order Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/update-address-on-order-200)
# [400 - Bad Request](#tab/update-address-on-order-400)
# [404 - Not Found](#tab/update-address-on-order-404)
---

## Update Order

Updates the details of the specified order

### Request

| Endpoint | `PUT https://api.electioapp.com/orders/{orderReference}` |
|---|---|
| Parameters: | Order Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/update-order-200)
# [400 - Bad Request](#tab/update-ordere-400)
# [404 - Not Found](#tab/update-order-404)
---

---

# Package Sizes

## Get Package Sizes

Returns your custom package sizes.

### Request

| Endpoint | `GET https://api.electioapp.com/packagesizes` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-package-sizes-200)
# [404 - Not Found](#tab/get-package-sizes-404)
---
---

# Packages

## Delete Package

Deletes the specified package.

### Request

| Endpoint | `DELETE https://api.electioapp.com/packages/{packageReference}` |
|---|---|
| Parameters: | Package Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

There is no response body for this request. You should check the HTTP Status Code to determine success

---

# Pickup Options

## Pickup Options

Returns pickup options matching the request details

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/pickupoptions/` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/pickup-options-200)

## Reserve Pickup Option

Reserves a specified pickup option

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/reserve/{pickupOptionReference}` |
|---|---|
| Parameters: | Pickup Option Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

There is no response body for this request. You should check the HTTP Status Code to determine success

## Select Option

Select a delivery option by reference

### Request

| Endpoint | `POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}` |
|---|---|
| Parameters: | Delivery Option Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/select-option-200)

---

# Quotes

## Get Quotes

Get quotes matching the request details.

### Request

| Endpoint | `POST https://api.electioapp.com/quotes/` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/get-quotes-201)
# [400 - Bad Request](#tab/get-quotes-400)
---

## Get Quotes by Consignment Reference

Returns quotes for an existing consignment identified by the provided reference.

### Request

| Endpoint | `GET https://api.electioapp.com/quotes/consignment/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [201 - Created](#tab/get-quotes-by-consignment-reference-201)
# [400 - Bad Request](#tab/get-quotes-by-consignment-reference-400)
---

## Get Service Group Quotes

Get quotes matching the request details grouped by Service Group.

### Request

| Endpoint | `POST https://api.electioapp.com/quotes/serviceGroups` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-service-group-quotes-200)
---

---

# Shipping Locations

## Get Assigned Shipping Locations

Returns the list of shipping location with which the current user's account has been linked.

### Request

| Endpoint | `GET https://api.electioapp.com/shippinglocations/assigned` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-assigned-shipping-locations-200)
---

## Get Shipping Locations

Returns all shipping locations for the current company, including those to which the current user has not been linked.

### Request

| Endpoint | `GET https://api.electioapp.com/shippinglocations` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-shipping-locations-200)
---

---

# Tracking

## Get Events Per Package

Returns events for each package in a consignment.

### Request

| Endpoint | `GET https://api.electioapp.com/tracking/flattened/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-events-per-package-200)
# [404 - Not Found](#tab/get-events-per-package-404)
---

## Get Tracking Events

Returns all tracking events for a consignment.

### Request

| Endpoint | `GET https://api.electioapp.com/tracking/{consignmentReference}` |
|---|---|
| Parameters: | Consignment Reference	string |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

# [200 - OK](#tab/get-tracking-events-200)
# [404 - Not Found](#tab/get-tracking-events-404)
---

## Post Tracking Events

Post tracking events for a consignment. Note: This endpoint is designed for us by carriers in order to provide tracking details to Sorted.

### Request

| Endpoint | `POST https://api.electioapp.com/tracking/carrierevents` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 

### Response

There is no response body for this request. You should check the HTTP Status Code to determine success.

---

<script src="/pro/scripts/dropdown.js"></script>