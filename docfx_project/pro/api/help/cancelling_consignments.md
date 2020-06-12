---
uid: pro-api-help-cancelling-consignments
title: Cancelling Consignments
tags: consignments,pro,api
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 28/05/2020
---
# Cancelling Consignments

This page explains how to cancel consignments in PRO, both individually and in bulk.

---

## Overview

You can only cancel a consignment prior to it being manifested. Once a consignment has been manifested it can no longer be cancelled. 

Once a consignment has been cancelled, then no further changes can be made to it. If you want to reinstate a cancelled consignment then you will need to create a new consignment with the same details.

## Cancelling Individual Consignments

To cancel an individual consignment, use the **Cancel Consignment** endpoint. You can call **Cancel Consignment** by sending a `PUT` request to `https://api.electioapp.com/consignments/{consignmentReference}/cancel`. Once the request has been received, PRO changes the consignment's `ConsignmentState` to _Cancelled_ and returns a code 200 response with no body.

> [!NOTE]
>
> For full reference information on the **Cancel Consignment** endpoint, see the <a href="https://docs.electioapp.com/#/api/CancelConsignment">API reference</a>.

## Cancelling Consignments in Bulk

If you need to cancel multiple consignments in one operation, use the **Cancel Consignments** endpoint. You can call **Cancel Consignments** by sending a `PUT` request to `https://api.electioapp.com/consignments/cancellist`. The body of the request should comprise an array listing the `consignmentReference`s of the consignments you want to cancel.

Once the request has been received, PRO changes the each consignment's `consignmentState` to _Cancelled_ and returns a list with a confirmation message in it for each consignment.

> [!NOTE]
>
> For full reference information on the **Cancel Consignments** endpoint, see the <a href="https://docs.electioapp.com/#/api/CancelConsignments">API reference</a>.

### Cancel Consignments Example

This example shows three consignments being cancelled at once via **Cancel Consignments** endpoint.

# [Cancel Consignments Request](#tab/update-consignments-request)

`PUT https://api.electioapp.com/consignments/cancellist`

```json
[
  "EC-000-05D-1NS",
  "EC-000-05D-1NT",
  "EC-000-05D-1NV"
]
```

# [Cancel Consignments Response](#tab/update-consignments-response)

```json
[
    {
        "IsSuccess": true,
        "Message": "Consignment cancellation completed successfully",
        "Data": "EC-000-05D-1NS",
        "ApiLinks": null
    },
    {
        "IsSuccess": true,
        "Message": "Consignment cancellation completed successfully",
        "Data": "EC-000-05D-1NT",
        "ApiLinks": null
    },
    {
        "IsSuccess": true,
        "Message": "Consignment cancellation completed successfully",
        "Data": "EC-000-05D-1NV",
        "ApiLinks": null
    }
]
```
---

## Next Steps

* Learn how to allocate consignments at the [Allocating Consignments to Carriers](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>