# Updating Shipments

This page explains how to use REACT's **Update Shipment** and **Delete Shipment** endpoints to keep your registered shipment data up to date.

---

## Updating Shipments

To update a registered shipment, send a <span class="text--orange text--bold">PUT</span> request to `https://api.sorted.com/react/shipments/{id}`, where `{id}` is the REACT ID of the shipment you want to update.

The body of the request should be a [Shipment](https://docs.sorted.com/react/api/#UpdateShipment) resource. This resource will to a large extent overwrite the existing shipment details.

> <span class="note-header">Note:</span>
>
> You must include the shipment's `tracking_reference` in the body of every **Update Shipment** request you make. If you send a request with no `tracking_reference`, or an amended `tracking_reference` property, then REACT returns a [400 - Validation](/react/help/error-codes.html) error.
>
> All other Shipment properties are optional when making **Update Shipment** requests. For more information on available properties, see the [Update Shipment](https://docs.sorted.com/react/api/#UpdateShipment) API reference.

REACT follows the below rules when updating shipments:

<div class="table-1">

| Property                 | Consideration                                                                                                                                                                                                                                                                                                                                                                                        |
| ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `id`                     | You must include the `id` of the shipment in the URL so that REACT can identify the shipment to be updated. However, `id` is a read-only property and cannot be changed manually.                                                                                                                                                                                                                                 |
| `tracking_references`    | You must include the shipment's `tracking_reference` in the body of the request so that REACT can identify the shipment to be updated. However, `tracking_reference` is a read-only property and cannot be changed manually. If you send a new `tracking_reference`, or add additional `tracking_reference` values, then REACT returns a [400 - Validation](/react/help/error-codes.html) error.            |
| `custom_references`      | You can update custom references at any point. REACT replaces all existing reference data with data sent in the **Update Shipment** request. As such, you should include all required references when making an update request, not just new references. To delete all references, send an empty `custom_references` array. If REACT receives a null `custom_references` property, no changes are made. |
| `tags`                   | You can update tags at any point. REACT replaces all existing tags with those tags sent in the **Update Shipment** request. As such, you should include all required tags when making an update request, not just new ones. To delete all tags, send an empty `tags` array. <br/><br/>If REACT receives a null `tags` property, no changes are made. You can add up to 20 tags to a shipment, and each tag must be between three and 30 characters long. If you attempt to add more than 20 tags then only the first 20 are stored. Tags are not case-sensitive, and you cannot add duplicate tags within the same shipment.
| `carrier`                | You can update the shipment's carrier at any point. However, REACT will overwrite the `carrier` property if it receives a tracking event that contains a different carrier name. This property is a label only, and does not have any impact on the shipment itself.                                                                                                                                                                                                                                                                |
| `carrier_service`        | You can update the shipment's carrier service at any point. This field is a label only, and does not have any impact on the shipment itself.                                                                                                                                                                                                                                                                    |
| `shipped_date`           | You can update the shipped date at any point.                                                                                                                                                                                                                                                                                                                                                        |
| `order_date`             | You can update the order date at any point.                                                                                                                                                                                                                                                                                                                                                          |
| `promised_date`          | You can update the promised date at any point. If you change this property then REACT recalculates any properties that are derived from the promised date (for example, `lateness`).                                                                                                                                                                                                                 |
| `expected_delivery_date` | You can update the expected delivery date at any point. However, REACT will overwrite this property if it later receives an event that contains a change in expected date.                                                                                                                                                                                                                           |
| `addresses`              | You can update addresses at any point. REACT replaces all existing address data with data sent in the **Update Shipment** request. As such, you should include all required addresses when making an update request, not just new addresses. To delete all addresses, send an empty `addresses` array. If REACT receives a null `addresses` property, no changes are made.                              |
| `shipment_type`          | You can update the shipment type at any point.                                                                                                                                                                                                                                  |
| `consumer`               | You can update consumer details at any point.                                                                                                                                                                                                                                                                                                                                                        |
| `metadata`               | You can update metadata at any point. REACT replaces all existing metadata with data sent in the **Update Shipment** request. As such, you should include all required metadata when making an update request, not just new metadata. To delete all metadata, send an empty `metadata` array. If REACT receives a null `metadata` property, no changes are made.                                        |
| `retailer`               | You can update retailer details at any point.                                                                                                                                                                                                                                                                                                                                                        |

</div>

Once the shipment has been updated, REACT returns a confirmation response:

```json
{
  "id": "sp_1234567890",
  "message":
    "Shipment record 'sp_1234567890' with tracking reference ['QWERTYUIOP'] updated successfully.",
  "tracking_references": ["QWERTYUIOP"],
  "_links": [
    {
      "href": "https://api.sorted.com/react/shipment/sp_1234567890",
      "rel": "self"
    }
  ]
}
```
<span class="text--caption text--center">Example Update Shipment confirmation response.</span>

## Deleting Shipments

To delete a shipment, send a <span class="text--red text--bold">DELETE</span> request to `https://api.sorted.com/react/shipments/{id}`, where `{id}` is the REACT ID of the shipment you want to delete. You do not need to include any data in the body of the request.

You can only delete shipments that belong to your organisation. Deleting a shipment means that REACT will no longer track that shipment, and you will no longer be able to use REACT's APIs and Dashboard to get information on it.

Once the request has been validated, REACT returns a code *202 - Accepted* with the following confirmation response in its body:

```json
{
  "id": "sp_1234567899900",
  "message":
    "Shipment record 'sp_1234567899900' with tracking reference ['QWERTYUIOOP'] deleted successfully.",
  "tracking_references": ["QWERTYUIOOP"]
}
```
<span class="text--caption text--center">Example Delete Shipment confirmation response.</span>

> <span class="note-header">More Information:</span>
>
> For a more information on the properties returned by the **Delete Shipment** confirmation message, see the [API Reference](https://docs.sorted.com/react/api/#DeleteShipment).

## Next Steps

Learn more about integrating with REACT:

* [Registering Shipments](/react/help/registering-shipments.html)
* [Retrieving Shipment and Event Data](/react/help/retrieving-data.html)
* [Error Codes](/react/help/error-codes.html)
