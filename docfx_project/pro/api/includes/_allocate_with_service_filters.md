> Allocate With Service Filters Endpoint
```
PUT https://api.electioapp.com/allocation/allocateConsignmentsWithServiceFilters
```

To allocate one or more consignments via service filters, use the **[Allocate With Service Filters](https://docs.electioapp.com/#/api/AllocateWithServiceFilters)** endpoint. The **Allocate With Service Filters** endpoint enables you to filter the list of available services as part of your allocation API call.

<aside class="note">
  The <strong>Allocate With Service Filters</strong> endpoint does not bypass any existing allocation rules that your organisation may have set up. Rather, it is a means of filtering carrier services within the list of services permitted by those rules.
</aside>

The **Allocate With Service Filters** request body can contain an array of one or more `{consignmentReference}`s to be allocated, and a `filters` object indicating the filter conditions to be used.

The attributes in the `filters` array can contain the following:

* A `ServiceDirection` property indicating whether the consignment should be allocated to an _inbound_ or _outbound_ carrier service.
* An (optional) Boolean `IsPickup` property indicating whether pick-up services should be included.
* An (optional) Boolean `IsDropOff` property indicating whether drop-off services should be included. 

Once the request is received, SortedPRO attempts to allocate the consignments to the cheapest service that meets the criteria set out in the `filters` array. It then returns an array of Allocation Summaries, one for each allocated consignment. 

<aside class="note">
  For full reference information on the <strong>Allocate With Service Filters</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithServiceFilters">Allocate With Service Filters</a></strong> page of the API reference. 
</aside>

> Example Allocate With Service Filters Request

```json
PUT https://api.electioapp.com/allocation/allocateConsignmentsWithServiceFilters

{
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ],
  "Filters": {
    "ServiceDirection": "Outbound",
    "IsPickup": false,
    "IsDropOff": true
  }
}
```
```xml
PUT https://api.electioapp.com/allocation/allocateConsignmentsWithServiceFilters

<?xml version="1.0" encoding="utf-8"?>
<AllocateConsignmentsWithServiceFiltersRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
  <ConsignmentReferences>
    <string>EC-000-05A-Z6S</string>
    <string>EC-000-083-45D</string>
    <string>EC-000-A04-0DV</string>
  </ConsignmentReferences>
  <Filters>
    <ServiceDirection>Outbound</ServiceDirection>
    <IsPickup>false</IsPickup>
    <IsDropOff>true</IsDropOff>
  </Filters>
</AllocateConsignmentsWithServiceFiltersRequest>
```

### Example

The example shows a request to allocate three consignments to an outbound, drop-off carrier service.