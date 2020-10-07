---
uid: pro-api-help-brexit-guide
title: Brexit Data Guide
tags: allocation,pro,api,consignments,brexit
contributors: andy.walton@sorted.com
created: 24/09/2020
---
# Brexit Data Guide

The UK's departure from the EU has resulted in some changes to the data required for international shipments in PRO. This page details the consignment data needed to generate customs documentation in PRO and allocate international shipments to DPD, Hermes, Parcelforce, Yodel, or Royal Mail.

---

## Customs Documentation Required Data

The following consignment properties are required in order for PRO to generate CN22, CN23, and commercial invoice documents. 

> [!NOTE]
>
> PRO enables you to create consignments either by making a **Create Consignment** API request, or by using the manual consignment creation page in the UI. Note that validation requirements are slightly different for these two methods.

| Description | PRO Data   Element | PRO APIs:   Required for CN22, CN23 & Commercial Invoice | PRO User   Interface: Required for CN22, CN23 & Commercial Invoice |
|:-:|:-:|:-:|:-:|
| Delivery   Town  | Addresses>   Destination<br>     Address>Town |   | n/a |
| Exporter Address | Addresses   >Exporter |   | n/a |
| Category Type | CustomsDocumentation   > CategoryType > | Yes | Yes |
| Declaration Date | CustomsDocumentation   > DeclarationDate | Yes | Mandatory |
| Declaration Name | CustomsDocumentation   > Designated PersonResponsible | Yes | Mandatory |
| Invoice Date | CustomsDocumentation   > InvoiceDate | Yes | Mandatory |
| Consignment Carriage Value | CustomsDocumentation   > ReceiversShippingCost | No | n/a |
| Shipper's VAT Number | CustomsDocumentation   > ShippersVatNumber | Yes | Optional |
| Shipping Terms | CustomsDocumentation   > ShippingTerms > | Yes | Mandatory |
| Receiver's EORI | Order   > Metadata<br>     Consignment > Metadata <br>     Key Value: ReceiversEORI | No | n/a |
| Shipper's EORI | Order   > Metadata<br>     Consignment > Metadata <br>     Key Value: ShippersEORI | Yes | n/a |
| Carriage Value Currency | Order   > Metadata<br>     Consignment > Metadata<br>     Key Value: CarriageCurrency | No | n/a |
| Package Description | Package >   Description | Yes | Mandatory |
| Height | Package >   Dimensions > Height |   | Mandatory |
| Length | Package >   Dimensions > Length |   | Mandatory |
| Package Unit of Dimension | Package >   Dimensions > Unit |   | Mandatory |
| Package Width | Package >   Dimensions > Width |   | Mandatory |
| Maximum number of items | Package > Item   > | Unbounded | Unbounded |
| Minimum number of items | Package > Item   > | 1 | 0 |
| Country of Origin | Package > Item   > CountryOfOrigin | Yes |   |
| Item Description | Package > Item   > Description | Yes |   |
| Harmonisation Code | Package > Item   > HarmonisationCode | Yes |   |
| Quantity | Package > Item   > Quantity |   |   |
| Item Value | Package   > Item > Value > Money > Amount | Yes | Conditional:  Required if an item is provided |
| Currency | Package   > Item > Value > Money > Currency > IsoCode | Yes | Conditional:  Required if an item is provided |
| Item Weight | Package > Item   > Weight > Value |   | Conditional:  Required if an item is provided |
| Item unit of Weight | Package > Item   > Weight > Weight Unit |   | Conditional:  Required if an item is provided |
| Duty Paid Value | Package   > Metadata <br>     Key Value: DutyPaidValue |   | n/a |
| Package VAT Value | Package   > Metadata <br>     Key Value: VatValue |   | Not Available |
| Package Value | Package > Value   > Money > Amount | Yes | Mandatory |
| Package Currency | Package > Value   > Money > Currency > IsoCode | Yes | Mandatory |
| Package Unit of Weight | Package > Weight   > Unit |   | Mandatory |
| Package Weight | Package > Weight   > Value |   | Mandatory |

## Carrier Data Requirements

The table below shows the consignment data required to ship internationally with specific carriers. PRO only considers a consignment for allocation to a particular carrier if the consignment meets that carrier's data requirements for international shipping.

| Description | PRO Data   Element | DPD  | HERMES ROTW | PARCELFORCE INTL | YODEL | ROYAL MAIL |
|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
| Delivery   Town  | Addresses>   Destination<br>     Address>Town |   |   |   |   | Mandatory |
| Exporter Address | Addresses   >Exporter |      Conditional:<br>     <br>     Must be provided if different from the Origin Address<br>     <br>     If required please provide either:<br>     <br>     ShippingLocationReference<br>     <br>     or<br>     <br>     A minmum of AddressLine1, Region, Postcde, Country, Email <br>     <br>     and <br>     <br>     One or more of Telephone, Mobile and Landline<br>     <br>     Sorted will default to Origin Address if an Exporter Address has not been   provided. |   |   |   |   |
| Category Type | CustomsDocumentation   > CategoryType > | Mandatory<br>     <br>     Permitted values:<br>     <br>     Gift<br>     ReturnedGoods<br>     SaleOfGoods:  To be made available in   Q1, 2020<br>     Documents<br>     Other<br>     None<br>     <br>     Note: Any other value will fail to return DPD services in any Quote,   Allocation or Delivery Option result.<br>      |   | Mandatory<br>     <br>     Permitted Types:<br>     <br>     Documents<br>     <br>     Outstanding Query with ParcelForce to confirm permitted   types. | Mandatory<br>     <br>     Permitted values:<br>     <br>     Gift<br>     SaleOfGoods:  To   be made available in Q1, 2020     Sample<br>     Personal<br>     <br>     Note: Any other provided value will fail to return DPD services in any   Quote, Allocation or Delivery Option result. | Mandatory<br>     <br>     Permitted values:<br>     <br>     Gift<br>     Documents<br>     Other<br>     <br>     Full list of values?      |
| Declaration Name | CustomsDocumentation   > Designated PersonResponsible |   |   |   |   | Mandatory |
| Consignment Carriage Value | CustomsDocumentation   > ReceiversShippingCost |   |   |   | Mandatory - total   consignment carriage value |   |
| Shipper's VAT Number | CustomsDocumentation   > ShippersVatNumber | Mandatory: EU   and Rest of World<br>     Pass "GBUNREG" if not VAT registered | Mandatory:   EU and Rest of World | Mandatory for EU and   ROW | Conditional:  Mandatory if DDP Shipping Term is selected |   |
| Shipping Terms | CustomsDocumentation   > ShippingTerms > | Mandatory: Only   DAP or DDP Accepted<br>     <br>     DDU will be translated to DAP when manifesting to DPD.<br>     <br>     Any other provided value will fail to return DPD services in any Quote,   Allocation or Delivery Option result. | Mandatory:   <br>     <br>     Home Delivery: DDU or DDP or DAP<br>     <br>     DAP will be mapped as DDU when manifested to Hermes<br>     <br>     Parcelshop: DDP ONLY<br>     <br>     Any other provided value will fail to return DPD services in any Quote,   Allocation or Delivery Option result. | Mandatory:   DDU or DDP<br>     <br>      | Mandatory:   DDU ONLY |   |
| Receiver's EORI | Order   > Metadata<br>     Consignment > Metadata <br>     Key Value: ReceiversEORI | Conditional:  Mandatory if the destination address is a   business. |   | Optional:  Required if the receiver is a business |   |   |
| Shipper's EORI | Order   > Metadata<br>     Consignment > Metadata <br>     Key Value: ShippersEORI | Mandatory: EU   and Rest of World<br>     <br>     Pass "GBUNREG" if not VAT registered<br>     <br>      | Mandatory:   for Commercial Invoice | Mandatory:   for EU and Rest of World | Mandatory | Mandatory |
| Carriage Value Currency | Order   > Metadata<br>     Consignment > Metadata<br>     Key Value: CarriageCurrency |   |   |   | The currency of the   Carriage Value provided | The currency of the Carriage Value   provided |
| Package Description | Package >   Description | Mandatory  |   | Mandatory |   |   |
| Maximum number of items | Package > Item   > | Unbounded | Unbounded | Unbounded | 10 |   |
| Minimum number of items | Package > Item   > | 1 | 1 | 1 | 1 |   |
| Country of Origin | Package > Item   > CountryOfOrigin | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| Item Description | Package > Item   > Description | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| Harmonisation Code | Package > Item   > HarmonisationCode | Mandatory | Mandatory | Mandatory | Manadatory | Mandatory |
| Quantity | Package > Item   > Quantity | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| Item Value | Package   > Item > Value > Money > Amount | Mandatory |   | Mandatory | Mandatory | Mandatory |
| Currency | Package   > Item > Value > Money > Currency > IsoCode | Mandatory | ?? | Mandatory | Mandatory | Mandatory |
| Item Weight | Package > Item   > Weight > Value | Mandatory | Mandatory | Mandatory |   | Mandatory |
| Item unit of Weight | Package > Item   > Weight > Weight Unit | Mandatory  |   | Mandatory |   |   |
| Duty Paid Value | Package   > Metadata <br>     Key Value: DutyPaidValue |   | Conditional:  <br>     Must be provided if the ShippingTerms = "DDP" |   |   |   |
| Package VAT Value | Package   > Metadata <br>     Key Value: VatValue |   | Conditional:  <br>     Must be provided if the ShippingTerms = "DDP" |   |   |   |
| Package Value | Package > Value   > Money > Amount | Mandatory |   | Mandatory |   |   |
| Package Currency | Package > Value   > Money > Currency > IsoCode | Mandatory |   | Mandatory |   |   |

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