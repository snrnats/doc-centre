---
uid: pro-api-help-shipments-cancelling-shipments
title: Cancelling Shipments
tags: shipments,pro,api
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Cancelling Shipments

This page explains how to cancel and delete shipments in PRO.

---

## Cancelling Shipments

To cancel a shipment, use the **Cancel Shipment** endpoint. You can call **Cancel Shipment** by sending a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/cancel`, where `{reference}` refers to the shipment you want to cancel. Once the request has been received, PRO changes the shipment's `{state}` to _cancelled_ and returns a confirmation message.

You can only cancel a shipment prior to it being manifested. Once a shipment has been manifested it can no longer be cancelled.

Once a shipment has been cancelled, then no further changes can be made to it other than deleting it. If you want to reinstate a cancelled shipment then you will need to create a new shipment with the same details.

> [!NOTE]
>
> For full reference information on the **Cancel Shipment** endpoint, see [LINK HERE]

### Cancel Shipment Example

The example below shows a successful **Cancel Shipment** request for shipment _sp_00595452779180472847666078547968_.

# [Cancel Shipment Request](#tab/cancel-shipment-request)

```json
PUT https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968/cancel
```

# [Cancel Shipment Response](#tab/cancel-shipment-response)

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "custom_reference": "1cb686aa-cc67-4c14-9a92-244d0c5421b3",
  "message": "Shipment sp_00595452779180472847666078547968 has been cancelled",
  "_links": [
    {
      "href": "https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968",
      "rel": "shipment",
      "reference": "sp_00595452779180472847666078547968",
      "type": "shipment"
    }
  ]
}
```
---

## Deleting Shipments

To delete a cancelled shipment, use the **Delete Shipment** endpoint. You can call **Delete Shipment** by sending a `DELETE` request to `https://api.sorted.com/pro/shipments/{reference}`, where `{reference}` refers to the shipment you want to delete. Once the request has been received, PRO permanently deletes the shipment's data and returns a confirmation message.

You can only delete shipments that are in a `state` of _cancelled_. If you attempt to delete a shipment that has not been cancelled then PRO returns an error

> [!NOTE]
>
> For full reference information on the **Delete Shipment** endpoint, see [LINK HERE]

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