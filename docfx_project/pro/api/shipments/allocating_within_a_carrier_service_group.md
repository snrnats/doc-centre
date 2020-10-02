---
uid: pro-api-help-shipments-allocating-within-a-carrier-service-group
title: Allocating Within A Carrier Service Group
tags: shipments,pro,api,allocation,service group
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---

# Allocating Within A Carrier Service Group

Service groups enable you to specify a custom pool of carrier services to allocate a shipment from. This page explains how to configure service groups, and how to use the **Allocate Shipment with Service Group** and **Allocate with Service Group** endpoints to allocate from within those groups.

---

## What Is a Carrier Service Group?

SortedPRO carrier service groups are user-defined pools of carrier services. They are designed to be used in conjunction with the **Allocate Shipment with Service Group** and **Allocate with Service Group** endpoints as a means of limiting the carrier services that a particular shipment could be allocated to. 

For example, you might set up a group containing all services that will ship dangerous goods. You would then allocate within that group for all shipments involving dangerous items. 

You can use any combination of carrier services in a carrier service group.

<!-- ## Configuring Carrier Service Groups

<span class="commented-out">INSTRUCTIONS FOR SETTING UP CSGS IN THE NEW UI IN HERE</span>-->

## Allocating a Single Shipment with a Carrier Service Group

The **Allocate Shipment with Service Group** endpoint allocates a shipment with a carrier service from a specific carrier service group. 

To call **Allocate Shipment With Service Group**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/allocate/service_group/{group_ref}`, where `{reference}` is the unique reference for the shipment you want to allocate and `{group_ref}` is the **Service Group Code**  of the group you want to allocate within.

<!--<span class="commented-out">INSTRUCTIONS ON FINDING SERVICE GROUP CODES OR SHIPMENTS EQUIVALENT IN HERE</span>-->

Once the request is received, PRO uses allocation rules to eliminate any carrier services in the group that would not be suitable to take the shipment, allocates the shipment to the cheapest remaining service, and returns an Allocate Result.

> [!NOTE]
> For information on using allocation rules, see the [What Is An Allocation Rule?](/pro/api/shipments/allocating_shipments.html#what-is-an-allocation-rule) section of the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

### Allocate Shipment with Service Group Example

The example shows a successful request to allocate a shipment with a `{reference}` of _sp_10014418679662051328777876543332_ within a group that has a `{group_ref}` of _valuableGoods_.

# [Allocate Shipment With Service Group Request](#tab/allocate-shipment-with-service-group-request)

```json
PUT https://api.sorted.com/pro/shipments/sp_10014418679662051328777876543332/allocate/service_group/valuableGoods
```

# [Allocate Shipment With Service Group Response](#tab/allocate-shipment-with-service-group-response)

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
> For full reference information on the **Allocate Shipment with Service Group** endpoint, see the Shipments data contract. 

## Allocating Multiple Shipments with a Carrier Service Group

The **Allocate with Service Group** endpoint queues one or more shipments for allocation to a carrier service that is a member of a specific carrier service group. 

To call **Allocate with Service Group**, send a `PUT` request to `https://api.sorted.com/pro/shipments/allocate/service_group`. The body of the request should contain a list of the `{shipments}` that you want to allocate and the `{service_group}` reference of the carrier service you want to allocate to.

Optionally, you can also include a list of service `capabilities`. Where capabilities are provided, then PRO only allocated the shipment to a carrier service that meets those capabilities. Each capability should list the `type` of service capability specified and the `value` that that capability should have.

> [!NOTE]
> For information on available service capabilities and values, see the Shipments data contract

PRO takes each shipment in turn, uses allocation rules to eliminate any carrier services in the group that would not be suitable to take the shipment, and the queues the shipment for allocation to the cheapest remaining service. It then returns an Allocate Shipments result detailing the results of the request.

<span class="highlight">Is the above accurate?</span>

[!include[_shipments_allocate_shipments_result](../includes/_shipments_allocate_shipments_result.md)]

### Allocate with Service Group Example

The example shows a request to queue four shipments for allocation within carrier service group _exampleSG123_. Three shipments have been successfully queued, but one was rejected because its `{reference}` could not be found.

# [Allocate With Service Group Request](#tab/allocate-with-service-group-request)

```json
{
    "shipments": [
        "sp_10014418679662051328777876543332",
        "sp_10014418692546953216762537656534",
        "sp_10014418701136887808123998889990",
        "sp_10014418709726822400876827639994"
    ],
    "service_group ": "exampleSG123"
}
```

# [Allocate With Service Group Response](#tab/allocate-with-service-group-response)

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
> For full reference information on the **Allocate with Service Group** endpoint, see the Shipments data contract. 

## Next Steps

* Learn about alternative methods of allocating shipments at the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/shipments/getting_shipment_labels.html) page.
* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.