---
uid: pro-api-help-brexit-guide
title: Brexit Data Guide
tags: allocation,pro,api,consignments,brexit
contributors: andy.walton@sorted.com
created: 24/09/2020
---
# Brexit Data Guide

The UK's departure from the EU has resulted in some changes to the data required for international shipments in PRO. This page details the consignment data needed to generate customs documentation in PRO and allocate international shipments to DPD, Hermes, Parcelforce, or Yodel.

---

## Customs Documentation Required Data

The following consignment properties are required in order for PRO to generate CN22, CN23, and commercial invoice documents. 

> [!NOTE]
>
> PRO enables you to create consignments either by making a **Create Consignment** API request, or by using the manual consignment creation page in the UI. Note that validation requirements are slightly different for these two methods.

| Description               | PRO Data Element                                                | PRO APIs |             PRO UI              |
| :------------------------ | :-------------------------------------------------------------- | :------: | :-----------------------------: |
| Category Type             | `CustomsDocumentation` > `CategoryType`                         | Required |            Required             |
| Country of Origin         | `Package` > `Item` > `CountryOfOrigin`                          | Required |                                 |
| Currency                  | `Package` > `Item` > `Value` > `Money` > `Currency` > `IsoCode` | Required | Required if an item is provided |
| Declaration Date          | `CustomsDocumentation` > `DeclarationDate`                      | Required |            Required             |
| Harmonisation Code        | `Package` > `Item` > `HarmonisationCode`                        | Required |                                 |
| Height                    | `Package` > `Dimensions` > `Height`                             |          |            Required             |
| Invoice Date              | `CustomsDocumentation` > `InvoiceDate`                          | Required |            Required             |
| Item Description          | `Package` > `Item` > `Description`                              | Required |                                 |
| Item Value                | `Package` > `Item` > `Value` > `Money` > `Amount`               | Required | Required if an item is provided |
| Item Weight               | `Package` > `Item` > `Weight` > `Value`                         |          | Required if an item is provided |
| Item unit of Weight       | `Package` > `Item` > `Weight` > `Weight Unit`                   |          | Required if an item is provided |
| Length                    | `Package` > `Dimensions` > `Length`                             |          |            Required             |
| Minimum number of items   | `Package` > `Item`                                              |    1     |                0                |
| Package Currency          | `Package` > `Value` > `Money` > `Currency` > `IsoCode`          | Required |            Required             |
| Package Description       | `Package` > `Description`                                       | Required |            Required             |
| Package Unit of Dimension | `Package` > `Dimensions` > `Unit`                               |          |            Required             |
| Package Unit of Weight    | `Package` > `Weight` > `Unit`                                   |          |            Required             |
| Package Value             | `Package` > `Value` > `Money` > `Amount`                        | Required |            Required             |
| Package Weight            | `Package` > `Weight` > `Value`                                  |          |            Required             |
| Package Width             | `Package` > `Dimensions` > `Width`                              |          |            Required             |
| Shipper's EORI            | `Order`/`Consignment` > `Metadata` (`KeyValue`:_ShippersEORI_)   | Required |                                 |
| Shipper's VAT Number      | `CustomsDocumentation` > `ShippersVatNumber`                    | Required |            Optional             |
| Shipping Terms            | `CustomsDocumentation` > `ShippingTerms`                        | Required |            Required             |

## DPD Required Data

When allocating international consignments, PRO only returns DPD services if the consignment contains the following properties:

| Description | PRO Data Element  | Validation      |
| --------- | -- | ----- |
| Category Type | `CustomsDocumentation`>`CategoryType`   | Must have one of the following values:<br> <br>- Gift<br>- ReturnedGoods <br>- SaleOfGoods (To be made available in Q1, 2020)<br>- Documents<br>- Other<br>- None  |
| Country of Origin       | `Package` > `Item` > `CountryOfOrigin`  | Mandatory  |
| Currency                | `Package` > `Item` > `Value` > `Money` > `Currency` > `IsoCode`  | Mandatory  |
| Exporter Address        | `Addresses` > `Exporter`     | Mandatory if different from the Origin Address<br> <br> Where provided, must contain either a `ShippingLocationReference` or a combination of `AddressLine1`, `Region`, `Postcode`, `Country`, `Email`, one or more of `Telephone`, `Mobile` and `Landline`<br> <br> If you do not specify an Exporter Address, then PRO uses the Origin Address. |
| Harmonisation Code      | `Package` > `Item` > `HarmonisationCode`    | Mandatory   |
| Item Description        | `Package` > `Item` > `Description` | Mandatory    |
| Item Value              | `Package` > `Item` > `Value` > `Money` > `Amount`    | Mandatory   |
| Item Weight             | `Package` > `Item` > `Weight` > `Value`     | Mandatory      |
| Item unit of Weight     | `Package` > `Item` > `Weight` > `Weight Unit`    | Mandatory   |
| Maximum number of items | `Package` > `Item`   | Unbounded   |
| Minimum number of items | `Package` > `Item`  | 1    |
| Package Currency        | `Package` > `Value` > `Money` > `Currency` > `IsoCode`    | Mandatory    |
| Package Description     | `Package` > `Description`     | Mandatory     |
| Package Value           | `Package` > `Value` > `Money` > `Amount`    | Mandatory    |
| Quantity                | `Package` > `Item` > `Quantity`     | Mandatory       |
| Receiver's EORI         | `Order` / `Consignment` > `Metadata` > `KeyValue`= _ReceiversEORI_ | Mandatory if the destination address is a business. <br/><br/> See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |
| Shipper's EORI          | `Order` / `Consignment` > `Metadata` > `KeyValue`= _ShippersEORI_ | Mandatory if the destination address is a business. <br/><br/> See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property.  |
| Shipper's VAT Number    | `CustomsDocumentation` > `ShippersVatNumber` | Pass a value of _GBUNREG_ if the shipper is not VAT registered   |
| Shipping Terms          | `CustomsDocumentation` > `ShippingTerms`      | DPD only accepts value of _DAP_ or _DDP_. <br/> _DDU_ is translated to _DAP_ when manifesting to DPD. DPD services will not be returned in any Quote, Allocation or Delivery Option for consignments that have any other value. result.     |

## Hermes Required Data

When allocating international consignments, PRO only returns Hermes services if the consignment contains the following properties:

| Description | PRO Data Element | Validation |
|-|-|-|
| Shipper's VAT Number | `CustomsDocumentation`   > `ShippersVatNumber` | Mandatory |
| Shipping Terms | `CustomsDocumentation`  > `ShippingTerms` | For home deliveries, must have a value of _DDU_, _DDP_, or _DAP_. _DAP_ is mapped as _DDU_ when manifested to Hermes<br><br/> Parcelshop consignments should use _DDP_ only |
| Shipper's EORI          | `Order` / `Consignment` > `Metadata` > `KeyValue`= _ShippersEORI_ | Mandatory in order to generate commercial invoices. <br/><br/> > See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property.  |
| Minimum number of items | `Package` > `Item` | 1 |
| Country of Origin | `Package` > `Item` > `CountryOfOrigin` | Mandatory |
| Item Description | `Package` > `Item` > `Description` | Mandatory |
| Harmonisation Code | `Package` > `Item`  > `HarmonisationCode` | Mandatory |
| Quantity | `Package` > `Item` > `Quantity` | Mandatory |
| Item Weight | `Package` > `Item`> `Weight` > `Value` | Mandatory |
| Duty Paid Value | `Package` > `Metadata` > `KeyValue`= _DutyPaidValue_ | Must be provided if `ShippingTerms` = _DDP_<br/><br/> > See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |
| Package VAT Value | `Package` > `Metadata` > `KeyValue`= _VATValue_ | Must be provided if `ShippingTerms` = _DDP_<br/><br/> > See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |

## Parcelforce Required Data

When allocating international consignments, PRO only returns Parcelforce services if the consignment contains the following properties:

| Description | PRO Data Element | Validation |
|-|-|-|
| Category Type | `CustomsDocumentation` > `CategoryType` | <span class="highlight">Outstanding Query with ParcelForce to confirm permitted types.</span> |
| Shipper's VAT Number | `CustomsDocumentation` > `ShippersVatNumber` | Mandatory |
| Shipping Terms | `CustomsDocumentation` > `ShippingTerms` | Must have a value of either _DDU_ or _DDP_ |
| Receiver's EORI | `Order` / `Consignment` > `Metadata` > `KeyValue`= _ReceiversEORI_ | Mandatory if the destination address is a business <br/><br/> See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |
| Shipper's EORI  | `Order` / `Consignment` > `Metadata` > `KeyValue`= _ShippersEORI_ | Mandatory <br/><br/> See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |
| Package Description | `Package` > `Description` | Mandatory |
| Minimum number of items | `Package` > `Item` | 1 |
| Country of Origin | `Package` > `Item` > `CountryOfOrigin` | Mandatory |
| Item Description | `Package` > `Item` > `Description` | Mandatory |
| Harmonisation Code | `Package` > `Item` > `HarmonisationCode` | Mandatory |
| Quantity | `Package` > `Item` > `Quantity` | Mandatory |
| Item Value | `Package` > `Item` > `Value` > `Money` > `Amount` | Mandatory |
| Currency | `Package` > `Item` > `Value` > `Money` > `Currency` > `IsoCode` | Mandatory |
| Item Weight | `Package` > `Item`> `Weight` > `Value` | Mandatory |
| Item unit of Weight | `Package` > `Item` > `Weight` > `Weight Unit` | Mandatory |
| Package Value | `Package` > `Value` > `Money` > `Amount` | Mandatory |
| Package Currency | `Package` > `Value` > `Money` > `Currency` > `IsoCode` | Mandatory |

## Yodel Required Data

When allocating international consignments, PRO only returns Yodel services if the consignment contains the following properties:

| Description | PRO Data Element | Validation |
|-|-|-|
| Category Type | `CustomsDocumentation` > `CategoryType` | Must have one of the following values: <br/><br/>- Gift<br/>- SaleOfGoods  (To be made available in Q1, 2020) <br/>- Sample<br/>- Personal |
| Consignment Carriage Value | `CustomsDocumentation` > `ReceiversShippingCost` | Must contain the total consignment carriage value |
| Shipper's VAT Number | `CustomsDocumentation` > `ShippersVatNumber` | Mandatory if `ShippingTerm` has a value of _DDP_ is selected |
| Shipping Terms | `CustomsDocumentation` > `ShippingTerms` | Must have a value of _DDU_ |
| Shipper's EORI  | `Order` / `Consignment` > `Metadata` > `KeyValue`= _ShippersEORI_ | Mandatory <br/><br/> See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |
| Carriage Value Currency  | `Order` / `Consignment` > `Metadata` > `KeyValue`= _CarriageCurrency_ | Mandatory <br/><br/> See the [Adding Metadata Properties](#adding-metadata-properties) section for further information on using the `Metadata` property. |
| Maximum number of items | `Package` > `Item`| 10 |
| Minimum number of items | `Package` > `Item`| 1 |
| Country of Origin | `Package` > `Item` > `CountryOfOrigin` | Mandatory <span class="highlight">3 Digit ISOCode eg GBP   ?? GBR? Or two digit country code??</span> |
| Item Description | `Package` > `Item` > `Description` | Mandatory |
| Harmonisation Code | `Package` > `Item` > `HarmonisationCode` | Mandatory |
| Quantity | `Package` > `Item` > `Quantity` | Mandatory |
| Item Value | `Package` > `Item` > `Value` > `Money` > `Amount` | Mandatory |
| Currency | `Package` > `Item` > `Value` > `Money` > `Currency` > `IsoCode` | Mandatory |

## Adding Metadata Properties 

Some required fields for international shipments do not have a dedicated property in the PRO consignments data contract. You will need to record information for each of these fields using a `Metadata` property with a specific `KeyValue`.

The table below lists the fields that should be recorded as metadata, and their accompanying `KeyValues`.

| Property | KeyValue |
|-|-|
| Shipper's EORI| `ReceiversEORI` |
| Receiver's EORI| `ShippersEORI` |
| Carriage Value Currency| `CarriageCurrency` |
| Duty Paid Value| `DutyPaidValue` |
| Package VAT Value| `VatValue` |

The example below shows a `ShippersEORI` value recorded using the `Metadata` property. The `KeyValue` denotes to PRO that this is a Shipper's EORI, and the `StringValue` contains the EORI itself.

# [EORI Number Example](#tab/eori-number-example)

```json
{
    "ConsignmentReferenceProvidedByCustomer": "YOUR-REF",
    "Addresses": [
        // addresses
    ],
    "Packages": [
        // package properties
    ],
    "Metadata": [
        {
            "KeyValue": "ShippersEORI",
            "StringValue": "GB987654312000"
        }
    ]
    // other consignment properties
}

```
---

> [!NOTE]
> For more information on commercial invoices and other customs documents in PRO, see the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page. 

## Next Steps

* Learn how to allocate consignments at the [Allocating Consignments](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.