---
uid: pro-api-help-shipments-getting-content-level-events
title: Getting Content Level Events
tags: shipments,pro,api,tracking,events,contents
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Contents-Level Events 



---

## Contents-Level Tracking Overview

In contents-level tracking, PRO returns separate tracking events for every item of contents within the specified shipment. Contents-level tracking is useful for shipments with multiple items of contents that may ship at different times.

PRO offers two endpoints that enable you to get contents-level tracking events: 

* **Get Contents-Level Tracking Events** - Returns contents-level tracking events by unique shipment `{reference}`. 
* **Get Contents-Level Tracking Events by Custom Reference** - Returns contents-level tracking events by `{custom_reference}`. This endpoint may return tracking details for the contents of more than one shipment, because shipment `custom_references` do not need to be unique.

## Getting Contents-Level Tracking Events

Get Contents-Level Tracking Events

`GET https://api.sorted.com/pro/tracking/{shipment_reference}/shipment_contents`

> [!NOTE]
>
> * For more information on the structure of PRO shipment tracking events, see the [What Is a Tracking Event?](/pro/api/shipments/tracking_pro_shipments.html#what-is-a-tracking-event) section of the [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html) page.
> * For full reference information on the **Get Contents-Level Tracking Events** endpoint, see LINK HERE.

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