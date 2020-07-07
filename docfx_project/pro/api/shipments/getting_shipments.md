---
uid: pro-api-help-shipments-getting-shipments
title: Getting Shipments
tags: shipments,pro,api,retrieving
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Getting Shipments

PRO offers several endpoints that return consignment data. This page explains how to retrieve consignment data by shipment reference, custom reference, and carrier tracking reference.

---

## Getting Shipments by Shipment Reference

The **Get Shipment** endpoint takes the `{reference}` of the shipment you want to view as a path parameter, and returns full details for the specified shipment. To call **Get Shipment**, send a `GET` request to `https://api.sorted.com/pro/shipments/{reference}`, where `{reference}` is the unique reference of the shipment you want to retrieve.

The information returned is structured in a broadly similar way to a **Create Shipment** request, but may also contain additional properties (that is, properties that are managed by PRO rather than explicitly stated by the customer when a shipment is created). These properties include:

* `reference` - The shipment's unique reference.
* `state` - The shipment's current `state`. For a full list of shipment states see [LINK HERE]
* `created` - The date and time that the shipment was created.
* `updated` - The date and time that the shipment was last updated, where applicable.
* `shipping_date` - The assigned shipping date for the shipment based on the active allocation, where applicable.
* `expected_delivery_date` - The expected date(s) for delivery based on the current active allocation, where applicable.
* `actual_delivery_date` - 	The actual date and time that the shipment was delivered, where applicable.
* `allocation` - Details of the active allocated carrier and service for the shipment, where applicable.
* `label_details` - Links to retrieve labels for allocated shipments, and details on whether labels have already been retrieved.
* `reservation` - Details of any reservation for the shipment (for example, click and collect options), where applicable.
* `_links` - Links to any related resources.

> [!NOTE]
>
> For full reference information on the **Get Shipment** endpoint, see [LINK HERE]

### Example Get Shipment Call

The example below shows a **Get Shipment** request for a shipment with a `{reference}` of _sp_9953035299125395456009822134452_.

# [Get Shipment Request](#tab/get-shipment-request)

`GET https://api.sorted.com/pro/shipments/sp_9953035299125395456009822134452`

# [Get Shipment Response](#tab/get-shipment-response)

```json
{
    "reference": "sp_9953035299125395456009822134452",
    "state": "allocated",
    "created": "2019-04-25T16:12:14+01:00",
    "shipping_date": {
        "start": "2019-04-26T12:45:00+01:00",
        "end": "2019-04-26T16:45:00+01:00"
    },
    "required_shipping_date": {
        "start": "2019-04-26T00:00:00+01:00",
        "end": "2019-04-26T23:59:59+01:00"
    },
    "expected_delivery_date": {
        "start": "2019-04-28T09:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "required_delivery_date": { 
        "start": "2019-04-27T07:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "actual_delivery_date": null,
    "allocation": {
        "carrier": {
            "reference": "ABQ",
            "name": "ABQ Worldwide",
            "service_reference": "ABQ48",
            "service_name": "ABQ 48 Express"
        },
        "allocation_date": "2019-04-25T16:27:22+01:00",
        "price": {
            "net": 10.0,
            "gross": 12.0,
            "taxes": [
                {
                    "rate": {
                        "reference": "gb_standard",
                        "country_iso_code": "GB",
                        "type": "standard",
                        "value": 0.2
                    },
                    "amount": 2.0
                }
            ],
            "currency": "GBP",
            "tracking_references": [
                "TRK987987345"
            ],
            "_links": []
        }
    },
    "label_details": {
        "date_first_retrieved": "2019-04-25T16:27:23+01:00",
        "retrieval_count": 1,
        "_links": [
            {
                "href": "https://api.sorted.com/pro/labels/sp_9953035299125395456000008989766/zpl",
                "rel": "label",
                "reference": null,
                "type": "label"
            }
        ]
    },
    "tags": [
        "b&w",
        "T2"
    ],
    "order_date": "2019-04-05T09:34:55+01:00",
    "direction": "outbound",
    "shipment_type": "on_demand",
    "contents": [
        {
            "reference": "sc_10014418860050677760000090908111",
            "custom_reference": "b9fa91b0-0dd0-4dd5-986f-363fa8cb2386",
            "package_size_reference": null,
            "weight": {
                "value": 2.40,
                "unit": "Kg"
            },
            "dimensions": {
                "unit": "Cm",
                "width": 15.0,
                "height": 15.5,
                "length": 20.0
            },
            "description": "Jeans",
            "value": {
                "amount": 8.99,
                "currency": "GBP",
                "discount": 0.0
            },
            "sku": "SKU09876",
            "model": "MOD-009",
            "country_of_origin": "PO",
            "harmonisation_code": "09.02.10",
            "quantity": 2,
            "unit": "Box",
            "dangerous_goods": {
                "class_division": "2",
                "class_sub_divisions": [
                    "1"
                ],
                "packing_group": "iii",
                "id_number": "UN2202",
                "proper_shipping_name": "Hydrogen selenide, anhydrous",
                "technical_name": null,
                "physical_form": "gas",
                "radioactivity": "surface_reading",
                "accessibility": "accessible",
                "custom_label_text": null
            },
            "metadata": [
                {
                    "key": "Category",
                    "value": "Menswear",
                    "type": "string"
                }
            ],
            "label_properties": null,
            "Contents": null
        }
    ],
    "addresses": [
        {
            "address_type": "origin",
            "shipping_location_reference": "SLOC001"
        },
        {
            "address_type": "destination",
            "shipping_location_reference": null,
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865000090903324",
                "title": "Mr",
                "first_name": "Steve",
                "last_name": "Kingston",
                "middle_name": null,
                "position": null,
                "contact_details": {
                    "landline": null,
                    "mobile": "+447495747987",
                    "email": "steve@kingston.com"
                }
            },
            "property_number": "8",
            "property_name": null,
            "address_line_1": "Norbert Road",
            "address_line_2": "Bertwistle",
            "address_line_3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ],
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ],
    "reservation": {
        "reference": "rs_9953035320600231936990900087888",
        "location_reference": "8BDSF43555",
        "external_reference": "d6bc18f4-1d48-45fb-9586-8111db7ab827"
    },
    "source": "WMS",
    "tenant": "TEN001",
    "channel": "CHAN002"
}
```
---

## Getting Shipments by Custom Reference

The **Get Shipments by Custom Reference** endpoint enables you to search for shipment data by your own custom reference number. To call **Get Shipments by Custom Reference**, send a `GET` request to `https://api.sorted.com/pro/shipments?custom_reference={reference}`, where `{reference}` is the `custom_reference` you want to search on.

> [!NOTE]
> In PRO, a `custom_reference` is a user-specified reference for a shipment or item of shipment contents. Custom references do not need to be unique. For example, you might use the `custom_reference` property to add your own order number to all shipments corresponding to a particular order.

The `custom_reference` property can be applied to both shipments and `shipment_contents` objects. The **Get Shipments by Custom Reference** endpoint returns both those shipments that are directly tagged with the specified `custom_reference` _and_ those shipments that contain a `shipment_contents` object with the specified `custom_reference`.

> [!NOTE]
> For more information on the structure of shipment contents, see the [Specifying Shipment Contents](/pro/api/shipments/creating_shipments.html#specifying-shipment-contents) section of the [Creating Shipments](/pro/api/shipments/creating_shipments.html) page.

Once it has received the request, PRO returns a `shipment_list` object containing a list of shipments, the total number of results, the number of shipments requested and the number of shipments skipped.

### Example Get Shipments by Custom Reference Call

The example shows a successful request to get all shipments that either have the `custom_reference` or contain contents with the `custom_reference` _CR1234_.

# [Get Shipments by Custom Reference Request](#tab/get-shipments-by-custom-reference-request)

`GET https://api.sorted.com/pro/shipments?custom_reference=CR1234`

# [Get Shipments by Custom Reference Response](#tab/get-shipments-by-custom-reference-response)

<span class="highlight">NO JSON EXAMPLES OR WORKING ENDPOINTS FOR THIS YET</span>

---

> [!NOTE]
> For full reference information on the **Get Shipments by Custom Reference** endpoint, see <span class="highlight">LINK HERE</span>.

## Getting Shipments by Carrier Tracking Reference

The **Get Shipments by Carrier Tracking Reference** endpoint enables you to search for shipment data using a carrier tracking reference. To call **Get Shipments by Carrier Tracking Reference**, send a `GET` request to `https://api.sorted.com/pro/shipments/tracking_reference/{tracking_reference}`, where `{tracking_reference}` is the carrier tracking reference you want to search on.

Once it has received the request, PRO returns a `shipment_list` object containing a list of shipments, the total number of results, the number of shipments requested and the number of shipments skipped.

**Get Shipments by Carrier Tracking Reference** can only return allocated shipments, as carrier tracking references are assigned to shipments at the point of allocation. The carrier `tracking_reference` can be found in the shipment's `allocation.tracking_references` property. It can also be found in the `tracking_details.shipment.tracking_references` property of the Allocation Summary object that is returned when a shipment is allocated. 

> [!NOTE]
> As carrier tracking references can repeat, the **Get Shipments by Carrier Tracking Reference** endpoint only returns shipments that have been allocated within the last 30 days. Any older shipments may still be present in the database, but are not returned by the endpoint.

**Get Shipments by Carrier Tracking Reference** only works with those tracking references provided by carriers. It will not return shipments for internally-generated PRO or REACT references.

### Example Get Shipments by Carrier Tracking Reference Call

The example shows a successful request to get all shipments that have the carrier `tracking_reference` _CTR1234_.

# [Get Shipments by Carrier Tracking Reference Request](#tab/get-shipments-by-carrier-tracking-reference-request)

`GET https://api.sorted.com/pro/shipments/tracking_reference/CTR1234`

# [Get Shipments by Carrier Tracking Reference Response](#tab/get-shipments-by-carrier-tracking-reference-response)

<span class="highlight">NO JSON EXAMPLES OR WORKING ENDPOINTS FOR THIS YET</span>

---

> [!NOTE]
> For full reference information on the **Get Shipments by Carrier Tracking Reference** endpoint, see <span class="highlight">LINK HERE</span>.

## Paging Results

Both the **Get Shipments by Custom Reference** endpoint and the **Get Shipment by Carrier Tracking Reference** endpoint support optional `{take}` and `{skip}` parameters, which can be used to drive paging functions. The `{take}` parameter indicates the number of shipments to return (up to a maximum of 10), and the `{skip}` parameter indicates the number of shipment records PRO should "skip over" before it returns records.

For example, suppose that you have 15 shipments with a `custom_reference` of _CR1234_, and you want to return them as three pages of five shipments: 

* To view the first page of five, you would make a call to `GET https://api.sorted.com/pro/shipments?custom_reference=CR1234&take=5&skip=0` (that is, take five shipments and do not skip over any). 
* To view the second page, you would call `GET https://api.sorted.com/pro/shipments?custom_reference=CR1234&take=5&skip=5` (skip the first five shipments and then take the next five).
* To view the third page, you would call `GET https://api.sorted.com/pro/shipments?custom_reference=CR1234&take=5&skip=10` (skip the first ten shipments and then take the next five).

By default, `{take}` has a value of 10 and `{skip}` has a value of 0.

## Next Steps

* Learn how to create, clone, and update shipments: [Creating Shipments](/pro/api/shipments/creating_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)