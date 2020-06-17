---
uid: pro-api-help-flows-quotes-flow
title: Quotes Flow
tags: pro,api,consignments,flows,quotes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 15/04/2020
---
# Quotes Flow

<p>
   <a href="../../../images/Flow6.png" target="_blank" >
      <img src="../../../images/Flow6.png" class="noborder"/>
   </a>
</p>

The **Quotes** flow is intended as a back-end customer service integration to help you resolve delivery issues that require manual intervention. In this flow, a consignment is created and then allocated to a carrier service based on a specific quote for that consignment.

The **Quotes** flow is useful to your business for:

* Customer contact centre use.
* In store delivery booking.
* ERP workflows (e.g. SAP, Oracle).

There are five steps to the flow:

1. **Create the consignment** - Use the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) endpoint to record the details of a new consignment.
2. **Get quotes for the consignment** - Use the [Get Quotes by Consignment Reference](https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference) endpoint to get delivery quotes for the consignment.
3. **Select a quote** - Use the [Allocate With Quote](https://docs.electioapp.com/#/api/AllocateWithQuote) endpoint to select one of the returned quotes.
4. **Get the consignment's labels** - Use the [Get Labels in Format](https://docs.electioapp.com/#/api/GetLabelsinFormat) endpoint to get the delivery label for your consignment.
5. **Manifest the consignment** - Use the [Manifest Consignments from Query](https://docs.electioapp.com/#/api/ManifestConsignmentsFromQuery) endpoint to confirm the consignment with the selected carrier. At this point, the consignment is ready to ship.

This section gives more detail on each step of the flow and provides worked examples.

---

## Step 1: Creating Consignments

[!include[_create_consignments](../../includes/_create_consignments.md)]

---

## Step 2: Getting Quotes by Consignment Reference

[!include[_get_quotes_by_con_ref](../../includes/_get_quotes_by_con_ref.md)]

---

## Step 3: Selecting a Quote

[!include[_allocate_with_quote](../../includes/_allocate_with_quote.md)]

---

## Step 4: Getting Consignment Labels

[!include[_get_labels_in_format](../../includes/_get_labels_in_format.md)]

---

## Step 4b (Optional): Getting Customs Docs

[!include[_get_customs_docs](../../includes/_get_customs_docs.md)]

---

## Step 5: Manifesting a Consignment

[!include[_manifest_consignments_from_query](../../includes/_manifest_consignments_from_query.md)]
