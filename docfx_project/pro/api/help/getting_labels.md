---
uid: pro-api-help-getting-labels
title: Getting Labels
tags: labels,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/06/2020
---
# Getting Labels

SortedPRO can generate despatch labels for all of its carriers, enabling PRO customers to download labels without having to request them directly from the carrier. This page explains how to get labels for a specific consignment or an individual package within a consignment.

---

## The Labels Request

Getting labels is a key part of all PRO workflows, as an unlabelled consignment cannot be dispatched. Labels are usually retrieved after a consignment has been allocated but before it has been manifested.

> [!CAUTION]
> 
> You can only retrieve labels for consignments that have been allocated to a carrier. If you attempt to return labels for an unallocated consignment, PRO returns an error.

### Getting Labels for an Entire Consignment

PRO offers two endpoints that return labels for all packages in a consignment: **Get Labels** and **Get Labels In Format**:

* **[Get Labels](https://docs.electioapp.com/#/api/GetLabels)** returns labels for the specified consignment. It has only one parameter: the `consignmentReference` of the consignment you want to retrieve labels for. To call **Get Labels**, send a `GET` request to `https://api.electioapp.com/labels/{consignmentReference}`.
* **[Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat)** is similar to **Get Labels**, but enables you to specify the file format that you want the labels to be returned in. This must be one of PRO's supported formats: PDF, PNG, ZPL or ZPLII. To call **Get Labels In Format**, send a `GET` request to `https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}`.

### Getting Labels for an Individual Package

PRO also offers two endpoints that return labels for a specific package in a consignment: **Get Package Label** and **Get Package Label In Format**:

* **[Get Package Label](https://docs.electioapp.com/#/api/GetPackageLabel)** returns the label for the specified package. It has two required parameters: the `packageReference` of the relevant package and the `consignmentReference` of its associated consignment. To call **Get Package Label**, send a `GET` request to `https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}`.
* **[Get Package Label in Format](https://docs.electioapp.com/#/api/GetPackageLabelinFormat)** is similar to **Get Package Label**, but enables you to specify the file format that you want the label to be returned in. This must be one of PRO's supported formats: PDF, PNG, ZPL or ZPLII. To call **Get Package Label In Format**, send a `GET` request to `https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}/{labelFormat}`.

## The Labels Response

All Labels API endpoints return labels objects. The labels object has two properties:

* `File` - A base64-encoded byte array representing the file content.
* `ContentType` - The content type of the file (as specified in the **Label Format** parameter, where applicable).

## Request Examples

* `https://api.electioapp.com/labels/EC-000-05D-1ST` - a **Get Labels** request for all package labels associated with consignment _EC-000-05D-1ST_.
* `https://api.electioapp.com/labels/EC-000-05D-1ST/pdf` - a **Get Labels In Format** request for all package labels associated with consignment _EC-000-05D-1ST_ in PDF format.
* `https://api.electioapp.com/labels/EC-000-05D-1ST/EP-000-05F-1E8` - a **Get Package Label** request for the label of package _EP-000-05F-1E8_, which is part of consignment _EC-000-05D-1ST_.
* `https://api.electioapp.com/labels/EC-000-05D-1ST/EP-000-05F-1E8/pdf` - a **Get Package Label In Format** request for the label of package _EP-000-05F-1E8_, which is part of consignment _EC-000-05D-1ST_, in PDF format.

## Response Example

The below example shows a typical label object.

# [Label Object](#tab/label-object)

```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZl ... VRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```
---

## Using the Label Data

Once you have downloaded the file data, you will need to decode the file's Base64 in order to view the label itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

## Next Steps

* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.
* Learn how to retrieve a consignment's customs documentation and invoices at the [Getting Customs Docs And Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page.
* Learn how to track consignments at the [Tracking Consignments](/pro/api/help/tracking_consignments.html) page.

> [!NOTE]
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).