---
uid: pro-api-help-shipments-allocating-via-a-quote
title: Allocating via a Quote
tags: shipments,pro,api,allocation,rules
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Allocating with a Quote

Obtaining quotes to carry an individual shipment and then allocating to the most suitable response is a key part of many customer service workflows in SortedPRO. This page explains how to use the **Allocate Shipment with Quote** endpoint to select a quote.

---

## Quotes Overview

In PRO, delivery quotes are generally used outside of a "regular" shipment allocation workflow, as a means of managing shipments that require manual intervention. For example, your customer service teams might want to get quotes for an expedited delivery on a shipment that was missed by a carrier and so did not meet its delivery promise. 

PRO's Quotes endpoints return one or more `quote` objects, of which each represents an offer for carriage of a shipment with a specific carrier service. Each quote can be uniquely identified by a `{reference}`, which is used when selecting a quote via the **Allocate Shipment With Quote** endpoint.

> [!NOTE]
>
> * For a full user guide on working with quotes, see LINK HERE.
> * For reference information on the Quotes API, see the LINK HERE.

## Using Allocate Shipment With Quote

The **Allocate Shipment With Quote** endpoint enables you to allocate an individual shipment based on a specific delivery quote from a carrier. To call **Allocate Shipment With Quote**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/allocate/quote/{quote_ref}`, where `{reference}` corresponds to the shipment you want to allocate and `{quote_ref}` is the quote you want to select.

> [!NOTE]
> The `{quote_ref}` begins with _qu_ and can be found in the `quotes.reference` property of the Quote Result. It is not to be confused with the Quote Result's own `{reference}`, which begins with _qr_ and is a unique reference for the entire quote response rather than a selectable quote.

Once the request is received PRO attempts to allocate the shipment to the carrier service specified in the quote (as denoted by the `carrier.service_reference` and `carrier.service_name` fields contained within the `quote` object), and returns an Allocate Result.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

> [!NOTE]
> For full reference information on the **Allocate Shipment with Quote** endpoint, see LINK HERE.

### Allocate Shipment with Quote Example

The example shows a successful request to allocate shipment _sp_10014418868640612447876776802355_ to quote _qu_10014418868640618745676788980009_.

# [Allocate With Quote Request](#tab/allocate-with-quote-request)

```json
PUT https://api.sorted.com/pro/shipments/allocate/sp_10014418868640612447876776802355/quote/qu_10014418868640618745676788980009
```

# [Allocate With Quote Response](#tab/allocate-with-quote-response)

```json
{
  "shipment_reference": "sp_10014418868640612447876776802355",
  "state": "allocated",
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
        "amount": 0.0
      }
    ],
    "currency": "GBP"
  },
  "message": "Shipment sp_10014418868640612447876776802355 allocated with quote qu_10014418868640618745676788980009 successfully",
  "carrier": {
    "reference": "DNQ",
    "name": "DNQ Worldwide",
    "service_reference": "DNQ72",
    "service_name": "DNQ 72-Hour Express"
  },
  "tracking_details": {
    "shipment": {
      "reference": "sp_10014418868640612447876776802355",
      "tracking_references": [
        "tr_00658933450928453677570964848640"
      ],
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/shipments/sp_10014418868640612447876776802355",
          "rel": "shipment",
          "reference": "sp_10014418868640612447876776802355",
          "type": "shipment"
        },
        {
          "href": "https://beta.sorted.com/pro/tracking/sp_10014418868640612447876776802355",
          "rel": "self",
          "reference": "sp_10014418868640612447876776802355",
          "type": "tracking"
        }
      ]
    },
    "contents": [
      {
        "reference": "sc_00658933450633305772391612022784",
        "tracking_references": [
          "tr_00658933450946900421644674400256"
        ],
        "_links": [
          {
            "href": "https://beta.sorted.com/pro/shipments/sp_10014418868640612447876776802355",
            "rel": "shipment",
            "reference": "sp_10014418868640612447876776802355",
            "type": "shipment"
          },
          {
            "href": "https://beta.sorted.com/pro/tracking/sp_10014418868640612447876776802355/shipment_contents",
            "rel": "self",
            "reference": "sp_10014418868640612447876776802355",
            "type": "contents_tracking"
          }
        ]
      }
    ]
  },
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/labels/sp_10014418868640612447876776802355/pdf",
      "rel": "label",
      "reference": "sp_10014418868640612447876776802355",
      "type": "label"
    },
    {
      "href": "https://beta.sorted.com/pro/labels/sp_10014418868640612447876776802355/zpl",
      "rel": "label",
      "reference": "sp_10014418868640612447876776802355",
      "type": "label"
    },
    {
      "href": "https://beta.sorted.com/pro/shipments/sp_10014418868640612447876776802355",
      "rel": "shipment",
      "reference": "sp_10014418868640612447876776802355",
      "type": "shipment"
    }
  ]
}
```
--- 

## Next Steps

* Learn about alternative methods of allocating shipments at the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/shipments/getting_shipment_labels.html) page.
* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.