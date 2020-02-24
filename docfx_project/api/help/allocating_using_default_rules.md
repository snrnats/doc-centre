# Allocate Using Default Allocation Rules

To page explains how to configure custom allocation rules and use the **[Allocate Using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)**  and [Allocate Consignment](https://docs.electioapp.com/#/api/AllocateConsignment) endpoints to allocate consignments based on those rules.

---

## Allocating Multiple Consignments Using Allocation Rules

The **Allocate Using Default Rules** endpoint can be used to allocate multiple consignments simultaneously. The request body can contain an array of one or more `{consignmentReference}`s to be allocated. 

Once the request is received, SortedPRO takes each consignment in turn and allocates it to the cheapest eligible carrier, based on your default rules. It then returns an array of Allocation Summaries, one for each allocated consignment. 

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Allocate Using Default Rules</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> page of the API reference. 

### Allocate Using Default Rules Example

The example shows a request to allocate three consignments via default rules. 

<div class="tab">
    <button class="staticTabButton">Example Allocate Using Default Rules Request</button>
    <div class="copybutton" onclick="CopyToClipboard('allocationUDRRequest')">Click to Copy</div>
</div>

<div id="allocationUDRRequest" class="staticTabContent" onclick="CopyToClipboard('allocationUDRRequest')">

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

## Allocating a Single Consignment Using Allocation Rules

> Allocate Consignment Endpoint
```
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote
```

To allocate a single consignment to the cheapest available carrier service, use the **[Allocate Consignment](https://docs.electioapp.com/#/api/AllocateConsignment)** endpoint. Once the **Allocate Consignment** request is received and validated, SortedPRO checks for quotes to ship the consignment in question, and allocates the consignment to the cheapest service. 

This endpoint takes a `{consignmentReference}` as a path parameter, and returns an Allocation Summary.

> Example Allocate Consignment Request
```
PUT https://api.electioapp.com/allocation/EC-000-05A-Z6S/allocatewithcheapestquote
```
### Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05A-Z6S_ via the **Allocate Consignment** endpoint. 

<aside class="note">
  For full reference information on the <strong>Allocate Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignment">Allocate Consignment</a></strong> page of the API reference. 
</aside>

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>