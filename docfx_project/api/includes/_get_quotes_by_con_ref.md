> Get Quotes by Consignment Reference Endpoint
```
GET https://api.electioapp.com/quotes/consignment/{consignmentReference}
```

> Example Get Quotes by Consignment Reference Request

```
https://api.electioapp.com/quotes/consignment/EC-000-05B-1CM
```

> Example Get Quotes by Consignment Reference Response

```json
{
    "QuoteRequestReference": "6f9c7ee5-a97e-4df9-bc07-aa3f00e99316",
    "Quotes": [
        {
            "MpdCarrierServiceSource": 2,
            "MpdCarrierService": "1st and 2nd Class Account Mail (1st Parcel)",
            "OriginAddress": {
                "ShippingLocationReference": "EDC5_Electio",
                "AddressLine1": "Third Floor",
                "AddressLine2": "Merchant Exchange",
                "AddressLine3": "Whitworth Street West",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "SpecialInstructions": "",
                "IsCached": false
            },
            "DestinationAddress": {
                "AddressLine1": "13 Porter Street",
                "AddressLine2": "Pressington",
                "AddressLine3": "Carlsby",
                "Town": "Manchester",
                "Region": "Greater Manchester",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "SpecialInstructions": "Gate code: 4454",
                "IsCached": false
            },
            "CollectionDate": "2019-05-01T00:00:00",
            "EarliestDeliveryDate": "2019-05-02T00:00:00",
            "LatestDeliveryDate": "2019-05-02T23:59:00",
            "BasePrice": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
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
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
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
            "Surcharges": [],
            "Legs": [
                {
                    "JourneyStage": 1,
                    "CarrierService": {
                        "Reference": "RMDBPR1STPSU",
                        "Name": "1st and 2nd Class Account Mail (1st Parcel)",
                        "CarrierReference": "ROYAL_MAIL",
                        "CarrierName": null,
                        "IsDropOff": false,
                        "IsPickUp": false,
                        "IsTimed": false
                    },
                    "CarrierAccountReference": "RM1",
                    "DeliveryHub": null,
                    "CostItems": null,
                    "VolumetricParcelWeight": null,
                    "CollectionType": "NotApplicable"
                }
            ],
            "CarrierAccountOwner": null,
            "IsElectioService": false,
            "QuoteReference": "f6374a18-a6b5-48c1-841c-aa3f00e9951a",
            "CreationDate": "2019-04-30T14:10:26.8551633+00:00",
            "ExpiryDate": "2019-05-01T00:00:00+01:00",
            "Requestor": "Andy Walton",
            "ConsignmentReference": "EC-000-05B-1CM",
            "ConsignmentReferenceProvidedByCustomer": "",
            "MpdCarrierServiceReference": "MPD_RMDBPR1STPSU"
        },
        {
            "MpdCarrierServiceSource": 2,
            "MpdCarrierService": "Tracked 48 Signed For",
            "OriginAddress": {
                "ShippingLocationReference": "EDC5_Electio",
                "AddressLine1": "Third Floor",
                "AddressLine2": "Merchant Exchange",
                "AddressLine3": "Whitworth Street West",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "SpecialInstructions": "",
                "IsCached": false
            },
            "DestinationAddress": {
                "AddressLine1": "13 Porter Street",
                "AddressLine2": "Pressington",
                "AddressLine3": "Carlsby",
                "Town": "Manchester",
                "Region": "Greater Manchester",
                "Postcode": "M1 5WG",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "SpecialInstructions": "Gate code: 4454",
                "IsCached": false
            },
            "CollectionDate": "2019-05-01T00:00:00",
            "EarliestDeliveryDate": "2019-05-03T00:00:00",
            "LatestDeliveryDate": "2019-05-03T23:59:00",
            "BasePrice": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
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
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "VatRate": {
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
            "Surcharges": [],
            "Legs": [
                {
                    "JourneyStage": 1,
                    "CarrierService": {
                        "Reference": "RMDTPS48HNAST",
                        "Name": "Tracked 48 Signed For",
                        "CarrierReference": "ROYAL_MAIL",
                        "CarrierName": null,
                        "IsDropOff": false,
                        "IsPickUp": false,
                        "IsTimed": false
                    },
                    "CarrierAccountReference": "RM1",
                    "DeliveryHub": null,
                    "CostItems": null,
                    "VolumetricParcelWeight": null,
                    "CollectionType": "NotApplicable"
                }
            ],
            "CarrierAccountOwner": null,
            "IsElectioService": false,
            "QuoteReference": "f63bd4ab-d519-4547-b361-aa3f00e9951a",
            "CreationDate": "2019-04-30T14:10:26.8551633+00:00",
            "ExpiryDate": "2019-05-01T00:00:00+01:00",
            "Requestor": "Andy Walton",
            "ConsignmentReference": "EC-000-05B-1CM",
            "ConsignmentReferenceProvidedByCustomer": "",
            "MpdCarrierServiceReference": "MPD_RMDTPS48HNAST"
        }
    ],
    "Message": null,
    "UnqualifiedServices": [
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "acceptanceTestCarrier_825d",
            "MpdCarrierServiceReference": "acceptanceTestCarrier_f8fe",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": false,
            "Rates": false,
            "MpdCarrierService": "Express With Signature Parcel",
            "MpdCarrierServiceReference": "MPD_ANPOS-00001",
            "ExclusionReason": "This service is not available for the selected collection/delivery dates."
        },
        {
            "Available": false,
            "Rates": true,
            "MpdCarrierService": "Next Day Monday - Saturday",
            "MpdCarrierServiceReference": "MPD_MNZIS-00001",
            "ExclusionReason": "This service is not available between the selected addresses."
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS EXPRESS (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHEXDCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS EXPRESS (Saturday Delivery, Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHEXSDDCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS EXPRESS PLUS (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHEP",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS SAVER (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHSADCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": true,
            "Rates": false,
            "MpdCarrierService": "UPS STANDARD (Delivery Confirmation Signature Required)",
            "MpdCarrierServiceReference": "EDC5_UPSHSTDCS",
            "ExclusionReason": "No cost and/or pricing data configured"
        },
        {
            "Available": false,
            "Rates": false,
            "MpdCarrierService": "wnDirect International Economy",
            "MpdCarrierServiceReference": "MPD_WNDECOM",
            "ExclusionReason": "This service is not available between the selected addresses. This service is not available for the given package dimensions/weight."
        }
    ]
}
```

```xml
<?xml version="1.0"?>
<QuoteResult xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Quotes">
    <QuoteRequestReference>ef3b878b-930e-4a8d-8990-aa70009c9ecb</QuoteRequestReference>
    <Quotes>
        <Quote>
            <QuoteReference>72b23d6b-15a9-4925-af0f-aa70009ca110</QuoteReference>
            <Requestor>Andy Walton</Requestor>
            <CreationDate>2019-06-18T09:30:16.1575456+00:00</CreationDate>
            <ExpiryDate>2019-06-18T15:30:00.0000000+01:00</ExpiryDate>
            <ConsignmentReference>EC-000-05B-N44</ConsignmentReference>
            <ConsignmentReferenceProvidedByCustomer>MYCONS-098998</ConsignmentReferenceProvidedByCustomer>
            <MpdCarrierServiceReference>EDC5_UPSHSTDCS</MpdCarrierServiceReference>
            <MpdCarrierServiceSource>External</MpdCarrierServiceSource>
            <MpdCarrierService>UPS STANDARD (Delivery Confirmation Signature Required)</MpdCarrierService>
            <OriginAddress>
                <ShippingLocationReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">EDC5_Electio</ShippingLocationReference>
                <AddressLine1 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Third Floor</AddressLine1>
                <AddressLine2 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Merchant Exchange</AddressLine2>
                <AddressLine3 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Whitworth Street West</AddressLine3>
                <Town xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Manchester</Town>
                <Region xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
                <Postcode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">M1 5WG</Postcode>
                <Country xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
                    <Name>United Kingdom</Name>
                    <IsoCode>
                        <TwoLetterCode>GB</TwoLetterCode>
                    </IsoCode>
                </Country>
                <SpecialInstructions xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
            </OriginAddress>
            <DestinationAddress>
                <AddressLine1 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">13 Porter Street</AddressLine1>
                <AddressLine2 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pressington</AddressLine2>
                <AddressLine3 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Carlsby</AddressLine3>
                <Town xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Manchester</Town>
                <Region xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Greater Manchester</Region>
                <Postcode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">M1 5WG</Postcode>
                <Country xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
                    <Name>United Kingdom</Name>
                    <IsoCode>
                        <TwoLetterCode>GB</TwoLetterCode>
                    </IsoCode>
                </Country>
                <SpecialInstructions xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Gate code: 4454</SpecialInstructions>
            </DestinationAddress>
            <CollectionDate>2019-06-18T17:00:00.0000000+00:00</CollectionDate>
            <EarliestDeliveryDate>2019-06-19T00:00:00.0000000+00:00</EarliestDeliveryDate>
            <LatestDeliveryDate>2019-06-19T23:30:00.0000000+00:00</LatestDeliveryDate>
            <BasePrice>
                <Net xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">5.49</Net>
                <Gross xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">6.59</Gross>
                <TaxRate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Reference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB-0.200364298724954463</Reference>
                    <CountryIsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                    <Type xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                    <Rate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.200364298724954463</Rate>
                </TaxRate>
                <VatAmount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">1.10</VatAmount>
                <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Name xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                    <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                </Currency>
            </BasePrice>
            <Price>
                <Net xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">5.49</Net>
                <Gross xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">6.59</Gross>
                <TaxRate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Reference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB-0.200364298724954463</Reference>
                    <CountryIsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                    <Type xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                    <Rate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.200364298724954463</Rate>
                </TaxRate>
                <VatAmount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">1.10</VatAmount>
                <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Name xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                    <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                </Currency>
            </Price>
            <Surcharges />
            <Legs>
                <Leg>
                    <JourneyStage xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">1</JourneyStage>
                    <CarrierService xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
                        <Reference>UPSHSTDCS</Reference>
                        <Name>UPS STANDARD (Delivery Confirmation Signature Required)</Name>
                        <CarrierReference>UPS</CarrierReference>
                        <IsDropOff>false</IsDropOff>
                        <IsPickUp>false</IsPickUp>
                        <IsTimed>false</IsTimed>
                        <IsTracked>true</IsTracked>
                        <IsSigned>true</IsSigned>
                        <ServiceDirection>Inbound Outbound</ServiceDirection>
                    </CarrierService>
                    <CarrierAccountReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">EDC5_UPS</CarrierAccountReference>
                    <CollectionType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">NotApplicable</CollectionType>
                    <Metadata xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
                </Leg>
            </Legs>
            <IsElectioService>false</IsElectioService>
            <ServiceDirection>Inbound Outbound</ServiceDirection>
        </Quote>
        <Quote>
            <QuoteReference>587ca570-b400-41b5-8b47-aa70009ca110</QuoteReference>
            <Requestor>Andy Walton</Requestor>
            <CreationDate>2019-06-18T09:30:16.1575456+00:00</CreationDate>
            <ExpiryDate>2019-06-18T15:30:00.0000000+01:00</ExpiryDate>
            <ConsignmentReference>EC-000-05B-N44</ConsignmentReference>
            <ConsignmentReferenceProvidedByCustomer>MYCONS-098998</ConsignmentReferenceProvidedByCustomer>
            <MpdCarrierServiceReference>EDC5_UPSHSADCS</MpdCarrierServiceReference>
            <MpdCarrierServiceSource>External</MpdCarrierServiceSource>
            <MpdCarrierService>UPS SAVER (Delivery Confirmation Signature Required)</MpdCarrierService>
            <OriginAddress>
                <ShippingLocationReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">EDC5_Electio</ShippingLocationReference>
                <AddressLine1 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Third Floor</AddressLine1>
                <AddressLine2 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Merchant Exchange</AddressLine2>
                <AddressLine3 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Whitworth Street West</AddressLine3>
                <Town xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Manchester</Town>
                <Region xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
                <Postcode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">M1 5WG</Postcode>
                <Country xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
                    <Name>United Kingdom</Name>
                    <IsoCode>
                        <TwoLetterCode>GB</TwoLetterCode>
                    </IsoCode>
                </Country>
                <SpecialInstructions xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
            </OriginAddress>
            <DestinationAddress>
                <AddressLine1 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">13 Porter Street</AddressLine1>
                <AddressLine2 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pressington</AddressLine2>
                <AddressLine3 xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Carlsby</AddressLine3>
                <Town xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Manchester</Town>
                <Region xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Greater Manchester</Region>
                <Postcode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">M1 5WG</Postcode>
                <Country xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
                    <Name>United Kingdom</Name>
                    <IsoCode>
                        <TwoLetterCode>GB</TwoLetterCode>
                    </IsoCode>
                </Country>
                <SpecialInstructions xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Gate code: 4454</SpecialInstructions>
            </DestinationAddress>
            <CollectionDate>2019-06-18T17:00:00.0000000+00:00</CollectionDate>
            <EarliestDeliveryDate>2019-06-19T00:00:00.0000000+00:00</EarliestDeliveryDate>
            <LatestDeliveryDate>2019-06-19T12:00:00.0000000+00:00</LatestDeliveryDate>
            <BasePrice>
                <Net xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">7.49</Net>
                <Gross xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">8.99</Gross>
                <TaxRate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Reference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB-0.200267022696929239</Reference>
                    <CountryIsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                    <Type xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                    <Rate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.200267022696929239</Rate>
                </TaxRate>
                <VatAmount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">1.50</VatAmount>
                <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Name xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                    <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                </Currency>
            </BasePrice>
            <Price>
                <Net xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">7.49</Net>
                <Gross xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">8.99</Gross>
                <TaxRate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Reference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB-0.200267022696929239</Reference>
                    <CountryIsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GB</CountryIsoCode>
                    <Type xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Standard</Type>
                    <Rate xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">0.200267022696929239</Rate>
                </TaxRate>
                <VatAmount xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">1.50</VatAmount>
                <Currency xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Rates">
                    <Name xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Pound Sterling</Name>
                    <IsoCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">GBP</IsoCode>
                </Currency>
            </Price>
            <Surcharges />
            <Legs>
                <Leg>
                    <JourneyStage xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">1</JourneyStage>
                    <CarrierService xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">
                        <Reference>UPSHSADCS</Reference>
                        <Name>UPS SAVER (Delivery Confirmation Signature Required)</Name>
                        <CarrierReference>UPS</CarrierReference>
                        <IsDropOff>false</IsDropOff>
                        <IsPickUp>false</IsPickUp>
                        <IsTimed>false</IsTimed>
                        <IsTracked>true</IsTracked>
                        <IsSigned>true</IsSigned>
                        <ServiceDirection>Inbound Outbound</ServiceDirection>
                    </CarrierService>
                    <CarrierAccountReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">EDC5_UPS</CarrierAccountReference>
                    <CollectionType xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">NotApplicable</CollectionType>
                    <Metadata xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
                </Leg>
            </Legs>
            <IsElectioService>false</IsElectioService>
            <ServiceDirection>Inbound Outbound</ServiceDirection>
        </Quote>
    </Quotes>
    <UnqualifiedServices>
        <UnqualifiedService>
            <Available>true</Available>
            <Rates>false</Rates>
            <MpdCarrierService>acceptanceTestCarrier_825d</MpdCarrierService>
            <MpdCarrierServiceReference>acceptanceTestCarrier_f8fe</MpdCarrierServiceReference>
            <ExclusionReason>No cost and/or pricing data configured</ExclusionReason>
        </UnqualifiedService>
        <UnqualifiedService>
            <Available>false</Available>
            <Rates>false</Rates>
            <MpdCarrierService>Express With Signature Parcel</MpdCarrierService>
            <MpdCarrierServiceReference>MPD_ANPOS-00001</MpdCarrierServiceReference>
            <ExclusionReason>This service is not available for the selected collection/delivery dates.</ExclusionReason>
        </UnqualifiedService>
        <UnqualifiedService>
            <Available>false</Available>
            <Rates>true</Rates>
            <MpdCarrierService>Next Day Monday - Saturday</MpdCarrierService>
            <MpdCarrierServiceReference>MPD_MNZIS-00001</MpdCarrierServiceReference>
            <ExclusionReason>This service is not available between the selected addresses.</ExclusionReason>
        </UnqualifiedService>
        <UnqualifiedService>
            <Available>false</Available>
            <Rates>false</Rates>
            <MpdCarrierService>wnDirect International Economy</MpdCarrierService>
            <MpdCarrierServiceReference>MPD_WNDECOM</MpdCarrierServiceReference>
            <ExclusionReason>This service is not available between the selected addresses. This service is not available for the given package dimensions/weight.</ExclusionReason>
        </UnqualifiedService>
    </UnqualifiedServices>
</QuoteResult>
```

Once you've created your consignment, you'll need to use the **[Get Quotes by Consignment Reference](https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference)** endpoint to get some delivery quotes for it.

**Get Quotes by Consignment Reference** returns quotes based on the details of an existing consignment. Specifically, it takes a `{consignmentReference}` as a path parameter and returns an array of `{Quotes}` for that consignment, as well as a list of services that were unable to quote for the consignment. 

Each `{Quote}` object contains details on carrier service, dates, addresses, and price, amongst other information. Pay particular attention to the `{quoteReference}`, as you'll need this when you select a quote in the next step.

<aside class="note">
  For full reference information on the <strong>Get Quotes by Consignment Reference</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference">Get Quotes by Consignment Reference</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows a **Get Quotes by Consignment Reference** request and its accompanying response. In this case, SortedPRO has returned two quotes for the service. The next step in the process is to select one of those quotes.

