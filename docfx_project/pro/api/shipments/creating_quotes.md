---
uid: pro-api-help-shipments-creating-quotes
title: Creating Quotes
tags: v2,shipments,pro,api,quotes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---
# Creating Quotes

This page explains how got get delivery quotes based on shipment details.

> [!NOTE]
> This page provides help and support for PRO version 2 (Shipments). As PRO v2 is currently in development, content may be removed or edited without warning.
>
> For support on PRO v1 (Consignments), [click here](/pro/api/help/introduction.html).  

---

## Making a Create Quote Request

<!--PRO has two endpoints that take the details of an as-yet uncreated shipment and return quotes:

* **Create Quote** can return quotes from any suitable carrier service. To call **Create Quote**, send a `POST` request to `https://api.sorted.com/pro/shipments/quote`.
* **Create Quote by Service Group** returns quotes from eligible services in the specified carrier service group.  To call **Create Quote by Service Group**, send a `POST` request to `https://api.sorted.com/pro/shipments/quote/service_group/{group_ref}`, where `{group_ref}` is the unique `reference` of the service group you want to get quotes within. 

The body of the request should contain a shipment object.

> [!NOTE]
>
> Both the **Create Quote** and **Create Quote by Service Group** endpoints take a shipment object in the body of the request. However, they do not create shipments in and of themselves. In order to allocate to one of the quotes returned by these endpoints, you would need to first create the shipment. 
>
> For more information on creating shipments, see the [Creating Shipments](/pro/api/shipments/creating_shipments.html) page.-->

PRO's **Create Quote** endpoint takes the details of an as-yet uncreated shipment and returns quotes for it. To call **Create Quote**, send a `POST` request to `https://api.sorted.com/pro/shipments/quote`.

As a minimum, the **Create Quote** endpoint requires you to send the following information in the request body:

* `shipment_type` - Specifies whether the shipment will be `on_demand` (i.e. will require an ad-hoc carrier collection to be booked) or `scheduled` (i.e. will be picked up as part of a regularly scheduled carrier collection ).
* `contents` - The contents of the shipment itself.
* `addresses` - All shipments require both `origin` and `destination` addresses.

However, there are lots of optional properties you can send when requesting quotes for a potential shipment, including:

* Your own custom reference for the shipment.
* Required shipping and delivery dates.
* The order date.
* Customs documentation for international shipments. For more information on using customs documentation in PRO, see the [Getting Shipment Documents](/pro/api/shipments/getting_shipment_documents.html) page.
* Shipment direction.
* Custom label properties.
* Tenant and channel.
* Metadata. PRO metadata enables you to use custom fields to record additional data about a shipment.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular shipment could be allocated to. For more information on allocation tags, see the [Using Shipment Tags](/pro/api/shipments/using_shipment_tags.html) page.

Adding optional properties when you request quotes for a shipment can help you to filter the list of quotes you receive down to the most appropriate carrier services.

> [!CAUTION]
>
> You should exercise caution when using the `required_delivery_date` and `required_shipping_date` parameters to specify dates for your shipment. These parameters limit delivery options for the shipment, meaning that it can only be allocated to carrier services that would be able to ship it within the specified `required_shipping_date` range and / or deliver it by the specified `required_delivery_date` range. 
>
> If the dates you specify are too restrictive, there may not be any carrier services available to take the shipment, which would result in a failed allocation. As such, you should only specify shipping and delivery dates where it is necessary to do so.

## The Quote Result

Once it has received the request, PRO returns a quote result. The quote result object includes a summary of the shipment details submitted, a list of `quote` objects, and a list of `excluded_services` (that is, eligible services for which it was not possible to obtain a delivery quote). 

Each `quote` object contains the following information:

* A unique reference for the quote. This property is important, as it is used when allocating shipments to the quote via the **Allocate Shipment With Quote** endpoint.
* Creation and expiry dates. 
* Details of the relevant carrier and carrier service.
* Confirmation of collection and delivery dates.
* Pricing information.

At this point, you would be able to display the relevant quote information to your customer service operative.

> [!NOTE]
> The quote `reference` begins with _qu_ and can be found in the `quotes.reference` property of the Quote Result. It is not to be confused with the Quote Result's own `reference`, which begins with _qc_ and is a unique reference for the entire quote response rather than a selectable quote.

## Example Quotes

The example below shows a quote request for a shipment. Note that PRO has returned two quotes, with a further service excluded as it cannot meet the delivery promise.

# [Quote Requests](#tab/create-quote-request)

`POST https://api.sorted.com/pro/shipments/quote`

```json
{
    "custom_reference": "0af07451-cf80-43cb-af24-acdfdbd41a14",
    "required_delivery_date": { 
        "start": "2020-04-27T07:00:00+01:00",
        "end": "2020-04-28T12:00:00+01:00"
    },
    "required_shipping_date": {
        "start": "2020-04-26T00:00:00+01:00",
        "end": "2020-04-26T23:59:59+01:00"
    },
    "tags": [
        "b&w",
        "T2"
    ],
    "order_date": "2020-04-05T09:34:55+01:00",
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string"
        },
        {
            "key": "refundable",
            "value": "false",
            "type": "bool"
        }
    ],
    "direction": "outbound",
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
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865",
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
            "address_line1": "Norbert Road",
            "address_line2": "Bertwistle",
            "address_line3": null,
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
    "source": "WMS"
}

```
# [Quote Response](#tab/create-quote-response)

```json
{
  "reference": "qc_00660740195638722361142689923072",
  "message": "2 quotes generated successfully",
  "shipment": {
    "addresses": [
      {
        "address_type": "origin",
        "shipping_location_reference": "SLOC001"
      },
      {
        "address_type": "destination",
        "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
        "contact": {
          "reference": "co_9953035290535460865",
          "title": "Mr",
          "first_name": "Steve",
          "last_name": "Kingston",
          "contact_details": {
            "mobile": "+447495747987",
            "email": "steve@kingston.com"
          }
        },
        "property_number": "8",
        "address_line1": "Norbert Road",
        "address_line2": "Bertwistle",
        "locality": "Preston",
        "region": "Lancashire",
        "postal_code": "PR4 5LE",
        "country_iso_code": "GB"
      }
    ],
    "custom_reference": "0af07451-cf80-43cb-af24-acdfdbd41a14"
  },
  "quotes": [
    {
      "reference": "qu_00660740195620275617068980371456",
      "carrier": {
        "reference": "PCLYINTL",
        "name": "Parcelly International",
        "service_reference": "PCLYINTLISF",
        "service_name": "International Superfast"
      },
      "collection_date": {
        "start": "2020-07-16T00:00:00+00:00",
        "end": "2020-07-16T20:00:00+00:00",
        "has_value": true
      },
      "delivery_date": {
        "start": "2020-07-17T09:00:00+00:00",
        "end": "2020-07-17T12:00:00+00:00",
        "has_value": true
      },
      "price": {
        "net": 20.0,
        "gross": 20.0,
        "taxes": [
          {
            "rate": {
              "reference": "zero_rated",
              "country_iso_code": "PT",
              "type": "zero_rated",
              "value": 0.0
            },
            "amount": 0.0
          }
        ],
        "currency": "EUR"
      },
      "created": "2020-07-15T13:39:57.7777258+00:00",
      "expires": "2020-07-15T23:59:00+00:00",
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/quotes/qu_00660740195620275617068980371456",
          "rel": "self",
          "reference": "qu_00660740195620275617068980371456",
          "type": "quote"
        }
      ]
    },
    {
      "reference": "qu_00660740195620275617068980371457",
      "carrier": {
        "reference": "QSDOM",
        "name": "QuickStep Domestic",
        "service_reference": "QSDOMLOC",
        "service_name": "QS Domestic Local"
      },
      "collection_date": {
        "start": "2020-07-16T00:00:00+00:00",
        "end": "2020-07-16T19:30:00+00:00",
        "has_value": true
      },
      "delivery_date": {
        "start": "2020-07-17T08:00:00+00:00",
        "end": "2020-07-17T15:45:00+00:00",
        "has_value": true
      },
      "price": {
        "net": 10.0,
        "gross": 12.0,
        "taxes": [
          {
            "rate": {
              "reference": "standard",
              "country_iso_code": "GB",
              "type": "VAT Standard",
              "value": 0.2
            },
            "amount": 2.0
          }
        ],
        "currency": "EUR"
      },
      "created": "2020-07-15T13:39:57.7779745+00:00",
      "expires": "2020-07-15T23:59:00+00:00",
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/quotes/qu_00660740195620275617068980371457",
          "rel": "self",
          "reference": "qu_00660740195620275617068980371457",
          "type": "quote"
        }
      ]
    }
  ],
  "excluded_services": [
    {
      "carrier": {
        "reference": "DNT",
        "name": "DNT Express",
        "service_reference": "DNTEXPOD",
        "service_name": "DNT ExpressPack On Demand"
      },
      "exclusion": {
        "reason": "Carrier does not have availability for this shipment for the given date(s)",
        "code": "ex_availability"
      }
    }
  ]
}
```
---


> [!NOTE]
>
> For full reference information on the **Create Quote** endpoint, see the [PRO v2 API reference](/pro/api/reference/shipments.html#tag/Quotes/paths/~1shipments~1quote/post).

## Next Steps

* Learn how to create shipments at the [Creating Shipments](/pro/api/shipments/creating_shipments.html) page.
* Learn how to allocate shipments at the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.
* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.