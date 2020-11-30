---
uid: pro-api-help-shipments-allocating-using-filters
title: Allocating Using Filters
tags: v2,shipments,pro,api,allocation,filters
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Allocating Using Filters

SortedPRO's allocation filters enable you to select a carrier service that meets a particular list of criteria. This page explains PRO's allocation filters and how to use them.

---

## Making an Allocate with Filters Request

The **Allocate with Filters** endpoint enables you to specify a list of shipments and a set of allocation criteria. When you make an **Allocate with Filters** request, PRO attempts to allocate all shipments in the list to a carrier service that meets the filters you specified. 

To call **Allocate with Filters**, send a `PUT` request to `https://api.sorted.com/pro/shipments/allocation/filters`. The body of the request should contain a `shipments` property listing the shipment `{reference}`s of the shipments you want to allocate, and a `filters` property defining the criteria you want to use to select a service. PRO accepts the following allocation filters:

* `direction` - The direction of the carrier services. Can be either `inbound` or `outbound`.
* `pickup` - A boolean value indicating whether to include pick-up services.
* `drop-off` - A boolean value indicating whether to include drop-off services.
* `tags` - A list of allocation tags to include, up to a maximum of 10. Any services that do not match all of the specified tags are excluded.

> [!NOTE]
> For more information on allocation tags, see the [Using Shipment Tags](/pro/api/shipments/using_shipment_tags.html) page.

`direction` is mandatory, but all other properties are optional.

## The Allocate with Filters Response

Once the request is received, PRO uses the filters provided to determine a list of available carrier services for the shipments to be allocated to. It then takes each shipment in the list and allocates it to a suitable service using the process defined in the [Selecting a Carrier Service](/pro/api/shipments/allocating_shipments.html#selecting-a-carrier-service) section of the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.

<!-- Finally, PRO returns a  

<span class="commented-out">SKIPPING THE REST OF THIS OF NOW AS THERE ARE SOME INCONSISTENCIES IN THE DATA CONTRACT - THE REQUEST FILTERS AVAILABLE CARRIER SERVICES BUT THE RESPONSE IMPLIES THAT IT'S THE SHIPMENTS FOR ALLOCATION BEING FILTERED</span>

## Allocate with Filters Example -->

## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to manifest shipments: [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html)
* Learn how to create shipment groups: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)