---
uid: pro-api-help-shipments-changing-shipment-states-manually
title: Changing Shipment States Manually
tags: shipments,pro,api,shipment states
contributors: andy.walton@sorted.com
created: 26/11/2020
---
# Changing Shipment States Manually

This page explains how to use the **Change Shipment State** endpoint to make manual alterations to a shipment's `state`.

---

## Using the Change Shipment State Endpoint

> [!CAUTION]
> This endpoint is intended to enable you to change the state of a shipment due to exceptional circumstances, rather than as part of a standard workflow. 
>
> PRO only allows certain manual state transitions. For instance, you cannot transition a shipment from a state of `unallocated` to `allocated` – this state change can only be carried out by the application itself as a result of a successful allocation.

To call **Change Shipment State**, send a `PUT` request to `https://api.sorted.com/pro/shipments/state`. The body of the request should contain the unique `reference` of the shipment whose state you want to edit, the `state` that you want that shipment to be placed into, and a free text `reason` property detailing the reason for the change. 

The `reason` property does not affect the request itself, but instead forms part of the shipment's audit trail. PRO logs audit messages for all state transitions, including details of the change initiator.

Once it has received a valid **Change Shipment State** request, PRO places the specified shipment into the requested state and returns a standard Resource Result object.

### Example Change Shipment State Call

The example below shows a request to put shipment _sp_00874350842266620068172088868864_ into a state of `ready_to_ship`. PRO responds with a message confirming that the shipment was placed into the requested state.

# [Change Shipment State Request](#tab/change-shipment-state-request)

`PUT https://api.sorted.com/pro/shipments/state`

```json
{
	"reference": "sp_00874350842266620068172088868864",
	"state": "ready_to_ship	",
	"reason": "For reasons"
}
```

# [Change Shipment State Response](#tab/change-shipment-state-response)

```json
{
    "reference": "sp_00874350842266620068172088868864",
    "message": "Shipment sp_00874350842266620068172088868864 has changed state to ready_to_ship",
    "_links": [
        {
            "href": "https://api-int.sorted.com/pro/shipments/sp_00874350842266620068172088868864",
            "rel": "shipment",
            "reference": "sp_00874350842266620068172088868864",
            "type": "shipment"
        }
    ]
}
```
---

## Next Steps

* Learn how to retrieve existing shipment groups: [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html)
* Learn how to add and remove shipments from groups: [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html)
* Learn how to close shipment groups: [Closing Shipment Groups](/pro/api/shipments/closing_shipment_groups.html)