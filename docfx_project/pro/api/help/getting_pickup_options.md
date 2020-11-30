---
uid: pro-api-help-getting-pickup-options
title: Getting Pickup Options
tags: v1,options,pro,api,consignments,pickup options
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Getting Pickup Options

Want to let your customers collect their deliveries from a pickup location? This page explains how to use the **Pickup Options** endpoint to offer available pickup locations and timeslots.

---

## Using the Pickup Options Endpoint

The **[Pickup Options](https://docs.electioapp.com/#/api/PickupOptions)** endpoint takes the details of an as-yet uncreated consignment and returns available pickup options. This information can be used to offer pickup timeslots and locations for the product that the customer is about to purchase.

> [!NOTE]
>
> For further information on what constitutes a pickup option, see the [Using Delivery and Pickup Options](using_delivery_and_pickup_options.md) page.

To call the **Pickup Options** endpoint, send a `POST` request to `https://api.electioapp.com/deliveryoptions/pickupoptions/`. At a minimum, the body of the request should contain the following information:

* **Distance** - The maximum distance from the destination address (in km) you want to receive results for.
* **Max Results** - The maximum number of results that you want to receive. This should be a value between one and 50.
* **Package Information**
* **Origin Address**
* **Destination Address**

 However, there are lots of other properties you can send when getting pickup options, including:

* Your own consignment reference.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the [Metadata](/pro/api/help/metadata.html) page.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the [Tags](/pro/api/help/tags.html) page.

Providing extra information can help you to improve the relevance of the options returned, and means that any consignments or orders you generate from an option will be populated with richer data.

Either the consignment's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

The **Pickup Options** endpoint returns a `{Locations}` array listing all the pickup locations that can meet your request criteria. Each `{Location}` object contains a `{DeliveryOptions}` array listing the delivery options that are available to that location for the proposed consignment.

Each `{DeliveryOptions}` object contains details of a particular option that could be used to deliver the consignment to the relevant `{location}`, including:

* **Reference** - A unique identifier for the option, used when selecting options in the next step.
* **Delivery Date**
* **Start** and **End Time**
* **Carrier Service**
* **Cost of Delivery**
* The latest **Shipping Date** and **Time** possible to meet the promise.

The pickup options available for a given consignment can change over time. This is primarily due to different carriers collecting at different times at each shipping location, or the pickup locations provider updating the list of active locations. 

> [!CAUTION]
>
> Pickup locations are classified as having either finite or infinite capacity. For locations with finite capacity, PRO may disable or enable a location at any time in line with demand for the location. Sorted strongly advise that location details are never cached for re-use in the web store or checkout due to the dynamic nature of this information.

> [!NOTE]
>
> For full reference information on the <strong>Pickup Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PickupOptions">Pickup Options</a></strong> page of the API reference.

### Pickup Options Example

The example shows a request to get no more than 10 pickup options for a fairly standard consignment, all within 1km of the recipient's location. PRO returns one location that meets the requested criteria, and three options for delivery to that location. All three options use the same carrier service and have a delivery time window of 09:30 - 17:30, but are scheduled for different days. In practice, PRO is saying that the carrier can deliver to the pickup location during business hours on the 17th, 18th or 19th or March (as required by the customer).

# [Get Pickup Options Request](#tab/get-pickup-options-request)

`POST https://api.electioapp.com/deliveryoptions/pickupoptions/`

```json
{
  "Distance": {
    "Unit": "Km",
    "Value": 1.0
  },
  "MaxResults": 10,
  "ConsignmentReferenceProvidedByCustomer": "Your reference",
  "DeliveryDate": "2020-03-19T00:00:00+00:00",
  "GuaranteedOnly": false,
  "ShippingDate": "2020-03-16T00:00:00+00:00",
  "Packages": [
    {
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

# [Get Pickup Options Response](#tab/get-pickup-options-response)

```json
{
    "Distance": 1,
    "MaxResults": 10,
    "Locations": [
        {
            "Name": "I-Smart Communications",
            "ShopReference": "GB14002",
            "Address": {
                "AddressLine1": "41 Whitworth Street West",
                "AddressLine2": "",
                "AddressLine3": "The Lock Building",
                "Town": "Manchester",
                "Region": "",
                "Postcode": "M1 5BD",
                "Country": {
                    "Name": "United Kingdom",
                    "IsoCode": {
                        "TwoLetterCode": "GB",
                        "ThreeLetterCode": "GBR",
                        "NumericCode": "826"
                    }
                },
                "RegionCode": "",
                "IsCached": false
            },
            "Distance": 0.15,
            "OpeningTimes": {
                "Monday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Tuesday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Wednesday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Thursday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Friday": [
                    {
                        "Start": "11:00:00",
                        "End": "18:00:00",
                        "UtcOffset": "0:00"
                    }
                ],
                "Saturday": [],
                "Sunday": []
            },
            "DeliveryOptions": [
                {
                    "Reference": "EDO-000-AHP-093",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-03-19T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Tuesday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-17T15:30:00+01:00",
                    "OperationalCutOff": "2019-05-17T15:00:00+01:00"
                },
                {
                    "Reference": "EDO-000-AHP-094",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-03-18T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Monday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-18T12:30:00+01:00",
                    "OperationalCutOff": "2019-05-18T12:00:00+01:00"
                },
                {
                    "Reference": "EDO-000-AHP-09G",
                    "EstimatedDeliveryDate": {
                        "Date": "2019-03-17T00:00:00+00:00",
                        "Guaranteed": true,
                        "DayOfWeek": "Sunday"
                    },
                    "DeliveryWindow": {
                        "Start": "09:00:00",
                        "End": "17:30:00",
                        "UtcOffset": "+01:00"
                    },
                    "Carrier": "DPD",
                    "CarrierService": "DPD Ship To Shop",
                    "CarrierServiceReference": "EDC5_DPDSS",
                    "Price": {
                        "Net": 5.99,
                        "Gross": 7.19,
                        "VatRate": {
                            "Reference": "GB-0.2000",
                            "CountryIsoCode": "GB",
                            "Type": "Standard",
                            "Rate": 0.2
                        },
                        "VatAmount": 1.2,
                        "Currency": {
                            "Name": "Pound Sterling",
                            "IsoCode": "GBP"
                        }
                    },
                    "AllocationCutOff": "2019-05-16T15:30:00+01:00",
                    "OperationalCutOff": "2019-05-16T15:00:00+01:00"
                }
            ],
            "Reservation": {
                "IsReservationRequired": false,
                "ExpiryDate": null
            },
            "AdditionalInformation": [
                {
                    "Key": "Language",
                    "Value": "en"
                },
                {
                    "Key": "DisabledAccess",
                    "Value": "True"
                }
            ]
        }
    ],
    "NonGuaranteedLocation": null
}
```

--- 

Note the `{Reference}` for each pickup option. When the customer selects their preferred delivery option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. For information on how to handle the choice the customer makes, see the [Selecting Options](/pro/api/help/selecting_options.html) page.

## Next Steps

* Learn how to get delivery options for a consignment at the [Getting Delivery Options](/pro/api/help/getting_delivery_options.html) page
* Learn how to create consignments and orders from delivery options at the [Selecting Options](/pro/api/help/selecting_options.html) page
* Learn how to manifest consignments at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page
