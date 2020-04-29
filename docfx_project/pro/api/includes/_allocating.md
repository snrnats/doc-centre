<div class="tab">
    <button class="staticTabButton">Allocation Endpoints</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocationEndpoints')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocationEndpoints" class="staticTabContent" onclick="CopyToClipboard(this, 'allocationEndpoints')">

   ```
   PUT https://api.electioapp.com/allocation/allocate
   PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}
   PUT https://api.electioapp.com/allocation/allocatewithcarrierservice
   ```

</div>   

Once you've created a consignment, it must be allocated to a carrier service. In the context of SortedPRO, <strong>allocation</strong> is the process of selecting the carrier service that will be used to deliver the consignment. 

PRO has multiple allocation endpoints, giving you the flexibility to allocate to carriers using whatever criteria suits you best. In this case you could allocate via:

* **[Allocate Using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)** - Allocates the consignment using pre-configured default rules.
* **[Allocate Consignment With Service Group](https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup)** - Allocates the consignment to the cheapest carrier service in the specified Carrier Service Group.
* **[Allocate With Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** - Allocates the consignment to the specified carrier service.

Once allocated, the consignment's status changes to _Allocated_, enabling you to retrieve its package labels and (where applicable) customs documentation.

This section explains the circumstances in which you might choose to use each allocation endpoint, and gives worked examples.

> <span class="note-header">More Information:</span>
>
> For a full user guide on allocating consignments in PRO, see the [Allocating Consignments](/pro/api/help/allocating_consignments.html) section.

### The Allocation Summary Response

All allocation endpoints return an Allocation Summary, either singularly or (where multiple consignments have been allocated at once) in an array. The Allocation Summary contains links to the consignment resource that was allocated, a summary of the carrier service that the consignment was allocated to, a link to the relevant package labels, and a `ConsignmentLegs` array indicating how many legs the shipment will need. Where a shipment would need multiple legs to complete, the `ConsignmentLegs` array shows tracking details for each individual leg.

In the example, a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_ has been allocated to a (dummy) carrier service called _Carrier X Next Day Super_.

> <span class="note-header">Note:</span>
>  Allocation tags enable you to filter the list of available carrier services on a per-consignment basis, no matter which allocation endpoint you use in your integration. For more information on using allocation tags, see the <strong><a href="/api/flows/moreInfo.html#tags">Tags</a></strong> section of the <strong>More Information</strong> page. 

<div class="tab">
    <button class="staticTabButton">Example Allocation Summary</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocationSummary')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocationSummary" class="staticTabContent" onclick="CopyToClipboard(this, 'allocationSummary')">

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