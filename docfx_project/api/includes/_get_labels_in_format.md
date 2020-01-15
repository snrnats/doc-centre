<div class="tab">
    <button class="staticTabButton">Get Labels in Format Endpoint</button>
</div>
<div class="staticTabContent">

```
GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}
```
</div>

When a consignment is allocated, SortedPRO generates labels for each package in that consignment. The next step in the process is to retrieve those delivery labels via the **[Get Label in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat)** endpoint.

The **Get Labels in Format** endpoint takes a `{consignmentReference}` and `{labelFormat}` as path parameters. PRO returns all package labels associated with that consignment as a base64-encoded byte array in the format requested.

**Get Labels in Format** can return labels as `pdf`, `zpl` and `zplii` file types. We recommend that, when integrating PRO with your system, you make the `{labelFormat}` field a parameter, so you can easily return labels in an alternative format if required.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Get Labels in Format</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetLabelsinFormat">Get Labels in Format</a></strong> page of the API reference. 
  
### Examples

The example shows a request to get PDF labels for a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_. The file data in the response has been truncated for clarity.

You would next need to decode the file's Base64 in order to view the label itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

<div class="tab">
    <button class="staticTabButton">Example Get Labels in Format Request</button>
</div>
<div class="staticTabContent">

```
GET https://api.electioapp.com/labels/EC-000-05B-MMA/pdf
```

</div>

<div class="tab">
    <button class="staticTabButton">Example Get Labels in Format Response</button>
</div>
<div class="staticTabContent">

```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZ ... [truncated for brevity] ... TVRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```

</div>