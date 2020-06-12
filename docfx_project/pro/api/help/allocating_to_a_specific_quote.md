---
uid: pro-api-help-allocating-to-a-specific-quote
title: Allocating to a Specific Quote
tags: allocation,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 28/05/2020
---

# Allocating to a Specific Quote

Obtaining quotes to carry an individual consignment and then allocating to the most suitable response is a key part of many customer service workflows in PRO. This page explains how to use the **Allocate With Quote** endpoint to select a quote.

---

## Quotes Overview

In PRO, delivery quotes are generally used outside of a "regular" consignment allocation workflow, as a means of managing consignments that require manual intervention. For example, your customer service teams might want to get quotes for an expedited delivery on a consignment that was missed by a carrier and so did not meet its delivery promise. 

PRO's Quotes API enables you to get delivery quotes for both uncreated and existing consignments. All Quotes endpoints return one or more `Quote` objects, of which each represents an offer for carriage of a consignment with a specific carrier service. Each quote can be uniquely identified by a `{quoteReference}`, which is used when selecting a quote via the **Allocate With Quote** endpoint.

> [!NOTE]
>
> * For a full user guide on working with quotes, see the <a href="/pro/api/help/managing_quotes.html">Managing Quotes</a> page.
> * For reference information on the Quotes API, see the <a href="https://docs.electioapp.com/#/api/GetQuotes">API reference</a>.
> * For worked examples showing a consignment being allocated from a quote, see the <a href="/pro/api/help/flows/quotes_flow.html">Quotes</a> call flow page.

## Using Allocate With Quote

The **Allocate With Quote** endpoint enables you to allocate an individual consignment based on a specific delivery quote from a carrier. To call **Allocate With Quote**, send a `PUT` request to `https://api.electioapp.com/allocation/{consignmentReference}/allocatewithquote/{quoteReference}`, where `{consignmentReference}` corresponds to the consignment you want to allocate and `{quoteReference}` is the quote you want to select.

Once the request is received PRO attempts to allocate the consignment to the carrier service specified in the quote (as denoted by the `{MpdCarrierService}` and `MpdCarrierServiceReference` fields contained within the `Quote` object), and returns an Allocation Summary.

> [!NOTE]
>  For full reference information on the <strong>Allocate With Quote</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithQuote">Allocate With Quote</a></strong> page of the API reference.

### Allocate With Quote Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05B-N40_ to the carrier service associated with a quote that has the `{quoteReference}` _112236d5-4460-492f-a6bd-aa3f00f62dfb_.

# [Allocate With Quote Request](#tab/allocate-with-quote-request)

`PUT https://api.electioapp.com/allocation/EC-000-05B-N40/allocatewithquote/112236d5-4460-492f-a6bd-aa3f00f62dfb`

--- 

## Next Steps

* Learn about alternative methods of allocating consignments at the [Allocating Consignments](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>