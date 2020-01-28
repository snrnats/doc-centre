<div class="tab">
    <button class="staticTabButton">Create Consignment Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard('createConEndpoint')">Click to Copy</div>
</div>

<div id="createConEndpoint" class="staticTabContent" onclick="CopyToClipboard('createConEndpoint')">

```
POST https://api.electioapp.com/consignments
```
</div>

The first step toward manifesting a consignment is to create that consignment in SortedPRO. 

> <span class="note-header">Note:</span>
> In the context of PRO, the term <strong>"consignment"</strong> refers to a collection of one or more packages that are shipped from the same origin address, to the same destination address, on behalf of the same    Sorted customer, using the same carrier service, on the same day.
>
> A <strong>package</strong> is an <strong>item</strong> or a collection of items, wrapped or contained together for shipment. Each package can contain one or more items. 
>
> As an example, suppose that a clothing retailer has received a customer order for a necklace, a bracelet, a coat, and a hat. As the necklace and bracelet are both physically small, the retailer elects to ship them in the same package. As such, this sales order would break down to:
>
> * Four items - The necklace, the bracelet, the coat, and the hat.
> * Three packages - One containing the necklace and bracelet, one containing the coat, and one containing the hat.
> * A single consignment corresponding to everything on the order.

Consignments are created using the **[Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment)** endpoint, which takes information about new consignments, adds them to the database, and returns a link to the newly-created consignment, including its `{consignmentReference}`. 

The `{consignmentReference}` is a unique identifier for that consignment within PRO, and is a required parameter for many of PRO's API requests. Each PRO `{consignmentReference}` takes the format `EC-xxx-xxx-xxx`, where `x` is an alphanumeric character.

As a minimum, the **Create Consignments** endpoint requires you to send package weights and dimensions, origin address, and destination address data. You can either specify package weights and dimension via the `Weight` and `Dimensions` properties, or by supplying a `PackageSizeReference`. 

> <span class="note-header">More Information:</span>
>  A <code>PackageSizeReference</code> is a unique identifier for a pre-defined, standardised package size. To configure standard package sizes, use the <strong><a href="https://www.electioapp.com/Configuration/packagingsizes">Configuration > Packaging Sizes</a></strong> page of the PRO UI.  

However, there are lots of other properties you can send when creating a consignment, including:

* Your own consignment reference.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](/api/flows/moreInfo.html#metadata)** section of the **More Information** page.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](/api/flows/moreInfo.html#tags)** section of the **More Information** page.

Either the consignment's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

To edit an existing order, use the **[Update Orders](https://docs.electioapp.com/#/api/UpdateOrder)** endpoint. For more information on updating orders, see the **[Updating Orders](/api/flows/moreInfo.html#updating-orders)** section of the **More Information** page.

> <span class="note-header">More Information:</span>
>  For full reference information on the <strong>Create Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/CreateConsignment">Create Consignment</a></strong> page of the API reference.

###  Create Consignments Example

These examples show the creation of a fairly standard consignment. In this case, we have an outbound consignment comprising a single package with a single item inside it.

<div class="tab">
    <button class="staticTabButton">Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard('createConRequest')">Click to Copy</div>
</div>

<div id="createConRequest" class="staticTabContent" onclick="CopyToClipboard('createConRequest')">

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
    <div class="copybutton" onclick="CopyToClipboard('createConResponse')">Click to Copy</div>
</div>

<div id="createConResponse" class="staticTabContent" onclick="CopyToClipboard('createConResponse')">

```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-05B-MMA"
  }
]
```
</div>