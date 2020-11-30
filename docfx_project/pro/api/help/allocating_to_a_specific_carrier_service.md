---
uid: pro-api-help-allocating-to-a-specific-carrier-service
title: Allocating to a Specific Carrier Service
tags: v1,allocation,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 28/05/2020
---
# Allocating to a Specific Carrier Service

Want to specify the carrier service that should take your consignment? This page explains how to allocate consignments to services manually.

---

## Getting the Carrier Service Reference

In order to allocate a consignment to a specific carrier service, you'll need to know that service's `{MpdCarrierServiceReference}`. The `{MpdCarrierServiceReference}` is a unique identifier for each service available in PRO.

There are two ways of obtaining a carrier service's `{MpdCarrierServiceReference}`: 

* **Via the UI** - The [Carrier Services](https://www.electioapp.com/Configuration/carrierservices/) page (**Settings** > **Carrier Services**) displays a list of all available services. The `{MpdCarrierServiceReference}` for each service is displayed in the **Service Code** field.
* **Via API** - The **Get Available MPD Carrier Services** endpoint returns a list of all available services.  The `{MpdCarrierServiceReference}` for each service is displayed in the `Reference` field.

  > [!NOTE]
  >  For full reference information on the <strong>Get Available MPD Carrier Services</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetAvailableMPDCarrierServices">Get Available MPD Carrier Services</a></strong> page of the API reference. 

## Allocating to a Carrier Service Manually

The **Allocate With Carrier Service** endpoint enables you to allocate one or more consignments to a specific carrier service. 

To call **Allocate With Carrier Service**, make a `PUT` request to `https://api.electioapp.com/allocation/allocatewithcarrierservice`. The body of the request should contain the `{MpdCarrierServiceReference}` of the carrier service you want to allocate to, and an array of `consignmentReferences` listing the references of the consignments you want to allocate to that service.

> [!NOTE]
>  For full reference information on the <strong>Allocate With Carrier Service</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithCarrierService">Allocate With Carrier Service</a></strong> page of the API reference. 

Once the request is received, SortedPRO takes each consignment in turn and checks whether the specified service is eligible to take that consignment. If the specified service can meet the consignment's delivery promise, and allocating to that service would not break any existing allocation rules, then PRO allocates the consignment to that service and returns an allocation summary.

> [!NOTE]
> For information on using allocation rules, see the [What Is An Allocation Rule?](/pro/api/help/allocating_consignments.html#what-is-an-allocation-rule) section of the [Allocating Consignments To Carriers](/pro/api/help/allocating_consignments.html) page.

If PRO is unable to allocate the consignment to the specified carrier service, it puts the consignment into a state of _Allocation Failed_ and takes no further action. For information on dealing with failed allocations, see the _Manage Not Shipped Consignments_ section of the PRO UI User Manual.

### Allocate With Carrier Service Example

The example shows a request to allocate three consignments to a carrier service with an `{MpdCarrierServiceReference}` of _Example-Carrier-Service_ .

# [Allocate With Carrier Service Request](#tab/allocate-with-carrier-service-request)

`PUT https://api.electioapp.com/allocation/allocatewithcarrierservice`

```json
{
  "MpdCarrierServiceReference": "Example-Carrier-Service",
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```
---

## Next Steps

* Learn about alternative methods of allocating consignments at the [Allocating Consignments](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.