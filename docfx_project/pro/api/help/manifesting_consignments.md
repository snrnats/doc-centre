---
uid: pro-api-help-manifesting-consignments
title: Manifesting Consignments
tags: consignments,pro,api,manifesting
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/06/2020
---
# Manifesting Consignments

Once you've created a consignment and allocated it to a carrier service, you're ready to manifest it. This page explains how to manifest consignments, how to view existing customer manifests, and how to set a consignment as _Ready to Ship_.

---

## Manifesting Overview

In the context of SortedPRO, the term "manifesting" refers to collating, formatting and transmitting consignment data to carriers. It is the final step of most PRO workflows.

You can only manifest consignments that are in a state of _Allocated_, _Manifest Failed_, or _ReadyToShip_. If you attempt to manifest a consignment that is not in one of these states then PRO returns an error.

PRO has two manifest endpoints: 

* **Manifest Consignments** enables you to manifest multiple consignments at once by providing a list of `{consignmentReferences}`. 
* **Manifest Consignments From Query** enables you to manifest all consignments that meet a specified set of search criteria.

> [!CAUTION]
>
> Every successful request to a manifest endpoint results in data being transmitted to the carrier. Therefore, Sorted strongly advise that you do not manifest consignments individually, and that consignment manifesting is aligned with the carrier collection times from the warehouse.

Manifesting a consignment changes its state to _Manifested_. At this point the carrier is aware of the consignment, and will collect it unless otherwise advised. In order to prevent the consignment being shipped, you would need to either cancel or deallocate it. 

> [!NOTE]
>
> For more information on cancelling consignments, see the [Cancelling Consignments](/pro/api/help/cancelling_consignments.html) page.
>
> For more information on deallocating consignments, see the [Deallocating Consignments](/pro/api/help/deallocating_consignments.html) page.

At this point, you should also look to print labels for the consignment, if you have not already done so. See [Getting Labels](/pro/api/help/getting_labels.html) for an explanation of how to retrieve package labels.

> [!NOTE]
>
> For worked examples showing consignments being manifested, see any of the flows in the [Example Call Flows](/pro/api/help/flows.html) section.

## Manifesting Consignments

Perhaps the simplest way to manifest consignments in PRO is to use the **Manifest Consignment** endpoint. **Manifest Consignment** enables you to manifest multiple consignments at once by providing their `ConsignmentReferences`.

To call **Manifest Consignments**, send a `PUT` request to `https://api.electioapp.com/consignments/manifest`. The body of the request should contain a `ConsignmentReferences` list. 

Once PRO has received the request, it attempts to manifest the consignments listed in the request. The system then returns an array of messages indicating whether each individual consignment was successfully manifested.

> [!NOTE]
>
>  For full reference information on the <strong>Manifest Consignments</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignments">Manifest Consignments</a></strong> page of the API Reference. 

### Examples

The example shows a request to manifest three consignments. The response indicates that all three consignments were successfully manifested.

# [Manifest Consignments Request](#tab/manifest-consignments-request)

`PUT https://api.electioapp.com/consignments/manifest`

```json
{
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```

# [Manifest Consignments Response](#tab/manifest-consignments-response)

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

---

## Manifesting Consignments Using a Query

The **Manifest Consignments From Query** endpoint enables you to manifest consignments using a query, rather than by providing consignment references directly. 

To call **Manifest Consignments From Query**, send a `POST` request to `https://api.electioapp.com/consignments/manifestFromQuery`. The body of the request should contain consignment search criteria. You can use the following query fields:

* `ShippingLocationReference` - The shipping location that the consignment will ship from. For information on how to obtain a list of your organisation's shipping locations and their references, see the [Get Shipping Locations](https://docs.electioapp.com/#/api/GetShippingLocations) page of the API reference.
* `States` - The state that the consignments should be in. All the consignments you provide in the request should be in a state of either _Allocated_, _Manifest Failed_, or _ReadyToShip_. If you attempt to manifest a consignment that is not in one of these states then PRO returns an error.
* `Carriers` - The carriers that the consignments are allocated to.
* `LabelsPrinted` - Whether or not the labels for the consignments have already been printed.
* `ShippingDate` - The date that the consignment is scheduled to ship.
* `ShippingDateRanges`- A range of scheduled shipping dates.

Once the request is received, PRO attempts to manifest any consignments that meet the specified criteria. PRO then returns a `Message` indicating how many consignments met the terms of the query and how many it was able to add to the manifest queue. It also returns a `FailedConsignments` array listing the `consignmentReferences` of those consignments that PRO was unable to queue for manifest.

> [!NOTE]
>
>  For full reference information on the <strong>Manifest Consignments From Query</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments From Query</a></strong> page of the API Reference. 

### Setting Consignments As Ready to Ship

PRO's **Set Ready To Ship** and **Set Not Ready To Ship** endpoints can help you when manifesting consignments from queries. These endpoints set a consignment's `consignmentState` to _ReadyToShip_. Although setting a consignment as ready to ship doesn't alter the consignment in and of itself, it can be useful as a means of marking consignments as ready for manifest via the **Manifest Consignments From Query** endpoint.

To call **Set Ready To Ship**, send a `PUT` request to `https://api.electioapp.com/consignments/setreadytoship`. The body of the request should comprise a list containing the `{consignmentReferences}` of all the consignments you want to set as _ReadyToShip_.

> [!NOTE]
>
> You can only set consignments that are in an _Allocated_ state as _ReadyToShip_.

Once the request is received, PRO changes the `consignmentStates` of all the relevant consignments to _ReadyToShip_ and returns a confirmation message. You could then manifest these consignments with a simple **Manifest Consignments From Query** call adding all consignments in that state to the manifest queue. 

The example below shows a successful request to set two consignments as _ReadyToShip_, and a further **Manifest Consignments From Query** call to manifest all consignments in that state.

# [Ready To Ship Request](#tab/ready-to-ship-request)

`PUT https://api.electioapp.com/consignments/setreadytoship`

```json
[
    "EC-000-05D-EM7",
    "EC-000-05D-EKV"
]
```

# [Ready To Ship Response](#tab/ready-to-ship-response)

```json
[
    {
        "IsSuccess": true,
        "Message": "Consignment marked as Ready To Ship completed successfully",
        "Data": "EC-000-05D-EM7",
        "ApiLinks": [
            {
                "Rel": "detail",
                "Href": "https://api.electioapp.com/consignments/EC-000-05D-EM7"
            }
        ]
    },
    {
        "IsSuccess": true,
        "Message": "Consignment marked as Ready To Ship completed successfully",
        "Data": "EC-000-05D-EKV",
        "ApiLinks": [
            {
                "Rel": "detail",
                "Href": "https://api.electioapp.com/consignments/EC-000-05D-EKV"
            }
        ]
    }
]    
```

# [Manifest Query](#tab/manifest-query)

`POST https://api.electioapp.com/consignments/manifestFromQuery`

```json
{
  "States": [
    "ReadyToShip"
  ]
}
```

---

The **Set Not Ready To Ship** endpoint works in exactly the same way as **Set Ready To Ship**, only in reverse. It takes the `consignmentReferences` of consignments in a _ReadyToShip_ state and returns them to a state of _Allocated_, enabling them to be deallocated (and subsequently edited if required) or cancelled.

To call **Set Not Ready To Ship**, send a `PUT` request to `https://api.electioapp.com/consignments/setnotreadytoship`. The body of the request should comprise a list containing the `{consignmentReferences}` of all the consignments you want to return to an _Allocated_ state.

The example below shows a successful **Set Not Ready To Ship** request for a single consignment.

# [Not Ready To Ship Request](#tab/not-ready-to-ship-request)

`PUT https://api.electioapp.com/consignments/setnotreadytoship`

```json
[
	"EC-000-05D-GHR"
]
```

# [Not Ready To Ship Response](#tab/not-ready-to-ship-response)

```json
[
    {
        "IsSuccess": true,
        "Message": "Consignment set back to Allocated from Ready To Ship completed successfully",
        "Data": "EC-000-05D-GHR",
        "ApiLinks": [
            {
                "Rel": "detail",
                "Href": "https://api.electioapp.com/consignments/EC-000-05D-GHR"
            }
        ]
    }
]
```

---

### Manifest Consignments From Query Example

The example shows a request to manifest all consignments that are allocated to Carrier X, shipping from a location with the `ShippingLocationReference` _Location1_, and have already had their labels printed. The response indicates that PRO found 10 consignments meeting these criteria, and that all 10 were successfully queued for manifest.

# [Manifest From Query Request](#tab/manifest-from-query-request)

`POST https://api.electioapp.com/consignments/manifestFromQuery`

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
# [Manifest From Query Response](#tab/manifest-from-query-response)

```json
{
  "Message": "Query found 10 consignment(s). 10 successfully queued to manifest. 0 failed to be added to the queue"
}
```

---

## Retrieving Customer Manifests

PRO has two endpoints that enable you to retrieve current customer manifest details: 

* **Get Customer Manifests** enables you to retrieve a summary of all current manifests.
* **Get Customer Manifest** enables you to download an individual manifest file as a PDF.

### Retrieving a Manifest Summary

To call **Get Customer Manifests**, send a `GET` request to  `https://api.electioapp.com/consignments/customer/manifests`. Optionally, you can add a `?shippingLocationReference=string` parameter, where `shippingLocationReference` is the unique reference of a shipping location you want to retrieve manifests for.

> [!NOTE]
> 
> You can get a list of valid shipping locations by calling the **Get Shipping Locations** endpoint. For reference information on **Get Shipping Locations**, see the <a href="https://docs.electioapp.com/#/api/GetShippingLocations">API Reference</a>.

Once it has received the request, PRO returns a summary of all current manifests, including the following information:

* The manifest's unique reference.
* The filename of the manifest.
* The date the manifest was created.
* The name of the carrier.
* The number of bookings on the manifest.

If you added a `shippingLocationReference` parameter, then the summary only includes manifests that correspond to shipments from that particular shipping location.

### Example Get Customer Manifests Request

This example shows a request for details of all manifests associated with shipping location _EDC5-SL1_. PRO has returned a summary of three manifest files.

# [Get Customer Manifests Request](#tab/get-customer-manifests-request)

```json
GET https://api.electioapp.com/consignments/customer/manifests?shippingLocationReference=EDC5-SL1
```

# [Get Customer Manifests Response](#tab/get-customer-manifests-response)

```json
[
    {
        "ManifestReference": "3837b862e2ab47de95f11c016f36f072",
        "ManifestFileStorageContainer": "electio-carrierbooking-sandbox-upsready-edc5-ups",
        "ManifestFileName": "EDC5_SL1-3837b862e2ab47de95f11c016f36f072.pdf",
        "ShippingLocationReference": "EDC5-SL1",
        "ShippingLocationName": null,
        "Created": "2019-09-16T09:09:56.9894014+00:00",
        "CarrierName": "Ups",
        "BookingsCount": 1,
        "ManifestFileNameSentToCarrier": null
    },
    {
        "ManifestReference": "ffe8739761624fc695e3fbcb72a63557",
        "ManifestFileStorageContainer": "electio-carrierbooking-sandbox-upsready-edc5-ups",
        "ManifestFileName": "EDC5_SL1-ffe8739761624fc695e3fbcb72a63557.pdf",
        "ShippingLocationReference": "EDC5-SL1",
        "ShippingLocationName": null,
        "Created": "2019-08-15T12:20:06.5067094+00:00",
        "CarrierName": "Ups",
        "BookingsCount": 1,
        "ManifestFileNameSentToCarrier": null
    },
    {
        "ManifestReference": "49fcade22cf24458b1314704a4102738",
        "ManifestFileStorageContainer": "electio-carrierbooking-sandbox-upsready-edc5-ups",
        "ManifestFileName": "EDC5_SL1-49fcade22cf24458b1314704a4102738.pdf",
        "ShippingLocationReference": "EDC5-SL1",
        "ShippingLocationName": null,
        "Created": "2019-08-14T09:30:54.4984558+00:00",
        "CarrierName": "Ups",
        "BookingsCount": 1,
        "ManifestFileNameSentToCarrier": null
    }
]
```

---

### Downloading a Manifest File

The **Get Customer Manifest** endpoint enables you to download an individual manifest file in PDF format. To call **Get Customer Manifest**, send a `GET` request to `https://api.electioapp.com/consignments/customer/manifest/{manifestReference}`, where `{manifestReference}` is the unique reference of the manifest you want to download.

> [!NOTE]
>
> You can get the `ManifestReference` for a particular manifest by making a **Get Customer Manifests** request for a summary of existing manifest details. Each manifest summary returned contains a `ManifestReference`.

Once the request is received, PRO returns the specified manifest file as a base-64 encoded byte array. You will need to decode the file in order to view the label itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

## Next Steps

* Learn how to track consignments via PRO's APIs at the [Tracking Consignments](/pro/api/help/tracking_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to deallocate a consignment at the [Deallocating Consignments](/pro/api/help/deallocating_consignments.html)page.

> [!NOTE]
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).