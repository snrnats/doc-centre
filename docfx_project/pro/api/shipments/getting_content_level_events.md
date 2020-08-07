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
* **Get Contents-Level Tracking Events by Custom Reference** - Returns contents-level tracking events by `{custom_reference}`. This endpoint may return tracking responses for the contents of more than one shipment, because shipment `custom_references` do not need to be unique.

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
> * For full reference information on the **Get Contents-Level Tracking Events** endpoint, see LINK HERE.

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

Get Contents-Level Tracking Events by Custom Reference

`GET https://api.sorted.com/pro/tracking/custom_reference/{custom_reference}/shipment_contents`

> [!NOTE]
>
> * For more information on the structure of PRO shipment tracking events, see the [What Is a Tracking Event?](/pro/api/shipments/tracking_pro_shipments.html#what-is-a-tracking-event) section of the [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html) page.
> * For full reference information on the **Get Contents-Level Tracking Events by Custom Reference** endpoint, see LINK HERE.

## Next Steps

* Learn how to get tracking events for a shipment: [Getting Shipment Events](/pro/api/shipments/getting_shipment_events.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to use REACT, Sorted's advanced shipment tracking product: [REACT Docs](/react/index.html?v2)