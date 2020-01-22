<div class="tab">
    <button class="staticTabButton">Pack Order Endpoint</button>
    <div class="copybutton" onclick="CopyToClipboard('packOrderEndpoint')">Click to Copy</div>
</div>

<div id="packOrderEndpoint" class="staticTabContent" onclick="CopyToClipboard('packOrderEndpoint')">

   ```
   POST https://api.electioapp.com/orders/{orderReference}/pack
   ```

</div>

Once your order is created, you'll need to use the **[Pack Order](https://docs.electioapp.com/#/api/PackOrder)** endpoint to create consignments from it.

It's important to understand the difference between a consignment and an order when using **Pack Order**:

* An **order** is a collection of items that is to be transported to the same destination on behalf of the same customer.
* A **consignment** is a collection of packages that is to be transported to the same destination, on behalf of the same customer, _from the same origin, on the same day, and by the same carrier_.

This means that orders can contain items that will not ship from the same location, but consignments cannot. Similarly, orders can contain items that will ship from the same location but at different times (for example, because one of the items a customer has purchased is out of stock).

The **Pack Order** endpoint enables you to take those items on an order that share an origin and are to be shipped together, and generate a shippable consignment from them. You will need to send one **Pack Order** request per consignment that you want to create from the order.

> <span class="note-header">More Information:</span>
>  As an example, suppose that a clothing retailer has received a customer order for a necklace, a bracelet, a coat, and a hat. As the necklace and bracelet are both physically small, the retailer elects to ship them in the same package. The necklace and bracelet are located in warehouse A, and the coat and hat in warehouse B. This would likely break down to:
>
>  * Four items - The necklace, the bracelet, the coat, and the hat.
>  * Three packages - One containing the necklace and bracelet, one containing the coat, and one containing the hat.
>  * Two consignments - One with a single item for the package containing the necklace and bracelet, and another with separate packages for the coat and hat.
>  * A single order comprising the customer's entire purchase.
>
>  In this example, you would need to run <strong>Pack Order</strong> twice - once for each consignment.

To make a **Pack Order** request, send a GET request to `https://api.electioapp.com/orders/{orderReference}/pack`. The body of the request can contain various properties that are used when creating the consignment, but at a minimum should contain the `{orderReference}` of the associated order and details of at least one `{item}` (and its accompanying `{package}`). The items and packages listed make up the consignment.

> <span class="note-header">Note:</span>
>  The <strong>Pack Order</strong> request's <code>OrderReferenceProvidedByCustomer</code> field enables you to provide a custom reference for the consignment that the request generates. 
>  
>  If you add a custom reference to your <strong>Pack Order</strong> request, then PRO uses this value as the consignment's custom reference, as opposed to any <code>OrderReferenceProvidedByCustomer</code> you may have provided when creating the order. 
>  
>  If you do not add a custom reference to your <strong>Pack Order</strong> request, then PRO uses the existing order's <code>OrderReferenceProvidedByCustomer</code> (where provided) as the consignment's custom reference.

Once SortedPRO has received a **Pack Order** request, it creates the consignment and returns the relevant `{consignmentReference}`.

### Example

The example shows a **Pack Order** request to create a consignment with one package containing a single item from order _EO-000-002-0TT_. PRO creates the consignment and responds with a `{consignmentReference}` of _EC-000-05B-MQ4_.

<div class="tab">
    <button class="staticTabButton">Example Pack Order Request</button>
    <div class="copybutton" onclick="CopyToClipboard('packOrderRequest')">Click to Copy</div>
</div>

<div id="packOrderRequest" class="staticTabContent" onclick="CopyToClipboard('packOrderRequest')">

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
    <div class="copybutton" onclick="CopyToClipboard('packOrderResponse')">Click to Copy</div>
</div>

<div id="packOrderResponse" class="staticTabContent" onclick="CopyToClipboard('packOrderResponse')">

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


