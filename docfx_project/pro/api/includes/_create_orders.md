# [Create Order Endpoint](#tab/create-order-endpoint)

```json
POST https://api.electioapp.com/orders
```

---  

The **[Create Order](https://docs.electioapp.com/#/api/CreateOrder)** endpoint enables you to record details of a customer's order in SortedPRO.

As a minimum, the **Create Order** endpoint requires you to send package and item details, origin address, and destination address data.

> [!NOTE]
>
> * For full reference information on the **Create Order** endpoint, see the [Create Order](https://docs.electioapp.com/#/api/CreateOrder) page of the API reference.
> * For a user guide on creating orders, see the [Creating New Orders](/pro/api/help/creating_new_orders.html) page.

### Create Order Example

The example shows the creation of a fairly standard order. In this case, we have an outbound order comprising a single package with a single item inside it.

# [Create Order Request](#tab/create-order-request)

`POST https://api.electioapp.com/orders`

```json
{
  "OrderReferenceProvidedByCustomer": "MY_ORDER_REF_001",
  "RequiredDeliveryDate": {
    "Date": "2019-06-19T00:00:00+00:00",
    "IsToBeExactlyOnTheDateSpecified": false
  },
  "Source": "Api",
  "ShippingDate": "2019-06-17T13:23:44.3774435Z",
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
  "Direction": "Outbound"
}
```

# [Create Order Response](#tab/create-order-response)

```json
[
  {
    "Rel": "Order",
    "Href": "https://apisandbox.electioapp.com/orders/EO-000-002-0TS"
  }
]
```

---

After receiving the request, PRO returns an `{orderReference}` of _EO-000-002-0TS_. You should store the `{orderReference}`, as it will be required later when we pack the order into shippable consignments.
