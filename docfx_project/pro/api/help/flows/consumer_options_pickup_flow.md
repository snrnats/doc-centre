# Consumer Options Pickup Flow

<p>
   <a href="../../../images/Flow3.png" target="_blank" >
      <img src="../../../images/Flow3.png" class="noborder"/>
   </a>
</p>

The **Consumer Options** flow can also be used to power Pick Up / Drop-Off (PUDO) services. By integrating PRO's **Pickup Options** endpoint, you can build click-and-collect functionality that lets your customers select a pickup location and collection date.

There are four steps to the flow:

1. **Get pickup options** - Use the [Pickup Options](https://docs.electioapp.com/#/api/PickupOptions) endpoint to request a list of available delivery locations for the (as yet uncreated) consignment that the customer's order will generate.
2. **Select delivery option** - Use the [Select Option](https://docs.electioapp.com/#/api/SelectOption) endpoint to tell PRO which option the customer selected. At this point, PRO has all the information it needs to create and allocate a consignment.
3. **Get the consignment's labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignment.
4. **Manifest the consignment** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to send consignment data to the selected carrier.

This section gives more detail on each step of the flow and provides worked examples. 

---

## Step 1: Getting Pickup Options

[!include[_get_pickup_options](../../includes/_get_pickup_options.md)]

---

## Step 2: Selecting a Delivery Option

[!include[_select_option](../../includes/_select_option.md)]

---

## Step 3: Getting a Package Label

[!include[_get_labels_in_format](../../includes/_get_labels_in_format.md)]

---

## Step 3b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 4: Manifesting the Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]

### Next Steps

Read on to learn how to use delivery options to fulfil multiple-consignment orders.

[!include[scripts](../../includes/scripts.md)]
