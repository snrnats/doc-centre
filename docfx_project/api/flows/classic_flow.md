# Classic Flow

<p>
   <a href="../../images/Flow1.png" target="_blank" >
      <img src="../../images/Flow1.png" class="noborder"/>
   </a>
</p>

Creating a new consignment, allocating it to a suitable carrier service, and then adding it to that service's manifest is perhaps PRO's most basic use case. The **Classic** call flow offers the lightest integration design of all PRO flows, making it easy for your organisation to manage deliveries across multiple carriers.

The **Classic** flow is most useful to your business if:

* You have a single warehouse / fulfilment centre.
* You use a static delivery promise (e.g. Next day delivery before 5pm).
* You want to keep your business logic and technology architecture as simple as possible.

There are four steps to the flow:

<table class="flowTable">
   <tr>
      <th>Step</th>
      <th>Endpoints Used</th>
   </tr>
   <tr>
      <td>1. <strong>Create the consignment</strong> - Use the <a href="https://docs.electioapp.com/#/api/CreateConsignment">Create Consignment</a> endpoint to record the details of your new consignment.</td>
      <td><pre>POST https://api.electioapp.com/consignments</pre></td>
   </tr>
   <tr>
      <td>2. <strong>Allocate the consignment</strong> - Use one of PRO's <a href="https://docs.electioapp.com/#/api/AllocateConsignment">Allocation</a> endpoints to select the carrier service that your consignment will use. You can nominate a specific service, ask PRO to determine the best service to use from a pre-defined group, or allocate based on pre-set allocation rules.</td>
      <td><pre>PUT https://api.electioapp.com/allocation/allocate
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice</pre></td>
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

## Step 1: Creating Consignments

[!include[_create_consignments](../includes/_create_consignments.md)]

---

## Step 2: Allocating Consignments

[!include[_allocating](../includes/_allocating.md)]

---

## Step 2a: Allocating using Default Rules

[!include[_allocate_using_default_rules](../includes/_allocate_using_default_rules.md)]

---

## Step 2b: Allocating from a Service Group

[!include[_allocate_with_service_group](../includes/_allocate_with_service_group.md)]

---

## Step 2c: Allocating to a Specific Carrier Service

[!include[_allocate_with_carrier_service](../includes/_allocate_with_carrier_service.md)]

---

## Step 3: Getting Package Labels

[!include[_get_labels_in_format](../includes/_get_labels_in_format.md)]

---

## Step 4: Manifesting a Consignment

[!include[_manifest_consignments_from_query](../includes/_manifest_consignments_from_query.md)]

## Next Steps

And we're done! Read on to learn how to allocate consignments based on options presented to the customer at point of purchase, and deal with orders that may require multiple consignments to fulfil. 

[!include[scripts](../includes/scripts.md)]