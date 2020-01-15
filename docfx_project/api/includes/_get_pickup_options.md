> Pickup Options Endpoint
```
POST https://api.electioapp.com/deliveryoptions/pickupoptions/
```

> Example Pickup Options Request

```json
{
  "Distance": {
    "Unit": "Km",
    "Value": 1.0
  },
  "MaxResults": 10,
  "ConsignmentReferenceProvidedByCustomer": "Your reference",
  "DeliveryDate": "2019-06-19T00:00:00+00:00",
  "GuaranteedOnly": false,
  "ShippingDate": "2019-06-16T00:00:00+00:00",
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
      "IsCached": false
    }
  ],
  "Direction": "Outbound"
}
```

```xml
<?xml version="1.0" encoding="utf-8"?>
<PickupOptionsRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.DeliveryOptions">
  <ShippingDate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">2019-06-16T00:00:00+00:00</ShippingDate>
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
      <AddressType>Destination</AddressType>
    </Address>
  </Addresses>
  <Direction xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Outbound</Direction>
  <ConsignmentReferenceProvidedByCustomer>Your reference</ConsignmentReferenceProvidedByCustomer>
  <DeliveryDate>2019-06-19T00:00:00+00:00</DeliveryDate>
  <GuaranteedOnly>false</GuaranteedOnly>
  <Distance>
    <Unit>Km</Unit>
    <Value>1</Value>
  </Distance>
  <MaxResults>10</MaxResults>
</PickupOptionsRequest>
```

> Example Pickup Options Response

```json
{
    "Distance": 1,
    "MaxResults": 10,
    "Locations": [
        {
            "Name": "I-Smart Communications",
            "ShopReference": "GB14002",
            "Address": {
                "AddressLine1": "41 Whitworth Street West",
                "AddressLine2": "",
                "AddressLine3": "The Lock Building",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5BD",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "IsCached": false
            },
            "Distance": 0.15,
            "OpeningTimes": {
                "Monday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Tuesday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Wednesday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Thursday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Friday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Saturday": [],
                "Sunday": []
            },
            "DeliveryOptions": [
                {
                    "Reference": "EDO-000-AHP-093",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-05-21T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Tuesday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-17T15:30:00+01:00",
                    "OperationalCutOff": "2019-05-17T15:00:00+01:00"
                },
                {
                    "Reference": "EDO-000-AHP-094",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-05-20T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Monday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-18T12:30:00+01:00",
                    "OperationalCutOff": "2019-05-18T12:00:00+01:00"
                },
                {
                    "Reference": "EDO-000-AHP-09G",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-05-17T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Friday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-16T15:30:00+01:00",
                    "OperationalCutOff": "2019-05-16T15:00:00+01:00"
                }
            ],
            "Reservation": {
                "IsReservationRequired": false,
                "ExpiryDate": null
            },
            "AdditionalInformation": [
                {
                    "Key": "Language",
                    "Value": "en"
                },
                {
                    "Key": "DisabledAccess",
                    "Value": "True"
                }
            ]
        }
    ],
    "NonGuaranteedLocation": null
}
```

```xml
<?xml version="1.0"?>
<PickupOptionsResponse xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.DeliveryOptions">
    <Distance>1.0</Distance>
    <MaxResults>10</MaxResults>
    <Locations>
        <Location>
            <Name>I-Smart Communications</Name>
            <ShopReference>GB14002</ShopReference>
            <Address>
                <AddressLine1 xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">41 Whitworth Street West</AddressLine1>
                <AddressLine2 xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common" />
                <AddressLine3 xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">The Lock Building</AddressLine3>
                <Town xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Manchester</Town>
                <Region xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common" />
                <Postcode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">M1 5BD</Postcode>
                <Country xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">
                    <Name>United Kingdom</Name>
                    <IsoCode>
                        <TwoLetterCode>GB</TwoLetterCode>
                    </IsoCode>
                </Country>
            </Address>
            <Distance>0.15</Distance>
            <OpeningTimes>
                <Monday>
                    <OpeningTime>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT11H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT18H</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0:00</UtcOffset>
                    </OpeningTime>
                </Monday>
                <Tuesday>
                    <OpeningTime>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT11H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT18H</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0:00</UtcOffset>
                    </OpeningTime>
                </Tuesday>
                <Wednesday>
                    <OpeningTime>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT11H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT18H</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0:00</UtcOffset>
                    </OpeningTime>
                </Wednesday>
                <Thursday>
                    <OpeningTime>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT11H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT18H</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0:00</UtcOffset>
                    </OpeningTime>
                </Thursday>
                <Friday>
                    <OpeningTime>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT11H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT18H</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0:00</UtcOffset>
                    </OpeningTime>
                </Friday>
                <Saturday />
                <Sunday />
            </OpeningTimes>
            <DeliveryOptions>
                <DeliveryOption>
                    <Reference>EDO-000-AHN-ZR3</Reference>
                    <EstimatedDeliveryDate>
                        <Date>2019-05-21T00:00:00.0000000+00:00</Date>
                        <Guaranteed>true</Guaranteed>
                    </EstimatedDeliveryDate>
                    <DeliveryWindow>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT9H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT17H30M</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">+01:00</UtcOffset>
                    </DeliveryWindow>
                    <Carrier>DPD</Carrier>
                    <CarrierService>DPD Ship To Shop</CarrierService>
                    <CarrierServiceReference>EDC5_DPDSS</CarrierServiceReference>
                    <Price>
                        <Net>5.99</Net>
                        <Gross>7.19</Gross>
                        <VatRate>
                            <Reference xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GB-0.2000</Reference>
                            <CountryIsoCode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                            <Type xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                            <Rate xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0.2000</Rate>
                        </VatRate>
                        <VatAmount>1.20</VatAmount>
                        <Currency>
                            <Name xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                            <IsoCode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                        </Currency>
                    </Price>
                    <AllocationCutOff>2019-05-18T15:30:00.0000000+01:00</AllocationCutOff>
                    <OperationalCutOff>2019-05-18T15:00:00.0000000+01:00</OperationalCutOff>
                </DeliveryOption>
                <DeliveryOption>
                    <Reference>EDO-000-AHN-ZR4</Reference>
                    <EstimatedDeliveryDate>
                        <Date>2019-05-20T00:00:00.0000000+00:00</Date>
                        <Guaranteed>true</Guaranteed>
                    </EstimatedDeliveryDate>
                    <DeliveryWindow>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT9H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT17H30M</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">+01:00</UtcOffset>
                    </DeliveryWindow>
                    <Carrier>DPD</Carrier>
                    <CarrierService>DPD Ship To Shop</CarrierService>
                    <CarrierServiceReference>EDC5_DPDSS</CarrierServiceReference>
                    <Price>
                        <Net>5.99</Net>
                        <Gross>7.19</Gross>
                        <VatRate>
                            <Reference xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GB-0.2000</Reference>
                            <CountryIsoCode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                            <Type xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                            <Rate xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0.2000</Rate>
                        </VatRate>
                        <VatAmount>1.20</VatAmount>
                        <Currency>
                            <Name xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                            <IsoCode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                        </Currency>
                    </Price>
                    <AllocationCutOff>2019-05-18T12:30:00.0000000+01:00</AllocationCutOff>
                    <OperationalCutOff>2019-05-18T12:00:00.0000000+01:00</OperationalCutOff>
                </DeliveryOption>
                <DeliveryOption>
                    <Reference>EDO-000-AHN-ZR5</Reference>
                    <EstimatedDeliveryDate>
                        <Date>2019-05-18T00:00:00.0000000+00:00</Date>
                        <Guaranteed>true</Guaranteed>
                    </EstimatedDeliveryDate>
                    <DeliveryWindow>
                        <Start xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT9H</Start>
                        <End xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">PT17H30M</End>
                        <UtcOffset xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">+01:00</UtcOffset>
                    </DeliveryWindow>
                    <Carrier>DPD</Carrier>
                    <CarrierService>DPD Ship To Shop</CarrierService>
                    <CarrierServiceReference>EDC5_DPDSS</CarrierServiceReference>
                    <Price>
                        <Net>5.99</Net>
                        <Gross>7.19</Gross>
                        <VatRate>
                            <Reference xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GB-0.2000</Reference>
                            <CountryIsoCode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                            <Type xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                            <Rate xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">0.2000</Rate>
                        </VatRate>
                        <VatAmount>1.20</VatAmount>
                        <Currency>
                            <Name xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                            <IsoCode xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                        </Currency>
                    </Price>
                    <AllocationCutOff>2019-05-15T15:30:00.0000000+01:00</AllocationCutOff>
                    <OperationalCutOff>2019-05-15T15:00:00.0000000+01:00</OperationalCutOff>
                </DeliveryOption>                
            </DeliveryOptions>
            <Reservation>
                <IsReservationRequired>false</IsReservationRequired>
                <ExpiryDate xsi:nil="true" />
            </Reservation>
            <AdditionalInformation>
                <AdditionalInformation>
                    <Key xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">Language</Key>
                    <Value xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">en</Value>
                </AdditionalInformation>
                <AdditionalInformation>
                    <Key xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">DisabledAccess</Key>
                    <Value xmlns="http://electioapp.com/schemas/v1/MPD.Electio.SDK.DataTypes.Common">True</Value>
                </AdditionalInformation>
            </AdditionalInformation>
        </Location>
    </Locations>
</PickupOptionsResponse>
```

<aside class="info">
  In the context of PRO, a "pickup option" refers to a combination of a carrier service, date and time window.

  For example, suppose that you use the **Pickup Options** endpoint to request pickup options for a particular consignment, and the response indicates the following:

  * Carrier X could deliver the consignment on Monday between 9-5.
  * Carrier Y could deliver the consignment on Monday between 9-12 or Tuesday between 9-12
  * Carrier Z could deliver the consignment on Monday between 9-1 or Monday between 1-5

  In this case, there are five available pickup options: one for Carrier X and two each for Carriers Y and Z.
</aside>   

The **[Pickup Options](https://docs.electioapp.com/#/api/PickupOptions)** endpoint takes the details of an as-yet uncreated consignment and returns available pickup options. This data can be used to offer pickup timeslots and locations for the product that the customer is about to purchase.  

At a minimum, SortedPRO requires you to send the following data in order to receive pickup options for a potential consignment:

* **Distance** - The maximum distance from the destination address (in km) you want to receive results for.
* **Max Results** - The maximum number of results that you want to receive. This should be a value between one and 50.
* **Package Information**
* **Origin Address**
* **Destination Address**

 However, there are lots of other properties you can send when getting pickup options, including:

* Your own consignment reference.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](#metadata)** section.
* Tags. Allocation tags enable you to filter the list carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](#tags)** section.

Providing extra information can help you to improve the relevance of the options returned.

Either the consignment's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

The **Pickup Options** endpoint returns a `{Locations}` array detailing all the pickup locations that have options meeting your request criteria. Each `{Location}` object contains a `{DeliveryOptions}` array listing the delivery options that are available to that location for the proposed consignment, and the opening times of the location itself.

Each `{PickupOptions}` object contains details of a particular pickup option that could be used to deliver the consignment to the relevant location, including:

* **Reference** - A unique identifier for the option, used when selecting options in the next step.
* **Dates and Delivery Windows**
* **Carrier Service**
* **Price**
* **Allocation Cutoff** - The option's expiry time. If the option is not used by this time, it is rendered invalid.
* **Operational Cutoff** - 	The operational cut off date as specified by the fulfilling shipping location.
* **Service Direction**

<aside class="note">
  For full reference information on the <strong>Pickup Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PickupOptions">Pickup Options</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows a request to get no more than 10 pickup options for a fairly standard consignment, all within 1km of the recipient's location. 

The API has returned one location that meets the requested criteria, and three options for delivery to that location. All three options use the same carrier service and have a delivery time window of 09:30 - 17:30, but are scheduled for different days. In practice, PRO is saying that the carrier can deliver to the pickup location during business hours on the 17th, 20th or 21st of May (as required by the customer).

Note the `{Reference}` for each pickup option. When the customer selects their preferred delivery option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. In the next step, we'll see how to handle the choice the customer makes.