---
uid: pro-api-help-shipments-creating-shipments
title: Creating Shipments
tags: v2,shipments,pro,api
contributors: andy.walton@sorted.com
created: 05/10/2020
---
# Creating Shipments

In order for SortedPRO to manage a shipment, you'll need to record the details of that shipment on the system. This page explains how to use the **Create Shipment** endpoint to create a new shipment record<!--, how to clone existing shipments using the **Clone Shipment** endpoint, and how to update existing shipments using the **Update Shipment** endpoint-->.

---

## Sending a Create Shipment Request

The **Create Shipment** endpoint enables you to create new shipment records within PRO. When you send a valid **Create Shipment** request, PRO generates a new shipment record and returns a unique `{reference}` for that shipment. Many of PRO's endpoints take this shipment `{reference}` as a parameter.

To create a shipment, send a `POST` request to `https://api.sorted.com/pro/shipments`. The body of the request should contain the shipment details, structured as per the PRO data contract.

### Required Shipment Properties

As a minimum, the **Create Shipments** endpoint requires you to send:

* `shipment_type` - Specifies whether the shipment is `on_demand` (i.e. will require an ad-hoc carrier collection to be booked) or `scheduled` (i.e. will be picked up as part of a regularly scheduled carrier collection).
* `contents` - The contents of the shipment itself.
* `addresses` - All shipments require both `origin` and `destination` addresses.

> [!TIP]
>
> PRO handles collection booking for `on_demand` shipments as a background process when the shipment is allocated to a carrier service. You do not need to specify `on_demand` booking details manually.

### Specifying Shipment Contents

The `contents` object replaces the `package` and `item` objects used in PRO's version 1 consignments-based implementation. `Contents` objects are designed to nest within each other, and can be used at both package and item level.

As an example, suppose that a clothing retailer has received a customer order for a necklace, a bracelet, and a coat. As the necklace and bracelet are both physically small, the retailer elects to ship them in the same package. The resulting shipment would contain:

* One `contents` object containing details of the coat and its accompanying package.
* One `contents` object containing details of the package that the necklace and bracelet are shipping in.
* One `contents` object containing details of the necklace, nested inside the object representing its package.
* One `contents` object containing details of the bracelet, nested inside the object representing its package.

The example below shows how this shipment would be represented in JSON. This is a highly simplified example, with only the minimum properties given for each `contents` object. In practice, you would probably look to provide additional detail on the shipment contents by specifying optional properties. 

# [Contents Example](#tab/contents-example)

```json
"contents": [
    {
        "description": "Coat",
        "value": {
            "amount": 30,
            "currency": "GBP"
        },
        "shipping_terms": "fca",
        "contents": null
    },
    {
        "description": "Package",
        "value": {
            "amount": 40,
            "currency": "GBP"
        },
        "shipping_terms": "fca",            
        "contents": [
            {
                "description": "Necklace",
                "value": {
                    "amount": 20,
                    "currency": "GBP"
                },
                "shipping_terms": "fca",                    
                "contents": null
            },
            {
                "description": "Bracelet",
                "value": {
                    "amount": 20,
                    "currency": "GBP"
                },
                "shipping_terms": "fca",                        
                "contents": null
            }
        ]    
    }
]
```
---

### Specifying Addresses

All shipments require both `origin` and `destination` addresses. In PRO, addresses are represented by `address` objects, which must be specified as a list inside the `shipments.addresses` property. As a minimum, each address must include the following:

* `address_type` - As well as `origin` and `destination` address types, PRO enables you to specify `return`, `sender`, `recipient`, `importer`,	and `billing` addresses.
* `shipping_location_reference` - Each shipping location that you run scheduled shipments from should have a unique shipping location reference. The `shipping_location_reference` property is optional for `on_demand` shipments but required for `scheduled` shipments. Where provided, the value must be a valid shipping location reference for your organisation.
* `contact`- Details of the contact at the address (for example, the name of the recipient). This property is only required where a `shipping_location_reference` is not provided.
* `address_line_1` - All addresses must have at least one line.
* `region` - The state, county, or equivalent. This property is required for certain countries, such as the US, Australia, and Canada.
* `postal_code` - Required for countries with official postcode systems, such as the UK.
* `country_iso_code` - The ISO 3166 Alpha 2 code for the country.

In addition, PRO supports several optional address properties, including custom references, company details, and latitude / longitude. See the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Shipments/paths/~1shipments/post) for details.

### Optional Shipment Properties

There are lots of optional properties you can send when creating a shipment, including:

* Your own custom reference for the shipment.
* Required shipping and delivery dates.
* The order date.
* Customs documentation for international shipments. For more information on using customs documentation in PRO, see the [Getting Shipment Documents](/pro/api/shipments/getting_shipment_documents.html) page.
* Shipment direction.
* Custom label properties.
* Tenant and channel.
* Metadata. PRO metadata enables you to use custom fields to record additional data about a shipment.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular shipment could be allocated to. For more information on allocation tags, see the [Using Shipment Tags](/pro/api/shipments/using_shipment_tags.html) page.

Adding optional properties when you create a shipment can help you to ensure that your shipment is allocated to the most appropriate carrier service.

> [!CAUTION]
>
> You should exercise caution when using the `required_delivery_date` and `required_shipping_date` parameters to specify dates for your shipment. These parameters limit delivery options for the shipment, meaning that it can only be allocated to those carrier services that would be able to ship it within the specified `required_shipping_date` range and / or deliver it by the specified `required_delivery_date` range. 
>
> If the dates you specify are too restrictive, there may not be any carrier services available to take the shipment, which would result in a failed allocation. As such, you should only specify shipping and delivery dates where it is necessary to do so.

### Example Create Shipment Request

The example below shows a simple **Create Shipment** request containing only a `shipment_type`, `contents`, and `addresses`. For an example of a full **Create Shipment** request, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Shipments/paths/~1shipments/post).

# [Create Shipment Request](#tab/create-shipment-request)

`POST https://api.sorted.com/pro/shipments`

```json


{
    "shipment_type": "on_demand",
    "contents": [
        {
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
                "currency": "GBP"
            },
            "sku": "SKU09876",
            "model": "MOD-009",
            "country_of_origin": "PT",
            "harmonisation_code": "09.02.10",
            "shipping_terms": "fca",
            "quantity": 2,
            "unit": "Box",
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
            "address_type": "Origin",
            "contact": {
                "reference": "co_9953035290535460864",
                "title": "Mr",
                "first_name": "Mark",
                "last_name": "Brunell",
                "contact_details": {
                    "mobile": "+447495747987",
                    "email": "mark@62-7.com"
                }
            },
            "property_number": "1",
            "property_name": "Frank's Place",
            "address_line1": "Zappa Avenue",
            "address_line2": "Off Rock Road",
            "address_line3": "Off Heavy Crescent",
            "locality": "Manchester",
            "region": "Greater Manchester",
            "postal_code": "M2 6LW",
            "country_iso_code": "GB"
        },
        {
            "address_type": "destination",
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865",
                "title": "Mr",
                "first_name": "Gardner",
                "last_name": "Minshew",
                "middle_name": null,
                "position": null,
                "contact_details": {
                    "landline": null,
                    "mobile": "+447495747987",
                    "email": "gminshew@test.com"
                }
            },
            "property_number": "8",
            "property_name": null,
            "address_line1": "Norbert Road",
            "address_line2": "Bertwistle",
            "address_line3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ]
}

```
---

## The Create Shipments Response

Once it has received the shipment information, PRO creates the shipment record and returns a link to the newly-created shipment, including its `{reference}`. 

The `{reference}` is a unique identifier for that shipment within PRO, and is a required parameter for many of PRO's API requests. Each PRO shipment `{reference}` takes the format `sp_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx`, where `x` is a numerical digit. 

In the example below, PRO has returned a shipment `{reference}` of _sp_00595452779180472847666078547968_. 

# [Create Shipment Response](#tab/create-shipment-response)

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "message": "Shipment created successfully",
  "_links": [
    {
      "href": "https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968",
      "rel": "shipment",
      "reference": "sp_00595452779180472847666078547968",
      "type": "shipment"
    }
  ]
}
```
---

All PRO shipments have a `{state}`, indicating the point in the delivery process that that particular shipment is at. Newly-created shipments have an initial state of `Unallocated`. For more information on PRO shipment states, see the [Shipment States](/pro/api/shipments/shipment_states.html) page.

> [!NOTE]
>
> For full reference information on the **Create Shipments** endpoint, including the properties accepted and the structure required, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Shipments/paths/~1shipments/post).

<!--## Cloning Shipments

<span class="commented-out">CLONE SHIPMENTS IS IN DRAFT AT THE TIME OF WRITING - THIS ALL NEEDS FULLY REVIEWING BEFORE GO-LIVE</span>

As well as creating entirely new shipments through the **Create Shipment** endpoint, you can also clone existing shipments via the **Clone Shipment** endpoint. **Clone Shipment** takes the basic properties of a given shipment, creates a new shipment with identical properties, and returns that new shipment's `{reference}`. 

> [!NOTE]
>
> **Clone Shipment** only clones those shipment properties that can be specified via the **Create Shipment** endpoint. For example, it will copy `address` and `contents` details to the new shipment, but not allocation details.

To call **Clone Shipment**, send a `POST` request to `https://api.sorted.com/pro/shipments/{reference}/clone`, where `{reference}` refers to the shipment you want to clone. Once it has received the request, PRO creates the new shipment record and returns a link to the newly-created shipment.

### Clone Shipment Example 

The example below shows a request to clone a shipment <span class="commented-out">NEED TO PUT IN EXAMPLE ONCE THE ENDPOINT STUB IS UP AND RUNNING</span>

> [!NOTE]
>
> For full reference information on the **Clone Shipment** endpoint, see the Shipments data contract 

## Updating Shipments

You can update an existing unallocated shipment via the **Update Shipment** endpoint. When you make an **Update Shipment** request, SortedPRO overwrites the relevant shipment's details with new details provided in the body of the request.

To call **Update Shipment**, send a `PUT` request to `https://api.sorted.com/pro/shipments`. You will need to specify the shipment `reference` in the body of the request, but the request should otherwise be structured in the same way as a **Create Shipment** request. 

> [!NOTE]
> The **Update Shipment** endpoint cannot be used to edit a shipment's paperless documents. To edit paperless documents on an existing shipment, use the Paperless Documents endpoints. For more information on working with paperless documents in PRO, see the [Adding Paperless Documents](/pro/api/shipments/adding_paperless_documents.html) page.

Other than the `reference` and `paperless_documents`, **Update Shipment** uses the same validation as **Create Shipment** (that is, `shipment_type`, `contents`, and `addresses` are required and all other valid properties are optional). 

You can only pass properties that would be accepted by a **Create Shipment**  request when using **Update Shipment**. For example, you can update a shipment's `contents` and `custom_reference`, but not its `allocation` details or `state`.

When it has received the request, PRO replaces the _entire_ shipment object for the specified shipment with the new details you provided, and returns a confirmation message.

> [!CAUTION]
>
> If you do not pass a value for an optional property when making an **Update Shipment** request then PRO will not store any value for that property, even if that property had a value before you updated the shipment.

You cannot update a shipment that has already been allocated, because PRO uses a shipment's current details to decide the carrier services that that shipment can be allocated to.

### Update Shipment Example

The example shows a simple **Update Shipment** request for a shipment with a `{reference}` of  _sp_00595452779180472847666078547968_. The request is successful, meaning that PRO has any previous details for that shipment with the details in the request.

# [Example Update Shipment Request](#tab/example-update-shipment-request)

`PUT https://api.sorted.com/pro/shipments`

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "custom_reference": "MyCustomRef002",
  "shipment_type": "on_demand",
  "direction": "outbound",
  "contents": [
    {
	  "value": {
	    "amount": 2.99,
		"currency": "GBP"
	  }
	}
  ],
  "addresses": [
    {
	  "address_type": "origin",
	  "shipping_location_reference": "myref"
	},
	{
	  "address_type": "destination",
	  "shipping_location_reference": "myref002"
    }
  ]
}
```

# [Example Update Shipment Response](#tab/example-update-shipment-response)

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "custom_reference": "MyCustomRef002",
  "message": "Shipment sp_00595452779180472847666078547968 has been updated successfully",
  "_links": [
    {
      "href": "https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968",
      "rel": "shipment",
      "reference": "sp_00595452779180472847666078547968",
      "type": "shipment"
    }
  ]
}
```
---

> [!NOTE]
>
> For full reference information on the **Update Shipment** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Shipments/paths/~1shipments/put). -->

## Next Steps

* Learn how to retrieve shipment data: [Getting Shipments](/pro/api/shipments/getting_shipments.html)
* Learn how to cancel shipments: [Cancelling Shipments](/pro/api/shipments/cancelling_shipments.html)
* Learn how to allocate shipments: [Allocating Shipments](/pro/api/shipments/allocating_shipments.html)