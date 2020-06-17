# Consumer Options Flex Flow

<p>
   <a href="../../../images/Flow5.png" target="_blank" >
      <img src="../../../images/Flow5.png" class="noborder"/>
   </a>
</p>

Like the **Consumer Options** flow, the **Consumer Options Flex** flow enables you to provide delivery timeslots to your customer at point of purchase. However, rather than generating a single consignment from the options selected, this flow generates orders, which can then be packed into multiple consignments.

The **Consumer Options Flex** flow can be used to provide front-end delivery options in circumstances where you cannot guarantee that the contents of your customer's online basket will map directly to a single consignment. For example, you might operate more than one warehouse and so may need to ship some orders in multiple consignments.

The **Consumer Options Flex** flow is useful to your business if:

* You use a distributed business logic and technology architecture.
* You operate multiple warehouses / fulfilment centres.
* You want to present your customer with a dynamic checkout that offers delivery timeslot options.

There are six steps to the flow:

1. **Get delivery options** - Use the [Delivery Options](https://docs.electioapp.com/#/api/DeliveryOptions) endpoint to request a list of available delivery options for the (as yet uncreated) consignment that the customer's purchase will generate.
2. **Select option as an order** - Use the [Select Delivery Option as an Order](https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder) to generate an order from the selected delivery option. 
3. **Pack the order** - Use the [Pack Order](https://docs.electioapp.com/#/api/PackOrder) endpoint to create one or more consignments from the order.
4. **Allocate the consignments** - Use one of PRO's [Allocation](https://docs.electioapp.com/#/api/AllocateConsignment) endpoints to select the carrier service that your consignments will use. You can select a specific service, ask PRO to determine the best service to use from a pre-defined group of services, or allocate based on pre-set allocation rules.
5. **Get the consignment's labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignment.
6. **Manifest the consignments** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to confirm the consignment with the selected carrier. At this point, the consignment is ready to ship.

This section gives more detail on each step of the flow and provides worked examples.

---

## Step 1: Getting Options

[!include[_getting_delivery_options](../../includes/_getting_delivery_options.md)]

> [!NOTE]
> Although this guide focuses on generating an order from the **Delivery Options** endpoint, you can also generate orders from pickup options via the **Pickup Options** endpoint. For more information on the **Pickup Options** endpoint, see the **[Pickup Options](https://docs.electioapp.com/#/api/PickupOptions)** page of the API reference.

---

## Step 2: Selecting an Option as an Order

[!include[_select_option_as_order](../../includes/_select_option_as_order.md)]

---

## Step 3: Packing the Order

[!include[_pack_orders](../../includes/_pack_orders.md)]

---

## Step 4: Allocating the Consignment

[!include[_allocating](../../includes/_allocating.md)]

You'll need to allocate all of the consignments packed from your order. Bear in mind that **[Allocate using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)** and **[Allocate with Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** enable you to allocate multiple consignments at once, but you can only allocate one consignment at a time via **[Allocate Consignment with Service Group](https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup)**. If you allocate via **Allocate Consignment with Service Group** you'll need to make one API call per consignment on the order.

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

## Step 5: Getting Shipment Labels

[!include[_get_labels_in_format](../../includes/_get_labels_in_format.md)]

> [!NOTE]
> You'll need to make one **Get Labels** call per consignment on the order.

---

## Step 5b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 6: Manifesting the Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]

> [!NOTE]
> You'll need to manifest all the consignments on the order.

### Next Steps

The final section explains how to set up a call flow that enables you to retrieve and select quotes manually.
