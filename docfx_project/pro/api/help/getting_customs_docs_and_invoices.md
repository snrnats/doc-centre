# Getting Customs Docs And Invoices

This page explains the various way in which SortedPRO can return return customs documents and commercial invoices.

---

## Customs Docs in PRO

When an international non-EU shipment (that is, an international shipment that either originates from a non-EU country, is destined for a non-EU country, or both <span class="highlight">PRESUMABLY THIS IS GOING TO CHANGE WITH BREXIT?</span>) is allocated, PRO generates CN22, CN23 and commercial invoice documents for it. The Customs Docs API enables you to retrieve that information.

The Customs Docs API has three endpoints:

* **Get Commercial Invoice** - returns a consignment's commercial invoice.
* **Get Customs Document** - returns a CN22 or CN23 document for a particular package.
* **Get Customs Documents** - returns all customs documents for a particular consignment.

> <span class="note-header">Note:</span>
>
> You can only retrieve documents for consignments that have been allocated to a carrier. If you attempt to return labels for an unallocated consignment, PRO returns an error.

## Getting Commercial Invoices

To call **Get Commercial Invoice**, send a `GET` request to `https://api.electioapp.com/consignments/docs/commercialinvoice/{consignmentReference}`. PRO returns the commercial invoice for the relevant consignment as a base-64 encoded byte array.

> <span class="note-header">More information:</span>
>
> For full reference information on the **Get Commercial Invoice** endpoint, see the [API reference](https://docs.electioapp.com/#/api/GetCommercialInvoice).

## Getting an Individual Customs Document

To call **Get Customs Document**, send a `GET` request to `https://api.electioapp.com/consignments/docs/{customsDocumentType}/{consignmentReference}/{packageReference}`. The `{customsDocumentType}` can either _CN22_ or _CN23_.

PRO returns the relevant document as a base-64 encoded byte array.

> <span class="note-header">More information:</span>
>
> For full reference information on the **Get Customs Document** endpoint, see the [API reference](https://docs.electioapp.com/#/api/GetCustomsDocument).

## Getting All Customs Documents For A Consignment

To call **Get Customs Documents**, send a `GET` request to `https://api.electioapp.com/consignments/docs/{consignmentReference}`.

PRO returns an object containing three properties:

* A `CommercialInvoiceDocuments` property containing the consignment's commercial invoice.
* A `CN22Documents` property containing all CN22 documents for the consignment.
* A `CN23Documents` property containing all CN23 documents for the consignment.

All documents are represented as key / value pairs, with the key as the filename for the document and the value containing the document data.

> <span class="note-header">More information:</span>
>
> For full reference information on the **Get Customs Documents** endpoint, see the [API reference](https://docs.electioapp.com/#/api/GetCustomsDocuments).

### Get Customs Documents Example

This example shows a **Get Customs Documents** response for a single-package consignment. PRO has returned a commercial invoice for the consignment and both CN22 and CN23 documents for the package.

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
  ],
  "CN23Documents": [
    {
      "Key": "CN23_Example",
      "Value": "(document data)"
    }
  ]
}
```

</div>

## Using the Document Data

Once you have obtained the raw document data, you will need to perform some processing in order to use it. For example methods to read the data, write it to disk, and automatically open the label file so it can be printed and applied to the relevant package, see <span class="highlight">LINK HERE</span>.

## Next Steps

*
*
*

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>