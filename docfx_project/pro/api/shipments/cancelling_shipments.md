---
uid: pro-api-help-shipments-cancelling-shipments
title: Cancelling Shipments
tags: shipments,pro,api
contributors: andy.walton@sorted.com
created: 06/10/2020
---
# Cancelling Shipments

This page explains how to cancel and delete shipments in PRO.

---

## Cancelling Shipments

To cancel a shipment, use the **Cancel Shipment** endpoint. To call **Cancel Shipment**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/cancel`, where `{reference}` denotes the shipment you want to cancel. Once the request has been received, PRO changes the shipment's `{state}` to _cancelled_ and returns a confirmation message.

You can only cancel a shipment prior to that shipment being manifested. Once a shipment has been manifested it can no longer be cancelled.

Once a shipment has been cancelled, then no further changes can be made to it. In order to reinstate a cancelled shipment you would need to create a new shipment with the same details.

> [!NOTE]
>
> For full reference information on the **Cancel Shipment** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments-api-ref.html#tag/Shipments/paths/~1shipments~1{shipmentReference}~1cancel/put).

### Cancel Shipment Example

The example below shows a successful **Cancel Shipment** request for shipment _sp_00792815110958000332875334549504_.

# [Cancel Shipment Request](#tab/cancel-shipment-request)

```json
PUT https://api.sorted.com/pro/shipments/sp_00792815110958000332875334549504/cancel
```

# [Cancel Shipment Response](#tab/cancel-shipment-response)

```json
{
    "reference": "sp_00792815110958000332875334549504",
    "custom_reference": "77d58d14-53f6-414c-876d-05c9b3cf079a",
    "message": "Shipment sp_00792815110958000332875334549504 has been cancelled",
    "_links": [
        {
            "href": "https://api-int.sorted.com/pro/shipments/sp_00792815110958000332875334549504",
            "rel": "shipment",
            "reference": "sp_00792815110958000332875334549504",
            "type": "shipment"
        }
    ]
}
```
---

## Deleting Shipments

To delete a cancelled shipment, use the **Delete Shipment** endpoint. You can call **Delete Shipment** by sending a `DELETE` request to `https://api.sorted.com/pro/shipments/{reference}`, where `{reference}` refers to the shipment you want to delete. Once the request has been received, PRO permanently deletes the shipment's data and returns a confirmation message.

You can only delete shipments that are in a `state` of _cancelled_. If you attempt to delete a shipment that has not been cancelled then PRO returns an error.

> [!NOTE]
>
> For full reference information on the **Delete Shipment** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments-api-ref.html#tag/Shipments/paths/~1shipments~1{shipmentReference}/delete).

### Delete Shipment Example

The example below shows a successful **Delete Shipment** request for shipment _sp_00595452779180472847666078547968_.

# [Delete Shipment Request](#tab/delete-shipment-request)

```json
DELETE https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968
```
# [Delete Shipment Response](#tab/delete-shipment-response)

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "message": "Shipment sp_00595452779180472847666078547968 was deleted successfully",
  "_links": []
}
```
---

## Next Steps

* Learn how to create, clone, and update shipments: [Creating Shipments](/pro/api/shipments/creating_shipments.html)
* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)