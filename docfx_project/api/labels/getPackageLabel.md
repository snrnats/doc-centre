# Get Package Label

Returns the label for the specified package.

`GET https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}`


<div class="refcontainer">
<div class="refdivider">

## Headers

</div>
<div class="refdivider">

### Keys

<table>
    <tr>
        <td>ocp-apim-subscription-key</td>
        <td>Your API key. Must be provided with all requests</td>
    </tr>
    <tr>
        <td>Accept</td>
        <td>Specify what type of response you want to receive, either JSON or XML</td>
    </tr>
    <tr>
        <td>Content-Type</td>
        <td>Specify what type of content you are sending, either JSON or XML</td>
    </tr>
    <tr>
        <td>electio-api-version</td>
        <td>The version of the API to use, currently 1.1</td>
    </tr>
</table>

</div>
<div class="refdivider">

### Example

```json
ocp-apim-subscription-key: [qwerrtyuiioop0987654321]
content-type: application/json
accept: application/json
electio-api-version: 1.1
```

</div>
</div>

<div class="refcontainer">
<div class="refdivider">

---

## Request

</div>
<div class="refdivider">

### Parameters

<table>
    <tr>
        <td>Consignment Reference</td>
        <td>string</td>
    </tr>
    <tr>
        <td colspan="2">A unique identifier for a PRO consignment. Takes the format <code>EC-xxx-xxx-xxx</code>.</td>
    </tr>
    <tr>
        <td>Package Reference</td>
        <td>string</td>
    </tr>
    <tr>
        <td colspan="2">A unique identifier for a PRO package. Takes the format <code>EP-xxx-xxx-xxx</code>.</td> 
    </tr>    
</table> 

</div>
<div class="refdivider">

### Example

```
GET https://api.electioapp.com/labels/EC-000-05B-MMA/EP-000-05E-ETQ
```

</div>
</div>

<div class="refcontainer">
<div class="refdivider">

---

## Responses

</div>
<div class="refdivider">

### Properties

<table>
    <tr>
        <td>File</td>
        <td>Byte[]</td>
    </tr>
    <tr>
        <td colspan ="2">A base64-encoded byte array representing the file content</td>
    </tr>
    <tr>
        <td>ContentType</td>
        <td>String</td>
    </tr>
    <tr>
        <td colspan="2">The content type of the file - for example, "application/pdf".</td>    
    </tr>
</table>    

</div>
<div class="refdivider">

### Example

```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZl ... VRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```
</div>
</div>