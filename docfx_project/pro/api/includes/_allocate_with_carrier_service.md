# [Allocate with Carrier Service Endpoint](#tab/allocate-with-carrier-service-endpoint)

```json
PUT https://api.electioapp.com/allocation/allocatewithcarrierservice
```

---

To allocate one or more consignments to a specific carrier service, use the **[Allocate With Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** endpoint.

The **Allocate With Carrier Service** request body contains an array of one or more `{consignmentReference}`s to be allocated and the `{MpdCarrierServiceReference}` of the carrier service that they should be allocated to. Once the request is received, SortedPRO attempts to allocate the consignments to the specified carrier service.

> [!NOTE]
>
> * For full reference information on the **Allocate With Carrier Service** endpoint, see the **[Allocate With Carrier Service](https://docs.electioapp.com/#/api/AllocateWithCarrierService)** page of the API reference.
> * For a user guide on allocating consignments to a specific carrier service, see the [Allocating to a Specific Carrier Service](/pro/api/help/allocating_to_a_specific_carrier_service.html).

**Allocate With Carrier Service Example**

The example shows a request to allocate three consignments to a carrier service with an `{MpdCarrierServiceReference}` of _Example-Carrier-Service_.

# [Allocate with Carrier Service Request](#tab/allocate-with-carrier-service-request)

`PUT https://api.electioapp.com/allocation/allocatewithcarrierservice`

```json
{
  "MpdCarrierServiceReference": "Example-Carrier-Service",
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```

---
