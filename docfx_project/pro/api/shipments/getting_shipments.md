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

The **Get Shipments by Custom Reference** endpoint enables you to search for shipment data by your own custom reference number.

In PRO, a `custom_reference` is a user-specified reference for a shipment or item of shipment contents. Custom references do not need to be unique. For example, you might add your own order number as a custom reference to all shipments corresponding to a particular order.

`GET https://api.sorted.com/pro/shipments?custom_reference={reference}&take={int}&skip={int}`

The {take} and {skip} values can be used to drive paging functions in systems that present a list of consignments to the user. For example, suppose that you have 100 active consignments in an Allocated state. A call to GET https://api.electioapp.com/consignments/100/0?&State=Allocated would return all of those consignments, as a {take} value of 100 and a {skip} value of 0 means that the API will return up to 100 results without skipping over any.

However, suppose that you want to split the list up into two groups of 50 (for example, because you are using the data to populate a list in a system whose UI only enables you to display 50 results at any one time). In this case, you would populate the first page of results with a call to GET https://api.electioapp.com/consignments/50/0?&State=Allocated (max. 50 results, none skipped). If the user elects to view the second page, you would call GET https://api.electioapp.com/consignments/50/50?&State=Allocated. The API would again return 50 results, but would skip over the first 50 in the list (i.e. those results that were displayed on the first page) and instead return results 51-100.

## Getting Shipments by Tracking Reference

Get Shipment by Carrier Tracking Reference

`GET https://api.sorted.com/pro/shipments/tracking_reference/{tracking_reference}?take={int}&skip={int}`

## Next Steps

* Learn how to create, clone, and update shipments: [Creating Shipments](/pro/api/shipments/creating_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)