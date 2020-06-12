# Creating Consignments From Orders

Packing orders into shippable consignments is the final step in the Orders process. This page explains how to create consignments from an order.

---

## Using Pack Order

The **Pack Order** endpoint enables you to take those items on an order that share an origin and are to be shipped together, and generate a shippable consignment from them. You will need to send one **Pack Order** request per consignment that you want to create from the order.

To call **Pack Order**, send a `POST` request to `https://api.electioapp.com/orders/{orderReference}/pack`. At a minimum, the body of the request should contain the `{orderReference}` of the associated order and details of at least one `{item}` (and its accompanying `{package}`). The items and packages listed make up the consignment. If required, you can also populate the resulting consignment with a custom order reference and additional `MetaData`, `CustomsDocumentation`, and `Tags`.

Each item must be identified by a `Reference`, an `ItemReferenceProvidedByCustomer`, or a `Sku`. These fields are not mandatory in themselves, but one of them must be present for each item.

> [!NOTE]
>
> PRO validates the items on a <strong>Pack Order</strong> request against its associated order. For example, the system will return an error if you make a <strong>Pack Order</strong> request including an item with a <code>Sku</code> of <em>12345</em> if there is no item with that <code>Sku</code> on the corresponding order.
>
> However, PRO does not validate the items on a <strong>Pack Order</strong> request against previous <strong>Pack Order</strong> requests. The Pack Order endpoint can be called multiple times for the same order and items. This allows for split picks and short picks to backorder in an operation.

Once SortedPRO has received a **Pack Order** request, it creates the consignment and returns the relevant `{consignmentReference}`. The consignment's details are taken from the body of the **Pack Order** request. Fields that are not part of the request (because they are either NULL or not part of the **Pack Order** request structure) are populated from the details of the specified order.

### Providing a Custom Order Reference 

The **Pack Order** request's `OrderReferenceProvidedByCustomer` field enables you to provide a custom reference for the consignment that the request generates. This is a separate field to the `OrderReferenceProvidedByCustomer` used on the order itself, and behaves in the following ways:

* If you add a custom reference to your **Pack Order** request, then PRO uses this value as the consignment's custom reference, even if there is a different custom reference on the order itself. 
* If you do not add a custom reference to your **Pack Order** request, but the order does have a custom reference, then PRO populates the resulting consignment's `OrderReferenceProvidedByCustomer` using the value from the order.
* If neither the order or the **Pack Order** request has a custom reference specified, then PRO creates the consignment without a custom reference. 

### Generating Return Consignments

You can automatically generate a return consignment at the same time as well as an outbound consignment by using the `GenerateReturn` flag. When PRO receives a **Pack Order** request that has `GenerateReturn` set to _true_, it creates and returns two consignments - one outbound and one inbound.

The inbound consignment is identical to the outbound consignment, with the exception that its _Origin_ and _Destination_ addresses are swapped.

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

> [!NOTE]
>
> * For full reference information on the <strong>Pack Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PackOrder">Pack Order</a></strong> page of the API reference.
> * For an example call flow showing orders being packed into consignments, see the <a href="/pro/api/help/flows/order_flex_flow.html">Order Flex</a> call flow page.

## Next Steps

* Learn how to retrieve delivery options at the [Getting Delivery Options](/pro/api/help/getting_delivery_options.html) page.
* Learn how to retrieve a consignment's customs documentation and invoices at the [Getting Customs Docs And Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page.
* Learn how to track consignments at the [Tracking Consignments](/pro/api/help/tracking_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>
