---
uid: pro-api-help-shipments-manifesting-shipments-by-shipment-groups
title: Manifesting Shipments by Shipment Groups
tags: v2,shipments,pro,api,manifesting,shipment groups
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Manifesting Shipments by Shipment Groups

This page explains how to use the **Manifest Shipments by Shipment Group** endpoint to manifest all shipments in a particular shipment group

---

## The Manifest Shipments by Shipment Group Endpoint

The **Manifest Shipments by Shipment Group** endpoint manifests all unmanifested shipments in a particular shipment group. It is designed to be used alongside other PRO's other manifest endpoints as a means of "scooping up" any shipments in the group that were not manifested by other methods.

To call **Manifest Shipments by Shipment Group**, send a `POST` request to `https://api.sorted.com/pro/shipment_groups/{reference}/manifest`, where `{reference}` is the unique reference of the shipment group you want to manifest.

Once the request is received, PRO attempts to manifest any unmanifested shipments in the selected shipment group, and returns a Manifest Response.

[!include[_shipments_manifest_result](../includes/_shipments_manifest_result.md)]

> [!NOTE]
>
> * For full reference information on the **Manifest Shipments by Shipment Group** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Manifest/paths/~1shipment_groups~1{shipmentGroupReference}~1manifest/post).
> * For a user guide on with working shipment groups, see the [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) section.

## Manifest Shipments by Shipment Group Example

The example shows a request to manifest shipments belonging to shipment group _example123_. PRO has identified four unmanifested shipments within that group, and has successfully queued them all for manifest.

# [Manifest Shipments by Shipment Group Request](#tab/manifest-shipments-by-shipment-group-request)

```json
`POST https://api.sorted.com/pro/shipment_groups/example123/manifest`
```

# [Manifest Shipments by Shipment Group Response](#tab/manifest-shipments-by-shipment-group-response)

```json
{
  "results": [
    {
      "reference": "ma_00673542211491707169731467018240",
      "carrier": {
        "reference": "XPDI",
        "name": "XPD International",
        "service_reference": "XPDISU",
        "service_name": "XPD International Supreme"
      },
      "message": "4 shipments have been queued for manifest with XDP Worldwide successfully",
      "state": "manifesting",
      "shipment_count": 4,
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/shipments/manifest/ma_00673542211491707169731467018240",
          "rel": "self",
          "reference": "ma_00673542211491707169731467018240",
          "type": "manifest"
        }
      ]
    }
  ]
}
```
---

## Next Steps

* Learn how to generate and select delivery quotes: [Managing Shipment Quotes](/pro/api/shipments/managing_shipment_quotes.html)
* Learn how to configure shipment groups: [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) 
* Learn how to get collection notes: [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html)