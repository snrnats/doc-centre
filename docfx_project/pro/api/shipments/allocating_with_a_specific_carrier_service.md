---
uid: pro-api-help-shipments-allocating-with-a-specific-carrier-service
title: Allocating with a Specific Carrier Service
tags: shipments,pro,api,allocation,carrier service
contributors: andy.walton@sorted.com
created: 07/10/2020
---

# Allocating with a Specific Carrier Service

Want to specify the carrier service that should take your shipment? This page explains how to allocate shipments to services manually.

---

## Getting the Carrier Service Reference

In order to allocate a shipment to a specific carrier service, you'll need to know that service's `{carrier_service_reference}`. The `{carrier_service_reference}` is a unique identifier for each service available in PRO.

## Allocating A Single Shipment with a Specific Carrier Service

The **Allocate Shipment with Carrier Service** endpoint enables you to allocate a shipment to a specific carrier service. To call **Allocate Shipment with Carrier Service**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/allocate/service/{service_ref}`, where `{reference}`refers to the shipment you want to allocate and `{service_ref}` is the reference of the carrier service that you want to allocate to.

PRO then attempts to allocate the specified shipment to the specified carrier service and returns an Allocate Result. 

> [!NOTE]
> **Allocate Shipment with Carrier Service** does not override existing allocation rules. If the carrier service you selected does not meet your existing allocation rules, then PRO returns an error.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

### Allocate Shipment with Carrier Service Example

The example shows a successful request to allocate shipment _sp_00794355402411366010308868571136_ to a carrier service with the `{carrier_service_reference}` _FF_LINET-00001_.

# [Allocate Shipment with Carrier Service Request](#tab/allocate-shipment-with-carrier-service-request)

`PUT https://api.sorted.com/pro/shipments/sp_00794355402411366010308868571136/allocate/service/FF_LINET-00001`

# [Allocate Shipment with Carrier Service Response](#tab/allocate-shipment-with-carrier-service-response)

```json
{
    "shipment_reference": "sp_00794355402411366010308868571136",
    "state": "allocated",
    "price": {
        "net": 2.00,
        "gross": 2.00,
        "taxes": [
            {
                "rate": {
                    "reference": "FF_LINET-00001",
                    "country_iso_code": "GB",
                    "type": "Zero",
                    "value": 0.0000
                },
                "amount": 0.000000
            }
        ],
        "currency": "GBP"
    },
    "message": "Shipment sp_00794355402411366010308868571136 has been allocated successfully",
    "carrier": {
        "reference": "FF_LINET",
        "name": "Lineten",
        "service_reference": "FF_LINET-00001",
        "service_name": "Lineten - Standard On Demand"
    },
    "tracking_details": {
        "shipment": {
            "reference": "sp_00794355402411366010308868571136",
            "tracking_references": [
                "8376568"
            ]
        },
        "contents": []
    },
    "_links": [
        {
            "href": "https://api-int.sorted.com/pro/shipments/sp_00794355402411366010308868571136",
            "rel": "shipment",
            "reference": "sp_00794355402411366010308868571136",
            "type": "shipment"
        },
        {
            "href": "https://api-int.sorted.com/pro/labels/sp_00794355402411366010308868571136/pdf",
            "rel": "label",
            "reference": "sp_00794355402411366010308868571136",
            "type": "label"
        },
        {
            "href": "https://api-int.sorted.com/pro/labels/sp_00794355402411366010308868571136/zpl",
            "rel": "label",
            "reference": "sp_00794355402411366010308868571136",
            "type": "label"
        }
    ],
    "correlation_id": "e35a94cd-f3e5-401a-85b8-dcda0aa2d553.SAPI_496bfd60-08b5-4cd3-86a7-502601288357",
    "details": [],
    "excluded_services": []
}
```
---

> [!NOTE]
>  For full reference information on the **Allocate Shipment with Carrier Service** endpoint, see the Shipments data contract.

## Allocating Multiple Shipments with a Specific Carrier Service

The **Allocate With Carrier Service** endpoint enables you to queue one or more shipments for allocation to a specific carrier service. To call **Allocate With Carrier Service**, send a `PUT` request to `https://api.sorted.com/pro/shipments/allocate/service`. The body of the request should contain a list of the `{shipments}` that you want to allocate and the `{carrier_service_reference}` of the carrier service you want to allocate to. 

Optionally, you can also include a list of service `capabilities`. Where capabilities are provided, then PRO only allocates the shipment to a carrier service that meets those capabilities. Each capability should list the `type` of service capability specified and the `value` that that capability should have.

> [!NOTE]
> For information on available service capabilities and values, see the Shipments data contract.

PRO takes each shipment in turn and checks whether the specified service is eligible to take that shipment. It then returns an Allocate Shipments result detailing the results of the request.

> [!NOTE]
> **Allocate with Carrier Service** does not override existing allocation rules. If the carrier service you selected does not meet your existing allocation rules, then PRO returns an error.

[!include[_shipments_allocate_shipments_result](../includes/_shipments_allocate_shipments_result.md)]

### Allocate with Carrier Service Example

The example shows a request to queue four shipments for allocation to a carrier service with the `{carrier_service_reference}` FF_LINET-00001. Three shipments have been successfully queued, but one was rejected because its `{reference}` could not be found.

# [Allocate with Carrier Service Request](#tab/allocate-with-carrier-service-request)

`PUT https://api.sorted.com/pro/shipments/allocate/service`

```json
{
    "shipments": [
        "sp_00794372987452683804666199932928",
        "sp_00794373204515521320006493798400",
        "sp_00794373381493583963175932002304",
        "sp_10014418709726822400876827879904"
    ],
    "carrier_service_reference": "FF_LINET-00001"
}
```
# [Allocate With Carrier Service Response](#tab/allocate-with-carrier-service-response)

```json
{
    "message": "3 shipments queued for allocation successfully. 1 shipment rejected for allocation.",
    "queued": [
        "sp_00794372987452683804666199932928",
        "sp_00794373204515521320006493798400",
        "sp_00794373381493583963175932002304"
    ],
    "rejected": [
        {
            "code": "shipment_not_found",
            "message": "The shipment cannot be found.",
            "references": [
                "sp_10014418709726822400876827879904"
            ]
        }
    ],
    "_links": []
}
```
---

> [!NOTE]
>  For full reference information on the **Allocate With Carrier Service** endpoint, see the Shipments data contract.

## Next Steps

* Learn about alternative methods of allocating shipments at the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/shipments/getting_shipment_labels.html) page.
* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.