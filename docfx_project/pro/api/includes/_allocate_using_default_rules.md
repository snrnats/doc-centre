<div class="tab">
    <button class="staticTabButton">Allocation Using Default Rules Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocationUDREndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocationUDREndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'allocationUDREndpoint')">

```
PUT https://api.electioapp.com/allocation/allocate
```

</div>

To allocate one or more consignments based on your organisation's custom allocation rules, use the **[Allocate Using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)** endpoint. PRO allocation rules enable you to configure business rules - such as physical package size, consignment value, and geographical availability - against individual carrier services. You can configure them via the <strong>Manage Carrier Service Rules</strong></a> page of the PRO UI. 

The **Allocate Using Default Rules** endpoint can be used to allocate multiple consignments simultaneously. The request body can contain an array of one or more `{consignmentReference}`s to be allocated. 

Once the request is received, SortedPRO takes each consignment in turn and allocates it to the cheapest eligible carrier, based on your default rules. It then returns an array of Allocation Summaries, one for each allocated consignment. 

> <span class="note-header">More Information:</span>
> * For full reference information on the <strong>Allocate Using Default Rules</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> page of the API reference. 
> * For a guide to using allocation rules, see the [Allocating Using Default Allocation Rules](/pro/api/help/allocating_using_default_allocation_rules.html) page.

**Allocate Using Default Rules Example**

The example shows a request to allocate three consignments via default rules. 

<div class="tab">
    <button class="staticTabButton">Example Allocate Using Default Rules Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocationUDRRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocationUDRRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'allocationUDRRequest')">

```json
PUT https://api.electioapp.com/allocation/allocate

{
  "ConsignmentReferences": [
    "EC-000-05B-MMA",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```

</div>