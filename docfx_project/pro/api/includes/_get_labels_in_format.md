<div class="tab">
    <button class="staticTabButton">Get Labels in Format Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'GLFEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="GLFEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'GLFEndpoint')">

```
GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}
```
</div>

When a consignment is allocated, SortedPRO generates labels for each package in that consignment. You can retrieve these delivery labels via the **[Get Label in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat)** endpoint.

The **Get Labels in Format** endpoint takes a `{consignmentReference}` and `{labelFormat}` as path parameters. PRO returns all package labels associated with that consignment as a base64-encoded byte array that decodes to the format requested.

> <span class="note-header">Note:</span>
> * For full reference information on the <strong>Get Labels in Format</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetLabelsinFormat">Get Labels in Format</a></strong> page of the API reference.
> * For a user guide on retrieving labels in PRO, see the [Getting Labels](/pro/api/help/getting_labels.html) page.  
  
### Get Labels in Format Example

The example shows a request to get PDF labels for a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_. The file data in the response has been truncated for clarity.

You will need to decode the File's Base64 data in order to view or print the label. If you are unsure how to do this, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

<div class="tab">
    <button class="staticTabButton">Example Get Labels in Format Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'GLFRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="GLFRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'GLFRequest')">

```
GET https://api.electioapp.com/labels/EC-000-05B-MMA/pdf
```

</div>

<div class="tab">
    <button class="staticTabButton">Example Get Labels in Format Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'GLFResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="GLFResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'GLFResponse')">

```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZ ... TVRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```

</div>
