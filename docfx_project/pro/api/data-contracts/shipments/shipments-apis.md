---
uid: pro-api-data-contracts-shipments-shipments-apis
title: Shipments API Reference
tags: shipments,pro,api,reference,data-contract
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 12/08/2020
---
# Shipments API Reference

---

# Shipments

## Get Shipments

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

### More Information

---

# Paperless Documents

Paperless

---

# Allocation

Allocation

---

# Quotes

Quotes

---

# Customs Documents

Customs Documents

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

Labels

---

# Manifest

Manifest

---

# Shipment Groups

Shipment Groups

---

# Collection Notes

## Get Shipment Group Collection Note

## Get Collection Note by Query

## Get Collection Note by Manifests

---

# Tracking

Tracking

<script src="/pro/scripts/dropdown.js"></script>