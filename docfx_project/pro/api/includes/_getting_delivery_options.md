# [Delivery Options Endpoint](#tab/delivery-options-endpoint)

```json
POST https://api.electioapp.com/deliveryoptions
```
---

In the context of SortedPRO, a "delivery option" is a combination of a delivery date, a start time and an end time. These details form a delivery promise for a consignment. PRO then recommends a carrier service that can meet the delivery promise, the delivery cost, and the required shipping date, completing the data for each delivery option.

The **[Delivery Options](https://docs.electioapp.com/#/api/DeliveryOptions)** endpoint takes the details of the (as yet uncreated) consignment. As a minimum, PRO requires you to send package, origin address and destination address data in order to return delivery options. 

The endpoint returns an array of `{DeliveryOptions}` objects. Each `{DeliveryOptions}` object contains details of a delivery option that can be used to take a consignment with the details you passed in the request. PRO always returns the cheapest carrier service for each delivery promise, unless using the cheapest service would conflict with existing business rules.

If you do not provide a `DeliveryDate` in the request, then PRO returns delivery options for a maximum of fourteen days from the current date. If you provide a `DeliveryDate`, then PRO provides options up to and including the supplied date.

The delivery options available for a given consignment can change over time. This is primarily due to differing carrier collection times at each shipping location.

> [!NOTE]
> * For full reference information on the <strong>Delivery Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/DeliveryOptions">Delivery Options</a></strong> page of the API reference.
> * For a user guide on PRO delivery options, see the [Using Delivery and Pickup Options](/pro/api/help/using_delivery_and_pickup_options.html) section.

### Get Delivery Options Example

The example shows a request to get delivery options for a fairly standard consignment. The API has returned two delivery options, both for Carrier X: one with an `{estimatedDeliveryDate}` of _2019-06-19_ and one with an `{estimatedDeliveryDate}` of _2019-06-20_.

# [Delivery Options Request](#tab/delivery-options-request)

`POST https://api.electioapp.com/deliveryoptions`

```json
{  
  "ConsignmentReferenceProvidedByCustomer": "Your Reference",
  "DeliveryDate": "2019-06-19T00:00:00+00:00",
  "GuaranteedOnly": false,
  "ShippingDate": "2019-06-17T00:00:00+00:00",
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
    }
  ],
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
    "DeclarationDate": "2019-06-14T00:00:00+00:00",
    "OfficeOfPosting": "Manchester",
    "ReasonForExport": "Sale",
    "ShippingTerms": "CFR",
    "ShippersVatNumber": "874541414",
    "ReceiversTaxCode": "TC5454",
    "ReceiversVatNumber": "8745474",
    "InvoiceDate": "2019-06-14T00:00:00+00:00"
  },
  "Addresses": [
    {
      "AddressType": "Origin",
      "ShippingLocationReference": "EDC5_Electio",
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
  "Direction": "Outbound"
}
```

# [Delivery Options Response](#tab/delivery-options-response)

```json
{
    "DeliveryOptions": [
        {
            "Reference": "EDO-000-6DX-6XP",
            "EstimatedDeliveryDate": {
                "Date": "2019-06-19T00:00:00+00:00",
                "Guaranteed": true,
                "DayOfWeek": "Wednesday"
            },
            "DeliveryWindow": {
                "Start": "00:00:00",
                "End": "23:59:00",
                "UtcOffset": "+01:00"
            },
            "Carrier": "Carrier X",
            "CarrierService": "Tracked 48 Signed For",
            "CarrierServiceReference": "MPD_T48CX",
            "CarrierServiceTypes": [
                "Standard"
            ],
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "TaxRate": {
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
            "AllocationCutOff": "2019-06-17T00:00:00+01:00",
            "OperationalCutOff": "2019-06-17T00:00:00+01:00",
            "ServiceDirection": "Inbound, Outbound"
        }
        {
            "Reference": "EDO-000-6DX-6XQ",
            "EstimatedDeliveryDate": {
                "Date": "2019-06-20T00:00:00+00:00",
                "Guaranteed": true,
                "DayOfWeek": "Wednesday"
            },
            "DeliveryWindow": {
                "Start": "00:00:00",
                "End": "23:59:00",
                "UtcOffset": "+01:00"
            },
            "Carrier": "Carrier X",
            "CarrierService": "Tracked 48 Signed For",
            "CarrierServiceReference": "MPD_T48CX",
            "CarrierServiceTypes": [
                "Standard"
            ],
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "TaxRate": {
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
            "AllocationCutOff": "2019-06-18T00:00:00+01:00",
            "OperationalCutOff": "2019-06-18T00:00:00+01:00",
            "ServiceDirection": "Inbound, Outbound"
        }
    ]
}    
```
---

Both of these options have a time window starting at 00:00 and ending at 23:59. In practice, the carrier is offering to make the delivery at some point on either the 19th or 20th of June (as selected by the customer), but isn't offering a more specific timeslot on that service. 

Note the `{Reference}` for each delivery option. When the customer selects their preferred delivery option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. In the next step, we'll see how to handle the choice the customer makes.
