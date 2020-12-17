---
uid: pro-api-shipments-integration-designs-2-quotes
title: PRO Integration Designs
tags: v2,shipments,pro,api,flows,integration design
contributors: andy.walton@sorted.com
created: 17/12/2020
---
# PRO Integration Designs

Ready to get started with SortedPRO? This guide explains some common integration designs for PRO's APIs, helping you to see what PRO can do for your business.

We'll cover:

* **Design 1a - Creating and manifesting a scheduled shipment**

   The **Classic - Scheduled** design is a simple call flow to create a shipment, allocate it to a scheduled carrier service using criteria of your choosing, retrieve delivery labels, and manifest it with the carrier. This design would be best used to facilitate bulk shipments from a warehouse.

* **Design 1b - Creating and manifesting a ad-hoc shipment**

   The **Classic - Ad-hoc** design is similar to the **Classic - Scheduled** design, but involves creating a shipment for an ad-hoc carrier collection rather than a scheduled collection from a warehouse. This design would be best used to facilitate a ship-from-store model.     

* **Design 2 - Obtaining and selecting delivery quotes**

   The **Quotes** design enables you to obtain a full list of potential delivery services for a shipment. This design would be best used to facilitate the delivery of a shipment outside of your normal delivery process, for example in cases where a customer service operator needs to get manual delivery quotes for a customer.

> [!NOTE]
> This guide is intended as a primer for PRO. If you're already familiar with the basics of PRO, or you just need reference info for PRO's APIs, see the [API Reference](/pro/api/reference/index.html.
>
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).

<span class="highlight">WHAT'S THE DEAL WITH THE SHIPMENTS SANDBOX?</span>
