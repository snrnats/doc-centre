# Get Labels

Returns labels for the specified consignment.

`GET https://api.electioapp.com/labels/{consignmentReference}`



## Request


<div class="tab">
    <button class="requestTabLinks" onclick="openRequestTab(event, 'headers')">Headers</button>
    <button class="requestTabLinks" onclick="openRequestTab(event, 'path')" id="defaultRequest">Body</button>
</div>

<div id="headers"  class="requestTabContent">

[!include[apiheaders](../includes/apiheaders.md)]

</div>

<div id="path"  class="requestTabContent">

<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Validation</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <td>Code</td>
        <td>string</td>
        <td>The PRO error code returned. Note that this is an internal code, and not a HTTP status code</td>
        <td>-</td>
        <td>1</td>
    </tr>
</table> 

<div class="copyheader">

### Example
<div class="copybutton" onclick="CopyToClipboard('requestExample')">Click to Copy</div>

</div>

<div id="requestExample" class="copycontent"onclick="CopyToClipboard('requestExample')">

```
GET https://api.electioapp.com/labels/EC-000-05B-MMA
```
</div>

</div>

## Responses

<div class="tab">
  <button class="responseTabLinks" onclick="openCity(event, '200')" id="defaultResponse">200 (OK)</button>
  <button class="responseTabLinks" onclick="openCity(event, '400')">400 (Not Found)</button>
</div>

<div id="200"  class="responseTabContent">

<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <td>Code</td>
        <td>string</td>
        <td>The PRO error code returned. Note that this is an internal code, and not a HTTP status code</td>
        <td>1</td>
    </tr>
</table> 

<div class="copyheader">
    
<h3>Example</h3>
<div class="copybutton" onclick="CopyToClipboard('200example')">Click to Copy</div>

</div>

<div id="200example" class="copycontent" onclick="CopyToClipboard('200example')">

```json
{
    "File": "SlZCRVJpMHhMalFLSmRQcjZl ... VRrNU9ERUtKU1ZGVDBZPQ==",
    "ContentType": "application/pdf"
}
```
</div>

</div>

<div id="400"  class="responseTabContent">

<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <td>Code</td>
        <td>string</td>
        <td>The PRO error code returned. Note that this is an internal code, and not a HTTP status code</td>
        <td>1</td>
    </tr>
</table>

<div class="copyheader">
    
<h3>Example</h3>
<div class="copybutton" onclick="CopyToClipboard('400example')">Click to Copy</div>

</div>

<div id="400example" class="copycontent" onclick="CopyToClipboard('400example')">

```json
{
  "Code": "SampleErrorCode",
  "Message": "Item {reference} not found",
  "CorrelationId": "f94c7dbc-c542-40b9-b6da-bd98aa110939"
}
```

</div>

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>
