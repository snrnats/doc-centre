---
uid: pro-api-help-shipments-allocating-using-filters
title: Allocating Using Filters
tags: shipments,pro,api,allocation,filters
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Allocating Using Filters

Allocate with Filters

## What Is an Allocation Tag?

<span class="highlight">ALL OF THE BELOW IS JUST TAKEN FROM THE EQUIVALENT CONSIGNMENTS DOCS AND NEEDS A FULL SHIPMENTS REWORK</span>

Allocation tags are a type of allocation rule that enables you to filter the list of available carrier services on a per-consignment basis, no matter which allocation endpoint you use in your integration. They are generally used as a flexible means of excluding carrier services that would not be suitable for a particular consignment. 

Tagged consignments can only be allocated to those carrier services that have a matching tag. You can still allocate untagged shipments to a carrier service that has tags.

For example, a retailer might use the UI to add a `Flammables` tag to all the carrier services that they wanted to use for flammable products. They would then add the `Flammables` tag to all consignments containing flammable products. PRO would only allocate those consignments tagged as `Flammables` to a consignment in the pre-approved `Flammables` list.

### Configuring Allocation Tags

To associate tags with carrier services, use the **Settings > [Carrier Services](https://www.electioapp.com/Configuration/carrierservices/) > [select carrier service] > Allocation Rules > Allocation Filtering Tags** panel of the PRO UI, as detailed in [Configuring Allocation Rules](#configuring-allocation-rules).

To tag a consignment, add the required tag into the shipment's `tags` property, either at creation or via the [Update Consignment](https://docs.electioapp.com/#/api/UpdateConsignment) endpoint. The `tags` property is a simple array listing all the tags that apply to the shipment.

The code sample below shows a `tags` property for a consignment that contains flammable materials, oil and alcohol.

<div class="tab">
    <button class="staticTabButton">Example Tags array</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'tagsExample')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="tagsExample" class="staticTabContent" onclick="CopyToClipboard(this, 'tagsExample')">

```json
"Tags": [
   "Flammables",
   "Oil",
   "Alcohol"
]
```

</div>

### Tags Example

Suppose that you set your carrier services up in the following way:

* You tag Carrier Service A with `Alcohol`
* You tag Carrier Service B with `Flammables`
* You tag Carrier Service C with `Alcohol` and `Flammables`
* You tag Carrier Service D with `Oil`
* You don't add any tags to Carrier Service E

This configuration would produce the following results:

* **Consignment with no tags** - A B C D and E are returned
* **Consignment tagged with** `Alcohol` - A and C are returned
* **Consignment tagged with** `Flammables` - B and C are returned
* **Consignment tagged with** `Alcohol` **and** `Flammables` - C is returned
* **Consignment tagged with** `Alcohol`**,** `Flammables`**, and** `Oil` - No services are returned