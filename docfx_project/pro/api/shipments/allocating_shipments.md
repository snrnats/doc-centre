# Allocating Shipments

<span class="highlight">THESE ARE ALL JUST NOTES TO SELF AND AREN'T INTENDED FOR PUBLIC CONSUMPTION (AT LEAST, NOT IN THIS FORM)</span>

In order to make dangerous goods rulesets reusable and simple to manage for customers, the concept we are introducing is that customers will manage which carrier services can carry which types of dangerous goods. This means that Sorted do not have to continually update integrations when new rules are introduced by carriers. This is especially useful in situations where customers have non-standard agreements with carriers.

In this concept, a "dangerous goods ruleset" is created independently of a carrier service and can then be applied to or linked to a carrier service. Then, when allocating, the dangerous goods rules should be considered and any service which does not meet the rules should be excluded.

When allocating or retrieving quotes for a shipment, the Shipment API should also consult the Allocation Rules API to check for any excluded carrier services.

Rulesets are managed through the new UI

### collections

For on_demand carriers there is a need to tell the carrier when to send a driver to collect shipments. This is in contrast to scheduled shipments where there is a scheduled collection from pre-defined shipping locations.

> <span class="note-header">Note:</span>
>
> The terminology used by many carriers for this type of operation is a "pick-up request". To avoid confusion with "pick-up options", this operation will be known as a "collection request" in Sorted.

After analysing several carriers for on_demand shipping it became clear that carriers generally operate in a similar way.

Shipments are booked individually with the carrier but are only collected by the carrier once a collection or pick-up request has been made.

Each on_demand carrier service will have different requirements for when and how a collection request can be made.

For example:

FedEx Ground - maximum of one collection request per location, per day for next day collection.
DPD - maximum of one collection request per location, per day, no later than 12:00 on the day of collection.
WARNING
The following points should be factored in to any design for this feature:

* Collection requests must not be configurable by customers, but must be configurable by Sorted per carrier service.
* Collection schedules must be configurable outside of the carrier service integration.
* Collection requests must be made per origin location and must respect carrier limits.

There are 2 known operating modes for carrier collection requests:

* Per shipment
* Roll up per origin location

Per shipment mode
This operating mode must result in a collection request per shipment as part of the allocation flow.

Success: The shipment is allocated when the both pick up and delivery elements of a request succeed
Failure: Allocation of the shipment will fail if either the collection or delivery element of a request fails

Roll up mode
Roll up mode is more complex. Some carrier services have limits such as a maximum frequency of collection requests (e.g. once per location per day), as well as a maximum number of shipments per request.

Success:
The current number of queued shipments per location does not exceed the carrier service's specific limit (if applicable);
The delivery element of the shipment is successful;
The shipment is successfully queued in an internal queue for collection booking
Failure
The current number of queued shipments per location exceeds the carrier service's specific limit (if applicable)
The delivery element of the shipment is unsuccessful
The shipment is not successfully queued in an internal queue for collection booking

Following an allocation request,the following state transitions should occur.

Per shipment mode
When operating per shipment, the state transitions should be as follows:

Event	Target State
shipment successfully booked with carrier, including collection and delivery	collection_booked
shipment not successfully booked with carrier for delivery	allocation_failed
shipment not successfully booked with carrier for collection	collection_booking_failed

Roll up mode
In addition to immediate feedback when allocating in this mode, we have scheduled events that will be triggered later in the lifecycle of a shipment, e.g.:

The queued collection request succeeds (i.e. a driver collection is booked)
The queued collection request does not succeed

Event	Target State
shipment successfully booked for delivery	allocated
shipment not successfully queued for collection request	collection_booking_failed
collection request succeeds	collection_booked
collection request does not succeed	collection_booking_failed

> <span class="note-header">Note:</span>
>
> If the date of collection for a shipment is known, this information should be populated in the shipping_date property of the shipment. This applies whether the shipment is allocated according to "per shipment mode" or "roll up mode".

The customer can't do anything about collections and we're going to handle it per carrier service as part of our integration

Andy Walton:house:  15:34
Ah right, OK. So as far as the customer's concerned they just allocate to the on demand service and we tell them when it's getting picked up?

Michael Rose  15:35
exactly. we might not even tell them when it's going to be picked up, just that it will be
15:35
carriers don't all even confirm pick up requests
