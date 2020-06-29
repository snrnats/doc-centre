---
uid: pro-api-help-allocating-using-default-allocation-rules
title: Allocate Using Default Allocation Rules
tags: allocation,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Allocate Using Default Allocation Rules

To page explains how to use the **[Allocate Using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)**  and [Allocate Consignment](https://docs.electioapp.com/#/api/AllocateConsignment) endpoints to allocate consignments based on your pre-defined allocation rules.

---

## Overview

The **Allocate Using Default Rules** and **Allocate Consignments** endpoints enable you to allocate consignments to the cheapest available carrier service. PRO selects a service for you when you use these endpoints, rather than requiring you to select a service or service group manually.

PRO uses the following selection process when allocating via these endpoints:

1. **Who can deliver?** - First, PRO compiles a list of all carrier services that could potentially take the consignment (that is, configured and enabled services that ship to the delivery address and could meet any specified delivery promise).

2. **Who meets the allocation rules?** - Next, PRO creates a final shortlist of carrier services by eliminating any services that do not meet your organisation's own allocation rules. For information on using allocation rules, see the [What Is An Allocation Rule?](/pro/api/help/allocating_consignments.html#what-is-an-allocation-rule) section of the [Allocating Consignments To Carriers](/pro/api/help/allocating_consignments.html) page.

3. **Who is cheapest?** - Finally, PRO allocates the consignment to the cheapest service on the shortlist.

## Allocating Multiple Consignments at Once

The **Allocate Using Default Rules** endpoint enables you to allocate multiple consignments to the cheapest eligible carrier service in one request. 

To call **Allocate using Default Rules**, send a `PUT` request to `https://api.electioapp.com/allocation/allocate`. The request body should contain an array of one or more `{consignmentReference}`s to be allocated. 

Once the request is received, SortedPRO takes each consignment in turn and allocates it to the cheapest eligible carrier, as per the process detailed in the [Overview](#overview). It then returns an array of Allocation Summaries, one for each allocated consignment. 

> [!NOTE]
>  For full reference information on the <strong>Allocate Using Default Rules</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> page of the API reference. 

### Allocate Using Default Rules Example

The example shows a request to allocate three consignments via default rules. 

# [Allocate Using Default Rules Request](#tab/allocate-using-default-rules-request)

`PUT https://api.electioapp.com/allocation/allocate`

```json
{
  "ConsignmentReferences": [
    "EC-000-05B-MMA",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```
---

## Allocating a Single Consignment

The **[Allocate Consignment](https://docs.electioapp.com/#/api/AllocateConsignment)** endpoint allocates a single consignment to the cheapest eligible carrier service. To call **Allocate Consignment**, send a `PUT` request to `https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote`, where `{consignmentReference}` refers to the consignment you want to allocate.

Once the request has been received, SortedPRO uses the process detailed in the [Overview](#overview) to determine the appropriate service and allocate the consignment. It then returns an Allocation Summary. 

### Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05A-Z6S_ via the **Allocate Consignment** endpoint. 

# [Allocate Consignment Request](#tab/allocate-consignment-request)

```json
PUT https://api.electioapp.com/allocation/EC-000-05A-Z6S/allocatewithcheapestquote
```
---

> [!NOTE]
>
>  For full reference information on the <strong>Allocate Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignment">Allocate Consignment</a></strong> page of the API reference. 

## Next Steps

* Learn about alternative methods of allocating consignments at the [Allocating Consignments](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.