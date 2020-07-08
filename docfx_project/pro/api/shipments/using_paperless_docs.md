---
uid: pro-api-help-shipments-using-paperless-docs
title: Using Paperless Documents
tags: shipments,pro,api,paperless,documents
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 08/07/2020
---

# Using Paperless Documents


---

## Getting Paperless Documents

This endpoint is used to retrieve paperless documents.

NOTE
"Paperless" documents are provided by customers when creating shipments and enable the transmission of customer-generated documents to carriers.

`GET https://api.sorted.com/pro/documents/paperless/{document_reference}`

## Adding Paperless Documents to Shipments

This endpoint is used to enable customers to add paperless documents to existing shipments.

WARNING
It is only possible to add a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

`GET https://api.sorted.com/pro/documents/paperless/{shipment_reference}`

## Removing Paperless Documents from Shipments

This endpoint is used to remove an existing paperless_document from a shipment.

WARNING
It is only possible to remove a paperless_document to a shipment prior to allocation, i.e. when the shipment is in a state of unallocated or allocation_failed.

`GET https://api.sorted.com/pro/documents/paperless/{document_reference}`

## Next Steps

