# Consumer Options Pickup Flow

<p>
   <a href="../../images/Flow3.png" target="_blank" >
      <img src="../../images/Flow3.png" class="noborder"/>
   </a>
</p>

The **Consumer Options** flow can also be used to power Pick Up / Drop-Off (PUDO) services. By integrating PRO's **Pickup Options** endpoint, you can build click-and-collect functionality that lets your customers select a pickup location and timeslot for their consignment.

There are four steps to the flow:

<table class="flowTable">
   <tr>
      <th>Step</th>
      <th>Endpoints Used</th>
   </tr>
   <tr>
      <td>1. <strong>Get pickup options</strong> - Use the <a href="https://docs.electioapp.com/#/api/PickupOptions">Pickup Options</a> endpoint to request a list of available delivery locations and timeslots for the (as yet uncreated) consignment that the customer's order will generate.</td>
      <td><pre>POST https://api.electioapp.com/deliveryoptions/pickupoptions/</pre></td>
   </tr>
   <tr>
      <td>2. <strong>Select delivery option</strong> - Use the <a href="https://docs.electioapp.com/#/api/SelectOption">Select Option</a> endpoint to tell PRO which option the customer selected. At this point, PRO has all the information it needs to create and allocate a consignment.
      <td><pre>POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}</pre></td>
   </tr>
   <tr>
      <td>3. <strong>Get the consignment's labels</strong> - Use the <a href="https://docs.electioapp.com/#/api/GetLabelsinFormat">Get Labels In Format</a> endpoint to get the delivery label for your consignment.</td>
      <td><pre>GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}</pre></td>
   </tr>
   <tr>
      <td>4. <strong>Manifest the consignment</strong> - Use the <a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments from Query</a> endpoint to confirm the consignment with the selected carrier. At this point, the consignment is ready to ship.</td>
      <td><pre>POST https://api.electioapp.com/consignments/manifestFromQuery</pre></td>
   </tr>         
 </table>

This section gives more detail on each step of the flow and provides worked examples. 

---

## Step 1: Getting Pickup Options

[!include[_get_pickup_options](../includes/_get_pickup_options.md)]

---

## Step 2: Selecting a Delivery Option

[!include[_select_option](../includes/_select_option.md)]

---

## Step 3: Getting a Package Label

[!include[_get_labels_in_format](../includes/_get_labels_in_format.md)]

---

## Step 4: Manifesting the Consignment

[!include[_manifest_consignments_from_query](../includes/_manifest_consignments_from_query.md)]

### Next Steps

Read on to learn how to use delivery options to fulfil multiple-consignment orders.

[!include[scripts](../includes/scripts.md)]