# Using Delivery and Pickup Options

Using delivery options enables you to offer you customers a choice of delivery slots. This section explains how to get delivery and pickup options for a consignment, and how to generate consignments and orders from the options a customer selects.

## What Is a Delivery Option?

In the context of SortedPRO, a "delivery option" for a consignment is a delivery date and time window that that consignment could potentially be delivered on, and a carrier service that could meet that delivery promise. When you request delivery options, you give PRO the details of an as-yet uncreated consignment. PRO then checks its carrier services and returns a list of available delivery slots and their associated carriers, enabling you to present these options to your customer at checkout.

PRO always returns a single carrier service for each timeslot. This is generally the cheapest service, unless using the cheapest service would conflict with existing business rules. 

For example, suppose that you use the **Delivery Options** endpoint to request delivery options for a particular consignment, and the response indicates the following:

* Carrier X could deliver the consignment on Monday between 9 and 5 or Tuesday between 9 and 12
* Carrier Y could deliver the consignment on Monday between 9 and 12 or Tuesday between 9 and 12
* Carrier Z could deliver the consignment on Monday between 9 and 1 or Monday between 1 and 5

In this case, PRO would return five delivery options:

* Carrier X Monday 9-5
* Carrier Y Monday 9-12
* Carrier Z Monday 9-1
* Carrier Z Monday 1-5
* The cheapest option between Carrier X Tuesday 9-12 and Carrier Y Tuesday 9-12

## What Is a Pickup Option?

Pickup options are similar to delivery options, except they are used to enable PUDO (pick up / drop off) services rather than home delivery.

As with delivery options, when you request pickup options, you give PRO the details of an as-yet uncreated consignment. PRO then returns a list of each pickup location that consignment could potentially be delivered to. In turn, each location contains a list of delivery options, generated using the same rules as "standard" home delivery options. This enables you to create workflows whereby you customer selects a pickup location and then either selects or is presented with a pickup date/time

## Section Contents

* **[Getting Delivery Options](/pro/api/help/getting_delivery_options.html)** - Explains how to generate delivery options for a consignment
* **[Getting Pickup Options](/pro/api/help/getting_pickup_options.html)** - Explains how to generate pickup options for a consignment
* **[Selecting Options](/pro/api/help/selecting_options.html)** - Explains how to generate either a consignment or and order from a specific option

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>