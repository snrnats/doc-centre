# Grouping Shipments

REACT shipment groups help you to track orders that will take more than one shipment to fulfil. This page explains how to use metadata to group shipments together, how to view shipment groups in the REACT UI, and how to present grouped shipments to your customers using REACT's tracking pages.

---

## Shipment Groups Overview

In REACT, a shipment is a singly-tracked consignment of goods that are being shipped together from a single origin location to a single destination location. Shipment groups enable you to link related shipments together so that they can be tracked through the same page.

For example, suppose that a clothing retailer has received an order for a coat and a hat. At the time of order, the two items are physically located in two different warehouses. This means that they will need to be sent as two separate shipments, as all items on a shipment must share an origin location.

However, both items are still a single order from the customer's perspective. As such, it would be a better user experience to provide the customer with a single link that they could use to track both shipments, rather than two separate links.

By using shipment groups, you can link these two shipments together via a shared metadata property, enabling you to send tracking details for both as a single link. You can then use this metadata property as an identifier for a REACT tracking page link. The page displayed by the link displays tracking information for all shipments tagged with that property, with a drop-down menu enabling customers to switch between all shipments in the group without following a separate link. 

## Registering Grouped Shipments

Shipment groups are based on metadata. If two shipments share an identical metadata property (that is, one that has both the same `key` and `value`), then REACT considers them to be grouped together.

The following example shows a request to register four simple shipments at once. The shipments all have a metadata key named `group_name` denoting the group they are in. The first two shipments belong to `example_group1`, and the second two below to `example_group2`.

<div class="tab">
    <button class="staticTabButton">Shipment Groups Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'HTTPRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="HTTPRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'HTTPRequest')">

```json
{
    "shipments": [
    	{
            "tracking_references": [
                "shipment1"
            ],
            "metadata": [
                {
                "key": "group_name",
                "value": "example_group1",
                "type": "String"
                }
            ]
    	},
    	{
            "tracking_references": [
                "shipment2"
            ],
            "metadata": [
                {
                "key": "group_name",
                "value": "example_group1",
                "type": "String"
                }
            ]
    	},
        {
            "tracking_references": [
                "shipment3"
            ],
            "metadata": [
                {
                "key": "group_name",
                "value": "example_group2",
                "type": "String"
                }
            ]
    	},
        {
            "tracking_references": [
                "shipment4"
            ],
            "metadata": [
                {
                "key": "group_name",
                "value": "example_group2",
                "type": "String"
                }
            ]
    	}        
    ]
}
```

</div>




## Naming Shipment Groups



## Viewing Grouped Shipments
hazardousItemCount


## Next Steps

Read on for more info:

* [REACT Overview](https://docs.sorted.com/react/overview/)
* [Registering Shipments](https://docs.sorted.com/react/registering-shipments/)
* [Managing Webhooks](https://docs.sorted.com/react/managing-webhooks/)
* [Retrieving Shipment and Event Data](https://docs.sorted.com/react/retrieving-data/)

<script src="../../pro/scripts/requesttabs.js"></script>
<script src="../../pro/scripts/responsetabs.js"></script>
<script src="../../pro/scripts/copy.js"></script>