---
uid: pro-api-help-shipments-allocating-with-a-virtual-service
title: Allocating with a Virtual Service
tags: shipments,pro,api,allocation,virtual service
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 08/07/2020
---
# Allocating with a Virtual Service

Virtual services offer flexible shipment allocation, enabling you to automatically choose from either a single carrier service or from a pre-defined group of carrier services via a single API call. This page explains how to use the **Allocate Shipment with Virtual Service** endpoint.

---

## Allocating using Virtual Services

The **Allocate Shipment with Virtual Service** endpoint takes a unique shipment `reference` and either a service group `reference` or a carrier service `reference`, and attempts to allocate the specified shipment to either the specified carrier service or a service within the specified service group, as applicable.

To call **Allocate Shipment with Virtual Service**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/allocate/virtual_service/{virtual_service_reference}`, where `{reference}` is the unique reference of the shipment you want to allocate and `{virtual_service_reference}` is the reference of the carrier service or service group you want to allocate to.

Once it has received the request, PRO takes the following action:

* When a valid carrier service reference is provided, PRO allocates the shipment with that specific carrier service and returns an Allocate Result.
* When a valid service group reference is provided, PRO allocates the shipment within the specific carrier service group and returns an Allocate Result.
* When the `{virtual_service_reference}` parameter matches both a carrier service and a service group, PRO returns a _400 (Bad Request)_ error response.
* When the `{virtual_service_reference}` parameter does not match either a carrier service or a service group, PRO returns a _404 (Not Found)_ error response.

> [!TIP]
> When PRO returns a _400 (Bad Request)_ error response due to the `{virtual_service_reference}` parameter matching both a carrier service and a service group, you can still use the **Allocate Shipment with Carrier Service** or **Allocate Shipment with Service Group** to allocate the shipment.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

### Allocate Shipment with Virtual Service Example

This example shows a successful **Allocate Shipment with Virtual Service** request to allocate shipment _sp_00802615769404976542730318118912_ using the reference _FF_LINET-00001_. In this case, the provided reference corresponds to a carrier service rather than a service group. However, the `allocate_result` object returned would have the same structure if you were to provide a service group reference. 

# [Example Allocate Shipment with Virtual Service Request](#tab/example-allocate-shipment-with-virtual-service-request)

`PUT https://api.sorted.com/pro/shipments/sp_00802615769404976542730318118912/allocate/virtual_service/FF_LINET-00001`

# [Example Allocate Shipment with Virtual Service Response](#tab/example-allocate-shipment-with-virtual-service-response)

```json
{
    "shipment_reference": "sp_00802615769404976542730318118912",
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
    "message": "Shipment sp_00802615769404976542730318118912 has been allocated successfully",
    "carrier": {
        "reference": "FF_LINET",
        "name": "Lineten",
        "service_reference": "FF_LINET-00001",
        "service_name": "Lineten - Standard On Demand"
    },
    "tracking_details": {
        "shipment": {
            "reference": "sp_00802615769404976542730318118912",
            "tracking_references": [
                "19297253"
            ]
        },
        "contents": []
    },
    "_links": [
        {
            "href": "https://api-int.sorted.com/pro/shipments/sp_00802615769404976542730318118912",
            "rel": "shipment",
            "reference": "sp_00802615769404976542730318118912",
            "type": "shipment"
        },
        {
            "href": "https://api-int.sorted.com/pro/labels/sp_00802615769404976542730318118912/pdf",
            "rel": "label",
            "reference": "sp_00802615769404976542730318118912",
            "type": "label"
        },
        {
            "href": "https://api-int.sorted.com/pro/labels/sp_00802615769404976542730318118912/zpl",
            "rel": "label",
            "reference": "sp_00802615769404976542730318118912",
            "type": "label"
        }
    ],
    "correlation_id": "c0d007b2-ff54-4e6d-b770-2298bb15e667.SAPI_c895965a-b123-4b6e-88c3-b5fe71304303",
    "details": [],
    "excluded_services": []
}
```
---

## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to manifest shipments: [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html)
* Learn how to create shipment groups: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)