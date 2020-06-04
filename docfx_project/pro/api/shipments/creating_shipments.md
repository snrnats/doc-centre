# Creating Shipments

In order for SortedPRO to manage a shipment, you'll need to record the details of that shipment on the system. This page explains how to use the **Create Shipment** endpoint to create a new shipment record, and how to clone existing shipments using the **Clone Shipment** endpoint.

---

## Sending a Create Shipment Request

The **Create Shipment** endpoint enables you to create new shipment records within PRO. When you send a valid **Create Shipment** request, PRO generates a new shipment record and returns a unique shipment `{reference}` for it. Many of PRO's endpoints take this shipment `{reference}` as a parameter.

To create a shipment, send a `POST` request to `https://api.sorted.com/pro/shipments`. The body of the request should contain the shipment details, structured as per the PRO data contract.

> <span class="note-header">Note:</span>
>
> For full reference information on the **Create Shipments** endpoint, including the properties accepted and the structure required, see [LINK HERE]

### Required Shipment Properties

As a minimum, the **Create Shipments** endpoint requires you to send:

* `shipment_type` - Specifies whether the shipment is `on_demand` (i.e. will require an ad-hoc carrier collection to be booked) or `scheduled` (i.e. will be picked up as part of a regularly scheduled carrier collection ).
* `contents` - The contents of the shipment itself.
* `addresses` - All shipments require both `origin` and `destination` addresses.

### Specifying Shipment Contents

The `contents` object replaces the older `package` and `item` objects used in PRO's original Consignments-based implementation. `Contents` objects are designed to nest within each other, and can be used at both package and item level.

As an example, suppose that a clothing retailer has received a customer order for a necklace, a bracelet, and a coat. As the necklace and bracelet are both physically small, the retailer elects to ship them in the same package. The resulting shipment would contain:

* One `contents` object containing details of the coat and its accompanying package.
* One `contents` object containing details of the package that the necklace and bracelet are shipping in.
* One `contents` object containing details of the necklace, nested inside the object representing its package.
* One `contents` object containing details of the bracelet, nested inside the object representing its package.

The example below shows how this shipment would be represented in JSON. This is a highly simplified example, with only the minimum properties (`value` and `description`) given for each `contents` object. In practice, you would probably look to provide additional detail on the shipment contents by specifying optional properties. 

<div class="tab">
    <button class="staticTabButton">Contents Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'contentsExample')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="contentsExample" class="staticTabContent" onclick="CopyToClipboard(this, 'contentsExample')">

```json
    "contents": [
        {
            "value": {
                "amount": 79.99,
                "currency": "GBP",
                "discount": 0.0
            },
            "description": "Coat"
        },
        {
            "value": {
                "amount": 0,
                "currency": "GBP",
                "discount": 0.0
            },
            "description": "Package for necklace and bracelet",
            "contents": [
                {
                    "value": {
                        "amount": 39.99,
                        "currency": "GBP",
                        "discount": 0.0
                    },
                    "description": "Necklace"
                },
                {
                    "value": {
                        "amount": 29.99,
                        "currency": "GBP",
                        "discount": 0.0
                    },
                    "description": "Bracelet"
                }    
            ]
        }
    ],
```
</div>

<span class="highlight">NEED TO CHECK THE EXAMPLE ABOVE.</span> 

### Specifying Addresses

All shipments require both `origin` and `destination` addresses. In PRO, addresses are represented by `address` objects, which must be specified as a list inside the `shipments.addresses` property. As a minimum, each address must include the following:

* `address_type` - As well as `origin` and `destination` address types, PRO enables you to specify `return`, `sender`, `recipient`, `importer`,	and `billing` addresses.
* `shipping_location_reference` - Each shipping location that you run scheduled shipments from should have a unique shipping location reference. The `shipping_location_reference` property is optional for `on_demand` shipments but required for `scheduled` shipments. Where provided, the value must be a valid shipping location reference for your organisation. For information on how to obtain a list of your organisation's shipping locations, see [LINK HERE]
* `contact`- Details of the contact at the address (for example, the name of the recipient). This property is only required where a `shipping_location_reference` is not provided.
* `address_line_1` - All addresses must have at least one line.
* `region` - The state, county, or equivalent. This property is required for certain countries, such as the US, Australia, and Canada.
* `postal_code` - Required for countries with official postcode systems, such as the UK.
* `country_iso_code` - The ISO 3166 Alpha 2 code for the country.

In addition, PRO supports several optional address properties, including custom references, company details, and latitude / longitude. See [LINK HERE] for details.

### Optional Shipment Properties

There are lots of optional properties you can send when creating a shipment, including:

* Your own custom reference for the shipment.
* Required shipping and delivery dates.
* The order date.
* Customs documentation for international shipments. For more information on using customs documentation in PRO, see [LINK HERE].
* Shipment direction.
* Custom label properties.
* Tenant and channel.
* Metadata. PRO metadata enables you to use custom fields to record additional data about a shipment. For more information on using metadata in PRO, see [LINK HERE].
* Tags. Allocation tags enable you to filter the list of carrier services that a particular shipment could be allocated to. For more information on allocation tags, see [LINK HERE].

Adding optional properties when you create a shipment can help you to ensure that your shipment is allocated to the most appropriate carrier service.

> <span class="note-header">Note:</span>
>
> You should exercise caution when using the `required_delivery_date` and `required_shipping_date` parameters to specify dates for your shipment. These parameters limit delivery options for the shipment, meaning that it can only be allocated to carrier services that would be able to ship it within the specified `required_shipping_date` range and / or deliver it by the specified `required_delivery_date` range. 
>
> If the dates you specify are too restrictive, there may not be any carrier services available to take the shipment, which would result in a failed allocation. As such, you should only specify shipping and delivery dates where it is necessary to do so.

<span class="highlight">THE NOTE ABOVE IS REPURPOSED FROM THE CONSIGNMENTS HELP. IS IT STILL RELEVANT?</span>

### Example Create Shipment Request

The example below shows a simple **Create Shipment** request containing only a `shipment_type`, `contents`, and `addresses`. For an example of a full **Create Shipment** request, see [LINK HERE]

<div class="tab">
    <button class="staticTabButton">Example Create Shipment Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createShipmentRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createShipmentRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'createShipmentRequest')">

```json

{
    "shipment_type": "scheduled",
    "contents": [
        {
            "custom_reference": "b9fa91b0-0dd0-4dd5-986f-363fa8cb2386",
            "package_size_reference": null,
            "weight": {
                "value": 2.40,
                "unit": "Kg"
            },
            "dimensions": {
                "unit": "Cm",
                "width": 15.0,
                "height": 15.5,
                "length": 20.0
            },
            "description": "Jeans",
            "value": {
                "amount": 8.99,
                "currency": "GBP"
            },
            "sku": "SKU09876",
            "model": "MOD-009",
            "country_of_origin": "PT",
            "harmonisation_code": "09.02.10",
            "shipping_terms": "fca",
            "quantity": 2,
            "unit": "Box",
            "dangerous_goods": {
                "class_division": "2",
                "class_sub_divisions": [
                    "1"
                ],
                "packing_group": "iii",
                "id_number": "UN2202",
                "proper_shipping_name": "Hydrogen selenide, anhydrous",
                "technical_name": null,
                "physical_form": "gas",
                "radioactivity": "surface_reading",
                "accessibility": "accessible",
                "custom_label_text": null
            },
            "metadata": [
                {
                    "key": "Category",
                    "value": "Menswear",
                    "type": "string"
                }
            ],
            "label_properties": null,
            "Contents": null
        }
    ],
    "addresses": [
        {
            "address_type": "origin",
            "shipping_location_reference": "SLOC001"
        },
        {
            "address_type": "destination",
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865",
                "title": "Mr",
                "first_name": "Gardner",
                "last_name": "Minshew",
                "middle_name": null,
                "position": null,
                "contact_details": {
                    "landline": null,
                    "mobile": "+447495747987",
                    "email": "steve@kingston.com"
                }
            },
            "property_number": "8",
            "property_name": null,
            "address_line1": "Norbert Road",
            "address_line2": "Bertwistle",
            "address_line3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ]
}

```

</div>

## The Create Shipments Response

Once it has received the shipment information, PRO creates the shipment record and returns a link to the newly-created shipment, including its `{reference}`. 

The `{reference}` is a unique identifier for that shipment within PRO, and is a required parameter for many of PRO's API requests. Each PRO shipment `{reference}` takes the format `sp_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx`, where `x` is a numerical digit. 

In the example below, PRO has returned a shipment `{reference}` of _sp_00595452779180472847666078547968_. 

<div class="tab">
    <button class="staticTabButton">Example Create Shipment Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'createShipmentResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="createShipmentResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'createShipmentResponse')">

```json
{
  "reference": "sp_00595452779180472847666078547968",
  "message": "Shipment created successfully",
  "_links": [
    {
      "href": "https://api.sorted.com/pro/shipments/sp_00595452779180472847666078547968",
      "rel": "shipment",
      "reference": "sp_00595452779180472847666078547968",
      "type": "shipment"
    }
  ]
}
```
</div>

All PRO shipments have a `{state}`, indicating the point in the delivery process that that particular shipment is at. Newly-created shipments have an initial state of `Unallocated`. For more information on PRO shipment states, see [LINK HERE].

<span class="highlight">SHOULD PROBABLY PUT A NOTE IN HERE ABOUT CREATING SHIPMENTS IN THE UI ONCE WE KNOW WHAT THE NEW UI IS GOING TO LOOK LIKE</span>

## Cloning Shipments

