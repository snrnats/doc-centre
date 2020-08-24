This object represents a single document.

<div class="dc-row">
<div class="dc-column">
        <h4>Properties</h4>
        <div class="property">
            <div class="name"><code>file</code></div>
            <div class="type">string</div>
            <div class="occurs">1</div>
            <div class="description">The contents of the file encoded in base64</div>
        </div>
        <div class="property">
            <div class="name"><code>content_type</code></div>
            <div class="type">string</div>
            <div class="occurs">1</div>
            <div class="description">The format of the `document`, e.g. `application/pdf`</div>
            <div class="dropdown"> 
                <button onclick="dropFunction(this)">Show child properties</button>
                <div class="dropdown-content">

[!include[_content_type](_content_type.md)]
</div>
            </div>              
        </div>
        <div class="property">
            <div class="name"><code>document_type</code></div>
            <div class="type">string</div>
            <div class="occurs">1</div>
            <div class="description">The type of `document`</div>
            <div class="dropdown"> 
                <button onclick="dropFunction(this)">Show child properties</button>
                <div class="dropdown-content">

[!include[_document_type](_document_type.md)]
</div>
            </div>              
        </div>
        <div class="property">
            <div class="name"><code>dpi</code></div>
            <div class="type">integer</div>
            <div class="occurs">1</div>
            <div class="description">The DPI of the `document`</div>          
        </div>
    </div>
<div class="dc-column">
<h4>Example</h4>

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