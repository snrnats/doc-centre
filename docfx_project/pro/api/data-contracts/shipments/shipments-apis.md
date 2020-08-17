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

| Endpoint | `/labels/{shipment_reference}/{format}(/{dpi})` |
|---|---|
| Parameters | `{format}` - words words words words words words words words words words words words <br /> `{dpi}` - words words words words words words words words words words words words |
| Query Strings | None |
| ATU Score | 1.0 |

### Responses

# [200](#tab/get-labels-200)

#### Document

Returned when the label has been located and returned successfully.

[!include[_document](includes/_document.md)]

# [400](#tab/get-labels-400)

`api_error` - Returned when the request is not valid. This could be, for example, an invalid `{format}` or `{dpi}` route parameter.

[!include[_api_error](includes/_api_error.md)]

# [403](#tab/get-labels-403)

`api_error` - Returned when your account does not have permission to use this API endpoint.

[!include[_api_error](includes/_api_error.md)]

# [404](#tab/get-labels-404)

`api_error` - Returned when a `shipment` with the provided reference is not found. This can occur when the reference is valid but your account does not have access to the `shipment`, or when the `shipment` does not exist at all.

[!include[_api_error](includes/_api_error.md)]

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