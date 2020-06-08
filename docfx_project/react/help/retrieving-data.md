# Retrieving Shipment and Event Data

SortedREACT's APIs can retrieve shipment, event, and tracking information, enabling you to embed live shipment tracking into your websites and apps. This page explains the endpoints you can use to get this information, and the format in which the information is returned.

---

## Tracking in REACT

REACT has three APIs that enable you to retrieve information.

* The **Shipment** API enables you to retrieve full details of one or more shipments.
* The **Tracking** API enables you to retrieve carrier tracking event details in a standardised format. This is the API that you would likely use to drive embedded tracking on your site or apps.
* The **Events** API enables you to retrieve details of events within REACT (for example, an address or shipment state change).

> <span class="note-header">Note:</span>
>
> All REACT APIs require you to include JSON `Content-Type` and `Accept` headers and a valid API key as request headers. You can get an API key from the **Settings > API Keys** page of the REACT UI.
>
> For more information on obtaining an API key, see the [Getting an API Key](/react/help/quick-start.html#registering-a-shipment) section of the Quick Start guide.

## Retrieving Shipments

REACT has two endpoints that you can use to get shipment details:

* **[Get Shipments](https://docs.sorted.com/react/api/#GetShipments)** - Takes shipment `tracking_references` and `custom_references` and returns details of all shipments that meet those criteria.
* **[Get Shipment by Shipment ID](https://docs.sorted.com/react/api/#GetShipmentbyShipmentID)** - Takes a shipment `{id}` and returns details of the corresponding shipment.

### Get Shipment by Shipment ID Endpoint

The **Get Shipment by Shipment ID** endpoint returns details of a single shipment by that shipment's REACT `{id}`. To use the **Get Shipment by Shipment ID** endpoint, send a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/shipments/{id}`.

You can only use this API to get details of your own shipments. If you attempt to get details of another customer's shipments, REACT returns an error.

### Get Shipments Endpoint

The **Get Shipments** endpoint returns details of all shipments that meet your search criteria. It accepts the following parameters:

<div class="table-1">

| Parameter           | Description                                                           | Format                                                                          | Example                             |
| ------------------- | --------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ----------------------------------- |
| Start               | Returns all shipments that were created after the supplied timestamp         | <a href="https://en.wikipedia.org/wiki/Unix_time" target="_blank">Unix time</a> | `start=1543920000`                  |
| End                 | Returns all shipments that were created before the supplied timestamp        | <a href="https://en.wikipedia.org/wiki/Unix_time" target="_blank">Unix time</a> | `end=1543926896`                    |
| Tracking References | Returns the shipment that has the specified tracking reference          | String                                                                          | `tracking_reference=TRK098JKH54ADD` |
| Custom References   | Returns all shipments that have the specified custom reference          | String                                                                          | `custom_references=HB-003`          |
| Page                | Returns a particular page of results          | Integer                                                                          | `page=2`          |

</div><br/>

To use the **Get Shipments** endpoint, send a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/shipments/search?start=timestamp&end=timestamp&tracking_references=strings&custom_references=strings&page=int`.

> <span class="note-header">Note:</span>
>
> You can only retrieve shipments by `custom_references` if you have previously registered that information for the relevant shipments. For more information on registering shipment information, see the [Registering Shipments](/react/help/registering-shipments.html) page.

None of the search parameters are mandatory in themselves, but at least one search parameter must be provided. If you do not provide at least one search parameter, then REACT returns a validation error. 

The timestamp parameters must be provided in pairs. If you provide a `start` value with no corresponding `end` value (or vice versa), then REACT returns a validation error. Timestamps should be provided as UTC time. If neither timestamp is specified, then REACT searches for shipments created in the last 28 days (including today).

You can only add a maximum of one `tracking_reference` to your request. As such, you can only return one shipment at a time when searching by `tracking_reference`. To search for multiple shipments at once, use `custom_references`. You can add multiple `custom_references` by appending additional `&custom_references=(strings)` parameters to the end of the link. REACT treats multiple `custom_references` as an AND operation, and will return only those shipments that contain all provided references.

Where a valid request is made but no matching shipments are found, REACT returns an empty array with a link to the resource itself. Note that in this scenario the response has a code _200 OK_ rather than _404 Not Found_, as the request itself is valid even though there are no shipments currently matching your search criteria.

<div class="tab">
    <button class="staticTabButton">No Matching Shipments Example</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'nmsExample')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="nmsExample" class="staticTabContent" onclick="CopyToClipboard(this, 'nmsExample')">

```json
{
  "shipments": [],
  "_links": [
    {
      "href":
        "https://api.sorted.com/react/shipments/search?trackingReferences=nonexistenttrackingreference",
      "rel": "self"
    }
  ]
}
```

</div>

As with all REACT APIs, the **Get Shipments** endpoint retrieves a maximum of 200 records with any single request. Where more than 200 records exist, paging links to the next and previous set of results, as well as the first and last set of results, are returned. The `page` parameter enables you to request a particular page of results. See the [Paging Results](#paging-results) section for more information on paging in REACT's APIs.

### The Shipment Resource

Both Get Shipments endpoints return **Shipment** resources. The **Shipment** resource contains the information provided when the shipment was registered. For more information on the information that REACT accepts when registering a shipment, see the [Registering Shipments](/react/help/registering-shipments.html) doc page and the [Register Shipments API reference](https://docs.sorted.com/react/api/#RegisterShipments).

As well as the shipment's registration information, the **Shipment** resource contains some REACT-generated properties that could be particularly useful when embedding tracking pages on your website or app:

* `shipment.shipment_state.state` - Contains the shipment's current REACT shipment state. REACT uses carrier tracking events to calculate this value. For a full list of available REACT shipment states, see the [Shipment States](/react/help/shipment-states.html) page.
* `shipment.shipment_state.state_label` - Contains the customer-facing label for the shipment's current state. You can customise shipment state labels using the **Custom State Labels** UI page. If you have not set a custom label up for the shipment state then this field contains the default label text.
   > <span class="note-header">Note:</span>
   >
   > The **Custom State Labels** UI page enables you to set up custom labels in multiple languages. By default, REACT's APIs and webhooks return labels in `en-gb` (English - United Kingdom). To retrieve labels in languages other than `en-gb`, add an `accept-language` header with the relevant language code as its value to your API request.
   > 
   >For example, to retrieve language labels in German, you would first need to use the **Customise Shipment State Labels** page to add German labels to your shipment states. You would then add an `accept-language` header with a value of `de` to any API requests you made. In its response, REACT would populate the `state_label` field with your German labels.
* `shipment.delivered_date` - The date and time on which the shipment was delivered. REACT automatically records this information when a shipment enters a state of _Delivered_,  _Delivered to Neighbour_, _Delivered to Reception_, or _Delivered to Safe Location_. 
* `shipment.may_be_missing` - Indicates whether REACT believes that the shipment may be missing. REACT marks shipments as `may_be_missing` if they are not updated within a set time period after registration, or if they are not marked as delivered, lost, or refused within a different set time period. REACT can only perform `may_be_missing` calculations for shipments that have a `country_iso_code` recorded for their origin and destination addresses.
* `shipment.lateness.late` and `shipment.lateness.hours_late` - These properties indicate whether REACT believes a shipment to be late, and (where applicable) how many hours late this shipment is. REACT can only perform lateness calculations for shipments that have a `promised_date` recorded. 

> <span class="note-header">More Information:</span>
>
> This section gives a high-level overview of the information returned by the Get Shipments endpoints. For full reference details of the data returned, see the [Get Shipment Events](https://docs.sorted.com/react/api/#GetShipmentEvents) and [Get Shipment Events by Shipment ID](https://docs.sorted.com/react/api/#GetShipmentEventsbyShipmentID) sections of the API reference.

## Retrieving Tracking Events

The **[Get Tracking Events by Shipment ID](https://docs.sorted.com/react/api/#GetTrackingEventsbyShipmentID)** endpoint enables you to get details of carrier tracking events. **Get Tracking Events by Shipment ID** takes a shipment `{id}` and returns all tracking events associated with that shipment, as well as a summary of shipment details.

To use the **Get Tracking Events by Shipment ID** endpoint, send a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/tracking/search?shipment_id=string`.

### The Tracking Events Resource

The Tracking API returns a **Shipment Tracking Events** resource. The **Shipment Tracking Events** resource contains details of all tracking events related to a particular shipment and a summary of the shipment itself. The tracking information in the **Shipment Tracking Events** resource takes a standardised format, with the same data structure used for all carriers. 

The **Shipment Tracking Events** resource has two parts:

* `ShipmentSummary` - This object contains a summary of the data REACT holds on the shipment, including tags, reference numbers, carrier information and expected dates.
* `events` - This array contains details of all tracking events associated with the shipment in question.

The `ShipmentSummary` object contains all the information in the [Shipments](https://docs.sorted.com/react/api/#GetShipments) resource, except for the following:

* Consumer details.
* Address information.
* Carrier service details.
* Shipping and order dates.

The `events` object contains any tracking events that are associated with the selected shipment. Each **Tracking Event** resource contains details on an individual carrier tracking event, including:

* **ID** - A REACT-generated unique identifier for the tracking event.
* **Dates and Times** - The timestamps at which that the event occurred and was received by REACT.
* **Event Code** - The REACT event code.
* **Event Description**
* **Signee** - The name of the signee for the shipment, where applicable.
* **Location** - A text description of the location at which the tracking event occurred.
* **Latitude / Longitude** - The latitude and longitude of the location at which the event occurred.

If REACT finds a shipment that meets your criteria, but that shipment does not have associated tracking events, then the Tracking API returns a response containing shipment details only. This feature enables you to distinguish between a _404 Not Found_ response in which data matching the supplied details could not be found, and a _200 OK_ response in which a matching shipment was found but that shipment did not contain any tracking event data.

> <span class="note-header">More Information:</span>
>
> This section gives a brief overview of the contents of the **Tracking Event** resource. For full reference information, see the [Get Tracking Events by Shipment ID](https://docs.sorted.com/react/api/#GetTrackingEventsbyShipmentID) section of the API reference.

## Retrieving Events

You can get event details using the following endpoints:

* **[Get Shipment Events](https://docs.sorted.com/react/api/#GetShipmentEvents)** - Takes various shipment-related parameters and returns details of all events associated with the selected shipments, as well as summaries of the shipments themselves.
* **[Get Shipment Events by Shipment ID](https://docs.sorted.com/react/api/#GetShipmentEventsbyShipmentID)** - Takes a `shipment.id` and returns all events associated with that shipment, as well as a summary of shipment details.

You can only retrieve events which are associated with your organisation's shipments. REACT returns an error if you attempt to retrieve another organisation's event details.

REACT events are not the same as carrier tracking events. REACT uses events to track changes in shipment state. An event is generated whenever one of the following occurs:

* A shipment's `shipment_state` changes.
* A shipment's `promised_date` or `shipped_date` changes.

> <span class="note-header">Note:</span>
> 
> The Events API returns the same data as REACT's webhooks. You may want to consider implementing webhooks rather than integrating Events endpoints, as webhooks enable REACT to send event data proactively rather than requiring you to make a request. For more information on implementing webhooks, see the [Managing Webhooks](/react/help/managing-webhooks.html) page.

### The Get Shipment Events Endpoint

The **Get Shipment Events** endpoint returns details of all events related to a particular shipment or group of shipments, as well as a summary of the shipments themselves. It accepts the following parameters:

<div class="table-1">

| Parameter           | Description                                                           | Format                                                                          | Example                             |
| ------------------- | --------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ----------------------------------- |
| Start               | Returns all events that occurred after the supplied timestamp         | <a href="https://en.wikipedia.org/wiki/Unix_time" target="_blank">Unix time</a> | `start=1543920000`                  |
| End                 | Returns all events that occurred before the supplied timestamp        | <a href="https://en.wikipedia.org/wiki/Unix_time" target="_blank">Unix time</a> | `end=1543926896`                    |
| Tracking References | Returns all events associated with the specified shipment             | String                                                                          | `tracking_reference=TRK098JKH54ADD` |
| Custom References   | Returns all events associated with the specified shipment(s)          | String                                                                          | `custom_references=HB-003`          |
| Carrier             | Returned all events associated with the specified carrier's shipments | String                                                                          | `carrier=CarrierX`                  |

</div><br/>

To use the **Get Shipment Events** endpoint, send a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/events/search?start=timestamp&end=timestamp&tracking_references=strings&custom_references=strings&carrier=strings`. 

None of the search parameters are mandatory in themselves, but at least one search parameter must be provided. If you do not provide at least one search parameter, then REACT returns a validation error. 

The timestamp parameters must be provided in pairs. If you provide a `start` value with no corresponding `end` value (or vice versa), then REACT returns a validation error. Timestamps should be provided as UTC time.

As with all REACT APIs, the **Get Shipment Events** endpoint retrieves a maximum of 200 records with any single request. Where more than 200 records exist, paging links to the next and previous set of results, as well as the first and last set of results, are returned. See the [Paging Results](/react/help/retrieving-data.html#paging-results) section for more information on paging in REACT's APIs.

If REACT finds shipments that meet your criteria, but those shipments do not have associated events, then the Events API returns a response containing shipment details only. This feature enables you to distinguish between a _404 Not Found_ response in which data matching the supplied details could not be found, and a _200 OK_ response in which a matching shipment was found but that shipment did not contain any event data.

> <span class="note-header">More Information:</span>
>
> This section gives a brief overview of **Get Shipment Events** requests. For full reference information, see the [Get Shipment Events](https://docs.sorted.com/react/api/#GetShipmentEvents) section of the API reference.

### The Get Shipment Events by Shipment ID Endpoint

The **Get Shipment Events by Shipment ID** endpoint takes a shipment `{id}` and returns details of all events related to a particular shipment, as well as a summary of the shipment itself. 

To use the **Get Shipment Events by Shipment ID** endpoint, send a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/events/search?shipment_id=string`.

### The ShipmentEvents Resource

The **Get Shipment Events by Shipment ID** and **Get Shipment Events** endpoints return **ShipmentEvents** resources. The **ShipmentEvents** resource contains details of all events related to a particular shipment and a summary of the shipment itself.

The **Shipment Events** resource has two parts:

* `ShipmentSummary` - This object contains a summary of the data REACT holds on the shipment, including tags, reference numbers, carrier information and expected dates.
* `events` - This array contains details of all events associated with the shipment in question.

The `ShipmentSummary` object contains all the information in the [Shipments](https://docs.sorted.com/react/api/#GetShipments) resource, except for the following:

* Consumer details.
* Address information.
* Carrier service details.
* Shipping and order dates.
* Custom metadata fields.

The `events` object contains the following information:

* **ID** - A REACT-generated unique identifier for the event.
* **Event Type** - The event's type (e.g. `state_change` or `rescheduled`).
* **Timestamp** - The time that the event occurred.
* **Message** - A brief message describing the event.
* **Property Summary** - Details of any changes that were made to the shipment's `shipment.shipment_state.state`, `shipment.delivered_date`, `shipment.promised_date`, and `shipment.shipped_date` properties, including whether each property was changed as a result of the event, the property's value before the event, and the property's value after the event.

Within the `events` object, events are grouped by the action that triggered them. The `EventGroup` object contains an array of individual events. 

Each `EventGroup` has a `Trigger` property containing details of the action that triggered the event, including the initiator (for example, the carrier or user), a brief message describing the trigger, and a timestamp. `EventGroup`s can be identified by `correlation_id` - a REACT-generated string assigned to groups of events.

As an example of event grouping, let's suppose that the following sequence of events has occurred:

1.  A carrier was unable to deliver a shipment, and left a calling card.
2.  The customer has called the carrier to indicate that they would like to pick the shipment up from a click and collect point.
3.  The carrier has put the shipment back out for delivery to the click and collect point and recorded the `promised_date` that the customer was advised the shipment would be reading for collection by.

The carrier update would cause two events to be generated: one with an `EventType` of *state_change*, and one with an `EventType` of *key_property_change*. These events would be grouped into the same `EventGroup` object, because they were triggered by the same action.

> <span class="note-header">More Information:</span>
>
> This section gives a brief overview of the **ShipmentEvents** resource. For full reference information, see the [Get Shipment Events](https://docs.sorted.com/react/api/#GetShipmentEvents) section of the API reference.

## Retrieving Shipment State History

You can also use the Events API to get further information on shipment states. The **[Get Shipment States History](https://docs.sorted.com/react/api/#GetShipmentStatesHistory)** endpoint takes a shipment `{id}` and returns a history of the shipment states that a particular shipment has been in.

To use the **Get Shipment States History** endpoint, send a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/events/shipment-states?{id}`. 

### The Shipment State Events Resource

The **Get Shipment States History** endpoint returns a **Shipment State Events** resource. In addition to the relevant shipment ID, this resource contains an array of **ShipmentStateEvent** objects, one for each state that that shipment has assumed. Each of these objects contains the following data:

* **State** - The state that the shipment assumed.
* **Label** - The custom label corresponding to that shipment state, where applicable.
   > <span class="note-header">More Information:</span>
   >
   > Custom shipment state labels enable you to explain shipment states to your customers in your brand's own tone of voice. For more information on setting up custom shipment state labels, see the [Setting up Custom State Labels](/react/help/settings.html#setting-up-custom-state-labels) section of the **Settings** page.
* **Timestamp** - The date and time at which the shipment assumed the state in question.

The following example shows the **Shipment State Events** resource for a shipment that has gone from *Dispatched* to *In Transit* to *Delivered*, with accompanying timestamps and custom labels.  

<div class="tab">
    <button class="staticTabButton">Shipment State Events Resource</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'shipState')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="shipState" class="staticTabContent" onclick="CopyToClipboard(this, 'shipState')">

```json
{
  "shipment_id": "sp_18446744073709551615",
  "shipment_state_events": [
    {
      "shipment_state": "Dispatched",
      "state_label": "Dispatched!",
      "timestamp": "2019-03-22T14:52:02.1053944+00:00"
    },
    {
      "shipment_state": "In Transit",
      "state_label": "In Transit!",
      "timestamp": "2019-03-22T17:31:02.1022944+00:00"
    },
        {
      "shipment_state": "Delivered",
      "state_label": "Delivered!",
      "timestamp": "2019-03-23T18:02:02.103544+00:00"
    }
  ]
}
```

</div>

> <span class="note-header">More Information:</span>
>
> This section gives a brief overview of the **Shipment State Events** resource. For full reference information, see the [Get Shipment States History](https://docs.sorted.com/react/api/#GetShipmentStatesHistory) section of the API reference.

## Paging Results

REACT enables you to retrieve a maximum of 200 records with any individual API call. Where more than 200 records exist, paging links are supplied. These links enable you to retrieve the next, previous, first, and last sets of results.

All paging links follow a standard format. They are returned in a `_links` object, located after either the 200th or final record returned, whichever is earlier. Each link takes the format `[URL requested]&page=[PAGE NUMBER]`

For example, let's say you want to view all events for the shipments you have with Carrier X. You've sent a <span class="text--blue text--bold">GET</span> request to `https://api.sorted.com/react/events/search?carrier=Carrier%20X&page=1`, which has found around 900 results. After the 200th record, the response from the API would include the following:

<div class="tab">
    <button class="staticTabButton">Paging Links</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'pagingLinks')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="pagingLinks" class="staticTabContent" onclick="CopyToClipboard(this, 'pagingLinks')">

```json
{
  "_links": [
    {
      "rel": "self",
      "href":
        "https://api.sorted.com/react/events/search?carrier=Carrier%20X&page=1"
    },
    {
      "rel": "next",
      "href":
        "https://api.sorted.com/react/events/search?carrier=Carrier%20X&page=2"
    },
    {
      "rel": "first",
      "href":
        "https://api.sorted.com/react/events/search?carrier=Carrier%20X&page=1"
    },
    {
      "rel": "last",
      "href":
        "https://api.sorted.com/react/events/search?carrier=Carrier%20X&page=5"
    }
  ]
}
```

</div>

To access the rest of the results, you would need to make a <span class="text--blue text--bold">GET</span> request to the relevant paging link. For example, to get the third page of results, you would use <span class="text--blue text--bold">GET</span> `https://api.sorted.com/react/events/search?carrier=Carrier%20X&page=3`. Results are sorted by created on date.

This paging format is used across all of REACT's APIs.

## Next Steps

Learn more about integrating with REACT:

* [Registering Shipments](/react/help/registering-shipments.html)
* [Updating Shipments](/react/help/updating-shipments.html)
* [Error Codes](/react/help/error-codes.html)

<script src="../../pro/scripts/requesttabs.js"></script>
<script src="../../pro/scripts/responsetabs.js"></script>
<script src="../../pro/scripts/copy.js"></script>