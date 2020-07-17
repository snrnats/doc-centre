---
uid: pro-api-help-shipments-managing-shipments
title: Managing Shipments
tags: shipments,pro,api
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Managing Shipments

In SortedPRO, a shipment represents a collection of goods that are to be shipped together. This section explains how to create, retrieve and edit shipments.

---

## What Is a Shipment?

In the context of PRO, the term **"shipment"** refers to a collection of one or more items that are shipped from the same origin address, to the same destination address, on behalf of the same Sorted customer, using the same carrier service, on the same day.

Each shipment object contains details of the shipment's current state (for example `ready_to_ship` or `dispatched`), its contents, and its origin and delivery addresses, alongside numerous optional properties. You can create, edit, update, and delete shipments via PRO's Shipments API.

> [!NOTE]
>
> Shipments were introduced to PRO in 2020 as an extension of the Consignment object, which was previously used to represent items being shipped together in PRO. For a comparison of shipments and consignments, see the [Consignments vs Shipments](/pro/api/shipments/consignments_vs_shipments.html) page.

## Shipments Section Contents

* [Creating Shipments](/pro/api/shipments/creating_shipments.html) - Explains how to create, clone, and update shipments.
* [Getting Shipments](/pro/api/shipments/getting_shipments.html) - Explains the various ways in which you can retrieve shipment details.
* [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html) - Explains how to use the **Cancel Shipment** endpoint to set a shipment's status to _Cancelled_.
* [Adding Paperless Documents](/pro/api/shipments/cancelling_shipments.html) - Explains how to add, retrieve, and remove a shipment's paperless documents. 
* [Shipment States](/pro/api/shipments/shipment_states.html) - Lists the various `{states}` that a shipment can assume.