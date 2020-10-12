---
uid: pro-api-help-shipments-using-paperless-documents
title: Adding Paperless Documents
tags: shipments,pro,api,paperless,documents
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 08/07/2020
---

# Adding Paperless Documents

Paperless documents are customer-generated documents that are transmitted to carriers as part of a shipment's data rather than being generated separately by the carrier. This page explains how to add paperless documents to a shipment, retrieve a shipment's paperless documents, and remove a paperless document from a shipment.

---

## What are Paperless Documents?

Paperless documents are intended to make your workflows more efficient, enabling you to send documentation directly to the carrier as part of a shipment's data rather than having it produced as a separate operation. You can upload paperless documents as part of a **Create Shipment** request, or add them to an existing shipment using the **Add Paperless Documents** endpoint. 

You can only add paperless documents to an unallocated shipment. 

> [!CAUTION]
> Not all carriers support paperless trade. <span class="highlight">What's the best way for customers to ascertain whether a particular service supports paperless trade?</span>

PRO supports the following paperless document types:

* Commercial invoice documents
* Certificates of origin
* NAFTA certificates of origin
* Pro-forma invoices
* Authorisation forms
* Export documents
* Export licences
* Import permits
* Power of attorney documents
* Packing lists
* Shipper's export (SED) documents
* Letters of instruction
* Customs declarations
* Air waybills
* Invoices

Documents must be uploaded as an image in one of PRO's supported formats (PDF, PNG, JPG or GIF), and must be less than 5MB in size. For larger documents you may need to optimise your files (for example, removing fonts and embedded data from a PDF or reducing quality on a JPG) to bring your files under the size limit.

> [!NOTE]
> PRO's paperless document functionality should not be confused with PRO's customs documents functionality. Paperless documents are added to the shipment before allocation and transmitted as part of that shipment's data, while customs documents are generated post-allocation and are intended to be printed before dispatch. For more information on working with customs documents in PRO, see the [Getting Shipment Documents](/pro/api/shipments/getting_shipment_documents.html) page. 

## Adding Paperless Documents to Shipments

The **Add Paperless Document** endpoint enables you to add paperless documents to an existing unallocated shipment. To call **Add Paperless Document**, send a `POST`request to `https://api.sorted.com/pro/documents/paperless/{reference}`, where `{reference}` is the unique reference of the shipment you want to add the document to.

The body of the request should contain the following information:

* A `file_format` property indicating the format of the file being uploaded.
* A `document_type` property indicating the type of document being uploaded. This must be a valid PRO paperless document type. See the Shipments data contract for a list of valid document types.
* A `file_content` property containing the document file itself as a base64-encoded byte array.

Optionally, the request body can also include:

* An `expiration` property indicating the date and time that the document expires.
* A `usage` property indicating the document's intended usage. If provided, this property must contain a valid PRO `paperless_document_usage` value. See the Shipments data contract for a list of valid document usages. If this property is not provided the PRO defaults to a usage of `electronic_trade` for the document.

> [!NOTE]
> It is only possible to add a paperless document to a shipment prior to allocation (i.e. when the shipment is in a state of either `unallocated` or `allocation_failed`). If you attempt to add a paperless document to an allocated shipment then PRO returns an error.

Once it has received the request, PRO attached the document to the specified shipment and returns a unique `reference` for the paperless document.

### Example Add Paperless Document Call

The example shows a successful request to add a `commercial_invoice` paperless document to shipment _sp_00595452779180472847666078547968_. PRO has responded with a paperless document `reference` of _pd_00797582543150236528252876881920_.

# [Example Add Paperless Document Request](#tab/example-add-paperless-document-request)

`POST https://api.sorted.com/pro/documents/paperless/sp_00595452779180472847666078547968`

```json
{
  "file_format": "pdf",
  "document_type": "commercial_invoice",
  "expiration": "2021-09-01T06:00:00+00:00",
  "file_content": (Base64 document data),
  "usage": "electronic_trade"
}
```

# [Example Add Paperless Document Response](#tab/example-add-paperless-document-response)

```json
{
    "reference": "pd_00797582543150236528252876881920",
    "message": "Paperless Document pd_00797582543150236528252876881920 added successfully",
    "_links": [
        {
            "href": "https://api-int.sorted.com/pro/documents/paperless/pd_00797582543150236528252876881920",
            "rel": "self",
            "reference": "pd_00797582543150236528252876881920",
            "type": "paperless_document"
        },
        {
            "href": "https://api-int.sorted.com/pro/shipments/sp_00797580869643167594270016798720",
            "rel": "shipment",
            "reference": "sp_00797580869643167594270016798720",
            "type": "shipment"
        }
    ]
}
```
---

## Getting Paperless Documents

The **Get Paperless Document** endpoint takes a paperless document `reference` and returns details of the relevant paperless document. To call **Get Paperless Document**, send a `GET` request to `https://api.sorted.com/pro/documents/paperless/{document_reference}`

Once it has received the request, PRO returns a `paperless_document` object. This object details all of the information supplied when the paperless document was added to the shipment.

### Example Get Paperless Document Call

The example shows a successful  **Get Paperless Document** request for the paperless document added in the previous example, _pd_00797582543150236528252876881920_.

# [Example Get Paperless Document Request](#tab/example-get-paperless-document-request)

`GET https://api.sorted.com/pro/documents/paperless/pd_00797582543150236528252876881920`

# [Example Get Paperless Document Response](#tab/example-get-paperless-document-response)

```json

{
    "file_content": (Base64 document data),
    "expiration": "2021-09-01T06:00:00+00:00",
    "file_format": "pdf",
    "document_type": "commercial_invoice",
    "usage": "electronic_trade"
}
```
---

<!-- ## Removing Paperless Documents from Shipments

<span class="highlight">THIS CURRENTLY RUNS OFF A DOCUMENT REFERENCE PROPERTY THAT ISN'T MENTIONED IN THE DATA CONTRACT. LEAVING THIS FOR NOW</span>

This endpoint is used to remove an existing paperless_document from a shipment.

WARNING
It is only possible to remove a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

`DELETE https://api.sorted.com/pro/documents/paperless/{document_reference}`

### Example Remove Paperless Document Call

The example shows

# [Example Remove Paperless Document Request](#tab/example-remove-paperless-document-request)

```json
DELETE https://api.sorted.com/pro/documents/paperless/{document_reference}
```


# [Example Remove Paperless Document Response](#tab/example-remove-paperless-document-response)

```json

```
---

-->

## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)