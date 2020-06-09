# Cancelling Shipments

This page explains how to cancel and delete shipments in PRO.

---

## Cancelling Shipments

To cancel a shipment, use the **Cancel Shipment** endpoint. You can call **Cancel Shipment** by sending a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/cancel`, where `{reference}` refers to the shipment you want to cancel. Once the request has been received, PRO changes the shipment's `{state}` to _cancelled_ and returns a confirmation message.

You can only cancel a shipment prior to it being manifested. Once a shipment has been manifested it can no longer be cancelled.

<span class="highlight">IS THE ABOVE CORRECT? THAT WAS THE CASE IN CONSIGNMENTS BUT I CAN'T TEST WITH THE STUBS</span>

Once a shipment has been cancelled, then no further changes can be made to it other than deleting it. If you want to reinstate a cancelled shipment then you will need to create a new shipment with the same details.

> <span class="note-header">Note:</span>
>
> For full reference information on the **Cancel Shipment** endpoint, see [LINK HERE]

### Cancel Shipment Example

The example below shows a successful **Cancel Shipment** request for shipment _sp_00595452779180472847666078547968_.

<div class="tab">
    <button class="staticTabButton">Example Cancel Shipment Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'cancelShipmentRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="cancelShipmentRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'cancelShipmentRequest')">

```json
PUT https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968/cancel
```
</div>

<div class="tab">
    <button class="staticTabButton">Example Cancel Shipment Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'cancelShipmentResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="cancelShipmentResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'cancelShipmentResponse')">

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
</div>

## Deleting Shipments

To delete a cancelled shipment, use the **Delete Shipment** endpoint. You can call **Delete Shipment** by sending a `DELETE` request to `https://api.sorted.com/pro/shipments/{reference}`, where `{reference}` refers to the shipment you want to delete. Once the request has been received, PRO permanently deletes the shipment's data and returns a confirmation message.

You can only delete shipments that are in a `state` of _cancelled_. If you attempt to delete a shipment that has not been cancelled then PRO returns an error

> <span class="note-header">Note:</span>
>
> For full reference information on the **Delete Shipment** endpoint, see [LINK HERE]

### Delete Shipment Example

The example below shows a successful **Delete Shipment** request for shipment _sp_00595452779180472847666078547968_.

<div class="tab">
    <button class="staticTabButton">Example Delete Shipment Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'deleteShipmentRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="deleteShipmentRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'deleteShipmentRequest')">

```json
DELETE https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968
```
</div>

<div class="tab">
    <button class="staticTabButton">Example Delete Shipment Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'deleteShipmentResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="deleteShipmentResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'deleteShipmentResponse')">

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "message": "Shipment sp_00595452779180472847666078547968 was deleted successfully",
  "_links": []
}
```
</div>

## Next Steps

* Learn how to create, clone, and update shipments: [Creating Shipments](/pro/api/shipments/creating_shipments.html)
* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>