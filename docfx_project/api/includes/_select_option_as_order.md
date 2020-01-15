> Select Delivery Option as an Order Endpoint
```
POST https://api.electioapp.com/deliveryoptions/selectorder
```

> Example Select Delivery Option as an Order Request

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

```xml
<?xml version="1.0" encoding="utf-8"?>
<SelectOrderRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Orders">
  <DeliveryOptions>
    <SelectDeliveryOptionRequest>
      <Reference>EDO-000-6DX-6XP</Reference>
      <OrderReferenceProvidedByCustomer>MYORDEREF001</OrderReferenceProvidedByCustomer>
      <MetaData>
        <MetaData>
          <KeyValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">OrderReference</KeyValue>
          <StringValue xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">10045634343</StringValue>
          <IntValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <DecimalValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <DateTimeValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
          <BoolValue xsi:nil="true" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common" />
        </MetaData>
      </MetaData>
    </SelectDeliveryOptionRequest>
  </DeliveryOptions>
</SelectOrderRequest>
```

> Example Select Delivery Option as an Order Response

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

```xml
<?xml version="1.0"?>
<SelectOrderResponse xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Orders">
    <SelectOrderResults>
        <SelectOrderResult>
            <DeliveryOptionReference>EDO-000-6DX-6XP</DeliveryOptionReference>
            <OrderReference>EO-000-002-0TT</OrderReference>
            <Status>201</Status>
            <Links>
                <ApiLink>
                    <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Detail</Rel>
                    <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://apisandbox.electioapp.com/orders/EO-000-002-0TT</Href>
                </ApiLink>
            </Links>
        </SelectOrderResult>
    </SelectOrderResults>
</SelectOrderResponse>
```

Once the customer has selected an available delivery option, you'll need to record their choice in SortedPRO via the **[Select Delivery Option as an Order](https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder)** endpoint. This endpoint takes the `{Reference}` of the selected option as a path parameter.

Once it has received the **Select Delivery Option as an Order** request, PRO uses the details of the selected option to create an order and returns an object containing the associated `{orderReference}`. The reference will come in useful in the next step, when we pack the order into consignments.

<aside class="note">
  For full reference information on the <strong>Select Delivery Option as an Order</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/SelectDeliveryOptionasanOrder">Select Delivery Option as an Order</a></strong> page of the API reference.
</aside>

### Example

The example to the right shows a request to select a delivery option that has a `{Reference}` of _EDO-000-6DX-6XP_ as an order. PRO takes that delivery option's details and creates an order with an `{orderReference}` of _EO-000-002-0TT_.