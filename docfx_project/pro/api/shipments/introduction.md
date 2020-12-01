---
uid: pro-api-help-shipments-introduction
title: Introduction
tags: v2,shipments,pro,api,getting started
contributors: andy.walton@sorted.com
created: 05/10/2020
---
# Getting Started with PRO's APIs

Welcome to SortedPRO! This page contains a brief overview of PRO version 2's APIs and explains how you can use them.

---

## API Collection Overview

PRO's Shipments functionality was introduced in version 2 as an extension to the Consignments API suite used in version 1. PRO's Shipments API collection offers unparalleled flexibility, with support for on-demand collections from multiple locations (e.g. a ship-from-store model) as well the regular scheduled fulfilment centre collections supported in v1.

PRO also offers the ability to group shipments together for ease of management, an improved dangerous goods specification and enhanced customs functionality, among many other features.

> [!NOTE]
>
> For more information on the differences between the Shipments API suite used in v2 and the Consignments API suite used in v1, see the [Consignments vs Shipments](/pro/api/shipments/consignments_vs_shipments.html) page.

PRO's APIs enable you to:

* **Manage Shipments** - Create, update, clone, cancel and delete shipment records, and manually modify shipment states.
* **Allocate Shipments** - Allocate shipments to the most appropriate carrier service<!--, allocate within a service group, manually filter services to allocate to, or allocate based on a previous delivery quote -->.
* **Manage Quotes** - Create and receive delivery quotes for shipments.
* **Get Customs Docs** - Get customs documents for allocated international shipments. 
* **Get Labels** - Get delivery labels for an allocated shipment in either ZPL or PDF format.
* **Manifest Shipments** - Manually manifest one or more shipments, either via query or by manifesting a shipment group. 
* **Manage Shipment Groups** - Group shipments together so they can be operated on as a single unit, and edit or delete shipment groups as required.
* **Get Collection Notes** - Retrieve collection notes (aka driver's manifest) by search query or by shipment group.
<!--* **Track Shipments** - Return tracking updates for a given shipment.--> 

> [!NOTE]
>
> For example API call flows and reference information, see the [PRO v2 API reference](/pro/api/reference/index.html).

## Making an API Request in PRO

This section explains the various API headers used when making a request to one of PRO's APIs.

# [Example PRO Shipments API Headers](#tab/example-pro-shipments-api-headers)

```
x-api-key: [qwerrtyuiioop0987654321]
Accept: application/json
Content-Type: application/json 
Accept-Encoding: gzip 
x-api-version: 1.1

```
---

### Authentication

You must provide a valid API key in every call you make to PRO. When a new user account is created, PRO generates a unique API key and allocates it to the new user. You can view your API key in the PRO UI.

To use your API key with PRO v2, include it in an `x-api-key` header when making calls. If you make an API call to PRO without including an API key, then PRO returns an error with a status code of _401 (Unauthorized)_.

### Formats

PRO v2 only works with JSON data. This is a change from v1, which accepted XML requests and responses as well as JSON. 

If you provide an `Accept` header to indicate request format and/or a `Content-Type` format to indicate response format, then these keys must have a value of _application/json_. PRO will return an error if you provide any other values in these headers. If you do not provide `Accept` and/or `Content-Type` headers, then PRO uses its default value of _application/json_.

PRO is designed to work with GZIP encoding. We strongly recommend that you provide an `Accept-Encoding` header with a value of _gzip_ in all requests.

### Versioning

You must provide an `x-api-version` header in all requests. The current API version is _1.1_.

> [!NOTE]
> The API version provided in the `x-api-version` header is a purely technical property, and should not be confused with the version of PRO you are using. At present, the `x-api-version` should always _1.1_, irrespective of whether you are calling PRO v2 (Shipments) or PRO v1 (Consignments) endpoints. This is because both versions of PRO share certain back-end processes.

## Response Headers

Depending on the content returned, PRO's responses may include the following headers:

* `x-api-version` - The version of the API that served the request. 
* `Content-Type` -  The format of the response body. This will ordinarily have the value _application/json_. 
* `Content-Encoding` -  If you request responses in GZIP format, the `Content-Encoding` response header returns a value of _gzipped_. 

## Next Steps

* Learn more about the differences between shipments and consignments: [Shipments vs Consignments](/pro/api/shipments/consignments_vs_shipments.html)
* Learn how to create, update and delete shipments: [Managing Shipments](/pro/api/shipments/managing_shipments.html)
* Learn how to allocate shipments to carrier services: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)