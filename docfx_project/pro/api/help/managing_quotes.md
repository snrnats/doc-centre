# Managing Quotes

SortedPRO's Quotes API enables you to get delivery quotes for a consignment manually. This page explains the various ways in which you can get delivery quotes for a consignment, and how to generate and allocate consignments from a selected quote.

---

## What Is A Quote In PRO?

In PRO, a 

## Getting Quotes

Get Quotes

## Getting Quotes For An Existing Consignment

Get Quotes by Consignment Reference

<div class="tab">
    <button class="staticTabButton">Get Quotes by Consignment Reference Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'quoteConRefEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="quoteConRefEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'quoteConRefEndpoint')">

```
GET https://api.electioapp.com/quotes/consignment/{consignmentReference}
```

</div>  

Once you've created your consignment, you'll need to use the **[Get Quotes by Consignment Reference](https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference)** endpoint to get some delivery quotes for it.

**Get Quotes by Consignment Reference** returns quotes based on the details of an existing consignment. Specifically, it takes a `{consignmentReference}` as a path parameter and returns an array of `{Quotes}` for that consignment, as well as a list of services that were unable to quote for the consignment. 

Each `{Quote}` object contains details on carrier service, dates, addresses, and price, amongst other information. Pay particular attention to the `{quoteReference}`, as you'll need this when you select a quote in the next step.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Get Quotes by Consignment Reference</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference">Get Quotes by Consignment Reference</a></strong> page of the API reference.

### Get Quotes By Consignment Reference Example

The example shows a **Get Quotes by Consignment Reference** request and its accompanying response. In this case, SortedPRO has returned two quotes for the service. The next step in the process is to select one of those quotes.

<div class="tab">
    <button class="staticTabButton">Example Get Quotes by Consignment Reference Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'quoteConRefRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="quoteConRefRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'quoteConRefRequest')">

```
https://api.electioapp.com/quotes/consignment/EC-000-05B-1CM
```

</div>  

<div class="tab">
    <button class="staticTabButton">Example Get Quotes by Consignment Reference Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'quoteConRefResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="quoteConRefResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'quoteConRefResponse')">

```json
{
    "QuoteRequestReference": "6f9c7ee5-a97e-4df9-bc07-aa3f00e99316",
    "Quotes": [
        {
            "MpdCarrierServiceSource": 2,
            "MpdCarrierService": "1st and 2nd Class Account Mail (1st Parcel)",
            "OriginAddress": {
                "ShippingLocationReference": "EDC5_Electio",
                "AddressLine1": "Third Floor",
                "AddressLine2": "Merchant Exchange",
                "AddressLine3": "Whitworth Street West",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "SpecialInstructions": "",
                "IsCached": false
            },
            "DestinationAddress": {
                "AddressLine1": "13 Porter Street",
                "AddressLine2": "Pressington",
                "AddressLine3": "Carlsby",
                "Town": "Manchester",
                "Region": "Greater Manchester",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "SpecialInstructions": "Gate code: 4454",
                "IsCached": false
            },
            "CollectionDate": "2019-05-01T00:00:00",
            "EarliestDeliveryDate": "2019-05-02T00:00:00",
            "LatestDeliveryDate": "2019-05-02T23:59:00",
            "BasePrice": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2
                },
                "VatAmount": 5.54,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2
                },
                "VatAmount": 5.54,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "Surcharges": [],
            "Legs": [
                {
                    "JourneyStage": 1,
                    "CarrierService": {
                        "Reference": "RMDBPR1STPSU",
                        "Name": "1st and 2nd Class Account Mail (1st Parcel)",
                        "CarrierReference": "ROYAL_MAIL",
                        "CarrierName": null,
                        "IsDropOff": false,
                        "IsPickUp": false,
                        "IsTimed": false
                    },
                    "CarrierAccountReference": "RM1",
                    "DeliveryHub": null,
                    "CostItems": null,
                    "VolumetricParcelWeight": null,
                    "CollectionType": "NotApplicable"
                }
            ],
            "CarrierAccountOwner": null,
            "IsElectioService": false,
            "QuoteReference": "f6374a18-a6b5-48c1-841c-aa3f00e9951a",
            "CreationDate": "2019-04-30T14:10:26.8551633+00:00",
            "ExpiryDate": "2019-05-01T00:00:00+01:00",
            "Requestor": "Andy Walton",
            "ConsignmentReference": "EC-000-05B-1CM",
            "ConsignmentReferenceProvidedByCustomer": "",
            "MpdCarrierServiceReference": "MPD_RMDBPR1STPSU"
        },
        {
            "MpdCarrierServiceSource": 2,
            "MpdCarrierService": "Tracked 48 Signed For",
            "OriginAddress": {
                "ShippingLocationReference": "EDC5_Electio",
                "AddressLine1": "Third Floor",
                "AddressLine2": "Merchant Exchange",
                "AddressLine3": "Whitworth Street West",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "SpecialInstructions": "",
                "IsCached": false
            },
            "DestinationAddress": {
                "AddressLine1": "13 Porter Street",
                "AddressLine2": "Pressington",
                "AddressLine3": "Carlsby",
                "Town": "Manchester",
                "Region": "Greater Manchester",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "SpecialInstructions": "Gate code: 4454",
                "IsCached": false
            },
            "CollectionDate": "2019-05-01T00:00:00",
            "EarliestDeliveryDate": "2019-05-03T00:00:00",
            "LatestDeliveryDate": "2019-05-03T23:59:00",
            "BasePrice": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2
                },
                "VatAmount": 5.54,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2
                },
                "VatAmount": 5.54,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "Surcharges": [],
            "Legs": [
                {
                    "JourneyStage": 1,
                    "CarrierService": {
                        "Reference": "RMDTPS48HNAST",
                        "Name": "Tracked 48 Signed For",
                        "CarrierReference": "ROYAL_MAIL",
                        "CarrierName": null,
                        "IsDropOff": false,
                        "IsPickUp": false,
                        "IsTimed": false
                    },
                    "CarrierAccountReference": "RM1",
                    "DeliveryHub": null,
                    "CostItems": null,
                    "VolumetricParcelWeight": null,
                    "CollectionType": "NotApplicable"
                }
            ],
            "CarrierAccountOwner": null,
            "IsElectioService": false,
            "QuoteReference": "f63bd4ab-d519-4547-b361-aa3f00e9951a",
            "CreationDate": "2019-04-30T14:10:26.8551633+00:00",
            "ExpiryDate": "2019-05-01T00:00:00+01:00",
            "Requestor": "Andy Walton",
            "ConsignmentReference": "EC-000-05B-1CM",
            "ConsignmentReferenceProvidedByCustomer": "",
            "MpdCarrierServiceReference": "MPD_RMDTPS48HNAST"
        }
    ],
    "Message": null,
    "UnqualifiedServices": [
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "acceptanceTestCarrier_825d",
            "MpdCarrierServiceReference": "acceptanceTestCarrier_f8fe",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": false,
            "Rates": false,
            "MpdCarrierService": "Express With Signature Parcel",
            "MpdCarrierServiceReference": "MPD_ANPOS-00001",
            "ExclusionReason": "This service is not available for the selected collection/delivery dates."
        },
        {
            "Available": false,
            "Rates": true,
            "MpdCarrierService": "Next Day Monday - Saturday",
            "MpdCarrierServiceReference": "MPD_MNZIS-00001",
            "ExclusionReason": "This service is not available between the selected addresses."
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS EXPRESS (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHEXDCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS EXPRESS (Saturday Delivery, Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHEXSDDCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS EXPRESS PLUS (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHEP",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS SAVER (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHSADCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS STANDARD (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHSTDCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": false,
            "Rates": false,
            "MpdCarrierService": "wnDirect International Economy",
            "MpdCarrierServiceReference": "MPD_WNDECOM",
            "ExclusionReason": "This service is not available between the selected addresses. This service is not available for the given package dimensions/weight."
        }
    ]
}
```

</div> 

## Getting Quotes For A Service Group

Get Service Group Quotes

## Selecting a Quote

Allocate With Quote

## Next Steps



<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>