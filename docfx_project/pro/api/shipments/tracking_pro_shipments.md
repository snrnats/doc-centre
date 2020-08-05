---
uid: pro-api-help-shipments-tracking-pro-shipments
title: Tracking PRO Shipments
tags: shipments,pro,api,tracking
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Tracking PRO Shipments

SortedPRO's tracking features enable you to provide package tracking updates for your customers without having to pass them off to a carrier portal. This section explains how to use PRO's built-in tracking endpoints.

> [!NOTE]
> Sorted's dedicated tracking product, REACT, enables you to provide a richer tracking experience to your customers. For more information on using REACT, see the [REACT](/react/index.html?v2) section.

---

## PRO Shipment Tracking Overview

PRO's Tracking API is intended to drive simple web-based tracking pages. When the API is called, PRO returns a response listing the tracking events that have occurred since that shipment was dispatched. Tracking events are informational messages returned from carriers that provide details about the status of the consignment. For example, a shipment being picked up by a carrier would generate a `collected_by_carrier` event for that shipment. You can then display the information returned to your customers through your site.

PRO enables you to get tracking events at either shipment or (where supported by the carrier) contents level: 

* In shipment-level tracking, PRO returns tracking events for the entire shipment, without making a distinction between individual items of contents within that shipment. <span class="highlight">WHAT DOES IT DO WHEN THERE ARE MULTIPLE ITEMS OF CONTENTS SHIPPING INDEPENDENTLY? DOES IT JUST DISPLAY THE MOST RECENT?</span>
* In contents-level tracking, PRO returns separate tracking events for every item of contents within the specified shipment.

In addition, PRO enables you to get tracking events by both a shipment's PRO-generated unique `{reference}` or its user-defined `{custom_reference}`. Getting tracking information by `{custom_reference}` means that you can track shipments using your own internal references (assuming that you have added those references to your shipments as `custom_references`). 

> [!NOTE]
> Because shipment `custom_references` do not need to be unique, PRO's endpoints that return tracking information by custom reference may return details of more than one shipment.

In total, PRO has four in-built shipment tracking endpoints:

* **Get Tracking Events** - Returns shipment-level tracking events by unique shipment `{reference}`.
* **Get Tracking Events by Custom Reference** - Returns shipment-level tracking events by `{custom_reference}`.
* **Get Content-Level Tracking Events** - Returns contents-level tracking events by unique shipment `{reference}`. 
* **Get Content-Level Tracking Events by Custom Reference** - Returns contents-level tracking events by `{custom_reference}`. 

## Section Contents

* [Getting Shipment Events](/pro/api/shipments/getting_shipment_events.html) - Explains how to use the **Get Tracking Events** and **Get Tracking Events by Custom Reference** endpoints.
* [Getting Content-Level Events](/pro/api/shipments/getting_content_level_events.html) - Explains how to use the **Get Content-Level Tracking Events** and **Get Content-Level Tracking Events by Custom Reference** endpoints.