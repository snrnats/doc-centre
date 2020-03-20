# Getting Quotes

This page explains how got get delivery quotes based on consignment details.

---

## Sending a Get Quotes Request

The **Get Quotes** endpoint enables you to get quotes based on the details of an as-yet nonexistent consignment. 

To call **Get Quotes**, send a `POST` request to `https://api.electioapp.com/quotes/`. The body of the request should contain a consignment object.

As a minimum, the **Get Quotes** endpoint requires you to send package weights and dimensions, origin address, and destination address data. You can either specify package weights and dimension via the `Weight` and `Dimensions` properties, or by supplying a `PackageSizeReference`. 

> <span class="note-header">Note:</span>
>  A <code>PackageSizeReference</code> is a unique identifier for a pre-defined, standardised package size. 
>
> To configure standard package sizes, use the <strong><a href="https://www.electioapp.com/Configuration/packagingsizes">Configuration > Packaging Sizes</a></strong> page of the PRO UI. You can also view a list of your available standard package sizes by making a call to the <a href="https://docs.electioapp.com/#/api/GetPackageSizes">Get Package Sizes</a> API.

Either the consignment's `destination` address, its `origin` address (if it has one), or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

There are lots of optional properties you can send when getting quotes for a consignment, including:

* Your own consignment reference.
* Details of the specific items inside the consignment's packages.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to us custom fields to record additional data about a consignment. For more information on using metadata in PRO, see <span class="highlight">[LINK HERE]</span>.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see <span class="highlight">[LINK HERE]</span>.

Adding optional properties can help to improve the relevance and accuracy of the quote results that you get back from PRO.

## The Get Quotes Response

Once it has received the request, PRO returns a quote result. The quote result object includes two lists: one containing `Quotes` and one containing `UnqualifiedServices` (that is, eligible services for which it was not possible to obtain a delivery quote). 

Each `Quote` object contains the following information:

* A unique reference for the quote. This value is important, as it is used when allocating consignments to the quote via the **Allocate With Quote** endpoint.
* Creation and expiry dates
* The name and reference of the relevant carrier and carrier service
* Origin and destination addresses
* Collection date, and a delivery date range
* Pricing information
* Details on each leg of the journey (where applicable)
* The service direction

At this point, you would be able to display the relevant quote information to your customer service operative.

> <span class="note-header">Note:</span>
>
> For full reference information on the **Get Quotes** endpoint, see the [API Reference](https://docs.electioapp.com/#/api/GetQuotes).

## Example Get Quotes Call

The example below shows a **Get Quotes** call for a fairly simple consignment.

<div class="tab">
    <button class="staticTabButton">Get Quote Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'quoteRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="quoteRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'quoteRequest')">

```json
{
  "Packages": [
    {
      "Weight": {
        "Value": 0.5,
        "Unit": "Kg"
      },
      "Dimensions": {
        "Unit": "Cm",
        "Width": 10.0,
        "Length": 10.0,
        "Height": 10.0
      },
      "Description": "Socks",
      "Value": {
        "Amount": 5.99,
        "Currency": {
          "IsoCode": "GBP"
        }
      }
    }  
  ],
  "Addresses": [
    {
      "AddressType": "Origin",
      "ShippingLocationReference": "Sorted1",
      "IsCached": false
    },
    {
      "AddressType": "Destination",
      "Contact": {
        "Title": "Mr",
        "FirstName": "Peter",
        "LastName": "McPetersson",
        "Telephone": "07702123456",
        "Mobile": "07702123456",
        "LandLine": "0161544123",
        "Email": "peter.mcpetersson@test.com"
      },
      "AddressLine1": "13 Porter Street",
      "Region": "Greater Manchester",
      "Postcode": "M1 5WG",
      "Country": {
        "Name": "Great Britain",
        "IsoCode": {
          "TwoLetterCode": "GB"
        }
      },
      "IsCached": false
    }
  ]
}
```

</div>

PRO has responded with one quote and two unavailable services.

<div class="tab">
    <button class="staticTabButton">Get Quote Response Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'quoteResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="quoteResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'quoteResponse')">

```json
{
    "QuoteRequestReference": "e2d05715-bb82-4659-a970-ab8400f35eef",
    "Quotes": [
        {
            "MpdCarrierServiceSource": 2,
            "MpdCarrierService": "Tracked 48 ",
            "CarrierReference": "RoyalMail",
            "OriginAddress": {
                "Contact": null,
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
            "DestinationAddress": {
                "Contact": null,
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
            },
            "CollectionDate": "2020-03-21T00:00:00+00:00",
            "EarliestDeliveryDate": "2020-03-24T00:00:00+00:00",
            "LatestDeliveryDate": "2020-03-24T23:59:00+00:00",
            "BasePrice": {
                "Net": 27.69,
                "Gross": 33.23,
                "TaxRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2000
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
                "TaxRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2000
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
                        "Reference": "RMDTPS48HNAUT",
                        "Name": "Tracked 48 ",
                        "CarrierReference": "ROYAL_MAIL",
                        "CarrierName": null,
                        "ExternalReference": null,
                        "IsDropOff": false,
                        "IsPickUp": false,
                        "IsTimed": false,
                        "IsTracked": true,
                        "IsSigned": false,
                        "ServiceDirection": "Inbound, Outbound"
                    },
                    "CarrierAccountReference": "RM1",
                    "DeliveryHub": null,
                    "CostItems": null,
                    "VolumetricParcelWeight": null,
                    "CollectionType": "NotApplicable",
                    "Metadata": []
                }
            ],
            "CarrierAccountOwner": null,
            "IsElectioService": false,
            "ServiceDirection": "Inbound, Outbound",
            "QuoteReference": "49a01165-e512-4287-9a6a-ab8400f3600b",
            "CreationDate": "2020-03-20T14:46:06.113622+00:00",
            "ExpiryDate": "2020-03-21T00:00:00+00:00",
            "Requestor": "Andy Walton",
            "ConsignmentReference": "",
            "ConsignmentReferenceProvidedByCustomer": "",
            "MpdCarrierServiceReference": "MPD_RMDTPS48HNAUT"
        }
    ],
    "Message": null,
    "UnqualifiedServices": [
        {
            "Available": false,
            "Rates": true,
            "MpdCarrierService": "UPS EXPRESS (Delivery Confirmation Signature Required)",
            "CarrierReference": "UPS",
            "MpdCarrierServiceReference": "EDC5_UPSHEXDCS",
            "ExclusionReason": "Service availability data not configured"
        },
        {
            "Available": false,
            "Rates": true,
            "MpdCarrierService": "UPS EXPRESS (Saturday Delivery, Delivery Confirmation Signature Required)",
            "CarrierReference": "UPS",
            "MpdCarrierServiceReference": "EDC5_UPSHEXSDDCS",
            "ExclusionReason": "Service availability data not configured"
        }
    ]
}
```

</div>

## Next Steps

* Learn how to get quotes using a consignment reference at the [Getting Quotes For An Existing Consignment](/pro/api/help/getting_quotes_for_an_existing_consignment.html) page.
* Learn how to get quotes from a carrier service group at the [Getting Quotes For A Service Group](/pro/api/help/getting_quotes_for_a_service_group.html) page.
* Learn how to allocate consignments to your chosen quote at the [Allocating To A Specific Quote](/pro/api/help/allocating_to_a_specific_quote.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>