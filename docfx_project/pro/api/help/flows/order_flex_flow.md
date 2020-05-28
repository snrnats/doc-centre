# Order Flex Flow

<p>
   <a href="../../../images/Flow4.png" target="_blank" >
      <img src="../../../images/Flow4.png" class="noborder"/>
   </a>
</p>

The **Order Flex** flow enables you to process customer orders comprising items that will ship from different physical locations, ship on different dates or require multiple carrier services to fulfil.

The **Order Flex** flow is useful to your business if:

* You operate multiple warehouses / fulfilment centres, or run a customer marketplace.
* You use drop ship vendors.
* You use a static delivery promise (e.g. Order by 5pm to get next day delivery). not sure about this point?? Why is it useful for this?
* You supply a large range of products with large vaiations in weights and dimensions.

There are five steps to the flow:

1. **Create order** - Use the [Create Order](https://docs.electioapp.com/#/api/CreateOrder) endpoint to record the customer's order in PRO.
2. **Pack order** - Use the [Pack Order](https://docs.electioapp.com/#/api/PackOrder) endpoint to create one or more consignments from the order.
3. **Allocate the consignments** - Use one of PRO's [Allocation](https://docs.electioapp.com/#/api/AllocateConsignment) endpoints to select the carrier service that your consignments will use. You can select a specific service, ask PRO to determine the best service to use from a pre-defined group, or allocate based on pre-set allocation rules.
4. **Get delivery labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignments.
5. **Manifest the consignments** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to confirm the consignments with the selected carrier. At this point, the consignments are ready to ship.

This section gives more detail on each step of the flow and provides worked examples. 

---

## Step 1: Creating the Order

[!include[_create_orders](../../includes/_create_orders.md)]

---

## Step 2: Packing the Order

[!include[_pack_orders](../../includes/_pack_orders.md)]

---

## Step 3: Allocating the Consignment

[!include[_allocating](../../includes/_allocating.md)]


You'll need to allocate all of the consignments packed from your order. Bear in mind that <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> and <strong><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Allocate With Carrier Service</a></strong> enable you to allocate multiple consignments at once, but you can only allocate one consignment at a time via <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Allocate Consignment With Service Group</a></strong>. If you allocate via <strong>Allocate Consignment With Service Group</strong> you'll need to make one API call per consignment on the order.

---

### Allocating using Default Rules

[!include[_allocate_using_default_rules](../../includes/_allocate_using_default_rules.md)]

---

### Allocating from a Service Group

[!include[_allocate_with_service_group](../../includes/_allocate_with_service_group.md)]

---

### Allocating to a Specific Carrier Service

[!include[_allocate_with_carrier_service](../../includes/_allocate_with_carrier_service.md)]

---

## Step 4: Getting Package Labels

[!include[_get_labels_in_format](../../includes/_get_labels_in_format.md)]

> <span class="note-header">Note:</span>
> You'll need to make one <strong>Get Labels</strong> call per consignment on the order.

---

## Step 4b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 5: Manifesting a Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]

> <span class="note-header">Note:</span>
> You'll need to manifest all the consignments on the order.

### Next Steps

Finished! The next section explains a similar process, whereby the order is generated from delivery options that the customer selects rather than created up front.

[!include[scripts](../../includes/scripts.md)]
