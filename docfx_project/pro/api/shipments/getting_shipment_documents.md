---
uid: pro-api-help-shipments-getting-shipment-documents
title: Getting Shipment Documents
tags: v2,shipments,pro,api,customs,documents,dangerous,hazardous,collection note
contributors: andy.walton@sorted.com
created: 08/10/2020
---
# Getting Shipment Documents

SortedPRO can automatically generate customs documentation, collection notes, and hazard labels for shipments. This page explains the various way in which SortedPRO can return this documentation.

> [!NOTE]
> PRO also generates delivery labels, which have the same data structure as shipment documents and are also created after allocation. However, labels are managed through their own dedicated endpoints, and cannot be returned through PRO's Documents endpoints. For information on using delivery labels in PRO, see the [Getting Shipment Labels](/pro/api/shipments/getting_shipment_labels.html) page. 

---

## Documentation in PRO

Once a shipment is allocated, PRO automatically determines what documentation is required for it. PRO can generate the following document types:

* `cn22` - Customs documentation. Only generated for applicable international shipments.
* `cn23` - Customs documentation. Only generated for applicable international shipments.
* `commercial_invoice` - Customs documentation. Only generated for applicable international shipments.
* `hazard_label` - Generated for shipments containing dangerous goods. 
* `collection_note` - A driver's manifest for the shipment. Generated for all shipments.

PRO offers two endpoints to retrieve documents once they have been generated:

* **Get Document** retrieves a specific document.
* **Get Customs Documents** retrieves all customs documents (that is, CN22, CN23, and commercial invoice documents) that have been generated for a particular shipment.

> [!NOTE]
> PRO's auto-generated documents should not be confused with paperless documents. Paperless documents are documents that are attached to a shipment prior to allocation and transmitted to a carrier as part of that shipment's data. Auto-generated documents are created by PRO at the point of allocation and are intended to be printed before the carrier picks the shipment up. 
>
> For more information on using paperless documents in PRO, see the [Adding Paperless Documents](/pro/api/shipments/adding_paperless_documents.html) page. 

## Getting a Specific Shipment Document

To call **Get Document**, send a `GET` request to `https://api.sorted.com/pro/documents/{shipment_reference}/{document_type}`, where `{shipment_reference}` is the unique reference of the shipment that the document belongs to and `{document_type}` is the type of document you want to return for that shipment.

If the specified shipment has a document of the specified type, then PRO returns a `document` object representing that document. Otherwise, PRO returns an error.

> [!NOTE]
>
> If you use the **Get Document** endpoint to get a *collection_note* for a shipment, then PRO returns a collection note for the contents of that shipment only. If you need collection notes for multiple shipments being picked up by the same carrier (as part of a scheduled collection, for example), you should use one of PRO's dedicated Collection Notes endpoints instead.
> 
> * For more information on using collection notes in PRO, see the [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html) page.
> * For full reference information on the **Get Document** endpoint, see the Shipments data contract.

## Getting All of a Shipment's Customs Documents

To call **Get Customs Documents**, send a `GET` request to `https://api.sorted.com/pro/documents/{shipment_reference}`, where `{shipment_reference}` is the unique reference of the shipment that you want to get customs documents for.

If the specified shipment has customs documents (that is, it is an international shipment), then PRO returns a list of `document` objects representing those documents. Otherwise, PRO returns an error.

> [!NOTE]
>
> For full reference information on the **Get Customs Documents** endpoint, see the Shipments data contract.

## The Document Response

Both Documents endpoints return `document` objects. **Get Document** returns a single `document`, while **Get Customs Documents** returns a list.

[!include[_shipments_document_object](../includes/_shipments_document_object.md)]

## Examples

The example below shows a successful **Get Document** request for the `cn22` document associated with shipment _sp_00670175533382557003917067812864_. PRO returns a `document` object representing that document. In this example, the Base64 data returned has been removed for clarity.

# [Get Document Request](#tab/get-document-request)

```json
GET https://api.sorted.com/pro/documents/sp_00670175533382557003917067812864/cn22
```

# [Get Document Response](#tab/get-document-response)

```json
{
  "file": {Base64 file contents},
  "content_type": "application/pdf",
  "document_type": "cn22",
  "dpi": 203
}
```
---

The example below shows a successful **Get Customs Documents** request for all customs documents associated with shipment _sp_00670175533382557003917067812864_. PRO returns a list of `document` objects representing the `cn22`, `cn23`, and `commercial_invoice` documents associated with that shipment. In this example, the Base64 data returned has been removed for clarity.

# [Get Customs Documents Request](#tab/get-customs-documents-request)

```json
GET https://api.sorted.com/pro/documents/sp_00670175533382557003917067812864
```

# [Get Customs Documents Response](#tab/get-customs-documents-response)

```json
[
  {
    "file": {Base64 file contents},
    "content_type": "application/pdf",
    "document_type": "cn22",
    "dpi": 203
  },
  {
    "file": {Base64 file contents},
    "content_type": "application/pdf",
    "document_type": "cn23",
    "dpi": 203
  },
  {
    "file": {Base64 file contents},
    "content_type": "application/pdf",
    "document_type": "commercial_invoice",
    "dpi": 203
  }
]
```
---

## Using the Label Data

Once you have downloaded the file data, you will need to decode the file's Base64 in order to view the label itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

## Next Steps

* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.
* Learn how to retrieve a shipment's labels at the [Getting Shipment Labels](/pro/api/shipments/getting_shipment_labels.html) page.
* Learn how to work with shipment groups at the [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) page.