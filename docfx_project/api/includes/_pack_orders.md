> Pack Order Endpoint
```
POST https://api.electioapp.com/orders/{orderReference}/pack
```

> Example Pack Order Request

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

```xml
<?xml version="1.0" encoding="utf-8"?>
<PackOrderRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.PackOrders">
  <OrderReference>EO-000-002-0TT</OrderReference>
  <OrderReferenceProvidedByCustomer>MyOrderRef001</OrderReferenceProvidedByCustomer>
  <GenerateReturn>false</GenerateReturn>
  <Packages>
    <Package>
      <Dimensions>
        <Unit xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Cm</Unit>
        <Width xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">15.4</Width>
        <Length xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">21.7</Length>
        <Height xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10</Height>
      </Dimensions>
      <Weight>
        <Value xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">1.3</Value>
        <Unit xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Kg</Unit>
      </Weight>
      <PackageSizeReference />
      <Items>
        <Item>
          <Sku>SKU093434</Sku>
        </Item>
      </Items>
    </Package>
  </Packages>
</PackOrderRequest>
```

> Example Pack Order Response

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

```xml
<?xml version="1.0" encoding="utf-8"?>
<PackOrderResponse xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.PackOrders">
  <Results>
    <PackOrderResult>
      <Result>ConsignmentCreated</Result>
      <ApiLinks>
        <ApiLink>
          <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Consignment</Rel>
          <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://api.electioapp.com/consignments/EC-000-05B-MQ4</Href>
        </ApiLink>
      </ApiLinks>
    </PackOrderResult>
  </Results>
</PackOrderResponse>
```

Once your order is created, you'll need to use the **[Pack Order](https://docs.electioapp.com/#/api/PackOrder)** endpoint to create consignments from it.

It's important to understand the difference between a consignment and an order when using **Pack Order**:

* An **order** is a collection of items that is to be transported to the same destination on behalf of the same customer.
* A **consignment** is a collection of packages that is to be transported to the same destination, on behalf of the same customer, _from the same origin, on the same day, and by the same carrier_.

This means that orders can contain items that will not ship from the same location, but consignments cannot. Similarly, orders can contain items that will ship from the same location but at different times (for example, because one of the items a customer has purchased is out of stock).

The **Pack Order** endpoint enables you to take those items on an order that share an origin and are to be shipped together, and generate a shippable consignment from them. You will need to send one **Pack Order** request per consignment that you want to create from the order.

<aside class="info">
  As an example, suppose that a clothing retailer has received a customer order for a necklace, a bracelet, a coat, and a hat. As the necklace and bracelet are both physically small, the retailer elects to ship them in the same package. The necklace and bracelet are located in warehouse A, and the coat and hat in warehouse B. This would likely break down to:

  * Four items - The necklace, the bracelet, the coat, and the hat.
  * Three packages - One containing the necklace and bracelet, one containing the coat, and one containing the hat.
  * Two consignments - One with a single item for the package containing the necklace and bracelet, and another with separate packages for the coat and hat.
  * A single order comprising the customer's entire purchase.

  In this example, you would need to run <strong>Pack Order</strong> twice - once for each consignment.
</aside>

To make a **Pack Order** request, send a GET request to `https://api.electioapp.com/orders/{orderReference}/pack`. The body of the request can contain various properties that are used when creating the consignment, but at a minimum should contain the `{orderReference}` of the associated order and details of at least one `{item}` (and its accompanying `{package}`). The items and packages listed make up the consignment.

<aside class="note">
  The <strong>Pack Order</strong> request's <code>OrderReferenceProvidedByCustomer</code> field enables you to provide a custom reference for the consignment that the request generates. 
  
  If you add a custom reference to your <strong>Pack Order</strong> request, then PRO uses this value as the consignment's custom reference, as opposed to any <code>OrderReferenceProvidedByCustomer</code> you may have provided when creating the order. 
  
  If you do not add a custom reference to your <strong>Pack Order</strong> request, then PRO uses the existing order's <code>OrderReferenceProvidedByCustomer</code> (where provided) as the consignment's custom reference.
</aside>

Once SortedPRO has received a **Pack Order** request, it creates the consignment and returns the relevant `{consignmentReference}`.

### Example

The example to the right shows a **Pack Order** request to create a consignment with one package containing a single item from order _EO-000-002-0TT_. PRO creates the consignment and responds with a `{consignmentReference}` of _EC-000-05B-MQ4_.

<aside class="note">
  For full reference information on the <strong>Pack Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/PackOrder">Pack Order</a></strong> page of the API reference.
</aside>

