---
uid: pro-api-help-getting-consignment-data
title: Getting Consignment Data
tags: consignments,pro,api
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 08/06/2020
---
# Getting Consignment Data

PRO offers several endpoints that return consignment data. This page explains how to fetch data on an individual consignment, and how to search for consignments that meet a particular set of criteria.

---

## Getting Data For a Specific Consignment

Perhaps the most straightforward way of getting PRO consignment data is to use the **Get Consignment** endpoint. This endpoint takes the `consignmentReference` of the consignment you want to view as a path parameter, and returns full details for the specified consignment. The information returned is structured in a broadly similar way to a **Create Consignment** request, but can also (where applicable) include additional information, including:

* Information on the carrier service the consignment is allocated to
* Tracking references for each of the consignment's packages
* Information on the number of shipment legs required to deliver the consignment
* Label information, including whether labels have been printed yet and the date on which the labels were printed
* An `IsLate` flag indicating whether the consignment is late or not.

To call **Get Consignment**, send a `GET` request to `https://api.electioapp.com/consignments/{consignmentReference}`.

> [!NOTE]
>
> For full reference information on the **Get Consignment** endpoint, see the <a href="https://docs.electioapp.com/#/api/GetConsignment">API reference</a>.

### Example Get Consignment Call

The example below shows a simple **Get Consignment** request for an unallocated consignment containing just package and address details. For an example of a full **Get Consignment** request, see the [Get Consignment](https://docs.electioapp.com/#/api/GetConsignment) API reference.

# [Get Consignment Request](#tab/get-consignment-request)

`GET https://api.electioapp.com/consignments/EC-000-05C-ZB4`

# [Get Consignment Response](#tab/get-consignment-response)

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
            "ShippingLocationReference": "Sorted1",
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
---

### Checking a Consignment's Status

If you only need to check a consignment's status, you could use the **Get Consignment Status** endpoint instead of **Get Consignment**. **Get Consignment Status** takes a `consignmentReference` as a path parameter, and returns only the consignment's current status and expected delivery date. Although **Get Consignment** returns both status and delivery date, it also returns a great deal of other information, which may not be useful if you simply want to check a consignment's progress.

To make a **Get Consignment Status** request, send a `GET` request to `https://api.electioapp.com/consignments/{consignmentReference}/status`.

# [Get Consignment Status Request](#tab/get-consignment-status-request)

`GET https://api.electioapp.com/consignments/EC-000-087-01A/status`

# [Get Consignment Status Response](#tab/get-consignment-status-response)

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
---

## Searching For Consignments

As well as endpoints that return data based on a `consignmentReference`, PRO also enables you to search for consignments that meet a particular set of criteria. PRO has two search endpoints: **Get Consignments References** and **Search Consignments**. Both of these endpoints enable you to specify consignment parameters in your request, and return any consignments that meet those parameters. 

The two search endpoints differ in their responses: **Get Consignments References** returns only the `consignmentReference`s of any consignments that meet the criteria, while **Search Consignments** returns a summary of each matching consignment. **Search Consignments** also includes a paging feature that enables you to specify how many results you want PRO to return, and to skip over a specified number of results. 

### Using Get Consignments References

To call **Get Consignments References**, send a `GET` request to `https://api.electioapp.com/consignments/getConsignmentReferences?{property}={value}`, where `{property}` is the name of the consignment property you want to search on and `{value}` is its associated value. You can separate additional properties using the `&` operator. PRO then returns the `consignmentReferences` of any consignments that meet all the criteria that you specify.

> [!NOTE]
>
> For a full list of search properties accepted by the **Get Consignments References** endpoint, see the <a href="https://docs.electioapp.com/#/api/GetConsignmentsReferences">API reference</a>

### Get Consignments References Example

The example below shows a request for all inbound consignments in an _Allocated_ state. PRO has returned two consignments.

# [Get Consignments References Request](#tab/get-consignments-status-request)

`https://api.electioapp.com/consignments/getConsignmentReferences?State=Allocated&Direction=Inbound`

# [Get Consignments References Response](#tab/get-consignments-status-response)

```json

[
    "EC-000-05C-VQ4",
    "EC-000-05C-VQ3"
]

```
---

### Using Search Consignments

To call **Search Consignments**, send a `GET` request to `https://api.electioapp.com/consignments/{take}/{skip}?{property}={value}`, where:

* `{take}` is the maximum number of results you want the endpoint to return
* `{skip}` is the number of results in the list that you want to skip
* `{property}` is the name of the consignment property you want to search on  
* `{value}` is the property value you want to search on.

As with the **Get Consignments References** API, you can add additional search properties and values, as long as each property/value pair is separated by an `&` operator.


> [!NOTE]
>
> The `{take}` and `{skip}` values can be used to drive paging functions in systems that present a list of consignments to the user. For example, suppose that you have 100 active consignments in an _Allocated_  state. A call to `GET https://api.electioapp.com/consignments/100/0?&State=Allocated` would return all of those consignments, as a `{take}` value of _100_ and a `{skip}` value of _0_ means that the API will return up to 100 results without skipping over any.
>
> However, suppose that you want to split the list up into two groups of 50 (for example, because you are using the data to populate a list in a system whose UI only enables you to display 50 results at any one time). In this case, you would populate the first page of results with a call to `GET https://api.electioapp.com/consignments/50/0?&State=Allocated` (max. 50 results, none skipped). If the user elects to view the second page, you would call `GET https://api.electioapp.com/consignments/50/50?&State=Allocated`. The API would again return 50 results, but would skip over the first 50 in the list (i.e. those results that were displayed on the first page) and instead return results 51-100. 

The **Search Consignments** endpoint returns a summary of each consignment that meets the request criteria. The summary object contains the following:

* The carrier service that the consignment is allocated to (where applicable) and its date of allocation
* Address information
* Requested and estimated delivery dates, and a flag indicating whether the shipment is late
* The consignment's label status (i.e. whether labels have been printed and on what date)
* The consignment reference
* The customer's reference for the consignment (where applicable)
* Creation and shipping dates
* The consignment's value and weight

> [!NOTE]
>
> For full reference information on the **Search Consignments** endpoint, see the <a href="https://docs.electioapp.com/#/api/SearchConsignments">API reference</a>. 

### Search Consignments Example

The example below shows a request for all inbound consignments in an _Allocated_ state, with a potential maximum of 100 results returned and none skipped. PRO has returned a summary of two consignments.

# [Search Consignments Request](#tab/search-consignments-request)

`https://apis.electioapp.com/consignments/100/0/?State=Allocated&Direction=Inbound`

# [Search Consignments Response](#tab/search-consignments-response)

```json

{
    "Count": 2,
    "ConsignmentSummaries": [
        {
            "Source": "Api",
            "MpdCarrierServiceName": "Tracked 48 ",
            "MpdCarrierServiceGroupName": null,
            "MpdCarrierServiceGroupReference": "",
            "DestinationAddressLine1": "1 Electio Way",
            "DestinationAddressTown": "Manchester",
            "DestinationAddressPostcode": "M1 5WG",
            "DestinationAddressCountry": "GB",
            "DestinationShippingLocationReference": "EDC5_UKMAIL",
            "RequestedDeliveryDate": "2020-02-01T00:00:00+00:00",
            "RequestedDeliveryDateIsToBeExactlyOnTheDateSpecified": true,
            "LabelsPrinted": false,
            "DateLabelsWereFirstPrinted": null,
            "EstimatedDeliveryDate": "2020-02-01T00:00:00+00:00",
            "ShippingTerms": null,
            "FailedAllocationAttemptedAllocationDate": null,
            "FailedAllocationMessage": "Could not be booked with courier.",
            "FailedAllocationMpdCarrierServiceReference": null,
            "FailedAllocationMpdCarrierServiceGroupName": null,
            "FailedAllocationMpdCarrierServiceGroupReference": null,
            "FailedAllocationMpdCarrierServiceName": null,
            "IsLate": true,
            "DeliveryDate": "2020-02-01T23:59:00+00:00",
            "CollectionDate": null,
            "AttemptedDeliveryDate": null,
            "Value": {
                "Amount": 3.0000,
                "Currency": {
                    "Name": null,
                    "IsoCode": "GBP"
                }
            },
            "Weight": {
                "Value": 1.00000,
                "Unit": "Kg"
            },
            "ApiLink": {
                "Rel": "detail",
                "Href": "https://api.electioapp.com/consignments/EC-000-05C-VQ4"
            },
            "FailedManifestMessage": null,
            "FailedManifestTimeStamp": null,
            "Reference": "EC-000-05C-VQ4",
            "ConsignmentReferenceProvidedByCustomer": "HermesReturn",
            "DateCreated": "2020-01-29T11:42:15.2739889+00:00",
            "State": "Allocated",
            "ShippingDate": "2020-01-30T00:00:00+00:00",
            "MpdCarrierReference": null,
            "MpdCarrierServiceReference": "MPD_RMDTPS48HNAUT",
            "AllocationDate": "2020-01-29T11:42:19.3156347+00:00",
            "ShippedDate": null
        },
        {
            "Source": "Api",
            "MpdCarrierServiceName": "Tracked 48 ",
            "MpdCarrierServiceGroupName": null,
            "MpdCarrierServiceGroupReference": "",
            "DestinationAddressLine1": "1 Electio Way",
            "DestinationAddressTown": "Manchester",
            "DestinationAddressPostcode": "M1 5WG",
            "DestinationAddressCountry": "GB",
            "DestinationShippingLocationReference": "EDC5_UKMAIL",
            "RequestedDeliveryDate": "2020-02-01T00:00:00+00:00",
            "RequestedDeliveryDateIsToBeExactlyOnTheDateSpecified": true,
            "LabelsPrinted": true,
            "DateLabelsWereFirstPrinted": "2020-01-29T11:40:32.8733333+00:00",
            "EstimatedDeliveryDate": "2020-02-01T00:00:00+00:00",
            "ShippingTerms": null,
            "FailedAllocationAttemptedAllocationDate": null,
            "FailedAllocationMessage": "Could not be booked with courier.",
            "FailedAllocationMpdCarrierServiceReference": null,
            "FailedAllocationMpdCarrierServiceGroupName": null,
            "FailedAllocationMpdCarrierServiceGroupReference": null,
            "FailedAllocationMpdCarrierServiceName": null,
            "IsLate": true,
            "DeliveryDate": "2020-02-01T23:59:00+00:00",
            "CollectionDate": null,
            "AttemptedDeliveryDate": null,
            "Value": {
                "Amount": 3.0000,
                "Currency": {
                    "Name": null,
                    "IsoCode": "GBP"
                }
            },
            "Weight": {
                "Value": 1.00000,
                "Unit": "Kg"
            },
            "ApiLink": {
                "Rel": "detail",
                "Href": "https://api.electioapp.com/consignments/EC-000-05C-VQ3"
            },
            "FailedManifestMessage": null,
            "FailedManifestTimeStamp": null,
            "Reference": "EC-000-05C-VQ3",
            "ConsignmentReferenceProvidedByCustomer": "Test001",
            "DateCreated": "2020-01-29T11:40:22.6011283+00:00",
            "State": "Allocated",
            "ShippingDate": "2020-01-30T00:00:00+00:00",
            "MpdCarrierReference": null,
            "MpdCarrierServiceReference": "MPD_RMDTPS48HNAUT",
            "AllocationDate": "2020-01-29T11:40:27.4840935+00:00",
            "ShippedDate": null
        }
    ]
}

```
---

## Next Steps

* Learn how to allocate consignments at the [Allocating Consignments to Carriers](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>