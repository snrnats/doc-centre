# Updating Shipment Groups

This endpoint is used to update an existing `shipment_group`.

This can be used to:

- Add additional `shipments` to the group (as long as the `10,000` member limit is not exceeded); or
- Remove existing `shipments` from the group

> [!WARNING]
> The `custom_reference` property for a `shipment_group` **cannot** be updated once the group has been created.

 Lock Shipment Group (M)

This endpoint allows the customer to prevent any further inadvertent changes to a `shipment_group`.

> [!NOTE]
> It is not a requirement that customers must use this endpoint, but it provides a convenient mechanism for preventing further changes without closing the group which is an irreversible operation.

Unlock Shipment Group (M)
This endpoint is used to unlock a shipment_group that was previously locked. Unlocking allows further changes to be made to the shipment_group.

Close Shipment Group (M)

This endpoint is used when all `shipments` within a `shipment_group` have been `manifested` or `cancelled` and the group is no longer required. The group will not be deleted but will be retained in a `closed` `state`. You may still retrieve the details of the `shipment_group` via the API for a period of time but will no longer be able to otherwise operate on the group.

> [!CAUTION]
> This operation is not reversible. Once a `shipment_group` has been `closed` it cannot be re-opened.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>
