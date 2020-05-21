# Consignments vs Shipments

PRO's new Shipments model represents a significant overhaul to PRO, with a new data contract and UI enabling the system to offer enhancements such as on-demand shipping, auto-manifesting, and bulk grouping of shipments. This page is intended for users who are familiar with the older Consignments model, explaining what has changed and how the new system works.

---

## How Does On-Demand Shipping Work?

The consignments model was based around high volume shipping from warehouses to end consumers. In this model, PRO could ship thousands of items for a customer daily, with carriers making regular scheduled collections from a small number of fulfilment centres before taking the goods to their own hubs and then shipping out to the end customer.

In order to ship a consignment, PRO requires a shipping location and a scheduled collection datetime.

<img src="/pro/images/consignments-workflow.png" class="noborder"/>

<p class="text--center text--bold">Consignments Workflow</p>

Shipments extends this functionality, giving you greater control over the collection part of the delivery cycle. PRO can now offer ad-hoc collections and deliveries from distributed stock locations, such as a ship-from-store model. 

On-demand shipping enables you to be more flexible in the way that goods are collected, and helps you to avoid the risk that warehousing from a single location can bring in a modern retail environment. Shipments gives you the ability to run thousands of shipping locations all over the world, and to ship from any of them,

<img src="/pro/images/shipments-workflow.png" class="noborder"/>

<p class="text--center text--bold">Shipments Workflow</p>

However, PRO hasn't lost any functionality. Shipments can also handle high volume traditional scheduled shipments just as well as consignments. 

## New Features

As well as support for on-demand shipping, the enhancements to PRO's data contract have enabled us to add several additional new features to PRO. Shipments also includes:

* **Shipment Groups and Collection Notes** – A shipment group is a group of one or more shipments, booked with the same carrier service, that can be operated on together. Grouping shipments fulfils several workflow needs, such as letting a driver use a collection note to sign off the shipments he’s just collected from a store, or grouping and manifesting shipments by trailer in a warehouse.
* **Auto-Manifest** - PRO can now automatically manifest shipments with carriers using a pre-configured schedule – you don't need to make an API call to tell it when to manifest
* **REACT Powered Tracking** - PRO now uses Sorted's REACT product as its core tracking engine, offering improved tracking functionality including push notifications and easy-to-configure tracking pages.
* **Dangerous Goods** – PRO's Dangerous Goods functionality has been completely overhauled, enabling you to use custom rulesets to configure which carrier services can carry which types of dangerous goods. This is especially useful if you have have non-standard agreements with carriers.
* **Label Extension** - PRO now offers improved support for label extensions, including enabling you to select whether you want standard or extended labels are part of your API call.
* **Customs Documents** -  PRO's customs document generation engine has been overhauled to make it more efficient and scalable.


## Shipment Structure

To facilitate these changes, the _shipment_ has replaced the _consignment_ as PRO's basic delivery unit. Like consignments, shipments are a collection of one or more packages that are shipped from the same origin address, to the same destination address, on behalf of the same Sorted customer, using the same carrier service, on the same day. However, shipments 

* required / expected delivery dates
* order date
* shipment type field - Enables you to specify which type(s) of carrier service to use when retrieving quotes or allocating a shipment.
* contents - All shipments in SortedPRO require at least one shipment_contents object. This object represents the contents of the shipment.
* reservations - PRO can now store the details of reservations,  such as those for click and collect options. 
