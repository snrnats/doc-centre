> Create Order Endpoint
```
POST https://api.electioapp.com/orders
```

> Example Create Order Request

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

```xml
POST https://apisandbox.electioapp.com/orders

<?xml version="1.0" encoding="utf-8"?>
<CreateOrderRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Orders">
  <ShippingDate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">2019-06-17T14:08:53.4058784Z</ShippingDate>
  <Packages xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
    <Package>
      <PackageReferenceProvidedByCustomer>MYPACK-00923</PackageReferenceProvidedByCustomer>
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
      <Description>Socks</Description>
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
          <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">WMS-REF</KeyValue>
          <IntValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">77656555</IntValue>
          <DecimalValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
        </MetaData>
      </MetaData>
      <ConsignmentLegs>
        <ConsignmentLeg>
          <Leg>1</Leg>
          <TrackingReferences>
            <string>TRK00098HG</string>
            <string>PKJJGH434333</string>
          </TrackingReferences>
          <CarrierReference>CR001</CarrierReference>
          <CarrierName>Carrier A</CarrierName>
        </ConsignmentLeg>
      </ConsignmentLegs>
      <Items>
        <Item>
          <Sku>SKU093434</Sku>
          <Model>ITM-002</Model>
          <Description>Striped Bamboo Red/White</Description>
          <CountryOfOrigin>
            <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
              <TwoLetterCode>GB</TwoLetterCode>
            </IsoCode>
          </CountryOfOrigin>
          <HarmonisationCode>Harmonisation_Code</HarmonisationCode>
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
          <ItemReferenceProvidedByCustomer>ITEMREF-098</ItemReferenceProvidedByCustomer>
          <Barcode>
            <Code xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">09887-091221</Code>
            <BarcodeType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Code39</BarcodeType>
          </Barcode>
          <MetaData>
            <MetaData>
              <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Picker</KeyValue>
              <StringValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">David Thomas</StringValue>
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
          </HarmonisationKeyWords>
          <ContentClassification>Unrestricted</ContentClassification>
          <ContentClassificationDetails>NotSpecified</ContentClassificationDetails>
        </Item>
      </Items>
      <Charges>
        <KeyValuePairOfCustomChargeTypeDecimal>
          <Key xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Duty</Key>
          <Value xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">1.7</Value>
        </KeyValuePairOfCustomChargeTypeDecimal>
      </Charges>
    </Package>
  </Packages>
  <CustomsDocumentation xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
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
    <DeclarationDate>2019-06-14T00:00:00.0000000+00:00</DeclarationDate>
    <OfficeOfPosting>Manchester</OfficeOfPosting>
    <ReasonForExport>Sale</ReasonForExport>
    <ShippingTerms>CFR</ShippingTerms>
    <ShippersVatNumber>874541414</ShippersVatNumber>
    <ReceiversTaxCode>TC5454</ReceiversTaxCode>
    <ReceiversVatNumber>8745474</ReceiversVatNumber>
    <InvoiceDate />
  </CustomsDocumentation>
  <Addresses xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
    <Address>
      <ShippingLocationReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">EDC5_Electio</ShippingLocationReference>
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
  <MetaData xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
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
  <Direction xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Outbound</Direction>
  <Tags xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
    <Tag>TagA</Tag>
    <Tag>TagB</Tag>
  </Tags>
  <OrderReferenceProvidedByCustomer>MY_ORDER_REF_001</OrderReferenceProvidedByCustomer>
  <RequiredDeliveryDate>
    <IsToBeExactlyOnTheDateSpecified xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">false</IsToBeExactlyOnTheDateSpecified>
    <Date xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">2019-06-19T00:00:00.0000000+00:00</Date>
  </RequiredDeliveryDate>
  <Source>Api</Source>
</CreateOrderRequest>
```

> Example Create Order Response

```json
[
  {
    "Rel": "Order",
    "Href": "https://apisandbox.electioapp.com/orders/EO-000-002-0TS"
  }
]
```

```xml
<?xml version="1.0"?>
<ArrayOfApiLink xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <ApiLink>
        <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Detail</Rel>
        <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://apisandbox.electioapp.com/orders/EO-000-002-0TS</Href>
    </ApiLink>
</ArrayOfApiLink>
```

The **[Create Order](https://docs.electioapp.com/#/api/CreateOrder)** endpoint enables you to record details of a customer's order in SortedPRO. 

<aside class="info">
  In the context of PRO, an order represents a collection of packages that is to be transported to the same destination and on behalf of the same customer. Each order will eventually correspond to one or more consignments.
</aside>

At a minimum, the **Create Order** endpoint requires you to send package, origin address, and destination address data. However, there are lots of other properties you can send when creating an order, including:

* Your own order reference.
* The order's source.
* The required delivery date.
* Customs documentation.
* The order's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](#metadata)** section.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](#tags)** section.

Either the order's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

To edit an existing order, use the **[Update Orders](https://docs.electioapp.com/#/api/UpdateOrder)** endpoint. For more information on updating orders, see the [Updating Orders](#updating-orders) section.

<aside class="note">
  For full reference information on the <strong>Create Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/CreateOrder">Create Order</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows the creation of a fairly standard order. In this case, we have an outbound order comprising a single package with a single item inside it.

After receiving the request, PRO returns an `{orderReference}` of _EO-000-002-0TS_. That `{orderReference}` will come in useful later, as we will need it when we pack the order into shippable consignments.