> Allocate With Quote Endpoint
```
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithquote/{quoteReference}
```
> Example Allocate With Quote Request
```
PUT https://api.electioapp.com/allocation/EC-000-05B-N40/allocatewithquote/112236d5-4460-492f-a6bd-aa3f00f62dfb
```
> Example Allocate With Quote Response
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

```xml
<?xml version="1.0"?>
<ArrayOfAllocationSummary xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <AllocationSummary>
        <StatusCode xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">200</StatusCode>
        <ApiLinks xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
            <ApiLink>
                <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">detail</Rel>
                <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://apisandbox.electioapp.com/consignments/EC-000-05B-N40</Href>
            </ApiLink>
            <ApiLink>
                <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">label</Rel>
                <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://apisandbox.electioapp.com/labels/EC-000-05B-N40</Href>
            </ApiLink>
        </ApiLinks>
        <Description xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Consignment EC-000-05B-N40 has been successfully allocated with UPS STANDARD (Delivery Confirmation Signature Required) for shipping on 18/06/2019 17:00:00 +00:00</Description>
        <ConsignmentLegs xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
            <ConsignmentLeg>
                <Leg>1</Leg>
                <TrackingReferences>
                    <string>1Z9A80W5DK99189174</string>
                </TrackingReferences>
                <CarrierReference>UPS</CarrierReference>
                <CarrierName>UPS</CarrierName>
            </ConsignmentLeg>
        </ConsignmentLegs>
        <CarrierReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">UPS</CarrierReference>
        <CarrierName xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">UPS</CarrierName>
        <CarrierServiceReference xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">EDC5_UPSHSTDCS</CarrierServiceReference>
        <CarrierServiceName xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">UPS STANDARD (Delivery Confirmation Signature Required)</CarrierServiceName>
    </AllocationSummary>
</ArrayOfAllocationSummary>
```

To allocate an individual consignment based on a specific delivery quote from a carrier, use the **[Allocate With Quote](https://docs.electioapp.com/#/api/AllocateWithQuote)** endpoint.

<aside class="note">
  You can get quote details via SortedPRO's Quotes API. For more information on PRO's quote endpoints (<strong><a href="https://docs.electioapp.com/#/api/GetQuotes">Get Quotes</a></strong>, <strong><a href="https://docs.electioapp.com/#/api/GetQuotesbyConsignmentReference">Get Quotes by Consignment Reference</a></strong>, and <strong><a href="https://docs.electioapp.com/#/api/GetServiceGroupQuotes">Get Service Group Quotes</a></strong>), see the API reference.
</aside>

The **Allocate With Quote** endpoint takes the `{consignmentReference}` of the consignment you want to allocate and the `{quoteReference}` of a particular quote. Once the request is received PRO attempts to allocate the consignment to the carrier service specified in the quote, and returns an Allocation Summary.

<aside class="note">
  For full reference information on the <strong>Allocate With Quote</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateWithQuote">Allocate With Quote</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05B-N40_ to the carrier service associated with a quote that has the `{quoteReference}` _112236d5-4460-492f-a6bd-aa3f00f62dfb_.