---
uid: pro-api-help-managing-consignments
title: Managing Consignments
tags: consignments,pro,api
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/06/2020
---
# Managing Consignments

In SortedPRO, a consignment represents a collection of goods that are to be shipped together. This section explains how to create, retrieve and edit consignments.

---

## What Is a Consignment?

In the context of PRO, the term **"consignment"** refers to a collection of one or more packages that are shipped from the same origin address, to the same destination address, on behalf of the same Sorted customer, using the same carrier service, on the same day.

A **package** is an **item** or a collection of items, wrapped or contained together for shipment. Each package can contain one or more items.

As an example, suppose that a clothing retailer has received a customer order for a necklace, a bracelet, a coat, and a hat. As the necklace and bracelet are both physically small, the retailer elects to ship them in the same package. As such, this sales order would break down to:

* Four items - The necklace, the bracelet, the coat, and the hat.
* Three packages - One containing the necklace and bracelet, one containing the coat, and one containing the hat.
* A single consignment corresponding to everything on the order.

<p>
   <a href="../../images/consignment-diagram.png" target="_blank" >
      <img src="../../images/consignment-diagram.png" class="noborder"/>
   </a>
</p>

## Consignments Section Contents

* **[Creating New Consignments](/pro/api/help/creating_new_consignments.html)** - Explains how to use the **Create Consignment** endpoint, and how to generate consignments from quotes and orders.
* **[Getting Consignment Data](/pro/api/help/getting_consignment_data.html)** - Explains how to retrieve data on an individual consignment, and search for consignments that meet set criteria.
* **[Updating Existing Consignments](/pro/api/help/updating_existing_consignments.html)** - Explains how to update a consignment's details and edit its component packages.
* **[Cancelling Consignments](/pro/api/help/cancelling_consignments.html)** - Explains how to set a consignment's status to _Cancelled_.

> [!NOTE]
> All of the URLs and examples given in this documentation relate to PRO's live production environment. To call APIs in the sandbox environment, substitute the `api.electioapp.com` portion of the API's base URL with `apisandbox.electioapp.com`. Don't forget to use your sandbox API key (as opposed to your production API key) when making the call.
>
> For more information on PRO's sandbox, see [Using the Sandbox Environment](/pro/api/help/introduction.html#using-the-sandbox-environment).