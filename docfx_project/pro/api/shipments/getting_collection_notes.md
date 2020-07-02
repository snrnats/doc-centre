---
uid: pro-api-help-shipments-getting-collection-notes
title: Getting Collection Notes
tags: shipments,pro,api,shipment groups,collection notes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Collection Notes

Get Shipment Group Collection Note

This endpoint allows the user to retrieve a `collection_note` for a `shipment_group` by using the reference of the `shipment_group`.

In addition to the endpoint that utilises Sorted’s unique `shipment_group` reference to return a `collection_note`, the API must also support using the customer's own `custom_reference` and `version` for a `shipment_group`.

this endpoint should automatically determine the latest `version` of a `shipment_group` with the specified `custom_reference` if the version parameter is specified as `latest`.

The `latest` `version` will always be the `shipment_group` with the **highest** `version` that *also* has the provided `custom_reference` and is registered for the customer making the query.


Get Collection Note by Query
Get Collection Note by Manifests
