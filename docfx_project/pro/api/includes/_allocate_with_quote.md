# [Allocate with Quote Endpoint](#tab/allocate-with-quote-endpoint)

```json
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithquote/{quoteReference}
```
--- 

To allocate an individual consignment based on a specific delivery quote from a carrier, use the **[Allocate With Quote](https://docs.electioapp.com/#/api/AllocateWithQuote)** endpoint.

The **Allocate With Quote** endpoint takes the `{consignmentReference}` of the consignment you want to allocate and the `{quoteReference}` of a particular quote. Once the request is received PRO attempts to allocate the consignment to the carrier service specified in the quote, and returns an Allocation Summary.

> [!NOTE]
> * For full reference information on the <strong>Allocate With Quote</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithQuote">Allocate With Quote</a></strong> page of the API reference.
> * For a user guide on allocating to specific delivery quotes, see the [Allocating to a Specific Quote](/pro/api/help/allocating_to_a_specific_quote.html) page.

### Allocate With Quote Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05B-N40_ to the carrier service associated with a quote that has the `{quoteReference}` _112236d5-4460-492f-a6bd-aa3f00f62dfb_.

# [Allocate with Quote Request](#tab/allocate-with-quote-request)

```json
PUT https://api.electioapp.com/allocation/EC-000-05B-N40/allocatewithquote/112236d5-4460-492f-a6bd-aa3f00f62dfb
```

# [Allocate with Quote Response](#tab/allocate-with-quote-response)

```json
[
    {
        "StatusCode": 200,
        "ApiLinks": [
            {
                "Rel": "detail",
                "Href": "https://apisandbox.electioapp.com/consignments/EC-000-05B-N40"
            },
            {
                "Rel": "label",
                "Href": "https://apisandbox.electioapp.com/labels/EC-000-05B-N40"
            }
        ],
        "Description": "Consignment EC-000-05B-N40 has been successfully allocated with UPS STANDARD (Delivery Confirmation Signature Required) for shipping on 18/06/2019 17:00:00 +00:00",
        "ConsignmentLegs": [
            {
                "Leg": 1,
                "TrackingReferences": [
                    "1Z9A80W5DK96293164"
                ],
                "CarrierReference": "UPS",
                "CarrierServiceReference": null,
                "CarrierName": "UPS"
            }
        ],
        "CarrierReference": "UPS",
        "CarrierName": "UPS",
        "CarrierServiceReference": "EDC5_UPSHSTDCS",
        "CarrierServiceName": "UPS STANDARD (Delivery Confirmation Signature Required)"
    }
]
```
---
