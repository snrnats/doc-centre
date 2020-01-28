<div class="tab">
    <button class="staticTabButton">Delivery Options Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard('DelOptionsEndpoint')">Click to Copy</div>
</div>

<div id="DelOptionsEndpoint" class="staticTabContent" onclick="CopyToClipboard('DelOptionsEndpoint')">

   ```
   POST https://api.electioapp.com/deliveryoptions
   ```

</div>  

The **[Delivery Options](https://docs.electioapp.com/#/api/DeliveryOptions)** endpoint takes the details of an as-yet-nonexistent consignment and returns a single available carrier service for each delivery option. PRO always returns the cheapest carrier service for each option, unless using the cheapest service would conflict with existing business rules. This data can be used to offer delivery promise choices (such as dates and timeslots) to your customer.   

> <span class="note-header">Note:</span>
>  In the context of SortedPRO, a "delivery option" refers to a combination of a carrier service, delivery date and time window.
>
>  For example, suppose that you use the **Delivery Options** endpoint to request delivery options for a particular consignment, and the response indicates the following:
>
>  * Carrier X could deliver the consignment between 9 and 5 on Monday.
>  * Carrier Y could deliver the consignment on Monday between 9 and 12 or Tuesday between 9 and 12
>  * Carrier Z could deliver the consignment on Monday between 9 and 1 or Monday between 1 and 5
>
>  In this case, there are five available delivery options: one for Carrier X and two each for Carriers Y and Z. 

At a minimum, PRO requires you to send package, origin address and destination address data in order to return delivery options. However, there are lots of other properties you can send when getting delivery options, including:

* Your own consignment reference.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](/api/flows/moreInfo.html#metadata)** section of the **More Information** page.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](/api/flows/moreInfo.html#tags)** section of the **More Information** page.

Providing extra information can help you to improve the relevance of the options returned.

Either the consignment's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

The **Delivery Options** endpoint returns an array of `{DeliveryOptions}` objects. Each `{DeliveryOptions}` object contains details of a particular delivery option that is available to take a consignment with the details you passed in the request, including:

* **Reference** - A unique identifier for the delivery option, used when selecting delivery options in the next step.
* **Dates and Delivery Windows**
* **Carrier Service**
* **Price (cost)**
* **Allocation Cutoff** - The option's expiry time. If the option is not used by this time, it is rendered invalid. This value is usually set by the carrier, but can be configured manually via the **Settings > [Shipping Locations](https://www.electioapp.com/Configuration/ShippingLocations) > [Select Location] > Collection Calendar** page of the PRO UI. 
* **Operational Cutoff** - 	The operational cut off date as specified by the fulfilling shipping location.
* **Service Direction**

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Delivery Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/DeliveryOptions">Delivery Options</a></strong> page of the API reference.

### Get Delivery Options Example

The example shows a request to get delivery options for a fairly standard consignment. The API has returned two delivery options, both for Carrier X: one with an `{estimatedDeliveryDate}` of _2019-06-19_ and one with an `{estimatedDeliveryDate}` of _2019-06-20_.

<div class="tab">
    <button class="staticTabButton">Example Delivery Options Request</button>
    <div class="copybutton" onclick="CopyToClipboard('DelOptionsRequest')">Click to Copy</div>
</div>

<div id="DelOptionsRequest" class="staticTabContent" onclick="CopyToClipboard('DelOptionsRequest')">

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

</div>

<div class="tab">
    <button class="staticTabButton">Example Delivery Options Response</button>
    <div class="copybutton" onclick="CopyToClipboard('DelOptionsResponse')">Click to Copy</div>
</div>

<div id="DelOptionsResponse" class="staticTabContent" onclick="CopyToClipboard('DelOptionsResponse')">

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

</div>  

Both of these options have a time window starting at 00:00 and ending at 23:59. In practice, the carrier is offering to make the delivery at some point on either the 19th or 20th of June (as selected by the customer), but isn't offering a more specific timeslot on that service. 

Note the `{Reference}` for each delivery option. When the customer selects their preferred delivery option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. In the next step, we'll see how to handle the choice the customer makes.