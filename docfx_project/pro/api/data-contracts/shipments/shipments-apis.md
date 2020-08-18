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

Shipments

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

| Endpoint | `/labels/{shipment_reference}/{format}` |
|---|---|
| Parameter: `{shipment_reference}` |  The unique reference of the shipment to retrieve labels for. |
| Parameter: `{format}` |  The label file format required. <br/> **Supported Values:** `ZPL`, `ZPLII`, `PDF` |
| Query String: `?dpi={int}` |  The label resolution required. <br/> **Supported Values:** `203`, `300`, `600` | 
| Query String: `?include_extension={bool}` |  Specifies whether PRO should return custom label extensions. 
| ATU Score | 1.0 |

### Responses

# [200 - Document](#tab/get-labels-200)

Returned when the label has been located and returned successfully.

[!include[_document](includes/_document.md)]

# [400 - API Error](#tab/get-labels-400)

Returned when the request is not valid. This could be, for example, an invalid route parameter.

[!include[_api_error](includes/_api_error.md)]

# [403 - API Error](#tab/get-labels-403)

Returned when your account does not have permission to use this API endpoint.

[!include[_api_error](includes/_api_error.md)]

# [404 - API Error](#tab/get-labels-404)

Returned when a `shipment` with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the `shipment`, or when the `shipment` does not exist at all.

[!include[_api_error](includes/_api_error.md)]

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