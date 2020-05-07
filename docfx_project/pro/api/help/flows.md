# PRO Call Flows

Ready to get started with SortedPRO? This guide explains some common use cases for PRO's APIs, helping you to see what PRO can do for your business. 

We will cover:

* **Creating and manifesting a consignment**
   
   The **[Classic](/pro/api/flows/classic_flow.html)** flow is a simple flow to create a consignment, allocate it to a carrier service using criteria of your choosing, retrieve delivery labels, and confirm the delivery with the carrier. 

* **Offering and using delivery options**

   The **[Consumer Options](/pro/api/flows/consumer_options_flow.html)** flow is used when you want to present delivery options to your customer at point of purchase. PRO creates and allocates consignments based on the options the customer selects.

* **Offering and using pickup options**

   The **[Consumer Options Pickup](/pro/api/flows/consumer_options_pickup_flow.html)** flow is similar to the **Consumer Options** flow, but used when offering delivery to a pickup/drop-off (PUDO) location rather than home delivery. 

* **Creating a pack order flow from a PRO order**

   The **[Order Flex](/pro/api/flows/order_flex_flow.html)** flow is used when you can't guarantee that all parts of a customer's order will be picked, packed and dispatched from the same place at the same time. PRO can generate multiple consignments from a single customer order where required.

* **Using delivery options to create a pack order flow**

   The **[Consumer Options Flex](/pro/api/flows/consumer_options_flex_flow.html)** flow is used when you can't guarantee that all parts of a customer's order will be picked, packed and dispatched from the same place at the same time, and you want to present delivery options to your customer at point of purchase.

* **Obtaining and selecting delivery quotes**

   The **[Quotes](/pro/api/flows/quotes_flow.html)** flow is used to obtain a full list of potential delivery services for a consignment. It is often used to validate a consignment's detail or to enable a customer service operator to get manual quotes for a customer.

> <span class="note-header">Note:</span>
> This guide is intended as a primer for PRO. If you're already familiar with the basics of PRO, or you just need reference info for PRO's APIs, see the <a href="https://docs.electioapp.com/#/api">API reference</a>.
>
> Sample requests and responses are available in both <strong>JSON</strong> and <strong>XML</strong>. To switch between the two, use the tabs at the top of the right-hand panel.