# [Allocate Consignment with Service Group Endpoint](#tab/allocate-consignment-with-service-group-endpoint)

```json
https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}
```
---

SortedPRO carrier service groups are user-defined pools of carrier services that can be used in the allocation process. To allocate a consignment to the cheapest available carrier service in a particular carrier service group, use the **[Allocate Consignment With Service Group](https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup)** endpoint.  

To configure carrier service groups, use the <strong><a href="https://www.electioapp.com/Configuration/CarrierServiceGroups">Configuration - Carrier Service Groups</a></strong> UI page. 

The **Allocate Consignment With Service Group** endpoint takes the `{consignmentReference}` of the consignment you want to allocate and the `{mpdCarrierServiceGroupReference}` of the service group you want to allocate from as path parameters, and returns an Allocation Summary with details of the service that was allocated. 

> [!NOTE]
> * For full reference information on the <strong>Allocate Consignment With Service Group</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Allocate Consignment With Service Group</a></strong> page of the API reference.
> * For a user guide on allocating consignments within a service group, see the [Allocating Via Service Group](/pro/api/help/allocating_via_service_group.html). 

**Allocate With Service Group Example**

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_ to a carrier service within a group named `valuableGoods`.

# [Allocate Consignment with Service Group Request](#tab/allocate-consignment-with-service-group-request)

```json
PUT https://api.electioapp.com/allocation/EC-000-05B-MMA/allocatewithservicegroup/valuableGoods
```

---
