> Delivery Options Endpoint

```
POST https://api.electioapp.com/deliveryoptions
```

> Example Delivery Options Request

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

```xml
<?xml version="1.0" encoding="utf-8"?>
<DeliveryOptionsRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.DeliveryOptions">
  <ShippingDate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">2019-06-17T00:00:00+00:00</ShippingDate>
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
  <Direction xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Outbound</Direction>
  <ConsignmentReferenceProvidedByCustomer>Your Reference</ConsignmentReferenceProvidedByCustomer>
  <DeliveryDate>2019-06-19T00:00:00+00:00</DeliveryDate>
  <GuaranteedOnly>false</GuaranteedOnly>
</DeliveryOptionsRequest>
```
> Example Delivery Options Response

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

```xml
<?xml version="1.0"?>
<DeliveryOptionsResponse xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.DeliveryOptions">
    <DeliveryOptions>
        <DeliveryOption>
            <Reference>EDO-000-6DX-9EF</Reference>
            <EstimatedDeliveryDate>
                <Date>2019-06-19T00:00:00.0000000+00:00</Date>
                <Guaranteed>true</Guaranteed>
            </EstimatedDeliveryDate>
            <DeliveryWindow>
                <Start xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">PT0S</Start>
                <End xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">PT23H59M</End>
                <UtcOffset xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">+01:00</UtcOffset>
            </DeliveryWindow>
            <Carrier>Carrier X</Carrier>
            <CarrierService>Tracked 48 Signed For</CarrierService>
            <CarrierServiceReference>MPD_T48CX</CarrierServiceReference>
            <CarrierServiceTypes>
                <CarrierServiceType>Standard</CarrierServiceType>
            </CarrierServiceTypes>
            <Price>
                <Net xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">27.69</Net>
                <Gross xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">33.23</Gross>
                <TaxRate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Reference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB-0.2000</Reference>
                    <CountryIsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                    <Type xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                    <Rate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.2000</Rate>
                </TaxRate>
                <VatAmount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">5.54</VatAmount>
                <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Name xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                    <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                </Currency>
            </Price>
            <AllocationCutOff>2019-06-17T00:00:00.0000000+01:00</AllocationCutOff>
            <OperationalCutOff>2019-06-17T00:00:00.0000000+01:00</OperationalCutOff>
            <ServiceDirection>Inbound Outbound</ServiceDirection>
        </DeliveryOption>
        <DeliveryOption>
            <Reference>EDO-000-6DX-9EG</Reference>
            <EstimatedDeliveryDate>
                <Date>2019-06-20T00:00:00.0000000+00:00</Date>
                <Guaranteed>true</Guaranteed>
            </EstimatedDeliveryDate>
            <DeliveryWindow>
                <Start xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">PT0S</Start>
                <End xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">PT23H59M</End>
                <UtcOffset xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">+01:00</UtcOffset>
            </DeliveryWindow>
            <Carrier>Carrier X</Carrier>
            <CarrierService>Tracked 48 Signed For</CarrierService>
            <CarrierServiceReference>MPD_T48CX</CarrierServiceReference>
            <CarrierServiceTypes>
                <CarrierServiceType>Standard</CarrierServiceType>
            </CarrierServiceTypes>
            <Price>
                <Net xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">27.69</Net>
                <Gross xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">33.23</Gross>
                <TaxRate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Reference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB-0.2000</Reference>
                    <CountryIsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                    <Type xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                    <Rate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.2000</Rate>
                </TaxRate>
                <VatAmount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">5.54</VatAmount>
                <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Name xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                    <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                </Currency>
            </Price>
            <AllocationCutOff>2019-06-18T00:00:00.0000000+01:00</AllocationCutOff>
            <OperationalCutOff>2019-06-18T00:00:00.0000000+01:00</OperationalCutOff>
            <ServiceDirection>Inbound Outbound</ServiceDirection>
        </DeliveryOption>
    </DeliveryOptions>
</DeliveryOptionsResponse>
```

<aside class="info">
  In the context of SortedPRO, a "delivery option" refers to a combination of a carrier service, delivery date and time window.

  For example, suppose that you use the **Delivery Options** endpoint to request delivery options for a particular consignment, and the response indicates the following:

  * Carrier X could deliver the consignment between 9 and 5 on Monday.
  * Carrier Y could deliver the consignment on Monday between 9 and 12 or Tuesday between 9 and 12
  * Carrier Z could deliver the consignment on Monday between 9 and 1 or Monday between 1 and 5

  In this case, there are five available delivery options: one for Carrier X and two each for Carriers Y and Z.
</aside> 

The **[Delivery Options](https://docs.electioapp.com/#/api/DeliveryOptions)** endpoint takes the details of an as-yet-nonexistent consignment and returns a single available carrier service for each delivery option. PRO always returns the cheapest carrier service for each option, unless using the cheapest service would conflict with existing business rules. This data can be used to offer delivery promise choices (such as dates and timeslots) to your customer.    

At a minimum, PRO requires you to send package, origin address and destination address data in order to return delivery options. However, there are lots of other properties you can send when getting delivery options, including:

* Your own consignment reference.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](#metadata)** section.
* Tags. Allocation tags enable you to filter the list carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](#tags)** section.

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

<aside class="note">
  For full reference information on the <strong>Delivery Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/DeliveryOptions">Delivery Options</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows a request to get delivery options for a fairly standard consignment. The API has returned two delivery options, both for Carrier X: one with an `{estimatedDeliveryDate}` of _2019-06-19_ and one with an `{estimatedDeliveryDate}` of _2019-06-20_. 

Both of these options have a time window starting at 00:00 and ending at 23:59. In practice, the carrier is offering to make the delivery at some point on either the 19th or 20th of June (as selected by the customer), but isn't offering a more specific timeslot on that service. 

Note the `{Reference}` for each delivery option. When the customer selects their preferred delivery option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. In the next step, we'll see how to handle the choice the customer makes.