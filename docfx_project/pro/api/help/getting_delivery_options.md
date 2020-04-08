# Getting Delivery Options

This page explains how to get a list of delivery options for a consignment, both as a summary and with full details.

---

## Getting Detailed Options

The Delivery Options endpoint takes the details of an as-yet-nonexistent consignment and returns a list of delivery options. To call **Delivery Options**, send a `POST` request to `https://api.electioapp.com/deliveryoptions`.

> <span class="note-header">Note:</span>
>
> For further information on what constitutes a delivery option, see the [Using Delivery and Pickup Options](using_delivery_and_pickup_options.md) page.

At a minimum, PRO requires you to send the consignment's package, origin address and destination address data in your **Delivery Options** request. However, there are lots of other properties you can send when getting delivery options, including:

* Your own consignment reference.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to record additional data about a consignment in custom fields. For more information on using metadata in PRO, see the **[Metadata](/api/flows/moreInfo.html#metadata)** section of the **More Information** page.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see the **[Tags](/api/flows/moreInfo.html#tags)** section of the **More Information** page.

Providing extra information can help you to improve the relevance of the options returned, and means that any consignments or orders you generate from an option will be populated with richer data.

Either the consignment's `origin` address, its `destination` address, or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

Once it has received the request, PRO returns an array of `{DeliveryOptions}` objects. Each `{DeliveryOptions}` object contains details of a particular delivery option that is available to take a consignment with the details you passed in the request, including:

* **Reference** - A unique identifier for the delivery option, used when selecting delivery options in the next step.
* **Dates and Delivery Windows**
* **Carrier Service**
* **Price (cost)**
* **Allocation Cutoff** - The option's expiry time. If the option is not used by this time, it is rendered invalid. This value is usually set by the carrier, but can be configured manually via the **Settings > [Shipping Locations](https://www.electioapp.com/Configuration/ShippingLocations) > [Select Location] > Collection Calendar** page of the PRO UI. 
* **Operational Cutoff** - 	The operational cut off date as specified by the fulfilling shipping location.
* **Service Direction**

PRO only returns a single carrier service for each delivery window on each date. This is generally the cheapest service, unless using the cheapest service would conflict with existing business rules. 

> <span class="note-header">Note:</span>
>
>  For full reference information on the <strong>Delivery Options</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/DeliveryOptions">Delivery Options</a></strong> page of the API reference.

### Get Delivery Options Example

The example shows a request to get delivery options for a fairly standard consignment. 

<div class="tab">
    <button class="staticTabButton">Example Delivery Options Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'DelOptionsRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="DelOptionsRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'DelOptionsRequest')">

```json
{
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

</div>

The API has returned two delivery options, both for Carrier X: one with an `{estimatedDeliveryDate}` of _2020-03-18_ and one with an `{estimatedDeliveryDate}` of _2020-03-19_.

<div class="tab">
    <button class="staticTabButton">Delivery Options Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'DelOptionsResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="DelOptionsResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'DelOptionsResponse')">

```json
{
    "DeliveryOptions": [
        {
            "Reference": "EDO-000-79G-RXC",
            "EstimatedDeliveryDate": {
                "Date": "2020-03-18T00:00:00+00:00",
                "Guaranteed": true,
                "DayOfWeek": "Wednesday"
            },
            "DeliveryWindow": {
                "Start": "00:00:00",
                "End": "23:59:00",
                "UtcOffset": "+00:00"
            },
            "Carrier": "Royal Mail",
            "CarrierService": "Tracked 48 ",
            "CarrierServiceReference": "MPD_RMDTPS48HNAUT",
            "CarrierServiceTypes": [
                "Standard"
            ],
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "TaxRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2000
                },
                "VatAmount": 5.54,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "AllocationCutOff": "2020-03-14T00:00:00+00:00",
            "OperationalCutOff": "2020-03-14T00:00:00+00:00",
            "ServiceDirection": "Inbound, Outbound"
        },
        {
            "Reference": "EDO-000-79G-RXD",
            "EstimatedDeliveryDate": {
                "Date": "2020-03-19T00:00:00+00:00",
                "Guaranteed": true,
                "DayOfWeek": "Thursday"
            },
            "DeliveryWindow": {
                "Start": "00:00:00",
                "End": "23:59:00",
                "UtcOffset": "+00:00"
            },
            "Carrier": "Royal Mail",
            "CarrierService": "Tracked 48 ",
            "CarrierServiceReference": "MPD_RMDTPS48HNAUT",
            "CarrierServiceTypes": [
                "Standard"
            ],
            "Price": {
                "Net": 27.69,
                "Gross": 33.23,
                "TaxRate": {
                    "Reference": "GB-0.2000",
                    "CountryIsoCode": "GB",
                    "Type": "Standard",
                    "Rate": 0.2000
                },
                "VatAmount": 5.54,
                "Currency": {
                    "Name": "Pound Sterling",
                    "IsoCode": "GBP"
                }
            },
            "AllocationCutOff": "2020-03-16T00:00:00+00:00",
            "OperationalCutOff": "2020-03-16T00:00:00+00:00",
            "ServiceDirection": "Inbound, Outbound"
        }
    ]
}
```

</div>  

Both of these options have a time window starting at 00:00 and ending at 23:59. In practice, the carrier is offering to make the delivery at some point on either the 18th or 19th of March (as selected by the customer), but isn't offering a more specific timeslot on that service. 

Note the `{Reference}` for each delivery option. When the customer selects their preferred delivery option you will need to pass the relevant `{Reference}` back to PRO via the **Select Option** endpoint.

At this point, you would present some or all of the options returned to your customer via your site or app. For information on how to handle the choice the customer makes, see the [Selecting Options](/pro/api/help/selecting_options.md) page.

## Getting a Summary of Options

The **Delivery Options Summary** endpoint enables you to to get a list of all dates on which delivery and/or pickup options would be available for a particular consignment. This could be useful during checkout flows if you want to give your customers an indication of the dates on which they could request delivery before you make a full **Get Delivery Options** call

To call **Delivery Options Summary**, send a `POST` request to `https://api.electioapp.com/deliveryoptions/summary`. The body of the request should contain the details of an as-yet uncreated consignment, structured identically to a **Get Delivery Options** request. For more information on the structure of a **Get Delivery Options** request, see the [Getting Detailed Options](#getting-detailed-options) section.

Once it has received the request, PRO returns a list of all dates that have `DeliveryOptions` available for that consignment, and a separate list with all dates that have `PickUp` options available for that consignment. Note that PRO does not return details of the delivery options themselves.

<span class="highlight">HOW DOES THE TIMESLOTS ARRAY WORK? IT'S NOT EVEN MENTIONED IN THE API REF?</span>

> <span class="note-header">Note:</span>
>
>  For full reference information on the <strong>Delivery Options Summary</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/DeliveryOptionSummary">Delivery Options Summary</a></strong> page of the API reference.

### Delivery Options Summary Example

In this example response, PRO has returned a list of delivery dates, but there are no available pickup options for the consignment.

<div class="tab">
    <button class="staticTabButton">Delivery Options Summary Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'DelOptionsSumResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="DelOptionsSumResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'DelOptionsSumResponse')">

```json
{
    "Reference": "EPC-000-039-EPK",
    "DeliveryOptions": [
        "2020-03-18T00:00:00",
        "2020-03-19T00:00:00",
        "2020-03-20T00:00:00",
        "2020-03-21T00:00:00",
        "2020-03-23T00:00:00",
        "2020-03-24T00:00:00",
        "2020-03-25T00:00:00",
        "2020-03-26T00:00:00",
        "2020-03-27T00:00:00",
        "2020-03-28T00:00:00",
        "2020-03-30T00:00:00"
    ],
    "TimeSlots": null,
    "PickUp": null,
    "DropOff": null
}
```

</div>

## Getting Existing Delivery Options

The **Get Existing Delivery Option** endpoint enables you to get the details of an existing delivery option (that is, a delivery option that was generated by a previous **Get Delivery Options** call) using that delivery option's `{deliveryOptionReference}`. To call **Get Existing Delivery Option**, send a `GET` request to `https://api.electioapp.com/deliveryoptions/details/{deliveryOptionReference}`. There is no body content required for the request.

Once it has received the request, PRO returns the details of the delivery option as a `deliveryOption` object. For further information on the structure of delivery options, see the [Getting Detailed Options](#getting-detailed-options) section.

> <span class="note-header">Note:</span>
>
>  For full reference information on the <strong>Get Existing Delivery Option</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/GetExistingDeliveryOption">Get Existing Delivery Option</a></strong> page of the API reference.

## Get Existing Delivery Option Example

This example shows a standard delivery option as returned by the **Get Existing Delivery Options** endpoint.

<div class="tab">
    <button class="staticTabButton">Get Existing Delivery Option Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'existDelOptResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="existDelOptResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'existDelOptResponse')">

```json
{
    "Reference": null,
    "ConsignmentDetail": {
        "Reference": "EPC-000-039-EPZ",
        "CustomerReference": "00000000-0000-0000-0000-000000000000",
        "Weight": {
            "Kg": 0.0
        },
        "Value": {
            "Amount": 0.00,
            "Currency": {
                "Name": "Pound Sterling",
                "IsoCode": "GBP"
            }
        },
        "CustomsDocumentation": null,
        "DateCreated": "2020-03-13T15:29:46.7279404+00:00",
        "ShippingDate": null,
        "RequestedDeliveryDate": null,
        "EarliestDeliveryDate": null,
        "LatestDeliveryDate": null,
        "ConsignmentReferenceProvidedByCustomer": "",
        "Addresses": []
    },
    "DeliveryOption": {
        "Reference": "EDO-000-79G-V89",
        "EstimatedDeliveryDate": {
            "Date": "2020-03-14T00:00:00+00:00",
            "Guaranteed": true,
            "DayOfWeek": "Saturday"
        },
        "DeliveryWindow": {
            "Start": "00:00:00",
            "End": "12:00:00",
            "UtcOffset": "+00:00"
        },
        "Carrier": "UPS",
        "CarrierService": "UPS EXPRESS (Saturday Delivery, Delivery Confirmation Signature Required)",
        "CarrierServiceReference": "EDC5_UPSHEXSDDCS",
        "Price": {
            "Net": 33.64,
            "Gross": 40.37,
            "VatRate": {
                "Reference": "GB-0.200059453032104637",
                "CountryIsoCode": "GB",
                "Type": "Standard",
                "Rate": 0.200059453032104637
            },
            "VatAmount": 6.73,
            "Currency": {
                "Name": "Pound Sterling",
                "IsoCode": "GBP"
            }
        },
        "AllocationCutOff": "2020-03-13T15:30:00+00:00",
        "OperationalCutOff": null
    }
}
```

</div>

## Next Steps

* Learn how to get pickup options for a consignment at the [Getting Pickup Options](/pro/api/help/getting_pickup_options.html) page
* Learn how to create consignments and orders from delivery options at the [Selecting Options](/pro/api/help/selecting_options.html) page
* Learn how to manifest consignments at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>