---
uid: pro-api-help-flows-classic-flow
title: Classic Flow
tags: pro,api,consignments,flows,classic
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 07/05/2020
---
# Classic Flow

<p>
   <a href="../../../images/Flow1.png" target="_blank" >
      <img src="../../../images/Flow1.png" class="noborder"/>
   </a>
</p>

Creating a new consignment, allocating it to a suitable carrier service, and then adding it to that service's manifest is perhaps PRO's most basic use case. The **Classic** call flow offers the lightest integration design of all PRO flows, making it easy for your organisation to manage deliveries across multiple carriers.

The **Classic** flow is most useful to your business if:

* You have a single warehouse / fulfilment centre.
* You use a static delivery promise (e.g. Next day delivery before 5pm).
* You want to keep your business logic and technology architecture as simple as possible.

There are four steps to the flow:

1. **Create the consignment** - Use the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) endpoint to record the details of your new consignment.
2. **Allocate the consignment** - Use one of PRO's [Allocation](https://docs.electioapp.com/#/api/AllocateConsignment) endpoints to select the carrier service that your consignment will use. You can nominate a specific service, ask PRO to determine the best service to use from a pre-defined group, or allocate based on pre-set allocation rules.
3. **Get the consignment's labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignment.
4. **Manifest the consignment** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to send consignment data to the selected carrier.

This section gives more detail on each step of the flow and provides worked examples.

---

## Step 1: Creating Consignments

[!include[_create_consignments](../../includes/_create_consignments.md)]

---

## Step 2: Allocating Consignments

[!include[_allocating](../../includes/_allocating.md)]

---

### Allocating using Default Rules

[!include[_allocate_using_default_rules](../../includes/_allocate_using_default_rules.md)]

---

### Allocating from a Service Group

[!include[_allocate_with_service_group](../../includes/_allocate_with_service_group.md)]

---

### Allocating to a Specific Carrier Service

[!include[_allocate_with_carrier_service](../../includes/_allocate_with_carrier_service.md)]

---

## Step 3: Getting Package Labels

[!include[_get_labels_in_format](../../includes/_get_labels_in_format.md)]

---

## Step 3b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 4: Manifesting a Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]

## Next Steps

And we're done! Read on to learn how to allocate consignments based on options presented to the customer at point of purchase, and deal with orders that may require multiple consignments to fulfil.
