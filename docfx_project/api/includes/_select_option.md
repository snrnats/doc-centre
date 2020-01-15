> Select Option Endpoint

```
POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}
```

> Example Select Option Request
```
POST https://api.electioapp.com/deliveryoptions/select/EDO-000-6DX-6XP
```

> Example Select Option Response
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

```xml
<?xml version="1.0"?>
<AllocationSummary xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
    <StatusCode>200</StatusCode>
    <ApiLinks>
        <ApiLink>
            <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">detail</Rel>
            <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://apisandbox.electioapp.com/consignments/EC-000-05B-MMQ</Href>
        </ApiLink>
        <ApiLink>
            <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">label</Rel>
            <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://apisandbox.electioapp.com/labels/EC-000-05B-MMQ</Href>
        </ApiLink>
    </ApiLinks>
    <Description>Consignment EC-000-05B-MMQ has been successfully allocated with Carrier X Tracked 48 Signed For for shipping on 17/06/2019 00:00:00 +00:00</Description>
    <ConsignmentLegs>
        <ConsignmentLeg>
            <Leg>1</Leg>
            <TrackingReferences>
                <string>TT324209366GB</string>
            </TrackingReferences>
            <CarrierReference>CARRIER_X</CarrierReference>
            <CarrierName>Carrier X</CarrierName>
        </ConsignmentLeg>
    </ConsignmentLegs>
    <CarrierReference>CARRIER_X</CarrierReference>
    <CarrierName>Carrier X</CarrierName>
    <CarrierServiceReference>MPD_T48CX</CarrierServiceReference>
    <CarrierServiceName>Tracked 48 Signed For</CarrierServiceName>
</AllocationSummary>
```

Once the customer has selected an available option, you'll need to record their choice in SortedPRO via the **[Select Option](https://docs.electioapp.com/#/api/SelectOption)** endpoint. The **Select Option** endpoint takes the `{deliveryOptionReference}` of the selected option as a path parameter.

Once it has received the selected `{deliveryOptionReference}`, PRO has all the information it needs to create and allocate a consignment. The consignment details were passed as part of the original request to get delivery options, and the `{deliveryOptionReference}` passed to the **Select Option** endpoint confirms the required delivery promise.

PRO creates and allocates a consignment with the selected details, and returns links to the consignment resource that was allocated, a summary of the carrier service that the consignment was allocated to, a link to the relevant package labels, and a `ConsignmentLegs` array indicating how many legs the shipment will need. Where a shipment would need multiple legs to complete, the `ConsignmentLegs` array shows tracking details for each individual leg.

<aside class="note">
  For full reference information on the <strong>Select Option</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectOption">Select Option</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows a request to select a delivery option that has a `{deliveryOptionReference}` of _EDO-000-6DX-6XP_. PRO creates a consignment with a `{consignmentReference}` of _EC-000-05B-MMQ_, which it then  allocates to the carrier service associated with delivery option _EDO-000-6DX-6XP_. PRO then returns the relevant `{consignmentReference}` and label link, enabling you to get labels for and manifest the consignment.