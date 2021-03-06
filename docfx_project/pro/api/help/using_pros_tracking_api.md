---
uid: pro-api-help-using-pros-tracking-api
title: Using PRO's Tracking API
tags: tracking,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Using PRO's Tracking API

SortedPRO's Tracking API enables you to drive embedded delivery tracking from your own website, without the need to pass customers off to a carrier portal. This page explains how to use the Tracking API to get updates on a consignment's progress.

---

## Tracking API Overview

PRO's Tracking API has three endpoints:

* **Get Tracking Events** - Returns full tracking event information for a specific consignment, including separate details for each leg of a shipment.
* **Get Events Per Package** - Returns flattened tracking event information for a specific consignment, broken down by package. Does not take multiple legs into account.
* **Post Tracking Events** - Enables carriers to post events directly to PRO.

> [!NOTE]
>
> The **Post Tracking Events** endpoint is intended for carrier use only, and is outside the scope of this documentation.

## What Is a Tracking Event?

Tracking events are informational messages returned from carriers that provide details about the status of the consignment. Each tracking event contains the following properties:

* `TimeStamp` - The time and date that the tracking event occurred.
* `Code` - A unique identifier for the type of tracking event (for example "Delivered").
* `Description` - A description of the tracking event.
* `SignedBy` - The name of the person who signed for the package (if applicable).
* `Location` - The location of the tracking event.

PRO integrates with many carriers, and each carrier provides tracking events in different formats. As such, PRO translates all tracking events into a standard format, regardless of carrier service selected.

A consignment's current `ConsignmentState` is derived from these tracking events. For example, a "Delivered" tracking event will change the state of the relevant consignment to _Delivered_.

> [!NOTE]
>
> For a full list and description of available consignment states, see the [Consignment States](/pro/api/help/consignment_states.html) page.

## Getting Multi-Leg Tracking Events

To call **Get Tracking Events**, send a `GET` request to `https://api.electioapp.com/tracking/{consignmentReference}`. 

PRO responds with a `TrackedPackages` array, containing details of all the tracked packages in the consignment. Each package contains an array of `Legs`, of which each contains tracking `Events` for that particular leg of the package's journey.

> [!NOTE]
>
> For full reference information on the **Get Tracking Events** API, see the [API reference](https://docs.electioapp.com/#/api/GetTrackingEvents).

### Get Tracking Events Example

This example shows a simplified **Get Tracking Events** response for consignment _EC-000-002-4DF_. PRO has returned details of one journey leg with a single sample tracking event.

# [Get Tracking Events Response](#tab/get-tracking-events-response)

`GET https://api.electioapp.com/tracking/EC-000-002-4DF`

```json
{
  "ConsignmentReferenceForAllLegsAssignedByMpd": "EC-000-002-4DF",
  "TrackedPackages": [
    {
      "PackageReferenceForAllLegsAssignedByMpd": "EP-000-034-4DG",
      "Legs": [
        {
          "CarrierServiceName": "Carrier Service B",
          "Events": [
            {
              "TimeStamp": "2020-02-11T07:08:11.786733+00:00",
              "Code": "Sample",
              "Description": "Sample Event",
              "SignedBy": "C. Smith",
              "Location": "Sample Location"
            }
          ]
        }
      ]
    }
  ]
}
```
---

## Getting Single Leg Tracking Events

To call **Get Events Per Package**, send a `GET` request to `https://api.electioapp.com/tracking/flattened/{consignmentReference}`.

Like the **Get Tracking Events** endpoint, **Get Events Per Package** returns all tracking events for the specified consignment. However, unlike **Get Tracking Events**, **Get Events Per Package** does not break the events returned down into legs. Instead, it returns a list of `TrackedPackages`, of which each contains a package reference and a list of relevant `Events`.

> [!NOTE]
>
> For full reference information on the **Get Events Per Package** API, see the [API reference](https://docs.electioapp.com/#/api/GetEventsPerPackage).

### Example Get Events Per Package Response

This example shows a simplified **Get Events Per Package** response for consignment _EC-000-002-4DF_. PRO has returned details of a single sample tracking event.

# [Get Events Per Package Response](#tab/get-events-per-package-response)

`GET https://api.electioapp.com/tracking/flattened/EC-000-002-4DF`

```json
{
  "ConsignmentReferenceForAllLegsAssignedByMpd": "EC-000-002-4DF",
  "TrackedPackages": [
    {
      "PackageReferenceForAllLegsAssignedByMpd": "EP-000-002-4RE",
      "Events": [
        {
          "TimeStamp": "2020-02-11T07:08:11.7398573+00:00",
          "Code": "DELIVERED",
          "Description": "Sample tracking event",
          "SignedBy": "P. Smith",
          "Location": "Sample Location",
          "CarrierServiceName": "Sample Carrier Service A"
        }
      ]
    }
  ]
}
```
---

## Next Steps

* Learn how to get customs docs and invoices for international shipments at the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page.
* View the list of available consignment states at the [Consignment States](/pro/api/help/consignment_states.html) page.
* Learn how to manifest consignments at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.