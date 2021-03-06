---
uid: pro-api-help-flows
title: PRO Call Flows
tags: consignments,pro,api,flows
contributors: andy.walton@sorted.com
created: 28/02/2020
---
# PRO Call Flows

Ready to get started with SortedPRO? This guide explains some common use cases for PRO's APIs, helping you to see what PRO can do for your business.

We will cover:

* **Creating and manifesting a consignment**

   The **[Classic](./flows/classic_flow.md)** flow is a simple flow to create a consignment, allocate it to a carrier service using criteria of your choosing, retrieve delivery labels, and confirm the delivery with the carrier. 

* **Offering and using delivery options**

   The **[Consumer Options](./flows/consumer_options_flow.md)** flow is used when you want to present delivery options to your customer at point of purchase. PRO creates and allocates consignments based on the options the customer selects.

* **Offering and using pickup options**

   The **[Consumer Options Pickup](./flows/consumer_options_pickup_flow.md)** flow is similar to the **Consumer Options** flow, but used when offering delivery to a pickup/drop-off (PUDO) location rather than home delivery. 

* **Creating a pack order flow from a PRO order**

   The **[Order Flex](./flows/order_flex_flow.md)** flow is used when you can't guarantee that all parts of a customer's order will be picked, packed and dispatched from the same place at the same time. PRO can generate multiple consignments from a single customer order where required.

* **Obtaining and selecting delivery quotes**

   The **[Quotes](./flows/quotes_flow.md)** flow is used to obtain a full list of potential delivery services for a consignment. It is often used to validate a consignment's detail or to enable a customer service operator to get manual quotes for a customer.

> [!NOTE]
> This guide is intended as a primer for PRO. If you're already familiar with the basics of PRO, or you just need reference info for PRO's APIs, see the [API Reference](https://docs.electioapp.com/#/api).
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).
