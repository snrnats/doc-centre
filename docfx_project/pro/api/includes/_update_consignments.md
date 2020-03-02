<div class="tab">
    <button class="staticTabButton">Update Consignment Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateConsEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateConsEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'updateConsEndpoint')">

```
PUT https://api.electioapp.com/consignments/
```

</div>

The **Update Consignment** endpoint enables you to update an existing consignment. When you make an **Update Consignment** request for a particular consignment, SortedPRO overwrites the existing consignment's details with new details provided in the body of the request.

The structure of the **Update Consignment** request is identical to that of the **Create Consignment** request. PRO uses the following rules when updating consignment properties:

* `{Reference}` - Required property. Cannot be updated.
* `{Source}` - Ignored. Cannot be updated.
* `{ShippingDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{RequestedDeliveryDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{ConsignmentReferenceProvidedByCustomer}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{CustomsDocumentation}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{MetaData}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Addresses}`	- PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted. You cannot update addresses after a consignment has been allocated.
* `{Packages}` - If any values are provided, then PRO attempts to replace the entire property with the updated values. You cannot update packages after a consignment has been allocated. If no values are provided, PRO makes no changes to the consignment.
* `{Tags}` - If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the consignment.

<aside class="note">
  For full reference information on the <strong>Update Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/UpdateConsignment">Update Consignment</a></strong> page of the API reference.
</aside>

### Update Consignments Example

The example shows an  **Update Consignment** request for a single shipment that has a `{ConsignmentReference}` of _EC-000-087-01A_.  

<div class="tab">
    <button class="staticTabButton">Example Update Consignment Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateConsRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateConsRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'updateConsRequest')">

```json
{
  "ShippingDate": "2019-06-02T00:00:00+01:00",
  "Reference": "EC-000-087-01A",
  "RequestedDeliveryDate": {
    "Date": "2019-06-05T00:00:00+01:00",
    "IsToBeExactlyOnTheDateSpecified": false
  },
  "ConsignmentReferenceProvidedByCustomer": "Your Reference",
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
    "DeclarationDate": "2019-05-31T00:00:00+01:00",
    "OfficeOfPosting": "Manchester",
    "ReasonForExport": "Sale",
    "ShippingTerms": "CFR",
    "ShippersVatNumber": "874541414",
    "ReceiversTaxCode": "TC5454",
    "ReceiversVatNumber": "8745474",
    "InvoiceDate": "2019-05-31T00:00:00+01:00"
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
      "LatLong": {
        "Latitude": 53.474220,
        "Longitude": -2.246049
      },
      "IsCached": false
    }
  ],
  "MetaData": [
    {
      "KeyValue": "Updated_Key",
      "StringValue": "Updated_Value"
    }
  ],
  "Packages": [
    {
      "Items": [
        {
          "Reference": "3385728cb8594c739dccb2cf63454101",
          "Sku": "SKU_Updated",
          "Model": "Updated Model",
          "Description": "Updated Description",
          "CountryOfOrigin": {
            "IsoCode": {
              "TwoLetterCode": "GB"
            }
          },
          "HarmonisationCode": "NewCode",
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
          "ItemReferenceProvidedByCustomer": "UpdatedItemReference",
          "Barcode": {
            "Code": "09887-091221",
            "BarcodeType": "Code39"
          },
          "MetaData": [
            {
              "KeyValue": "NewMetadata",
              "StringValue": "NewValue"
            }
          ],
          "Quantity": 1,
          "Unit": "Box",
          "HarmonisationKeyWords": [
            "Keyword1",
            "Keyword2"
          ]
        }
      ],
      "Reference": "EP-000-045-9FD",
      "PackageReferenceProvidedByCustomer": "UpdatedReference",
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
      "Description": "Updated Description",
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
          "KeyValue": "New_Metadata",
          "StringValue": "New Value"
        }
      ]
    }
  ],
  "Tags": [
    "TagC"
  ]
}
```
</div>

<div class="tab">
    <button class="staticTabButton">Example Update Consignment Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateConsResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateConsResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'updateConsResponse')">

```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-087-01A"
  }
]
```

</div>

