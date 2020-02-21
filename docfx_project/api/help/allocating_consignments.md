# Allocating Consignments To Carriers

Once you've created a consignment, you'll need to allocate it to a carrier service. This section explains how to view available carrier services and the various methods you can use to allocate consignments to those services.

---

## What Is Allocation?

In the context of SortedPRO, **allocation** is the process of selecting the carrier service that will be used to deliver a consignment. When a consignment is allocated to a carrier service, its status changes to _Allocated_, enabling you to retrieve its package labels and (where applicable) customs documentation. Allocation is a key part of all PRO workflows, as a consignment cannot be shipped if it has not previously been allocated to a suitable carrier service.

To allocate a consignment in PRO, you'll need to call one of PRO's allocation endpoints. You can specify a carrier service to allocate to, allocate based on a quote you received, or have PRO choose a carrier service for you based on your existing business rules.

PRO offers the following allocation endpoints:

<table class="endpointTable">
    <tr>
        <th width="55%">Endpoint</th>
        <th width="33%">Description</th>
        <th width="12%">API Reference</th>
    </tr>
    <tr>
        <td width="55%">
            <p><a href="/api/help/allocating_to_the_cheapest_quote.html">Allocate Consignment</a></p> 
            <p><pre>PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote</pre></p>
        </td>
        <td width="33%">Allocates a single consignment to the cheapest available carrier service</td>
        <td width="12%"><a href="https://docs.electioapp.com/#/api/AllocateConsignment">Link</a></td>                
    </tr>
    <tr>
        <td>
            <p><a href="/api/help/allocating_via_service_group.html">Allocate Consignment With Service Group</a></p>
            <p><pre>PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}</pre></p>
        </td>
        <td>Allocates a consignment to the cheapest available carrier service in a particular carrier service group</td>
        <td><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Link</a></td>               
    </tr>
    <tr>
        <td>
            <p><a href="/api/help/allocating_using_default_rules.html">Allocate Using Default Rules</a></p>
            <p><pre>PUT https://api.electioapp.com/allocation/allocate</pre></p>
        </td>
        <td>Allocates one or more consignments based on your organisation's custom allocation rules</td>
        <td><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Link</a></td>                
    </tr>
    <tr>
        <td>
            <p><a href="/api/help/allocating_to_a_specific_carrier_service.html">Allocate With Carrier Service</a></p>
            <p><pre>PUT https://api.electioapp.com/allocation/allocatewithcarrierservice</pre></p>
        </td>
        <td>Allocates one or more consignments to a specific carrier service</td>
        <td><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Link</a></td>            
    </tr>
    <tr>
        <td>
            <p><a href="/api/help/allocating_to_a_specific_quote.html">Allocate With Quote</a></p>
            <p><pre>PUT https://api.electioapp.com/allocation/{consignmentReference}/Route parameter: {consignmentReference}allocatewithquote/{quoteReference}</pre></p>
        </td>
        <td>Allocates an individual consignment based on a specific delivery quote from a carrier</td>
        <td><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Link</a></td>                
    </tr>            
</table>

## Filtering Carrier Services

Allocation tags enable you to filter the list of available carrier services on a per-consignment basis, no matter which allocation endpoint you use in your integration. They are generally used as a means of excluding carrier services that would not be suitable for a particular consignment. 

Tagged shipments can only be allocated to those carrier services that have a matching tag. You can still allocate untagged shipments to a carrier service that has tags.

To associate tags with carrier services, use the **Settings > [Carrier Services](https://www.electioapp.com/Configuration/carrierservices/) > [select carrier service] > Allocation Rules > Allocation Filtering Tags** panel of the SortedPRO UI.

For example, a retailer might use the UI to add a `Flammables` tag to all the carrier services that they wanted to use for flammable products. They would then add the `Flammables` tag to all consignments containing flammable products. PRO would only allocate those consignments tagged as `Flammables` to a consignment in the pre-approved `Flammables` list.

### Scenarios

Suppose that you set your carrier services up in the following way:

* You tag Carrier Service A with `Alcohol`
* You tag Carrier Service B with `Flammables`
* You tag Carrier Service C with `Alcohol` and `Flammables`
* You tag Carrier Service D with `Oil`
* You don't add any tags to Carrier Service E

This configuration would produce the following results:

* **Consignment with no tags** - A B C D and E are returned
* **Consignment tagged with** `Alcohol` - A and C are returned
* **Consignment tagged with** `Flammables` - B and C are returned
* **Consignment tagged with** `Alcohol` **and** `Flammables` - C is returned
* **Consignment tagged with** `Alcohol`**,** `Flammables`**, and** `Oil` - No services are returned

### Tags Example

The example shows a `tags` property for a consignment that contains flammable materials, oil and alcohol.

<div class="tab">
    <button class="staticTabButton">Example Tags array</button>
    <div class="copybutton" onclick="CopyToClipboard('tagsExample')">Click to Copy</div>
</div>

<div id="tagsExample" class="staticTabContent" onclick="CopyToClipboard('tagsExample')">

```json
"Tags": [
   "Flammables",
   "Oil",
   "Alcohol"
]
```

</div>

## After Allocation

Once allocated, the consignment's status changes to _Allocated_, enabling you to retrieve its package labels and (where applicable) customs documentation. All allocation endpoints also return an Allocation Summary, either singularly or (where multiple consignments have been allocated at once) in an array. 

The Allocation Summary contains links to the consignment resource that was allocated, a summary of the carrier service that the consignment was allocated to, a link to the relevant package labels, and a `ConsignmentLegs` array indicating how many legs the shipment will need. Where a shipment would need multiple legs to complete, the `ConsignmentLegs` array shows tracking details for each individual leg.

In the example, a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_ has been allocated to a (dummy) carrier service called _Carrier X Next Day Super_.

### Allocation Summary Example

<div class="tab">
    <button class="staticTabButton">Example Allocation Summary</button>
    <div class="copybutton" onclick="CopyToClipboard('allocationSummary')">Click to Copy</div>
</div>

<div id="allocationSummary" class="staticTabContent" onclick="CopyToClipboard('allocationSummary')">

```json
[
    {
        "StatusCode": 200,
        "ApiLinks": [
            {
                "Rel": "detail",
                "Href": "https://apisandbox.electioapp.com/consignments/EC-000-05B-MMA"
            },
            {
                "Rel": "label",
                "Href": "https://apisandbox.electioapp.com/labels/EC-000-05B-MMA"
            }
        ],
        "Description": "Consignment EC-000-05B-MMA has been successfully allocated with Carrier X Next Day Super for shipping on 14/06/2019 17:00:00 +00:00",
        "ConsignmentLegs": [
            {
                "Leg": 1,
                "TrackingReferences": [
                    "TRK00009823"
                ],
                "CarrierReference": "CARRIER_X",
                "CarrierServiceReference": null,
                "CarrierName": "Carrier X"
            }
        ],
        "CarrierReference": "CARRIER_X",
        "CarrierName": "Carrier X",
        "CarrierServiceReference": "CX_NDS",
        "CarrierServiceName": "Next Day Super"
    }
]
```
</div>

## Allocation Section Contents

* [Viewing Available Carrier Services](/api/help/viewing_available_carrier_services.html) - Explains how to get a list of the carriers and services available with your subscription.
* [Allocating Consignments To The Cheapest Quote](/api/help/allocating_to_the_cheapest_quote.html) - Explains how to allocate a consignment to the cheapest eligible quote.
* [Allocating To A Specific Carrier Service](/api/help/allocating_to_a_specific_carrier_service.html) - Explains how to allocate a consignment to a specific carrier service.
* [Allocating Via Service Group](/api/help/allocating_via_service_group.html) - Explains how to allocate a consignment to the cheapest available service in the specific carrier service group.
* [Allocating Using Default Rules](/api/help/allocating_using_default_rules.html) - Explains how to allocate a consignment based on custom business rules.
* [Allocating To A Specific Quote](/api/help/allocating_to_a_specific_quote.html) - Explains how to allocate a consignment based on a specific delivery quote from a carrier.
* [Deallocating Consignments](/api/help/deallocating_consignments.html) - Explains how to return a consignment to a deallocated state.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>