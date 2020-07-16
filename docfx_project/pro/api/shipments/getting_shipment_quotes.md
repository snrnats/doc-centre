---
uid: pro-api-help-shipments-getting-shipment-quotes
title: Getting Shipment Quotes
tags: shipments,pro,api,quotes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 02/07/2020
---

# Getting Shipment Quotes

This page explains how to get delivery quotes for a shipment that already exists in PRO.

---

The **Get Quote** endpoint returns quotes based on the details of an existing shipment. Specifically, it takes a shipment `reference` and uses that shipment's details to return a list of `quote`s. 

To call **Get Quote**, send a `GET` request to `https://api.sorted.com/pro/shipments/{reference}/quote`, where `reference` is the unique identifier of the shipment you want to get quotes for.

Once it has received the request, PRO returns a quote result. The quote result object includes a summary of the shipment details submitted, a list of `quote` objects, and a list of `excluded_services` (that is, eligible services for which it was not possible to obtain a delivery quote). 

Each `quote` object contains the following information:

* A unique reference for the quote. This property is important, as it is used when allocating shipments to the quote via the **Allocate Shipment With Quote** endpoint.
* Confirmation of the shipment `reference` that you requested quotes for.
* Creation and expiry dates. 
* Details of the relevant carrier and carrier service.
* Confirmation of collection and delivery dates.
* Pricing information.

At this point, you would be able to display the relevant quote information to your customer service operative.

> [!NOTE]
> The quote `reference` begins with _qu_ and can be found in the `quotes.reference` property of the Quote Result. It is not to be confused with the Quote Result's own `reference`, which begins with _qr_ <span class="highlight">NEED TO CHECK THIS, SOME CALLS ARE COMING BACK WITH IT STARTING WITH QC</span> and is a unique reference for the entire quote response rather than a selectable quote.

### Get Quote Example

The example shows a request to get quotes for shipment _sp_00662089297971405204020773257216_. PRO has retrieved two quotes, with a further service excluded as it cannot meet the delivery promise.

# [Get Quote Request](#tab/get-quote-request)

```json
`GET https://api.sorted.com/pro/shipments/sp_00662089297971405204020773257216/quote`
```

# [Get Quote Response](#tab/get-quote-response)

```json
{
  "reference": "qc_00662089901143042926175691997186",
  "message": "2 quotes retrieved successfully for shipment sp_00662089297971405204020773257216",
  "shipment": {
    "reference": "sp_00662089297971405204020773257216",
    "addresses": [
      {
        "address_type": "origin",
        "shipping_location_reference": "ab_00662089901143042926175691997187",
        "contact": {
          "title": "Mr",
          "first_name": "Alan",
          "last_name": "McBride",
          "position": "General Manager",
          "contact_details": {
            "landline": "020 7287 5007",
            "email": "orders@redwinglondon.com"
          }
        },
        "property_number": "17a",
        "property_name": "Porter House",
        "address_line1": "Newburgh Street",
        "address_line2": "Oxford Circus",
        "locality": "London",
        "region": "Greater London",
        "postal_code": "W1F 7RZ",
        "country_iso_code": "GB"
      },
      {
        "address_type": "destination",
        "contact": {
          "title": "Mr",
          "first_name": "Andrew",
          "last_name": "Lock",
          "contact_details": {
            "landline": "202-555-0186",
            "email": "andrew_lock2000@gmail.com"
          }
        },
        "property_number": "5801",
        "property_name": "Edward H. Levi Hall",
        "address_line1": "South Ellis Avenue",
        "locality": "Chicago",
        "region": "IL",
        "postal_code": "60637",
        "country_iso_code": "US"
      }
    ],
    "custom_reference": "me_00662089901143042926175691997188",
    "_links": [
      {
        "href": "https://beta.sorted.com/pro/shipments/sp_00662089297971405204020773257216",
        "rel": "shipment",
        "reference": "sp_00662089297971405204020773257216",
        "type": "shipment"
      }
    ]
  },
  "quotes": [
    {
      "reference": "qu_00662089901143042926175691997184",
      "shipment_reference": "sp_00662089297971405204020773257216",
      "carrier": {
        "reference": "PCLYINTL",
        "name": "Parcelly International",
        "service_reference": "PCLYINTLISF",
        "service_name": "International Superfast"
      },
      "collection_date": {
        "start": "2020-07-17T00:00:00+00:00",
        "end": "2020-07-17T20:00:00+00:00",
        "has_value": true
      },
      "delivery_date": {
        "start": "2020-07-18T09:00:00+00:00",
        "end": "2020-07-18T12:00:00+00:00",
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
      "created": "2020-07-16T09:59:25.4607538+00:00",
      "expires": "2020-07-16T23:59:00+00:00",
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/quotes/qu_00662089901143042926175691997184",
          "rel": "self",
          "reference": "qu_00662089901143042926175691997184",
          "type": "quote"
        }
      ]
    },
    {
      "reference": "qu_00662089901143042926175691997185",
      "shipment_reference": "sp_00662089297971405204020773257216",
      "carrier": {
        "reference": "QSDOM",
        "name": "QuickStep Domestic",
        "service_reference": "QSDOMLOC",
        "service_name": "QS Domestic Local"
      },
      "collection_date": {
        "start": "2020-07-17T00:00:00+00:00",
        "end": "2020-07-17T19:30:00+00:00",
        "has_value": true
      },
      "delivery_date": {
        "start": "2020-07-18T08:00:00+00:00",
        "end": "2020-07-18T15:45:00+00:00",
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
      "created": "2020-07-16T09:59:25.4607593+00:00",
      "expires": "2020-07-16T23:59:00+00:00",
      "_links": [
        {
          "href": "https://beta.sorted.com/pro/quotes/qu_00662089901143042926175691997185",
          "rel": "self",
          "reference": "qu_00662089901143042926175691997185",
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
> For full reference information on the **Get Quote** endpoint, see LINK HERE

## Next Steps

* Learn how to create shipments at the [Creating Shipments](/pro/api/shipments/creating_shipments.html) page.
* Learn how to allocate shipments at the [Allocating Shipments](/pro/api/shipments/allocating_shipments.html) page.
* Learn how to add shipments to a carrier manifest at the [Manifesting Shipments](/pro/api/shipments/manifesting_shipments.html) page.