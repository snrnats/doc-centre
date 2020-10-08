---
uid: pro-api-help-shipments-getting-shipment-labels
title: Getting Shipment Labels
tags: shipments,pro,api,labels
contributors: andy.walton@sorted.com
created: 08/10/2020
---
# Getting Shipment Labels

SortedPRO can generate despatch labels for all of its carriers, enabling PRO customers to download labels without having to request them directly from the carrier. This page explains how to get labels for a specific shipment or an individual package within a shipment.

---

## The Labels Request

Getting labels is a key part of all PRO workflows, as an unlabelled shipment cannot be dispatched. When a shipment is allocated, PRO generates delivery labels for all of its `contents` properties.

Labels are usually retrieved before a shipment has been manifested.

PRO offers label extensions, which enable customers to specify custom text, images and QR codes on their labels. Each PRO customer can have a single label extension, which is configured during the onboarding process.

> [!CAUTION]
> 
> You can only retrieve labels for shipments that have been allocated to a carrier. If you attempt to return labels for an unallocated shipment, PRO returns an error.

### Getting All Labels for a Shipment

The **Get Labels** endpoint retrieves all labels for the specified shipment. To call **Get Labels**, send a `GET` request to `https://api.sorted.com/pro/labels/{shipment_reference}/{format}(/dpi)`, where `{shipment_reference}` is the unique reference of the shipment you want to get labels for, `{format}` is the file format required (either PDF or ZPL), and `{dpi}` is an optional parameter indicating the resolution required. <span class="highlight">Is there a list of acceptable resolutions? Does this vary with file type?</span>

**Get Labels** also has an optional `?include_extension=bool` boolean (true/false) query enabling you to specify whether you want the returned labels to include your custom label extensions. If you do not provide an `include_extension` query then PRO returns label extensions by default.

### Example Get Labels Calls

* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/pdf` - Get all labels for shipment _sp_00668400124857422605561635799040_ in PDF format.
* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/zpl/300` - Get all labels for shipment _sp_00668400124857422605561635799040_ in ZPL format at 300 DPI resolution.
* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/pdf?include_extension=false` - Get all labels for shipment _sp_00668400124857422605561635799040_ in PDF format without label extensions.
* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/zpl/300&include_extension=false` - Get all labels for shipment _sp_00668400124857422605561635799040_ in ZPL format at 300 DPI resolution without label extensions.

### Getting a Label for a Specific Item of Contents

The **Get Contents Label** endpoint retrieves the label for a specific item of shipment contents. To call **Get Contents Label**, send a `GET` request to `https://api.sorted.com/pro/labels/{shipment_reference}/{contents_reference}/{format}`, where `{shipment_reference}` is the unique reference of the shipment that the contents belong to, `{contents_reference}` is the unique reference of the contents object you want to get the label for, `{format}` is the file format required (either PDF or ZPL), and `{dpi}` is an optional parameter indicating the resolution required.

> [!NOTE]
> The contents object's unique reference begins with _sc_ and is located in the shipment's `contents.reference` property. It is not to be confused with the shipment's own `reference`, which begins with _sp_ and is a unique identifier for the entire shipment.

**Get Contents Label** also has an optional `?include_extension=bool` boolean (true/false) query enabling you to specify whether you want the returned labels to include your custom label extensions. If you do not provide an `include_extension` query then PRO returns label extensions by default.

### Example Get Contents Label Calls

* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/sc_00668412927930827428118192193538/pdf` - Get all labels for contents _sc_00668412927930827428118192193538_ (located within shipment _sp_00668400124857422605561635799040_) in PDF format. 
* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/sc_00668412927930827428118192193538/zpl/300` - Get all labels for contents _sc_00668412927930827428118192193538_ (located within shipment _sp_00668400124857422605561635799040_) in ZPL format at 300 DPI resolution. 
* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/sc_00668412927930827428118192193538/pdf?include_extension=false` - Get all labels for contents _sc_00668412927930827428118192193538_ (located within shipment _sp_00668400124857422605561635799040_) in PDF format without label extensions. 
* `GET https://api.sorted.com/pro/labels/sp_00668400124857422605561635799040/sc_00668412927930827428118192193538/zpl/300&include_extension=false` - Get all labels for contents _sc_00668412927930827428118192193538_ (located within shipment _sp_00668400124857422605561635799040_) in ZPL format at 300 DPI resolution without label extensions. 

## The Labels Response

Both Labels API endpoints return document objects. 

[!include[_shipments_document_object](../includes/_shipments_document_object.md)]

Labels always have a `document_type` of _label_.

> [!NOTE]
> PRO's **Get Documents** endpoint also retrieves documents. However, it cannot return documents with a `document_type` of _label_. PRO returns an error if you attempt to retrieve a label through **Get Documents**. **Get Labels** and **Get Contents Label** are the only PRO endpoints that can return labels.

### Example Label Response

The example shows a sample label response in ZPL format.

# [Example Label](#tab/example-label)

```json
{
  "file": "XlhBDQogICAgICAgICAgICAgICAgXkNGMCw2MA0KICAgICAgICAgICAgICAgIF5GTzUwLDUwXkdCMTAwLDEwMCwxMDBeRlMNCiAgICAgICAgICAgICAgICBeRk83NSw3NV5GUl5HQjEwMCwxMDAsMTAwXkZTDQogICAgICAgICAgICAgICAgXkZPODgsODheR0I1MCw1MCw1MF5GUw0KICAgICAgICAgICAgICAgIF5GTzIyMCw1MF5GRFhEUCBJbnRlcm5hdGlvbmFsXkZTDQogICAgICAgICAgICAgICAgXkNGMCw0MA0KICAgICAgICAgICAgICAgIF5GTzIyMCwxMDBeRkQxYSBUaGUgSGlnaCBTdHJlZXReRlMNCiAgICAgICAgICAgICAgICBeRk8yMjAsMTM1XkZETWFuY2hlc3RlciwgTTEgNVdBXkZTDQogICAgICAgICAgICAgICAgXkZPMjIwLDE3MF5GREdyZWF0IEJyaXRhaW4gKEdCKV5GUw0KICAgICAgICAgICAgICAgIF5GTzUwLDI1MF5HQjcwMCwxLDNeRlMNCg0KICAgICAgICAgICAgICAgIF5DRkEsMzANCiAgICAgICAgICAgICAgICBeRk81MCwzMDBeRkRBbmRyZXcgTG9ja15GUw0KICAgICAgICAgICAgICAgIF5GTzUwLDM0MF5GREVkd2FyZCBILiBMZXZpIEhhbGxeRlMNCiAgICAgICAgICAgICAgICBeRk81MCwzODBeRkQ1ODAxIFNvdXRoIEVsbGlzIEF2ZW51ZV5GUw0KICAgICAgICAgICAgICAgIF5GTzUwLDQyMF5GRENoaWNhZ28sIElMXkZTDQogICAgICAgICAgICAgICAgXkZPNTAsNDYwXkZEVW5pdGVkIFN0YXRlcyAoVVMpXkZTDQoNCiAgICAgICAgICAgICAgICBeQ0ZBLDE1DQogICAgICAgICAgICAgICAgXkZPNjAwLDMwMF5HQjE1MCwxNTAsM15GUw0KICAgICAgICAgICAgICAgIF5GTzYzOCwzNDBeRkRQZX
  AgICAgICBeQ0ZBLDE1DQogICAgICAgICAgICAgICAgXkZPNjAwLDMwMF5HQjE1MCwxNTAsM15GUw0KICAgICAgICAgICAgICAgIF5GTzYzOCwzNDBeRkRQZXAgICAgICBeQ0ZBLDE1DQogICAgICAgICAgICAgICAgXkZPNjAwLDMwMF5HQjE1MCwxNTAsM15GUw0KICAgICAgICAgICAgI
  JtaXReRlMNCiAgICAgICAgICAgICAgICBeRk82MzgsMzkwXkZEMTIzNDU2XkZTDQogICAgICAgICAgICAgICAgXkZPNTAsNTAwXkdCNzAwLDEsM15GUw0KDQogICAgICAgICAgICAgICAgXkJZNSwyLDI3MA0KICAgICAgICAgICAgICAgIF5GTzEwMCw1NTBeQkNeRkRzcF8wMDY2ODQwMDEyNDg1NzQyMjYwNTU2MTYzNTc5OTA0MF5GUw0KDQogICAgICAgICAgICAgICAgXkZPNTAsOTAwXkdCNzAwLDI1MCwzXkZTDQogICAgICAgICAgICAgICAgXkZPNDAwLDkwMF5HQjEsMjUwLDNeRlMNCiAgICAgICAgICAgICAgICBeQ0YwLDQwDQogICAgICAgICAgICAgICAgXkZPMTAwLDk2MF5GRFJlZHdpbmcgTG9uZG9uXkZTDQogICAgICAgICAgICAgICAgXkZPMTAwLDEwMTBeRkRGMDBCNDdeRlMNCiAgICAgICAgICAgICAgICBeRk8xMDAsMTA2MF5GREJMNEg4XkZTDQogICAgICAgICAgICAgICAgXkNGMCwxOTANCiAgICAgICAgICAgICAgICBeRk80ODUsOTY1XkZEQ0FeRlMNCg0KICAgICAgICAgICAgICAgIF5YWg==",
  "content_type": "text/plain",
  "document_type": "label",
  "dpi": 203
}
```
---

## Using the Label Data

Once you have downloaded the file data, you will need to decode the file's Base64 in order to view the label itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

## Next Steps

* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.
* Learn how to retrieve a shipment's other documents at the [Getting Shipment Documents](/pro/api/shipments/getting_shipment_documents.html) page.
* Learn how to work with shipment groups at the [Managing Shipment Groups](/pro/api/shipments/managing_shipment_groups.html) page.