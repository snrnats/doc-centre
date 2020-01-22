<div class="tab">
    <button class="staticTabButton">Manifest Consignments From Query Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard('ManifestQueryEndpoint')">Click to Copy</div>
</div>

<div id="ManifestQueryEndpoint" class="staticTabContent" onclick="CopyToClipboard('ManifestQueryEndpoint')">

```
PUT https://api.electioapp.com/consignments/manifestFromQuery
```
</div>

Once you've created a consignment, allocated it to a carrier service and printed labels for it, you're ready to manifest it. To manifest a consignment, use the **[Manifest Consignments From Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery)** endpoint.

> <span class="note-header">More Information:</span>
>  In the context of SortedPRO, the term "manifest" refers to advising the carrier that the consignment in question needs to be collected from the shipper.

The **Manifest Consignments From Query** endpoint enables you to use a query to select consignments to be manifested. You can select consignments via the following criteria:

* `ShippingLocationReference` - The shipping location that the consignment will ship from. For information on how to obtain a list of your organisation's shipping locations and their references, see the [Get Shipping Locations](https://docs.electioapp.com/#/api/GetShippingLocations) page of the API reference.
* `States` - The state that the consignments should be in. All the consignments you provide in the request should be in a state of either _Allocated_ or _Manifest Failed_. If you attempt to manifest a consignment that is not in one of these states then PRO returns an error.
* `Carriers` - The carriers that the consignments are allocated to.
* `LabelsPrinted` - Whether or not the labels for the consignments have already been printed.
* `ShippingDate` - The date that the consignment is scheduled to ship.
* `ShippingDateRanges`- A range of scheduled shipping dates.

Once PRO has attempted to add the consignments to the manifest queue, the **Manifest Consignments From Query** endpoint returns a `Message` indicating how many consignments met the terms of the query and how many it was able to queue. It also returns a `FailedConsignments` array listing the `consignmentReferences` of those consignments that PRO was unable to queue for manifest.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Manifest Consignments From Query</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments From Query</a></strong> page of the API Reference. 

### Examples

The example shows a request to manifest all consignments that are allocated to Carrier X, shipping from a location with the `ShippingLocationReference` _Location1_, and have already had their labels printed. The response indicates that PRO found 10 consignments meeting these criteria, and that all 10 were successfully queued for manifest.

<div class="tab">
    <button class="staticTabButton">Example Manifest Consignments From Query Request</button>
    <div class="copybutton" onclick="CopyToClipboard('ManifestQueryRequest')">Click to Copy</div>
</div>

<div id="ManifestQueryRequest" class="staticTabContent" onclick="CopyToClipboard('ManifestQueryRequest')">

```json
{
  "ShippingLocationReferences": [
    "Location1"
  ],
  "States": [
    "Allocated"
  ],
  "Carriers": [
    "CARRIER_X"
  ],
  "LabelsPrinted": true
}
```
</div>

<div class="tab">
    <button class="staticTabButton">Example Manifest Consignments From Query Response</button>
    <div class="copybutton" onclick="CopyToClipboard('ManifestQueryResponse')">Click to Copy</div>
</div>

<div id="ManifestQueryResponse" class="staticTabContent" onclick="CopyToClipboard('ManifestQueryResponse')">

```json
{
  "Message": "Query found 10 consignment(s). 10 successfully queued to manifest. 0 failed to be added to the queue"
}
```

</div>