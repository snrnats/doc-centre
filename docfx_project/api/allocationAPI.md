# Allocation API

`https://api.electioapp.com/allocation/`

In the context of SortedPRO, _allocation_ is the process of selecting the carrier service that will be used to deliver the consignment. In PRO, allocation and de-allocation of consignments is handled by the **Allocation** API.

PRO has multiple allocation endpoints, giving you the flexibility to allocate to carriers using whatever criteria suits you best. Once allocated, a consignment's status changes to _Allocated_, enabling you to retrieve its package labels and (where applicable) customs documentation, and ultimately manifest the consignment with the selected service.

## Allocation Endpoints

The Allocation API has five endpoints that handle consignment allocation:

* [Allocate Consignment](/api/allocation/allocateConsignment.html) - `PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote` </br> Allocates a single consignment to the cheapest eligible service (that is, the cheapest service that meets your organisation's Carrier Service Rules).
* [Allocate Consignment With Service Group](/api/allocation/allocateConsignmentWithServiceGroup.html) - `PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}` </br> Allocates the specified consignment to the cheapest available service in the specified Carrier Service Group.
* [Allocate Using Default Rules](/api/allocation/allocateUsingDefaultRules.html) - `PUT https://api.electioapp.com/allocation/allocate` </br> Takes one or more consignments and allocates each to the cheapest eligible service (that is, the cheapest service that meets your organisation's Carrier Service Rules).
* [Allocate With Carrier Service](/api/allocation/allocateWithCarrierService.html) - `PUT https://api.electioapp.com/allocation/allocatewithcarrierservice` </br> Allocates the specified consignments to the specified carrier service.
* [Allocate With Quote](/api/allocation/allocateWithQuote.html) - `PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithquote/{quoteReference}` </br> Allocates the consignment to the carrier service specified in the supplied quote.

> <span class="note-header">Note:</span>
>  Allocation tags enable you to filter the list of available carrier services on a per-consignment basis, no matter which allocation endpoint you use in your integration. For more information on using allocation tags, see the <strong><a href="/api/flows/moreInfo.html#tags">Tags</a></strong> section of the <strong>More Information</strong> page. 

## The Allocation Summary Response

All allocation endpoints return an Allocation Summary, either singularly or (where multiple consignments have been allocated at once) in an array. The Allocation Summary contains links to the consignment resource that was allocated, a summary of the carrier service that the consignment was allocated to, a link to the relevant package labels, and a `ConsignmentLegs` array indicating how many legs the shipment will need. Where a shipment would need multiple legs to complete, the `ConsignmentLegs` array shows tracking details for each individual leg.

In the example, a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_ has been allocated to a (dummy) carrier service called _Carrier X Next Day Super_.

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

## De-Allocation Endpoints

The Allocation API has two endpoints that handle consignment de-allocation:

* [Deallocate Consignment](/api/allocation/deallocateConsignment.html) - `PUT https://api.electioapp.com/consignments/{consignmentReference}/deallocate` </br> Deallocates the specified consignment.
* [Deallocate Consignments](/api/allocation/deallocateConsignments.html) - `PUT https://api.electioapp.com/consignments/deallocatelist` </br> Deallocates one or more consignments.

[!include[scripts](includes/scripts.md)]