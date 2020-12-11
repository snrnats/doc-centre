---
uid: pro-api-help-shipments-tracking-pro-shipments
title: Tracking PRO Shipments
tags: v2,shipments,pro,api,tracking
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Tracking PRO Shipments

SortedPRO's tracking features enable you to provide package tracking updates for your customers without having to pass them off to a carrier portal. This section explains how to use PRO's built-in tracking endpoints.

> [!NOTE]
> Sorted's dedicated tracking product, REACT, enables you to provide a richer tracking experience to your customers. For more information on using REACT, see the [REACT](/react/index.html?v2) section.

> [!NOTE]
> This page provides help and support for PRO version 2 (Shipments). As PRO v2 is currently in development, content may be removed or edited without warning.
>
> For support on PRO v1 (Consignments), [click here](/pro/api/help/introduction.html).  

---

## PRO Shipment Tracking Overview

PRO's Tracking API is intended to drive simple web-based tracking pages. When the API is called, PRO returns a response listing the tracking events that have occurred since that shipment was dispatched. 

PRO enables you to get tracking events at either shipment or (where supported by the carrier) contents level: 

* In shipment-level tracking, PRO returns tracking events for the entire shipment, without making a distinction between individual items of contents within that shipment.
* In contents-level tracking, PRO returns separate tracking events for every item of contents within the specified shipment.

In addition, PRO enables you to get tracking events by both a shipment's PRO-generated unique `{reference}` or its user-defined `{custom_reference}`. Getting tracking information by `{custom_reference}` means that you can track shipments using your own internal references (assuming that you have added those references to your shipments as `custom_references`). 

In total, PRO has four in-built shipment tracking endpoints:

* **Get Tracking Events** - Returns shipment-level tracking events by unique shipment `{reference}`.
* **Get Tracking Events by Custom Reference** - Returns shipment-level tracking events by `{custom_reference}`.
* **Get Content-Level Tracking Events** - Returns contents-level tracking events by unique shipment `{reference}`. 
* **Get Content-Level Tracking Events by Custom Reference** - Returns contents-level tracking events by `{custom_reference}`. 

> [!NOTE]
> PRO's endpoints that return tracking information by custom reference may return details of more than one shipment, because shipment `custom_references` do not need to be unique.

## What Is a Tracking Event?

Tracking events are informational messages returned from carriers that provide details about the status of the consignment. All of PRO's tracking endpoints return standardised tracking events with the following properties:

* `reference` - A unique identifier for the tracking event.
* `timestamp` - The time and date that the tracking event occurred.
* `received_timestamp` - The time and date that the tracking event was received by Sorted.
* `event_code` - A unique identifier for the type of tracking event (for example _delivered_).
* `description` - A description of the tracking event.
* `signee` - The name of the person who signed for the package, if applicable.
* `location` - The location of the tracking event, if applicable.
* `lat_long` The latitude and longitude of the location at which the event took place, where provided.

# [Example Tracking Event](#tab/example-tracking-event)

```json
{
    "reference": "tr_00076982052571118537797193957408",
    "timestamp": "2019-07-23T17:42:00+01:00",
    "received_timestamp": "2019-07-23T16:45:44+00:00",
    "event_code": "delivered",
    "description": "The parcel was handed to the resident",
    "signee": "P. Jones",
    "location": "23 Baker Road, Wilmslow, Manchester",
    "lat_long": null
}
```
---

PRO integrates with many carriers, and each carrier provides tracking events in different formats. As such, PRO translates all tracking events into a standard format, regardless of carrier service selected.

A shipment's current `shipment_state` is derived from these tracking events. For example, a `delivered` tracking event will change the state of the relevant shipmenta to _Delivered_.

> [!NOTE]
>
> For a full list and description of available consignment states, see the [Consignment States](/pro/api/help/consignment_states.html) page.

## Section Contents

* [Getting Shipment Events](/pro/api/shipments/getting_shipment_events.html) - Explains how to use the **Get Tracking Events** and **Get Tracking Events by Custom Reference** endpoints.
* [Getting Content-Level Events](/pro/api/shipments/getting_content_level_events.html) - Explains how to use the **Get Content-Level Tracking Events** and **Get Content-Level Tracking Events by Custom Reference** endpoints.