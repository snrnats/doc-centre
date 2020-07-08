---
uid: pro-api-help-shipments-allocating-shipments
title: Allocating Shipments
tags: shipments,pro,api,allocation
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Allocating Shipments

Once you've created a shipment, you'll need to allocate it to a carrier service. This section explains how to configure allocation rules that PRO can use when selecting carrier services, and the various methods you can use to allocate shipments to those services.

---

## What Is Allocation?

In the context of SortedPRO, **allocation** is the process of selecting the carrier service that will be used to deliver a shipment. Allocation is a key part of all PRO workflows, as a shipment cannot be shipped if it has not previously been allocated to a suitable carrier service.

> [!NOTE]
>
> You can only allocate shipments that are in a `{state}` of either _unallocated_ or _allocation_failed_. If you attempt to allocate a shipment that is not in one of those states, PRO returns an error.

<span class="highlight">THE ABOVE IS A CONSIGNMENTS RULE BUT I'M GUESSING THAT THIS IS STILL THE CASE. CAN'T SEE ANY OTHER STATES ON THE LIST THAT YOU WOULD BE ABLE TO ALLOCATE FROM</span>

To allocate shipments in PRO, you'll need to call one of PRO's allocation endpoints. You can specify a carrier service or service group to allocate to, allocate based on a quote you received, or have PRO select the cheapest eligible carrier service for you. You can also use custom filters to narrow down the pool of available services on a per-shipment basis. Whichever endpoint you use, PRO uses pre-defined allocation rules to ensure that your shipment is allocated to a suitable carrier service.

PRO offers the following allocation endpoints:

* **Allocate Shipment**

    `https://api.sorted.com/pro/shipments/{reference}/allocate` - Allocates a single shipment using your default allocation rules.
* **Allocate Shipments**

    `https://api.sorted.com/pro/shipments/allocation` - Allocates multiple shipments using your default allocation rules. 
* **Allocate Shipment with Carrier Service**

    `https://api.sorted.com/pro/shipments/{reference}/allocate/service/{service_ref}` - Allocates a single shipment with a specific carrier service.
* **Allocate with Carrier Service**

    `https://api.sorted.com/pro/shipments/allocation/service` - Allocates multiple shipments with a specific carrier service.
* **Allocate Shipment with Service Group**

    `https://api.sorted.com/pro/shipments/{reference}/allocate/service_group/{group_ref}` - Allocates a single shipment with a carrier service from a specific carrier service group.
* **Allocate with Service Group**

    `https://api.sorted.com/pro/shipments/allocation/service_group` - Allocates multiple shipments with a carrier service from a specific carrier service group.
* **Allocate with Virtual Service**

    `https://api.sorted.com/pro/shipments/{reference}/allocate/virtual_service/{virtual_service_reference}` - Allocates a single shipment with a virtual service. <span class="highlight">NEED A PROPER DEFINITION OF VIRTUAL SERVCIE IN HERE</span>   
* **Allocate with Filters**
    
    `https://api.sorted.com/pro/shipments/allocation/filters` - Allocates one or more shipments with a carrier service that matches the specified filters. 
* **Allocate Shipment with Quote**

    `https://api.sorted.com/pro/shipments/allocate/{reference}/quote/{quote_reference}` - Allocates a single shipment with the carrier service referenced in a specific pre-existing quote.

The action PRO takes once the allocation request is received depends on the type of endpoint you used. If you used an endpoint that allocated individual shipments, then PRO allocates the shipment immediately and returns an Allocation Summary listing details of the allocation, such as prices, dates and tracking information. However, if you used an endpoint that can allocate multiple shipments at once, then PRO queues the shipments for allocation at a later time in order to maintain performance. When PRO queues shipments, it returns an Allocate Shipments Result confirming the shipments that were queued.

When a shipment is allocated to a carrier service, its status changes to _allocated_, enabling you to retrieve its package labels and (where applicable) customs documentation.

## What Is an Allocation Rule?

When you make an allocation request for a shipment, PRO uses its allocation rules to ascertain which carrier services are eligible to take that shipment and which are not. Allocation rules are optional criteria that define the shipments that a particular carrier service is eligible to take. You can specify the following:

* Maximum and minimum dimensions and weight
* Maximum monetary value
* Excluded UK postcode areas
* Excluded countries
* Allocation tags.

<span class="highlight">LIST TAKEN FROM CONSIGNMENTS HELP. NEEDS CHECKING IN NEW UI</span>

For example, you could specify that a particular carrier service should only be allocated shipments that weigh between 1-25 Kg. Subsequently, PRO would not consider this service when allocating a shipment with a weight of 30Kg.

### Configuring Allocation Rules

<span class="highlight">INSTRUCTIONS ON CONFIGURING RULES IN NEW UI IN HERE</span>

### Configuring Dangerous Goods Rules

PRO enables you to manage which carrier services can carry which types of dangerous goods by setting up "dangerous goods rulesets" in the UI. This is a change from the original PRO's consignments-based implementation, in which dangerous goods specifications were directly tied in to each carrier service.

When setting up dangerous goods rules, you configure a ruleset independently of any carrier services and then link those rules to the services you require. This is especially useful if you have non-standard agreements with your carriers (that is, carriers will allow you to ship dangerous goods on a carrier service that would not normally take that class of goods).

When allocating shipments, PRO takes your dangerous goods rulesets into account as part of its allocation rule checks. Any service that does not meet the rules is excluded.

<span class="highlight">INSTRUCTIONS FOR SETTING UP RULESETS IN HERE (WHEN IT'S IN THE UI)</span>

> [!TIP]
>
> When you allocate an `on-demand` shipment, PRO automatically books a collection as a background process. You do not need to specify `on_demand` booking details manually.

## Allocation Section Contents

* [Allocating to Default Rules](/pro/api/shipments/allocating_to_default_rules.html) - Explains how to allocate shipments based on custom business rules.
* [Allocating with a Specific Carrier Service](/pro/api/shipments/allocating_with_a_specific_carrier_service.html) - Explains how to allocate shipments with a specific carrier service.
* [Allocating Within a Carrier Service Group](/pro/api/shipments/allocating_within_a_carrier_service_group.html) - Explains how to allocate shipments with a carrier service from a specific carrier service group.
* [Allocating with a Virtual Service](/pro/api/shipments/allocating_with_a_virtual_service.html) - Explains how to allocate a shipment with a virtual service.
* [Allocating Using Filters](/pro/api/shipments/allocating_using_filters.html) - Explains how to use filters to specify allocation rules on a per-shipment basis. 
* [Allocating via a Quote](/pro/api/shipments/allocating_via_a_quote.html) - Explains how to allocate a shipment with the carrier service referenced in a specific pre-existing quote.