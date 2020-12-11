---
uid: pro-api-help-shipments-creating-shipment-groups
title: Creating Shipment Groups
tags: v2,shipments,pro,api,shipment groups
contributors: andy.walton@sorted.com
created: 08/10/2020
---
# Creating Shipment Groups

This page explains how to use the **Create Shipment Groups** endpoint to create new shipment groups.

> [!NOTE]
> This page provides help and support for PRO version 2 (Shipments). As PRO v2 is currently in development, content may be removed or edited without warning.
>
> For support on PRO v1 (Consignments), [click here](/pro/api/help/introduction.html).  

---

## The Create Shipment Groups Request

To call **Create Shipment Group**, send a `POST` request to `https://api.sorted.com/pro/shipment_groups`. The body of the request should contain a list of up to 10,000 `shipments` that you want to add to the group, and an optional `custom_reference` that can be used as an identifier for the group.

### Shipment Group Validation

 All **Create Shipment Group** requests must conform to the following validation rules: 

* You must provide between 1 and 10,000 references in the `shipments` list.
* All references must be for existing `shipments` that you have access to. 
* All `shipments` must be in a state of either `allocated` or `manifested`.
* All `shipments` must have the same `origin` address or same `origin` shipping location reference.
* A `shipment` may only be a member of one **open** `shipment_group` at any one time.
* All `shipments` must be allocated to the same carrier service.

However, PRO still creates the group if you provide a reference for an invalid shipment, as long as there is at least once valid reference in the request.

Shipment groups cannot share a `custom_reference` with another open shipment group. However, you can re-use previous `custom_references` as long as all previous groups that have used that reference are closed. `custom_reference` values must be URL-safe (that is, they cannot contain characters such as `/`, `\`, `?`, `@` unless encoded).

## The Create Shipment Group Response

Once it has received and validated the request, PRO creates the shipment group and returns a Resource Result including the following information:

* `reference`. This is an auto-generated unique reference for the group. It is not to be confused with the `custom_reference`.
* `custom_reference` - The custom reference specified in the request.
* `version` - An integer indicating the number of times that the `custom_reference` has been used.
* `errors` - Indicates any shipments in the request that failed validation and could not be added to the group.

### Versioning

Versioning enables you to identify any shipment group by `custom_reference`, even though `custom_references` can be re-used as long as they are not shared with any open groups.

[!include[_shipments_group_versioning](../includes/_shipments_group_versioning.md)]

Shipment group versioning is used when retrieving shipment groups, when adding or removing shipments from a group, and when generating collection notes.

> [!NOTE]
> * For more information on retrieving shipment groups, see the [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html) page.
> * For more information on adding and removing shipments from a group, see the [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html) page.
> * For more information on generating collection notes, see the [Getting Collection Notes](/pro/api/shipments/getting_collection_notes.html) page.

## Examples

### Successful Request

The example shows a successful request to create a shipment group. The group comprises three valid shipments and has a `custom_reference` of _Example123_.

# [Create Shipment Group Request](#tab/create-shipment-group-request)

```json
{
    "custom_reference": "Example123",
    "shipments": [
        "sp_00013464648910021776641789788160",
        "sp_00013464648910021776641789784435",
        "sp_00013464648910021776641789790773"
    ]
}
```

# [Create Shipment Group Response](#tab/create-shipment-group-response)

```json
{
  "reference": "sg_00679577652026749527919113797632",
  "custom_reference": "Example123",
  "version": 79,
  "message": "Shipment group sg_00679577652026749527919113797632 created successfully",
  "_links": [
    {
      "href": "https://beta.sorted.com/pro/shipments/groups/sg_00679577652026749527919113797632",
      "rel": "self",
      "reference": "sg_00679577652026749527919113797632",
      "type": "shipment_group"
    }
  ]
}
```
---

Note the `version` number of _79_ in the response, indicating that the user has used the `custom_reference` _Example123_ 78 times before.

### Invalid Shipment Reference

Like the first example, this example response shows the successful creation of a shipment group. However, in this case not all of the shipments provided are valid, with one of the provided `references` in an invalid formant and another corresponding to a non-existent shipment. PRO has indicated the shipments that could not be added to the group in its response.

> [!NOTE]
> In this case, the HTTP status code of the response would be `207 (Multi-status)`. This code enables you to to differentiate between completely successful and partially successful group creation requests.

# [Invalid Shipment Reference Response](#tab/invalid-shipment-reference-response)

```json
{
        "errors": [
        {
            "property": "shipments",
            "code": "invalid_reference_format",
            "message": "shp_000134646476641789784435 is not a valid shipment reference"
        },
        {
            "property": "shipments",
            "code": "shipment_not_found",
            "message": "sp_00013464648910021776641789790773 could not be found"
        }
    ],
    "reference": "sg_00679577652026749527919113797632",
    "custom_reference": "Example456",
    "version": 59,
    "message": "Shipment group sg_00679577652026749527919113797632 created successfully",
    "_links": //omitted for brevity
}
```
---

> [!NOTE]
> For full reference information on the **Create Shipment Group** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Shipment-Groups/paths/~1shipment_groups/post).

## Next Steps

* Learn how to retrieve existing shipment groups: [Getting Shipment Groups](/pro/api/shipments/getting_shipment_groups.html)
* Learn how to add and remove shipments from groups: [Editing Shipment Groups](/pro/api/shipments/editing_shipment_groups.html)
* Learn how to close shipment groups: [Closing Shipment Groups](/pro/api/shipments/closing_shipment_groups.html)