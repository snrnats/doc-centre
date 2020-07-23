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

Manifest Shipment

`PUT https://api.sorted.com/pro/shipments/{reference}/manifest`

[!include[_shipments_manifest_result](../includes/_shipments_manifest_result.md)]

### Manifest Shipment Example

## Manifesting Multiple Shipments Manually

**Manifest Shipments** enables you to manifest multiple shipments at once by providing their `reference`s.

To call **Manifest Shipments**, send a `PUT` request to `https://api.sorted.com/pro/shipments/manifest`. The body of the request should contain a `shipments` list. 

Once PRO has received the request, it attempts to queue the shipments listed in the request for manifest. The system then returns a Manifest Response.

[!include[_shipments_manifest_result](../includes/_shipments_manifest_result.md)]

> [!NOTE]
>
>  For full reference information on the **Manifest Shipments** endpoint, see LINK HERE. 

### Manifest Shipments Example



## Next Steps