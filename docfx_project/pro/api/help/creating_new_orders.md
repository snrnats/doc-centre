---
uid: pro-api-help-creating-new-orders
title: Creating New Orders
tags: orders,pro,api,consignments,EORI number
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---

# Creating New Orders

The first step in using SortedPRO orders is to create the order itself. This page explains the various ways in which you can create orders.

---

## Creating Orders Directly  

The **[Create Order](https://docs.electioapp.com/#/api/CreateOrder)** endpoint enables you to record details of a customer's order in SortedPRO. To call **Create Order**, send a `POST` request to `https://api.electioapp.com/orders`.

The body structure of the **Create Order** request is very similar to that of the **Create Consignments** request, with the exception that items on an order do not need to share an origin, ship date, and carrier.

> [!NOTE]
>
> For more information on the difference between orders and consignments, see the [Managing Orders](/pro/api/help/managing_orders.html) page.

At a minimum, the **Create Order** endpoint requires you to send item, origin address, and destination address data. However, there are lots of other properties you can send when creating an order, including:

* Your own order reference.
* The order's source.
* The required delivery date.
* Customs documentation.
* The order's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the [Metadata](/pro/api/help/metadata.html) page.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the [Tags](/pro/api/help/tags.html) page.

Either the order's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

> [!NOTE]
>
> * For full reference information on the <strong>Create Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/CreateOrder">Create Order</a></strong> page of the API reference.
> * For an example call flow showing orders being created, see the <a href="/pro/api/help/flows/order_flex_flow.html">Order Flex</a> call flow page.

### Adding an EORI Number

If required, you can record a order's EORI number using the `Metadata` property. To do so, add a property with a `KeyValue` of _ShippersEORI_ and a `StringValue` representing the number itself.

# [EORI Number Example](#tab/eori-number-example)

```json
{
    "OrderReferenceProvidedByCustomer": "YOUR-REF",
    "Addresses": [
        // addresses
    ],
    "Packages": [
        // package properties
    ],
    "Metadata": [
        {
            "KeyValue": "ShippersEORI",
            "StringValue": "GB987654312000"
        }
    ]
    // other order properties
}

```
---

If you add a `ShippersEORI` metadata property to an international order, then PRO automatically adds that property to any consignments that are packed from that order. PRO also automatically adds an **EORI Number** field to any commercial invoices that it generates from those consignments.

> [!NOTE]
> * For more information on commercial invoices and other customs documents in PRO, see the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page. 
> * For more information on packing orders, see the [Creating Consignments From Orders](/pro/api/help/packing_orders.html)

### Create Order Example

The example shows the creation of a fairly standard order. In this case, we have an outbound order comprising a single package with a single item inside it. After receiving the request, PRO returns an `{orderReference}` of _EO-000-002-0TS_. You will need the `{orderReference}` when you come to pack the order into shippable consignments.

# [Create Order Request](#tab/create-order-request)

`POST https://api.electioapp.com/orders`

```json
{
  "Packages": [
    {
    	"Items": [
        {
          "Sku": "SKU093434",
          "Description": "Striped Bamboo Red/White",
          "CountryOfOrigin": {
            "IsoCode": {
              "TwoLetterCode": "GB"
            }
          },
          "Weight": {
            "Value": 0.5,
            "Unit": "Kg"
          },
          "Dimensions": {
            "Unit": "Cm",
            "Width": 10.0,
            "Length": 10.0,
            "Height": 10.0
          },
          "Value": {
            "Amount": 5.99,
            "Currency": {
              "IsoCode": "GBP"
            }
          }
        }   
      ],
      "Weight": {
        "Value": 0.5,
        "Unit": "Kg"
      },
      "Dimensions": {
        "Unit": "Cm",
        "Width": 10.0,
        "Length": 10.0,
        "Height": 10.0
      },
      "Description": "Socks",
      "Value": {
        "Amount": 5.99,
        "Currency": {
          "IsoCode": "GBP"
        }
      }
    }  
  ],
  "Addresses": [
    {
      "AddressType": "Origin",
      "ShippingLocationReference": "Sorted1",
      "IsCached": false
    },
    {
      "AddressType": "Destination",
      "Contact": {
        "Title": "Mr",
        "FirstName": "Peter",
        "LastName": "McPetersson",
        "Telephone": "07702123456",
        "Mobile": "07702123456",
        "LandLine": "0161544123",
        "Email": "peter.mcpetersson@test.com"
      },
      "AddressLine1": "13 Porter Street",
      "Region": "Greater Manchester",
      "Postcode": "M1 5WG",
      "Country": {
        "Name": "Great Britain",
        "IsoCode": {
          "TwoLetterCode": "GB"
        }
      },
      "IsCached": false
    }
  ]
}
```

# [Create Order Response](#tab/create-order-response)

```json
[
  {
    "Rel": "Order",
    "Href": "https://api.electioapp.com/orders/EO-000-002-0TS"
  }
]
```
--- 

## Creating Orders From Delivery Options

The **Create Orders** endpoint isn't the only PRO endpoint that can generate orders. You can also create orders via the **Delivery Options** API, which enables you to get a list of delivery options for a potential order that you can present to your customer at checkout. When you select the required option as an order, PRO automatically creates a new order without requiring you to make additional API calls.

Creating orders in this way lets you provide front-end delivery options in circumstances where you cannot guarantee that the contents of your customer's online basket will map directly to a single consignment (and so first need to create an order that you can pack into consignments). For example, you might operate more than one warehouse and so may need to ship some orders in multiple consignments.

> [!NOTE]
>
> Access to PRO's delivery and pickup option endpoints requires a SortedHERO license. This component is sold separately to the main SortedPRO product. 

To create an order from delivery options, you'll need to make two API calls: 

1. Call the **Delivery Options** endpoint. The structure of the **Delivery Options** request is very similar to that of the **Create Order** request. However, rather than simply creating an order from the information, PRO instead returns a list of potential delivery options for the (as yet uncreated) order. Each delivery option represents a delivery date and time, and a suitable carrier service. 

2. Select the option that the customer chooses as an order. To do so, call **Select Delivery Option As An Order** by sending a `POST` request to `https://api.electioapp.com/deliveryoptions/selectorder` with the `Reference` of the delivery option you want to select in the body of the request. 

You can also generate orders from pickup options. The process is the same as that used for delivery options - make a **Pickup Options** call and then select the required option via the **Select Delivery Option As Order** endpoint.

> [!NOTE]
>
> * For a full user guide on working with delivery and pickup options, including further information on selecting options, see the <a href="/pro/api/help/using_delivery_and_pickup_options.html">Using Delivery and Pickup Options</a> section.
> * For reference information on the Delivery Options and Pickup Options APIs, see the <a href="https://docs.electioapp.com/#/api/DeliveryOptions">API reference</a>.

## Next Steps

* Learn how to work with existing orders at the [Managing Existing Orders](/pro/api/help/managing_existing_orders.html) page.
* Learn how to pack orders into consignments at the [Creating Consignments From Orders](/pro/api/help/packing_orders.html) page.
* Learn how to retrieve delivery options at the [Getting Delivery Options](/pro/api/help/getting_delivery_options.html) page.