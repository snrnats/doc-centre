---
uid: pro-api-help-shipments-allocating-with-a-virtual-service
title: Allocating with a Virtual Service
tags: shipments,pro,api,allocation,virtual service
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 08/07/2020
---
# Allocating with a Virtual Service


---

## What Is a Virtual Service?



## Using the Allocate Shipment with Virtual Service Endpoint

`PUT https://api.sorted.com/pro/shipments/{reference}/allocate/virtual_service/{virtual_service_reference}`

Allocate Shipment with Virtual Service
TIP
The term "virtual service" is used to here to indicate that the provided reference can refer to multiple types of entity such as a carrier service or a carrier service group. This functionality may be extended in the future to include other types of virtual service.

This endpoint is used to allocate a shipment with a specific carrier service or service_group, depending upon the reference provided.

WARNING
This endpoint can result in clashes between references. If a customer has a carrier service and a service_group with the same reference, any attempt to use that carrier service or service_group via this endpoint will result in a 400 (Bad Request). The specific Allocate Shipment with Specific Carrier Service or Allocate Shipment with Service Group can still be used successfully in this instance.

[!include[_shipments_allocate_result](../includes/_shipments_allocate_result.md)]

### Allocate Shipment with Virtual Service Example



## Next Steps



