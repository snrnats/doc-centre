---
uid: pro-api-help-shipments-allocating-within-a-carrier-service-group
title: Allocating Within A Carrier Service Group
tags: shipments,pro,api,allocation,service group
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---

# Allocating Within A Carrier Service Group



---

## What Is a Carrier Service Group?



## Configuring Carrier Service Groups



## Allocating a Single Shipment with a Carrier Service Group

Allocate Shipment with Service Group This endpoint is used to allocate a shipment with a carrier service from a specific carrier service group.

### Allocate Shipment with Service Group Example



## Allocating Multiple Shipments with a Carrier Service Group At Once

Allocate with Service Group This endpoint is used to allocate multiple shipments with a carrier service from a specific carrier service_group.

NOTE
When requesting an allocation of multiple shipments, the allocation will not happen in-process. This is to ensure the performance of the API endpoint. Any shipments allocated as a batch will be allocated via a background process.

### Allocate with Service Group Example



## Next Steps


