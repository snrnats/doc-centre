---
uid: pro-api-help-shipments-getting-shipments
title: Getting Shipments
tags: v2,shipments,pro,api,retrieving
contributors: andy.walton@sorted.com
created: 06/10/2020
---
# Getting Shipments

This page explains how to retrieve consignment data by shipment reference<!--, custom reference, and carrier tracking reference-->.

---

## Getting Shipments by Shipment Reference

The **Get Shipment** endpoint takes the `{reference}` of the shipment you want to view and returns details of that shipment. To call **Get Shipment**, send a `GET` request to `https://api.sorted.com/pro/shipments/{reference}`, where `{reference}` is the unique reference of the shipment you want to retrieve.

The information returned is structured in a broadly similar way to a **Create Shipment** request, but also contains additional properties (that is, properties that are managed by PRO rather than explicitly stated by the customer when a shipment is created). These properties include:

* `reference` - The shipment's unique reference.
* `state` - The shipment's current `state`. For a full list of shipment states, see the [Shipment States](/pro/api/shipments/shipment_states.html) page.
* `created` - The date and time that the shipment was created.
* `updated` - The date and time that the shipment was last updated, where applicable.
* `shipping_date` - The assigned shipping date for the shipment based on the active allocation, where applicable.
* `expected_delivery_date` - The expected date(s) for delivery based on the current active allocation, where applicable.
* `actual_delivery_date` - 	The actual date and time that the shipment was delivered, where applicable.
* `allocation` - Details of the active allocated carrier and service for the shipment, where applicable.
* `label_details` - Links to retrieve labels for allocated shipments, and fields indicating whether labels have already been retrieved.
* `reservation` - Details of any reservation for the shipment (for example, click and collect options), where applicable.
* `_links` - Links to any related resources.

> [!NOTE]
>
> For full reference information on the **Get Shipment** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Shipments/paths/~1shipments~1{shipmentReference}/get).

### Example Get Shipment Call

The example below shows a **Get Shipment** request for a shipment with a `{reference}` of _sp_00792693789526132644358207963136_.

# [Get Shipment Request](#tab/get-shipment-request)

`GET https://api.sorted.com/pro/shipments/sp_9953035299125395456009822134452`

# [Get Shipment Response](#tab/get-shipment-response)

```json
{
    "reference": "sp_00792693789526132644358207963136",
    "state": "unallocated",
    "created": "2020-10-06T08:40:16.436208+00:00",
    "shipping_date": {
        "has_value": false
    },
    "required_shipping_date": {
        "has_value": false
    },
    "expected_delivery_date": {
        "has_value": false
    },
    "required_delivery_date": {
        "has_value": false
    },
    "custom_reference": "Example123",
    "tags": [
        "b&w",
        "T2T"
    ],
    "order_date": "2019-04-05T09:34:55+01:00",
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string",
            "metadata_type": "string"
        },
        {
            "key": "refundable",
            "value": "false",
            "type": "string",
            "metadata_type": "bool"
        }
    ],
    "customs_documentation": {
        "designated_person_responsible": "John McBride",
        "importers_vat_number": "0234555",
        "category_type": "Documents",
        "category_type_explanation": "Free text",
        "shippers_customs_reference": "CREF0001",
        "importers_tax_code": "TC001",
        "importers_telephone": "+441772611444",
        "importers_email": "jmcb@tilda.net",
        "cn23_comments": "cn23 comments",
        "attached_invoice_references": [
            "63bc2ad5-dbff-4d30-a9b2-8081607d9921"
        ],
        "attached_certificate_references": [
            "bbc0eaa5-1a1d-4b56-b33a-a360680c1270"
        ],
        "attached_licence_references": [
            "0e5084d6-6509-4ff3-9771-66e63f452eb9"
        ],
        "declaration_date": "2019-04-26T14:57:54+01:00",
        "reason_for_export": "sale",
        "shippers_vat_number": "98798273434",
        "receivers_tax_code": "TC8793847",
        "receivers_vat_number": "9879879878675",
        "invoice_date": "2019-04-26T15:01:45+01:00",
        "eori_number": "GB1234567890111",
        "invoice_number": "{{invRandomVariable}}",
        "office_of_origin": "Hey, that's far out so you heard him too! I would "
    },
    "direction": "outbound",
    "shipment_type": "on_demand",
    "contents": [
        {
            "reference": "sc_00792693789526132644358207963137",
            "custom_reference": "b9fa91b0-0dd0-4dd5-986f-363fa8cb2386",
            "weight": {
                "value": 2.400,
                "unit": "Kg"
            },
            "dimensions": {
                "length": 20.00,
                "height": 15.50,
                "width": 15.00,
                "unit": "Cm"
            },
            "value": {
                "amount": 8.99,
                "currency": "GBP"
            },
            "sku": "SKU09876",
            "description": "Jeans",
            "model": "MOD-009",
            "country_of_origin": "PT",
            "harmonisation_code": "09.02.10",
            "shipping_terms": "Fca",
            "quantity": 2,
            "unit": "Box",
            "metadata": [
                {
                    "key": "Category",
                    "value": "Menswear",
                    "type": "string",
                    "metadata_type": "string"
                }
            ],
            "label_properties": [],
            "contents": []
        },
        {
            "reference": "sc_00792693789526132644358207963138",
            "custom_reference": "b9fa91b0-0dd0-4dd5-986f-363fa8cb2386",
            "weight": {
                "value": 2.500,
                "unit": "Kg"
            },
            "dimensions": {
                "length": 20.00,
                "height": 15.50,
                "width": 15.00,
                "unit": "Cm"
            },
            "value": {
                "amount": 8.99,
                "currency": "GBP"
            },
            "sku": "SKU09876",
            "description": "Jeans",
            "model": "MOD-009",
            "country_of_origin": "PT",
            "harmonisation_code": "09.02.10",
            "shipping_terms": "Fca",
            "quantity": 2,
            "unit": "Box",
            "metadata": [
                {
                    "key": "Category",
                    "value": "Menswear",
                    "type": "string",
                    "metadata_type": "string"
                }
            ],
            "label_properties": [],
            "contents": []
        }
    ],
    "addresses": [
        {
            "address_type": "Origin",
            "contact": {
                "reference": "co_9953035290535460864",
                "title": "Mr",
                "first_name": "Frank",
                "last_name": "Zappa",
                "contact_details": {
                    "mobile": "+447495747987",
                    "email": "frank@zappa.com"
                }
            },
            "property_number": "1",
            "property_name": "Frank's Palace",
            "address_line1": "Zappa Avenue",
            "address_line2": "Off Rock Road",
            "address_line3": "Off Heavy Crescent",
            "locality": "Manchester",
            "region": "Greater Manchester",
            "postal_code": "M2 6LW",
            "country_iso_code": "GB"
        },
        {
            "address_type": "Destination",
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865",
                "title": "Mr",
                "first_name": "Freddie",
                "last_name": "Mercury",
                "contact_details": {
                    "mobile": "+447495747987",
                    "email": "freddie@mercury.com"
                }
            },
            "property_number": "8",
            "property_name": "Queen",
            "address_line1": "Norbert Road",
            "address_line2": "Bertwistle",
            "address_line3": "Near Nothing",
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB"
        }
    ],
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ],
    "source": "WMS",
    "paperless_documents": [],
    "_links": [
        {
            "href": "https://api-int.sorted.com/pro/shipments/sp_00792693789526132644358207963136",
            "rel": "shipment",
            "reference": "sp_00792693789526132644358207963136",
            "type": "shipment"
        }
    ]
}
```
---

<!--## Getting Shipments by Custom Reference

The **Get Shipments by Custom Reference** endpoint enables you to search for shipment data by your own custom reference number. To call **Get Shipments by Custom Reference**, send a `GET` request to `https://api.sorted.com/pro/shipments?custom_reference={reference}`, where `{reference}` is the `custom_reference` you want to search on.

> [!NOTE]
> In PRO, a `custom_reference` is a user-specified reference for a shipment or item of shipment contents. Custom references do not need to be unique. For example, you might use the `custom_reference` property to add your own order number to all shipments corresponding to a particular order.

The `custom_reference` property can be applied to both shipments and `shipment_contents` objects. The **Get Shipments by Custom Reference** endpoint returns both those shipments that are directly tagged with the specified `custom_reference` _and_ those shipments that contain a `shipment_contents` object with the specified `custom_reference`.

> [!NOTE]
> For more information on the structure of shipment contents, see the [Specifying Shipment Contents](/pro/api/shipments/creating_shipments.html#specifying-shipment-contents) section of the [Creating Shipments](/pro/api/shipments/creating_shipments.html) page.

Once it has received the request, PRO returns a `shipment_list` object containing a list of shipments, the total number of results, the number of shipments requested and the number of shipments skipped.

 commenting out due to endpoint not currently running

### Example Get Shipments by Custom Reference Call

The example shows a successful request to get all shipments that either have the `custom_reference` or contain contents with the `custom_reference` _CR1234_.

# [Get Shipments by Custom Reference Request](#tab/get-shipments-by-custom-reference-request)

`GET https://api.sorted.com/pro/shipments?custom_reference=CR1234`

# [Get Shipments by Custom Reference Response](#tab/get-shipments-by-custom-reference-response)

<span class="commented-out">NO JSON EXAMPLES OR WORKING ENDPOINTS FOR THIS YET</span>

> [!NOTE]
> For full reference information on the **Get Shipments by Custom Reference** endpoint, see the Shipments data contract.

## Getting Shipments by Carrier Tracking Reference

The **Get Shipments by Carrier Tracking Reference** endpoint enables you to search for shipment data using a carrier tracking reference. To call **Get Shipments by Carrier Tracking Reference**, send a `GET` request to `https://api.sorted.com/pro/shipments/tracking_reference/{tracking_reference}`, where `{tracking_reference}` is the carrier tracking reference you want to search on.

Once it has received the request, PRO returns a `shipment_list` object containing a list of shipments, the total number of results, the number of shipments requested and the number of shipments skipped.

**Get Shipments by Carrier Tracking Reference** can only return allocated shipments, as carrier tracking references are assigned to shipments at the point of allocation. The carrier `tracking_reference` can be found in the shipment's `allocation.tracking_references` property. It can also be found in the `tracking_details.shipment.tracking_references` property of the Allocation Summary object that is returned when a shipment is allocated. 

> [!NOTE]
> As carrier tracking references can repeat, the **Get Shipments by Carrier Tracking Reference** endpoint only returns shipments that have been allocated within the last 30 days. Any older shipments may still be present in the database, but are not returned by the endpoint.

**Get Shipments by Carrier Tracking Reference** only works with those tracking references provided by carriers. It will not return shipments for internally-generated PRO or REACT references.

commenting out due to endpoint not currently running

### Example Get Shipments by Carrier Tracking Reference Call

The example shows a successful request to get all shipments that have the carrier `tracking_reference` _CTR1234_.

# [Get Shipments by Carrier Tracking Reference Request](#tab/get-shipments-by-carrier-tracking-reference-request)

`GET https://api.sorted.com/pro/shipments/tracking_reference/CTR1234`

# [Get Shipments by Carrier Tracking Reference Response](#tab/get-shipments-by-carrier-tracking-reference-response)

<span class="commented-out">NO JSON EXAMPLES OR WORKING ENDPOINTS FOR THIS YET</span>

> [!NOTE]
> For full reference information on the **Get Shipments by Carrier Tracking Reference** endpoint, see the Shipments data contract.

## Paging Results

Both the **Get Shipments by Custom Reference** endpoint and the **Get Shipment by Carrier Tracking Reference** endpoint support optional `{take}` and `{skip}` parameters, which can be used to drive paging functions. The `{take}` parameter indicates the number of shipments to return (up to a maximum of 10), and the `{skip}` parameter indicates the number of shipment records PRO should "skip over" before it returns records.

For example, suppose that you have 15 shipments with a `custom_reference` of _CR1234_, and you want to return them as three pages of five shipments: 

* To view the first page of five, you would make a call to `GET https://api.sorted.com/pro/shipments?custom_reference=CR1234&take=5&skip=0` (that is, take five shipments and do not skip over any). 
* To view the second page, you would call `GET https://api.sorted.com/pro/shipments?custom_reference=CR1234&take=5&skip=5` (skip the first five shipments and then take the next five).
* To view the third page, you would call `GET https://api.sorted.com/pro/shipments?custom_reference=CR1234&take=5&skip=10` (skip the first ten shipments and then take the next five).

By default, `{take}` has a value of 10 and `{skip}` has a value of 0.-->

## Next Steps

* Learn how to create, clone, and update shipments: [Creating Shipments](/pro/api/shipments/creating_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)