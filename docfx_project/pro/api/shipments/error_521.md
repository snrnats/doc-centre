---
uid: pro-api-error-codes-shipments-521
title: 521 - Allocation Failed
tags: allocation,pro,api,shipments,error
contributors: andy.walton@sorted.com
created: 07/10/2020
---
# 521 - Allocation Failed

An error returned when PRO is unable to allocate one or more shipments. The child error code gives further information on the reason that the allocation attempt failed. 

## Child Errors

| Child Error Code | Description |
|-|-|
| allocation_failed | The shipment(s) could not be allocated. The response will include details of the allocation failure. |
| carrier_service_not_found | The request carrier service did not match a carrier service within your account |
| carrier_service_shipment_mismatch | The type of shipment (e.g. on_demand, scheduled) is not compatible with the requested carrier service |
| shipment_invalid_state | The shipment was not in a valid state to be allocated |
| shipment_not_found | The provided reference did not match a shipment within your account |.