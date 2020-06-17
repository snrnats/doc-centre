# [Pickup Options Endpoint](#tab/pickup-options-endpoint)

```json
POST https://api.electioapp.com/deliveryoptions/pickupoptions/
```
---    

In the context of PRO, a "pickup option" is a combination of a delivery promise (i.e. a delivery date and pickup location), and a carrier service that could meet that delivery promise for a consignment. The **[Pickup Options](https://docs.electioapp.com/#/api/PickupOptions)** endpoint takes the details of an as-yet uncreated consignment and returns available pickup options.

At a minimum, PRO requires you to send the following data in order to receive pickup options for a potential consignment:

* **Distance** - The maximum distance from the destination address that you want to receive results for.
* **Max Results** - The maximum number of results that you want to receive. This should be a value between one and 50.
* **Package Information**
* **Origin Address**
* **Destination Address**

The **Pickup Options** endpoint returns a `{Locations}` array containing details of each pickup location that can accept your consignment. PRO provides the location's full address, distance from destination address, latitude / longitude, and opening and closing times, enabling you to surface this information at checkout so that your customers can choose a convenient option. 

Each `{Location}` object contains a `{DeliveryOptions}` array listing the delivery promises available to that location for the proposed consignment. 

> [!NOTE]
> * For full reference information on the <strong>Pickup Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PickupOptions">Pickup Options</a></strong> page of the API reference.
> * For a user guide on pickup options, see the [Getting Pickup Options](/pro/api/help/getting_pickup_options.html) page.

### Pickup Options Example

The example shows a request to get no more than 10 pickup options for a fairly standard consignment, all within 1km of the recipient's location. 

# [Pickup Options Request](#tab/pickup-options-request)

`POST https://api.electioapp.com/deliveryoptions/pickupoptions/`

```json
{
  "Distance": {
    "Unit": "Km",
    "Value": 1.0
  },
  "MaxResults": 10,
  "ConsignmentReferenceProvidedByCustomer": "Your reference",
  "DeliveryDate": "2019-06-19T00:00:00+00:00",
  "GuaranteedOnly": false,
  "ShippingDate": "2019-06-16T00:00:00+00:00",
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
      "IsCached": false
    }
  ],
  "Direction": "Outbound"
}
```

# [Pickup Options Response](#tab/pickup-options-response)

```json
{
    "Distance": 1,
    "MaxResults": 10,
    "Locations": [
        {
            "Name": "I-Smart Communications",
            "ShopReference": "GB14002",
            "Address": {
                "AddressLine1": "41 Whitworth Street West",
                "AddressLine2": "",
                "AddressLine3": "The Lock Building",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5BD",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "IsCached": false
            },
            "Distance": 0.15,
            "OpeningTimes": {
                "Monday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Tuesday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Wednesday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Thursday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Friday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Saturday": [],
                "Sunday": []
            },
            "DeliveryOptions": [
                {
                    "Reference": "EDO-000-AHP-093",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-05-21T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Tuesday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-17T15:30:00+01:00",
                    "OperationalCutOff": "2019-05-17T15:00:00+01:00"
                },
                {
                    "Reference": "EDO-000-AHP-094",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-05-20T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Monday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-18T12:30:00+01:00",
                    "OperationalCutOff": "2019-05-18T12:00:00+01:00"
                },
                {
                    "Reference": "EDO-000-AHP-09G",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-05-17T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Friday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-16T15:30:00+01:00",
                    "OperationalCutOff": "2019-05-16T15:00:00+01:00"
                }
            ],
            "Reservation": {
                "IsReservationRequired": false,
                "ExpiryDate": null
            },
            "AdditionalInformation": [
                {
                    "Key": "Language",
                    "Value": "en"
                },
                {
                    "Key": "DisabledAccess",
                    "Value": "True"
                }
            ]
        }
    ],
    "NonGuaranteedLocation": null
}
```
---

The API has returned one location that meets the requested criteria, and three options for delivery to that location. All three options use the same carrier service and have a delivery time window of 09:30 - 17:30, but are scheduled for different days. In practice, PRO is saying that the carrier can deliver to the pickup location during business hours on the 17th, 20th or 21st of May (as required by the customer).

Note the `{Reference}` for each pickup option. When the customer selects their preferred pickup option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. In the next step, we'll see how to handle the choice the customer makes.
