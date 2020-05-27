<div class="tab">
    <button class="staticTabButton">Select Option Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'selectOptionEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="selectOptionEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'selectOptionEndpoint')">

   ```
   POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}
   ```

</div>  

Once the customer has selected an available option, you'll need to record their choice in SortedPRO via the **[Select Option](https://docs.electioapp.com/#/api/SelectOption)** endpoint. 

PRO creates and allocates a consignment using the details supplied previously in the delivery options call, and returns: 

* A link to the consignment resource that was allocated
* A summary of the carrier service the consignment was allocated to
* A link to the relevant package labels

> <span class="note-header">Note:</span>
> * For full reference information on the <strong>Select Option</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectOption">Select Option</a></strong> page of the API reference.
> * For a user guide on selecting options, see the [Selecting Options](/pro/api/help/selecting_options.html) page.

### Select Option Example

The example shows a request to select a delivery option that has a `{deliveryOptionReference}` of _EDO-000-6DX-6XP_. PRO creates a consignment with a `{consignmentReference}` of _EC-000-05B-MMQ_, which it then  allocates to the carrier service associated with delivery option _EDO-000-6DX-6XP_. PRO then returns the relevant `{consignmentReference}` and label link, enabling you to retrieve labels for the consignment.

<div class="tab">
    <button class="staticTabButton">Example Select Option Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'selectOptionRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="selectOptionRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'selectOptionRequest')">

   ```
   POST https://api.electioapp.com/deliveryoptions/select/EDO-000-6DX-6XP
   ```

</div>   

<div class="tab">
    <button class="staticTabButton">Example Select Option Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'selectOptionResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="selectOptionResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'selectOptionResponse')">

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

</div> 
