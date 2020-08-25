---
uid: pro-api-help-shipments-closing-shipment-groups
title: Closing Shipment Groups
tags: shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Closing Shipment Groups

This page explains how to close shipment groups so that no further changes can be made to them.

---

## Overview

The **Close Shipment Group** endpoint permanently closes a specified shipment group. It is intended to be used when all shipments within a group have been either manifested or cancelled and the group is no longer required. 

Closed groups cannot be edited. However, you can still retrieve details of the group. <span class="highlight">IS THERE A TIME LIMIT ON HOW LONG YOU CAN RETRIEVE CLOSED GROUP DETAILS FOR? THE TECH DOCS SORT OF IMPLY THAT BUT DON'T GIVE SPECIFICS</span>

> [!CAUTION]
> Once closed, shipment groups cannot be re-opened. If you want to prevent a shipment group from being edited but may still need to make changes to it later, use the **Lock Shipment Group** endpoint.
>
> For more information on locking shipment groups, see the [Locking and Unlocking Shipment Groups](/pro/api/shipments/editing_shipment_groups.html#locking-and-unlocking-shipment-groups) section of the [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html) page.

## Making a Close Shipment Group Request

To call **Close Shipment Group**, send a `POST` request to `https://api.sorted.com/pro/shipment_groups/{reference}/close`, where `{reference}` is the unique reference of the shipment group you want to close. PRO closes the group and returns a confirmation message and a link to the closed group.

### Close Shipment Group Example

The example shows a successful **Close Shipment Group** request for shipment group _sg_00684650028894794889609836494848_.

# [Close Shipment Group Request](#tab/close-shipment-group-request)

```json
https://api.sorted.com/pro/shipment_groups/sg_00684650028894794889609836494848/close
```

# [Close Shipment Group Response](#tab/close-shipment-group-response)

```json
{
  "reference": "sg_00684650028894794889609836494848",
  "custom_reference": "01bdd7d1-48f1-4aa1-9246-42e39339f51a",
  "message": "Shipment group sg_00684650028894794889609836494848 has been closed successfully",
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/groups/sg_00684650028894794889609836494848",
      "rel": "self",
      "reference": "sg_00684650028894794889609836494848",
      "type": "shipment_group"
    }
  ]
}
```
---

## Next Steps

* Learn how to retrieve existing shipment groups: [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html)
* Learn how to add and remove shipments from groups: [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html)
* Learn how to retrieve collection notes: [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html)