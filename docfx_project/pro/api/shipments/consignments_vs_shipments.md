---
uid: pro-api-help-shipments-consignments_vs_shipments
title: Consignments vs Shipments
tags: shipments,pro,api,getting started,consignments,v1
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Consignments vs Shipments

PRO version 2's Shipments model represents a significant overhaul to the Sorted service, with a new data contract and UI enabling the system to offer enhancements such as on-demand shipping and bulk grouping of shipments. This page is intended for users who are familiar with the Consignments model used in version 1, explaining what has changed and how the new system works.

---

## How Does On-Demand Shipping Work?

PRO v1's Consignments model was based around high volume shipping from warehouses to end consumers. In this model, PRO could ship thousands of items for a customer daily, with carriers making regular scheduled collections from a small number of fulfilment centres before taking the goods to their own hubs and then shipping out to the end customer.

In order to ship a consignment in a scheduled workflow, PRO requires a shipping location and a scheduled collection datetime. An example scheduled workflow is given below:

![consignments-workflow.png](/pro/images/consignments-workflow.png)

PRO v2's Shipments model extends this functionality, giving you greater control over the collection part of the delivery cycle. PRO can now offer ad-hoc collections and deliveries from distributed stock locations, such as a ship-from-store model. 

On-demand shipping enables you to be more flexible in the way that goods are collected, and helps you to avoid the risk that warehousing from a single location can bring in a modern retail environment. PRO v2 gives you the ability to ship from thousands of locations all over the world.

![shipments-workflow.png](/pro/images/shipments-workflow.png)

However, PRO hasn't lost any functionality. The PRO v2 API suite can also handle high volume traditional scheduled shipments just as well as v1. 

## New Features

As well as support for on-demand shipping, the enhancements to PRO's data contract have enabled us to add several additional new features to PRO. The PRO v2 API suite also includes:

* **Shipment Groups and Collection Notes** – A shipment group is a group of one or more shipments, allocated to the same carrier service, that can be operated on together. Grouping shipments fulfils several workflow needs, such as letting a driver use a collection note to sign off the shipments they've just collected from a store or manifesting shipments by trailer in a warehouse.            
* **Auto-Manifest** - PRO can now automatically manifest shipments with carriers using a pre-configured schedule.
* **REACT Powered Tracking** - PRO now uses Sorted's REACT product as its core tracking engine, offering improved tracking functionality including push notifications and easy-to-configure tracking pages.
* **Dangerous Goods** – PRO's Dangerous Goods functionality has been completely overhauled, enabling you to use custom rulesets to configure which carrier services can carry which types of dangerous goods. This is especially useful if you have have non-standard agreements with carriers.
* **Label Extension** - PRO now offers improved support for label extensions, including the option to select whether you want standard or extended labels are part of your API call.
* **Customs Documents** -  PRO's customs document generation engine has been overhauled to make it more efficient and scalable.

## Shipment Structure

To facilitate these changes, the _shipment_ has replaced the _consignment_ as PRO's basic delivery unit in v2. 

> [!NOTE]
>
> Currently, PRO v1 customers will need to re-integrate in order to use the features introduced in PRO v2. To aid this process, we have designed the v2 API suite as an extension and enhancement to v1, keeping it as close as possible to the original structure. 

Like consignments, shipments are a collection of one or more packages that are shipped from the same origin address, to the same destination address, on behalf of the same Sorted customer, using the same carrier service, on the same day. However, the `shipment` object contains some new and reworked properties, including:

* `shipment_type` - Enables you to specify whether the shipment is intended to be allocated with an on-demand service or a scheduled service. This property affects PRO's validation when creating a shipment (as `on_demand` shipments have different mandatory properties to `scheduled` shipments) and the carrier services that the shipment can be allocated to.
* `shipment_contents` - The nested `package` and `item` objects used in consignments have been replaced by a list of `contents` objects. Each `contents` object represents an item within the shipment. For example, a shipment of a pair of shoes would contain one `contents` object defining the properties of the pair of shoes (e.g. dimensions, weight, etc.).
* `contents.dangerous_goods` - The new `dangerous_goods` object enables you to give significantly more detail on the nature of dangerous goods than the previous implementation, including physical form, radioactivity levels, accessibility during transit, and the class division of the goods according to the IATA standards.
* `contents.label_property` - Provides additional properties to be placed on the shipment's label. SortedPRO supports custom label decorators, which utilise additional label space to add fields and text. 
* `reservation` - The `reservation` object enables PRO to store the details of reservations, such as booking details for click and collect options.

> [!NOTE]
>
> For full reference information on the PRO v2 data contract, see the [API reference](/pro/api/reference/shipments-api-ref.html). 

## Next Steps

* Learn how to create, update and delete shipments: [Managing Shipments](/pro/api/shipments/managing_shipments.html)
* Learn how to allocate shipments to carrier services: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)
* Learn how to create shipment groups: [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) 