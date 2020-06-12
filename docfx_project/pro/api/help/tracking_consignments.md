# Tracking Consignments

SortedPRO's tracking features enable you to provide package tracking updates for your customers without having to pass them off to a carrier portal. You can track packages either via PRO's own tracking API, or via REACT, Sorted's dedicated carrier tracking product. This section explains how to use both options.

---

## PRO Tracking Overview

PRO's Tracking API is intended to drive simple web-based tracking pages. When the API is called, PRO returns a response listing the tracking events that have occurred since that package was dispatched. Tracking events are informational messages returned from carriers that provide details about the status of the consignment. You can then display this information to your customers through your site.

Alternatively, you can use SortedREACT to offer a richer tracking experience to your customers. As well as APIs that work in a similar way to PRO's Tracking API, REACT offers a full suite of tracking features, including push notifications via webhook, reports, and the ability to build custom tracking pages without any development work. When you sign up for REACT as well as PRO, REACT automatically converts the PRO consignments you create into its own shipment records. 

## Tracking Section Contents

* [Using PRO's Tracking API](/pro/api/help/using_pros_tracking_api.html) - Explains how to call the Tracking API.
* [Tracking Consignments Using REACT](/pro/api/help/tracking_consignments_using_react.html) - Gives an overview of how REACT and PRO interact.

> [!NOTE]
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>