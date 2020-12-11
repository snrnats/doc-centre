---
uid: pro-api-help-shipments-managing-shipments
title: Managing Shipments
tags: v2,shipments,pro,api,v2
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Managing Shipments

In SortedPRO, a _shipment_ represents a collection of goods that are to be shipped together. This section explains how to create, retrieve and edit shipments.

> [!NOTE]
> This page provides help and support for PRO version 2 (Shipments). As PRO v2 is currently in development, content may be removed or edited without warning.
>
> For support on PRO v1 (Consignments), [click here](/pro/api/help/introduction.html).  

---

## What Is a Shipment?

In the context of PRO, the term _"shipment"_ refers to a collection of one or more items that are shipped from the same origin address, to the same destination address, on behalf of the same Sorted customer, using the same carrier service, on the same day.

Each shipment object contains details of the shipment's current state (for example `ready_to_ship` or `dispatched`), its contents, its origin address, and its delivery address, alongside numerous optional properties. You can create, edit, and delete shipments via PRO version 2's Shipments API.

> [!NOTE]
>
> Shipments were introduced to PRO in v2 as an extension of the Consignment object, which was used in v1 to represent items being shipped together. For a comparison of shipments and consignments, see the [Consignments vs Shipments](/pro/api/shipments/consignments_vs_shipments.html) page.

## Shipments Section Contents

* [Creating Shipments](/pro/api/shipments/creating_shipments.html) - Explains how to create shipments.
* [Getting Shipments](/pro/api/shipments/getting_shipments.html) - Explains how to retrieve shipment details.
* [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html) - Explains how to cancel and delete existing shipments.
* [Adding Paperless Documents](/pro/api/shipments/adding_paperless_documents.html) - Explains how to add and retrieve a shipment's paperless documents. 
* [Changing Shipment States Manually](/pro/api/shipments/changing_shipment_states_manually.html) - Explains how to place shipments into a particular state manually.
* [List of Shipment States](/pro/api/shipments/shipment_states.html) - Lists the various states that a shipment can assume.