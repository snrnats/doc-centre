# Tracking Consignments

SortedPRO's Tracking API enables you to drive embedded delivery tracking from your own website, without the need to pass customers off to a carrier portal. This page explains how to use the Tracking API to get updates on a consignment's progress.

---

## Tracking API Overview

PRO's Tracking API has three endpoints:

* **Get Tracking Events** - Returns full tracking event information for a specific consignment, including separate details for each leg of a shipment.
* **Get Events Per Package** - Returns flattened tracking event information for a specific consignment, broken down by package. Does not take multiple legs into account.
* **Post Tracking Events** - Enables carriers to post events directly to PRO.

> <span class="note-header">Note:</span>
>
> The **Post Tracking Events** endpoint is intended for carrier use only, and is outside the scope of this documentation.

## What Is A Tracking Event?

<spnas class="highlight">ADD MORE TO THIS!</span>

PRO tracking events contain the following properties:

* `TimeStamp` - The time and date that the tracking event occurred
* `Code` - A unique identifier for the type of tracking event
* `Description` - A description of the tracking event
* `SignedBy` - The name of the person who signed for the package (if applicable)
* `Location` - The location of the tracking event

## Getting Multi-Leg Tracking Events

To call **Get Tracking Events**, send a `GET` request to `https://api.electioapp.com/tracking/{consignmentReference}`. 

PRO responds with a `TrackedPackages` array, containing details of all the tracked packages in the consignment. Each package contains an array of `Legs`, of which each contains tracking `Events` for that particular leg of the package's journey.

> <span class="note-header">Note:</span>
>
> 

## Getting Single Leg Tracking Events



## Using Tracking Events



## Next Steps



<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>