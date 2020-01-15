> Update Order Endpoint
```
PUT https://api.electioapp.com/orders/{orderReference}
```

> Example Update Order Request

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
```xml
<?xml version="1.0" encoding="utf-8"?>
<UpdateOrderRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Orders">
  <OrderReference>EC-000-087-01A</OrderReference>
  <OrderReferenceProvidedByCustomer>5e6127aa-fe42-49d8-a3a4-cd621e11b9ea</OrderReferenceProvidedByCustomer>
  <RequiredDeliveryDate>
    <IsToBeExactlyOnTheDateSpecified xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">true</IsToBeExactlyOnTheDateSpecified>
    <Date xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">2019-06-05T00:00:00.0000000+01:00</Date>
  </RequiredDeliveryDate>
  <ShippingDate>2019-05-31T00:00:00+01:00</ShippingDate>
  <CustomsDocumentation>
    <DesignatedPersonResponsible xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Peter McPetersson</DesignatedPersonResponsible>
    <ImportersVatNumber xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">02345555</ImportersVatNumber>
    <CategoryType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Other</CategoryType>
    <ShipperCustomsReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">CREF0001</ShipperCustomsReference>
    <ImportersTaxCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">TC001</ImportersTaxCode>
    <ImportersTelephone xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">0161123456</ImportersTelephone>
    <ImportersFax xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">01611124547</ImportersFax>
    <ImportersEmail xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">peter.mcpetersson@test.com</ImportersEmail>
    <CN23Comments xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Comments</CN23Comments>
    <ReferencesOfAttachedInvoices xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
      <string>INV001</string>
    </ReferencesOfAttachedInvoices>
    <ReferencesOfAttachedCertificates xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
      <string>CERT001</string>
    </ReferencesOfAttachedCertificates>
    <ReferencesOfAttachedLicences xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
      <string>LIC001</string>
    </ReferencesOfAttachedLicences>
    <CategoryTypeExplanation xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Explanation</CategoryTypeExplanation>
    <DeclarationDate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">2019-05-31T00:00:00.0000000+01:00</DeclarationDate>
    <OfficeOfPosting xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Manchester</OfficeOfPosting>
    <ReasonForExport xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Sale</ReasonForExport>
    <ShippingTerms xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">CFR</ShippingTerms>
    <ShippersVatNumber xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">874541414</ShippersVatNumber>
    <ReceiversTaxCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">TC5454</ReceiversTaxCode>
    <ReceiversVatNumber xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">8745474</ReceiversVatNumber>
    <InvoiceDate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments" />
  </CustomsDocumentation>
  <Addresses>
    <Address>
      <ShippingLocationReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Shipping_Location_Reference</ShippingLocationReference>
      <AddressType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Origin</AddressType>
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
      <AddressType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Destination</AddressType>
    </Address>
  </Addresses>
  <MetaData>
    <MetaData>
      <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Key1</KeyValue>
      <StringValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Value1</StringValue>
      <IntValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <DecimalValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
    </MetaData>
    <MetaData>
      <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Key2</KeyValue>
      <IntValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <DecimalValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">12.45</DecimalValue>
      <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
      <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
    </MetaData>
  </MetaData>
  <Direction>Outbound</Direction>
  <Tags>
    <Tag>TagC</Tag>
  </Tags>
</UpdateOrderRequest>
```
> Example Update Order Response
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

### Example

The example to the right shows an  **Update Order** request for a single shipment that has a `{OrderReference}` of _EC-000-087-01A_.  