---
uid: pro-api-help-shipments-manifesting-shipments-by-query
title: Manifesting Shipments by Query
tags: v2,shipments,pro,api,manifesting,query
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Manifesting Shipments by Query

This page explains how to manifest those shipments that meet a particular set of criteria.

---

## The Manifest Shipments by Query Endpoint

The **Manifest Shipments by Query** endpoint enables you to manifest shipments using a query, rather than by providing shipment references directly. To call **Manifest Shipments by Query**, send a `POST` request to `https://api.sorted.com/pro/shipments/manifest/query`. 

The body of the request should contain shipment search criteria. All properties are optional. You can use the following query fields:

* `shipping_locations` - A list of shipping location references. Only shipments originating from these locations will be selected.
* `address_custom_reference` - A specific address reference used to identify shipments. You can specify address `custom_reference` properties when creating a shipment. 
* `shipment_states` - PRO will only select shipments in the specified state. 
* `labels_retrieved` - A boolean value. If provided as `true`, PRO will only manifests those shipments for which labels have already been retrieved. 
* `required_shipping_date` - PRO only matches those shipments shipping within the specified date range. 
* `carrier_reference` - PRO only manifests those shipments bound for the specified carrier.
* `carrier_service_reference` - PRO only manifests those shipments bound for the specified carrier service.

>[!CAUTION]
>
> If you specify both a `carrier_reference` and a `carrier_service_reference`, ensure that the specified service is offered by the specified carrier. If you select a service that is not offered by your specified carrier then PRO will not manifest any shipments.

Once the request is received, PRO attempts to manifest any shipments that meet the specified criteria. The system then returns a Manifest Response.

[!include[_shipments_manifest_result](../includes/_shipments_manifest_result.md)]

> [!NOTE]
>
>  For full reference information on the **Manifest Shipments by Query** endpoint, see the Shipments data contract.

## Manifest Shipments by Query Example

The example shows a request to manifest all allocated shipments that have had their labels retrieved and are shipping from an address with the  `address_custom_reference` _76dc0fd4-1788-48bf-978c-f8601411f9b1_ on 23-07-2020.

In this case, the query has returned four shipments. PRO has successfully queued all of these shipments for allocation.

# [Manifest Shipments by Query Request](#tab/manifest-shipments-by-query-request)

```json
{
    "shipping_locations": null,
    "address_custom_reference": "76dc0fd4-1788-48bf-978c-f8601411f9b1",
    "shipment_states": [
        "allocated"
    ],
    "labels_retrieved": true,
    "required_shipping_date": "2020-07-23T00:00:00+00:00"
}
```

# [Manifest Shipments by Query Response](#tab/manifest-shipments-by-query-response)

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
