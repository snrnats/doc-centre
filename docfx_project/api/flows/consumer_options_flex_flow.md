# Consumer Options Flex Flow

<p>
   <a href="../../images/Flow5.png" target="_blank" >
      <img src="../../images/Flow5.png" class="noborder"/>
   </a>
</p> 

Like the **Consumer Options** flow, the **Consumer Options Flex** flow enables you to provide delivery timeslots to your customer at point of purchase. However, rather than generating a single consignment from the options selected, this flow generates orders, which can then be packed into multiple consignments. 

The **Consumer Options Flex** flow can be used to provide front-end delivery options in circumstances where you cannot guarantee that the contents of your customer's online basket will map directly to a single consignment. For example, you might operate more than one warehouse and so may need to ship some orders in multiple consignments.

The **Consumer Options Flex** flow is useful to your business if:

* You use a distributed business logic and technology architecture.
* You operate multiple warehouses / fulfilment centres.
* You want to present your customer with a dynamic checkout that offers delivery timeslot options.

There are six steps to the flow:

<table class="flowTable">
   <tr>
      <th>Step</th>
      <th>Endpoints Used</th>
   </tr>
   <tr>
      <td>1. <strong>Get delivery options</strong> - Use the <a href="https://docs.electioapp.com/#/api/DeliveryOptions">Delivery Options</a> endpoint to request a list of available delivery options for the (as yet uncreated) consignment that the customer's order will generate.</td>
      <td><pre>POST https://api.electioapp.com/deliveryoptions</pre></td>
   </tr>
   <tr>
      <td>2. <strong>Select option as an order</strong>- Use the <a href="https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder">Select Delivery Option as an Order</a> endpoint to generate an order from the selected delivery option. </td>
      <td><pre>POST https://api.electioapp.com/deliveryoptions/selectorder</pre></td>
   </tr>
   <tr>
      <td>3. <strong>Pack order</strong> - Use the <a href="https://docs.electioapp.com/#/api/PackOrder">Pack Order</a> endpoint to create one or more consignments from the order.</td>
      <td><pre>POST https://api.electioapp.com/orders/{orderReference}/pack</pre></td>
   </tr>   
   <tr>
      <td>4. <strong>Allocate the consignment</strong> - Use one of PRO's <a href="https://docs.electioapp.com/#/api/AllocateConsignment">Allocation</a> endpoints to select the carrier service that your consignment will use. You can nominate a specific service, ask PRO to determine the best service to use from a pre-defined group, or allocate based on pre-set allocation rules.</td>
      <td><pre>PUT https://api.electioapp.com/allocation/allocate
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice</pre></td>
   </tr>
   <tr>
      <td>5. <strong>Get the consignment's labels</strong> - Use the <a href="https://docs.electioapp.com/#/api/GetLabelsinFormat">Get Labels In Format</a> endpoint to get the delivery label for your consignment.</td>
      <td><pre>GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}</pre></td>
   </tr>
   <tr>
      <td>6. <strong>Manifest the consignment</strong> - Use the <a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments from Query</a> endpoint to confirm the consignment with the selected carrier. At this point, the consignment is ready to ship.</td>
      <td><pre>POST https://api.electioapp.com/consignments/manifestFromQuery</pre></td>
   </tr>         
 </table>

This section gives more detail on each step of the flow and provides worked examples. 

---

## Step 1: Getting Options

[!include[_getting_delivery_options](../includes/_getting_delivery_options.md)]

> <span class="note-header">Note:</span>
>   Although this guide focuses on generating an order from the <strong>Delivery Options</strong> endpoint, you can also generate orders from pickup options via the <strong>Pickup Options</strong> endpoint. For more information on the <strong>Pickup Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PickupOptions">Pickup Options</a></strong> page of the API reference.


---

## Step 2: Selecting an Option as an Order

[!include[_select_option_as_order](../includes/_select_option_as_order.md)]

---

## Step 3: Packing the Order

[!include[_pack_orders](../includes/_pack_orders.md)]

---

## Step 4: Allocating the Consignment

[!include[_allocating](../includes/_allocating.md)]

You'll need to allocate all of the consignments packed from your order. Bear in mind that <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> and <strong><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Allocate With Carrier Service</a></strong> enable you to allocate multiple consignments at once, but you can only allocate one consignment at a time via <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Allocate Consignment With Service Group</a></strong>. If you allocate via <strong>Allocate Consignment With Service Group</strong> you'll need to make one API call per consignment on the order.

---

## Step 4a: Allocating using Default Rules

[!include[_allocate_using_default_rules](../includes/_allocate_using_default_rules.md)]

---

## Step 4b: Allocating from a Service Group

[!include[_allocate_with_service_group](../includes/_allocate_with_service_group.md)]

---

## Step 4c: Allocating to a Specific Carrier Service

[!include[_allocate_with_carrier_service](../includes/_allocate_with_carrier_service.md)]

---

## Step 5: Getting Shipment Labels

[!include[_get_labels_in_format](../includes/_get_labels_in_format.md)]

> <span class="note-header">Note:</span>
>  You'll need to make one <strong>Get Labels</strong> call per consignment on the order.

---

## Step 6: Manifesting the Consignment

[!include[_manifest_consignments_from_query](../includes/_manifest_consignments_from_query.md)]

> <span class="note-header">Note:</span>
> You'll need to manifest all the consignments on the order.

### Next Steps

The final section explains how to set up a call flow that enables you to retrieve and select quotes manually.

[!include[scripts](../includes/scripts.md)]