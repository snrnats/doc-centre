---
uid: pro-api-help-shipments-manifesting-shipments
title: Manifesting Shipments
tags: shipments,pro,api,manifesting
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Manifesting Shipments

Once you've created a shipment and allocated it to a carrier service, you're ready to manifest it. This section explains how to <!--manifest shipments and how to view existing customer manifests --> do so.

---

## Manifesting Overview

In the context of SortedPRO, the term "manifesting" refers to collating, formatting and transmitting shipment data to carriers. It is the final step of most PRO workflows.

You can only manifest shipments that are in a state of `allocated`, `manifest_failed`, or `ready_to_ship`. If you attempt to manifest a shipment that is not in one of these states then PRO returns an error.

<span class="highlight">The above note is from the consignments help. I'm guessing this is still the case but need to confirm</span>

<!-- PRO has four endpoints that manifest shipments: 

* **Manifest Shipment** - Manifests the specified shipment.
* **Manifest Shipments**  - Manifests multiple shipments at once by providing a list of `{shipmentReferences}`. 
* **Manifest Shipments by Query**  - Manifests all shipments that meet a specified set of search criteria.
* **Manifest Shipments by Shipment Group** - Manifests all shipments within a specified shipment group. -->

> [!CAUTION]
>
> Every successful request to a manifest endpoint results in data being transmitted to the carrier. Therefore, Sorted strongly advise that <!-- you do not manifest shipments individually, and that -->shipment manifesting is aligned with the carrier collection times from the warehouse.

Manifesting a shipment changes its state to `manifested`. At this point the carrier is aware of the shipment, and will collect it unless otherwise advised. <!-- In order to prevent the shipment being shipped, you would need to cancel it. -->

<!-- >> [!NOTE]
>
> For more information on cancelling shipments, see the [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html) page. -->

Whenever you manifest one or more shipments, PRO creates a new manifest item. Each manifest item contains shipments for one carrier only. <!-- You can retrieve manifest items using the **Get Manifest** endpoint -->

Once a shipment is manifested you should also look to print labels for the shipment, if you have not already done so. See [Getting Labels](/pro/api/shipments/getting_shipment_labels.html) for an explanation of how to retrieve package labels.

<!-- ## Section Contents

* [Manifesting Shipments Manually](/pro/api/shipments/manifesting_shipments_manually.html) - Explains how to use the **Manifest Shipment** and **Manifest Shipments** endpoints to select the shipment to be manifested.
* [Manifesting Shipments by Query](/pro/api/shipments/manifesting_shipments_by_query.html) - Explains how to use the **Manifest Shipments by Query** endpoint to manifest only those shipment that meet a certain set of criteria.
* [Manifesting Shipments by Shipment Group](/pro/api/shipments/manifesting_shipments_by_shipment_group.html) - Explains how to use the **Manifest Shipments by Shipment Group** endpoint to manifest all shipments within a specified shipment group.
* [Getting Shipment Manifests](/pro/api/shipments/getting_shipment_manifests.html) - Explains how to use the **Get Manifest** endpoint to retrieve an existing manifest. -->

## Manifesting a Shipment

The **Manifest Shipment** endpoint enables you to manifest an individual shipment. To call **Manifest Shipment**, send a `PUT` request to `https://api.sorted.com/pro/shipments/{reference}/manifest`, where `{reference}` is the unique reference for the shipment you want to manifest.

Once PRO has received the request, it attempts to manifest the specified shipment and returns a `manifest_result` containing the following information:

* A unique reference for the manifest item.
* Details of the carrier and service that the shipment was manifested with.
* A message providing details of the result.
* The current state of the shipment as a result of the manifest operation. Ordinarily, this would be _manifesting_.
* A link to the generated manifest.

> [!NOTE]
>
>  For full reference information on the **Manifest Shipment** endpoint, see the Shipments data contract. 

### Manifest Shipment Example

The example shows a successful request to manifest shipment _sp_00673267200365953327505217421312_.

# [Manifest Shipment Request](#tab/manifest-shipment-request)

```json
`PUT https://api.sorted.com/pro/shipments/sp_00673267200365953327505217421312/manifest`
```

# [Manifest Shipment Response](#tab/manifest-shipment-response)

```json
{
  "results": [
    {
      "reference": "ma_00673536672211162995858760007680",
      "carrier": {
        "reference": "XPDI",
        "name": "XPD International",
        "service_reference": "XPDISU",
        "service_name": "XPD International Supreme"
      },
      "message": "Shipment sp_00673267200365953327505217421312 manifested with XDP Worldwide successfully",
      "state": "manifested",
      "shipment_count": 1,
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/shipments/sp_00673267200365953327505217421312",
          "rel": "shipment",
          "reference": "sp_00673267200365953327505217421312",
          "type": "shipment"
        }
      ]
    }
  ]
}
```
---

## Next Steps

* Learn how to generate and select delivery quotes: [Managing Shipment Quotes](/pro/api/shipments/managing_shipment_quotes.html)
* Learn how to configure shipment groups: [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) 
* Learn how to get collection notes: [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html)