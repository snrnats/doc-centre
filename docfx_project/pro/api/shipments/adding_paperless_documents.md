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
> Not all carriers support paperless trade. <span class="highlight">What's the best way for cusotmers</span>

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
> PRO's paperless document functionality should not be confused with PRO's customs documents functionality. Paperless documents are added to the shipment before allocation and transmitted as part of that shipment's data, while customs documents are generated post-allocation and are intended to be printed before dispatch. For more information on working with customs documents in PRO, see LINK HERE. 

<span class="highlight">NEED NOTE ABOUT HOW ALLOCATE RESULT CONFIRMS USAGE TYPE OF DOC</span>

## Adding Paperless Documents to Shipments



This endpoint is used to enable customers to add paperless documents to existing shipments.

WARNING
It is only possible to add a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

`POST https://api.sorted.com/pro/documents/paperless/{shipment_reference}`

<span class="highlight">NEED NOTE ABOUT HOW ALLOCATE RESULT CONFIRMS USAGE TYPE OF DOC</span>


### Example Add Paperless Document Call

The example shows

# [Example Add Paperless Document Request](#tab/example-add-paperless-document-request)

```json
POST https://api.sorted.com/pro/documents/paperless/sp_00595452779180472847666078547968
```

# [Example Add Paperless Document Response](#tab/example-add-paperless-document-response)

```json

```
---

## Getting Paperless Documents

<span class="highlight">THIS CURRENTLY RUNS OFF A DOCUMENT REFERENCE PROPERTY THAT ISN'T MENTIONED IN THE DATA CONTRACT. LEAVING THIS FOR NOW</span>

This endpoint is used to retrieve paperless documents.

NOTE
"Paperless" documents are provided by customers when creating shipments and enable the transmission of customer-generated documents to carriers.

`GET https://api.sorted.com/pro/documents/paperless/{document_reference}`

### Example Get Paperless Document Call

The example shows

# [Example Get Paperless Document Request](#tab/example-get-paperless-document-request)

```json
`GET https://api.sorted.com/pro/documents/paperless/{document_reference}`
```


# [Example Get Paperless Document Response](#tab/example-get-paperless-document-response)

```json

```
---



## Removing Paperless Documents from Shipments

<span class="highlight">THIS CURRENTLY RUNS OFF A DOCUMENT REFERENCE PROPERTY THAT ISN'T MENTIONED IN THE DATA CONTRACT. LEAVING THIS FOR NOW</span>

This endpoint is used to remove an existing paperless_document from a shipment.

WARNING
It is only possible to remove a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

`GET https://api.sorted.com/pro/documents/paperless/{document_reference}`

### Example Remove Paperless Document Call

The example shows

# [Example Remove Paperless Document Request](#tab/example-remove-paperless-document-request)

```json
`GET https://api.sorted.com/pro/documents/paperless/{document_reference}`
```


# [Example Remove Paperless Document Response](#tab/example-remove-paperless-document-response)

```json

```
---



## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)