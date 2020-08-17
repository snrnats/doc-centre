This object represents a single document.

<div class="dc-row">
<div class="dc-column">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `file` | `string` | The contents of the file encoded in base64 | `1` |
| `content_type` | `string`| The format of the `document`, e.g. `application/pdf`. See [`content_type`](../shipments-dc.html#content-type). | `1` |
| `document_type` | `string` | The type of `document`. See [`document_type`](../shipments-dc.html#document-type). | `1` |
| `dpi` | `integer` | The DPI of the `document`. | `1` |

</div>
<div class="dc-column">

```json
{
    "file": "XlhBCgpeRlggRGlzcGxheXMgY29ycmVjdGx5IGFzIDZ4NCBhdCAzMDBkcGkKXkNGMCw2MApeRk81MCw1MF5HQjEwMCwxMDAsMTAwXkZTCl5GTzc1LDc1XkZSXkdCMTAwLDEwMCwxMDBeRlMKXkZPODgsODheR0I1MCw1MCw1MF5GUwpeRk8yMjAsNTBeRkRFYXN0ZXIgU2hpcHBpbmcgQ28uXkZTCl5DRjAsNDAKXkZPMjIwLDEwMF5GRDEyMyBSYWJiaXQgTGFuZV5GUwpeRk8yMjAsMTM1XkZEU2hlbGJ5dmlsbGUgVE4gMzgxMDJeRlMKXkZPMjIwLDE3MF5GRFVuaXRlZCBTdGF0ZXMgKFVTQSleRlMKXkZPNTAsMjUwXkdCNzAwLDEsM15GUwoKXkNGQSwzMApeRk81MCwzMDBeRkRNYXJ5IE1hcnleRlMKXkZPNTAsMzQwXkZEMTAwIExpdHRsZSBMYW1iIFN0cmVldF5GUwpeRk81MCwzODBeRkRTcHJpbmdmaWVsZCBUTiAzOTAyMV5GUwpeRk81MCw0MjBeRkRVbml0ZWQgU3RhdGVzIChVU0EpXkZTCl5DRkEsMTUKXkZPNjAwLDMwMF5HQjE1MCwxNTAsM15GUwpeRk82MzgsMzQwXkZEUGVybWl0XkZTCl5GTzYzOCwzOTBeRkQ4ODg0NzReRlMKXkZPNTAsNTAwXkdCNzAwLDEsM15GUwoKXkJZNSwyLDI3MApeRk8xMDAsNTUwXkJDXkZEc3BfMTAwMTQ0MTg2OTI1NDY5NTMyMTZeRlMKCl5GTzUwLDkwMF5HQjgwMCwyNTAsM15GUwpeRk81MDAsOTAwXkdCMSwyNTAsM15GUwpeQ0YwLDQwCl5GTzEwMCw5NjBeRkRTaGlwcGluZyBDdHIuIFgzNEItMV5GUwpeRk8xMDAsMTAxMF5GRFJFRjEgRjAwQjQ3XkZTCl5GTzEwMCwxMDYwXkZEUkVGMiBCTDRIOF5GUwpeQ0YwLDE5MApeRk81NjAsOTY1XkZERkZeRlMKCl5YWg==",
    "content_type": "text/plain",
    "document_type": "label",
    "dpi": 300,
    "copies": 2
}
```

</div>
</div>

> [!WARNING]
> All documents are provided in base64 encoding and will need to be decoded before being saved to disk or printed.