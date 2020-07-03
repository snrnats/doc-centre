<div class="tab">
    <button class="staticTabButton">Select Delivery Option as an Order Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'optAsOrderEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="optAsOrderEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'optAsOrderEndpoint')">

  ```
  POST https://api.electioapp.com/deliveryoptions/selectorder
  ```

</div>     

Once the customer has selected an available delivery option, you'll need to record their choice in SortedPRO via the **[Select Delivery Option as an Order](https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder)** endpoint. 

Once it has received the **Select Delivery Option as an Order** request, PRO uses the details of the selected option to create an order and returns an object containing the associated `{orderReference}`. 

> [!NOTE]
> * For full reference information on the <strong>Select Delivery Option as an Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder">Select Delivery Option as an Order</a></strong> page of the API reference.
> * For a user guide on selecting options, see the [Selecting Options](/pro/api/help/selecting_options.html) page.

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