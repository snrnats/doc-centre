<div class="tab">
    <button class="staticTabButton">Allocate With Carrier Service Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard('allocationUCSEndpoint')">Click to Copy</div>
</div>

<div id="allocationUCSEndpoint" class="staticTabContent" onclick="CopyToClipboard('allocationUCSEndpoint')">

```
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice
```

</div>

To allocate one or more consignments to a specific carrier service, use the **[Allocate With Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** endpoint. 

The **Allocate With Carrier Service** request body contains an array of one or more `{consignmentReference}`s to be allocated and the `{MpdCarrierServiceReference}` of the carrier service that they should be allocated to. 

Once the request is received, SortedPRO attempts to allocate the consignments to the specified carrier service. It then returns an array of Allocation Summaries, one for each allocated consignment. 

If PRO is unable to allocate the consignment to the specified carrier service, it puts the consignment into a state of _Allocation Failed_ and takes no further action. For information on dealing with failed allocations, see the _Manage NOT SHIPPED Consignments_ section of the PRO UI User Manual.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Allocate With Carrier Service</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Allocate With Carrier Service</a></strong> page of the API reference. 

### Allocate With Carrier Service Example

The example shows a request to allocate three consignments to a carrier service with an `{MpdCarrierServiceReference}` of _Example-Carrier-Service_ .

<div class="tab">
    <button class="staticTabButton">Example Allocate With Carrier Service Request</button>
    <div class="copybutton" onclick="CopyToClipboard('allocationUCSRequest')">Click to Copy</div>
</div>

<div id="allocationUCSRequest" class="staticTabContent" onclick="CopyToClipboard('allocationUCSRequest')">

```json
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice

{
  "MpdCarrierServiceReference": "Example-Carrier-Service",
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```

</div>