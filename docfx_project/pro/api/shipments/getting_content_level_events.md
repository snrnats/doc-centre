---
uid: pro-api-help-shipments-getting-content-level-events
title: Getting Content Level Events
tags: shipments,pro,api,tracking,events,contents
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Contents-Level Events 

In contents-level tracking, PRO returns separate tracking responses for every item of contents within the specified shipment, rather than a single response per shipment. This page explains how to retrieve contents-level tracking events.

---

## Contents-Level Tracking Overview

Contents-level tracking is useful for shipments with multiple items of contents that may ship at different times. PRO offers two endpoints that enable you to get contents-level tracking events: 

* **Get Contents-Level Tracking Events** - Returns contents-level tracking events by unique shipment `{reference}`. 
* **Get Contents-Level Tracking Events by Custom Reference** - Returns contents-level tracking events by `{custom_reference}`. This endpoint may return tracking responses for more than one item of contents, because contents `custom_references` do not need to be unique.

## Getting Contents-Level Tracking Events

To call the **Get Contents-Level Tracking Events** endpoint, send a `GET` request to `https://api.sorted.com/pro/tracking/{reference}/shipment_contents` , where `{reference}` is the unique reference of the shipment you want to track.

PRO returns a `tracking_contents_response` object for the shipment. The `tracking_contents_response` includes the following information:

* The shipment's unique `reference` and (where applicable) `custom_reference`. 
* Details of the shipment's carrier.
* An updated expected delivery date for the shipment, where available.
* A list containing one `contents_tracking_event` object per item of shipment contents.

Each `contents_tracking_event` represents a tracking response for an item of contents within the shipment. The `contents_tracking_event` object includes:

* The unique `reference` for the item of contents.
  > [!NOTE]
  > The contents object's unique reference begins with _sc_ and is located in the shipment's `contents.reference` property. It is not to be confused with the shipment's own `reference`, which begins with _sp_ and is a unique identifier for the entire shipment.
* The `custom_reference` for the item of contents, where applicable.
* The carrier tracking reference for the item of contents.
* A list of standard PRO `tracking_events` for the item of contents. 

> [!NOTE]
>
> * For more information on the structure of PRO tracking events, see the [What Is a Tracking Event?](/pro/api/shipments/tracking_pro_shipments.html#what-is-a-tracking-event) section of the [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html) page.
> * For full reference information on the **Get Contents-Level Tracking Events** endpoint, see the Shipments data contract.

### Example Get Contents-Level Tracking Events Call

The example shows a **Get Contents-Level Tracking Events** call for shipment *sp_00076976827069691057723959934976*. In this case, the shipment has a single item of contents, which in turn has three tracking events available.

# [Get Contents-Level Tracking Events Request](#tab/get-contents-level-tracking-events-request)

```json
GET https://api.sorted.com/pro/tracking/sp_00076976827069691057723959934976/shipment_contents
```

# [Get Contents-Level Tracking Events Response](#tab/get-contents-level-tracking-events-response)

```json
{
    "shipment_reference": "sp_00076976827069691057723959934976",
    "carrier": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
    },
    "shipment_contents": [
        {
            "carrier_references": [
                "5805984057422232"
            ],
            "reference": "sc_00076982052497331561502355750928",
            "events": [
                {
                    "reference": "tr_00076982052571118537797193957408",
                    "timestamp": "2019-07-23T17:42:00+01:00",
                    "received_timestamp": "2019-07-23T16:45:44+00:00",
                    "event_code": "delivered",
                    "description": "The parcel was handed to the resident",
                    "signee": "P. Jones",
                    "location": "23 Baker Road, Wilmslow, Manchester",
                    "lat_long": null
                },
                {
                    "reference": "tr_00076980765301976842123553538056",
                    "timestamp": "2019-07-23T12:00.00+01:00",
                    "received_timestamp": "2019-07-23T11:02:31+00:00",
                    "event_code": "out_for_delivery",
                    "description": "The shipment is out for delivery",
                    "signee": null,
                    "location": null,
                    "lat_long": null
                },
                {
                    "reference": "tr_00076982052589565281870903508993",
                    "timestamp": "2019-07-22T19:33:54+01:00",
                    "received_timestamp": "2019-07-22T18:34:21+00:00",
                    "event_code": "collected",
                    "description": "The shipment has been collected",
                    "signee": null,
                    "location": null,
                    "lat_long": null
                }
            ]
        }
    ],
    "expected_delivery_date": null,
    "_links": [
        {
            "rel": "self",
            "href": "https://api.sorted.com/tracking/sp_00076976827069691057723959934976/shipment_contents",
            "type": "tracking",
            "reference": "sp_00076976827069691057723959934976"
        }
    ]
}
```
---

## Getting Contents-Level Tracking Events by Custom Reference

The **Get Contents-Level Tracking Events by Custom Reference** endpoint enables you to retrieve contents-level tracking details by your own internal order reference numbers. The items of contents in question must be tagged with the relevant references via the `{custom_reference}` property. 

The endpoint can also be used where a consumer order corresponds to multiple items of contents. In order to use the **Get Contents-Level Tracking Events by Custom Reference** endpoint in this way, all of the order's component contents would need to be tagged with the same `{custom_reference}`.

To call **Get Contents-Level Tracking Events by Custom Reference**, send a `GET` request to `https://api.sorted.com/pro/tracking/custom_reference/{custom_reference}/shipment_contents`.

> [!NOTE]
> The `{custom_reference}` parameter in the **Get Contents-Level Tracking Events by Custom Reference** path refers to the `custom_reference` of the item of shipment contents and **NOT** the `custom_reference` of the shipment itself.
>
> For example, suppose that you have a shipment with a `custom_reference` of _1234_, which contains three items of contents that all have the `custom_reference` _ABCD_. To view tracking details for those items of contents via the **Get Contents-Level Tracking Events by Custom Reference** endpoint, you would call `https://api.sorted.com/pro/tracking/custom_reference/ABCD/shipment_contents` rather than `https://api.sorted.com/pro/tracking/custom_reference/1234/shipment_contents`

### Response Structure

PRO returns a `tracking_contents_response_list` object containing tracking information for any items of shipment contents that have the specified `{custom_reference}`. The `tracking_contents_response_list` comprises a list of `tracking_contents_responses`, as well as fields indicating the total number of matching records and (where applicable) the number of records that were taken or skipped using paging parameters.

Each `tracking_contents_response` represents tracking details for a shipment that has contents that have the supplied `{custom_reference}`. The `tracking_contents_response` includes the following information:

* The shipment's unique `{reference}` and (where applicable) `{custom_reference}`. 
* Details of the carrier and carrier service for the shipment.
* An updated expected delivery date for the shipment, where available.
* A list of `contents_tracking_event` objects. 

Each `contents_tracking_event` object represents tracking details of an item of shipment contents. The `contents_tracking_event` object includes the following information:

* The item's unique `{reference}` and (where applicable) `{custom_reference}`.
  > [!NOTE]
  > The contents object's unique reference begins with _sc_ and is located in the shipment's `contents.reference` property. It is not to be confused with the shipment's own `reference`, which begins with _sp_ and is a unique identifier for the entire shipment. 
* The carrier tracking references for the item
* A list of standard PRO `tracking_events` for the item of contents.   

> [!NOTE]
> For more information on the structure of PRO shipment tracking events, see the [What Is a Tracking Event?](/pro/api/shipments/tracking_pro_shipments.html#what-is-a-tracking-event) section of the [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html) page.

### Paging Results

The **Get Contents-Level Tracking Events by Custom Reference** endpoint supports optional `{take}` and `{skip}` parameters, which can be used to drive paging functions. The `{take}` parameter indicates the number of shipments to return (up to a maximum of 10), and the `{skip}` parameter indicates the number of shipment records PRO should "skip over" before it returns records.

For example, suppose that you have 15 shipments with a `custom_reference` of _CR1234_, and you want to return their tracking information as three pages of five shipments: 

* To view the first page of five, you would make a call to `GET https://api.sorted.com/pro/tracking/custom_reference/CR1234/shipment_contents&take=5&skip=0` (that is, take five shipments and do not skip over any). 
* To view the second page, you would call `GET https://api.sorted.com/pro/tracking/custom_reference/CR1234/shipment_contents&take=5&skip=5` (skip the first five shipments and then take the next five).
* To view the third page, you would call `GET https://api.sorted.com/pro/tracking/custom_reference/CR1234/shipment_contents&take=5&skip=10` (skip the first ten shipments and then take the next five).

By default, `{take}` has a value of 10 and `{skip}` has a value of 0.

> [!NOTE]
> * For full reference information on the **Get Contents-Level Tracking Events by Custom Reference** endpoint, see the Shipments data contract.

<!-- commenting this section out as no example response available yet

### Example Get Contents-Level Tracking Events by Custom Reference Call

The example shows a **Get Contents-Level Tracking Events by Custom Reference** call for all shipments with the `{custom_reference}` _CR1234_, using default paging settings. PRO has returned tracking details for a single shipment.

# [Request](#tab/get-contents-level-tracking-events-by-custom-reference-request)

```json
GET https://api.sorted.com/pro/tracking/custom_reference/CR1234/shipment_contents
```

# [Response](#tab/get-contents-level-tracking-events-by-custom-reference-response)

```json

```
---

<span class="commented-out">NO EXAMPLE OBJECT IN THE DATA CONTRACT AND API STUB ISNT RESPONDING SO WILL HAVE TO ADD EXAMPLE RESPONSE LATER</span> -->

## Next Steps

* Learn how to get tracking events for a shipment: [Getting Shipment Events](/pro/api/shipments/getting_shipment_events.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to use REACT, Sorted's advanced shipment tracking product: [REACT Docs](/react/index.html?v2)