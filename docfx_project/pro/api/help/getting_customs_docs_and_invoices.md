# Getting Customs Docs and Invoices

This page explains the various way in which SortedPRO can return return customs documents and commercial invoices.

---

## Customs Docs in PRO

When shipping internationally, SortedPRO will automatically determine if customs documentation is required for a consignment. SortedPRO can automatically generate CN22, CN23, or Commercial Invoice documents in PDF format and will determine which document is appropriate for any allocated consignment. The Customs Docs APIs enable you to retrieve the pre-generated documents.

The Customs Docs API has three endpoints:

* **Get Commercial Invoice** - returns a consignment's commercial invoice.
* **Get Customs Document** - returns a CN22 or CN23 document for a particular package.
* **Get Customs Documents** - returns all customs documents for a particular consignment.

> [!NOTE]
>
> You can only retrieve documents for consignments that have been allocated to a carrier. If you attempt to return labels for an unallocated consignment, PRO returns an error.

## Getting Commercial Invoices

To call **Get Commercial Invoice**, send a `GET` request to `https://api.electioapp.com/consignments/docs/commercialinvoice/{consignmentReference}`. PRO returns the commercial invoice for the relevant consignment as a base-64 encoded byte array.

> <span class="note-header">More information:</span>
>
> For full reference information on the **Get Commercial Invoice** endpoint, see the [API reference](https://docs.electioapp.com/#/api/GetCommercialInvoice).

## Getting an Individual Customs Document

To call **Get Customs Document**, send a `GET` request to `https://api.electioapp.com/consignments/docs/{customsDocumentType}/{consignmentReference}/{packageReference}`. The `{customsDocumentType}` can return either _CN22_ or _CN23_ documents.

PRO returns the relevant document as a base-64 encoded byte array.

> <span class="note-header">More information:</span>
>
> For full reference information on the **Get Customs Document** endpoint, see the [API reference](https://docs.electioapp.com/#/api/GetCustomsDocument).

## Getting All Customs Documents for a Consignment

To call **Get Customs Documents**, send a `GET` request to `https://api.electioapp.com/consignments/docs/{consignmentReference}`.

PRO returns an object containing two properties: a `CommercialInvoiceDocuments` property containing the consignment's commercial invoice and either a `CN22Documents` property containing all CN22 documents for the consignment or a `CN23Documents` property containing all CN23 documents for the consignment.

All documents are represented as key / value pairs, with the key as the filename for the document and the value containing the document data.

> <span class="note-header">More information:</span>
>
> For full reference information on the **Get Customs Documents** endpoint, see the [API reference](https://docs.electioapp.com/#/api/GetCustomsDocuments).

### Get Customs Documents Example

This example shows a **Get Customs Documents** response for a single-package consignment. PRO has returned a commercial invoice for the consignment and a CN22 document for the package.

<div class="tab">
    <button class="staticTabButton">Get Customs Documents Example Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'customsDocsResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="customsDocsResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'customsDocsResponse')">

```json
{
  "CommercialInvoiceDocuments": [
    {
      "Key": "INV_Example",
      "Value": "(document data)"
    }
  ],
  "CN22Documents": [
    {
      "Key": "CN22_Example",
      "Value": "(document data)"
    }
  ]
}
```

</div>

> [!NOTE]
>
> Once you have downloaded the file data, you will need to decode the file's Base64 in order to view the document itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

## Next Steps

* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.
* Learn how to track consignments at the [Tracking Consignments](/pro/api/help/tracking_consignments.html) page.

> [!NOTE]
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>