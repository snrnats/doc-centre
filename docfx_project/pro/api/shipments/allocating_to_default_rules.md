---
uid: pro-api-help-shipments-allocating-to-default-rules
title: Allocating to Default Rules
tags: shipments,pro,api,allocation,rules
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Allocating to Default Rules


---

## Overview



## Allocating a Single Consignment

Allocate Shipment This endpoint is used when you wish to allocate a single shipment using Sorted's allocation engine. If you require allocation of multiple shipments in a single operation, you should use the Allocate Shipments endpoint. When allocating using this endpoint, Sorted will automatically determine the most appropriate carrier service based on several factors, including:

Configured allocation rules
Required shipping dates
Required delivery dates
Carrier availability
Carrier service price

### Allocate Shipment Example



## Allocating Multiple Consignments At Once

Allocate Shipments This endpoint is used when you wish to allocate multiple shipments using Sorted's allocation engine. If you only require allocation of an individual shipment, you should prefer the single Allocate Shipment endpoint. When allocating using this endpoint, Sorted will automatically determine the most appropriate carrier service based on several factors, including configured allocation rules, required shipping and delivery dates, carrier availability and carrier service price.

NOTE
When requesting an allocation of multiple shipments, the allocation will not happen in- process. This is to ensure the performance of the API endpoint. shipments allocated as a batch will be allocated via a background process.

### Allocate Shipments Example



## Next Steps

