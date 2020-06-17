# [Get Labels in Format Endpoint](#tab/get-labels-in-format-endpoint)

```json
GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}
```

---

When a consignment is allocated, SortedPRO generates labels for each package in that consignment. You can retrieve these delivery labels via the **[Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat)** endpoint.

The **Get Labels in Format** endpoint takes a `{consignmentReference}` and `{labelFormat}` as path parameters. PRO returns all package labels associated with that consignment as a base64-encoded byte array that decodes to the format requested.

> [!NOTE]
>
> * For full reference information on the **Get Labels in Format** endpoint, see the **[Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat)** page of the API reference.
> * For a user guide on retrieving labels in PRO, see the [Getting Labels](/pro/api/help/getting_labels.html) page.
  
### Get Labels in Format Example

The example shows a request to get PDF labels for a consignment with a `{consignmentReference}` of _EC-000-05B-MMA_. The file data in the response has been truncated for clarity.

You will need to decode the File's Base64 data in order to view or print the label. If you are unsure how to do so, see the **[MDN docs](https://developer.mozilla.org/en-US/docs/Web/API/WindowBase64/Base64_encoding_and_decoding)** for more information.

# [Get Labels in Format Request](#tab/get-labels-in-format-request)

```json
GET https://api.electioapp.com/labels/EC-000-05B-MMA/pdf
```

# [Get Labels in Format Response](#tab/get-labels-in-format-response)

```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZ ... TVRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```

---
