---
uid: pro-api-help-shipments-creating-shipment-groups
title: Creating Shipment Groups
tags: shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Creating Shipment Groups

In the list of `shipments` provided:

- A maximum of `10,000` references is permitted
- At least one `shipment` reference must be provided
- All references must be for existing `shipments` that the user has access to. In the event of an invalid reference being part of the group, the operation should still succeed as long as there is one or more valid references in the request. The response should indicate which reference(s) are invalid
- All `shipments` must be in a state of `allocated` or `manifested` in order to be added to the group
- Duplicate references should result in a `207 (Multi Status)` response which should inform the user which reference(s) were duplicated. The unique references from the request should be added to the group.
- All `shipments` must have the same `origin` address or same `origin` shipping location reference
- A `shipment` may only be a member of one **open** `shipment_group` at any one time
- All `shipments` must be allocated to the same carrier service

For the `custom_reference` value provided:

- The same `custom_reference` may be re-used, but only where there is no existing **open** group with the same `custom_reference`
- Where a `custom_reference` value is being re-used by the customer, the `resource_result` should provide a new version identifier for the `custom_reference` in the version property. This should be equivalent to the maximum current version for that `custom_reference` + 1
- The `custom_reference` value must be URL-safe or URL-encoded, i.e. it must not contain characters such as `/`, `\`, `?`, `@` unless encoded. Any invalid reference should result in a `400 (Bad Request)` response. This is because we permit these references as route parameters in other API endpoints.

The following request is valid provided there is no existing **open** `shipment_group` with a `custom_reference` of `TRAILER_XPD0092`:

```json
{
    "custom_reference": "TRAILER_XPD0092",
    "shipments": [
        "sp_00013464648910021776641789788160",
        "sp_00013464648910021776641789784435",
        "sp_00013464648910021776641789790773"
    ]
}
```

##### FR001 Successful Response

The following `JSON` demonstrates a successful create shipment group response:

```json
{
    "reference": "sg_00013464648946915264789208891396",
    "custom_reference": "TRAILER_XPD0092",
    "version": 1,
    "message": "Shipment group created successfully",
    "errors": null,
    "_links": [
        {
            "rel": "self",
            "href": "/pro/shipment_groups/{ref}",
            "type": "shipment_group",
            "reference": "{ref}"
        }
    ]
}
```

##### FR001 Re-used Custom Reference

When the customer re-uses a `custom_reference` value, the following `JSON` should be returned.

> [!TIP]
> This sample assumes a previous version of `78` for the `custom_reference` value `TRAILER_XPD0092`.

```json
{
    "reference": "sg_00013464648946915264789208891778",
    "custom_reference": "TRAILER_XPD0092",
    "version": 79,
    "message": "Shipment group created successfully",
    "errors": null,
    "_links": //omitted for brevity
}
```

##### FR001 Invalid Shipment Reference

When the customer provides multiple `shipment` references and one or more of those references are invalid but at least one reference is valid, the `shipment_group` should be created and should contain all valid `shipment` references. The response should include details of the invalid `shipment` reference(s).

> [!NOTE]
> Remember that the HTTP status code in this situation should be `207 (Multi-status)` to allow the user to differentiate between completely successful and partially successful operations.

```json
{
    "reference": "sg_00013464648946915264789208891778",
    "custom_reference": "TRAILER_XPD0092",
    "version": 79,
    "message": "Shipment group created successfully",
    "errors": [
        {
            "property": "shipments",
            "code": "invalid_reference_format",
            "message": "{ref} is not a valid shipment reference"
        },
        {
            "property": "shipments",
            "code": "shipment_not_found",
            "message": "sp_{ref} could not be found"
        }
    ],
    "_links": //omitted for brevity
}
```
