---
uid: pro-api-help-managing-existing-orders
title: Managing Existing Orders
tags: v1,orders,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 08/06/2020
---

# Managing Existing Orders

Need to make changes to an order before you pack it? This page explains how to retrieve and edit order details.

---

## Retrieving Orders

The **Get Order** endpoint returns full current details for a specific order. To call **Get Order**, send a `GET` request to `https://api.electioapp.com/orders/{orderReference}`.

> [!NOTE]
>
> For full reference information on the **Get Order** endpoint, see the <a href="https://docs.electioapp.com/#/api/GetOrder">API reference</a>.

### Example Get Order Call

The example below shows a **Get Order** request for a fairly simple order with an `{orderReference}` of _EO-000-002-K0R_. 

# [Get Order Request](#tab/get-order-request)

```json
GET https://api.electioapp.com/orders/EO-000-002-K0R
```

# [Get Order Response](#tab/get-order-response)

```json
{
    "OrderReference": "EO-000-002-K0R",
    "OrderReferenceProvidedByCustomer": null,
    "DeliveryOptionReference": null,
    "Packages": [
        {
            "Dimensions": {
                "Unit": "Cm",
                "Width": 10.00000,
                "Length": 10.00000,
                "Height": 10.00000
            },
            "Weight": {
                "Value": 0.50000,
                "Unit": "Kg"
            },
            "PackageSizeReference": null,
            "Items": [
                {
                    "Sku": "SKU093434",
                    "Reference": "02f60a1ff80c4f799799b2e9f281dd22",
                    "MetaData": [],
                    "Quantity": 1,
                    "Unit": null,
                    "Description": "Striped Bamboo Red/White",
                    "Dimensions": {
                        "Unit": "Cm",
                        "Width": 10.00000,
                        "Length": 10.00000,
                        "Height": 10.00000
                    },
                    "Weight": {
                        "Value": 0.50000,
                        "Unit": "Kg"
                    },
                    "HarmonisationKeyWords": [],
                    "Model": null,
                    "Value": {
                        "Amount": 5.9900,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "CountryOfOrigin": {
                        "Name": "United Kingdom",
                        "IsoCode": {
                            "TwoLetterCode": "GB"
                        }
                    },
                    "Barcode": null,
                    "ContentClassification": null,
                    "ContentClassificationDetails": null,
                    "ItemReferenceProvidedByCustomer": "",
                    "HarmonisationCode": null
                }
            ],
            "MetaData": [],
            "Value": {
                "Amount": 5.9900,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "Reference": "EP-000-002-QPF",
            "PackageReferenceProvidedByCustomer": "",
            "Description": "Socks",
            "Barcode": null
        }
    ],
    "DateCreated": "2020-03-10T09:59:12.9275216+00:00",
    "RequiredDeliveryDate": null,
    "ShippingDate": null,
    "MetaData": [],
    "EarliestDeliveryDate": null,
    "LatestDeliveryDate": null,
    "Weight": {
        "Value": 0.50000,
        "Unit": "Kg"
    },
    "Source": "Api",
    "Value": {
        "Amount": 5.99,
        "Currency": {
            "Name": "Pound Sterling",
            "IsoCode": "GBP"
        }
    },
    "Addresses": [
        {
            "AddressType": "Origin",
            "ShopLocationReference": null,
            "Contact": {
                "Reference": null,
                "Title": "",
                "FirstName": "",
                "LastName": "",
                "Position": null,
                "Telephone": "",
                "Mobile": "",
                "LandLine": "",
                "Email": ""
            },
            "CompanyName": null,
            "ShippingLocationReference": "Sorted1",
            "CustomerName": null,
            "AddressLine1": null,
            "AddressLine2": null,
            "AddressLine3": null,
            "Town": null,
            "Region": null,
            "Postcode": "",
            "Country": null,
            "RegionCode": null,
            "SpecialInstructions": null,
            "LatLong": null,
            "IsCached": false
        },
        {
            "AddressType": "Destination",
            "ShopLocationReference": null,
            "Contact": {
                "Reference": null,
                "Title": "Mr",
                "FirstName": "Peter",
                "LastName": "McPetersson",
                "Position": null,
                "Telephone": "07702123456",
                "Mobile": "07702123456",
                "LandLine": "0161544123",
                "Email": "peter.mcpetersson@test.com"
            },
            "CompanyName": null,
            "ShippingLocationReference": null,
            "CustomerName": null,
            "AddressLine1": "13 Porter Street",
            "AddressLine2": null,
            "AddressLine3": null,
            "Town": null,
            "Region": "Greater Manchester",
            "Postcode": "M1 5WG",
            "Country": {
                "Name": "United Kingdom",
                "IsoCode": {
                    "TwoLetterCode": "GB"
                }
            },
            "RegionCode": "",
            "SpecialInstructions": null,
            "LatLong": null,
            "IsCached": false
        }
    ],
    "CustomsDocumentation": null,
    "Direction": "Outbound",
    "Tags": []
}
```
---

## Updating Order Details

The **Update Order** endpoint enables you to update an existing order. To call **Update Order**, send a `PUT` request to `https://api.electioapp.com/orders/{orderReference}`.

When you make an **Update Order** request for a particular order, SortedPRO overwrites the existing order's details with new details provided in the body of the request. The structure of the **Update Order** request is identical to that of the **Create Order** request. 

PRO uses the following rules when updating order properties:

* `{OrderReference}` - Required property. Cannot be updated.
* `{OrderReferenceProvidedByCustomer}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{RequiredDeliveryDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Source}` - Ignored. Cannot be updated.
* `{ShippingDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Packages}` - Ignored. Use the **[Pack Order](https://docs.electioapp.com/#/api/PackOrder)** endpoint to manage an order's packages instead.
* `{CustomsDocumentation}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Addresses}`	- If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the order.
* `{MetaData}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Direction}` - If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the order.
* `{Tags}` - If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the order.

> [!NOTE]
>
>  For full reference information on the <strong>Update Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/UpdateOrder">Update Order</a></strong> page of the API reference.

Once it has received the request, PRO updates the order and returns a code _200_ message as confirmation. 

### Update Order Example

The example shows an **Update Order** request to update delivery and shipping dates on an order with an `{orderReference}` of _EO-000-002-K0R_.  

# [Update Order Request](#tab/update-order-request)

```json
PUT https://api.electioapp.com/orders/EO-000-002-K0R
```

# [Update Order Response](#tab/update-order-response)

```json
{
  "OrderReference": "EO-000-002-K0R",
  "RequiredDeliveryDate": {
    "Date": "2020-06-05T00:00:00+01:00",
    "IsToBeExactlyOnTheDateSpecified": true
  },
  "ShippingDate": "2020-05-31T00:00:00+01:00"
}
```
---

### Adding and Updating Order Addresses

In addition to the **Update Order** endpoint, PRO also features specific endpoints for adding and updating the addresses on a consignment.

* The **Add Address To Order** endpoint enables you to add a new address to an order. To call **Add Address To Order**, send a `POST` request to `https://api.electioapp.com/orders/{orderReference}/address`.
 
    **Add Address To Order** can only be used to add addresses with an address type that does not already exist on the order. For example, suppose that you have an order that already has _Origin_ and _Destination_ addresses. You could use **Add Address To Order** to add a new _Sender_ address to that order (because the order does not currently have a _Sender_ address), but you could not use it to add a new _Origin_ address (because the order does have an existing _Origin_).

* The **Update Address On Order** endpoint enables you to update an existing address on an order. To call **Update Address On Order**, send a `PUT` request to `https://api.electioapp.com/orders/{orderReference}/address`.
 
    **Update Address On Order** can only be used to edit addresses with an address type already exists on the order. For example, suppose that you have an order that already has _Origin_ and _Destination_ addresses. You could use **Update Address On Order** to edit those addresses (by using it to send a new `address` object with that `AddressType`), but not to add others of a different type. 

For both of these endpoints, the body of the request should contain an `address` object. The example below shows a new _Sender_ address.

# [Example Address Object](#tab/example-address-object)

```json
{
  "AddressType": "Sender",
  "Contact": {
    "Title": "Mr",
    "FirstName": "Peter",
    "LastName": "McPetersson",
    "Telephone": "07702123456",
    "Mobile": "07702123456",
    "LandLine": "0161544123",
    "Email": "peter.mcpetersson@test.com"
  },
  "CompanyName": "Update Address On Order Ltd.",
  "AddressLine1": "13 Porter Street",
  "AddressLine2": "Pressington",
  "AddressLine3": "Carlsby",
  "Town": "Manchester",
  "Region": "Greater Manchester",
  "Postcode": "M1 5WG",
  "Country": {
    "Name": "Great Britain",
    "IsoCode": {
      "TwoLetterCode": "GB"
    }
  },
  "SpecialInstructions": "Gate code: 4454",
  "LatLong": {
    "Latitude": 53.474220,
    "Longitude": -2.246049
  },
  "IsCached": false
}
```
---

Both **Add Address To Order** and **Update Address On Order** return an empty code _200_ message as confirmation that the address change was successful.

> [!NOTE]
>
> * For full reference information on the <strong>Add Address To Order</strong> endpoint, see the <a href="https://docs.electioapp.com/#/api/AddAddresstoOrder">Add Address To Order</a> page of the API reference.
> * For full reference information on the <strong>Update Address On Order</strong> endpoint, see the <a href="https://docs.electioapp.com/#/api/UpdateAddressonOrder">Update Address On Order</a> page of the API reference.

## Next Steps

* Learn how to pack orders into consignments at the [Creating Consignments From Orders](/pro/api/help/packing_orders.html) page.
* Learn how to retrieve delivery options at the [Getting Delivery Options](/pro/api/help/getting_delivery_options.html) page.
* Learn how to allocate consignments at the [Allocating Consignments](/pro/api/help/allocating_consignments.html) page.