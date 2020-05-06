<div class="tab">
    <button class="staticTabButton">Create Consignment Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createConEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createConEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'createConEndpoint')">

```
POST https://api.electioapp.com/consignments
```
</div>

The first step toward manifesting a consignment is to create that consignment in SortedPRO. 

Consignments are created using the **[Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment)** endpoint, which takes information about new consignments, adds them to the database, and returns a link to the newly-created consignment, including its `{consignmentReference}`. 

As a minimum, the **Create Consignments** endpoint requires you to send package weights and dimensions, origin address, and destination address data. 

> <span class="note-header">More Information:</span>
> * For full reference information on the <strong>Create Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/CreateConsignment">Create Consignment</a></strong> page of the API reference.
> * For a user guide explaining the **Create Consignment** endpoint, see the [Creating New Consignments](/pro/api/help/creating_new_consignments.html) page.

###  Create Consignments Example

These examples show the creation of a fairly standard consignment. In this case, we have an outbound consignment comprising a single package with a single item inside it.

<div class="tab">
    <button class="staticTabButton">Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createConRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createConRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'createConRequest')">

```json
{
  "ConsignmentReferenceProvidedByCustomer": "MYCONS-098998",
  "Source": "Api",
  "MetaData": [
    {
      "KeyValue": "Restock_Date",
      "DateTimeValue": "2019-06-18T00:00:00+00:00"
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

After receiving the request, PRO returns a `{consignmentReference}` of _EC-000-05B-MMA_. At this point, you should store the `{consignmentReference}`, as many of PRO's endpoints take `{consignmentReference}` as a parameter.

<div class="tab">
    <button class="staticTabButton">Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createConResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createConResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'createConResponse')">

```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-05B-MMA"
  }
]
```
</div>

A newly created consignment has a `{consignmentState}` of "Unallocated".
