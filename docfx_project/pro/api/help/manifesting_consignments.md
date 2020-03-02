# Manifesting Consignments

Once you've created a consignment and allocated it to a carrier service, you're ready to manifest it. This page explains how to manifest consignments, how to view existing customer manifests, and how to set a consignment as ready to ship.

---

## Manifesting Overview

In the context of SortedPRO, the term **manifesting** refers to advising the carrier that the consignment in question needs to be collected from the shipper. It is the final step of most PRO workflows.

You can only manifest consignments that are in a state of either _Allocated_ or _Manifest Failed_. If you attempt to manifest a consignment that is not in one of these states then PRO returns an error.

PRO has two manifest endpoints: 

* **Manifest Consignments** enables you to manifest multiple consignments at once by providing a list of `{consignmentReference}`s. 
* **Manifest Consignments From Query** enables you to manifest all consignments that meet a specified set of search criteria.

Manifesting a consignment changes its state to _Manifested_. At this point the carrier is aware of the consignment, and will collect it unless otherwise advised. In order to prevent the consignment being shipped, you would need to either cancel or deallocate it. 

> <span class="note-header">More Information:</span>
>
> For more information on cancelling consignments, see the [Cancelling Consignments](/pro/api/help/cancelling_consignments.html) page.
>
> For more information on deallocating consignments, see the [Deallocating Consignments](/pro/api/help/deallocating_consignments.html) page.

At this point, you should also look to print labels for the consignment, if you have not already done so. See [Getting Labels](/pro/api/help/cancelling_consignments.html) for an explanation of how to retrieve package labels.

> <span class="note-header">More Information:</span>
>
> For worked examples showing consignments being manifested, see any of the flows in the [Example Call Flows](/pro/api/help/flows.html) section.

## Manifesting Consignments

Perhaps the simplest way to manifest consignments in PRO is to use the **Manifest Consignment** endpoint. **Manifest Consignment** enables you to manifest multiple consignments at once by providing their unique references

To call **Manifest Consignments**, send a `PUT` request to `https://api.electioapp.com/consignments/manifest`. The body of the request should contain a `ConsignmentReferences` list. 

Once PRO has received the request, it attempts to manifest the consignments listed in the request. The system then returns an array of messages indicating whether each individual consignment was successfully manifested.

> <span class="note-header">Note:</span>
>
>  For full reference information on the <strong>Manifest Consignments</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignments">Manifest Consignments</a></strong> page of the API Reference. 

### Examples

The example shows a request to manifest three consignments. The response indicates that all three consignments were successfully manifested.

<div class="tab">
    <button class="staticTabButton">Example Manifest Consignment Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'manifestConsRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="manifestConsRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'manifestConsRequest')">

```json
{
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```

</div>

<div class="tab">
    <button class="staticTabButton">Example Manifest Consignment Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'manifestConsResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="manifestConsResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'manifestConsResponse')">

```json
[
  {
    "IsSuccess": true,
    "Message": "Consignment EC-000-002-5FG has been manifested successfully.",
    "Data": "EC-000-002-5FG",
    "ApiLinks": [
      {
        "Rel": "Link",
        "Href": "https://api.electioapp.com/consignments/EC-000-002-5FG"
      }
    ]
  },
  {
    "IsSuccess": true,
    "Message": "Consignment EC-000-002-5FG has been manifested successfully.",
    "Data": "EC-000-002-5FG",
    "ApiLinks": [
      {
        "Rel": "Link",
        "Href": "https://api.electioapp.com/consignments/EC-000-002-5FG"
      }
    ]
  },
  {
    "IsSuccess": true,
    "Message": "Consignment EC-000-002-5FG has been manifested successfully.",
    "Data": "EC-000-002-5FG",
    "ApiLinks": [
      {
        "Rel": "Link",
        "Href": "https://api.electioapp.com/consignments/EC-000-002-5FG"
      }
    ]
  }
]
```
</div>

## Manifesting Consignments Using A Query

The **Manifest Consignments From Query** endpoint enables you to use a query to select consignments to be manifested. You can select consignments via the following criteria: PUT https://api.electioapp.com/consignments/manifestFromQuery

* `ShippingLocationReference` - The shipping location that the consignment will ship from. For information on how to obtain a list of your organisation's shipping locations and their references, see the [Get Shipping Locations](https://docs.electioapp.com/#/api/GetShippingLocations) page of the API reference.
* `States` - The state that the consignments should be in. All the consignments you provide in the request should be in a state of either _Allocated_ or _Manifest Failed_. If you attempt to manifest a consignment that is not in one of these states then PRO returns an error.
* `Carriers` - The carriers that the consignments are allocated to.
* `LabelsPrinted` - Whether or not the labels for the consignments have already been printed.
* `ShippingDate` - The date that the consignment is scheduled to ship.
* `ShippingDateRanges`- A range of scheduled shipping dates.

Once PRO has attempted to add the consignments to the manifest queue, the **Manifest Consignments From Query** endpoint returns a `Message` indicating how many consignments met the terms of the query and how many it was able to queue. It also returns a `FailedConsignments` array listing the `consignmentReferences` of those consignments that PRO was unable to queue for manifest.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Manifest Consignments From Query</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments From Query</a></strong> page of the API Reference. 

### Manifest Consignments From Query Example

The example shows a request to manifest all consignments that are allocated to Carrier X, shipping from a location with the `ShippingLocationReference` _Location1_, and have already had their labels printed. The response indicates that PRO found 10 consignments meeting these criteria, and that all 10 were successfully queued for manifest.

<div class="tab">
    <button class="staticTabButton">Example Manifest Consignments From Query Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'ManifestQueryRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="ManifestQueryRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'ManifestQueryRequest')">

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
    <div class="copybutton" onclick="CopyToClipboard(this, 'ManifestQueryResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="ManifestQueryResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'ManifestQueryResponse')">

```json
{
  "Message": "Query found 10 consignment(s). 10 successfully queued to manifest. 0 failed to be added to the queue"
}
```

</div>

## Getting Manifests

Get Customer Manifest

Get Customer Manifests

## Setting a Consignment as Ready to Ship

Set Ready To Ship

Set Not Ready To Ship

## Next Steps

* Learn how to track consignments via PRO's APIs at the [Tracking Consignments](/api/help/tracking_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/api/help/getting_labels.html) page.
* Learn how to deallocate a consignment at the [Deallocating Consignments](/api/help/deallocating_consignments.html)page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>