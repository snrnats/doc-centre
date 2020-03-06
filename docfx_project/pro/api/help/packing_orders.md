# Packing Orders

<div class="tab">
    <button class="staticTabButton">Pack Order Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'packOrderEndpoint')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="packOrderEndpoint" class="staticTabContent" onclick="CopyToClipboard(this, 'packOrderEndpoint')">

   ```
   POST https://api.electioapp.com/orders/{orderReference}/pack
   ```

</div>

Once your order is created, you'll need to use the **[Pack Order](https://docs.electioapp.com/#/api/PackOrder)** endpoint to create consignments from it.

The **Pack Order** endpoint enables you to take those items on an order that share an origin and are to be shipped together, and generate a shippable consignment from them. You will need to send one **Pack Order** request per consignment that you want to create from the order.

To make a **Pack Order** request, send a GET request to `https://api.electioapp.com/orders/{orderReference}/pack`. The body of the request can contain various properties that are used when creating the consignment, but at a minimum should contain the `{orderReference}` of the associated order and details of at least one `{item}` (and its accompanying `{package}`). The items and packages listed make up the consignment.

> <span class="note-header">Note:</span>
>  The <strong>Pack Order</strong> request's <code>OrderReferenceProvidedByCustomer</code> field enables you to provide a custom reference for the consignment that the request generates. 
>  
>  If you add a custom reference to your <strong>Pack Order</strong> request, then PRO uses this value as the consignment's custom reference, as opposed to any <code>OrderReferenceProvidedByCustomer</code> you may have provided when creating the order. 
>  
>  If you do not add a custom reference to your <strong>Pack Order</strong> request, then PRO uses the existing order's <code>OrderReferenceProvidedByCustomer</code> (where provided) as the consignment's custom reference.

Once SortedPRO has received a **Pack Order** request, it creates the consignment and returns the relevant `{consignmentReference}`.

<span class="highlight">
Ive tested it.
 
Seems the Order.OrderReferenceProvidedByCustomer is used to populate the Consignment.ConsignmentReferenceProvidedByCustomer when the pack order call is made.
The original Order.OrderReferenceProvidedByCustomer from the create order call, is overwritten/updated/ignored if the reference is provided in the Pack call, but conserved if the value is omitted in the Pack call.
 
Is all this stuff being documented?
</span>

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

> <span class="note-header">Note:</span>
>  For full reference information on the <strong>Pack Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PackOrder">Pack Order</a></strong> page of the API reference.



<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>