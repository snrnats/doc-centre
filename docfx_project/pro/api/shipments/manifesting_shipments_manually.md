---
uid: pro-api-help-shipments-manifesting-shipments-manually
title: Manifesting Shipments Manually
tags: shipments,pro,api,manifesting
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Manifesting Shipments Manually

This page explains how to use the **Manifest Shipment** and **Manifest Shipments** endpoints to specify the shipments that you want to manifest

---

## Manifesting an Individual Shipment Manually

The **Manifest Shipment** endpoint enables you to manifest an individual shipment. To call **Manifest Shipment**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/manifest`, where `{reference}` is the unique reference for the shipment you want to manifest.

Once PRO has received the request, it attempts to manifest the specified shipment and returns a `manifest_result` containing the following information:

* A unique reference for the manifest item.
* Details of the carrier and service that the shipment was manifested with.
* A message providing details of the result.
* The current state of the shipment as a result of the manifest operation. Ordinarily, this would be _manifesting_.
* A link to the generated manifest.

> [!NOTE]
>
>  For full reference information on the **Manifest Shipment** endpoint, see the Shipments data contract. 

### Manifest Shipment Example

The example shows a successful request to manifest shipment _sp_00673267200365953327505217421312_.

# [Manifest Shipment Request](#tab/manifest-shipment-request)

```json
`PUT https://api.sorted.com/pro/shipments/sp_00673267200365953327505217421312/manifest`
```

# [Manifest Shipment Response](#tab/manifest-shipment-response)

```json
{
  "results": [
    {
      "reference": "ma_00673536672211162995858760007680",
      "carrier": {
        "reference": "XPDI",
        "name": "XPD International",
        "service_reference": "XPDISU",
        "service_name": "XPD International Supreme"
      },
      "message": "Shipment sp_00673267200365953327505217421312 manifested with XDP Worldwide successfully",
      "state": "manifested",
      "shipment_count": 1,
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/shipments/sp_00673267200365953327505217421312",
          "rel": "shipment",
          "reference": "sp_00673267200365953327505217421312",
          "type": "shipment"
        }
      ]
    }
  ]
}
```
---


## Manifesting Multiple Shipments Manually

The **Manifest Shipments** endpoint enables you to manifest multiple shipments at once by providing their `reference`s. To call **Manifest Shipments**, send a `PUT` request to `https://api.sorted.com/pro/shipments/manifest`. The body of the request should contain a `shipments` list. 

Once PRO has received the request, it attempts to manifest the shipments listed in the request. The system then returns a Manifest Response.

[!include[_shipments_manifest_result](../includes/_shipments_manifest_result.md)]

> [!NOTE]
>
>  For full reference information on the **Manifest Shipments** endpoint, see the Shipments data contract. 

### Manifest Shipments Example

The example below shows a request to queue four shipments for manifest. All four shipments were queued successfully.

# [Manifest Shipments Request](#tab/manifest-shipments-request)

```json
{
	"shipments": [
		"sp_00673266917780280862348596215808",
		"sp_00673541275546140590077375780489",
		"sp_00673541275596146590077365780480",
		"sp_00673267200365953327505217421312"
		]
}
```

# [Manifest Shipments Response](#tab/manifest-shipments-response)

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
* Learn how to use PRO's tracking APIs: [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html)