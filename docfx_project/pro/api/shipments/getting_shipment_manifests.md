---
uid: pro-api-help-shipments-getting-shipment-manifests
title: Getting Shipment Manifests
tags: shipments,pro,api,manifesting
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Shipment Manifests

This page explains how to use the **Get Manifest** endpoint to retrieve existing manifests.

---

## The Get Manifest Endpoint

To call **Get Manifest**, send a `GET` request to `https://api.sorted.com/pro/shipments/manifests/{reference}`, where `{reference}` is the unique reference of the manifest you want to retrieve. Manifest references begin with _ma_ and can be found in the `manifest_results.reference` property of the Manifest Response returned when the shipment was manifested.

PRO returns the requested manifest file. The manifest lists the shipments that were manifested in that operation and the date that the file was created.

> [!NOTE]
>
> * For full reference information on the **Get Manifest** endpoint, see the [Shipments data contract](/pro/api/reference/shipments-api-ref.html#tag/Manifest/paths/~1shipments~1manifests~1{manifestReference}/get).

## Get Manifest Example

The example shows a successful request to retrieve manifest _ma_00674859184207899628998023184384_.

# [Get Manifest Request](#tab/get-manifest-request)

```json
GET https://api.sorted.com/pro/shipments/manifests/ma_00674859184207899628998023184384
```

# [Get Manifest Response](#tab/get-manifest-response)

```json
{
  "reference": "ma_00674859184207899628998023184384",
  "shipments": [
    "sp_00674859460484785620945977737216",
    "sp_00674859460484785620945977737217",
    "sp_00674859460484785620945977737218",
    "sp_00674859460484785620945977737219",
    "sp_00674859460484785620945977737220",
    "sp_00674859460484785620945977737221",
    "sp_00674859460503232365019687288912",
    "sp_00674859460503232365019687288913"
  ],
  "created": "2020-07-23T21:16:44.6572271+00:00"
}
```
---

## Next Steps

* Learn how to generate and select delivery quotes: [Managing Shipment Quotes](/pro/api/shipments/managing_shipment_quotes.html)
* Learn how to configure shipment groups: [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) 
* Learn how to get collection notes: [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html)