---
uid: pro-api-shipments-dc
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

# [200 OK](#tab/get-labels-200)

<div class="row">
<div class="column">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `file` | `string` | The contents of the file encoded in base64 | `1` |
| `content_type` | `string`| The format of the `document`, e.g. `application/pdf`. See [`content_type`](#content-type). | `1` |
| `document_type` | `string` | The type of `document`. See [`document_type`](#document-type). | `1` |
| `dpi` | `integer` | The DPI of the `document`. | `1` |

</div>
<div class="column">

```json
{
    "file": "ICAgICAgICAgICAgICAgXkZPMTAwLDEwMTBeRkRGMDBCNDdeRlMNCiAgICAgICAgICAgICAgICBeRk8xMDAsMTA2MF5GREJMNEg4XkZTDQogICAgICAgICAgICAgICAgXkNGMCwxOTANCiAgICAgICAgICAgICAgICBeRk80ODUsOTY1XkZEQ0FeRlMNCg0KICAgICAgICAgICAgICAgIF5YWg==",
    "content_type": "text/plain",
    "document_type": "label",
    "dpi": 203
} 
```
</div>
</div>

# [404 Not Found](#tab/get-labels-404)

<div class="row">
<div class="column">
Left
</div>
<div class="column">

```json
{
    "correlation_id": "6c4e6a77-feab-42ab-9d7b-f559dc1b90ca",
    "code": "validation_error",
    "message": "A provided property has an invalid format",
    "details": [
        {
            "property": "addresses[0].contact.contact_details.email",
            "code": "invalid_format",
            "message": "'test@something' is not a valid email address"
        }
    ],
    "_links": null
}

```
</div>
</div>

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

### Request

### Response

## Get Collection Note by Query

### Request

### Response

## Get Collection Note by Manifests

### Request

### Response

---

# Tracking

Tracking

---

# Data Contract

Data Contract