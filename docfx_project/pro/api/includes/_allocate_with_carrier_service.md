<div class="tab">
    <button class="staticTabButton">Allocate With Carrier Service Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocationUCSEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocationUCSEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'allocationUCSEndpoint')">

```
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice
```

</div>

To allocate one or more consignments to a specific carrier service, use the **[Allocate With Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** endpoint. 

The **Allocate With Carrier Service** request body contains an array of one or more `{consignmentReference}`s to be allocated and the `{MpdCarrierServiceReference}` of the carrier service that they should be allocated to. Once the request is received, SortedPRO attempts to allocate the consignments to the specified carrier service.

> <span class="note-header">Note:</span>
>  * For full reference information on the <strong>Allocate With Carrier Service</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Allocate With Carrier Service</a></strong> page of the API reference.
> * For a user guide on allocating consignments to a specific carrier service, see the [Allocating to a Specific Carrier Service](/pro/api/help/allocating_to_a_specific_carrier_service.html).

### Allocate With Carrier Service Example

The example shows a request to allocate three consignments to a carrier service with an `{MpdCarrierServiceReference}` of _Example-Carrier-Service_ .

<div class="tab">
    <button class="staticTabButton">Example Allocate With Carrier Service Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocationUCSRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocationUCSRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'allocationUCSRequest')">

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