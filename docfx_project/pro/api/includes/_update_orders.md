<div class="tab">
    <button class="staticTabButton">Update Order Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateOrdEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateOrdEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'updateOrdEndpoint')">

```
PUT https://api.electioapp.com/orders/{orderReference}
```

</div>

The **Update Order** endpoint enables you to update an existing order. When you make an **Update Order** request for a particular order, SortedPRO overwrites the existing order's details with new details provided in the body of the request.

The structure of the **Update Order** request is identical to that of the **Create Order** request. PRO uses the following rules when updating order properties:

* `{OrderReference}` - Required property. Cannot be updated.
* `{OrderReferenceProvidedByCustomer}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{RequiredDeliveryDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Source}` - Ignored. Cannot be updated.
* `{ShippingDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Packages}` - Ignored. Use the **[Pack Order](https://docs.electioapp.com/#/api/PackOrder)** endpoint to manage an order's packages instead.
* `{CustomsDocumentation}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Addresses}`	- If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the order.
* `{MetaData}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Direction}` - If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the order.
* `{Tags}` - If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the order.

<aside class="note">
  For full reference information on the <strong>Update Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/UpdateOrder">Update Order</a></strong> page of the API reference.
</aside>

### Update Orders Example

The example shows an  **Update Order** request for a single shipment that has a `{OrderReference}` of _EC-000-087-01A_.  

<div class="tab">
    <button class="staticTabButton">Example Update Order Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateOrdRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateOrdRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'updateOrdRequest')">

```
PUT https://api.electioapp.com/orders/EC-000-087-01A
```

```json
{
  "OrderReference": "EC-000-087-01A",
  "OrderReferenceProvidedByCustomer": "5e6127aa-fe42-49d8-a3a4-cd621e11b9ea",
  "RequiredDeliveryDate": {
    "Date": "2019-06-05T00:00:00+01:00",
    "IsToBeExactlyOnTheDateSpecified": true
  },
  "ShippingDate": "2019-05-31T00:00:00+01:00",
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
      "KeyValue": "Key1",
      "StringValue": "Value1"
    },
    {
      "KeyValue": "Key2",
      "DecimalValue": 12.45
    }
  ],
  "Direction": "Outbound",
  "Tags": [
    "TagC"
  ]
}
```

</div>

<div class="tab">
    <button class="staticTabButton">Example Update Order Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateOrdResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateOrdResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'updateOrdResponse')">

```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-087-01A"
  }
]
```

</div>

