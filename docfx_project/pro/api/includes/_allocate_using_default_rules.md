# [Allocate using Default Rules Endpoint](#tab/allocate-using-default-rules-endpoint)

```json
PUT https://api.electioapp.com/allocation/allocate
```
---

To allocate one or more consignments based on your organisation's custom allocation rules, use the **[Allocate Using Default Rules](https://docs.electioapp.com/#/api/AllocateUsingDefaultRules)** endpoint. PRO enables you to configure custom allocation rules - such as valid package dimensions, maximum consignment value, and geographical availability - for individual carrier services. You can configure them via the <strong>Manage Carrier Service Rules</strong></a> page of the PRO UI. 

The **Allocate Using Default Rules** endpoint can be used to allocate multiple consignments simultaneously. The request body can contain an array of one or more `{consignmentReference}`s to be allocated. 

Once the request is received, SortedPRO takes each consignment in turn and allocates it to the cheapest eligible carrier, based on your default rules. It then returns an array of Allocation Summaries, one for each allocated consignment. 

> [!NOTE]
> * For full reference information on the <strong>Allocate Using Default Rules</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateUsingDefaultRules">Allocate Using Default Rules</a></strong> page of the API reference. 
> * For a guide to using allocation rules, see the [Allocating Using Default Allocation Rules](/pro/api/help/allocating_using_default_allocation_rules.html) page.

**Allocate Using Default Rules Example**

The example shows a request to allocate three consignments via default rules. 

# [Allocate using Default Rules Request](#tab/allocate-using-default-rules-request)

`PUT https://api.electioapp.com/allocation/allocate`

```json
{
  "ConsignmentReferences": [
    "EC-000-05B-MMA",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```
---