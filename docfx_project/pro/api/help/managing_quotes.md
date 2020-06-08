# Managing Quotes

SortedPRO's Quotes API enables you to get delivery quotes for a consignment manually. This section explains the various ways in which you can get delivery quotes for a consignment, and how to generate and allocate consignments from a selected quote.

---

## What Is a Quote In PRO?

In PRO, delivery quotes are generally used outside of a "regular" consignment allocation workflow, as a means of managing consignments that require manual intervention. For example, your customer service teams might want to get quotes for an expedited delivery on a consignment that was missed by a carrier and so did not meet its delivery promise.

PRO's Quotes API enables you to get delivery quotes for both as-yet uncreated and existing consignments. All Quotes endpoints return one or more `Quote` objects, of which each represents an offer for carriage of a consignment with a specific carrier service. Each quote can be uniquely identified by a `{quoteReference}`, which is used when selecting a quote via the **Allocate With Quote** endpoint.

### Allocate With Quote

The **Allocate With Quote** endpoint is a key part of all PRO quotes workflows, enabling you to allocate a consignment to the carrier service returned in a particular quote. It is covered in the **Allocation** section of this site, as it is part of the Allocation API:

* For reference information on **Allocate With Quote**, see the [API reference](https://docs.electioapp.com/#/api/AllocateWithQuote)
* For a user guide on the **Allocate With Quote** endpoint, see the [Allocating to a Specific Quote](/pro/api/help/allocating_to_a_specific_quote.html) page, in the **Allocating Consignments** section.

## Section Contents

* [Getting Quotes](/pro/api/help/getting_quotes.html) - Explains how to get delivery quotes without creating a new consignment.
* [Getting Quotes for an Existing Consignment](/pro/api/help/getting_quotes_for_an_existing_consignment.html) - Explains how to get delivery quotes for an existing consignment.

> <span class="note-header">Note:</span>
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>