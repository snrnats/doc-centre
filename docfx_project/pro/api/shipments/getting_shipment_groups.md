---
uid: pro-api-help-shipments-getting-shipment-groups
title: Getting Shipment Groups
tags: v2,shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com
created: 08/10/2020
---
# Getting Shipment Groups

This page explains the various ways in which you can retrieve existing shipment group data.

---

## Overview of Retrieving Shipment Groups

PRO has three endpoints that enable you to retrieve details of existing shipment groups:

* **Get Shipment Group** retrieves a single shipment group by its unique `reference`.
* **Get Shipment Groups by Custom Reference** retrieves a summary of any shipment groups that have the specified `custom_reference`.
* **Get Shipment Group by Custom Reference** retrieves a single shipment group using a combination of `custom_reference` and `version`.

## Shipment Group References

In PRO, shipment groups can be retrieved by two types of reference: 

* `reference` is a unique identifier generated for every shipment group you create. It begins with _sg_.
* `custom_reference` is a user-defined optional reference that is supplied as part of a **Create Shipment Group** call. While two open groups cannot share the same `custom_reference`, the `custom_reference` of a previously-closed group can be re-used.

Because the `custom_reference` can be re-used, it is not a unique identifier for a group. To this end, PRO uses versioning as a means of uniquely identifying groups by `custom_reference`. 

### Versioning in Shipment Groups

[!include[_shipments_group_versioning](../includes/_shipments_group_versioning.md)]

## Getting Shipment Groups by Group Reference

To call **Get Shipment Group**, send a `GET` request to `https://api.sorted.com/pro/shipment_groups/{reference}`, where `{reference}` is the unique reference of the shipment group you want to retrieve details for.

PRO returns a `shipment_group` object. The `shipment_group` object contains the following information:

* The group's unique `reference`.
* The group's `custom_reference` and `version` (if applicable).
* A list of the `shipments` in the group.
* The current `state` of the group.
* The date that the group was `created`.
* The dates that the group was `locked`, `closed`, and/or `updated` (if applicable).

### Get Shipment Group Example

The example shows a request for shipment _sg_00013464648946915264789208891778_.

# [Get Shipment Group Request](#tab/get-shipment-group-request)

```json
GET https://api.sorted.com/pro/shipment_groups/sg_00013464648946915264789208891778
```

# [Get Shipment Group Response](#tab/get-shipment-group-response)

```json
{
    "reference": "sg_00013464648946915264789208891778",
    "shipments": [
        "sp_00013473827456470532303387361290",
        "sp_09830498509898987009909000543435"
    ],
    "custom_reference": "CarrierX-PM",
    "version": "1",
    "state": "open",
    "created": "2019-05-03T17:00:23+01:00"
}

```
---

## Getting Shipment Groups by Custom Reference

To call **Get Shipment Groups by Custom Reference**, send a `GET` request to `https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_reference}`.

PRO returns details of every shipment group that has the specified `custom_reference`, irrespective of `version`. Specifically, PRO returns a list of `shipment_group_summary` objects.

Each `shipment_group_summary` is a simplified version of the full `shipment_group` object, containing the following information:

* The group's unique `reference`.
* The group's `custom_reference` and `version` (if applicable).
* Links to the full version of the group.

### Example Get Shipment Groups by Custom Reference Call

The example shows a request for a summary of all shipment groups with the `custom_reference` _CarrierX-PM_. PRO has returned a summary of two shipment groups.

# [Get Shipment Groups by Custom Reference Request](#tab/get-shipment-groups-by-custom-reference-request)

```json
GET https://api.sorted.com/pro/shipment_groups/custom_reference/CarrierX-PM
```

# [Get Shipment Groups by Custom Reference Response](#tab/get-shipment-groups-by-custom-reference-response)

```json
[
    {
        "reference": "sg_00013464648946915264789208891778",
        "custom_reference": "CarrierX-PM",
        "version": 1,
        "_links": [
            {
                "rel": "self",
                "href": "/pro/shipment_groups/sg_00013464648946915264789208891778"
            },
            {
                "rel": "version",
                "href": "/pro/shipment_groups/custom_reference/CarrierX-PM/1"
            }
        ]
    },
    {
        "reference": "sg_00013464648946915264789208891788",
        "custom_reference": "CarrierX-PM",
        "version": 2,
        "_links": [
            {
                "rel": "self",
                "href": "/pro/shipment_groups/sg_00013464648946915264789208891788"
            },
            {
                "rel": "version",
                "href": "/pro/shipment_groups/custom_reference/CarrierX-PM/2"
            }
        ]
    }
]
```
---

## Getting a Shipment Group by Custom Reference and Version

To call **Get Shipment Group by Custom Reference**, send a `GET` request to `https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_reference}/{version}`, where `{custom_reference}` is the reference you want to search on and `{version}` represents the group version you want PRO to return. `{version}` can be either an integer or the value _latest_.

PRO returns a full shipment group object (as opposed to the summaries returned by the **Get Shipment Groups by Custom Reference** endpoint). The shipment group object contains the following information:

* The group's unique `reference`.
* The group's `custom_reference` and `version` (if applicable).
* A list of the `shipments` in the group.
* The current `state` of the group.
* The date that the group was `created`.
* The dates that the group was `locked`, `closed`, and/or `updated` (if applicable).

### Example Get Shipment Group by Custom Reference Call

These examples show two calls, based on the data used in previous examples on this page: one to get a group with a `custom_reference` of _CarrierX-PM_ and a `version` of _1_, and one to get the latest _CarrierX-PM_ group.

# [Requests](#tab/requests)

```json
GET https://api.sorted.com/pro/shipment_groups/custom_reference/CarrierX-PM/1
GET https://api.sorted.com/pro/shipment_groups/custom_reference/CarrierX-PM/latest
```

# [Version 1 Response](#tab/version-1-response)

```json
{
    "reference": "sg_00013464648946915264789208891778",
    "shipments": [
        "sp_00013473827456470532303387361290",
        "sp_09830498509898987009909000543435"
    ],
    "custom_reference": "CarrierX-PM",
    "version": "1",
    "state": "open",
    "created": "2019-05-03T17:00:23+01:00"
}

```

# [Latest Version Response](#tab/latest-version-response)

```json
{
    "reference": "sg_00013464648946915264789208891788",
    "shipments": [
        "sp_00013473827456270532303387361927",
        "sp_09830498509898987009909000543108"
    ],
    "custom_reference": "CarrierX-PM",
    "version": "2",    
    "state": "open",
    "created": "2019-05-04T17:00:23+01:00"
}

```
---

## Next Steps

* Learn how to create new shipment groups: [Creating Shipment Groups](/pro/api/shipments/creating_shipment_groups.html)
* Learn how to add and remove shipments from groups: [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html)
* Learn how to retrieve collection notes: [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html)