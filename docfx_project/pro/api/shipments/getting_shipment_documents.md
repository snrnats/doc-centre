---
uid: pro-api-help-shipments-getting-shipment-documents
title: Getting Shipment Documents
tags: shipments,pro,api,customs,documents
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Shipment Documents

When shipping internationally, SortedPRO will automatically determine if customs documentation is required for a shipment. This page explains the various way in which SortedPRO can return return customs documents and commercial invoices.

<span class="highlight">PRO ALSO NOW HAS COLLECITON NOTES AND HAZARD LABELS AS DOCUMENT TYPES WHICH CAN PRESUMABLY BE RETURNED BY THE GET DOCUMENT ENDPOINT. ARE THESE ALSO AUTO GENERATED? PROBABLY NEED TO FIGURE THAT OUT BEFORE WE WRITE THIS SECTION</span>

---

## Customs Docs in PRO

SortedPRO can automatically generate CN22, CN23, or Commercial Invoice documents in PDF format and will determine which document is appropriate for any allocated shipment. The Customs Docs APIs enable you to retrieve the pre-generated documents.

PRO offers two endpoints to retrieve customs documents once they have been generated:

* **Get Customs Documents** retrieves all customs documents that have been generated for a particular shipment.
* **Get Document** retrieves a specific customs document.

> [!CAUTION]
>
> You can only retrieve documents for shipments that have been allocated to a carrier. If you attempt to return labels for an unallocated shipment, PRO returns an error.

## Getting Shipment Customs Docs

`GET https://api.sorted.com/pro/documents/{shipment_reference}`

<span class="highlight">THESE ARE ALL JUST NOTES TO SELF AND AREN'T INTENDED FOR PUBLIC CONSUMPTION (AT LEAST, NOT IN THIS FORM)</span>

Generate customs documentation as quickly as possible
Produce optimised customs documentation (small file size, high quality)
Enable rules to be updated quickly and easily without requiring a full deployment

### rules

In order to identify whether customs document(s) are required when allocating a `shipment`, the following factors must be considered:

- The origin ISO country code
- The destination ISO country code, including wildcard support (e.g. to any country)
- The value of goods in the specified currency
- The specified currency

### generating sdocs

Generating customs documents should be an immutable operation. When generating customs documents, we should be checking to ensure that the shipment has been allocated. If it has not, customs documents cannot be generated. If it has, then the shipment is now effectively immutable, and the data for customs documents generation cannot be changed. 

A Commercial Invoice is another type of document that can be returned in certain circumstances, depending upon the data mapping in place.

### paperless trade

However, in general terms "paperless" means that the client does not need to generate customs documents – the carrier will generate any relevant documents on the client's behalf.

As a result, when requesting documents for carrier services that are deemed "paperless", no documents should be returned.

### Example Rules

The following rules are currently configured in SortedPRO:

- When the `origin` country is `AT`, the destination is anywhere (`*`), and the goods are between `£0.00` and `£380.00`, then a CN22 is required
- When the `origin` country is `GB`, the destination is `JE`, and the goods are between `£0.00` and `£270.00`, then a CN22 is required
- When the `origin` country is `GB`, the destination is anywhere (`*`), and the goods are between `$0.00AUD` and `$519.11AUD`, then a CN22 is required

In implementing this endpoint, the application must identify the customs document(s) that are required based on the properties of the shipment, and then return that document (or those documents) only, and nothing else. I.e. when a specific document is not required, don’t just generate it anyway and send it back.

Get Document
Get Customs Documents 