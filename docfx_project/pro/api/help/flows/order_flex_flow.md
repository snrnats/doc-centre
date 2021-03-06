---
uid: pro-api-help-flows-order-flex-flow
title: Order Flex Flow
tags: pro,api,consignments,flows,orders
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 15/04/2020
---
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
* You supply a range of products with large variations in weights and dimensions.

There are five steps to the flow:

1. **Create order** - Use the [Create Order](https://docs.electioapp.com/#/api/CreateOrder) endpoint to record the customer's order in PRO.
2. **Pack order** - Use the [Pack Order](https://docs.electioapp.com/#/api/PackOrder) endpoint to create one or more consignments from the order.
3. **Allocate the consignments** - Use one of PRO's [Allocation](https://docs.electioapp.com/#/api/AllocateConsignment) endpoints to select the carrier service that your consignments will use. You can select a specific service, ask PRO to determine the best service to use from a pre-defined group, or allocate based on pre-set allocation rules.
4. **Get delivery labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignments.
5. **Manifest the consignments** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to send consignment data to the selected carrier.

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

You'll need to allocate all of the consignments packed from your order. Bear in mind that **[Allocate Using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)** and **[Allocate with Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** enable you to allocate multiple consignments at once, but you can only allocate one consignment at a time via **[Allocate Consignment with Service Group](https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup)**. If you allocate via **Allocate Consignment with Service Group** you'll need to make one API call per consignment on the order.

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

> [!NOTE]
> You'll need to make one **Get Labels** call per consignment on the order.

---

## Step 4b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 5: Manifesting a Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]

> [!NOTE]
> You'll need to manifest all the consignments on the order.

### Next Steps

Finished! The next section explains a similar process, whereby the order is generated from delivery options that the customer selects rather than created up front.
