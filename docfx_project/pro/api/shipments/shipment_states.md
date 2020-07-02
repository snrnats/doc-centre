---
uid: pro-api-help-shipments-shipment-states
title: Shipment States
tags: shipments,pro,api
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Shipment States

All PRO shipments have a `{state}`, indicating the point in the delivery process that that particular shipment is at. This page lists PRO's shipment states 

---

## List of States

| Value | Description |
|------ | ------------|
| `unallocated` | The default initial state. The shipment has not been booked with a carrier. |
| `allocating` | The shipment is in the process of being allocated. It cannot change state until allocation either completes or fails. |
| `allocation_failed` | The most recent attempt to allocate the shipment failed. |
| `allocated` | The shipment is currently allocated to a carrier service. |
| `manifesting` | The shipment is in the process of being manifested. It cannot change state until manifesting either completes or fails. |
| `manifested` | The shipment has been manifested with the carrier successfully. |
| `manifest_failed` | The most recent attempt to manifest the shipment failed. |
| `collection_booking_pending` | A collection booking is queued but has neither failed or succeeded. Only `on_demand` shipments can assume this state. |
| `collection_booked` | A collection was successfully booked. Only `on_demand` shipments can assume this state. |
| `collection_booking_failed` | A collection booking was attempted but was not successful. Only `on_demand` shipments can assume this state. |
| `dispatched` | The shipment has been dispatched. This state is normally used when the carrier does not or cannot provide tracking events. |
| `awaiting_drop_off` | The carrier is waiting for the customer to drop off the shipment. |
| `at_drop_off_point` | The shipment is at the drop off point and is waiting to be picked up. |
| `in_transit` | The shipment is currently being transported but has not yet been delivered. |
| `delayed` | The shipment is delayed and is likely to be late. |
| `out_for_delivery` | The shipment is out for delivery. |
| `delivery_failed` | Delivery of the shipment failed. |
| `delivery_failed_card_left` | Delivery of the shipment failed, and the driver left a card. |
| `delivered` | The shipment has been delivered successfully. |
| `partially_delivered` | One or more parts of the shipment have been delivered, but there still some parts that have not yet been delivered. |
| `at_collection_point` | The shipment is at a collection point waiting to be collected. |
| `returned_to_sender` | The shipment has been returned to the sender. |
| `action_required` | The shipment needs manual intervention in order to effect successful delivery. |
| `missing` | The shipment is missing. |
| `lost` | The shipment is lost. |
| `damaged` | The shipment has been damaged. |
| `destroyed` | The shipment has been destroyed by the carrier (either because it was dangerous, or it was severely damaged). |
| `cancelling` | The shipment is in the process of being cancelled. It cannot change statue until the cancellation either succeeds or fails. |
| `cancelled` | The shipment has been cancelled. No further changes may be made to the shipment. |
| `in_transit_waiting` | The shipment is in transit and is waiting for further action from the carrier. |
| `held_by_carrier` | The shipment is currently being held by the carrier. |
| `exchange_failed` | An attempt to exchange the shipment between carriers failed. |
| `at_customs` | The shipment is at customs. |
| `cleared_customs` | The shipment has cleared customs. |
| `delivered_damaged` | The shipment was delivered in a damaged condition. |
| `ready_to_ship` | The shipment is ready to be shipped. This is a pre-manifest state. |
| `carrier_collected` | The shipment has been collected by the carrier. This status is usually used by `on_demand` carriers. |
| `carrier_changed` | The shipment has been handed over to a new carrier. |
| `customer_collected` | The shipment has been collected by the customer (e.g. from a pick-up location). |
| `carrier_collection_failed` | The carrier failed to collect the shipment. |
| `customer_collection_failed` | The customer failed to collect the shipment. |
| `at_customer_collection_point` | The shipment been delivered to the collection point. |

## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)