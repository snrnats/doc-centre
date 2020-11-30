---
uid: pro-api-help-shipments-editing-shipment-groups
title: Editing Shipment Groups
tags: shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Editing Shipment Groups

This page explains how to add shipments to and remove them from a shipment group. It also explains how to lock shipment groups so that they can't be edited.

---

## Adding and Removing Shipments in Bulk

The **Update Shipment Group** endpoint enables you to add and/or remove multiple shipments from a shipment group in a single API call. To call **Update Shipment Group**, send a `PUT` request to `https://api.sorted.com/pro/shipment_groups/`. The body of the request should contain:

* The unique `reference` of the shipment group you want to update (_not_ the user-defined `custom_reference`). This must be an open and unlocked shipment group.
* An `add_shipments` property listing the unique `references` of the shipments you want to add to the group. These shipments must not be a member of either the specified shipment group or any other open shipment group. 
* A `remove_shipments` property listing the unique `references` of the shipments you want to remove from the group. These shipments must be a member of the specified shipment group. 

Once it has received the request, PRO makes the requested additions and removals and returns a standard resource result object with links to the updated shipment group.

> [!NOTE]
> For full reference information on the **Update Shipment Group** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments-api-ref.html#tag/Shipment-Groups/paths/~1shipment_groups/put).

### Update Shipment Group Example

The example shows a request to add three shipments to and remove two shipments from shipment group _sg_00682731282010871067439042134016_.

# [Update Shipment Group Request](#tab/update-shipment-group-request)

`https://api.sorted.com/pro/shipment_groups/`

```json
{
  "reference": "sg_00682731282010871067439042134016",
  "add_shipments": [
      "sp_00682731282010871067439042134016",
      "sp_00682731282010871067439042134045",
      "sp_00682731282010871067439042134076"
    ],
  "remove_shipments": [
      "sp_00682731282010871067439042134765",
      "sp_00682731282010871067439042134100"
    ]
}
```

# [Update Shipment Group Response](#tab/update-shipment-group-response)

```json
{
  "reference": "sg_00682731282010871067439042134016",
  "message": "Shipment group sg_00682731282010871067439042134016 updated successfully",
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/groups/sg_00682731282010871067439042134016",
      "rel": "self",
      "reference": "sg_00682731282010871067439042134016",
      "type": "shipment_group"
    }
  ]
}
```
---

## Adding Individual Shipments to a Shipment Group

The **Add Shipment to Group** endpoints enable you to add individual shipments to an open and unlocked shipment group. You can select the group to add the shipment to in two ways: 

* Using the group's unique `{reference}` - send a `PUT` request to `https://api.sorted.com/pro/shipment_groups/{reference}/shipments/{shipment_ref}`. 
* Using a combination of the group's `{custom_ref}` and `{version}`- send a `PUT` request to `https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_ref}/{version}/shipments/{shipment_ref}`. The `{version}` parameter can be either an integer or the value _latest_.

> [!NOTE]
>
> For an explanation of versioning in PRO shipment groups, see the [Versioning in Shipment Groups](/pro/api/shipments/getting_shipment_groups.html#versioning-in-shipment-groups) section of the [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html) page.

In both cases, `{shipment_ref}` is the unique reference of the shipment you want to add to the group. This shipment must not be a member of either the specified shipment group or any other open shipment group. 

Once it has received the request, PRO adds the specified shipment to the specified group and returns a standard resource result object with links to the shipment group that was updated.

> [!NOTE]
> For full reference information on the **Add Shipment to Group** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments-api-ref.html#tag/Shipment-Groups/paths/~1shipment_groups~1custom_reference~1{customReference}~1{version}~1shipments~1{shipmentReference}/put).

### Add Shipment to Group Examples

The examples show two requests to add shipment _sp_00013473827456470532303387361290_ to group _sg_00013464648946915264789208891778_. In the first call, the group is identified by its unique `{reference}`, and in the second it is identified by its `{custom_ref}` and `{version}`. The response for both calls is the same.

# [Add Shipment to Group Request](#tab/add-shipment-to-group-request)

```json
PUT https://api.sorted.com/pro/shipment_groups/sg_00013464648946915264789208891778/shipments/sp_00013473827456470532303387361290
PUT https://api.sorted.com/pro/shipment_groups/custom_reference/CarrierX-PM/1/shipments/sp_00013473827456470532303387361290
```

# [Add Shipment to Group Response](#tab/add-shipment-to-group-response)

```json
{
  "reference": "sg_00013464648946915264789208891778",
  "message": "Shipment group sg_00013464648946915264789208891778 updated successfully",
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/groups/sg_00013464648946915264789208891778",
      "rel": "self",
      "reference": "sg_00013464648946915264789208891778",
      "type": "shipment_group"
    }
  ]
}
```
---

## Removing Individual Shipments from a Group

The **Remove Shipment from Group** endpoints enable you to remove individual shipments from an open and unlocked shipment group. You can specify the group that the shipment is to be removed from in two ways: 

* Using the group's unique `{reference}` - send a `DELETE` request to `https://api.sorted.com/pro/shipment_groups/{reference}/shipments/{shipment_ref}`. This must be an open and unlocked shipment group.
* Using a combination of the group's `{custom_ref}` and `{version}`- send a `DELETE` request to `https://api.sorted.com/pro/shipment_groups/custom_reference/{custom_ref}/{version}/shipments/{shipment_ref}`. The `{version}` parameter can be either an integer or the value _latest_.

> [!NOTE]
>
> For more information on how versioning works in PRO shipment groups, see the [Versioning in Shipment Groups](/pro/api/shipments/getting_shipment_groups.html#versioning-in-shipment-groups) section of the [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html) page.

In both cases, `{shipment_ref}` is the unique reference of the shipment you want to remove from the group. This shipment must be a member of the specified shipment group. 

Once it has received the request, PRO removes the specified shipment from the specified group and returns a standard resource result object with links to the updated shipment group.

> [!NOTE]
> For full reference information on the **Remove Shipment from Group** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments-api-ref.html#tag/Shipment-Groups/paths/~1shipment_groups~1custom_reference~1{customReference}~1{version}~1shipments~1{shipmentReference}/delete).

### Remove Shipment from Group Examples

The examples show two requests to remove shipment _sp_00013473827456470532303387361290_ from group _sg_00013464648946915264789208891778_. In the first call, the group is identified by its unique `{reference}`, and in the second it is identified by its `{custom_ref}` and `{version}`. The response for both calls is the same.

# [Remove Shipment from Group Request](#tab/remove-shipment-from-group-request)

```json
DELETE https://api.sorted.com/pro/shipment_groups/sg_00013464648946915264789208891778/shipments/sp_00013473827456470532303387361290
DELETE https://api.sorted.com/pro/shipment_groups/custom_reference/CarrierX-PM/1/shipments/sp_00013473827456470532303387361290
```

# [Remove Shipment from Group Response](#tab/remove-shipment-from-group-response)

```json
{
  "reference": "sg_00013464648946915264789208891778",
  "message": "Shipment group sg_00013464648946915264789208891778 updated successfully",
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/groups/sg_00013464648946915264789208891778",
      "rel": "self",
      "reference": "sg_00013464648946915264789208891778",
      "type": "shipment_group"
    }
  ]
}
```
---

## Locking and Unlocking Shipment Groups

Locking a shipment group means that it can no longer be edited. You can only get collection notes for locked shipment groups.

> [!NOTE]
> For more information on getting collection notes, see the [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html) page.

### Locking Shipment Groups

You can lock shipment groups using the **Lock Shipment Group** endpoint. To call **Lock Shipment Group**, send a `POST` request to `https://api.sorted.com/pro/shipment_groups/{reference}/lock`, where `{reference}` is the unique reference of the group you want to lock.

PRO locks the group and returns a standard resource result object with links to the shipment group that was updated.

> [!NOTE]
> For full reference information on the **Lock Shipment Group** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments-api-ref.html#tag/Shipment-Groups/paths/~1shipment_groups~1{shipmentGroupReference}~1lock/post).

### Unlocking Shipment Groups

You can unlock shipment groups using the **Unlock Shipment Group** endpoint. To call **Unlock Shipment Group**, send a `POST` request to `https://api.sorted.com/pro/shipment_groups/{reference}/unlock`, where `{reference}` is the unique reference of the group you want to unlock.

PRO unlocks the group and returns a standard resource result object with links to the shipment group that was updated.

> [!NOTE]
> For full reference information on the **Unlock Shipment Group** endpoint, see the [Shipments data contract#(/pro/api/reference/shipments-api-ref.html#tag/Shipment-Groups/paths/~1shipment_groups~1{shipmentGroupReference}~1unlock/post).

### Example

The example shows a successful request to lock shipment group _sg_00013464648946915264789208891778_.

# [Lock Shipment Group Request](#tab/lock-shipment-group-request)

```json
POST https://api.sorted.com/pro/shipment_groups/sg_00013464648946915264789208891778/lock
```

# [Lock Shipment Group Response](#tab/lock-shipment-group-response)

```json
{
  "reference": "sg_00013464648946915264789208891778",
  "message": "Shipment group sg_00013464648946915264789208891778 locked successfully",
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/groups/sg_00013464648946915264789208891778",
      "rel": "self",
      "reference": "sg_00013464648946915264789208891778",
      "type": "shipment_group"
    }
  ]
}
```
---

## Next Steps

* Learn how to retrieve existing shipment groups: [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html)
* Learn how to retrieve collection notes: [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html)
* Learn how to close shipment groups: [Closing Shipment Groups](/pro/api/shipments/closing_shipment_groups.html)