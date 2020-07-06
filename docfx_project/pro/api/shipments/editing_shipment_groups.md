---
uid: pro-api-help-shipments-editing-shipment-groups
title: Editing Shipment Groups
tags: shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Editing Shipment Groups

Update Shipment Group

`PUT https://api.sorted.com/pro/shipment_groups/`

Add Shipment to Group

`PUT https://api.sorted.com/pro/shipment_groups/{reference}/shipments/{shipment_ref}`
`PUT https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_ref}/{version}/shipments/{shipment_ref}`
`PUT https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_ref}/latest/shipments/{shipment_ref}`

Remove Shipment from Group

`DELETE https://api.sorted.com/pro/shipment_groups/{reference}/shipments/{shipment_ref}`
`DELETE https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_ref}/{version}/shipments/{shipment_ref}`
`DELETE https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_ref}/latest/shipments/{shipment_ref}`

Lock Shipment Group

`POST https://api.sorted.com/pro/shipment_groups/{reference}/lock`

Unlock Shipment Group

`POST https://api.sorted.com/pro/shipment_groups/{reference}/unlock`