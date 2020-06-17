# [Get Customs Documents Endpoint](#tab/get-customs-documents-endpoint)

```json
GET https://api.electioapp.com/consignments/docs/{consignmentReference}
```
---

When shipping internationally, SortedPRO will automatically determine if customs documentation is necessary for a consignment, and generate documents where required. You can retrieve customs documentation via the **Get Customs Documents** endpoint.

The **Get Customs Documents** endpoint takes a `{consignmentReference}` as a path parameter. If CN22/CN23 or commercial invoice documents exist for the specified consignment, then PRO returns these documents as a base64-encoded byte array that will decode to a PDF document.

> [!NOTE]
> * For full reference information on the <strong>Get Customs Documents</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetCustomsDocuments">Get Customs Documents</a></strong> page of the API reference.
> * For a user guide on retrieving customs documents and commercial invoices in PRO, see the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page.  
  
### Get Customs Documents Example

This example shows a **Get Customs Documents** response for a single-package consignment. PRO has returned a commercial invoice for the consignment and a CN22 document for the package.

You will need to decode the file's Base64 data in order to view or print the documents. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

# [Get Customs Documents Request](#tab/get-customs-documents-request)

```json
GET https://api.electioapp.com/consignments/docs/EC-000-05B-MMA
```

# [Get Customs Documents Response](#tab/get-customs-documents-response)

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
---