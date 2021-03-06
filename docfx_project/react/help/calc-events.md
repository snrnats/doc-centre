---
uid: react-help-calc-events
title: Calculated Events
tags: react,api,calculated events,events
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Calculated Events

REACT's Calculated Events feature helps you to stay on top of shipments that may have gone missing, or which have passed their delivery promise date. This page explains the shipment properties that REACT can calculate, how calculated events work, and how best to use calculated events

---

## What is a Calculated Event?

A calculated event is an event that is generated by REACT's internal processing, rather than as a result of an external tracking update. 

Each shipment has two properties that REACT can change without receiving a carrier tracking update. They are:

* `may_be_missing` - Indicates whether REACT believes that the shipment may be missing. REACT marks shipments as `may_be_missing` if they are not updated within a set time period after registration, or if they are not marked as delivered, lost, or refused within a different set time period. 
* `lateness`. Contains two sub-properties - `lateness.is_late` and `lateness.hours_late`. These properties indicate whether REACT believes a shipment to be late, and (where applicable) how many hours late this shipment is. 

When REACT updates one of these properties, it creates a calculated event to record the change. You can retrieve calculated events in the same way you would retrieve regular, carrier-derived events.

> [!NOTE]
>
> For more information on retrieving events, see the [Retrieving Shipment and Event Data](/react/help/retrieving-data.html) page of the docs portal, and the [Get Shipment Events](https://docs.sorted.com/react/api/#GetShipmentEvents) section of the API reference.

## May Be Missing

If REACT believes that a shipment may be lost, it sets that shipment's `may_be_missing` property to _true_. By default, the `may_be_missing` property is set to _false_. 

> [!CAUTION]
>
> `may_be_missing` is always set based on REACT's internal calculations. A `may_be_missing` value of _true_ does not mean that the carrier has notified Sorted that the shipment may be missing.

REACT sets a shipment's `may_be_missing` property to _true_ if either of the following conditions are met:

**Condition 1**

No state changing tracking event has been received for that shipment within 12 hours of the shipment being registered with REACT (as recorded in the `created_on` property) **OR** within 12 hours of the `shipped_date` (whichever is earlier). Note that `shipped_date` is an optional field.

**Condition 2**

All of the following conditions are met:

* The shipment has never been in any of the [final states](/react/help/calc-events.html#final-states).
* The shipment has a country ISO code registered for both its origin and destination addresses (via the `addresses.country_iso_code` property).
* It has been more than 24 hours since a tracking event was received for a domestic shipment, **OR** more than 72 hours since a tracking event was received for an international shipment. 

Shipments are classed as domestic if their origin and destination `addresses.country_iso_code` is identical. Otherwise, they are classified as international.

## Late 

The `lateness.is_late` property denotes whether REACT believes a shipment to be late. By default, the `is_late` property is set to _false_. REACT sets `is_late` to _true_ if all of the following conditions are met:

* The shipment has a `promised_date` recorded. 
* The date and time recorded in `promised_date` has elapsed.
* The shipment did not enter any of the [final states](/react/help/calc-events.html#final-states) before the `promised_date` elapsed.

If a shipment does not have a `promised_date` recorded, then REACT cannot perform `lateness` calculations for that shipment. 

If a shipment is marked as late, then REACT records how many hours late it is in the `lateness.hours_late` property. This information is refreshed every time the shipment is retrieved from the Tracking, Shipment or Events APIs.

The `is_late` flag is reset if the shipment is updated with new `promised_date` information (as long as the new `promised_date` has not also already elapsed). If `is_late` is reset to _false_, then `hours_late` is reset to NULL. 

> [!NOTE]
>
> The `is_late` shipment property should not be confused with the _Late_ shipment state. Like all other shipment states, the _Late_ shipment state is assigned on the basis of a carrier tracking event that REACT has received. Simply put, the `is_late` property is used when REACT notices a shipment is late, while the _Late_ shipment state is used when a carrier tells Sorted that the shipment is late. 

### Trackable Shipments

To optimise performance, REACT periodically marks old shipments as "non-trackable". The system only performs `may_be_missing` and `lateness` calculations on trackable shipments.

A shipment is deemed to be non-trackable if any of the following criteria are met:

* The shipment is domestic (i.e. the `addresses.country_iso_code` of its origin and destination addresses is identical) **AND** Sorted has not received a tracking event for it in seven or more days.
* The shipment is international (i.e. the `addresses.country_iso_code` of its origin and destination addresses is different) **AND** Sorted has not received a tracking event for it in 10 or more days.
   > [!NOTE]
   >
   > If Sorted do not know whether a shipment is domestic or international (that is, it does not have a `addresses.country_iso_code` recorded for both its origin and destination addresses), then it is assumed to be domestic.
* The shipment is in a [final state](/react/help/calc-events.html#final-states) **AND** Sorted has not received a tracking event for it in three or more days.

## Final States

REACT uses "final shipment states" when determining whether shipments are lost or potentially missing. The list of final states covers all the potential outcomes for a shipment delivery. Once a shipment enters a final state, its journey is considered to have ended and REACT no longer tracks it.

The full list of final states is:

* delivered  
* delivered_damaged  
* delivered\_to_neighbour  
* delivered\_to_reception  
* delivered\_to\_safe_location  
* destroyed  
* lost
* carrier\_refused\_to_collect  
* carrier\_unable\_to_collect  
* delivered  
* delivery_failed  
* delivery\_failed\_card_left  
* delivery_refused  
* delivery_rescheduled  
* exchange_failed  
* partially_delivered  
* proof\_of\_delivery_available  
* ready\_for_collection

## Using Calculated Properties

Although set by REACT, the `lateness` and `may_be_missing` flags are standard properties and can be integrated in exactly the same way as any other shipment data. They are returned by the Shipments and Events APIs,as part of the Shipment and Shipment Events resources.

> [!NOTE]
>
> For more information on retrieving data via REACT's APIs, see the [Retrieving Shipment and Event Data](/react/help/retrieving-data.html) page.

## Viewing Calculated Properties in the UI

The UI's **Calculated Events** dashboard displays the number of your shipments that REACT has flagged as _Late_ or _May Be Missing_. To open the **Calculated Events** dashboard, select the **Dashboards > Calculated Events** menu option.

![calc-events-dash](images/calc-events-dash.png)

> [!NOTE]
>
> For more information on monitoring shipments in the REACT UI, see the [Monitoring Shipments](/react/help/monitoring-shipments.html) page.

## Next Steps

Learn more about integrating with REACT:

* [Registering Shipments](/react/help/registering-shipments.html)
* [Updating Shipments](/react/help/updating-shipments.html)
* [Error Codes](/react/help/error-codes.html)