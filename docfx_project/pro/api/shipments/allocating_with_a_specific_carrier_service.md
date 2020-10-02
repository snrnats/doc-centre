---
uid: pro-api-help-shipments-allocating-with-a-specific-carrier-service
title: Allocating with a Specific Carrier Service
tags: shipments,pro,api,allocation,carrier service
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---

# Allocating with a Specific Carrier Service

Want to specify the carrier service that should take your shipment? This page explains how to allocate shipments to services manually.

---

## Getting the Carrier Service Reference

In order to allocate a shipment to a specific carrier service, you'll need to know that service's `{carrier_service_reference}`. The `{carrier_service_reference}` is a unique identifier for each service available in PRO.

<span class="highlight">Where can the customer go to get this information? The Consignments UI had a menu - is there something similar for shipments?</span>

## Allocating A Single Shipment with a Specific Carrier Service

The **Allocate Shipment with Carrier Service** endpoint enables you to allocate a shipment to a specific carrier service. To call **Allocate Shipment with Carrier Service**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/allocate/service/{service_ref}`, where `{reference}`refers to the shipment you want to allocate and `{service_ref}` is the reference of the carrier service that you want to allocate to.

PRO then attempts to allocate the specified shipment to the specified carrier service and returns an Allocate Result. 

> [!NOTE]
> **Allocate Shipment with Carrier Service** does not override existing allocation rules. If the carrier service you selected does not meet your existing allocation rules, then PRO returns an error.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

### Allocate Shipment with Carrier Service Example

The example shows a successful request to allocate shipment _sp_10014418679662051328777876543332_ to a carrier service with the `{carrier_service_reference}` _DNQWW72_.

# [Allocate Shipment with Carrier Service Request](#tab/allocate-shipment-with-carrier-service-request)

`PUT https://api.sorted.com/pro/shipments/sp_10014418679662051328777876543332/allocate/service/DNQWW72`

# [Allocate Shipment with Carrier Service Response](#tab/allocate-shipment-with-carrier-service-response)

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
    "shipment_reference": "sp_10014418679662051328777876543332",
    "tracking_details": {
        "shipment": {
            "reference": "sp_10014418679662051328777876543332",
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
            "href": "https://api.sorted.com/pro/labels/sp_10014418679662051328777876543332/pdf",
            "rel": "PDF",
            "reference": null,
            "type": "Label"
        },
        {
            "href": "https://api.sorted.com/pro/labels/sp_10014418679662051328777876543332/zpl",
            "rel": "ZPL",
            "reference": null,
            "type": "Label"
        },
        {
            "href": "https://api.sorted.com/pro/shipments/sp_10014418679662051328777876543332",
            "rel": "Shipment",
            "reference": "sp_10014418679662051328777876543332",
            "type": "Shipment"
        }
    ]
}
```
---

> [!NOTE]
>  For full reference information on the **Allocate Shipment with Carrier Service** endpoint, see the Shipments data contract

## Allocating Multiple Shipments with a Specific Carrier Service

The **Allocate With Carrier Service** endpoint enables you to queue one or more shipments for allocation to a specific carrier service. To call **Allocate With Carrier Service**, send a `PUT` request to `https://api.sorted.com/pro/shipments/allocate/service`. The body of the request should contain a list of the `{shipments}` that you want to allocate and the `{carrier_service_reference}` of the carrier service you want to allocate to. 

Optionally, you can also include a list of service `capabilities`. Where capabilities are provided, then PRO only allocated the shipment to a carrier service that meets those capabilities. Each capability should list the `type` of service capability specified and the `value` that that capability should have.

> [!NOTE]
> For information on available service capabilities and values, see the Shipments data contract

PRO takes each shipment in turn and checks whether the specified service is eligible to take that shipment. It then returns an Allocate Shipments result detailing the results of the request.

> [!NOTE]
> **Allocate with Carrier Service** does not override existing allocation rules. If the carrier service you selected does not meet your existing allocation rules, then PRO returns an error.

[!include[_shipments_allocate_shipments_result](../includes/_shipments_allocate_shipments_result.md)]

### Allocate with Carrier Service Example

The example shows a request to queue four shipments for allocation to a carrier service with the `{carrier_service_reference}` _service123_. Three shipments have been successfully queued, but one was rejected because its `{reference}` could not be found.

# [Allocate with Carrier Service Request](#tab/allocate-with-carrier-service-request)

`PUT https://api.sorted.com/pro/shipments/allocate/service`

```json
{
    "shipments": [
        "sp_10014418679662051328777876543332",
        "sp_10014418692546953216762537656534",
        "sp_10014418701136887808123998889990",
        "sp_10014418709726822400876827639994"
    ],
    "carrier_service_reference": "service123"
}
```
# [Allocate With Carrier Service Response](#tab/allocate-with-carrier-service-response)

```json
{
  "message": "3 shipment(s) queued for allocation successfully. 1 shipment(s) rejected for allocation.",
  "queued": [
    "sp_10014418679662051328777876543332",
    "sp_10014418692546953216762537656534",
    "sp_10014418701136887808123998889990"
  ],
  "rejected": [
    {
      "code": "shipment_not_found",
      "message": "The shipment cannot be found",
      "references": [
        "sp_10014418709726822400876827639994"
      ]
    }
  ],
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/sp_10014418709726822400876827639994",
      "rel": "shipment",
      "reference": "sp_10014418709726822400876827639994",
      "type": "rejected"
    }
  ]
}
```
---

> [!NOTE]
>  For full reference information on the **Allocate With Carrier Service** endpoint, see the Shipments data contract

## Next Steps

* Learn about alternative methods of allocating shipments at the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/shipments/getting_shipment_labels.html) page.
* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.