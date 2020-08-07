---
uid: pro-api-help-shipments-getting-shipment-events
title: Getting Shipment Events
tags: shipments,pro,api,tracking,events
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Shipment Events

This page explains how to retrieve carrier tracking events for a shipment.

---

## Shipment-Level Tracking Overview

In shipment-level tracking, PRO returns tracking events for the entire shipment, without making a distinction between individual items of contents within that shipment. 

<span class="highlight">WHAT DOES IT DO WHEN THERE ARE MULTIPLE ITEMS OF CONTENTS SHIPPING INDEPENDENTLY? DOES IT JUST DISPLAY THE MOST RECENT? ALSO, DO WE HAVE USE CASES FOR THESE ENDPOINTS VS THE CONTENT-LEVEL ENDPOINTS (USE SHIPMENT-LEVEL IF YOU ONLY SHIP SINGLE PACKAGES, THAT SORT OF THING)</span>

PRO offers two endpoints that enable you to get shipment-level tracking events: 

* **Get Tracking Events** - Returns shipment-level tracking events by unique shipment `{reference}`.
* **Get Tracking Events by Custom Reference** - Returns shipment-level tracking events by `{custom_reference}`.

## Getting Tracking Events by Shipment Reference

To call the **Get Tracking Events** endpoint, send a `GET` request to `https://api.sorted.com/pro/tracking/{reference}`, where `{reference}` is the unique reference of the shipment you want to track.

PRO returns a `tracking_response` object for the shipment. The `tracking_response` includes the following information:

* The shipment's unique `reference` and (where applicable) `custom_reference`. 
* Details of the carrier and carrier service for the shipment.
* An updated expected delivery date for the shipment, where available.
* A list of tracking events for the shipment.

> [!NOTE]
>
> * For more information on the structure of PRO shipment tracking events, see the [What Is a Tracking Event?](/pro/api/shipments/tracking_pro_shipments.html#what-is-a-tracking-event) section of the [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html) page.
> * For full reference information on the **Get Tracking Events** endpoint, see LINK HERE.

### Example Get Tracking Events Call

The example shows a **Get Tracking Events** call for shipment _sp_00695767408794862515340410880000_. The `tracking_response` returned by PRO includes three tracking events: one created when the shipment was collected, one created when it was marked as out for delivery, and one created when it was delivered.

# [Get Tracking Events Request](#tab/get-tracking-events-request)

```json
GET https://api.sorted.com/pro/tracking/sp_00695767408794862515340410880000
```

# [Get Tracking Events Response](#tab/get-tracking-events-response)

```json
{
    "shipment_reference": "sp_00695767408794862515340410880000",
    "carrier_references": [
        "5605984057422227"
    ],
    "custom_reference": "3c48aee67b6c4662b5884b9ceec8e3c8",
    "carrier": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
    },
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
           "description": "The shipment has been collected by the carrier",
           "signee": null,
           "location": null,
           "lat_long": null
       }
    ],
    "expected_delivery_date": null,
    "_links": [
        {
            "rel": "self",
            "href": "https://api.sorted.com/tracking/sp_00695767408794862515340410880000",
            "type": "tracking",
            "reference": "sp_00695767408794862515340410880000"
        },
        {
            "rel": "shipment",
            "href": "https://api.sorted.com/shipments/sp_00695767408794862515340410880000",
            "type": "shipment",
            "reference": "sp_00695767408794862515340410880000"
        }
    ]
}
```
---

## Getting Tracking Events by Custom Reference

The **Get Tracking Events by Custom Reference** endpoint enables you to retrieve tracking details by your own internal order reference numbers. Your shipments must be tagged with the relevant references via the `{custom_reference}` property. 

The endpoint can also be used where a consumer order corresponds to multiple shipments, for example because the order contains items that will need to ship from different fulfilment centres. In order to use the **Get Tracking Events by Custom Reference** endpoint in this way, all of the order's component shipments would need to be tagged with the same `{custom_reference}`.

To call the **Get Tracking Events by Custom Reference** endpoint, send a `GET` request to `https://api.sorted.com/pro/tracking/custom_reference/{custom_reference}`.

PRO returns a `tracking_response_list` object containing tracking information for any shipments that have the specified `{custom_reference}`. The `tracking_response_list` comprises a list of `tracking_responses`, as well as fields indicating the total number of matching shipments and (where applicable) the number of records that were taken or skipped using paging parameters.

Each `tracking_response` includes the following information:

* The shipment's unique `{reference}` and (where applicable) `{custom_reference}`. 
* Details of the carrier and carrier service for the shipment.
* An updated expected delivery date for the shipment, where available.
* A list of tracking events for the shipment.

> [!NOTE]
> * For more information on the structure of PRO shipment tracking events, see the [What Is a Tracking Event?](/pro/api/shipments/tracking_pro_shipments.html#what-is-a-tracking-event) section of the [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html) page.

### Paging Results

The **Get Tracking Events by Custom Reference** endpoint supports optional `{take}` and `{skip}` parameters, which can be used to drive paging functions. The `{take}` parameter indicates the number of shipments to return (up to a maximum of 10), and the `{skip}` parameter indicates the number of shipment records PRO should "skip over" before it returns records.

For example, suppose that you have 15 shipments with a `custom_reference` of _CR1234_, and you want to return their tracking information as three pages of five shipments: 

* To view the first page of five, you would make a call to `GET https://api.sorted.com/pro/tracking/custom_reference/CR1234&take=5&skip=0` (that is, take five shipments and do not skip over any). 
* To view the second page, you would call `GET https://api.sorted.com/pro/tracking/custom_reference/CR1234&take=5&skip=5` (skip the first five shipments and then take the next five).
* To view the third page, you would call `GET https://api.sorted.com/pro/tracking/custom_reference/CR1234&take=5&skip=10` (skip the first ten shipments and then take the next five).

By default, `{take}` has a value of 10 and `{skip}` has a value of 0.

> [!NOTE]
> * For full reference information on the **Get Tracking Events by Custom Reference** endpoint, see LINK HERE.

### Example Get Tracking Events by Custom Reference Call

The example shows a **Get Tracking Events by Custom Reference** call for all shipments with the `{custom_reference}` _CR1234_, using default paging settings. PRO has returned tracking details for a single shipment.

# [Get Tracking Events by Custom Reference Request](#tab/get-tracking-events-by-custom-reference-request)

```json
GET https://api.sorted.com/pro/tracking/custom_reference/CR1234
```

# [Get Tracking Events by Custom Reference Response](#tab/get-tracking-events-by-custom-reference-response)

```json
{
  "tracking_responses": [
    {
      "shipment_reference": "sp_00695852292981903959812645584896",
      "custom_reference": "CR1234",
      "carrier_references": [
        "a695755498034110bfeb8a6a1f1b56b9"
      ],
      "carrier_details": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
      },
      "events": [
        {
          "reference": "tr_00695852293572199770171351236608",
          "timestamp": "2019-07-14T17:42:00+01:00",
          "received_timestamp": "2019-07-14T16:45:44+00:00",
          "event_code": "delivered",
          "description": "The parcel was handed to the resident",
          "signee": "P. Jones",
          "location": "23 Baker Road, Wilmslow, Manchester, UK, M2 5RG"
        },
        {
          "reference": "tr_00695852293572199770171351236609",
          "timestamp": "2019-07-14T12:00:00+01:00",
          "received_timestamp": "2019-07-14T11:02:31+00:00",
          "event_code": "out_for_delivery",
          "description": "The shipment is out for delivery"
        },
        {
          "reference": "tr_00695852293572199770171351236610",
          "timestamp": "2019-07-13T19:33:54+01:00",
          "received_timestamp": "2019-07-22T18:34:21+00:00",
          "event_code": "collected",
          "description": "The shipment has been collected by the carrier"
        }
      ],
      "expected_delivery_date": "2020-08-09T00:00:00+00:00",
      "_links": [
        {
          "href": "https://api.sorted.com/pro/tracking/sp_00695852292981903959812645584896",
          "rel": "self",
          "reference": "sp_00695852292981903959812645584896",
          "type": "tracking"
        },
        {
          "href": "https://api.sorted.com/pro/shipments/sp_00695852292981903959812645584896",
          "rel": "shipment",
          "reference": "sp_00695852292981903959812645584896",
          "type": "shipment"
        }
      ]
    }
  ],
  "total_results": 1,
  "take": 10,
  "skip": 0,
  "_links": [
    {
      "href": "https://api.sorted.com/pro/tracking/custom_reference/CR1234?take=10&skip=0",
      "rel": "self",
      "reference": "CR1234",
      "type": "tracking"
    }
  ]
}
```
---

## Next Steps

* Learn how to get tracking events for individual items of shipment contents: [Getting Content-Level Events](/pro/api/shipments/getting_content_level_events.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to use REACT, Sorted's advanced shipment tracking product: [REACT Docs](/react/index.html?v2)