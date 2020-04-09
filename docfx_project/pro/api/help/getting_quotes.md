# Getting Quotes

This page explains how got get delivery quotes based on consignment details.

---

## Overview

PRO has two endpoints that take the details of an as-yet uncreated consignment and return quotes for it:

* **Get Quotes** returns a simple list of delivery quotes for the potential consignment.
* **Get Service Group Quotes** returns a list of current service groups, along with quotes from the eligible services in each group.

> <span class="note-header">Note:</span>
>
> Both the **Get Quotes** and **Get Service Group Quotes** endpoints take a consignment object in the body of the request. However, they do not create consignments in and of themselves. In order to allocate to one of the quotes returned by these endpoints, you would need to first create the consignment. 
>
> For more information on creating consignments, see the [Creating Consignments](/pro/api/help/creating_new_consignments.html) page.

## Sending a Get Quotes Request

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

### The Get Quotes Response

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

### Example Get Quotes Call

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

## Getting Service Group Quotes

To call **Get Service Group Quotes**, send a `POST` request to `https://api.electioapp.com/quotes/serviceGroups`. The body of the request should contain a consignment object, structured in the same way as the **Get Quotes** request detailed above.

Once it has received the request, PRO returns a list of available service groups, identified by `Name` and `Reference`. Each service group contains a `CheapestQuote` detailing the cheapest service in that group. The service group object also contains a list of `Quotes` for the services in the group (including the service detailed in the `CheapestQuote` property) and a list of `UnqualifiedServices` (that is, eligible services within the group for which it was not possible to obtain a delivery quote).

> <span class="note-header">Note:</span>
>
> For full reference information on the **Get Service Group Quotes** endpoint, see the [API Reference](https://docs.electioapp.com/#/api/GetServiceGroupQuotes).

### Get Service Group Quotes Example

This simplified example shows a **Get Service Group Quotes** request for an outbound consignment. In this case, there is one service group configured in PRO, with the name _Example Service Group_. The group contains two services, with the service references <em>SAMPLE_SERVICE01</em> and <em>SAMPLE_SERVICE02</em>.

<div class="tab">
    <button class="staticTabButton">Get Service Group Quotes Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'SGQuoteRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="SGQuoteRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'SGQuoteRequest')">

```json
{
  "MetaData": [
    {
      "KeyValue": "IsExample",
      "BoolValue": true
    }
  ],
  "Source": "API",
  "Weight": {
    "Value": 0.5,
    "Unit": "Kg"
  },
  "Value": {
    "Amount": 5.99,
    "Currency": {
      "IsoCode": "GBP"
    }
  },
  "CustomsDocumentation": {
    "DesignatedPersonResponsible": "Peter McPetersson",
    "ImportersVatNumber": "02345555",
    "CategoryType": "Other",
    "ShipperCustomsReference": "CREF0001",
    "ImportersTaxCode": "TC001",
    "ImportersTelephone": "0161123456",
    "ImportersFax": "01611124547",
    "ImportersEmail": "peter.mcpetersson@test.com",
    "CN23Comments": "Comments",
    "ReferencesOfAttachedInvoices": [
      "INV001"
    ],
    "ReferencesOfAttachedCertificates": [
      "CERT001"
    ],
    "ReferencesOfAttachedLicences": [
      "LIC001"
    ],
    "CategoryTypeExplanation": "Explanation",
    "DeclarationDate": "2020-02-11T00:00:00+00:00",
    "OfficeOfPosting": "Manchester",
    "ReasonForExport": "Sale",
    "ShippingTerms": "CFR",
    "ShippersVatNumber": "874541414",
    "ReceiversTaxCode": "TC5454",
    "ReceiversVatNumber": "8745474",
    "InvoiceDate": "2020-02-11T00:00:00+00:00"
  },
  "Direction": "Outbound",
  "ShippingDate": "2020-02-11T00:00:00+00:00",
  "RequestedDeliveryDate": {
    "Date": "2020-02-13T00:00:00+00:00",
    "IsToBeExactlyOnTheDateSpecified": false
  },
  "ConsignmentReferenceProvidedByCustomer": "Your custom reference",
  "Addresses": [
    {
      "AddressType": "Origin",
      "ShippingLocationReference": "Shipping_Location_Reference",
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
      "CompanyName": "Test Company (UK) Ltd.",
      "AddressLine1": "13 Porter Street",
      "AddressLine2": "Pressington",
      "AddressLine3": "Carlsby",
      "Town": "Manchester",
      "Region": "Greater Manchester",
      "Postcode": "M1 5WG",
      "Country": {
        "Name": "Great Britain",
        "IsoCode": {
          "TwoLetterCode": "GB"
        }
      },
      "SpecialInstructions": "Gate code: 4454",
      "LatLong": {
        "Latitude": 53.474220,
        "Longitude": -2.246049
      },
      "IsCached": false
    }
  ],
  "Packages": [
    {
      "Items": [
        {
          "Sku": "SKU093434",
          "Model": "ITM-002",
          "Description": "Striped Bamboo Red/White",
          "CountryOfOrigin": {
            "IsoCode": {
              "TwoLetterCode": "GB"
            }
          },
          "HarmonisationCode": "Harmonisation_Code",
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
          "Value": {
            "Amount": 5.99,
            "Currency": {
              "IsoCode": "GBP"
            }
          },
          "ItemReferenceProvidedByCustomer": "ITEMREF-098",
          "Barcode": {
            "Code": "09887-091221",
            "BarcodeType": "Code39"
          },
          "MetaData": [
            {
              "KeyValue": "Picker",
              "StringValue": "David Thomas"
            }
          ],
          "Quantity": 1,
          "Unit": "Box",
          "HarmonisationKeyWords": [
            "Keyword1"
          ],
          "ContentClassification": "Unrestricted",
          "ContentClassificationDetails": "NotSpecified"
        }
      ],
      "PackageReferenceProvidedByCustomer": "MYPACK-00923",
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
      },
      "Barcode": {
        "Code": "09887-091221",
        "BarcodeType": "Code39"
      },
      "MetaData": [
        {
          "KeyValue": "WMS-REF",
          "IntValue": 77656555
        }
      ]
    },
    {
      "Items": [
        {
          "Sku": "SKU093434",
          "Model": "ITM-002",
          "Description": "Striped Bamboo Red/White",
          "CountryOfOrigin": {
            "IsoCode": {
              "TwoLetterCode": "GB"
            }
          },
          "HarmonisationCode": "Harmonisation_Code",
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
          "Value": {
            "Amount": 5.99,
            "Currency": {
              "IsoCode": "GBP"
            }
          },
          "ItemReferenceProvidedByCustomer": "ITEMREF-098",
          "Barcode": {
            "Code": "09887-091221",
            "BarcodeType": "Code39"
          },
          "MetaData": [
            {
              "KeyValue": "Picker",
              "StringValue": "David Thomas"
            }
          ],
          "Quantity": 1,
          "Unit": "Box",
          "HarmonisationKeyWords": [
            "Keyword1"
          ],
          "ContentClassification": "Unrestricted",
          "ContentClassificationDetails": "NotSpecified"
        }
      ],
      "PackageReferenceProvidedByCustomer": "MYPACK-00923",
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
      },
      "Barcode": {
        "Code": "09887-091221",
        "BarcodeType": "Code39"
      },
      "MetaData": [
        {
          "KeyValue": "WMS-REF",
          "IntValue": 77656555
        }
      ]
    }
  ]
}
```

</div>

PRO returns a single service group object. In this case, <em>SAMPLE_SERVICE01</em> is the only eligible service, and so is displayed as both the `CheapestQuote` and the only entry in the `Quotes` array. <em>SAMPLE_SERVICE02</em> is returned in the list of unqualified services.

<div class="tab">
    <button class="staticTabButton">Get Service Group Quotes Response Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'SGQuoteResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="SGQuoteResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'SGQuoteResponse')">

```json
[
  {
    "Reference": "SGREF01",
    "Name": "Example Service Group",
    "CheapestQuote": {
      "MpdCarrierServiceSource": "External",
      "MpdCarrierService": "SAMPLE_SERVICE01",
      "CarrierReference": "SAMPLE_CARRIER_REFERENCE",
      "OriginAddress": {
        "ShippingLocationReference": "Shipping_Location_Reference",
        "IsCached": false
      },
      "DestinationAddress": {
        "Contact": {
          "Title": "Mr",
          "FirstName": "Peter",
          "LastName": "McPetersson",
          "Telephone": "07702123456",
          "Mobile": "07702123456",
          "LandLine": "0161544123",
          "Email": "peter.mcpetersson@test.com"
        },
        "CompanyName": "Test Company (UK) Ltd.",
        "AddressLine1": "13 Porter Street",
        "AddressLine2": "Pressington",
        "AddressLine3": "Carlsby",
        "Town": "Manchester",
        "Region": "Greater Manchester",
        "Postcode": "M1 5WG",
        "Country": {
          "Name": "Great Britain",
          "IsoCode": {
            "TwoLetterCode": "GB"
          }
        },
        "SpecialInstructions": "Gate code: 4454",
        "LatLong": {
          "Latitude": 53.474220,
          "Longitude": -2.246049
        },
        "CacheDate": "2020-02-11T11:08:09.8336643+00:00",
        "CacheSource": "",
        "IsCached": true
      },
      "CollectionDate": "2020-02-13T00:00:00+00:00",
      "EarliestDeliveryDate": "2020-02-18T00:00:00+00:00",
      "LatestDeliveryDate": "2020-02-19T00:00:00+00:00",
      "BasePrice": {
        "Net": 12.0,
        "Gross": 10.0,
        "TaxRate": {
          "Reference": "VAT_STANDARD",
          "CountryIsoCode": "GB",
          "Type": "Standard",
          "Rate": 0.2
        },
        "TaxAmount": 0.2,
        "Currency": {
          "IsoCode": "GBP"
        }
      },
      "Price": {
        "Net": 12.0,
        "Gross": 10.0,
        "TaxRate": {
          "Reference": "VAT_STANDARD",
          "CountryIsoCode": "GB",
          "Type": "Standard",
          "Rate": 0.2
        },
        "TaxAmount": 0.2,
        "Currency": {
          "IsoCode": "GBP"
        }
      },
      "Surcharges": [],
      "Legs": [],
      "CarrierAccountOwner": "Electio",
      "IsElectioService": true,
      "ServiceDirection": "Outbound",
      "QuoteReference": "5a182bf7-d17e-40f3-adb3-c7137c804f00",
      "CreationDate": "2020-02-11T11:08:09.8336643+00:00",
      "ExpiryDate": "2020-02-12T00:00:00+00:00",
      "Requestor": "Peter",
      "ConsignmentReference": "EC-000-02D-DA4",
      "ConsignmentReferenceProvidedByCustomer": "MY_REF",
      "MpdCarrierServiceReference": "SAMPLE_SERVICE01"
    },
    "QuoteRequestReference": "6ddf6170-816e-448b-83a5-9e787080bffb",
    "Quotes": [
      {
        "MpdCarrierServiceSource": "External",
        "MpdCarrierService": "SAMPLE_SERVICE01",
        "CarrierReference": "SAMPLE_CARRIER_REFERENCE",
        "OriginAddress": {
          "ShippingLocationReference": "Shipping_Location_Reference",
          "IsCached": false
        },
        "DestinationAddress": {
          "Contact": {
            "Title": "Mr",
            "FirstName": "Peter",
            "LastName": "McPetersson",
            "Telephone": "07702123456",
            "Mobile": "07702123456",
            "LandLine": "0161544123",
            "Email": "peter.mcpetersson@test.com"
          },
          "CompanyName": "Test Company (UK) Ltd.",
          "AddressLine1": "13 Porter Street",
          "AddressLine2": "Pressington",
          "AddressLine3": "Carlsby",
          "Town": "Manchester",
          "Region": "Greater Manchester",
          "Postcode": "M1 5WG",
          "Country": {
            "Name": "Great Britain",
            "IsoCode": {
              "TwoLetterCode": "GB"
            }
          },
          "SpecialInstructions": "Gate code: 4454",
          "LatLong": {
            "Latitude": 53.474220,
            "Longitude": -2.246049
          },
          "CacheDate": "2020-02-11T11:08:09.8336643+00:00",
          "CacheSource": "",
          "IsCached": true
        },
        "CollectionDate": "2020-02-13T00:00:00+00:00",
        "EarliestDeliveryDate": "2020-02-18T00:00:00+00:00",
        "LatestDeliveryDate": "2020-02-19T00:00:00+00:00",
        "BasePrice": {
          "Net": 12.0,
          "Gross": 10.0,
          "TaxRate": {
            "Reference": "VAT_STANDARD",
            "CountryIsoCode": "GB",
            "Type": "Standard",
            "Rate": 0.2
          },
          "TaxAmount": 0.2,
          "Currency": {
            "IsoCode": "GBP"
          }
        },
        "Price": {
          "Net": 12.0,
          "Gross": 10.0,
          "TaxRate": {
            "Reference": "VAT_STANDARD",
            "CountryIsoCode": "GB",
            "Type": "Standard",
            "Rate": 0.2
          },
          "TaxAmount": 0.2,
          "Currency": {
            "IsoCode": "GBP"
          }
        },
        "Surcharges": [],
        "Legs": [],
        "CarrierAccountOwner": "Electio",
        "IsElectioService": true,
        "ServiceDirection": "Outbound",
        "QuoteReference": "5a182bf7-d17e-40f3-adb3-c7137c804f00",
        "CreationDate": "2020-02-11T11:08:09.8336643+00:00",
        "ExpiryDate": "2020-02-12T00:00:00+00:00",
        "Requestor": "Peter",
        "ConsignmentReference": "EC-000-02D-DA4",
        "ConsignmentReferenceProvidedByCustomer": "MY_REF",
        "MpdCarrierServiceReference": "SAMPLE_SERVICE01"
      }
    ],
    "Message": "Quote created successfully",
    "UnqualifiedServices": [
      {
        "Available": false,
        "Rates": true,
        "MpdCarrierService": "SAMPLE_SERVICE02",
        "CarrierReference": "SAMPLE_CARRIER_REFERENCE",
        "MpdCarrierServiceReference": "SAMPLE_SERVICE02",
        "ExclusionReason": "The service is not available between selected addresses"
      }
    ]
  }
]
```

</div>


## Next Steps

* Learn how to get quotes using a consignment reference at the [Getting Quotes For An Existing Consignment](/pro/api/help/getting_quotes_for_an_existing_consignment.html) page.
* Learn how to create consignments at the [Creating Consignments](/pro/api/help/creating_consignments.html) page.
* Learn how to allocate consignments to your chosen quote at the [Allocating to a Specific Quote](/pro/api/help/allocating_to_a_specific_quote.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>