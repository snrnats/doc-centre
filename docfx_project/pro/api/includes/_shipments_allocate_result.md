The Allocate Result object is returned by all PRO endpoints that allocate individual consignments. It contains details of:

* The shipment's current `state` following the allocation request. For successful requests this would generally be _Allocated_.
* The carrier and service that the shipment was allocated to.
* The `price` of the allocation.
* Any relevant tracking references.
* The services that were unable to provide a quote.
* The `shipping_date` and `expected_delivery_date` for the shipment.