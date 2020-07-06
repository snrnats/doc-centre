---
uid: pro-api-help-shipments-allocating-with-a-specific-carrier-service
title: Allocating with a Specific Carrier Service
tags: shipments,pro,api,allocation,carrier service
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---

# Allocating with a Specific Carrier Service

Want to specify the carrier service that should take your shipment? This page explains how to allocate shipments to services manually.

---

## Getting the Carrier Service Reference



## Allocating A Single Shipment with a Specific Carrier Service

`PUT https://api.sorted.com/pro/shipments/{reference}/allocate/service/{service_ref}`

Allocate Shipment with Carrier Service This endpoint is used when you wish to allocate a shipment with a specific carrier service.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]


### Allocate Shipment with Carrier Service Example



## Allocating Multiple Shipments with a Specific Carrier Service

`PUT https://api.sorted.com/pro/shipments/allocate/service`

Allocate with Carrier Service This endpoint is used when you wish to allocate one or more shipments with a specific carrier service.

[!include[_shipments_allocate_shipments_result](../includes/_shipments_allocate_shipments_result.md)]

### Allocate with Carrier Service Example



## Next Steps

