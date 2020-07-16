---
uid: pro-api-help-shipments-managing-documents
title: Managing Documents
tags: shipments,pro,api,customs,documents,paperless
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---

# Managing Documents

Shipping internationally? This section explains how to retrieve customs documentation for your shipments, and how to add, retrieve, and remove paperless shipment documents.

---

## Customs Documents

When a shipment is allocated, SortedPRO takes into account its origin and destination countries, the value of goods to be shipped, and the carrier service that will take the shipment to identify whether the shipment will need customs documentation. PRO can automatically generate CN22, CN23, and Commercial Invoice documents.

PRO offers two endpoints to retrieve customs documents once they have been generated:

* **Get Customs Documents** retrieves all customs documents that have been generated for a particular shipment.
* **Get Document** retrieves a specific customs document.

## Paperless Documents

PRO also supports paperless trade. 

"Paperless" documents are provided by customers when creating shipments and enable the transmission of customer-generated documents to carriers. The intention of allowing customers to supply documents is to allow original copies of documents such as certificates of conformity to be supplied to carriers in a paperless trade flow.

## Documents Section Contents