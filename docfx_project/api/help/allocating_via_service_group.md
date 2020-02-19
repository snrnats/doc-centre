# Allocating Via Service Group

<div class="tab">
    <button class="staticTabButton">Allocate Consignment With Service Group Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard('allocationUSGEndpoint')">Click to Copy</div>
</div>

<div id="allocationUSGEndpoint" class="staticTabContent" onclick="CopyToClipboard('allocationUSGEndpoint')">

```
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}
```
</div>

SortedPRO carrier service groups are user-defined pools of carrier services that can be used in the allocation process. To allocate a consignment to the cheapest available carrier service in a particular carrier service group, use the **[Allocate Consignment With Service Group](https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup)** endpoint.  

> <span class="note-header">Note:</span>
> Carrier service groups are designed to help you allocate your consignments to the best possible service. For example, you might set up a group containing all services that will ship dangerous goods. You would then allocate within that group for all consignments involving dangerous items. 
>
> To configure carrier service groups, use the <strong><a href="https://www.electioapp.com/Configuration/CarrierServiceGroups">Configuration - Carrier Service Groups</a></strong> UI page. 

The **Allocate Consignment With Service Group** endpoint takes the `{consignmentReference}` of the consignment you want to allocate and the `{mpdCarrierServiceGroupReference}` of the service group you want to allocate from as path parameters, and returns an Allocation Summary with details of the service that was allocated. 

The `{mpdCarrierServiceGroupReference}` is a unique identifier for each carrier service group. To find the `{mpdCarrierServiceGroupReference}` for a particular group, log in to the PRO UI, navigate to the **[Configuration - Carrier Service Groups](https://www.electioapp.com/Configuration/CarrierServiceGroups)** page, and locate the tile for that group. The `{mpdCarrierServiceGroupReference}` is shown in the **Code** field.

> <span class="note-header">Note:</span>
> For full reference information on the <strong>Allocate Consignment With Service Group</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignmentWithServiceGroup">Allocate Consignment With Service Group</a></strong> page of the API reference. 


### Allocate With Service Group Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_ to a carrier service within a group named `valuableGoods`.

<div class="tab">
    <button class="staticTabButton">Example Allocate Consignment With Service Group Request</button>
    <div class="copybutton" onclick="CopyToClipboard('allocationUSGRequest')">Click to Copy</div>
</div>

<div id="allocationUSGRequest" class="staticTabContent" onclick="CopyToClipboard('allocationUSGRequest')">

```
PUT https://api.electioapp.com/allocation/EC-000-05B-MMA/allocatewithservicegroup/valuableGoods
```

</div>


<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>