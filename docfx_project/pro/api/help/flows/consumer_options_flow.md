---
uid: pro-api-help-flows-consumer-options-flow
title: Consumer Options Flow
tags: pro,api,consignments,flows,options,delivery
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Consumer Options Flow

<p>
   <a href="../../../images/Flow2.png" target="_blank" >
      <img src="../../../images/Flow2.png" class="noborder"/>
   </a>
</p>

The **Consumer Options** flow enables you to provide real-time delivery choices - including delivery date, time, and carrier brand - to your customer at point of purchase. After the customer has chosen their preferred option, PRO can create a consignment based on their details, and allocate that consignment to a carrier service based on the customers choice.

> [!NOTE]
>
> Access to PRO's delivery and pickup option endpoints requires a SortedHERO license. This component is sold separately to the main SortedPRO product. 

The **Consumer Options** flow is most useful to your business if:

* You want to present your customer with a dynamic checkout that offers delivery timeslot options.
* You operate a single warehouse / fulfilment centre.
* You develop and configure your own e-commerce platform.

There are four steps to the flow:

1. **Get delivery options** - Use the [Delivery Options](https://docs.electioapp.com/#/api/DeliveryOptions) endpoint to request a list of available delivery options for the (as yet uncreated) consignment that the customer's order will generate.
2. **Select delivery option** - Use the [Select Option](https://docs.electioapp.com/#/api/SelectOption) endpoint to tell PRO which option the customer selected. At this point, PRO has all the information it needs to create and allocate a consignment.
3. **Get the consignment's labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignment.
4. **Manifest the consignment** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to send consignment data to the selected carrier.

This section gives more detail on each step of the flow and provides worked examples. 

---

## Step 1: Getting Delivery Options

[!include[_getting_delivery_options](../../includes/_getting_delivery_options.md)]

---

## Step 2: Selecting a Delivery Option

[!include[_select_option](../../includes/_select_option.md)]

---

## Step 3: Getting a Package Label

[!include[_get_labels_in_format](../../includes/_get_labels_in_format.md)]

---

## Step 3b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 4: Manifesting the Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]

## Next Steps

The next section explains a similar call flow that enables you to offer pickup options (aka click-and-collect) rather than home delivery timeslots.
