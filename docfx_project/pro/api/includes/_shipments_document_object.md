The document object has four properties:

* `file` - A base64-encoded byte array representing the file content.
* `content_type` - The document's format (e.g. _application/pdf_).
* `document_type` - The type of document (e.g. _commercial_invoice_).
* `dpi` - The document's resolution in DPI.

<span class="highlight">HOW DO WE HANDLE DECODING THE FILE? DO WE JUST ASSUME CUSTOMERS ARE GOING TO DO IT THEMSELVES OR SHOULD WE PROVIDE INSTRUCTIONS?</span>