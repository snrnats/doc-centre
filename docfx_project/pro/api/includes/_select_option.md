# [Select Option Endpoint](#tab/select-option-endpoint)

```json
POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}
```

---

Once the customer has selected an available option, you'll need to record their choice in SortedPRO via the **[Select Option](https://docs.electioapp.com/#/api/SelectOption)** endpoint.

PRO creates and allocates a consignment using the details supplied previously in the delivery options call, and returns: 

* A link to the consignment resource that was allocated
* A summary of the carrier service the consignment was allocated to
* A link to the relevant package labels

> [!NOTE]
>
> * For full reference information on the **Select Option** endpoint, see the **[Select Option](https://docs.electioapp.com/#/api/SelectOption)** page of the API reference.
> * For a user guide on selecting options, see the [Selecting Options](/pro/api/help/selecting_options.html) page.

### Select Option Example

The example shows a request to select a delivery option that has a `{deliveryOptionReference}` of _EDO-000-6DX-6XP_. PRO creates a consignment with a `{consignmentReference}` of _EC-000-05B-MMQ_, which it then  allocates to the carrier service associated with delivery option _EDO-000-6DX-6XP_. PRO then returns the relevant `{consignmentReference}` and label link, enabling you to retrieve labels for the consignment.

# [Select Option Request](#tab/select-option-request)

```json
POST https://api.electioapp.com/deliveryoptions/select/EDO-000-6DX-6XP
```

# [Select Option Response](#tab/select-option-response)

```json
{
    "StatusCode": 200,
    "ApiLinks": [
        {
            "Rel": "detail",
            "Href": "https://apisandbox.electioapp.com/consignments/EC-000-05B-MMQ"
        },
        {
            "Rel": "label",
            "Href": "https://apisandbox.electioapp.com/labels/EC-000-05B-MMQ"
        }
    ],
    "Description": "Consignment EC-000-05B-MMQ has been successfully allocated with Carrier X Tracked 48 Signed For for shipping on 17/06/2019 00:00:00 +00:00",
    "ConsignmentLegs": [
        {
            "Leg": 1,
            "TrackingReferences": [
                "TRK00009823"
            ],
            "CarrierReference": "CARRIER_X",
            "CarrierServiceReference": null,
            "CarrierName": "Carrier X"
        }
    ],
    "CarrierReference": "CARRIER_X",
    "CarrierName": "Carrier X",
    "CarrierServiceReference": "MPD_T48CX",
    "CarrierServiceName": "Tracked 48 Signed For"
}
```

---
