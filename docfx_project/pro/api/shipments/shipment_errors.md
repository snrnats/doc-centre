---
uid: pro-api-shipments-shipment-errors
title: Shipment Error Codes
tags: pro,api,shipments,errors
contributors: andy.walton@sorted.com
created: 07/10/2020
---
# Shipments Error Codes

Errors in SortedPRO can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing. This section provides an explanation of the PRO API error object and a reference list of the errors that PRO can return.

---

## Error Structure in PRO

Errors codes in PRO have two levels - a top-level code corresponding to standard HTTP error codes and a "child" code giving more detail on the specifics of the problem.

> [!NOTE]
> For a detailed breakdown of the error codes that PRO can return, see the [List of Error Codes](#list-of-error-codes) section.

When an API request encounters an error, PRO returns an API Error object. The API Error object contains the following information:

* `correlation_id` - A unique reference for the error.
* `code` - The top-level error code.
* `message ` - A plain-text message explaining the top-level error code returned. 
* `details` - An object indicating the affected shipment `property` (where applicable), child error `code`, and an explanatory `message`.
* `links` - Links to relevant resources.

> [!NOTE]
> The explanatory `message` properties should not be considered part of PRO's data contract and no logic should be programmed against them, as they are subject to change at any time.

### Example API Error Object

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

## List of Error Codes

PRO can return the following top-level error codes:

* [521 - Allocation Failed](/pro/api/shipments/error_521.html)