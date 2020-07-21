---
uid: pro-api-help-shipments-manifesting-shipments
title: Manifesting Shipments
tags: shipments,pro,api,manifesting
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Manifesting Shipments

Once you've created a shipment and allocated it to a carrier service, you're ready to manifest it. This section explains how to manifest shipments and how to view existing customer manifests.

---

## Manifesting Overview

In the context of SortedPRO, the term "manifesting" refers to collating, formatting and transmitting shipment data to carriers. It is the final step of most PRO workflows.

You can only manifest shipments that are in a state of `allocated`, `manifest_failed`, or `ready_to_ship`. If you attempt to manifest a shipment that is not in one of these states then PRO returns an error.

<span class="highlight">THE ABOVE NOTE IS FROM THE CONSIGNMENTS HELP. I'M GUESSING THIS IS STILL THE CASE BUT NEED TO CONFIRM</span>

PRO has four endpoints that manifest shipments: 

* **Manifest Shipment** - Manifests the specified shipment.
* **Manifest Shipments**  - Manifests multiple shipments at once by providing a list of `{shipmentReferences}`. 
* **Manifest Shipments by Query**  - Manifests all shipments that meet a specified set of search criteria.
* **Manifest Shipments by Shipment Group** - Manifests all shipments within a specified shipment group.

> [!CAUTION]
>
> Every successful request to a manifest endpoint results in data being transmitted to the carrier. Therefore, Sorted strongly advise that you do not manifest shipments individually, and that shipment manifesting is aligned with the carrier collection times from the warehouse.

Manifesting a shipment changes its state to `manifested`. At this point the carrier is aware of the shipment, and will collect it unless otherwise advised. In order to prevent the shipment being shipped, you would need to either cancel or deallocate it. 

> [!NOTE]
>
> For more information on cancelling shipments, see [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)].
>
> For more information on deallocating shipments, see LINK HERE.

<span class="highlight">NEED TO CONFIRM WHAT THE DEAL IS WITH DEALLOCATING SHIPMENTS AS THERE AREN'T ANY ENDPOINTS IN THE NEW COLLECTION</span>

Once a shipment is manifested you should also look to print labels for the shipment, if you have not already done so. See [Getting Labels](/pro/api/shipments/getting_shipment_labels.html) for an explanation of how to retrieve package labels.

## Section Contents

* [Manifesting Shipments Manually](/pro/api/shipments/manifesting_shipments_manually.html) - Explains how to use the **Manifest Shipment** and **Manifest Shipments** endpoints to select the shipment to be manifested.
* [Manifesting Shipments by Query](/pro/api/shipments/manifesting_shipments_by_query.html) - Explains how to use the **Manifest Shipments by Query** endpoint to manifest only those shipment that meet a certain set of criteria.
* [Manifesting Shipments by Shipment Group](/pro/api/shipments/manifesting_shipments_by_shipment_group.html) - Explains how to use the **Manifest Shipments by Shipment Group** endpoint to manifest all shipments within a specified shipment group.
* [Getting Shipment Manifests](/pro/api/shipments/getting_shipment_manifests.html) - Explains how to use the **Get Manifest** endpoint to retrieve an existing manifest.

