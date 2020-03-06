# Selecting Options

Select Option

<div class="tab">
    <button class="staticTabButton">Select Option Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'selectOptionEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="selectOptionEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'selectOptionEndpoint')">

   ```
   POST https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}
   ```

</div>  

Once the customer has selected an available option, you'll need to record their choice in SortedPRO via the **[Select Option](https://docs.electioapp.com/#/api/SelectOption)** endpoint. The **Select Option** endpoint takes the `{deliveryOptionReference}` of the selected option as a path parameter.

Once it has received the selected `{deliveryOptionReference}`, PRO has all the information it needs to create and allocate a consignment. The consignment details were passed as part of the original request to get delivery options, and the `{deliveryOptionReference}` passed to the **Select Option** endpoint confirms the required delivery promise.

PRO creates and allocates a consignment with the selected details, and returns links to the consignment resource that was allocated, a summary of the carrier service that the consignment was allocated to, a link to the relevant package labels, and a `ConsignmentLegs` array indicating how many legs the shipment will need. Where a shipment would need multiple legs to complete, the `ConsignmentLegs` array shows tracking details for each individual leg.

> <span class="note-header">Note:</span>
> For full reference information on the <strong>Select Option</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectOption">Select Option</a></strong> page of the API reference.

### Select Option Example

The example shows a request to select a delivery option that has a `{deliveryOptionReference}` of _EDO-000-6DX-6XP_. PRO creates a consignment with a `{consignmentReference}` of _EC-000-05B-MMQ_, which it then  allocates to the carrier service associated with delivery option _EDO-000-6DX-6XP_. PRO then returns the relevant `{consignmentReference}` and label link, enabling you to get labels for and manifest the consignment.

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
            "Href": "https://api.electioapp.com/consignments/EC-000-05B-MMQ"
        },
        {
            "Rel": "label",
            "Href": "https://api.electioapp.com/labels/EC-000-05B-MMQ"
        }
    ],
    "Description": "Consignment EC-000-05B-MMQ has been successfully allocated with Carrier X Tracked 48 Signed For for shipping on 17/06/2019 00:00:00 +00:00",
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
    "CarrierServiceName": "Tracked 48 Signed For"
}
```

</div> 

Reserve Pickup Option

## Creating Orders From Delivery Options

The **Select Delivery Option As An Order** endpoint enables you to take a delivery option and generate an order from it. To call **Select Delivery Option As An Order**, send a `POST` request to `https://api.electioapp.com/deliveryoptions/selectorder`. 

The body of the request should contain the `Reference` of the delivery option you want to select. If required, you can also specify an `OrderReferenceProvidedByCustomer` and metadata to be added to the generated order.

> <span class="highlight">
>
> This section assumes that you have already received options for a particular delivery. For more information on requesting delivery options, see the [Getting Delivery Options](/pro/api/)

Once the customer has selected an available delivery option, you'll need to record their choice in SortedPRO via the **[Select Delivery Option as an Order](https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder)** endpoint. This endpoint takes the `{Reference}` of the selected option as a path parameter. POST https://api.electioapp.com/deliveryoptions/selectorder
 
Once it has received the **Select Delivery Option as an Order** request, PRO uses the details of the selected option to create an order and returns an object containing the associated `{orderReference}`. The reference will come in useful in the next step, when we pack the order into consignments.

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Select Delivery Option as an Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder">Select Delivery Option as an Order</a></strong> page of the API reference.

### Select Option As Order Example

The example shows a request to select a delivery option that has a `{Reference}` of _EDO-000-6DX-6XP_ as an order. PRO takes that delivery option's details and creates an order with an `{orderReference}` of _EO-000-002-0TT_.

<div class="tab">
    <button class="staticTabButton">Example Select Delivery Option as an Order Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'optAsOrderRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="optAsOrderRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'optAsOrderRequest')">

```json
{
  "DeliveryOptions": [
    {
      "Reference": "EDO-000-6DX-6XP",
      "OrderReferenceProvidedByCustomer": "MYORDEREF001",
      "MetaData": [
        {
          "KeyValue": "OrderReference",
          "StringValue": "10045634343"
        }
      ]
    }
  ]
}
```

</div>   

<div class="tab">
    <button class="staticTabButton">Example Select Delivery Option as an Order Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'optAsOrderResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="optAsOrderResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'optAsOrderResponse')">

  ```json
  {
    "SelectOrderResults": [
      {
        "DeliveryOptionReference": "EDO-000-6DX-6XP",
        "OrderReference": "EO-000-002-0TT",
        "Status": 201,
        "Message": null,
        "Links": [
          {
            "Rel": "Detail",
            "Href": "https://api.electioapp.com/orders/EEO-000-002-0TT"
          }
        ]
      }
    ]
  }
  ```

</div> 

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>