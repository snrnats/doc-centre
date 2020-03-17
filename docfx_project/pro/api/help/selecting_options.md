# Selecting Options

This page explains how to to generate consignments and orders by selecting a delivery option. 

---

## Selecting Options as a Consignment

The **Select Option** endpoint enables you to record a customer's choice of delivery or pickup option in SortedPRO. PRO generates and allocates a consignment from the details of the selected option.

To call **Select Option**, send a `POST` request to `https://api.electioapp.com/deliveryoptions/select/{deliveryOptionReference}`. There is no body content required for the request.

Once it has received the request, PRO creates a consignment using the consignment that details were passed as part of the original request to get delivery options. Next, the system allocates the consignment in line with the delivery promise specified in the selected option. Generally, this means allocating to the carrier service returned in the original option, but PRO can allocate to an alternative service in certain circumstances. The delivery option guarantees the delivery promise, but not the carrier service

PRO then returns links to the consignment resource that was allocated, a summary of the carrier service that the consignment was allocated to, a link to the relevant package labels, and a `ConsignmentLegs` array indicating how many legs the shipment will need. Where a shipment would need multiple legs to complete, the `ConsignmentLegs` array shows tracking details for each individual leg.

> <span class="note-header">More Information:</span>
>
> * For full reference information on the <strong>Select Option</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectOption">Select Option</a></strong> page of the API reference.
> * For an example call flow in which consignments are created using **Select Order**, see the [Consumer Options](/pro/api/help/flows/consumer_options_flow.html) call flow page.

### Select Option Example

The example shows a request to select a delivery option that has a `{deliveryOptionReference}` of _EDO-000-6DX-6XP_. PRO creates a consignment with a `{consignmentReference}` of _EC-000-05B-MMQ_, which it then allocates to the carrier service associated with delivery option _EDO-000-6DX-6XP_. PRO then returns the relevant `{consignmentReference}` and label link, enabling you to get labels for and manifest the consignment.

<div class="tab">
    <button class="staticTabButton">Example Select Option Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'selectOptionRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="selectOptionRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'selectOptionRequest')">

```json
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

## Selecting Options as an Order    

The **Select Option As Order** endpoint enables you to record a customer's choice of delivery or pickup option as an order rather than a consignment. You can then pack the resulting order into multiple consignments as per the PRO order process. **Select Option As Order** enables you to select multiple delivery and/or pickup options at once. 

Using **Select Option As Order** combines the benefits of PRO's delivery options and orders features, enabling you to offer your customers delivery options even if their orders need to be shipped in multiple consignments.

> <span class="note-header">More Information:</span>
>
> For more information on using orders in PRO, see the [Managing Orders](/pro/api/help/managing_orders.html) section.

To call **Select Option As Order**, send a `POST` request to `https://api.electioapp.com/deliveryoptions/selectorder`. The body of the request should contain a `DeliveryOptions` array listing the delivery options you want to select as orders. Each `DeliveryOption` must contain a delivery option `Reference`, which is used to identify the order you want to select. If require, you can also add an `OrderReferenceProvidedByCustomer` and metadata to be added to the resulting order.

Once it has received the **Select Delivery Option as an Order** request, PRO uses the details of the selected option to create an order and returns an object containing the associated `{orderReferences}`. 

> <span class="note-header">More Information:</span>
>
> * For full reference information on the <strong>Select Delivery Option as an Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder">Select Delivery Option as an Order</a></strong> page of the API reference.
> * For an example call flow showing options being selected as orders, see the [Consumer Options Flex](/pro/api/help/flows/consumer_options_flex_flow.html) flow page.

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

## Next Steps

* Learn how to manifest consignments at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page
* Learn how to pack orders into consignments at the [Creating Consignments From Orders](/pro/api/help/packing_orders.html) page
* Learn how to retrieve customs docs and invoices at the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>