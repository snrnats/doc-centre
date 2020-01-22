# Order Flex Flow

<p>
   <a href="../../images/Flow4.png" target="_blank" >
      <img src="../../images/Flow4.png" class="noborder"/>
   </a>
</p>

The **Order Flex** flow enables you to process customer orders comprising items that will ship from different physical locations.

The **Order Flex** flow is useful to your business if:

* You operate multiple warehouses / fulfilment centres, or run a customer marketplace.
* You use drop ship vending.
* You use a static delivery promise (e.g. Order by 5pm to get next day delivery).

There are five steps to the flow:

<table class="flowTable">
   <tr>
      <th>Step</th>
      <th>Endpoints Used</th>
   </tr>
   <tr>
      <td>1. <strong>Create order</strong> - Use the <a href="https://docs.electioapp.com/#/api/CreateOrder">Create Order</a> endpoint to record the customer's order in PRO.</td>
      <td><pre>POST https://api.electioapp.com/orders</pre></td>
   </tr>
   <tr>
      <td>2. <strong>Pack order</strong> - Use the <a href="https://docs.electioapp.com/#/api/PackOrder">Pack Order</a> endpoint to create one or more consignments from the order.</td>
      <td><pre>POST https://api.electioapp.com/orders/{orderReference}/pack</pre></td>
   </tr>
   <tr>
      <td>3. <strong>Allocate the consignment</strong> - Use one of PRO's <a href="https://docs.electioapp.com/#/api/AllocateConsignment">Allocation</a> endpoints to select the carrier service that your consignment will use. You can nominate a specific service, ask PRO to determine the best service to use from a pre-defined group, or allocate based on pre-set allocation rules.</td>
      <td><pre>PUT https://api.electioapp.com/allocation/allocate
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice</pre></td>
   </tr>
   <tr>
      <td>4. <strong>Get the consignment's labels</strong> - Use the <a href="https://docs.electioapp.com/#/api/GetLabelsinFormat">Get Labels In Format</a> endpoint to get the delivery label for your consignment.</td>
      <td><pre>GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}</pre></td>
   </tr>
   <tr>
      <td>5. <strong>Manifest the consignment</strong> - Use the <a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments from Query</a> endpoint to confirm the consignment with the selected carrier. At this point, the consignment is ready to ship.</td>
      <td><pre>POST https://api.electioapp.com/consignments/manifestFromQuery</pre></td>
   </tr>         
 </table>   

This section gives more detail on each step of the flow and provides worked examples. 

---

## Step 1: Creating the Order

[!include[_create_orders](../includes/_create_orders.md)]

---

## Step 2: Packing the Order

[!include[_pack_orders](../includes/_pack_orders.md)]

---

## Step 3: Allocating the Consignment

[!include[_allocating](../includes/_allocating.md)]


You'll need to allocate all of the consignments packed from your order. Bear in mind that <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> and <strong><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Allocate With Carrier Service</a></strong> enable you to allocate multiple consignments at once, but you can only allocate one consignment at a time via <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Allocate Consignment With Service Group</a></strong>. If you allocate via <strong>Allocate Consignment With Service Group</strong> you'll need to make one API call per consignment on the order.

---

## Step 3a: Allocating using Default Rules

[!include[_allocate_using_default_rules](../includes/_allocate_using_default_rules.md)]

---

## Step 3b: Allocating from a Service Group

[!include[_allocate_with_service_group](../includes/_allocate_with_service_group.md)]

---

## Step 3c: Allocating to a Specific Carrier Service

[!include[_allocate_with_carrier_service](../includes/_allocate_with_carrier_service.md)]

---

## Step 4: Getting Package Labels

[!include[_get_labels_in_format](../includes/_get_labels_in_format.md)]

> <span class="note-header">Note:</span>
> You'll need to make one <strong>Get Labels</strong> call per consignment on the order.

---

## Step 5: Manifesting a Consignment

[!include[_manifest_consignments_from_query](../includes/_manifest_consignments_from_query.md)]

> <span class="note-header">Note:</span>
> You'll need to manifest all the consignments on the order.

### Next Steps

Finished! The next section explains a similar process, whereby the order is generated from delivery options that the customer selects rather than created up front.

[!include[scripts](../includes/scripts.md)]