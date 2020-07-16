---
uid: pro-api-help-shipments-managing-shipment-quotes
title: Managing Shipment Quotes
tags: shipments,pro,api,quotes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Managing Shipment Quotes

SortedPRO's Quotes API enables you to get delivery quotes for a shipment manually. This section explains the various ways in which you can get delivery quotes for a shipment.

---

## What Is a Quote In PRO?

In PRO, delivery quotes are generally used outside of a "regular" shipment allocation workflow, as a means of managing shipments that require manual intervention. For example, your customer service teams might want to get quotes for an expedited delivery on a shipment that was missed by a carrier and so did not meet its delivery promise.

PRO's Quotes API enables you to get delivery quotes for as-yet uncreated shipments. All Quotes endpoints return one or more `quote` objects, of which each represents an offer for carriage of a shipment with a specific carrier service. Each quote can be uniquely identified by a `reference`, which is used when selecting a quote via the **Allocate Shipment with Quote** endpoint.

### Allocate Shipment with Quote

The **Allocate Shipment with Quote** endpoint is a key part of all PRO quotes workflows, enabling you to allocate a shipment to the carrier service returned in a particular quote. It is covered in the **Allocation** section of this site, as it is part of the Allocation API:

> [!NOTE]
> * For reference information on **Allocate With Quote**, see LINK HERE
> * For a user guide on the **Allocate With Quote** endpoint, see the [Allocating with a Quote](/pro/api/shipments/allocating_via_a_quote.html) page, in the **Allocating Shipments** section.

## Section Contents

* [Creating Quotes](/pro/api/shipments/creating_shipment_quotes.html) - Explains how to get delivery quotes for an as-yet uncreated shipment.
* [Getting Shipment Quotes](/pro/api/shipments/getting_shipment_quotes.html) - Explains how to get delivery quotes for an existing shipment.