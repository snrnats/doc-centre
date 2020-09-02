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

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/update-shipment-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/cancel-shipment-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/delete-shipment-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Resource Result](#tab/clone-shipment-201)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/change-shipment-state-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment](#tab/get-shipment-200)

# [403 - API Error](#tab/get-shipment-403)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment List](#tab/get-shipments-by-custom-reference-or-tracking-reference-200)

# [400 - API Error](#tab/get-shipments-by-custom-reference-or-tracking-reference-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Paperless Document](#tab/get-paperless-document-200)
# [400 - API Error](#tab/get-paperless-document-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Paperless Document](#tab/add-paperless-document-201)
# [400 - API Error](#tab/add-paperless-document-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Paperless Document](#tab/remove-paperless-document-200)
# [400 - API Error](#tab/remove-paperless-document-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-200)
# [202 - Allocate Result](#tab/allocate-shipment-202)
# [400 - API Error](#tab/allocate-shipment-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [202 - Allocate Shipments Result](#tab/allocate-shipments-202)
# [207 - Allocate Shipments Result](#tab/allocate-shipments-207)
# [400 - API Error](#tab/allocate-shipments-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-carrier-service-200)
# [202 - Allocate Result](#tab/allocate-shipment-with-carrier-service-202)
# [400 - API Error](#tab/allocate-shipment-with-carrier-service-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [202 - Allocate Shipments Result](#tab/allocate-with-carrier-service-202)
# [207 - Allocate Shipments Result](#tab/allocate-with-carrier-service-207)
# [400 - API Error](#tab/allocate-with-carrier-service-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-service-group-200)
# [202 - Allocate Result](#tab/allocate-shipment-with-service-group-202)
# [400 - API Error](#tab/allocate-shipment-with-service-group-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [202 - Allocate Shipments Result](#tab/allocate-with-service-group-202)
# [207 - Allocate Shipments Result](#tab/allocate-with-service-group-207)
# [400 - API Error](#tab/allocate-with-service-group-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [202 - Allocate with Filters Result](#tab/allocate-with-filters-202)
# [207 - Allocate with Filters Result](#tab/allocate-with-filters-207)
# [400 - API Error](#tab/allocate-with-filters-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-quote-200)
# [202 - Allocate Result](#tab/allocate-shipment-with-quote-202)
# [400 - API Error](#tab/allocate-shipment-with-quote-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Allocate Result](#tab/allocate-shipment-with-virtual-service-200)
# [202 - Allocate Result](#tab/allocate-shipment-with-virtual-service-202)
# [400 - API Error](#tab/allocate-shipment-with-virtual-service-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Quote Result](#tab/create-quote-201)
# [400 - API Error](#tab/create-quote-400)

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

---

## Create Quote by Service Group

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Quote Result](#tab/create-quote-by-service-group-201)
# [400 - API Error](#tab/create-quote-by-service-group-400)

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

---

## Get Quote

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Quote Result](#tab/get-quote-201)
# [400 - API Error](#tab/get-quote-400)

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

---

---

# Customs Documents

## Get Document

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-document-200)

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
# [400 - API Error](#tab/get-document-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - List of Document](#tab/get-customs-documents-200)
# [204 - (no body)](#tab/get-customs-documents-204)
# [400 - API Error](#tab/get-customs-documents-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-contents-label-200)

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

### Request

### Response

# [200 - Manifest Response](#tab/manifest-shipment-200)
# [202 - Manifest Response](#tab/manifest-shipment-202)
# [400 - API Error](#tab/manifest-shipment-400)

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

### Request

### Response

# [200 - Manifest Response](#tab/manifest-shipments-200)
# [202 - Manifest Response](#tab/manifest-shipments-202)
# [400 - API Error](#tab/manifest-shipments-400)

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

### Request

### Response

# [200 - Manifest Response](#tab/manifest-shipments-by-query-200)
# [202 - Manifest Response](#tab/manifest-shipments-by-query-202)
# [400 - API Error](#tab/manifest-shipments-by-query-400)

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

### Request

### Response

# [200 - Manifest Response](#tab/manifest-shipments-by-shipment-group-200)
# [202 - Manifest Response](#tab/manifest-shipments-by-shipment-group-202)
# [400 - API Error](#tab/manifest-shipments-by-shipment-group-400)

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

### Request

### Response

# [200 - Manifest](#tab/get-manifest-200)
# [403 - API Error](#tab/get-manifest-403)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [201 - Resource Result](#tab/create-shipment-group-201)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment Group](#tab/get-shipment-group-200)
# [403 - API Error](#tab/get-shipment-group-403)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - List of Shipment Group Summary](#tab/get-shipment-groups-by-custom-reference-200)
# [403 - API Error](#tab/get-shipment-groups-by-custom-reference-403)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Shipment Group](#tab/get-shipment-group-by-custom-reference-200)
# [403 - API Error](#tab/get-shipment-group-by-custom-reference-403)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/update-shipment-group-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/add-shipment-to-group-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/remove-shipment-from-group-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/lock-shipment-group-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/unlock-shipment-group-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Resource Result](#tab/close-shipment-group-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-shipment-group-collection-note-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-collection-note-by-query-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Document](#tab/get-collection-note-by-manifests-200)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Tracking Response](#tab/get-tracking-events-200)
# [400 - API Error](#tab/get-tracking-events-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Tracking Contents Response](#tab/get-contents-level-tracking-events-200)
# [400 - API Error](#tab/get-contents-level-tracking-events-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Tracking Response List](#tab/get-tracking-events-by-custom-reference-200)
# [400 - API Error](#tab/get-tracking-events-by-custom-reference-400)

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

### Request

| Endpoint | `POST /shipments` |
|---|---|
| Parameters: | None |
| Query Strings: | None | 
| ATU Score | 1.0 |

### Response

# [200 - Tracking Contents Response List](#tab/get-contents-level-tracking-events-by-custom-reference-200)
# [400 - API Error](#tab/get-contents-level-tracking-events-by-custom-reference-400)

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