---
uid: pro-api-help-shipments-using_shipment_tags
title: Using Shipment Tags
tags: shipments,pro,api,allocation,filters,tags
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 13/07/2020
---
# Using Shipment Tags

Allocation tags are a type of allocation rule that enables you to filter the list of available carrier services on a per-shipment basis, no matter which allocation endpoints you use in your integration. They are generally used as a flexible means of excluding carrier services that would not be suitable for a particular shipment. 

Tagged shipments can only be allocated to those carrier services that have a matching tag. You can still allocate untagged shipments to a carrier service that has tags.

For example, a retailer might use the UI to add a `Flammables` tag to all the carrier services that they wanted to use for flammable products. They would then add the `Flammables` tag to all shipments containing flammable products. PRO would only allocate those shipments tagged as `Flammables` to a shipment in the pre-approved `Flammables` list.

### Configuring Allocation Tags

To tag a shipment, add the required tag into the shipment's `tags` property, either at creation or via the [Update Shipment](/pro/api/shipments/creating_shipments.html?tabs=contents-example%2Ccreate-shipment-request%2Ccreate-shipment-response%2Cexample-update-shipment-request#updating-shipments) endpoint. The `tags` property is a simple array listing all the tags that apply to the shipment.

The code sample below shows a `tags` property for a shipment that contains flammable materials, oil and alcohol.

# [Example Tags Property](#tab/example-tags-property)


```json
"Tags": [
   "Flammables",
   "Oil",
   "Alcohol"
]
```
---

### Tags Example

Suppose that you set your carrier services up in the following way:

* You tag Carrier Service A with `Alcohol`
* You tag Carrier Service B with `Flammables`
* You tag Carrier Service C with `Alcohol` and `Flammables`
* You tag Carrier Service D with `Oil`
* You don't add any tags to Carrier Service E

This configuration would produce the following results:

* **Shipment with no tags** - A B C D and E are returned
* **Shipment tagged with** `Alcohol` - A and C are returned
* **Shipment tagged with** `Flammables` - B and C are returned
* **Shipment tagged with** `Alcohol` **and** `Flammables` - C is returned
* **Shipment tagged with** `Alcohol`**,** `Flammables`**, and** `Oil` - No services are returned