---
uid: pro-api-help-shipments-allocating-to-default-rules
title: Allocating to Default Rules
tags: shipments,pro,api,allocation,rules
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Allocating to Default Rules

To page explains how to use the **Allocate Shipment**  and **Allocate Shipments** endpoints to allocate shipments based on your pre-defined allocation rules.

---

## Overview

The **Allocate Shipment** and **Allocate Shipments** endpoints enable you to allocate shipments to the cheapest eligible carrier service. PRO selects a service for you when you use these endpoints, rather than requiring you to select a service or service group manually. **Allocate Shipment** allocates a single shipment, while **Allocate Shipments** enables you to queue multiple shipments for allocation at once.

## Allocating a Single Shipment

The **Allocate Shipment** endpoint allocates a single shipment using the PRO allocation engine. To call **Allocate Shipment**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/allocate`, where `{reference}` refers to the shipment you want to allocate.

Once the request has been received, PRO uses the process detailed in the [Overview](#overview) to determine the appropriate service and allocate the shipment. It then returns an Allocate Result object. 

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

### Allocate Shipment Example

The example shows a successful request to allocate a shipment with a `{reference}` of _sp_9233500258180005889777767900009_ via the **Allocate Shipment** endpoint. 

# [Allocate Shipment Request](#tab/allocate-shipment-request)

```json
PUT https://api.sorted.com/pro/shipments/sp_9233500258180005889777767900009/allocate
```

# [Allocate Shipment Response](#tab/allocate-shipment-response)

```json
{
    "state": "Allocated",
    "price": {
        "net": 10.0,
        "gross": 12.0,
        "taxes": [
            {
                "rate": {
                    "reference": "gb_standard",
                    "country_iso_code": "GB",
                    "type": "standard",
                    "value": 0.2
                },
                "amount": 2.0
            }
        ],
        "currency": "GBP"
    },
    "message": "Shipment allocated successfully",
    "carrier": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
    },
    "shipment_reference": "sp_9233500258180005889777767900009",
    "tracking_details": {
        "shipment": {
            "reference": "sp_9233500258180005889777767900009",
            "tracking_references": [
                "DNK23098098"
            ],
            "_links": []
        },
        "contents": [
            {
                "reference": "sc_9233500258180006765777878909811",
                "tracking_references": [
                    "DNK23098099"
                ],
                "_links": []
            }
        ]
    },
    "_links": [
        {
            "href": "https://api.sorted.com/pro/labels/sp_9233500258180005889777767900009/pdf",
            "rel": "PDF",
            "reference": null,
            "type": "Label"
        },
        {
            "href": "https://api.sorted.com/pro/labels/sp_9233500258180005889777767900009/zpl",
            "rel": "ZPL",
            "reference": null,
            "type": "Label"
        },
        {
            "href": "https://api.sorted.com/pro/shipments/sp_9233500258180005889777767900009",
            "rel": "Shipment",
            "reference": "sp_9233500258180005889777767900009",
            "type": "Shipment"
        }
    ]
}
```
---

> [!NOTE]
>
>  For full reference information on the **Allocate Shipment** endpoint, see the [Shipments data contract](/pro/api/reference/shipments-api-ref.html#tag/Allocation/paths/~1shipments~1{shipmentReference}~1allocate/put). 

## Allocating Multiple Shipments At Once

The **Allocate Shipments** endpoint enables you to queue multiple shipments for to the cheapest eligible carrier service in one request. 

To call **Allocate Shipments**, send a `PUT` request to `https://api.sorted.com/pro/shipments/allocate`. The request body should contain an array of one or more shipment `{reference}`s to be allocated. 

Optionally, you can also include a list of service `capabilities`. Where capabilities are provided, then PRO only allocated the shipment to a carrier service that meets those capabilities. Each capability should list the `type` of service capability specified and the `value` that that capability should have.

> [!NOTE]
> For information on available service capabilities and values, see the [Shipments data contract](/pro/api/reference/shipments-api-ref.html#tag/Allocation/paths/~1shipments~1allocation/put)

Once the request is received, PRO takes each shipment in turn and attempts to queue it for allocation to the cheapest eligible carrier, as per the process detailed in the [Overview](#overview). It then returns an Allocate Shipments result. 

[!include[_shipments_allocate_shipments_result](../includes/_shipments_allocate_shipments_result.md)]

### Allocate Shipments Example

The example shows a request to queue three shipments for allocation. Two shipments have been successfully queued, but one was rejected because its `{reference}` could not be found.

# [Allocate Shipments Request](#tab/allocate-shipments-request)

`PUT https://api.sorted.com/pro/shipments/allocate`

```json
    "shipments": [
        "sp_10014418679662051328667654221112",
        "sp_10014418692546953216098308745978",
        "sp_10014418709726822400232323009988"
    ]
```

# [Allocate Shipments Response](#tab/allocate-shipments-response)

```json
{
  "message": "2 shipment(s) queued for allocation successfully. 1 shipment(s) rejected for allocation.",
  "queued": [
    "sp_10014418679662051328667654221112",
    "sp_10014418692546953216098308745978"
  ],
  "rejected": [
    {
      "code": "shipment_not_found",
      "message": "The shipment cannot be found",
      "references": [
        "sp_10014418709726822400232323009988"
      ]
    }
  ],
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/sp_10014418709726822400232323009988",
      "rel": "shipment",
      "reference": "sp_10014418709726822400232323009988",
      "type": "rejected"
    }
  ]
}
```
---

> [!NOTE]
>
>  For full reference information on the **Allocate Shipments** endpoint, see the [Shipments data contract](/pro/api/reference/shipments-api-ref.html#tag/Allocation/paths/~1shipments~1allocation/put). 

## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to manifest shipments: [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html)
* Learn how to create shipment groups: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)