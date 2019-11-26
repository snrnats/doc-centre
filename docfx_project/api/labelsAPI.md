# Labels API

`https://api.electioapp.com/labels/`

* [Get Labels](/api/labels/getLabels.html)
* [Get Labels in Format](/api/labels/getLabelsInFormat.html)
* [Get Package Label](/api/labels/getPackageLabel.html)
* [Get Package Label in Format](/api/labels/getPackageLabelInFormat.html)

---

SortedPRO can generate despatch labels for all of its carriers, enabling PRO customers to download labels without having to request them directly from the carrier. The **Labels** API enables you to get labels for a specific consignment or an individual package within a consignment.

Getting labels is a key part of all PRO workflows, as an unlabelled consignment cannot be dispatched. Labels are usually retrieved after a consignment has been allocated but before it has been manifested.

> <span class="note-header">Note: </span>
> 
> You can only retrieve labels for consignments that have been allocated to a carrier. If you attempt to return labels for an unallocated consignment, PRO returns an error.

## Endpoints

The Labels API has four endpoints:

* [Get Labels](/api/labels/getLabels.html) - `GET https://api.electioapp.com/labels/{consignmentReference}` </br> Returns labels for the specified consignment.
* [Get Labels in Format](/api/labels/getLabelsInFormat.html) - `GET https://api.electioapp.com/labels/{consignmentReference}/{labelFormat}` </br> Returns labels for the specified consignment in the specified format.
* [Get Package Label](/api/labels/getPackageLabel.html) - `GET https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}` </br> Returns the label for the specified package.
* [Get Package Label in Format](/api/labels/getPackageLabelInFormat.html) - `GET https://api.electioapp.com/labels/package/{consignmentReference}/{packageReference}/{labelFormat}` </br> Returns the label for the specified package in the specified format.

### Parameters

The Labels API accepts the following parameters:

* **Consignment Reference** - Used by all Labels endpoints. A unique identifier for a PRO consignment. Each `{consignmentReference}` takes the format EC-xxx-xxx-xxx, where x is an alphanumeric character.
* **Package Reference** - Used by the **Get Package Label** and **Get Package Label in Format** endpoints. A unique identifier for a PRO package. Each `{packageReference}` takes the format EP-xxx-xxx-xxx, where x is an alphanumeric character. 
* **Label Format** - Used by the **Get Labels in Format** and **Get Package Label in Format** endpoints. The label format required. This must be one of PRO's supported formats: PDF, PNG, ZPL or ZPLII. 

### Response

All Labels endpoints return a labels object. The labels object has two properties:

* `File` - A base64-encoded byte array representing the file content.
* `ContentType` - The content type of the file (as specified in the **Label Format** parameter, where applicable).

**Example**

```json
{
  "File": "SlZCRVJpMHhMalFLSmRQcjZl ... VRrNU9ERUtKU1ZGVDBZPQ==",
  "ContentType": "application/pdf"
}
```

## Using the Label Data

Once you have obtained the raw label data, you will need to perform some processing in order to use it. For example methods to read the data, write it to disk, and automatically open the label file so it can be printed and applied to the relevant package, see the [Labels SDK documentation](/../pro-sdk/reference/ref-labels/index.html). 