<div class="tab">
    <button class="staticTabButton">Pack Order Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'packOrderEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="packOrderEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'packOrderEndpoint')">

   ```
   POST https://api.electioapp.com/orders/{orderReference}/pack
   ```

</div>

Once your order is created, you'll need to use the **[Pack Order](https://docs.electioapp.com/#/api/PackOrder)** endpoint to create consignments from it. The **Pack Order** endpoint enables you to group those items on an order that share an origin and are to be shipped together, generating a shippable consignment for them. You will need to send a **Pack Order** request for each consignment that you want to create from the order.

To make a **Pack Order** request, send a GET request to `https://api.electioapp.com/orders/{orderReference}/pack`. The body of the request can contain various properties that are used when creating the consignment, but at a minimum should contain the `{orderReference}` of the associated order and details of at least one `{package}` containing at least one `{item}` from the order. The items and packages listed make up the consignment.

Once SortedPRO has received a **Pack Order** request, it creates the consignment and returns the relevant `{consignmentReference}`.

> [!NOTE]
> * For full reference information on the **Pack Order** endpoint, see the [Pack Order](https://docs.electioapp.com/#/api/PackOrder) page of the API reference.
> * For a user guide on orders in PRO, see the [Managing Orders](/pro/api/help/managing_orders.html) section.

### Pack Order Example

The example shows a **Pack Order** request to create a consignment with one package containing a single item from order _EO-000-002-0TT_. PRO creates the consignment and responds with a `{consignmentReference}` of _EC-000-05B-MQ4_.

<div class="tab">
    <button class="staticTabButton">Example Pack Order Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'packOrderRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="packOrderRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'packOrderRequest')">

  ```json
  {
    "OrderReference": "EO-000-002-0TT",
    "OrderReferenceProvidedByCustomer": "MyOrderRef001",
    "GenerateReturn": false,
    "Packages": [
      {
        "Dimensions": {
          "Unit": "Cm",
          "Width": 15.4,
          "Length": 21.7,
          "Height": 10.0
        },
        "Weight": {
          "Value": 1.3,
          "Unit": "Kg"
        },
        "PackageSizeReference": "",
        "Items": [
          {
            "Sku": "SKU093434",
            "Quantity": 1
          }
        ]
      }
    ],
    "MetaData": [
      {
        "KeyValue": "SampleKey",
        "StringValue": "SampleValue"
      }
    ]
  }
  ```

</div>   

<div class="tab">
    <button class="staticTabButton">Example Pack Order Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'packOrderResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="packOrderResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'packOrderResponse')">

```json
{
  "Results": [
    {
      "Result": "ConsignmentCreated",
      "ApiLinks": [
        {
          "Rel": "Consignment",
          "Href": "https://api.electioapp.com/consignments/EC-000-05B-MQ4"
        }
      ]
    }
  ]
}
```

</div>
