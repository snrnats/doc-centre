> Get Labels Endpoint
```
GET https://api.electioapp.com/labels/{consignmentReference}
```
> Example Get Labels Request
```
GET https://api.electioapp.com/labels/EC-000-05A-Z6S
```
> Example Get Labels Response
```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZ ... [truncated for brevity] ... TVRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```
```xml
<?xml version="1.0" encoding="utf-8"?>
<GetLabelsResponse xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.LabelGeneration">
  <File>SlZCRVJpMHhMalFLSmRQcjZ ... [truncated for brevity] ... TVRrNU9ERUtKU1ZGVDBZPQ==</File>
  <ContentType>application/pdf</ContentType>
</GetLabelsResponse>
```

When a consignment is allocated, SortedPRO generates labels for each package in that consignment. The next step in the process is to retrieve those delivery labels via the **[Get Labels](https://docs.electioapp.com/#/api/GetLabels)** endpoint.

The **Get Labels** endpoint takes a `{consignmentReference}` as a path parameter. PRO returns all package labels associated with that consignment as a base64-encoded byte array, and a `ContentType` property indicating the file format that the label(s) are in.

<aside class="note">
  For full reference information on the <strong>Get Labels</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetLabels">Get Labels</a></strong> page of the API reference. 
  
  In addition to the <strong>Get Labels</strong> endpoint, the following PRO endpoints also return label data:

  * <strong><a href="https://docs.electioapp.com/#/api/GetLabelsinFormat">Get Labels in Format</a></strong> - returns a consignment's labels in one of PRO's supported file formats.
  * <strong><a href="https://docs.electioapp.com/#/api/GetPackageLabel">Get Package Label</a></strong> - returns a label for an individual package.
  * <strong><a href="https://docs.electioapp.com/#/api/GetPackageLabelinFormat">Get Package Label in Format</a></strong> - returns a label for an individual package in a file format of your choice.
</aside>  

### Examples

The example shows a request to get labels for a consignment with a `{consignmentReference}` of _EC-000-05A-Z6S_. The file data in the response has been truncated for clarity.

You would next need to decode the file's Base64 in order to view the label itself. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.