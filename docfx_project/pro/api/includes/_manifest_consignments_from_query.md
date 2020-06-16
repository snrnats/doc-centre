# [Manifest Consignments From Query Endpoint](#tab/manifest-consignments-from-query-endpoint)

```json
PUT https://api.electioapp.com/consignments/manifestFromQuery
```
---

Once you've created a consignment, allocated it to a carrier service and printed labels for it, you're ready to manifest it. To manifest a consignment, use the **[Manifest Consignments From Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery)** endpoint. In the context of SortedPRO, the term "manifesting" refers to collating, formatting and transmitting the consignment data to carriers.

The **Manifest Consignments From Query** endpoint enables you to use a query to select consignments to be manifested. Once PRO has added those consignments to a manifest and queued the data to be sent, the **Manifest Consignments From Query** endpoint returns a `Message` detailing how many consignments met the terms of the query, how many of those consignments were successfully queued, and how many could not be queued. 

> [!NOTE]
> * For full reference information on the <strong>Manifest Consignments From Query</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery">Manifest Consignments From Query</a></strong> page of the API Reference.
> * For a user guide on manifesting consignments, see the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page. 

### Manifest Consignments From Query Example

The example shows a request to manifest all consignments that are allocated to Carrier X, shipping from a location with the `ShippingLocationReference` _Location1_, and have already had their labels printed. The response indicates that PRO found 10 consignments meeting these criteria, and that all 10 were successfully queued for manifest.

# [Manifest Consignments From Query Request](#tab/manifest-consignments-from-query-request)

```json
{
  "ShippingLocationReferences": [
    "Location1"
  ],
  "States": [
    "Allocated"
  ],
  "Carriers": [
    "CARRIER_X"
  ],
  "LabelsPrinted": true
}
```
# [Manifest Consignments From Query Response](#tab/manifest-consignments-from-query-response)

```json
{
  "Message": "Query found 10 consignment(s). 10 successfully queued to manifest. 0 failed to be added to the queue"
}
```
---
