---
uid: pro-api-help-shipments-getting-collection-notes
title: Getting Collection Notes
tags: shipments,pro,api,shipment groups,collection notes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Collection Notes

PRO's Collection Note functionality enables you to generate driver's manifest documents for your shipments. This page explains the various ways in which you can generate collection notes.

---

## Making a Collection Note Request

In PRO, a collection note (sometimes referred to as a driver's manifest) is a document listing items that are to be collected by a driver. It is intended to be printed and given to the driver at the point of collection.

In order to generate a note for a specific collection, you will need to tell PRO which shipments are to be picked up as part of that collection. PRO has three endpoints that enable you to do so:

* **Get Shipment Group Collection Note** - Retrieves a collection note for all of the shipments in the specified shipment group.
* **Get Collection Note by Query** - Retrieves a collection note for all of the shipments that meet the specified criteria. 
* **Get Collection Note by Manifests** - Retrieves a collection note for all of the shipments listed on the specified manifest files.

> [!NOTE]
> This page explains how to generate a single collection note for a number of shipments that are being picked up together, for example as part of a scheduled collection. 
>
> You can also get a collection note for a single shipment via the **Get Document** endpoint, which is covered on the [Getting Shipment Documents](/pro/api/shipments/getting_shipment_documents.html) page.

### Getting Collection Notes for a Shipment Group

To call **Get Shipment Group Collection Note**, send a `GET` request to `https://api.sorted.com/pro/collection_notes/shipment_group/{reference}`, where `{reference}` is the unique reference of the shipment group you want to get a collection note for.

Alternatively, you can call **Get Shipment Group Collection Note** using a shipment's `{custom_reference}` and `{version}` by sending a `GET` request to `https://api.sorted.com/pro/collection_notes/shipment_group/custom_reference/{custom_reference}/{version}`. `{version}` must be either an integer or the value _latest_.

PRO returns a collection note listing the contents of all of the shipments in the specified group.

> [!NOTE]
> * For an explanation of versioning in PRO shipment groups, see the [Versioning in Shipment Groups](/pro/api/shipments/getting_shipment_groups.html#versioning-in-shipment-groups) section of the [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html) page.
> * For full reference information on the **Get Shipment Group Collection Note** endpoint, see LINK HERE.

# [Example Get Shipment Group Collection Note Request](#tab/get-shipment-group-collection-note-request)

The example shows a collection note request for shipment group *sg_00693870520933731157514090446848*.

```json
GET https://api.sorted.com/pro/collection_notes/shipment_group/sg_00693870520933731157514090446848
```
---

### Getting Collection Notes by Query

To call **Get Collection Note by Query**, send a `POST` request to `https://api.sorted.com/pro/collection_notes/query`. The body of the request should contain a Collection Note Query object. The Collection Note Query must contain the following properties:

* The shipment's destination `address`.
* The `carrier` that the shipments are allocated to.
* A list of `shipment_states`.

In addition, the request can contain the following optional properties:

* A `labels_printed` boolean property indicating whether or not only shipments whose labels have been printed should be included in the note.
* A `shipping_date` range enabling you to specify shipments shipping within a specific time period.

PRO returns a collection note listing the contents of all of the shipments that meet all of the criteria you specified.

> [!NOTE]
> For full reference information on the **Get Collection Note by Query** endpoint, see LINK HERE.

# [Example Get Collection Note by Query Request](#tab/get-collection-note-by-query-request)

`POST https://api.sorted.com/pro/collection_notes/query`

```json

```
---

<span class="highlight">Need to add example once endpoint is up and running</span>

### Getting Collection Notes by Manifest

To call **Get Collection Note by Manifests**, send a `POST` request to `https://api.sorted.com/pro/collection_notes/manifest`. The body of the request should contains a list of one or more `manifest` references.

PRO returns a collection note listing the contents of all of the shipments that are on one of the specified manifests.

> [!NOTE]
> * For more information on manifesting in PRO, see the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) section.
> * For full reference information on the **Get Collection Note by Manifests** endpoint, see LINK HERE.

# [Example Get Collection Note by Manifests Request](#tab/get-collection-note-by-manifests-request)

`POST https://api.sorted.com/pro/collection_notes/manifest`

```json

```
---

<span class="highlight">Need to add example once endpoint is up and running</span>

## The Collection Note Response

All Collection Notes endpoints return a collection note as a `document` object with a `document_type` of *collection_note*.

[!include[_shipments_document_object](../includes/_shipments_document_object.md)]

<span class="highlight">Example collection note in here</span>

# [Example Collection Note Response](#tab/example-collection-note-response)

```json
  {
    "file": {Base64 file contents},
    "content_type": "application/pdf",
    "document_type": "collection_note",
    "dpi": 203
  }
```
---

## Next Steps

* Learn how to tracking shipments using PRO's Tracking API: [Tracking PRO Shipments](/pro/api/shipments/tracking_pro_shipments.html)
* See a Glossary of PRO terms: [Glossary](/pro/api/shipments/shipments_glossary.html)
* Learn how to use REACT, Sorted's advanced shipment tracking product: [REACT Docs](/react/index.html?v2)