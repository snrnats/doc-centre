---
uid: pro-api-help-brexit-guide
title: Brexit Data Guide
tags: v1,allocation,pro,api,consignments,brexit
contributors: andy.walton@sorted.com
created: 24/09/2020
---
# Brexit Data Guide

The UK's departure from the EU has resulted in some changes to the data required for international shipments in PRO. This page details the consignment data needed to generate customs documentation in PRO and allocate international shipments to DPD, Hermes, Parcelforce, Yodel, Royal Mail, DHL, or P2P.

---

## Customs Documentation Required Data

The following consignment properties are required in order for PRO to generate CN22, CN23, and commercial invoice documents. 

> [!NOTE]
>
> PRO enables you to create consignments either by making a **Create Consignment** API request, or by using the manual consignment creation page in the UI. Note that validation requirements are slightly different for these two methods.

| Description | PRO Data   Element | PRO APIs | PRO User   Interface |
|:-:|:-:|:-:|:-:|
| Delivery   Town  | Addresses>   Destination<br/>     Address>Town |   | n/a |
| Exporter Address | Addresses   >Exporter |   | n/a |
| Category Type | CustomsDocumentation   > CategoryType > | Yes | Yes |
| Declaration Date | CustomsDocumentation   > DeclarationDate | Yes | Mandatory |
| Declaration Name | CustomsDocumentation   > Designated PersonResponsible | Yes | Mandatory |
| Invoice Date | CustomsDocumentation   > InvoiceDate | Yes | Mandatory |
| Consignment Carriage Value | CustomsDocumentation   > ReceiversShippingCost | No | n/a |
| Shipper's VAT Number | CustomsDocumentation   > ShippersVatNumber | Yes | Optional |
| Shipping Terms | CustomsDocumentation   > ShippingTerms > | Yes | Mandatory |
| Receiver's EORI | Order   > Metadata<br/>     Consignment > Metadata <br/>     Key Value: ReceiversEORI | No | n/a |
| Shipper's EORI | Order   > Metadata<br/>     Consignment > Metadata <br/>     Key Value: ShippersEORI | Yes | n/a |
| Carriage Value Currency | Order   > Metadata<br/>     Consignment > Metadata<br/>     Key Value: CarriageCurrency | No | n/a |
| Package Description | `Package` >   Description | Yes | Mandatory |
| Height | `Package` >   Dimensions > Height |   | Mandatory |
| Length | `Package` >   Dimensions > Length |   | Mandatory |
| Package Unit of Dimension | `Package` >   Dimensions > Unit |   | Mandatory |
| Package Width | `Package` >   Dimensions > Width |   | Mandatory |
| Maximum number of items | `Package` > Item   > | Unbounded | Unbounded |
| Minimum number of items | `Package` > Item   > | 1 | 0 |
| Country of Origin | `Package` > Item   > CountryOfOrigin | Yes |   |
| Item Description | `Package` > Item   > Description | Yes |   |
| Harmonisation Code | `Package` > Item   > HarmonisationCode | Yes |   |
| Quantity | `Package` > Item   > Quantity |   |   |
| Item Value | Package   > Item > Value > Money > Amount | Yes | Conditional:  Required if an item is provided |
| Currency | Package   > Item > Value > Money > Currency > IsoCode | Yes | Conditional:  Required if an item is provided |
| Item Weight | `Package` > Item   > Weight > Value |   | Conditional:  Required if an item is provided |
| Item unit of Weight | `Package` > Item   > Weight > Weight Unit |   | Conditional:  Required if an item is provided |
| Duty Paid Value | Package   > Metadata <br/>     Key Value: DutyPaidValue |   | n/a |
| Package VAT Value | Package   > Metadata <br/>     Key Value: VatValue |   | Not Available |
| Package Value | `Package` > Value   > Money > Amount | Yes | Mandatory |
| Package Currency | `Package` > Value   > Money > Currency > IsoCode | Yes | Mandatory |
| Package Unit of Weight | `Package` > Weight   > Unit |   | Mandatory |
| Package Weight | `Package` > Weight   > Value |   | Mandatory |

## Carrier Data Requirements

This section shows the consignment data required to ship internationally with specific carriers, and the shipping routes that these restrictions apply to for each carrier. When allocating a consignment that will use one of these routes, PRO only considers that consignment for allocation to a particular carrier if the consignment meets the carrier's data requirements.

### Affected Routes

* **DPD** - Customs document not required. Non-GB Destinations for the following routes:
     * DPD INTERNATIONAL: GB to EU & Non-EU
     * DPD UK DOMESTIC: GB to IE, JE & GG
     * DPD LOCAL: GB to IE, JE & GG
* **HERMES INTL** - Commercial Invoice document required. The following routes are affected:
     * GB to Non-GB Destinations
     * Non-GB Origin to GB
     * GB to Northern Ireland
* **PARCELFORCE INTL** - Customs document required. Affects GB to all non-GB destinations
    > [!NOTE]
    > Parcelforce's **Euro Priority Business** and **Euro Priority Home** services have been renamed to **Euro Priority** and **Euro Economy Home** respectively. This name change does not affect the services in any way.

* **YODEL** - Customs document not required. Affects all GB to Northern Ireland & Channel Islands routes. 
    > [!NOTE]
    > Northern Ireland Addresses will have a Country of GB & the postcode prefix (Postcode Area) will always be "BT".
* **ROYAL MAIL INTL** - CN22 and CN23 customs documents required. Affects GB to all non-GB destinations.
* **DHL** -  Commercial invoice or PLT required. Affects GB to all non GB destinations, and GB to Northern Ireland.
* **P2P** - Customs document required. Affects GB to all non-GB destinations.

### Data 

Click the image below to view the Brexit shipping data table at full width.

<img src="/pro/images/brexit-table-clickable.png" id="myBtn" class="modalImage"/>

<div id="myModal" class="modal">
<div class="modal-content">
<span class="close">&times;</span>

| PRO Data Element | DPD  | HERMES ROTW | PARCELFORCE INTL | YODEL | ROYAL MAIL | DHL EXPRESS | P2P |
|:-:|:-:|:-:|:-:|:-:|:-:|
| `Addresses` ><br/> `Destination Address` > `Town` |   |   |   |   | Mandatory |
| `Addresses` > `Exporter` |      Must be provided if different from the Origin Address. If required please   provide either Shipping Location Reference or all of AddressLine1, Region,   Postcode, Country, Email  and one or   more of Telephone, Mobile and Landline<br/><br/> If an Exporter Address has not been provided then PRO uses the Origin Address. |   |   |   |   |
| `CustomsDocumentation` ><br/> `CategoryType` | Mandatory.   Permitted values:<br/>     <br/>     - Gift<br/>     - ReturnedGoods<br/>     - SaleOfGoods:  To be made available   in Q1, 2020<br/>     - Documents<br/>     - Other<br/>     - None |   | Mandatory.   Permitted values:<br/>     <br/>     - Gift<br/>     - Commercial Sample<br/>     - Documents<br/>     - Other | Mandatory.   Permitted values:<br/>     <br/>     - Gift<br/>     - Sales<br/>     - Sample<br/>     - Personal | Mandatory.   Permitted values:<br/>     <br/>     - Gift<br/>     - Commercial Sample<br/>     - Documents<br/>     - Other |
| `CustomsDocumentation` ><br/> `DesignatedPersonResponsible` |   |   |   |   | Mandatory | 
| `CustomsDocumentation` ><br/> `InvoiceDate` |   |   | Mandatory for Euro Priority service | |   |   |   |   |
| `CustomsDocumentation` ><br/> `ReceiversShippingCost` |   |   |   | Mandatory - total   consignment carriage value |   |
| `CustomsDocumentation` ><br/> `ShippersVatNumber` | Mandatory for EU   and Rest of World<br/>     Pass "GBUNREG" if not VAT registered | Mandatory   for EU and Rest of World | Mandatory for EU and   ROW | Mandatory   if DDP Shipping Term is selected, otherwise conditional |   |
| `CustomsDocumentation` ><br/> `ShippingTerms` | Mandatory. Only values of DAP or DDP are accepted. | Mandatory.   Home Delivery must use values of DDU or DDP or DAP. Parcelshop services should use DDP only | Mandatory.   Must use values of DDU or DDP<br/>     <br/>      | Mandatory.   Must use a value of DDU only |   | Mandatory | Mandatory |
| `Order` ><br/> `Metadata`<br/><br/> `Consignment` ><br/> `Metadata` <br/><br/>  Key Value: `ReceiversEORI`<br/><br/> See [Adding Metadata Properties](#adding-metadata-properties)<br/> for info on using<br/> `Metadata` to record properties | Mandatory if the destination address is a business, otherwise conditional |   | Required if the   receiver is a business, otherwise optional |   |   |
| `Order` ><br/> `Metadata`<br/><br/> `Consignment` ><br/> `Metadata` <br/><br/>  Key Value: `ShippersEORI`<br/><br/> See [Adding Metadata Properties](#adding-metadata-properties)<br/> for info on using<br/> `Metadata` to record properties | Mandatory for EU   and Rest of World<br/>     Pass "GBUNREG" if not VAT registered<br/>     <br/>      | Mandatory   for Commercial Invoice | Mandatory   for EU and Rest of World | Mandatory | Mandatory | Recommended for EU | Recommended for EU |
| `Order` ><br/> `Metadata`<br/><br/> `Consignment` ><br/> `Metadata` <br/><br/>  Key Value: `CarriageCurrency`<br/><br/> See [Adding Metadata Properties](#adding-metadata-properties)<br/> for info on using<br/> `Metadata` to record properties |   |   |   | The currency of the   Carriage Value provided | The currency of the Carriage Value   provided |
| `Package` > `Description` | Mandatory  |   | Mandatory |   |   |
| `Package` > `Item` | Unbounded | Unbounded | Unbounded | 10 |   |
| `Package` > `Item` | 1 | 1 | 1 | 1 |   |
| `Package` > `Item` ><br/> `CountryOfOrigin` | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory | | Mandatory |
| `Package` > `Item` ><br/> `Description` | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| `Package` > `Item` ><br/> `HarmonisationCode` | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory if dutiable | Mandatory |
| `Package` > `Item` ><br/> `Quantity` | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| `Package` > `Item` ><br/> `Value` > `Money` ><br/> `Amount` | Mandatory |   | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| `Package` > `Item` ><br/> `Value` > `Money` ><br/> `Currency` > `IsoCode` | Mandatory |   | Mandatory | Mandatory | Mandatory | Mandatory | Mandatory |
| `Package` > `Item` ><br/> `Weight` > `Value` | Mandatory | Mandatory | Mandatory |   | Mandatory |
| `Package` > `Item` ><br/> `Weight` > `Weight Unit` | Mandatory  |   | Mandatory |   |   |
| `Package` > `Metadata` <br/> Key Value: `DutyPaidValue`<br/><br/> See [Adding Metadata Properties](#adding-metadata-properties)<br/> for info on using<br/> `Metadata` to record properties |   | Conditional.   Must be provided if the ShippingTerms = "DDP" |   |   |   |
| `Package` > `Metadata` <br/> Key Value: `VatValue`<br/><br/> See [Adding Metadata Properties](#adding-metadata-properties)<br/> for info on using<br/> `Metadata` to record properties |   | Conditional.   Must be provided if the ShippingTerms = "DDP" |   |   |   |
| `Package` > `Value` > `Money` ><br/> `Amount` | Mandatory |   | Mandatory |   |   |
| `Package` > `Value` > `Money` ><br/> `Currency` > `IsoCode` | Mandatory |   | Mandatory |   |   |


</div>
</div>

## Adding Metadata Properties 

Some required fields for international shipments do not have a dedicated property in the PRO consignments data contract. You will need to record information for each of these fields using a `Metadata` property with a specific `KeyValue`.

The table below lists the fields that should be recorded as metadata, and their accompanying `KeyValues`.

| Property | KeyValue |
|-|-|
| Shipper's EORI| `ShippersEORI` |
| Receiver's EORI| `ReceiversEORI` |
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

<script src="/pro/scripts/modal.js"></script>