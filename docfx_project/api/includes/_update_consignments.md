> Update Consignment Endpoint
```
PUT https://api.electioapp.com/consignments/
```

> Example Update Consignment Request
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
```xml
<?xml version="1.0" encoding="utf-8"?>
<UpdateConsignmentRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
  <Reference>EC-000-087-01A</Reference>
  <RequestedDeliveryDate>
    <IsToBeExactlyOnTheDateSpecified>false</IsToBeExactlyOnTheDateSpecified>
    <Date>2019-06-05T00:00:00.0000000+01:00</Date>
  </RequestedDeliveryDate>
  <ConsignmentReferenceProvidedByCustomer>Your Reference</ConsignmentReferenceProvidedByCustomer>
  <CustomsDocumentation>
    <DesignatedPersonResponsible>Peter McPetersson</DesignatedPersonResponsible>
    <ImportersVatNumber>02345555</ImportersVatNumber>
    <CategoryType>Other</CategoryType>
    <ShipperCustomsReference>CREF0001</ShipperCustomsReference>
    <ImportersTaxCode>TC001</ImportersTaxCode>
    <ImportersTelephone>0161123456</ImportersTelephone>
    <ImportersFax>01611124547</ImportersFax>
    <ImportersEmail>peter.mcpetersson@test.com</ImportersEmail>
    <CN23Comments>Comments</CN23Comments>
    <ReferencesOfAttachedInvoices>
      <string>INV001</string>
    </ReferencesOfAttachedInvoices>
    <ReferencesOfAttachedCertificates>
      <string>CERT001</string>
    </ReferencesOfAttachedCertificates>
    <ReferencesOfAttachedLicences>
      <string>LIC001</string>
    </ReferencesOfAttachedLicences>
    <CategoryTypeExplanation>Explanation</CategoryTypeExplanation>
    <DeclarationDate>2019-05-31T00:00:00.0000000+01:00</DeclarationDate>
    <OfficeOfPosting>Manchester</OfficeOfPosting>
    <ReasonForExport>Sale</ReasonForExport>
    <ShippingTerms>CFR</ShippingTerms>
    <ShippersVatNumber>874541414</ShippersVatNumber>
    <ReceiversTaxCode>TC5454</ReceiversTaxCode>
    <ReceiversVatNumber>8745474</ReceiversVatNumber>
    <InvoiceDate />
  </CustomsDocumentation>
  <Addresses>
    <Address>
      <ShippingLocationReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Shipping_Location_Reference</ShippingLocationReference>
      <AddressType>Origin</AddressType>
    </Address>
    <Address>
      <Contact xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
        <Reference xsi:nil="true" />
        <Title>Mr</Title>
        <FirstName>Peter</FirstName>
        <LastName>McPetersson</LastName>
        <Telephone>07702123456</Telephone>
        <Mobile>07702123456</Mobile>
        <LandLine>0161544123</LandLine>
        <Email>peter.mcpetersson@test.com</Email>
      </Contact>
      <CompanyName xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Test Company (UK) Ltd.</CompanyName>
      <AddressLine1 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">13 Porter Street</AddressLine1>
      <AddressLine2 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pressington</AddressLine2>
      <AddressLine3 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Carlsby</AddressLine3>
      <Town xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Manchester</Town>
      <Region xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Greater Manchester</Region>
      <Postcode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">M1 5WG</Postcode>
      <Country xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
        <Name>Great Britain</Name>
        <IsoCode>
          <TwoLetterCode>GB</TwoLetterCode>
        </IsoCode>
      </Country>
      <SpecialInstructions xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Gate code: 4454</SpecialInstructions>
      <LatLong xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
        <Latitude>53.474220</Latitude>
        <Longitude>-2.246049</Longitude>
      </LatLong>
      <AddressType>Destination</AddressType>
    </Address>
  </Addresses>
  <MetaData>
    <MetaData>
      <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Updated_Key</KeyValue>
      <StringValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Updated_Value</StringValue>
      <IntValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <DecimalValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
    </MetaData>
  </MetaData>
  <Packages>
    <UpdatePackageRequest>
      <Reference>EP-000-045-9FD</Reference>
      <PackageReferenceProvidedByCustomer>UpdatedReference</PackageReferenceProvidedByCustomer>
      <Weight>
        <Value xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.5</Value>
        <Unit xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Kg</Unit>
      </Weight>
      <Dimensions>
        <Unit xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Cm</Unit>
        <Width xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Width>
        <Length xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Length>
        <Height xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Height>
      </Dimensions>
      <Description>Updated Description</Description>
      <Value>
        <Amount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">5.99</Amount>
        <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
          <IsoCode>GBP</IsoCode>
        </Currency>
      </Value>
      <Barcode>
        <Code xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">09887-091221</Code>
        <BarcodeType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Code39</BarcodeType>
      </Barcode>
      <MetaData>
        <MetaData>
          <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">New_Metadata</KeyValue>
          <StringValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">New Value</StringValue>
          <IntValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <DecimalValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
        </MetaData>
      </MetaData>
      <Items>
        <UpdateItemRequest>
          <Sku>SKU_Updated</Sku>
          <Model>Updated Model</Model>
          <Description>Updated Description</Description>
          <CountryOfOrigin>
            <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
              <TwoLetterCode>GB</TwoLetterCode>
            </IsoCode>
          </CountryOfOrigin>
          <HarmonisationCode>NewCode</HarmonisationCode>
          <Weight>
            <Value xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.5</Value>
            <Unit xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Kg</Unit>
          </Weight>
          <Dimensions>
            <Unit xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Cm</Unit>
            <Width xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Width>
            <Length xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Length>
            <Height xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Height>
          </Dimensions>
          <Value>
            <Amount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">5.99</Amount>
            <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
              <IsoCode>GBP</IsoCode>
            </Currency>
          </Value>
          <ItemReferenceProvidedByCustomer>UpdatedItemReference</ItemReferenceProvidedByCustomer>
          <Barcode>
            <Code xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">09887-091221</Code>
            <BarcodeType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Code39</BarcodeType>
          </Barcode>
          <MetaData>
            <MetaData>
              <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">NewMetadata</KeyValue>
              <StringValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">NewValue</StringValue>
              <IntValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
              <DecimalValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
              <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
              <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
            </MetaData>
          </MetaData>
          <Quantity>1</Quantity>
          <Unit>Box</Unit>
          <HarmonisationKeyWords>
            <string>Keyword1</string>
            <string>Keyword2</string>
          </HarmonisationKeyWords>
          <ContentClassification xsi:nil="true" />
          <ContentClassificationDetails xsi:nil="true" />
          <Reference>3385728cb8594c739dccb2cf63454101</Reference>
        </UpdateItemRequest>
      </Items>
    </UpdatePackageRequest>
  </Packages>
  <Tags>
    <Tag>TagC</Tag>
  </Tags>
  <ShippingDate>2019-06-02T00:00:00.0000000+01:00</ShippingDate>
</UpdateConsignmentRequest>
```
> Example Update Consignment Response
```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-087-01A"
  }
]
```
```xml
<?xml version="1.0" encoding="utf-8"?>
<ArrayOfApiLink xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ApiLink>
    <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Link</Rel>
    <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://api.electioapp.com/consignments/EC-000-087-01A</Href>
  </ApiLink>
</ArrayOfApiLink>
```

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

### Example

The example to the right shows an  **Update Consignment** request for a single shipment that has a `{ConsignmentReference}` of _EC-000-087-01A_.  