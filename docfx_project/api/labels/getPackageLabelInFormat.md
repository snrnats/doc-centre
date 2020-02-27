# Get Package Label in Format

Returns the label for the specified package in the specified format 

`GET https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}/{labelFormat}`

## Request

<div class="tab">
    <button class="requestTabLinks" onclick="openRequestTab(event, 'headers')">Headers</button>
    <button class="requestTabLinks" onclick="openRequestTab(event, 'path')" id="defaultRequest">Path</button>
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
        <td>Consignment Reference</td>
        <td>string</td>
        <td>A unique identifier for a PRO consignment </td>
        <td>Must be in the format <code>EC-xxx-xxx-xxx</code></td>
        <td>1</td>
    </tr>
    <tr>
        <td>Package Reference</td>
        <td>string</td>
        <td>A unique identifier for a PRO package </td>
        <td>Must be in the format <code>EP-xxx-xxx-xxx</code></td>
        <td>1</td>
    </tr> 
    <tr>
        <td>Label Format</td>
        <td>string</td>
        <td>The label format required</td>
        <td>Must be one of PRO's supported formats: PDF, PNG, ZPL or ZPLII</td>
        <td>1</td>
    </tr>       
</table> 

<div class="copyheader">

### Example
<div class="copybutton" onclick="CopyToClipboard(this, 'requestExample')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>

</div>

<div id="requestExample" class="copycontent"onclick="CopyToClipboard(this, 'requestExample')">

```
GET https://api.electioapp.com/labels/EC-000-05B-MMA/EP-000-05E-ETQ/pdf
```
</div>

</div>

## Responses

<div class="tab">
  <button class="responseTabLinks" onclick="openCity(event, '200')" id="defaultResponse">200 (OK)</button>
  <button class="responseTabLinks" onclick="openCity(event, '404')">404 (Not Found)</button>
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
        <td>File</td>
        <td>Byte[]</td>
        <td>A base64-encoded byte array representing the file content</td>
        <td>1</td>
    </tr>
    <tr>
        <td>ContentType</td>
        <td>string</td>
        <td>The content type of the file - for example, "application/pdf".</td>
        <td>1</td>
    </tr>    
</table> 

<div class="copyheader">
    
<h3>Example</h3>
<div class="copybutton" onclick="CopyToClipboard(this, '200example')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>

</div>

<div id="200example" class="copycontent" onclick="CopyToClipboard(this, '200example')">

```json
{
    "File": "SlZCRVJpMHhMalFLSmRQcjZl ... VRrNU9ERUtKU1ZGVDBZPQ==",
    "ContentType": "application/pdf"
}
```
</div>

</div>

<div id="404"  class="responseTabContent">

[!include[404Content](../includes/404Content.md)]

</div>

[!include[scripts](../includes/scripts.md)]