# Managing Quotes

SortedPRO's Quotes API enables you to get delivery quotes for a consignment manually. This section explains the various ways in which you can get delivery quotes for a consignment, and how to generate and allocate consignments from a selected quote.

---

## What Is A Quote In PRO?

In PRO, delivery quotes are generally used outside of a "regular" consignment allocation workflow, as a means of managing consignments that require manual intervention. For example, your customer service teams might want to get quotes for an expedited delivery on a consignment that was missed by a carrier and so did not meet its delivery promise. <span class="highlight">IS THIS EXAMPLE OK? WOULD THIS HAPPEN IN REAL LIFE?</span>

PRO's Quotes API enables you to get delivery quotes for both as-yet uncreated and existing consignments. All Quotes endpoints return one or more `Quote` objects, of which each represents an offer for carriage of a consignment with a specific carrier service. Each quote can be uniquely identified by a `{quoteReference}`, which is used when selecting a quote via the **Allocate With Quote** endpoint.

> <span class="note-header">Note:</span>
>
> The **Allocate With Quote** endpoint it a key part of all PRO quotes workflows, enabling you to allocate a consignment to the carrier service returned in a particular quote:
>
> * For reference information on **Allocate With Quote**, see the [API reference](https://docs.electioapp.com/#/api/AllocateWithQuote)
> * For a user quote on the **Allocate With Quote** endpoint, see the [Allocating To A Specific Quote](/pro/api/help/allocating_to_a_specific_quote.md) page, in the **Allocating Consignments** section.

## Section Contents

* [Getting Quotes](/pro/api/help/getting_quotes.md) - Explains how to get delivery quotes for an as-yet uncreated consignment
* [Getting Quotes for an Existing Consignment](/pro/api/help/getting_quotes_for_an_existing_consignment.md) - Explains how to get delivery quotes for an existing consignment

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>