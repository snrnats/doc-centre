---
uid: pro-api-data-contracts-shipments-shipments-apis
title: Shipments API Reference
tags: shipments,pro,api,reference,data-contract
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 12/08/2020
---
# Shipments API Reference

---

# Calling APIs in PRO

PRO's Shipments APIs accept the following headers:

<div class="dc-row">
    <div class="dc-column">
            <h4>Headers</h4>

[!include[_headers](includes/_headers.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_headers](code-samples/_cs_headers.md)]
</div>
</div>

## Response Headers

Depending on the content returned, PRO's responses may include the following headers:

* `x-api-version` - The version of the API that served the request 
* `Content-Type` -  The format of the response body. This will ordinarily have the value _application/json_. 
* `Content-Encoding` -  If you request responses in GZIP format, the `Content-Encoding` response header returns a value of _gzipped_. 

---

# Shipments

## Create Shipment

This endpoint is used to create new `shipments` within SortedPRO.

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 
| ATU Score | 1.0 |

### Request Body

A `shipment` is a collection of one or more packages sent together from a single `origin` address to a single `destination` address. A `create_shipment_request` is used to create a new `shipment` or to create quotes for a `shipment` that does not yet exist in SortedPRO.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_create_shipment_request](includes/_create_shipment_request.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_create_shipment_request](code-samples/_cs_create_shipment_request.md)]
</div>
</div>

### Response

# [201 - Resource Result](#tab/create-shipment-201)

Returned when the shipment is created successfully. Provides details of the created resource including the new unique shipment reference and _links to the shipment and related resources.

A resource_result is generally returned for all successful requests to create or modify resources.

> [!NOTE]
> This object also includes some optional properties such as errors and version. These properties should be completely excluded from the response when serialising if they are null as the properties do not apply to all types of resource.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/create-shipment-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.

# [403 - API Error](#tab/create-shipment-403)

Returned when your account does not have permission to use this API endpoint.

This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.

---

## Update Shipment

This endpoint is used to update an existing shipment within SortedPRO. The shipment must already exist, and the account used to perform the API request must have permission to update shipments.

> [!NOTE]
> Once a shipment has been allocated, it can no longer be updated.

### Request

| Endpoint | `PUT /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Update Shipment Request | 
| ATU Score | 1.0 |

### Request Body

> [!WARNING]
> All properties in an update_shipment_request should be provided when updating the shipment i.e. customers should provide the full details of the shipment rather than just including properties they wish to update. The properties provided will replace the entire shipment object. There are some system-generated properties of a shipment that cannot be modified, such as allocation and _links.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Resource Result](#tab/update-shipment-200)

Returned when the shipment is updated successfully. Provides details of the updated resource including the unique shipment reference and _links to the shipment and related resources.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/update-shipment-304)

Returned when no changes are made to the shipment as a result of the update request.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/update-shipment-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/update-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Cancel Shipment

This endpoint is used to cancel a booking with a carrier. The state of cancelled is a terminal state, i.e. a shipment can no longer be updated or changed once it has been cancelled, other than deleting the shipment.

### Request

| Endpoint | `PUT /shipments/{reference}/cancel` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/cancel-shipment-200)

Returned when the shipment is cancelled successfully. Provides details of the cancelled resource including the unique shipment reference and _links to the shipment and related resources.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [202 - Resource Result](#tab/cancel-shipment-202)

The request to cancel has been accepted but will be processed at a later stage. This is not a normal expected response but is included for future compatibility.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/cancel-shipment-304)

Returned when no changed is made to the shipment as a result of the cancel request.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/cancel-shipment-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/cancel-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/cancel-shipment-404)

Returned when the shipment with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/cancel-shipment-409)

Returned when there is a conflict that prevent the shipment from being cancelled, e.g. it has already been shipped.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Delete Shipment

This endpoint is used when you wish to completely remove a shipment and all its history from Sorted. This is an irreversible operation – once a shipment has been deleted it cannot be recovered.

> [!WARNING]
> A shipment must have a state of cancelled before it can be deleted. If you attempt to delete a shipment in any other state, you will receive a 400 (Bad Request) response from the API.

### Request

| Endpoint | `DELETE /shipments/{reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/delete-shipment-200)

Returned when the shipment has been deleted successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [202 - Resource Result](#tab/delete-shipment-202)

The request to delete has been accepted but will be processed at a later stage. This is not a normal expected response but is included for future compatibility.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/delete-shipment-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/delete-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/delete-shipment-404)

Returned when the shipment with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/delete-shipment-409)

Returned when there is a conflict that prevent the shipment from being deleted, e.g. it has already been shipped.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Clone Shipment

This endpoint can be used to clone the properties of a shipment. This is useful in situations where a shipment has been cancelled and you wish to start the allocation process again.

> [!NOTE]
> Cloning a shipment will only clone the basic properties of a shipment. For instance, allocation details for a shipment will not be copied to the new shipment, but the address and contents of the shipment will be copied to the new record.

### Request

| Endpoint | `POST /shipments/{reference}/clone` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Resource Result](#tab/clone-shipment-201)

Returned when the shipment has been cloned successfully. The response will include the reference of and links to the new shipment

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/clone-shipment-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/clone-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/clone-shipment-404)

Returned when the shipment with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Change Shipment State

This endpoint can be used to manually change the state of a shipment to the provided value.

### Request

| Endpoint | `PUT /shipments/state` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Shipment State Change Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Resource Result](#tab/change-shipment-state-200)

Returned when the shipment state has been updated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [202 - Resource Result](#tab/change-shipment-state-202)

The request to update the state has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/change-shipment-state-304)

Returned when the shipment state has not been modified. This would be returned, for example, because the shipment is already in the requested state.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/change-shipment-state-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/change-shipment-state-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/change-shipment-state-404)

Returned when the shipment with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Shipment

This endpoint is used to retrieve an existing shipment.

### Request

| Endpoint | `GET /shipments/{reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment](#tab/get-shipment-200)

Returned when the shipment has been located and returned successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [403 - API Error](#tab/get-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-shipment-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Shipments by Custom Reference or Tracking Reference

This endpoint is used to retrieve existing shipment(s) that have the provided custom_reference or tracking_reference.

The tracking_reference for this endpoint refers to the tracking reference generated by or on behalf of the carrier. Therefore, when using the tracking_reference query string only allocated (or beyond) shipments will be returned.

> [!NOTE]
> When creating shipments, customers can provide their own custom_reference property which does not need to be unique. This can be used, for example, to allow customers to create one or more shipments with their own unique reference matching the original order.
>
> The custom_reference parameter here should be use to match the custom_reference value at either shipment or shipment_contents level. For instance, if a customer has created a shipment where the shipment_contents have a custom_reference of CR1234 then a request to /shipments?custom_reference=CR1234 should return any shipment where either the shipment has that custom_reference or the shipment_contents have that custom_reference.

### Request

| Endpoint | `GET /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | custom_reference={reference}</br>carrier_tracking_reference={tracking_reference}</br>take={int}</br>skip={int} | 
| Body: | None | 
| ATU Score | 2.0 |

### Response

# [200 - Shipment List](#tab/get-shipments-by-custom-reference-or-tracking-reference-200)

Returned when the request was successful and one or more shipments have been located and returned.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-shipments-by-custom-reference-or-tracking-reference-400)

Returned when there is an error in the request such as an invalid take or skip query string parameter. A 400 status code will also be returned if neither custom_reference or carrier_tracking_reference query string parameters have a value, i.e. at least one of custom_reference and carrier_tracking_reference are required.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-shipments-by-custom-reference-or-tracking-reference-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-shipments-by-custom-reference-or-tracking-reference-404)

Returned when no shipments with the provided custom_reference and / or carrier_tracking_reference are found.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Paperless Documents

## Get Paperless Document

This endpoint is used to retrieve paperless documents. Paperless documents are provided by customers when creating shipments and enable the transmission of customer-generated documents to carriers.

### Request

| Endpoint | `GET /documents/paperless/{document_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Paperless Document](#tab/get-paperless-document-200)

Returned when the request was successful. The response includes the relevant document.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-paperless-document-400)

Returned when the request is not valid. This could be, for example, a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-paperless-document-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-paperless-document-404)

Returned when a paperless_document with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the paperless_document, or when the paperless_document does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Add Paperless Document

This endpoint is used to enable customers to add paperless documents to existing shipments.

> [!WARNING]
> It is only possible to add a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

### Request

| Endpoint | `POST /documents/paperless/{shipment_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Paperless Document | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [201 - Paperless Document](#tab/add-paperless-document-201)

Returned when the request was successful. The response includes the reference of the new document.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/add-paperless-document-400)

Returned when the request is not valid. This could be, for example, a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/add-paperless-document-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/add-paperless-document-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/add-paperless-document-409)

Returned when a conflict prevents the paperless_document from being added. For example, the shipment has already been allocated.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Remove Paperless Document

This endpoint is used to remove an existing paperless_document from a shipment.

> [!WARNING]
> It is only possible to remove a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

### Request

| Endpoint | `DELETE /documents/paperless/{document_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Paperless Document](#tab/remove-paperless-document-200)

Returned when the request was successful. The paperless_document has been deleted successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/remove-paperless-document-400)

Returned when the request is not valid. This could be, for example, a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/remove-paperless-document-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/remove-paperless-document-404)

Returned when a paperless_document with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the paperless_document, or when the paperless_document does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/remove-paperless-document-409)

Returned when a conflict prevents the paperless_document from being removed. For example, the shipment has already been allocated.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Allocation

## Allocate Shipment

This endpoint is used when you wish to allocate a single shipment using Sorted's allocation engine. If you require allocation of multiple shipments in a single operation, you should use the Allocate Shipments endpoint. When allocating using this endpoint, Sorted will automatically determine the most appropriate carrier service based on several factors, including:

* Configured allocation rules
* Required shipping dates
* Required delivery dates
* Carrier availability
* Carrier service price

### Request

| Endpoint | `PUT /shipments/{reference}/allocate` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-200)

Returned when the shipment has been allocated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Allocate Result](#tab/allocate-shipment-202)

The request to allocate the shipment has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-shipment-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-shipment-404)

Returned when the shipment with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-shipment-521)

Returned when the request was received successfully, but the shipment could not be allocated. 

> [!NOTE] 
> 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate Shipments

This endpoint is used when you wish to allocate multiple shipments using Sorted's allocation engine. If you only require allocation of an individual shipment, you should prefer the single Allocate Shipment endpoint. When allocating using this endpoint, Sorted will automatically determine the most appropriate carrier service based on several factors, including configured allocation rules, required shipping and delivery dates, carrier availability and carrier service price.

> [!NOTE]
> When requesting an allocation of multiple shipments, the allocation will not happen in- process. This is to ensure the performance of the API endpoint. shipments allocated as a batch will be allocated via a background process.

### Request

| Endpoint | `PUT /shipments/allocate` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Allocate Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [202 - Allocate Shipments Result](#tab/allocate-shipments-202)

The request to allocate the shipments has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [207 - Allocate Shipments Result](#tab/allocate-shipments-207)

Returned when one or more shipments have been queued for allocation successfully and one or more shipments have not been queued for allocation successfully. The result will indicate which shipments were successfully queued and which were not

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-shipments-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>
 
# [403 - API Error](#tab/allocate-shipments-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-shipments-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-shipments-521)

Returned when the request was received successfully, but the shipments could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate Shipment with Carrier Service

This endpoint is used when you wish to allocate a shipment with a specific carrier service.

### Request

| Endpoint | `PUT /shipments/{reference}/allocate/service/{service_ref}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-carrier-service-200)

Returned when the shipment has been allocated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Allocate Result](#tab/allocate-shipment-with-carrier-service-202)

The request to allocate the shipment has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-shipment-with-carrier-service-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-shipment-with-carrier-service-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-shipment-with-carrier-service-404)

Returned when the shipment or carrier service with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment or carrier service does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-shipment-with-carrier-service-521)

Returned when the request was received successfully, but the shipment could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate with Carrier Service

This endpoint is used when you wish to allocate one or more shipments with a specific carrier service.

> [!NOTE]
> When requesting an allocation of multiple shipments, the allocation will not happen in-process. This is to ensure the performance of the API endpoint. Any shipments allocated as a batch will be allocated via a background process.

### Request

| Endpoint | `PUT /shipments/allocate/service` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Allocate with Carrier Service Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [202 - Allocate Shipments Result](#tab/allocate-with-carrier-service-202)

The request to allocate the shipments has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [207 - Allocate Shipments Result](#tab/allocate-with-carrier-service-207)

Returned when one or more shipments have been queued for allocation successfully and one or more shipments have not been queued for allocation successfully. The result will indicate which shipments were successfully queued and which were not

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-with-carrier-service-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-with-carrier-service-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-with-carrier-service-404)

Returned when a shipment or carrier service with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment or carrier service does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-with-carrier-service-521)

Returned when the request was received successfully, but the shipments could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate Shipment with Service Group

This endpoint is used to allocate a shipment with a carrier service from a specific carrier service group.

### Request

| Endpoint | `PUT /shipments/{reference}/allocate/service_group/{group_ref}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-service-group-200)

Returned when the shipment has been allocated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Allocate Result](#tab/allocate-shipment-with-service-group-202)

The request to allocate the shipment has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-shipment-with-service-group-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-shipment-with-service-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-shipment-with-service-group-404)

Returned when the shipment or service_group with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment or service_group does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-shipment-with-service-group-521)

Returned when the request was received successfully, but the shipment could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate with Service Group

This endpoint is used to allocate multiple shipments with a carrier service from a specific carrier service_group.

> [!NOTE]
> When requesting an allocation of multiple shipments, the allocation will not happen in-process. This is to ensure the performance of the API endpoint. Any shipments allocated as a batch will be allocated via a background process.

### Request

| Endpoint | `PUT /shipments/allocate/service_group` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Allocate with Service Group Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [202 - Allocate Shipments Result](#tab/allocate-with-service-group-202)

The request to allocate the shipments has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [207 - Allocate Shipments Result](#tab/allocate-with-service-group-207)

Returned when one or more shipments have been queued for allocation successfully and one or more shipments have not been queued for allocation successfully. The result will indicate which shipments were successfully queued and which were not.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-with-service-group-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-with-service-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-with-service-group-404)

Returned when a shipment or service_group with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment or service_group does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-with-service-group-521)

Returned when the request was received successfully, but the shipments could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate with Filters

This endpoint is used when you wish to allocate one or more shipments by selecting a carrier service that matches the provided filters.

> [!NOTE]
> When requesting an allocation of multiple shipments, the allocation will not happen in-process. This is to ensure the performance of the API endpoint. Any shipments allocated as a batch will be allocated via a background process.

### Request

| Endpoint | `PUT /shipments/allocate/filters` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Allocate with Filters Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [202 - Allocate with Filters Result](#tab/allocate-with-filters-202)

The request to allocate the shipments has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [207 - Allocate with Filters Result](#tab/allocate-with-filters-207)

Returned when one or more shipments have been queued for allocation successfully and one or more shipments have not been queued for allocation successfully. The result will indicate which shipments were successfully queued and which were not

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-with-filters-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-with-filters-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-with-filters-404)

Returned when a the filter does not identify any matching shipments.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-with-filters-521)

Returned when the request was received successfully, but the shipments could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate Shipment with Quote

This endpoint is used when you wish to allocate a shipment with a specific pre-existing quote. For obtaining a quote, see Get Quote.

### Request

| Endpoint | `PUT /shipments/{reference}/allocate/quote/{quote_ref}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-quote-200)

Returned when the shipment has been allocated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Allocate Result](#tab/allocate-shipment-with-quote-202)

The request to allocate the shipment has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-shipment-with-quote-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-shipment-with-quote-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-shipment-with-quote-404)

Returned when the shipment or quote with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment or quote, or when the shipment or quote does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-shipment-with-quote-521)

Returned when the request was received successfully, but the shipment could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Allocate Shipment with Virtual Service

> [!TIP]
> The term "virtual service" is used to here to indicate that the provided reference can refer to multiple types of entity such as a carrier service or a carrier service group. This functionality may be extended in the future to include other types of virtual service.

This endpoint is used to allocate a shipment with a specific carrier service or service_group, depending upon the reference provided.

### Request

| Endpoint | `PUT /shipments/{reference}/allocate/virtual_service/{virtual_service_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-virtual-service-200)

Returned when the shipment has been allocated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Allocate Result](#tab/allocate-shipment-with-virtual-service-202)

The request to allocate the shipment has been accepted and will be processed as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/allocate-shipment-with-virtual-service-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation, e.g. where there is an invalid {virtual_service_reference} provided.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/allocate-shipment-with-virtual-service-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/allocate-shipment-with-virtual-service-404)

Returned when the shipment or service_reference with the provided reference is not found. This can occur when the reference is valid but the person making the request does not have access to the shipment, or when the shipment or service_reference does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [521 - API Error](#tab/allocate-shipment-with-virtual-service-521)

Returned when the request was received successfully, but the shipment could not be allocated. Note: 521 is not a standard HTTP status code

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Quotes

## Create Quote

This endpoint is used to retrieve a list of carrier services that are capable of carrying a shipment, based on the properties of the shipment such as dimensions, weight, addresses, and delivery promise. Quotes will be generated according to the "default rules" in the customer's account.

> [!NOTE]
> Although not used to create an actual shipment, this endpoint uses the same request type as create shipment to allow you to re-use the same object in the flow: create quote, identify suitable quote, create shipment.

### Request

| Endpoint | `POST /shipments/quote` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [201 - Quote Result](#tab/create-quote-201)

Returned when one or more quotes have been generated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/create-quote-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/create-quote-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [531 - Quote Result](#tab/create-quote-531)

Returned when the request was received successfully, but there are no quotes are available. Note: 531 is not a standard HTTP status code and is used to provide simpler programmatic detection of a request for which no quotes are available.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

---

## Create Quote by Service Group

This endpoint is used to retrieve a list of carrier services within a specific service group that are capable of carrying a shipment, based on the properties of the shipment such as dimensions, weight, addresses, and delivery promise. Quotes will be generated according to the "default rules" in the customer's account for the services included in the specified service_group.

> [!NOTE]
> Although not used to create an actual shipment, this endpoint uses the same request type as create shipment to allow you to re-use the same object in the flow: create quote, identify suitable quote, create shipment.

### Request

| Endpoint | `POST /shipments/quote/service_group/{group_ref}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [201 - Quote Result](#tab/create-quote-by-service-group-201)

Returned when one or more quotes have been generated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/create-quote-by-service-group-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/create-quote-by-service-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/create-quote-by-service-group-404)

Returned when the specified service_group does not exist or could not be found.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [531 - Quote Result](#tab/create-quote-by-service-group-531)

Returned when the request was received successfully, but there are no quotes are available. Note: 531 is not a standard HTTP status code and is used to provide simpler programmatic detection of a request for which no quotes are available.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

---

## Get Quote

This endpoint is used to retrieve a list of allocation options for a shipment. Each quote returned will include a unique reference that allows that specific quote to be used for allocation. See allocate with quote.

### Request

| Endpoint | `POST /shipments/{reference}/quote` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Quote Result](#tab/get-quote-201)

Returned when one or more quotes have been generated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-quote-400)

Returned when the request is not valid. This includes malformed requests and requests that fail validation.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-quote-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [531 - Quote Result](#tab/get-quote-531)

Returned when the request was received successfully, but the no quotes are available. Note: 531 is not a standard HTTP status code and is used to provide simpler programmatic detection of a request for which no quotes are available.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

---

---

# Customs Documents

## Get Document

This endpoint is used to retrieve a specific document for a shipment. To retrieve all applicable customs documents, see Get Customs Documents.

> [!NOTE]
> This endpoint does not support label retrieval. See Get Labels.

### Request

| Endpoint | `GET /documents/{shipment_reference}/{document_type}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-document-200)

Returned when the document has been located and returned successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_document](includes/_document.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_document](code-samples/_cs_document.md)]
</div>
</div>

# [204 - (no body)](#tab/get-document-204)

Returned when there is no applicable document to be returned. The response body will be empty. Note: This is is not an error, it is a valid successful response for a shipment that a requested document does not apply to.

# [400 - API Error](#tab/get-document-400)

Returned when the request is not valid. This could be, for example, an invalid {document_type} route parameter.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-document-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-document-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Customs Documents

This endpoint is used to retrieve all applicable customs documents for a shipment.

> [!NOTE]
> A shipment must be successfully allocated before customs documents can be generated and returned. Additionally, customs documents do not apply to all origin and destination country combinations, so not all responses will include documents.

### Request

| Endpoint | `GET /documents/{shipment_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - List of Document](#tab/get-customs-documents-200)

Returned when the request was successful. The response includes the relevant document(s).

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [204 - (no body)](#tab/get-customs-documents-204)

Returned when there are no applicable documents to be returned. The response body will be empty. Note: This is is not an error, it is a valid successful response for a shipment that customs documents do not apply to.

# [400 - API Error](#tab/get-customs-documents-400)

Returned when the request is not valid. This could be, for example, a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-customs-documents-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-customs-documents-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Labels

## Get Labels

This endpoint is used to retrieve the labels for a `shipment`. The endpoint supports multiple formats and multiple document resolutions to enable maximum compatibility with your label printing hardware.

### Request

| Endpoint | `GET /labels/{shipment_reference}/{format}` |
|---|---|
| Parameter: `{shipment_reference}` |  The unique reference of the shipment to retrieve labels for. |
| Parameter: `{format}` |  The label file format required. <br/> **Supported Values:** `ZPL`, `ZPLII`, `PDF` |
| Query String: `?dpi={int}` |  The label resolution required. <br/> **Supported Values:** `203`, `300`, `600` | 
| Query String: `?include_extension={bool}` |  Specifies whether PRO should return custom label extensions. 
| ATU Score | 1.0 |

### Responses

# [200 - Document](#tab/get-labels-200)

Returned when the label has been located and returned successfully. This object represents a single document.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_document](includes/_document.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_document](code-samples/_cs_document.md)]
</div>
</div>

# [400 - API Error](#tab/get-labels-400)

Returned when the request is not valid. This could be, for example, an invalid route parameter. 

This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.

# [403 - API Error](#tab/get-labels-403)

Returned when your account does not have permission to use this API endpoint.

This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.

# [404 - API Error](#tab/get-labels-404)

Returned when a `shipment` with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the `shipment`, or when the `shipment` does not exist at all.

This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.

---

### More Information

For a user guide on the **Get Labels** endpoint, see the [Getting Shipment Labels](/pro/api/shipments/getting_shipment_labels.html) page of the API User Guide. 

## Get Contents Label

This endpoint is used to retrieve the labels for the shipment_contents of a shipment. The endpoint supports multiple formats and multiple document resolutions to enable maximum compatibility with your label printing hardware.

> [!NOTE]
>Sorted are in the process of migrating all carrier service labels to a new and improved label generation routine which supports advanced functionality. Not all carrier services are currently compatible with this new process, and therefore not all labels are available in all formats and resolutions. This will be identified during the on-boarding process.
>
>Supported {format} parameters are currently PDF and ZPL.
>
>The include_extension query string parameter can be used to exclude label extensions when required but will default to true if not provided.

### Request

| Endpoint | `GET /labels/{shipment_reference}/{contents_reference}/{format}(/{dpi})?include_extension=bool` |
|---|---|
| Parameters: | None |
| Query Strings: | `?include_extension={bool}` | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-contents-label-200)

Returned when the label has been located and returned successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_document](includes/_document.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_document](code-samples/_cs_document.md)]
</div>
</div>

# [400 - API Error](#tab/get-contents-label-400)

Returned when the request is not valid. This could be, for example, an invalid {format} or {dpi} route parameter.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-contents-label-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-contents-label-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Manifest

## Manifest Shipment

This endpoint is used to manually manifest an individual shipment.

> [!NOTE]
> Depending on the shipment_type and carrier service, not all shipments require a manifest operation.

### Request

| Endpoint | `PUT /shipments/{reference}/manifest` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Manifest Response](#tab/manifest-shipment-200)

Returned when the shipment has been manifested successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Manifest Response](#tab/manifest-shipment-202)

Returned when the request has been processed successfully and manifest has been queued. Manifesting will occur as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/manifest-shipment-400)

Returned when there is an error in the request.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/manifest-shipment-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/manifest-shipment-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Manifest Shipments

This endpoint is used to manually manifest multiple shipments.

> [!NOTE]
> Depending on the shipment_type and carrier service, not all shipments require a manifest operation.

### Request

| Endpoint | `PUT /shipments/manifest` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Manifest Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Manifest Response](#tab/manifest-shipments-200)

Returned when the shipment has been manifested successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Manifest Response](#tab/manifest-shipments-202)

Returned when the request has been processed successfully and manifest has been queued. Manifesting will occur as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/manifest-shipments-400)

Returned when there is an error in the request.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/manifest-shipments-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/manifest-shipments-404)

Returned when a shipment with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment, or when the shipment does not exist at all.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Manifest Shipment by Query

This endpoint allows multiple shipments to be manifest at once by using a specific query to identify candidate shipments.

### Request

| Endpoint | `POST /shipments/manifest/query` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Manifest Query Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Manifest Response](#tab/manifest-shipments-by-query-200)

Returned when the shipment(s) have been manifested successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Manifest Response](#tab/manifest-shipments-by-query-202)

Returned when the request has been processed successfully and manifest has been queued. Manifesting will occur as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/manifest-shipments-by-query-400)

Returned when there is an error in the request.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/manifest-shipments-by-query-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/manifest-shipments-by-query-404)

Returned when no matching shipments are found.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Manifest Shipments by Shipment Group

This endpoint can be used to manifest all shipments within a shipment_group as a single operation.

> [!NOTE]
> It is still possible to manifest shipments within a group via other methods, as this endpoint's implementation will only attempt to manifest shipments that are not already manifested. This endpoint is not idempotent, as multiple calls can have different results.

### Request

| Endpoint | `POST /shipment_groups/{reference}/manifest` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Manifest Response](#tab/manifest-shipments-by-shipment-group-200)

Returned when the shipment(s) have been manifested successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [202 - Manifest Response](#tab/manifest-shipments-by-shipment-group-202)

Returned when the request has been processed successfully and manifest has been queued. Manifesting will occur as soon as possible, but not immediately.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/manifest-shipments-by-shipment-group-400)

Returned when there is an error in the request.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/manifest-shipments-by-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/manifest-shipments-by-shipment-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the shipment_group reference is valid but your account does not have access to it, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Manifest

This endpoint can be used to retrieve the details of an existing manifest.

> [!NOTE]
> There are multiple methods for creating a manifest. Sorted will automatically create a new manifest item whenever shipments are manifested. A manifest will contain shipments for one carrier only – i.e. if you made a Manifest by Query request which identified shipments for multiple carriers, you will receive a response containing the details of multiple manifests – one per carrier. If shipments are manifested individually, there will be a manifest per shipment manifested.

### Request

| Endpoint | `GET /shipments/manifests/{reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Manifest](#tab/get-manifest-200)

Returned when the request was successful. The response will contain the details of the manifest.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [403 - API Error](#tab/get-manifest-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-manifest-404)

Returned when the manifest with the provided reference is not found. This can occur when the manifest reference is valid but your account does not have access to it, or when the manifest does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Shipment Groups

## Create Shipment Group

A shipment_group is a group of one or more shipments that can be operated on together. For example, if a driver is due to come and collect a group of shipments together, you can create a shipment_group for the shipments and then produce a collection_note and manage the state of all the shipments within the group together.

> [!NOTE]
> Due to the nature of a shipment_group, you can only add shipments that are in a state of allocated or booked to a single shipment_group. All shipments within a group should be allocated with the same carrier service and should have the same origin address.

### Request

| Endpoint | `POST /shipment_groups` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Create Shipment Group Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [201 - Resource Result](#tab/create-shipment-group-201)

Returned when the request was successful. The shipment_group has been created successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [207 - Resource Result](#tab/create-shipment-group-207)

The shipment_group was successfully created, but one or more shipments could not be added to the group. For example, one or more shipments are not in a valid state to be added to the shipment_group. Check the errors property for more details.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/create-shipment-group-400)

Returned when the request is badly-formed or there is a validation error. This can also be returned when not all shipments have the same origin address or shipping_location_reference.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/create-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Shipment Group

A shipment_group is a group of one or more shipments that can be operated on together. For example, if a driver is due to come and collect a group of shipments together, you can create a shipment_group for the shipments and then produce a collection_note and manage the state of all the shipments within the group together. This endpoint allows you to retrieve the details of an existing shipment_group.

### Request

| Endpoint | `GET /shipment_groups/{reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment Group](#tab/get-shipment-group-200)

Returned when the request was successful. The shipment_group will be included in the response.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [403 - API Error](#tab/get-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-shipment-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the shipment_group reference is valid but your account does not have access to it, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Shipment Groups by Custom Reference

This endpoint allows a customer to retrieve a list of all shipment_group objects that have the provided custom_reference. Each shipment_group will have a unique reference which can then be used to retrieve the shipment_group. Alternatively, each shipment_group will have a unique version which can be used to retrieve that shipment_group using its custom_reference and version.

### Request

| Endpoint | `GET /shipment_groups/custom_reference/{custom_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - List of Shipment Group Summary](#tab/get-shipment-groups-by-custom-reference-200)

Returned when the request was successful. Summary details will be included in the response.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [403 - API Error](#tab/get-shipment-groups-by-custom-reference-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-shipment-groups-by-custom-reference-404)

Returned when the shipment_group with the provided custom_reference is not found. This can occur when the custom_reference is valid but your account does not have access to it, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Shipment Group by Custom Reference

This endpoint complements the previous endpoint by allowing users to retrieve a specific version of the shipment_group corresponding to their custom_reference.

### Request

| Endpoint | `GET /shipment_groups/custom_reference/{custom_reference}/{version}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment Group](#tab/get-shipment-group-by-custom-reference-200)

Returned when the request was successful. The shipment_group details will be included in the response.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [403 - API Error](#tab/get-shipment-group-by-custom-reference-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-shipment-group-by-custom-reference-404)

Returned when the shipment_group with the provided custom_reference or version is not found. This can occur when the custom_reference or version is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Update Shipment Group

This endpoint is used to update an existing shipment_group such as adding or removing shipments.

### Request

| Endpoint | `PUT /shipment_groups/` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Update Shipment Group Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Resource Result](#tab/update-shipment-group-200)

Returned when the request was successful. The shipment_group has been updated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/update-shipment-group-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/update-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/update-shipment-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/update-shipment-group-409)

There is a conflict that prevents the shipment_group from being updated e.g. it is locked or it has already been closed.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Add Shipment to Group

This endpoint provides the simplest possible method of adding a single shipment to an existing shipment_group.

> [!NOTE]
> If the group referenced by this endpoint does not exist, it will not be created. Instead, an API error will be returned. This is by design and is to prevent customers from accidentally creating new groups when attempting to add a shipment to an existing group.

### Request

| Endpoints | `PUT /shipment_groups/{reference}/shipments/{shipment_ref}`<br/>`PUT /shipment_groups/custom_reference/{custom_ref}/{version}/shipments/{shipment_ref}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/add-shipment-to-group-200)

Returned when the request was successful. The shipment_group has been updated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/add-shipment-to-group-304)

Returned when the shipment already exists in the shipment_group.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/add-shipment-to-group-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/add-shipment-to-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/add-shipment-to-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/add-shipment-to-group-409)

There is a conflict that prevents the shipment_group from being updated e.g. it is locked or it has already been closed.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Remove Shipment from Group

This endpoint provides the simplest possible method of removing a single shipment from an existing shipment_group.

### Request

| Endpoints | `DELETE /shipment_groups/{reference}/shipments/{shipment_ref}`<br/>`DELETE /shipment_groups/custom_reference/{custom_ref}/{version}/shipments/{shipment_ref}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/remove-shipment-from-group-200)

Returned when the request was successful. The shipment_group has been updated successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/remove-shipment-from-group-304)

Returned when the shipment is not a member of the shipment_group.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/remove-shipment-from-group-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/remove-shipment-from-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/remove-shipment-from-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/remove-shipment-from-group-409)

There is a conflict that prevents the shipment_group from being updated e.g. it is locked or it has already been closed.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Lock Shipment Group

This endpoint is used to lock a shipment_group to prevent any further changes being made to it. A shipment_group has to be locked before a collection_note can be retrieved.

### Request

| Endpoint | `POST /shipment_groups/{reference}/lock` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/lock-shipment-group-200)

Returned when the request was successful. The shipment_group has been locked successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/lock-shipment-group-304)

Returned when the shipment_group is already locked.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/lock-shipment-group-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/lock-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/lock-shipment-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/lock-shipment-group-409)

There is a conflict that prevents the shipment_group from being updated e.g. it has already been closed.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Unlock Shipment Group

This endpoint is used to remove a lock from a shipment_group to allow further changes to be made to it. A shipment_group has to be locked before a collection_note can be retrieved.

### Request

| Endpoint | `POST /shipment_groups/{reference}/unlock` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/unlock-shipment-group-200)

Returned when the request was successful. The shipment_group lock has been removed successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/unlock-shipment-group-304)

Returned when the shipment_group is not already locked.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/unlock-shipment-group-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/unlock-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/unlock-shipment-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/unlock-shipment-group-409)

There is a conflict that prevents the shipment_group from being updated e.g. it has already been closed.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Close Shipment Group

This endpoint is used when all shipments within a shipment_group have been manifested or cancelled and the group is no longer required. The group will not be deleted but will be retained in a closed state. You may still retrieve the details of the group via the API for a period of time but will no longer be able to otherwise operate on the group.

> [!NOTE]
> This operation is not reversible. Once a shipment_group has been closed it cannot be re-opened.

### Request

| Endpoint | `POST /shipment_groups/{reference}/close` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/close-shipment-group-200)

Returned when the request was successful. The shipment_group has been closed successfully.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [304 - Resource Result](#tab/close-shipment-group-304)

Returned when the shipment_group is already closed.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_resource_result](includes/_resource_result.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_resource_result](code-samples/_cs_resource_result.md)]
</div>
</div>

# [400 - API Error](#tab/close-shipment-group-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/close-shipment-group-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/close-shipment-group-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [409 - API Error](#tab/close-shipment-group-409)

There is a conflict that prevents the shipment_group from being closed e.g. it has not yet been locked.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Collection Notes

## Get Shipment Group Collection Note

This endpoint can be used to retrieve an auto-generated collection_note for a shipment_group. This can also be referred to as a "Driver's Manifest".

> [!NOTE]
> Retrieving a collection_note is a repeatable operation and does not change any data relating to the shipment_group. Once a collection_note has been retrieved, it can be retrieved multiple times by calling the same API endpoint again. If further shipments are added to the group, retrieving the collection_note will include the additional shipments.

### Request

| Endpoint | `GET /collection_notes/shipment_group/{reference}` <br/> `GET /collection_notes/shipment_group/custom_reference/{reference}/{version}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-shipment-group-collection-note-200)

Returned when the request was successful. The collection_note will be included in the response.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_document](includes/_document.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_document](code-samples/_cs_document.md)]
</div>
</div>

# [400 - API Error](#tab/get-shipment-group-collection-note-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-shipment-group-collection-note-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-shipment-group-collection-note-404)

Returned when the shipment_group with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the shipment_group, or when the shipment_group does not exist.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Collection Note by Query

This endpoint can be used to retrieve an auto-generated collection_note for shipments identified by the query. This can also be referred to as a "Driver's Manifest".

> [!NOTE]
> Retrieving a collection_note is a repeatable operation and does not change any data relating to the shipments. Once a collection_note has been retrieved, it can be retrieved multiple times by calling the same API endpoint again.

### Request

| Endpoint | `POST /collection_notes/query` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Collection Note Query Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Document](#tab/get-collection-note-by-query-200)

Returned when the request was successful. The collection_note will be included in the response.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_document](includes/_document.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_document](code-samples/_cs_document.md)]
</div>
</div>

# [400 - API Error](#tab/get-collection-note-by-query-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-collection-note-by-query-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-collection-note-by-query-404)

Returned when the query does not identify any shipments.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Collection Note by Manifests

This endpoint can be used to retrieve an auto-generated collection_note for shipments belonging to one or more manifest(s). This can also be referred to as a "Driver's Manifest".

> [!NOTE]
> This method for retrieving a collection_note is not idempotent, as the relevant shipments can change between requests.

### Request

| Endpoint | `POST /collection_notes/manifest` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | Collection Note from Manifest Request | 
| ATU Score | 1.0 |

### Request Body

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

### Response

# [200 - Document](#tab/get-collection-note-by-manifests-200)

Returned when the request was successful. The collection_note will be included in the response.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_document](includes/_document.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_document](code-samples/_cs_document.md)]
</div>
</div>

# [400 - API Error](#tab/get-collection-note-by-manifests-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-collection-note-by-manifests-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-collection-note-by-manifests-404)

Returned when the query does not identify any shipments or when the referenced manifest does not exist or cannot be found.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

---

# Tracking

## Get Tracking Events

This endpoint can be used to retrieve tracking events for a shipment.

> [!TIP]
> More advanced tracking functionality is available in SortedREACT. SortedPRO returns standardised basic tracking data only.

### Request

| Endpoint | `GET /tracking/{shipment_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 2.0 |

### Response

# [200 - Tracking Response](#tab/get-tracking-events-200)

Returned when the request was successful. The tracking_response will include the tracking events available for the shipment.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-tracking-events-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-tracking-events-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-tracking-events-404)

Returned when the query does not identify a valid existing shipment.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Contents-Level Tracking Events

This endpoint can be used to retrieve tracking events for the contents of a shipment. Some carriers will provide tracking at "package level" which means that for every package (contents) within a shipment Sorted will receive separate tracking events. This endpoint allows you to retrieve events in this form.

> [!TIP]
> More advanced tracking functionality is available in SortedREACT. SortedPRO returns standardised basic tracking data only.

### Request

| Endpoint | `GET /tracking/{shipment_reference}/shipment_contents` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| Body: | None | 
| ATU Score | 2.0 |

### Response

# [200 - Tracking Contents Response](#tab/get-contents-level-tracking-events-200)

Returned when the request was successful. The tracking_contents_response will include the tracking events available for the shipment by shipment_contents.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-contents-level-tracking-events-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-contents-level-tracking-events-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-contents-level-tracking-events-404)

Returned when the query does not identify a valid existing shipment.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Tracking Events by Custom Reference

This endpoint can be used to retrieve tracking events for multiple shipments that have a specific custom_reference.

> [!TIP]
> When creating shipments it is possible to supply a custom_reference value. This can be, for example, a customer's own reference for an order. The custom_reference does not need to be unique.
>
> More advanced tracking functionality is available in SortedREACT. SortedPRO returns standardised basic tracking data only.

### Request

| Endpoint | `GET /tracking/custom_reference/{shipment_reference}` |
|---|---|
| Parameters: | None |
| Query Strings: | `take={int}`<br/>`skip={int}` | 
| Body: | None | 
| ATU Score | 3.0 |

### Response

# [200 - Tracking Response List](#tab/get-tracking-events-by-custom-reference-200)

Returned when the request was successful. The tracking_response_list will include the tracking events available for the matching shipment(s).

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-tracking-events-by-custom-reference-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-tracking-events-by-custom-reference-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-tracking-events-by-custom-reference-404)

Returned when the query does not identify any valid existing shipments.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

## Get Contents-Level Tracking Events by Custom Reference

This endpoint can be used to retrieve tracking events for the contents of a shipment using the customer's own custom_reference. Some carriers will provide tracking at "package level" which means that for every package (contents) within a shipment Sorted will receive separate tracking events. This endpoint allows you to retrieve events in this form.

> [!TIP]
> The custom_reference in this endpoint refers to the custom_reference provided for the shipment_contents.

### Request

| Endpoint | `GET /tracking/custom_reference/{custom_reference}/shipment_contents` |
|---|---|
| Parameters: | None |
| Query Strings: | `take={int}`<br/>`skip={int}` | 
| Body: | None | 
| ATU Score | 3.0 |

### Response

# [200 - Tracking Contents Response List](#tab/get-contents-level-tracking-events-by-custom-reference-200)

Returned when the request was successful. The tracking_contents_response_list will include the tracking events available for the shipment(s) by shipment_contents.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_template](includes/_template.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_cs_template](code-samples/_cs_template.md)]
</div>
</div>

# [400 - API Error](#tab/get-contents-level-tracking-events-by-custom-reference-400)

Returned when the request is badly-formed or there is a validation error.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [403 - API Error](#tab/get-contents-level-tracking-events-by-custom-reference-403)

Returned when your account does not have permission to use this API endpoint.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

# [404 - API Error](#tab/get-contents-level-tracking-events-by-custom-reference-404)

Returned when the query does not identify any valid existing shipment_contents.

<div class="dc-row">
    <div class="dc-column">
            <h4>Properties</h4>

[!include[_api_error](includes/_api_error.md)]
</div>
    <div class="dc-column">
            <h4>Example</h4>

[!include[_api_error](code-samples/_cs_api_error.md)]
</div>
</div>

---

<script src="/pro/scripts/dropdown.js"></script>