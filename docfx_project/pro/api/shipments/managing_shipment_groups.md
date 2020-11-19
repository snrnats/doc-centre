---
uid: pro-api-help-shipments-managing-shipment-groups
title: Managing Shipment Groups
tags: shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Managing Shipment Groups

Shipment groups enable you to perform manifest operations on a number of shipments at once. This section explains how to create, edit and use shipment groups.

---
## What is a Shipment Group?

In SortedPRO, a shipment group is a collection of one or more shipments, all of which must be allocated with the same carrier service. PRO enables you to manifest all shipments in a group simultaneously, as well as getting a collection note for the entire shipment group.

Shipment groups enable you to align your manifest processes with your operational flows. For example, suppose that you allocate 500 shipments to a particular carrier and your distribution centre places those shipments into a cage to be loaded onto the carrier's outbound trailer. By creating a shipment group corresponding to that carrier's cage and then adding the relevant shipments to it, you could manifest all the shipments that the carrier will take on that trailer in a single API call.

## Section Contents

* [Creating Shipment Groups](/pro/api/shipments/creating_shipment_groups.html) - Explains how to use the **Create Shipment Group** endpoint to create new shipment groups.
* [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html) - Explains how to retrieve existing shipment groups.
* [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html) - Explains how to edit existing shipment groups, add and remove shipments from a group, and lock groups so that they cannot be edited.
* [Closing Shipment Groups](/pro/api/shipments/closing_shipment_groups.html) - Explains how to close shipment groups.

