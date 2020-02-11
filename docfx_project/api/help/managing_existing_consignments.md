# Managing Existing Consignments

Once you've created your consignments, you'll probably want to keep an eye on them! This page explains how you can use PRO's APIs to retrieve consignment data and update or delete your consignments. 

---

## Getting Consignment Data

PRO offers several endpoints that return consignment data. Some of these endpoints return information on a specific consignment, while some are "search" endpoints that return the details of those consignments that meet a particular set of criteria.

### Getting Data For a Specific Consignment

Perhaps the most straightforward way of getting PRO consignment data is to use the **Get Consignment** endpoint. This endpoint takes the `consignmentReference` of the consignment you want to view as a path parameter, and returns full details for the specified consignment. The information returned is structured in a broadly similar way to a **Create Consignment** request, but can also (where applicable) include additional information, including:

* Information on the carrier service the consignment is allocated to
* Tracking references for each of the consignment's packages
* Information on the number of shipment legs required to deliver the consignment
* Label information, including whether labels have been printed yet and the date on which the labels were printed
* An `IsLate` flag indicating whether the consignment is late or not.

To call **Get Consignment**, sent a `GET` request to `https://api.electioapp.com/consignments/{consignmentReference}`.

**Example Get Consignment Response**

The example below shows a simple **Get Consignment** request for an unallocated consignment that contains just package and address details. For an example of a full **Get Consignment** request, see the [Get Consignment](https://docs.electioapp.com/#/api/GetConsignment) API reference.

<div class="tab">
    <button class="staticTabButton">Get Consignment Response Example</button>
    <div class="copybutton" onclick="CopyToClipboard('getConResponse')">Click to Copy</div>
</div>

<div id="getConResponse" class="staticTabContent" onclick="CopyToClipboard('getConResponse')">

```json
{
    "ConsignmentLegs": [],
    "CollectionDate": null,
    "DateDelivered": null,
    "FirstAttemptedDeliveryDate": null,
    "DateReturned": null,
    "DateShipped": null,
    "DateCollected": null,
    "AttemptedDeliveryDate": null,
    "MetaData": [],
    "Allocation": null,
    "FailedAllocation": null,
    "Source": "Api",
    "LabelCount": 0,
    "LabelsPrinted": false,
    "DateLabelsWereFirstPrinted": null,
    "IsLate": false,
    "LateForCustomer": false,
    "CustomerReference": "338a3524-5a17-44dd-a601-1527574f1a5d",
    "Weight": {
        "Value": 0.50000,
        "Unit": "Kg"
    },
    "Value": {
        "Amount": 5.99,
        "Currency": {
            "Name": "Pound Sterling",
            "IsoCode": "GBP"
        }
    },
    "CustomsDocumentation": null,
    "Direction": "Outbound",
    "Tags": [],
    "Reference": "EC-000-05C-ZB4",
    "ConsignmentState": "Unallocated",
    "DateCreated": "2020-02-10T11:21:07.8156519+00:00",
    "ShippingDate": null,
    "RequestedDeliveryDate": null,
    "EarliestDeliveryDate": null,
    "LatestDeliveryDate": null,
    "ConsignmentReferenceProvidedByCustomer": "",
    "Addresses": [
        {
            "AddressType": "Origin",
            "ShopLocationReference": null,
            "Contact": {
                "Reference": null,
                "Title": "Miss",
                "FirstName": "Laura",
                "LastName": "Somebody",
                "Position": null,
                "Telephone": "01234 567 890",
                "Mobile": "01234 567 890",
                "LandLine": "",
                "Email": "laura.somebody@mpd-group.com"
            },
            "CompanyName": null,
            "ShippingLocationReference": "EDC5_Electio",
            "CustomerName": null,
            "AddressLine1": "Third Floor",
            "AddressLine2": "Merchant Exchange",
            "AddressLine3": "Whitworth Street West",
            "Town": "Manchester",
            "Region": "",
            "Postcode": "M1 5WG",
            "Country": {
                "Name": "United Kingdom",
                "IsoCode": {
                    "TwoLetterCode": "GB"
                }
            },
            "RegionCode": "",
            "SpecialInstructions": "",
            "LatLong": null,
            "IsCached": false
        },
        {
            "AddressType": "Destination",
            "ShopLocationReference": null,
            "Contact": {
                "Reference": null,
                "Title": "Mr",
                "FirstName": "Peter",
                "LastName": "McPetersson",
                "Position": null,
                "Telephone": "07702123456",
                "Mobile": "07702123456",
                "LandLine": "0161544123",
                "Email": "peter.mcpetersson@test.com"
            },
            "CompanyName": null,
            "ShippingLocationReference": null,
            "CustomerName": null,
            "AddressLine1": "13 Porter Street",
            "AddressLine2": null,
            "AddressLine3": null,
            "Town": null,
            "Region": "Greater Manchester",
            "Postcode": "M1 5WG",
            "Country": {
                "Name": "United Kingdom",
                "IsoCode": {
                    "TwoLetterCode": "GB"
                }
            },
            "RegionCode": "",
            "SpecialInstructions": null,
            "LatLong": null,
            "IsCached": false
        }
    ],
    "Packages": [
        {
            "ConsignmentLegs": [],
            "Items": [],
            "Charges": [],
            "Reference": "EP-000-05E-YRQ",
            "PackageReferenceProvidedByCustomer": "",
            "Weight": {
                "Value": 0.50000,
                "Unit": "Kg"
            },
            "Dimensions": {
                "Unit": "Cm",
                "Width": 10.00000,
                "Length": 10.00000,
                "Height": 10.00000
            },
            "Description": "Socks",
            "Value": {
                "Amount": 5.9900,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "PackageSizeReference": null,
            "Barcode": null,
            "MetaData": []
        }
    ]
}
```
</div>

In addition to the **Get Consignment** endpoint, PRO also offers the **Get Consignment With Metadata** endpoint. This endpoint returns the same information as **Get Consignment**, but also includes the consignment's associated metadata. <span class="highlight">WHAT'S THE DEAL WITH THIS, AS FAR AS I CAN SEE BOTH OF THESE ENDPOINTS RETURN METADATA? NEED TO CHECK THIS OUT. SHOULD PROBABLY EXPAND THIS SECTION ONCE WE'VE WORKED OUT WHAT THE CRACK IS</span>

To call **Get Consignment With Metadata**, send a `GET` request to `https://api.electioapp.com/consignments/getconsignmentwithmetadata/{consignmentReference}`.

### Checking a Consignment's Status

If you only need to check a consignment's status, you could use the **Get Consignment Status** endpoint instead of **Get Consignment**. **Get Consignment Status** takes a `consignmentReference` as a path parameter, and returns only the consignment's current status and expected delivery date. Although **Get Consignment** returns both status and delivery date, it also returns a great deal of other information, which may not be useful if you simply want to check a consignment's progress.

To make a **Get Consignment Status** request, send a `GET` request to `https://api.electioapp.com/consignments/{consignmentReference}/status`.

<div class="tab">
    <button class="staticTabButton">Get Consignment Status Response Example</button>
    <div class="copybutton" onclick="CopyToClipboard('getConStatResponse')">Click to Copy</div>
</div>

<div id="getConStatResponse" class="staticTabContent" onclick="CopyToClipboard('getConStatResponse')">

```json

{
  "ConsignmentReferenceForAllLegsAssignedByMpd": "EC-000-087-01A",
  "Status": "Allocated",
  "ExpectedDeliveryDate": "2020-06-02T14:20:11.4370803+01:00",
  "ApiLink": {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-087-01A"
  }
}

```
</div>

### Searching For Consignments

As well as endpoints that return data based on a `consignmentReference`, PRO also enables you to search for consignments that meet a particular set of criteria. PRO has two search endpoints, **Get Consignments References** and **Search Consignments**. 

Both of these endpoints enable you to specify consignment parameters in your request, and return any consignments that meet those parameters. The difference between the two lies in what is returned: **Get Consignments References** returns only the `consignmentReference`s of any consignments that meet the criteria, while **Search Consignments** returns a summary of each matching consignment. **Search Consignments** also includes a paging feature that enables you to specify how many results you want PRO to return, and to skip over a specified number of results.

To call **Get Consignments References**, send a `GET` request to `https://api.electioapp.com/consignments/getConsignmentReferences?{property}={value}`, where `{property}` is the name of the consignment property you want to search on and `{value}` is its associated value. You can separate additional properties using the `&` operator. PRO then returns the `consignmentReferences` of any consignments that meet all the criteria that you specify.

**Get Consignments References Example**

The example below shows a request for all inbound consignments in an _Allocated_ state. PRO has returned two consignments.

<div class="tab">
    <button class="staticTabButton">Get Consignments References Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard('getConRefsRequest')">Click to Copy</div>
</div>

<div id="getConRefsRequest" class="staticTabContent" onclick="CopyToClipboard('getConRefsRequest')">

```

https://api.electioapp.com/consignments/getConsignmentReferences?State=Allocated&Direction=Inbound

```
</div>

<div class="tab">
    <button class="staticTabButton">Get Consignments References Response Example</button>
    <div class="copybutton" onclick="CopyToClipboard('getConRefsResponse')">Click to Copy</div>
</div>

<div id="getConRefsResponse" class="staticTabContent" onclick="CopyToClipboard('getConRefsResponse')">

```json

[
    "EC-000-05C-VQ4",
    "EC-000-05C-VQ3"
]

```
</div>

Search Consignments

## Updating Consignments

Update Consignment

Add Package

Delete Package

## Cancelling Consignments

Cancel Consignment

Cancel Consignments




<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>