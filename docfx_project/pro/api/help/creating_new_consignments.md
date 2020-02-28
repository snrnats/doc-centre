# Creating New Consignments

In order for SortedPRO to manage a consignment, you'll need to record the details of that consignment on the system. This page explains explains the various ways that you can record consignment information in PRO.

---

## Creating a Consignment Via The Consignments API

Perhaps the simplest way to record consignment details in PRO is to use the **Create Consignment** API endpoint. **Create Consignment** enables you to send consignment details directly to PRO, from which PRO creates the consignment record and returns a unique `{consignmentReference}`.

### Sending The Request

To create a consignment, send a `POST` request to `https://api.electioapp.com/consignments`. The body of the request should contain the consignment details, structured as per the PRO data contract.

> <span class="note-header">Note:</span>
>
> For full reference information on the **Create Consignments** endpoint, including the properties accepted and the structure required, see the <a href="https://docs.electioapp.com/#/api/CreateConsignment">Create Consignments API reference</a>.

As a minimum, the **Create Consignments** endpoint requires you to send package weights and dimensions, origin address, and destination address data. You can either specify package weights and dimension via the `Weight` and `Dimensions` properties, or by supplying a `PackageSizeReference`. 

> <span class="note-header">Note:</span>
>  A <code>PackageSizeReference</code> is a unique identifier for a pre-defined, standardised package size. 
>
> To configure standard package sizes, use the <strong><a href="https://www.electioapp.com/Configuration/packagingsizes">Configuration > Packaging Sizes</a></strong> page of the PRO UI. You can also view a list of your available standard package sizes by making a call to the <a href="https://docs.electioapp.com/#/api/GetPackageSizes">Get Package Sizes</a> API.

Either the consignment's `destination` address, its `origin` address (if it has one), or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

There are lots of optional properties you can send when creating a consignment, including:

* Your own consignment reference.
* Details of the specific items inside the consignment's packages.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to us custom fields to record additional data about a consignment. For more information on using metadata in PRO, see <span class="highlight">[LINK HERE]</span>.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see <span class="highlight">[LINK HERE]</span>.

Adding optional properties when you create a consignment can help you to get more out of PRO. For example, recording your own consignment reference enables you to search for consignments by those references in the UI and via the **Search Consignments** endpoint. 

> <span class="note-header">Note:</span>
>
> You should exercise caution when using the `ShippingDate` and `RequiredDeliveryDate` parameters to specify dates for your consignment. These parameters limit delivery options for the consignment, meaning that the consignment can only be allocated to carrier services that would be able to ship it on the specified `ShippingDate` and / or deliver it by the `RequiredDeliveryDate`. If the `IsToBeExactlyOnTheDateSpecified` flag of the `RequiredDeliveryDate` is set, then the consignment is further limited, as it can only be allocated to a service that would deliver it on the exact date specified.
>
> If the dates you specify are too restrictive, there may not be any carrier services available to take the consignment, which would result in a failed allocation. As such, you should only specify shipping and delivery dates where it is necessary to do so.

### Example Create Consignments Request

The example below shows a simple **Create Consignments** request containing just package and address details. For an example of a full **Create Consignment** request, see the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) API reference.

<div class="tab">
    <button class="staticTabButton">Request Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createConRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createConRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'createConRequest')">

```json
{
  "Packages": [
    {
      "Weight": {
        "Value": 0.5,
        "Unit": "Kg"
      },
      "Dimensions": {
        "Unit": "Cm",
        "Width": 10.0,
        "Length": 10.0,
        "Height": 10.0
      },
      "Description": "Socks",
      "Value": {
        "Amount": 5.99,
        "Currency": {
          "IsoCode": "GBP"
        }
      }
    }  
  ],
  "Addresses": [
    {
      "AddressType": "Origin",
      "ShippingLocationReference": "EDC5_Electio",
      "IsCached": false
    },
    {
      "AddressType": "Destination",
      "Contact": {
        "Title": "Mr",
        "FirstName": "Peter",
        "LastName": "McPetersson",
        "Telephone": "07702123456",
        "Mobile": "07702123456",
        "LandLine": "0161544123",
        "Email": "peter.mcpetersson@test.com"
      },
      "AddressLine1": "13 Porter Street",
      "Region": "Greater Manchester",
      "Postcode": "M1 5WG",
      "Country": {
        "Name": "Great Britain",
        "IsoCode": {
          "TwoLetterCode": "GB"
        }
      },
      "IsCached": false
    }
  ]
}
```
</div>

### The Create Consignments Response

Once it has received the consignment information, PRO creates the consignment record and returns a link to the newly-created consignment, including its `consignmentReference`. 

The `{consignmentReference}` is a unique identifier for that consignment within PRO, and is a required parameter for many of PRO's API requests. Each PRO `consignmentReference` takes the format `EC-xxx-xxx-xxx`, where `x` is an alphanumeric character. Many of PRO's endpoints take `{consignmentReference}` as a parameter.

In the example below, PRO has returned a `{consignmentReference}` of _EC-000-05B-MMA_. 

<div class="tab">
    <button class="staticTabButton">Response Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createConResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createConResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'createConResponse')">

```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-05B-MMA"
  }
]
```
</div>

All PRO consignments have a `{consignmentState}`, indicating the point in the delivery process that that particular consignment is at. Newly-created consignments have an initial state of `Unallocated`. For more information on how PRO consignment states change across the lifecycle of a consignment, see <span class="highlight">{LINK HERE}</span>

> <span class="note-header">Note:</span>
>
> You can also create consignments via the <a href="https://www.electioapp.com/Allocation/ManualUpload">Manual Upload</a> page of the PRO UI. This feature is effectively a front-end for the **Create Consignments** API, and is most useful for handling exceptions and cases in which your conventional API workflow cannot be used.
>
> For more information on creating consignments via the PRO UI, see [LINK HERE]

## Creating Consignments from Delivery Options

The **Create Consignments** endpoint isn't the only PRO endpoint that can generate consignments. You can also create consignments via the **Delivery Options** API, which enables you to get a list of delivery options for a potential consignment that you can present to your customer at checkout. When you select the required option, PRO automatically creates and allocates a new consignment without requiring you to make additional API calls.

To create a consignment in this way, you'll need to make two API calls: 

1. Call the **Delivery Options** endpoint. The structure of the **Delivery Options** request is very similar to that of the **Create Consignment** request. However, rather than simply creating a consignment from the information, PRO instead returns a list of potential delivery options for the (as yet uncreated) consignment. Each delivery option represents a delivery date and time, and a carrier services that can fulfil the delivery of the consignment in line with that date and time. 

2. To select the option that the customer chooses, send the relevant `deliveryOptionReference` to PRO via the **Select Option** endpoint. PRO uses the information that you provided when making the **Delivery Options** request to create a new consignment and allocate it to the relevant carrier service for the selected delivery option. It then returns a link to the created consignment.

You can also generate consignments from pickup options. The process is the same as that used for delivery options - make a **Pickup Options** call and then select the required option via the **Select Option** endpoint.

> <span class="note-header">More Information:</span>
>
> * For a full user guide on working with delivery and pickup options, see the  <a href="/api/help/selecting_delivery_and_pickup_options.html">Selecting Delivery and Pickup Options</a> page.
> * For reference information on the Delivery Options and Pickup Options APIs, see the <a href="https://docs.electioapp.com/#/api/DeliveryOptions">API reference</a>.
> * For worked examples showing consignments being created from delivery options, see the <a href="/api/help/flows/consumer_options_flow.html">Consumer Options</a> and <a href="/api/help/flows/consumer_options_pickup_flow.html">Consumer Options Pickup</a> call flow documents.

## Creating Consignments from Orders

You can also create consignments from orders via the **Pack Order** endpoint. **Pack Order** enables you to take a PRO order and generate consignments from it. This function is particularly useful if your business uses multiple fulfilment centres, or uses drop ship vending.

It's important to understand the difference between a consignment and an order when using **Pack Order**:

* An **order** is a collection of items that is to be transported to the same destination on behalf of the same customer.
* A **consignment** is a collection of packages that is to be transported to the same destination, on behalf of the same customer, _from the same origin, on the same day, and by the same carrier_.

The **Pack Order** endpoint enables you to take those items on an order that share an origin and are to be shipped together, and generate a shippable consignment from them. You will need to send one Pack Order request per consignment that you want to create from the order.

To create a consignment in this way, you'll need to make two API calls: 

1. Call the **Create Order** endpoint to create an order in PRO. The structure of the **Create Order** request is very similar to that of the **Create Consignment** request, and must include package, origin address, and destination address data at a minimum. PRO creates the order and returns an `orderReference`.
2. Call the **Pack Order** endpoint to create the consignment. In the body of the request you'll need to supply at least the relevant `orderReference` and the package details of the consignment that you want to pack. Each package must contain at least one item. If the **Pack Order** request would create a valid consignment, then PRO creates the consignment and returns a consignment reference.

> <span class="note-header">More Information:</span>
>
> * For a full user guide on working with orders, see the <a href="/api/help/creating_new_orders.html">Creating New Orders</a> and <a href="/api/help/managing_existing_orders.html">Managing Existing Orders</a> page.
> * For reference information on the Orders API, see the <a href="https://docs.electioapp.com/#/api/CreateOrder">API reference</a>.
> * For worked examples showing consignments being created from orders, see the <a href="/api/help/flows/order_flex_flow.html">Order Flex</a> and <a href="/api/help/flows/consumer_options_flex_flow.html">Consumer Options Flex</a> call flow documents.

## Next Steps

* Learn how to work with existing consignments at the [Managing Existing Consignments](/api/help/managing_existing_consignments.html) page
* Learn how to allocate consignments at the [Allocating Consignments to Carriers](/api/help/allocating_consignments_to_carriers.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/api/help/getting_labels.html) page

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>