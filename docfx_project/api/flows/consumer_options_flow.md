# Consumer Options Flow

<p>
   <a href="../../images/Flow2.png" target="_blank" >
      <img src="../../images/Flow2.png" class="noborder"/>
   </a>
</p>

The **Consumer Options** flow enables you to provide real-time delivery choices - including delivery date, time, and carrier brand - to your customer at point of purchase. After the customer has chosen their preferred option, PRO can create a consignment based on their details, and allocate that consignment to a carrier service based on the customers choice.

The **Consumer Options** flow is most useful to your business if:

* You want to present your customer with a dynamic checkout that offers delivery timeslot options.
* You operate a single warehouse / fulfilment centre.
* You develop and configure your own e-commerce platform.

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

## Step 1: Getting Delivery Options

[!include[_getting_delivery_options](../includes/_getting_delivery_options.md)]

---

## Step 2: Selecting a Delivery Option

[!include[_select_option](../includes/_select_option.md)]

---

## Step 3: Getting a Package Label

[!include[_get_labels_in_format](../includes/_get_labels_in_format.md)]

---

## Step 4: Manifesting the Consignment

[!include[_manifest_consignments_from_query](../includes/_manifest_consignments_from_query.md)]

## Next Steps

The next section explains a similar call flow that enables you to offer pickup options (aka click-and-collect) rather than home delivery timeslots.

[!include[scripts](../includes/scripts.md)]