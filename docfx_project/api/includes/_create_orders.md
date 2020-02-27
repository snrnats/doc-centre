<div class="tab">
    <button class="staticTabButton">Create Order Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createOrderEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createOrderEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'createOrderEndpoint')">

   ```
   POST https://api.electioapp.com/orders
   ```

</div>    

The **[Create Order](https://docs.electioapp.com/#/api/CreateOrder)** endpoint enables you to record details of a customer's order in SortedPRO. 

> <span class="note-header">More Information:</span>
>  In the context of PRO, an order represents a collection of packages that is to be transported to the same destination and on behalf of the same customer. Each order will eventually correspond to one or more consignments.

At a minimum, the **Create Order** endpoint requires you to send package, origin address, and destination address data. However, there are lots of other properties you can send when creating an order, including:

* Your own order reference.
* The order's source.
* The required delivery date.
* Customs documentation.
* The order's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](/api/flows/moreInfo.html#metadata)** section of the **More Information** page.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](/api/flows/moreInfo.html#tags)** section of the **More Information** page.

Either the order's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

To edit an existing order, use the **[Update Orders](https://docs.electioapp.com/#/api/UpdateOrder)** endpoint. For more information on updating orders, see the **[Updating Orders](/api/flows/moreInfo.html#updating-orders)** section of the **More Information** page.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Create Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/CreateOrder">Create Order</a></strong> page of the API reference.

### Create Order Example

The example shows the creation of a fairly standard order. In this case, we have an outbound order comprising a single package with a single item inside it.

<div class="tab">
    <button class="staticTabButton">Example Create Order Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createOrderRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createOrderRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'createOrderRequest')">

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

</div>   

<div class="tab">
    <button class="staticTabButton">Example Create Order Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createOrderResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createOrderResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'createOrderResponse')">

```json
[
  {
    "Rel": "Order",
    "Href": "https://api.electioapp.com/orders/EO-000-002-0TS"
  }
]
```

</div>  

After receiving the request, PRO returns an `{orderReference}` of _EO-000-002-0TS_. That `{orderReference}` will come in useful later, as we will need it when we pack the order into shippable consignments.