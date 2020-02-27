<div class="tab">
    <button class="staticTabButton">Allocate With Quote Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocateWithQuoteEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocateWithQuoteEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'allocateWithQuoteEndpoint')">

```
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithquote/{quoteReference}
```

</div>  

To allocate an individual consignment based on a specific delivery quote from a carrier, use the **[Allocate With Quote](https://docs.electioapp.com/#/api/AllocateWithQuote)** endpoint.

> <span class="note-header">Note:</span>
>  You can get quote details via SortedPRO's Quotes API. For more information on PRO's quote endpoints (<strong><a href="https://docs.electioapp.com/#/api/GetQuotes">Get Quotes</a></strong>, <strong><a href="https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference">Get Quotes by Consignment Reference</a></strong>, and <strong><a href="https://docs.electioapp.com/#/api/GetServiceGroupQuotes">Get Service Group Quotes</a></strong>), see the API reference.

The **Allocate With Quote** endpoint takes the `{consignmentReference}` of the consignment you want to allocate and the `{quoteReference}` of a particular quote. Once the request is received PRO attempts to allocate the consignment to the carrier service specified in the quote, and returns an Allocation Summary.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Allocate With Quote</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithQuote">Allocate With Quote</a></strong> page of the API reference.

### Allocate With Quote Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05B-N40_ to the carrier service associated with a quote that has the `{quoteReference}` _112236d5-4460-492f-a6bd-aa3f00f62dfb_.

<div class="tab">
    <button class="staticTabButton">Example Allocate With Quote Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocateWithQuoteRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocateWithQuoteRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'allocateWithQuoteRequest')">

```
PUT https://api.electioapp.com/allocation/EC-000-05B-N40/allocatewithquote/112236d5-4460-492f-a6bd-aa3f00f62dfb
```

</div>  

<div class="tab">
    <button class="staticTabButton">Example Allocate With Quote Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'allocateWithQuoteResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="allocateWithQuoteResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'allocateWithQuoteResponse')">

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

</div>  
