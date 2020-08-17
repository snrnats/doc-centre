---
uid: pro-api-data-contracts-shipments-shipments-dc
title: Shipments Data Contracts
tags: shipments,pro,api,reference,data-contract
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 12/08/2020
---
# Data Contracts

This section of the site lists all data contracts applicable to Sorted's public Shipments APIs.

> [!CAUTION]
> Changing API data contracts may **only** include the addition of new, optional properties. Once a data contract has been communicated to customers, the contract cannot be changed. You can consider data contracts open for extension, but closed for modification.

## Accessibility

Indicates the `accessibility` of dangerous goods during transport.

| Value | Description |
|------ | ------------|
| `accessible` | The goods are accessible (e.g. for inspection) |
| `inaccessible` | The goods are **not** accessible (e.g. for inspection) |

## Accessibility Rules

This object allows a customer to specify which type(s) of accessibility are explicitly included or excluded from this `ruleset`.

> [!NOTE]
> If no accessibility rules are provided, then any type of accessibility is permitted according to this `ruleset`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `include` | List of [`accessibility`](#accessibility) | The accessibility value(s) to include in this `ruleset` (allow) | Optional. If provided, must be a valid `accessibility`. If `exclude` is provided, then `include` must be `null` or empty. | `0..4` |
| `exclude` | List of [`accessibility`](#accessibility) | The accessibility value(s) to exclude from this `ruleset` (disallow) | Optional. If provided, must be a valid `accessibility`. If `include` is provided, then `exclude` must be `null` or empty. | `0..4` |

</div>

## Address

Each `shipment` must have at least 2 addresses: one of type `origin` and one of type `destination`. Other `address_types` are optional.

> [!NOTE]
> The required properties of an address differ based on the `shipment_type`. Any `on_demand` type `shipments` do **not** require a valid `shipping_location_reference`, whereas `scheduled` type `shipments` require either the `origin` or `destination` address to be a valid shipping location.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `address_type` | [`address_type`](#address-type) | Indicates the type of address, e.g. `origin` or `destination` | Required. All addresses must include a valid `address_type` value. All `shipments` must have at least an `origin` and a `destination` address. Only one address of each type may be included in any `shipment`. | `1` |
| `shipping_location_reference` | `string` | Used to reference a pre-defined shipping location | Optional for `on_demand` `shipments` but required for `scheduled` `shipments`. If provided, must be a valid existing shipping location. | `0..1` |
| `custom_reference` | `string` | Your own reference for this address, if applicable. | Optional. If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `contact` | [`contact`](#contact) | Details of the `contact` at the address. This should be used to specify the name of the recipient, for example. | Required when `shipping_location_reference` is not provided. | `0..1` |
| `company_name` | `string` | The name of the company, if applicable | Optional. If provided, must be `>=1` and `<= 100` characters | `0..1` |
| `property_number` | `string` | The number of the property, if applicable. | Optional. If provided, must be `>= 1` and `<= 50` characters | `0..1` |
| `property_name` | `string` | The name of the property, if applicable. | Optional. If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `address_line_1` | `string` | The first line of the address. | Required. Must be `>= 1` and `<= 255` characters. | `1` |
| `address_line_2` | `string` | The second line of the address. | Optional. If provided, must be `>= 1` and `<= 255` characters. | `0..1` |
| `address_line_3` | `string` | The third line of the address. | Optional. If provided, must be `>= 1` and `<= 255` characters. | `0..1` |
| `locality` | `string` | The locality of the address. This may be, for example, a city or town. | Optional. If provided, must be `>= 1` and `<= 255` characters. | `0..1` |
| `region` | `string` | The region of the address. This could be a county (for the UK) or a state (for the US) for example. | Required for some countries, e.g. `US`, `CA`, `IE`, `AU`. If provided for a required country, Sorted will accept either official abbreviations or full names and will convert between values as required. For example, the values `AL` or `Alabama` would be accepted for the country `US`. | `0..1` |
| `postal_code` | `string` | The postal code / zip code of the address. | Required for countries with official postcode systems. The postcode provided must be in a valid format for the country provided. | `0..1` |
| `country_iso_code` | `string` | The ISO 3166 Alpha 2 code for the country of the location. | Required. The value provided must be exactly 2-characters and be a valid country ISO 3166 Alpha-2 code | `1` |
| `lat_long` | [`lat_long`](#latlong) | The latitude and longitude of the location, if known and applicable. | Optional. See Lat Long. | `1` |
| `reservation` | [`reservation`](#reservation) | Reserved for Sorted use. Sorted may populate this property where applicable, e.g. a known pick-up or collection reservation. | When creating a new resource, this property should not be populated. The property is reserved for Sorted's use and should only be populated by Sorted. | `0` |

</div>

### Address JSON Examples

The following example shows an `address` that utilises the `shipping_location_reference` property to reference a pre-existing shipping location address:

```json
{
    "address_type": "origin",
    "shipping_location_reference": "SLOC001"
}

```

The following example shows a complete address that does not use a `shipping_location_reference`:

```json
{
    "address_type": "destination",
    "shipping_location_reference": null,
    "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
    "contact": {
        "reference": "co_9953035290535460865888900000987",
        "title": "Mr",
        "first_name": "Steve",
        "last_name": "Kingston",
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
    "address_line_1": "Norbert Road",
    "address_line_2": "Bertwistle",
    "address_line_3": null,
    "locality": "Preston",
    "region": "Lancashire",
    "postal_code": "PR4 5LE",
    "country_iso_code": "GB",
    "lat_long": null
}

```

## Address Type

Indicates the type of an address. All addresses must include a valid type from this list.

> [!WARNING]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
|------ | ------------|
| `origin` | The `origin` of a `shipment` (i.e. where it is being shipped from) |
| `destination` | The final `destination` of a `shipment` (i.e. where it is being shipped to) |
| `return` | The address that a `shipment` should be returned to |
| `sender` | The address of the sender, if different to the `origin` |
| `recipient` | The address of the recipient, if different to the `destination` |
| `importer` | The address of the importer, if applicable |
| `billing` | The billing address, if different to the `destination` and `recipient` |

## Allocate Request

An `allocate_request` is used to request allocation of one or more `shipments` with a carrier. This object is intended for use when allowing Sorted's allocation engine to determine the most appropriate carrier based on:

- Configured allocation/shipment rules;
- Carrier availability for required shipping and delivery date(s); and
- The prices of each carrier service

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `shipments` | List of `string` | The reference(s) of `shipment(s)` to be allocated. | Required. At least one valid reference must be provided. A maximum of `100` `shipments` can be allocated at once using this method. This is to ensure the continued optimal performance of the Sorted platform. | `1.100` |
| `capabilities` | [`service_capabilities`](#service-capabilities) | Any specific capabilities that are required as part of the allocation. | Optional. See [`service_capabilities`](#service-capabilities). | `0..1` |

</div>

### Allocate Request JSON Example

An `allocate_request` is used to allocate one or more `shipments` using pre-configured shipping rules – Sorted's allocation engine will automatically determine the optimal service for allocation.

```json
{
    "shipments": [
        "sp_10014418679662051328667654221112",
        "sp_10014418692546953216098308745978",
        "sp_10014418701136887808093048987633",
        "sp_10014418709726822400232323009988"
    ]
}
```

## Allocate Result

An `allocate_result` is returned for all requests to allocate a `shipment`. The object contains details of the operation result, as well as details of the allocation or, in the case of a failed allocation, details of the allocation failure.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `state` | [`shipment_state`](#shipment-state) | The `state` of the `shipment` following the request to allocate. | `1` |
| `price` | [`price`](#price) | The `price` of the allocation with this carrier and service | `0..1` |
| `message` | `string` | A plain-text message describing the result of the allocation attempt. This should not be used for application logic - use `shipment_state` to determine the success of the operation. | `1` |
| `carrier` | [`carrier_details`](#carrier-details) | Details of the carrier and service for the allocation. In the case of a failed allocation, this property may be `null`. | `0..1` |
| `tracking_details` | [`tracking_details`](#tracking-details) | The details of tracking reference(s) for this allocation. The tracking reference(s) are issued by the carrier (or by Sorted according to the carrier's conventions) following a successful allocation. | `0..n` |
| `shipment_reference` | `string` | The reference of the `shipment` that this result relates to. | `1` |
| `_links` | List of [`link`](#link) | Lists any related resources such as labels or the `shipment` | `0..n` |
| `excluded_services` | List of [`excluded_service`](#excluded-service) | Details of active services within your account that could not provide a quote, including the reason(s). | `0..n` |
| `shipping_date` | [`date_range`](#date-range) | The shipping date range for this allocation, if applicable. | `0..1` |
| `expected_delivery_date` | [`date_range`](#date-range) | The expected delivery date range for this allocation, if applicable. | `0..1` |
| `paperless_documents` | [`paperless_documents`](#paperless-documents) | Provides details of how to handle paperless documents, if applicable | `0..1`
| `applicable_documents` | [`applicable_documents`](#applicable-documents) | Provides details of which documents (e.g. `cn22`) apply to the `shipment` | `0..n`

</div>

### Allocate Result JSON Example

An `allocate_result` is returned when a request is made to `allocate` a `shipment`. A list or array of `allocate_results` will be returned when a request is made to allocate multiple `shipments`.

```json
{
    "state": "Allocated",
    "price": {
        "net": 10.0,
        "gross": 12.0,
        "taxes": [
            {
                "rate": {
                    "reference": "gb_standard",
                    "country_iso_code": "GB",
                    "type": "standard",
                    "value": 0.2
                },
                "amount": 2.0
            }
        ],
        "currency": "GBP"
    },
    "message": "Shipment allocated successfully",
    "carrier": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
    },
    "shipment_reference": "sp_9233500258180005889777767900009",
    "tracking_details": {
        "shipment": {
            "reference": "sp_9233500258180005889777767900009",
            "tracking_references": [
                "DNK23098098"
            ],
            "_links": []
        },
        "contents": [
            {
                "reference": "sc_9233500258180006765777878909811",
                "tracking_references": [
                    "DNK23098099"
                ],
                "_links": []
            }
        ]
    },
    "_links": [
        {
            "href": "https://api.sorted.com/pro/labels/sp_9233500258180005889777767900009/pdf",
            "rel": "PDF",
            "reference": null,
            "type": "Label"
        },
        {
            "href": "https://api.sorted.com/pro/labels/sp_9233500258180005889777767900009/zpl",
            "rel": "ZPL",
            "reference": null,
            "type": "Label"
        },
        {
            "href": "https://api.sorted.com/pro/shipments/sp_9233500258180005889777767900009",
            "rel": "Shipment",
            "reference": "sp_9233500258180005889777767900009",
            "type": "Shipment"
        }
    ]
}
```

## Allocate Shipments Result

An `allocate_shipments_result` is returned when multiple `shipments` are allocated. The differs from a standard [`allocate_result`](#allocate-result) as this operation is asynchronous i.e. it is performed as a background task within SortedPRO.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `message` | `string` | A plain text message describing the result of the operation | `1` |
| `queued` | List of `string` | The references of the `shipments` that have been successfully queued for allocation | `0..n` |
| `rejected` | List of [`allocation_rejection`](#allocation-rejection) | Details of `shipments` that have been rejected for allocation. | `0..n` |
| `_links` | List of [`link`](#link) | Links to any relevant resources | `0..n` |

</div>

## Allocate with Carrier Service Request

The `allocate_with_carrier_service_request` is designed to facilitate allocating one or more `shipments` with a specific carrier service. The cheapest available option for that carrier service will automatically be selected using this method.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `shipments` | List of `string` | The reference(s) of the `shipment(s)` to be allocated. | Required. At least one valid reference must be provided. A maximum of `100` `shipments` can be allocated at once using this method. This is to ensure continued optimal performance of the Sorted platform. | `1..100` |
| `carrier_service_reference` | `string` | The reference of the carrier service to allocate the `shipments` with. | Required. Must be a valid reference for an existing `carrier_service` within your account | `1` |
| `capabilities` | [`service_capabilities`](#service-capabilities) | Any specific capabilities that are required as part of the allocation. | Optional. See [`service_capabilities`](#service-capabilities). | `0..1` |

</div>

### Allocate with Carrier Service Request JSON Example

An `allocate_with_carrier_service_request` is very similar to an `allocate_request`, but also include the `carrier_service` to allocate with:

```json
{
    "shipments": [
        "sp_10014418679662051328777876543332",
        "sp_10014418692546953216762537656534",
        "sp_10014418701136887808123998889990",
        "sp_10014418709726822400876827639994"
    ],
    "carrier_service_reference": "DDF_ND24"
}
```

## Allocate with Filters Request

The `allocate_with_filters_request` is designed to allow a flexible method for allocating `shipments`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `shipments` | List of `string` | The references of the `shipments` to be allocated. | Required. At least one valid reference must be provided. A maximum of `100` `shipments` can be allocated at once using this method. This is to ensure continued optimal performance of the Sorted platform. | `1..100` |
| `filters` | [`allocation_filters`](#allocation-filters) | A series of filters used to select one or more matching carrier services. | Required. See [`allocation_filters`](#allocation-filters). | `1` |

</div>

### Allocate with Filters Request JSON Example

An `allocate_with_filters_request` allows you to specify a number of filters in order to choose one or more candidate services to allocate a `shipment` with:

```json
{
    "shipments": [
        "sp_10014417580150423552888900098766",
        "sp_10014418692546953216788828723451",
        "sp_10014418701136887808987987374644",
        "sp_10014418709726822400897394782222"
    ],
    "filters": {
        "direction": "outbound",
        "tags": [
            "prime"
        ],
        "pickup": false,
        "drop_off": true
    }
}
```

## Allocate with Filters Result

An `allocate_with_filters_result` provides details of `shipments` identified and submitted for allocation by an [`allocate_with_filters_request`](#allocate-with-filters-request).

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | A unique reference for this result. | 1 |
| `shipments` | List of [`link`](#link) | Provides the references of (and links to) the `shipments` identified by the filters. Each `shipment` will have been submitted for allocation. | `0..n` |
| `message` | `string` | A plain-text message describing the result of the operation. | `1` |

</div>

### Allocate with Filters Result JSON Example

An `allocate_with_filters_result` is returned in response to an `allocate_with_filters_request`.

```json
{
    "reference": "af_10014418868640612352647583920000",
    "shipments": [
        {
            "rel": "shipment",
            "href": "https://api.sorted.com/pro/shipments/sp_10014419031849369600898767654443",
            "type": "shipment",
            "reference": " sp_10014419031849369600898767654443"
        },
        {
            "rel": "shipment",
            "href": "https://api.sorted.com/pro/shipments/sp_10014419031849369600898767654443",
            "type": "shipment",
            "reference": "sp_10014419031849369600898767654443"
        }
    ],
    "message": "Shipments queued for allocation successfully"
}
```

## Allocate with Service Group Request

The `allocate_with_service_group_request` is designed to facilitate allocating one or more `shipments` with a carrier from a specific service group. A `service_group` is a collection of one or more carrier services that you can configure. The cheapest available service in a group will automatically be selected using this method.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `shipments` | List of `string` | The reference(s) of the `shipment(s)` to be allocated. | Required. At least one valid reference must be provided. A maximum of `100` `shipments` can be allocated at once using this method. This is to ensure continued optimal performance of the Sorted platform. | `1..100` |
| `service_group` | `string` | The reference of the carrier service group to allocate the `shipments` with. | Required. Must be a valid reference for an existing `service_group` within your account | `1` |
| `capabilities` | [`service_capabilities`](#service-capabilities) | Any specific capabilities that are required as part of the allocation. | Optional. See [`service_capabilities`](#service-capabilities). | `0..1` |

</div>

### Allocate with Service Group JSON Example

An `allocate_with_service_group_request` includes both a list of `shipment` references and the reference of the `service_group` to allocate with:

```json
{
    "shipments": [
        "sp_10014418679662051328777876543233",
        "sp_10014418692546953216982387628936",
        "sp_10014418701136887808983479587874",
        "sp_10014418709726822400453450009232"
    ],
    "service_group ": "BAW_PREM_01"
}
```

## Allocation

The `allocation` object provides details of the active allocation for a `shipment`, if applicable. A `shipment` will only have an *active* allocation when the `shipment` has been allocated to a carrier service for delivery/collection. Any `shipment` that has not yet been allocated will have a `null` value for allocation.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `carrier` | [`carrier_details`](#carrier-details) | Details of the carrier and service to which this `allocation` is linked. | `1` |
| `allocation_date` | `ISO8601 Date Time` | The date and time at which this `allocation` was created. | `1` |
| `price` | [`price`](#price) | Details of the `price` for the `allocation`. | `1` |
| `tracking_references` | List of `string` | The tracking reference(s) assigned by the carrier for this `shipment`. Ordinarily, carriers will only ever assign a single reference. However, some carriers may assign multiple references. | `0..n` |
| `_links` | List of [`link`](#link) | Links to related resources, such as labels. | `0..n` |

</div>

### Allocation JSON Example

The `allocation` object provides details of which carrier and carrier service have been assigned to a `shipment`. The `price` of the service, the resulting `tracking_references` and the date and time of allocation are also included:

```json
"allocation": {
    "carrier": {
        "reference": "ABQ",
        "name": "ABQ Worldwide",
        "service_reference": "ABQ48",
        "service_name": "ABQ 48 Express"
    },
    "allocation_date": "2019-04-25T16:27:22+01:00",
    "price": {
        "net": 10.0,
        "gross": 12.0,
        "taxes": [
            {
                "rate": {
                    "reference": "gb_standard",
                    "country_iso_code": "GB",
                    "type": "standard",
                    "value": 0.2
                },
                "amount": 2.0
            }
        ],
        "currency": "GBP",
    },
    "tracking_references": [
        "TRK987987345"
    ],
    "_links": []
}
```

## Allocation Filters

The `allocation_filters` object is used to selectively pre-filter carrier services prior to executing an allocation.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `direction` | [`direction`](#direction) | The `direction` property of the carrier services to select. | Required. Must be a valid [`direction`](#direction). | `1` |
| `tags` | List of `string` | Filters carrier services to exclude any services that do not have a 100% tag match. All tags will be considered, and a service must have all the provided tags. | Optional. If provided, must contain `>= 1` and `<= 10` tags. | `0..10` |
| `pickup` | `boolean` | Indicates whether to include pick-up services or not (i.e. services where the consumer will collect the `shipment` from a location) | Optional. Will default to `false` if not provided. | `0..1` |
| `drop_off` | `boolean` | Indicates whether to include drop-off services or not (i.e. services where the consumer will receive the `shipment` to their location) | Optional. Will default to `true` if not provided. | `0..1` |

</div>

## Allocation Rejection

This object is returned as part of an [`allocate_shipments_result`](#allocate-shipments-result) when one or more `shipments` have been rejected for allocation. Rejection can occur for a number of reasons. For example, a `shipment` that is already in a `state` of allocated cannot be allocated.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `code` | `string` | The error code that indicates why the collection of `shipments` was rejected for allocation | `1` |
| `message` | `string` | A plain text message describing the error code | `1` |
| `references` | List of `string` | The list of shipment references that were rejected due to the specified code | `1..n` |

</div>

## API Error

This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `correlation_id` | `string` | A unique reference for this error. Customers can use this when reporting errors to Sorted, if applicable | `1` |
| `code` | `string` | A pre-defined code for this error. See [API Error Codes](./error-codes.md). | `1` |
| `message` | `string` | A plain text summary of the error. | `1` |
| `details` | List of [`api_error_message`](#api-error-message) | A collection of `api_error_messages` which provide further details of the error(s) if applicable. | `0..n` |
| `_links` | List of [`link`](#link) | Provides `links` to further relevant information of operations, if applicable. | `0..n` |

</div>

### API Error JSON Example

An `api_error` is returned when there was a problem with a request or operation:

```json
{
    "correlation_id": "6c4e6a77-feab-42ab-9d7b-f559dc1b90ca",
    "code": "validation_error",
    "message": "A provided property has an invalid format",
    "details": [
        {
            "property": "addresses[0].contact.contact_details.email",
            "code": "invalid_format",
            "message": "'test@something' is not a valid email address"
        }
    ],
    "_links": null
}
```

## API Error Message

The `api_error_message` object provides further information relating to errors.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `property` | `string` | The path to the affected property, if applicable. | `0..1` |
| `code` | `string` | A pre-defined code for this error. See [API Error Codes](./error-codes.md). | `1` |
| `message` | `string` | A plain text summary of the error. | `1` |

</div>

## Applicable Documents

This object informs API users of `documents` that apply to a particular `shipment` or `quote`.

For example, when retrieving a `quote` for a `shipment` originating in the `GB` and being sent to `US`, one or more customs documents are likely to apply. This property allows users to understand documentation requirements in advance.

> [!TIP]
> The `applicable` property is included to allow Sorted to return "negative" responses if required. For instance, we might wish to specify that a specific document is **not** required in paperless trade scenarios. This property allows us to explicitly inform that user that a specific `document` does not apply.

<div class="contract">

| Property     | Type                              | Description                                                        | Occurrence |
|--------------|-----------------------------------|--------------------------------------------------------------------|------------|
| `type`       | [`document_type`](#document-type) | The `type` of document that applies, e.g. `CN22`                   | `1`        |
| `applicable` | `bool`                            | Indicates whether or not the specified `type` of document applies. | `1`        |

</div>

## Application Type

The `application_type` identifies how a surcharge value is applied when calculating the price of the service for a `shipment`.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `none` | This is a default value provided in situations where there is no application of this surcharge. This value will not normally used but is included in the data contract to allow for situations where unusual or unexpected behaviour occurs when calculating surcharge values. |
| `standard` | This is a standard surcharge. |
| `retrospective` | The surcharge value applies retrospectively. |

## Base Application

The `base_application` object provides details of whether the value of a [`surcharge`](#surcharge) applies to the base price and, if so, whether it applies to the base price only or the base price and the combined value of other applicable surcharges.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `base` | `boolean` | Indicates whether this surcharge applies to the `base` cost. | `1` |
| `base_only` | `boolean` | Indicates whether this surcharge applies to the `base` cost only. This should never be `true` if `base` is `false`. | `1` |

</div>

## Calculation Model

The `calculation_model` determines the model for how the value of a [`surcharge`](#surcharge) is calculated.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `fixed` | The value is fixed at a particular value, regardless of the overall value of the quote. |
| `calculated` | The value is calculated based on the other factors in the surcharge and does not have a specific or fixed value. |

## Carrier Details

The `carrier_details` object provides details of a carrier and carrier service and is usually (but not always) linked to an `allocation`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | The Sorted reference for this carrier | Optional. If not provided in a request, `service_reference` must be provided. Will be provided in responses. | `0..1` |
| `name` | `string` | The name of this carrier | Optional. Will be provided in responses but is not required in requests. | `0..1` |
| `service_reference` | `string` | The Sorted reference for this carrier service. Customers will have a `service_reference` per account. | Optional. If not provided in a request, `reference` must be provided. Will be provided in responses. | `0..1` |
| `service_name` | `string` | The friendly name for this carrier service | Optional. Will be provided in responses but is not required in requests | `0..1` |
| `tags` | List of `string` | Any `tags` that apply to this carrier service | Optional. Will be provided in responses but it not applicable to requests | `0..n` |

</div>

## Category Type

The following values are permissible as `category_type` when populating the [`customs_documentation`](#customs-documentation) property of a `shipment`.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `commercial_sample` | The contents are a commercial sample |
| `gift` | The contents are a gift |
| `returned_goods` | The contents are returned goods |
| `documents` | The contents are documents |
| `other` | The contents are any other format not included above |

## Class Division Rules

These rules allow customers to express which `class_division` and `class_sub_division` codes are included or excluded for this `ruleset`.

> [!NOTE]
> One of `include` or `exclude` must be populated otherwise a 400 (Bad Request) should be returned.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `include` | List of [`class_division`](#class-division) | Class divisions to explicitly include (allow) | Optional. If provided, `exclude` must be `null` or empty. | `0..n` |
| `exclude` | List of [`class_division`](#class-division) | Class divisions to explicitly exclude (disallow) | Optional. If provided, `include` must be `null` or empty. | `0..n` |

</div>

## Class Division

This object holds details of an IATA class division and sub-divisions. This object is used as the class divisions and sub-divisions use a numeric scheme which does not make it simple to express a specific sub-division when multiple class divisions are provided.

> ![NOTE]
> If `class_sub_divisions` is not provided, the entire `class_division` will be used as either an `include` or `exclude` rule, as appropriate.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `class_division` | `string` | The class division of the goods according to the IATA standards e.g. `2` (Gas) | Required. Must be a valid [IATA](https://en.wikipedia.org/wiki/Dangerous_goods) class division. | `1` |
| `class_sub_divisions` | List of `string` | The sub-division(s) according to the IATA standards. E.g. `1` combined with a `class_division` of `1` results in an overall `class_division` of `2.1` (flammable gas) | Optional. If provided, must be a valid sub-division of the class provided in `class_division`. | `0..10` |

</div>

## Collection Note from Manifest Request

The `collection_note_from_manifest_request` is used to obtain a collection note for all `shipments` in the provided manifest(s), regardless of the `state` of the `shipments`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `manifests` | List of `string` | The references of the manifest(s) to obtain a collection note for | Required. Must contain at least one manifest reference | `1..10` |

</div>

## Collection Note Query Request

The `collection_note_query_request` allows you to retrieve a collection note for `shipments` identified by a query. This is an alternative to using `shipment_groups` for customers who wish to operate in a more dynamic manner or who use identifiable address values.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `address` | [`address`](#address) | Allows you to identify `shipments` by their address. | Required. See [`address`](#address). | `1` |
| `carrier` | [`carrier_details`](#carrier-details) | Allows you to provide references to identify a carrier. | Required. See [`carrier_details`](#carrier-details). | `1` |
| `shipment_states` | List of [`shipment_state`](#shipment-state) | Identify one or more `states` to find matching `shipments`. | Required. Must contain at least one valid [`shipment_state`](#shipment-state). | `1..n` |
| `labels_printed` | `boolean` | Allows you to filter `shipments` by whether or not labels have been printed. | Optional. Will default to `null` if not provided. | `0..1` |
| `shipping_date` | [`date_range`](#date-range) | Allows you to filter by specific date/time windows. | Optional. If provided, the period must be within the same calendar day. If not provided, will default to the start of the current day to the current date and time (UTC). | `0..1` |

</div>

## Contact

An address must always include a `contact`, except when the address utilises a pre-defined shipping location (which already has a `contact` defined). When providing a `shipping_location_reference` you may exclude the `contact` property, in which case the address will inherit the `contact` from the shipping location. However, you may also provide a `shipping_location_reference` *and* a `contact`, in which case the provided `contact` will supersede the `contact` from the shipping location, for the specific `shipment` only.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
|----------|------|-------------|------------|:----------:|
| `reference` | `string` | Your own reference for this `contact`, if applicable. | If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `title` | `string` | The title or salutation of the `contact` (e.g. `Mr`, `Mrs`, `señor`) | If provided, must be `>= 1` and `<= 50` characters | `0..1` |
| `first_name` | `string` | The first name / forename of the `contact`. | Required. Must be `>= 1` and `<= 100` characters. | `1` |
| `last_name` | `string` | The last name / surname of the `contact`. | Required. Must be `>= 1` and `<= 100` characters. | `1` |
| `middle_name` | `string` | The middle name(s) of the `contact`, if applicable | Optional. If provided, must be `>= 1` and `<= 100` characters. | `0..1` |
| `position` | `string` | The position / job title of the `contact`, if applicable. | Optional. If provided, must be `>= 1` and `<= 100` characters. | `0..1` |
| `contact_details` | [`contact_details`](#contact-details) | The details used to contact the person. | Required. See [`contact_details`](#contact-details). | `1` |

</div>

## Contact Details

The `contact_details` object is used to capture details used to contact a person, such as telephone number(s) or email address.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
|----------|------|-------------|------------|:----------:|
| `landline` | `string` | The landline telephone number of the `contact`. | Optional. At least one of landline or mobile must be provided. If provided, must be `>= 1` and `<= 100` characters. | `0..1` |
| `mobile` | `string` | The mobile telephone number of the `contact`. | Optional. At least one of landline or mobile must be provided. If provided, must be `>= 1` and `<= 100` characters. | `0..1` |
| `email` | `string` | The email address of the `contact`. | Required. Must be a valid format of email address. Maximum length of email is `255` characters. | `1` |

</div>

## Content Type

The following table lists the content types supported in Sorted:

| Value | Description |
|------ | ------------|
| `application/pdf` | The document is a `PDF` |
| `text/plain` | The document is in plain text. This includes `ZPL` documents |

## Contents Tracking Event

A `contents_tracking_event` is a wrapper around standard [`tracking_events`](#tracking-event), and includes details of the [`shipment_contents`](#shipment-contents) that the event(s) relate to.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference of the [`shipment_contents`](#shipment-contents) that these events relate to | `1` |
| `custom_reference` | `string` | The customer's own `custom_reference` for the [`shipment_contents`](#shipment-contents), if applicable | `0..1` |
| `carrier_references` | List of `string` | The tracking reference(s) provided by the carrier | `1..n` |
| `events` | List of [`tracking_event`](#tracking-event) | The tracking event(s) for this [`shipment_contents`](#shipment-contents) | `0..n` |

</div>

## Create Dangerous Goods Ruleset

This object is used to create a new dangerous goods `ruleset`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `description` | `string` | A user-provided description for this `ruleset`. |Required. The value must be `>= 5` and `<= 100` characters. | 1 |
| `active` | `boolean` | Determines whether or not this `ruleset` should be `active`. | Optional. If not provided, will default to `true`. | `0..1` |
| `validity` | [`date_range`](#date-range) | The validity of this `ruleset`, i.e. when the `ruleset` should apply. | Optional. If not provided, the `ruleset` will be effective immediately and will be effective until deleted or a validity period is added. | `0..1` |
| `rules` | [`dangerous_goods_rules`](#dangerous-goods-rules) | The rules that apply. | Required. See [`dangerous_goods_rules`](#dangerous-goods-rules). | `1` |

</div>

## Create Shipment Request

A `shipment` is a collection of one or more packages sent together from a single `origin` address to a single `destination` address. A `create_shipment_request` is used to create a new `shipment` or to create quotes for a `shipment` that does not yet exist in SortedPRO.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `custom_reference` | `string` | Custom reference provided by the customer | Optional. If provided, limited to 50 characters. | `0..1` |
| `required_delivery_date` | [`date_range`](#date-range) | A date range used to specify the required delivery date | Optional. | `0..1` |
| `required_shipping_date` | [`date_range`](#date-range) | A date range used to specify the required shipping date | Optional. | `0..1` |
| `tags` | List of `string` | Custom `tags` to apply to the shipment. | Optional. If provided, each `tag` is limited to 50 characters and there is a limit of 10 `tags` per `shipment`. | `0..10` |
| `order_date` | `ISO8601 DateTime` | The date that the items in the `shipment` were ordered. This can be used to track `shipments` vs. order dates in customers' own systems. | Optional. If provided, must be a valid ISO8601 date time including offset. Sorted will not validate the logic of the date compared to other relevant dates. | `0..1` |
| `metadata` | List of [`metadata`](#metadata) | Additional properties to apply to a `shipment`. Additional functionality can be linked to properties specified in `metadata`. | Optional. A maximum of 10 `metadata` values can be provided per `shipment`. | `0..10` |
| `customs_documentation` | [`customs_documentation`](#customs-documentation) | Properties used to generate customs document(s) for this `shipment`. | Optional. | `0..1` |
| `direction` | [`direction`](#direction) | Indicates the `direction` of the `shipment`. | Optional. Will default to `outbound` if not specified. | `0..1` |
| `shipment_type` | [`shipment_type`](#shipment-type) | Indicates the type of `shipment`. | Required. See [`shipment_type`](#shipment-type) | `1` |
| `contents` | List of [`shipment_contents`](#shipment-contents) | The contents of the `shipment`. | At least one `shipment_contents` required. | `1..n` |
| `addresses` | List of [`address`](#address) | The addresses for this `shipment`. | Required. Must contain at least an `origin` and `destination` address. | `2..n` |
| `label_properties` | List of [`label_property`](#label-property) | Values to be used in the generation or decoration of labels. | Optional. | `0..10` |
| `source` | `string` | Indicates the source of the `shipment`. | Optional. If not provided, will default to `api`. If provided, maximum length is 50 characters. | `0..1` |
| `tenant` | `string` | Indicates the tenant that the `shipment` belongs to | Optional. If provided, must be a valid pre-existing `tenant` reference for the customer | `0..1` |
| `channel` | `string` | Indicates the channel for the `shipment`. | Optional. If provided, must be a valid pre-existing `channel` for the provided `tenant`. Must **only** be provided when `tenant` is provided. | `0..1` |

</div>

### Create Shipment Request JSON Example

The following example shows a fully-populated `create_shipment_request` in `JSON`:

```json
{
    "custom_reference": "0af07451-cf80-43cb-af24-acdfdbd41a14",
    "required_delivery_date": {
        "start": "2019-04-27T07:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "required_shipping_date": {
        "start": "2019-04-26T00:00:00+01:00",
        "end": "2019-04-26T23:59:59+01:00"
    },
    "tags": [
        "b&w",
        "T2"
    ],
    "order_date": "2019-04-05T09:34:55+01:00",
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string"
        },
        {
            "key": "refundable",
            "value": "false",
            "type": "boolean"
        }
    ],
    "customs_documentation": {
        "designated_person_responsible": "John McBride",
        "importers_vat_number": "0234555",
        "category_type": "gift",
        "shippers_customs_reference": "CREF0001",
        "importers_tax_code": "TC001",
        "importers_telephone": "+441772611444",
        "importers_fax": null,
        "importers_email": "jmcb@tilda.net",
        "cn23_comments": "Some comments here",
        "attached_invoice_references": [
            "63bc2ad5-dbff-4d30-a9b2-8081607d9921"
        ],
        "attached_certificate_references": [
            "bbc0eaa5-1a1d-4b56-b33a-a360680c1270"
        ],
        "attached_licence_references": [
            "0e5084d6-6509-4ff3-9771-66e63f452eb9"
        ],
        "category_type_explanation": "Free text",
        "declaration_date": "2019-04-26T14:57:54+01:00",
        "reason_for_export": "sale",
        "shipping_terms": "fca",
        "shippers_vat_number": "98798273434",
        "receivers_tax_code": "TC8793847",
        "receivers_vat_number": "9879879878675",
        "invoice_date": "2019-04-26T15:01:45+01:00"
    },
    "direction": "outbound",
    "shipment_type": "on_demand",
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
            "country_of_origin": "PO",
            "harmonisation_code": "09.02.10",
            "quantity": 2,
            "unit": "Box",
            "dangerous_goods": {
                "hazard_classes": [
                    { "code": "2.1" }
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
            "shipping_location_reference": null,
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865000098664453",
                "title": "Mr",
                "first_name": "Steve",
                "last_name": "Kingston",
                "middle_name": null,
                "position": null,
                "contact_details": {
                    "landline": null,
                    "mobile": "+447495747987",
                    "email": "steve@kingston.com"
                }
            },
            "company_name": null,
            "property_number": "8",
            "property_name": null,
            "address_line_1": "Norbert Road",
            "address_line_2": "Bertwistle",
            "address_line_3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ],
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ],
    "source": "WMS",
    "tenant": "TENANT_001",
    "channel": "CHAN_003"
}
```

## Create Shipment Group Request

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `shipments` | List of `string` | The reference(s) of the `shipment(s)` to be added to the group | Required. Must contain at least one valid `shipment` reference. All references included must be valid existing `shipment` references. All `shipments` must be in a valid `state` | `1..10,000` |
| `custom_reference` | `string` | The customer's own reference for this [`shipment_group`](#shipment-group) | Optional. If provided, length must be `>= 5` and `<= 50` characters. The reference must be unique within your account for open `shipment_groups` – you cannot have multiple open `shipment_groups` with the same `custom_reference` | `0..1` |

</div>

### Create Shipment Group JSON Example

A `create_shipment_group_request` is used to create a new `shipment_group`.

This example creates a new `shipment_group` with a `custom_reference` and 2 `shipments`:

```json
{
    "shipments": [
        "sp_00013473827456470532303387361290",
        "sp_09830498509887687644434677889098"
    ],
    "custom_reference": "5988920e-4609-4658-ae97-11f44ea14c6f"
}
```

## Customs Documentation

Customs documentation details can be provided when creating `shipments` for which customs document(s) will be required. This information should be created prior to allocation for documents to be generated successfully.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `designated_person_responsible` | `string` | The name of the person responsible for the `shipment` of the contents. | Optional. If provided, must be between `<= 100` characters. | `0..1` |
| `importers_vat_number` | `string` | The VAT number of the importer, if applicable. | Optional. If provided, must be `<= 50` characters. | `0..1` |
| `category_type` | [`category_type`](#category-type) | Indicates the category of goods for customs purposes. | Required. Must be a valid [`category_type`](#category-type). | `1` |
| `category_type_explanation` | `string` | Free text explanation indicating the reason for the selection of the [`category_type`](#category-type). | Optional. If provided, must be `<= 100` characters. | `0..1` |
| `shippers_customs_reference` | `string` | The shipper's customs reference, if known. | Optional. If provided, must be `<= 50` characters. | `0..1` |
| `importers_tax_code` | `string` | The importer's tax code, if known. | Optional. If provided, must be `<= 25` characters. | `0..1` |
| `importers_telephone` | `string` | The importer's telephone number, if known. | Optional. If provided, must be `<= 25` characters. | `0..1` |
| `importers_fax` | `string` | The importer’s fax number, if known. | Optional. If provided, must be `<= 25` characters. | `0..1` |
| `importers_email` | `string` | The importer’s email address, if known. | Optional. If provided, must be `<= 100` characters. | `0..1` |
| `invoice_number` | `string` | The invoice number, if applicable | Optional. If provided, must be `<= 50` characters | `0..1` |
| `office_of_origin` | `string` | The office of origin (Madrid Protocol) if applicable | Optional. If provided, must be `<= 50` characters | `0..1` |
| `cn23_comments` | `string` | Comments used to populate section 11 of CN23 customs documentation. | Optional. If provided, must be `<= 500` characters. | `0..1` |
| `attached_invoice_references` | List of `string` | A list of 0 or more attached invoice references. | Optional. If provided, each reference must be `<= 50` characters. | `0..20` |
| `attached_certificate_references` | List of `string` | A list of 0 or more attached certificate references. | Optional. If provided, each reference must be `<= 50` characters. | `0..20` |
| `attached_licence_references` | List of `string` | A list of 0 or more attached licence references. | Optional. If provided, each reference must be `<= 50` characters. | `0..20` |
| `declaration_date` | `ISO8601 Date Time` | The date and time of the declaration. | Optional. If not provided, this will default to the date and time at which the shipment is created. | `0..1` |
| `reason_for_export` | `string` | The reason for the export of the goods contained in the shipment. | Optional. If provided, must be `<= 100` characters. | `0..1` |
| `shippers_vat_number` | `string` | The shipper’s VAT number. | Optional. If provided, must be `<= 50` characters. | `0..1` |
| `receivers_tax_code` | `string` | The receiver’s tax code. | Optional. If provided, must be `<= 25` characters. | `0..1` |
| `receivers_vat_number` | `string` | The receiver’s VAT number | Optional. If provided, must be `<= 50` characters. | `0..1` |
| `invoice_date` | `ISO8601 Date Time` | The date and time of the invoice for the goods. | Optional. If not provided, will default to the date and time of the creation of the `shipment`. | `0..1` |
| `eori_number` | `string` | The sender's EORI number | Optional. If provided, must be `>= 1` and `<= 15` characters |

</div>

### Customs Documentation JSON Example

The following example shows a fully-populated `customs_documentation` example:

```json
{
    "customs_documentation": {
        "designated_person_responsible": "John McBride",
        "importers_vat_number": "0234555",
        "category_type": "gift",
        "shippers_customs_reference": "CREF0001",
        "importers_tax_code": "TC001",
        "importers_telephone": "+441772611444",
        "importers_fax": null,
        "importers_email": "jmcb@tilda.net",
        "cn23_comments": "Some comments here",
        "attached_invoice_references": ["63bc2ad5-dbff-4d30-a9b2-8081607d9921"],
        "attached_certificate_references": ["bbc0eaa5-1a1d-4b56-b33a-a360680c1270"],
        "attached_licence_references": ["0e5084d6-6509-4ff3-9771-66e63f452eb9"],
        "category_type_explanation": "Free text",
        "declaration_date": "2019-04-26T14:57:54+01:00",
        "reason_for_export": "Sale",
        "shipping_terms": "fca",
        "shippers_vat_number": "98798273434",
        "receivers_tax_code": "TC8793847",
        "receivers_vat_number": "9879879878675",
        "invoice_date": "2019-04-26T15:01:45+01:00",
        "eori_number": "GB1234567890000"
    }
}
```

## Dangerous Goods Rules

This object contains the rules that apply within a `ruleset`.

> [!WARNING]
> Although all properties in this object are optional, **at least one** property must be provided otherwise the request should be rejected.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `class_divisions` | [`class_division_rules`](#class-division-rules) | Rules that apply to class divisions. | Optional. See [`class_division_rules`](#class-division-rules). | `0..1` |
| `packing_groups` | `packing_group_rules` | Rules that apply to packing groups. | Optional. See [`packing_group_rules`](#packing-group-rules). | `0..1` |
| `physical_forms` | [`physical_form_rules`](#physical-form-rules) | Rules that apply to physical forms. | Optional. See [`physical_form_rules`](#physical-form-rules). | `0..1` |
| `radioactivity` | [`radioactivity_rules`](#radioactivity-rules) | Rules that apply to radioactivity. | Optional. See [`radioactivity_rules`](#radioactivity-rules). | `0..1` |
| `accessibility` | [`accessibility_rules`](#accessibility-rules) | Rules that apply to accessibility. | Optional. See [`accessibility_rules`](#accessibility-rules). | `0..1` |
| `harmonisation_codes` | [`harmonisation_rules`](#harmonisation-rules) | Rules that apply to harmonisation codes. | Optional. See [`harmonisation_rules`](#harmonisation-rules). | `0..1` |
| `quantity` | [`quantity_rules`](#quantity-rules) | Rules that apply to quantity. Optional. See [`quantity_rules`](#quantity-rules). | `0..1` |

</div>

## Dangerous Goods

The `dangerous_goods` object is used to provide details of dangerous or hazardous contents. Not all carriers will carry all goods and providing details of dangerous goods could preclude certain carriers from being able to quote for a specific `shipment`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `hazard_classes` | List of `hazard_class` | The IATA hazard classes assigned to the contents. | Optional. Each entry must be a valid `hazard_class`. | `0..` ||
| `packing_group` | [`packing_group`](#packing-group) | The [`packing_group`](#packing-group) for the contents. | Optional. If provided, must be a valid [`packing_group`](#packing-group). If not provided will default to `i` (high). | `0..1` |
| `id_number` | `string` | The UN code / ID code or NA code of the contents. | Optional. If provided, must be `>= 1` and `<= 50` characters | `0..1` |
| `proper_shipping_name` | `string` | The Proper Shipping Name for the goods. | Optional. If provided, must be `<= 255` characters. | `0..1` |
| `technical_name` | `string` | The Technical Name for the goods. | Optional. If provided, must be `<= 255` characters. | `0..1` |
| `physical_form` | [`physical_form`](#physical-form) | The [`physical_form`](#physical-form) of the goods. | Optional. If not provided, will default to `other`. If provided, must be a valid [`physical_form`](#physical-form). | `0..1` |
| `radioactivity` | [`radioactivity`](#radioactivity) | The [`radioactivity`](#radioactivity) of the goods. | Optional. If not provided, will default to `None`. If provided, must be a valid [`radioactivity`](#radioactivity). | `0..1` |
| `accessibility` | [`accessibility`](#accessibility) | The [`accessibility`](#accessibility) of the goods during transit. | Optional. If not provided, will default to `inaccessible`. If provided, must be a valid [`accessibility`](#accessibility). | `0..1` |
| `custom_label_text` | `string` | Custom text to be displayed on labels for these goods | Optional. If provided, must be `>= 1` and `<= 255` characters. | `0..1` |

</div>

### Dangerous Goods JSON Example

The following example shows `dangerous_goods` as `JSON`:

```json
{
    "dangerous_goods": {
        "hazard_classes": [
            { "code": "2.3A" },
            { "code": "7" }
        ],
        "packing_group": "iii",
        "id_number": "UN2202",
        "proper_shipping_name": "Hydrogen selenide, anhydrous",
        "technical_name": null,
        "physical_form": "gas",
        "radioactivity": "surface_reading",
        "accessibility": "accessible",
        "custom_label_text": "Route 87 Only"
    }
}
```

## Dangerous Goods Ruleset

This object is used to update and retrieve an existing dangerous goods `ruleset`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | The unique reference for this `ruleset` provided by Sorted. | Required. Must be a valid reference for an existing `ruleset`. | `1` |
| `description` | `string` | A user-provided description for this `ruleset`. | Required. The value must be `>= 5` and `<= 100` characters. | `1` |
| `validity` | [`date_range`](#date-range) | The validity of this `ruleset`, i.e. when the `ruleset` should apply | Optional. If not provided, the `ruleset` will be effective immediately and will be effective until deleted or a validity period is added. If a `ruleset` has an existing validity and no validity is provided on update, the existing validity should be removed. | `0..1` |
| `active` | `boolean` | Indicates whether the `ruleset` is `active` or not. | Optional. If not provided, will default to `true`. | `0..1` |
| `rules` | [`dangerous_goods_rules`](#dangerous-goods-rules) | The rules that apply | Required. See [`dangerous_goods_rules`](#dangerous-goods-rules). | `1` |
| `updated` | `ISO8601 Date Time` | The date that the `ruleset` was last updated. | Not applicable for updates. Set by Sorted as a result of an update operation. | `0` |
| `updated_by` | `string` | The identifier of the user that last updated the `ruleset`. | Not applicable for updates. Set by Sorted as a result of an update operation. | `0` |
| `created` | `ISO8601 Date Time` | The date that the `ruleset` was created. | Not applicable for updates. Set by Sorted as a result of a create operation. | `0` |
| `created_by` | `string` | The identifier of the user that created the `ruleset`. | Not applicable for updates. Set by Sorted as a result of a create operation. | `0` |
| `version` | `string` | The version of the `ruleset`. | Not applicable for updates. Set by Sorted as a result of a create or update operation. | `0` |
| `carrier_service_links` | List of `string` | The references of the carrier services this `ruleset` is linked to. | Not applicable for updates. | `0` |

</div>

## Dangerous Goods Ruleset Summary

This object provides a summary view of a dangerous goods `ruleset`.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this `ruleset` provided by Sorted. | `1` |
| `description` | `string` | The description for this `ruleset` set by the customer | `1` |
| `validity` | [`date_range`](#date-range) | The validity period for this `ruleset`, if applicable | `0..1` |
| `active` | `boolean` | Indicates whether this `ruleset` is `active` or not | `1` |
| `linked_carrier_services` | `integer` | The number of carrier services that this `ruleset` is linked to | `1` |

</div>

## Date Range

The `date_range` object is used to indicate a period of time. The object may include any combination of values:

- A `start` **and** `end` indicates a complete range of dates (inclusive)
- A `start` **only** indicates an open-ended date range, starting from a particular date (inclusive)
- An `end` **only** indicates a date range with a fixed endpoint (inclusive)

> [!NOTE]
> The property `has_value` was included during development of the Shipments MVP and was not originally part of the specification. However, we now have a customer actively using this data contract and the property can no longer be removed. This is a great example of the dangers of extending data types - it suddenly becomes a property we're stuck with, whether we like it or not.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `start` | `ISO8601 Date Time` | The start of the date period, inclusive. | Optional. If provided, must be prior to equal to the `end` | `0..1` |
| `end` | `ISO8601 Date Time` | The end of the date period, inclusive. | Optional. If provided, must be later than or equal to the `start` | `0..1` |
| `has_value` | `boolean` | Indicates whether the object has a value or not. | Not applicable to requests. | `1` |

</div>

### Date Range JSON Examples

The following example shows an open-ended `date_range` – i.e. the date range covers the period from the start to any point in the future:

```json
{
    "required_delivery_date": {
        "start": "2019-04-27T07:00:00+01:00",
        "end": null
    }
}
```

The following example shows a `date_range` with no fixed start, but a fixed end:

```json
{
    "required_delivery_date": {
        "start": null,
        "end": "2019-04-27T07:00:00+01:00"
    }
}
```

The following example shows a specific `date_range`, with a fixed start and end:

```json
{
    "required_delivery_date": {
        "start": "2019-04-26T00:00:00+01:00",
        "end": "2019-04-27T23:00:00+01:00"
    }
}
```

## Dimensions

The `dimensions` object is used to specify the dimensions of the contents of a `shipment`. The `dimensions` object contains both the individual dimensions and the unit of measurement.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `length` | `decimal` | The length in the specified units. | Required. Must be a valid positive decimal. Values are saved by SortedPRO with a precision of up to 5 decimal places. `Length` should be the **longest** of the three dimensions provided. **Sorted will re-arrange dimensions if your request does not follow this rule**. | `1` |
| `height` | `decimal` | The height in the specified units. | Required. Must be a valid positive decimal. | `1` |
| `width` | `decimal` | The height in the specified units. | Required. Must be a valid positive decimal. | `1` |
| `unit` | [`dimension_unit`](#dimension-unit) | The unit of measurement. | Required. Must be a valid [`dimension_unit`](#dimension-unit). **Note**: all units specified within a single `shipment` **must** be the same, i.e. customers *cannot* combine `dimension_unit` values within a single `shipment`. | 1 |

</div>

### Dimensions JSON Examples

The following example shows how `dimensions` can be defined in `JSON`:

```json
{
    "dimensions": {
        "unit": "cm",
        "width": 15.0,
        "height": 15.5,
        "length": 20.0
    }
}
```

By using an alternative `unit`, the `dimensions` can be expressed in inches:

```json
{
    "dimensions": {
        "unit": "in",
        "width": 5.91,
        "height": 6.10,
        "length": 7.874
    }
}
```

## Dimension Unit

Represents the dimension units recognised by SortedPRO.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `cm` | Centimetres |
| `in` | Inches |

## Direction

The `direction` property of a `shipment` indicates whether the `shipment` is intended to be sent to a consumer or received by a consumer.

Generally, a return will have a `direction` of `inbound` and all other `shipments` will have a `direction` of `outbound`.

If not provided, the `direction` property will always default to `outbound`.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
|------ | ------------|
| `outbound` | The `shipment` is sent to a consumer. This does not have to be a direct `shipment` – it is possible that the `shipment` is an `on_demand` `shipment` from a location not under the customer's control. |
| `inbound` | The `shipment` is intended to be sent by a consumer (e.g. the `shipment` is being returned) |

## Document

[!include[_document](includes/_document.md)]

## Document Type

The following table provides details of the `document_types` support in Sorted APIs:

| Value | Description |
|------ | ------------|
| `label` | The document is a shipping label |
| `cn22` | The document is a CN22 form. |
| `cn23` | The document is a CN23 form. |
| `commercial_invoice` | The document is a commercial invoice. |
| `collection_note` | The document is a collection note (driver's manifest) |
| `hazard_label` | The document relates to hazardous or dangerous goods |

## Excluded Service

The `excluded_service` object provides details of carrier services that were unable to provide quotes. There are many reasons why a carrier service may not be able to provide a quote for any given `shipment` and this object provides high-level details.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `carrier` | [`carrier_details`](#carrier-details) | Details of the carrier and service that this record relates to. | `1` |
| `exclusion` | [`exclusion`](#exclusion) | Details of the reason for exclusion. | `1` |

</div>

## Exclusion

The `exclusion` object provides details of the reasons for exclusion of a carrier or carrier service when generating quotes.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reason` | `string` | A plain text reason for the exclusion of this carrier or carrier service. | `1` |
| `code` | [`exclusion_code`](#exclusion-code) | A specific code identifying why a carrier or carrier service was unable to provide a quote. | `1` |

</div>

## Exclusion Code

The following table lists the current `exclusion_code` values available in Sorted.

| Value | Description |
|------ | ------------|
| `ex_availability` | The carrier reported that it does not have availability to carry the `shipment`. |
| `ex_rates` | The carrier does not have a configured rate for this `shipment`. |
| `ex_contents` | The carrier does not support the contents of the `shipment`. This could be due to dangerous or hazardous contents, for example. |
| `ex_weight` | The carrier does not support a `shipment` with the given weight. |
| `ex_dims` | The carrier does not support a `shipment` with the given dimensions. |
| `ex_rules` | The carrier has been excluded by your configured allocation rules. |
| `ex_timeout` | The carrier did not respond within a given request time out value. |
| `ex_circuit_open` | The circuit breaker for the carrier is in an open state. |
| `ex_error` | An error occurred when attempting to obtain a quote for this carrier. |
| `ex_sys_disabled` | The carrier has been disabled by the system. This can occur if, for instance, the carrier requests withdrawal of the carrier’s availability. |
| `ex_dangerous_goods` | The carrier service has been excluded by your configured dangerous goods rules. |
| `ex_tag` | The carrier service does not have the `tag(s)` specified for the `shipment`. |
| `ex_inactive` | The carrier service is not marked as `active` |
| `ex_other` | Any other exclusion reason not covered by this list will have a code of `ex_other`. |

## Harmonisation Rules

This object allows a customer to specify which harmonisation codes are explicitly included or excluded from this `ruleset`.

> [!NOTE]
> If no harmonisation rules are provided, then any harmonisation codes are permitted according to this `ruleset`.

> [!TIP]
> Harmonisation codes can be found at <https://unstats.un.org/unsd/tradekb/Knowledgebase/50018/Harmonized-Commodity-Description-and-Coding-Systems-HS>

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `include` | List of `string` | The harmonisation code(s) to include in this `ruleset` (allow) | Optional. If provided, must be a valid format of harmonisation code including dots, e.g. `90.02.10`. If `exclude` is provided, then `include` must be `null` or empty. | `0..n` |
| `exclude` | List of `string` | The harmonisation code(s) to exclude from this `ruleset` (disallow) | Optional. If provided, must be a valid format of harmonisation code including dots e.g. `09.02.10`. If `include` is provided, then `exclude` must be `null` or empty. | `0..n` |

</div>

## Hazard Class

The `hazard_class` object represents an IATA hazard class, for use in categorising dangerous goods.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `code` | `string` | A composite code identifying an IATA hazard class, eg. `2.3` (a toxic gas).<br>Codes can also be partial, eg. `3` (a flammable liquid) | Required. Must be a recognised IATA hazard class code. | `1` |

</div>

## Label Details

The `label_details` object provides details of label retrieval.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `date_first_retrieved` | `ISO8601 Date Time` | The date and time that the label for this allocation was first retrieved. | `0..1` |
| `retrieval_count` | `integer` | The number of times that the label for this allocation has been retrieved. | `1` |
| `_links` | List of [`link`](#link) | Links to retrieve the label(s) | `0..n` |

</div>

### Label Details JSON Example

The `label_details` object provides details of label retrieval such as how many times a label has been retrieved and when the label was first retrieved. The object may also include a `_links` property which includes a link to the label:

```json
{
    "label_details": {
        "date_first_retrieved": "2019-04-25T16:27:23+01:00",
        "retrieval_count": 1,
        "_links": [
            {
                "href": "https://api.sorted.com/pro/labels/sp_9953035299125395456888900009098/zpl",
                "rel": "label",
                "reference": null,
                "type": "label"
            }
        ]
    }
}
```

## Label Property

The `label_property` object is used to provide additional properties to be placed on a label. SortedPRO supports custom label decorators, which utilise additional label space to add fields and text. The `label_property` object is used to provide this information. The specific keys and values should be agreed between customers and account managers as part of the on-boarding process.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `key` | `string` | The `key` of the property – this is used to identify this specific property in any dependant logic. | Required. Must be `>= 1` and `<= 50` characters. There must only be one occurrence of each `key` within each `shipment` or `shipment_contents`. | `1` |
| `value` | `string` | The `value` of this property. | Required. Must be `>= 1` and `<= 500` characters. | `1` |

</div>

### Label Property JSON Example

The following example shows how `label_properties` can be populated:

```json
{
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ]
}
```

## LatLong

The `lat_long` property is used to capture the latitude and longitude of an address, if applicable. Although individual properties can be set to zero, `0,0` is **not** a valid value for the object.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `latitude` | `decimal` | The latitude value, e.g. `51.5014` | Required. Must be a valid latitude value. | `1` |
| `longitude` | `decimal` | The longitude value, e.g. `0.1246` | Required. Must be a valid longitude value. | `1` |

</div>

## Link

A `link` object provides a pointer to a resource. Links are provided, for example, following the creation of a new resource (such as a `shipment`). The `link` will provide access to the created resource.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `href` | `string` | The URL of the resource. | `1` |
| `rel` | `string` | A string representing the relationship of the linked resource to the current resource. For example, a link to a `shipment` will have a value of `shipment`. Links to the current object will have a `rel` of `self`. | `1` |
| `reference` | `string` | When a `link` is a pointer to a resource with a unique reference, this property will contain the reference. For instance, a `link` for a `shipment` will contain the `shipment's` reference in this field. | `0..1` |
| `type` | `string` | The type of resource that this `link` points to. See [`resource_type`](#resource-type). | `1` |

</div>

## Manifest

The `manifest` object contains details of a collection of `shipments` that were manifested in a single operation. This can be as a result of manifesting by query, manifesting by an explicit list of `shipment` references, or by an automatic manifest operation.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this manifest. | `1` |
| `shipments` | List of [`shipment_state_summary`] | Provides the `shipment` reference and current state of the `shipment`. | `1..n` |
| `created` | `ISO8601 Date Time` | The date and time that the manifest was created. | `1` |

</div>

## Manifest Query Request

A `manifest_query_request` is used when manifesting one or more `shipments` using a query. Rather than provide individual `shipment` references, the request uses various parameters to identify `shipments` that should be manifested.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `shipping_locations` | List of `string` | A list of shipping location references used to identify `shipments`. Only `shipments` originating from these location(s) will be selected. | Optional. If provided, must include valid existing shipping location references. If provided, must include at least 1 and no more than 10 shipping location references. | `0..10` |
| `address_custom_reference` | `string` | A specific address reference used to identify `shipments`. When creating `shipments`, you can specify an optional `custom_reference`. Only `shipments` originating from matching addresses will be selected. | Optional. If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `shipment_states` | List of [`shipment_state`](#shipment-state) | A list of [`shipment_state`](#shipment-state). Only `shipments` in these `states` will be selected. | Optional. If provided, must contain only valid [`shipment_state`](#shipment-state) and all [`shipment_state`](#shipment-state) must be eligible for manifesting. A maximum of 5 states can be provided. | `0..5` |
| `labels_retrieved` | `boolean` | If provided, will only match `shipments` where labels have been retrieved. If not provided, this property will be ignored, and `shipments` will be matched regardless of whether labels have been retrieved or not. | Optional. If not provided, will default to `null`. | `0..1` |
| `required_shipping_date` | [`date_range`](#date-range) | A [`date_range`](#date-range) used to filter `shipments` with a matching `required_shipping_date` property. If provided, all `shipments` where the `required_shipping_date` range of the `shipment` is *wholly* within the provided range will be selected. | Optional. | `0..1` |
| `carrier_reference` | `string` | The reference of the carrier to manifest with. | If `carrier_reference` and `carrier_service_reference` are both provided, they must be compatible. | `0..1` |
| `carrier_service_reference` | `string` | The reference of the carrier service to manifest with. | If `carrier_reference` and `carrier_service_reference` are both provided, they must be compatible. | `0..1` |

</div>

### Manifest Query Request JSON Example

A `manifest_query_request` is used to identify `shipments` to be manifested based on the provided criteria:

```json
{
    "shipping_locations": null,
    "address_custom_reference": "76dc0fd4-1788-48bf-978c-f8601411f9b1",
    "shipment_states": [
        "allocated"
    ],
    "labels_retrieved": true,
    "required_shipping_date": "2019-05-03T00:00:00+00:00"
}
```

## Manifest Request

A `manifest_request` is used to manually manifest one or more `shipments` that are in a valid `state` to be manifested with the carrier.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `shipments` | List of `string` | References of one or more `shipments` to manifest | Required. Must include 1 or more valid existing `shipment` references. A maximum of `100` `shipments` can be manifested at once using this method. | `1..100` |

</div>

### Manifest Request JSON Example

A `manifest_request` is used to request that one or more `shipments` should be manifested:

```json
{
    "shipments": [
        "sp_10014417511430946819000009890989",
        "sp_10014417515725914112653748572891",
        "sp_10014417515725914113647485930221"
    ]
}
```

## Manifest Response

A `manifest_response` is returned when a request is made to manifest one or more `shipments`. The `manifest_result` objects within the response will be grouped by carrier or carrier service.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `results` | List of [`manifest_result`](#manifest-result) | Details of the result of the manifest operation for each `shipment` in the request. | `1..n` |

</div>

### Manifest Response JSON Example

A `manifest_response` is sent in response to a `manifest_request` and provides details of the success, or otherwise, of the request to manifest `shipments`:

```json
{
    "manifest_results": [
        {
            "reference": " ma_10014418692546953216767678909876",
            "carrier": {
                "reference": "DNT",
                "name": "DNT International",
                "service_reference": "DNT_IP_24",
                "service_name": "DNT International Priority 24"
            },
            "message": "10 shipments queued for manifest successfully",
            "state": "manifesting",
            "shipment_count": 10,
            "_links": [
                {
                    "href": "https://https://api.sorted.com/pro/manifests/groups/ma_10014418692546953216767678909876",
                    "rel": "manifest"
                }
            ]
        }
    ]
}
```

## Manifest Result

A `manifest_result` provides details of the result of a manifest operation for a single `shipment`. Multiple `manifest_results` are returned as part of a [`manifest_response`](#manifest-response).

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | A unique reference for this manifest | 1 |
| `carrier` | [`carrier_details`](#carrier-details) | Provides details of the carrier and service that the shipment(s) were manifested or queued to be manifested with. | 1 |
| `message` | `string` | A plain-text message providing details of the result. | 1 |
| `state` | [`shipment_state`](#shipment-state) | The current `state` of the `shipment` as a result of the manifest operation. This will ordinarily be `manifesting`. | `1` |
| `shipment_count` | `int` | The number of `shipments` identified by the query. | `1` |
| `_links` | List of [`link`](#link) | A list of related resources, if applicable. | `0..n` |

</div>

## Metadata

`Metadata` is used in SortedPRO as a collection of properties that customers define, rather than fixed fields or properties defined by Sorted. SortedPRO may include functional extensions in the future that provide new functionality based on `metadata`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `key` | `string` | The `key` of this `metadata` item. | Required. Each `metadata` key must be unique within a `metadata` collection. The length of the `key` must be `>= 1` and `<= 50` characters. | `1` |
| `value` | `string` | The `value` of this `metadata` item. | Required. The length of the `value` must be `>=1` and `<= 100` characters. | `1` |
| `type` | [`metadata_type`](#metadata-type) | The `type` of this `metadata` item. | Optional. If not provided, will default to `string`. See [`metadata_type`](#metadata-type). | `1` |

</div>

### Metadata JSON Example

The following example shows how `metadata` can be used to add additional properties to a `shipment`:

> [!TIP]
> In this example there is a string property with the `key` "warehouse_id" and a custom `value`. There is also a `boolean` item with the `key` "refundable" which has a value of `false`. This object allows the storage of custom attributes for a `shipment` that might be used for logical decision-making in in the future.

```json
{
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string"
        },
        {
            "key": "refundable",
            "value": "false",
            "type": "boolean"
        }
    ]
}
```

## Metadata Type

This property is used to indicate the type of value provided with a particular `metadata` item. This may be used by future SortedPRO features to enable logic-based operations on provided `metadata`. If not provided, the value of `metadata_type` will default to `string`.

| Value | Description |
| ----- | ----------- |
| `string` | The `metadata` value is a `string`. The provided value must have a length `>= 1` and `<= 100`. No further validation will be performed on the provided value. |
| `bool` | The `metadata` value indicates a `boolean` value. The provided value must be one of `true | false`. The value can be provided in any case (e.g. `FALSE`, `false`, `False`) but will be converted to lowercase by SortedPRO when saved. |
| `date_time_offset` | The `metadata` value is an `ISO8601 Date Time` (including offset). The provided value will be validated to ensure that it is a valid `ISO8601 Date Time` value. |
| `integer` | The `metadata` value is an `integer`. The provided value will be validated to ensure that is it a valid `integer` between `-2,147,483,648` and `2,147,483,647` |
| `decimal` | The `metadata` value is a `decimal`. The provided value will be validated to ensure that it is a valid `decimal` number. |
| `url` | A URL provided as a `string`. |

## Operator

Relational operator used to determine how `value` should be applied when used in a [`quantity_rule`](#quantity-rules).

| Value | Description |
|------ | ------------|
| `==` | The quantity of items must be exactly equal to the value in the ruleset |
| `!=` | The quantity of items can be any value other than the value specified in the `ruleset` |
| `>` | The quantity of items must be greater than the value in the `ruleset` |
| `>=` | The quantity of items must be greater than or equal to the value in the `ruleset` |
| `<` | The quantity of items must be less than the value in the `ruleset` |
| `<=` | The quantity of items must be less than or equal to the value in the `ruleset` |

## Packing Group

Indicates the `packing_group` for dangerous goods purposes. The following values are accepted by SortedPRO.

| Value | Description |
|------ | ------------|
| `i` | High Danger |
| `ii` | Medium Danger |
| `iii` | Low Danger |

## Packing Group Rules

This object allows a customer to specify which packing groups should be included or excluded from a `ruleset`.

> [!NOTE]
> If no packing group rules are provided, then any packing group value is permitted according to this ruleset.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `include` | List of [`packing_group`](#packing-group) | The packing group(s) to include in this `ruleset` (allow) | Optional. If provided, must be a valid `packing_group`. If `exclude` is provided, then `include` must be `null` or empty. | `0..3` |
| `exclude` | List of [`packing_group`](#packing-group) | The packing group(s) to exclude from this `ruleset` (disallow) | Optional. If provided, must be a valid `packing_group`. If `include` is provided, then `exclude` must be `null` or empty. | `0..3` |

</div>

## Paperless Document

This object allows a customer to supply documents when creating `shipments`.

The intention of allowing customers to supply documents is to allow original copies of documents such as certificates of conformity to be supplied to carriers in a paperless trade flow.

> [!WARNING]
> Not all carriers support paperless trade

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `file_format` | [`paperless_file_format`](#paperless-file-format) | The format of file being uploaded | Required. Must be a valid [`paperless_file_format`](#paperless-file-format) | `1` |
| `document_type` | [`paperless_document_type`](#paperless-document-type) | The type of document being uploaded | Required. Must be a valid [`paperless_document_type`](#paperless-document-type) | `1` |
| `expiration` | `ISO8601 Date Time` | The date/time that the document expires, if applicable. | Optional. If provided, must be a value greater than the current date and time. **Note**: This is currently only supported by FedEx. | `0..1` |
| `file_content` | `string` | The contents of the file as a base64-encoded byte array. | Required. A maximum file size of 5MB is permitted. Any larger file must be rejected with a suitable validation error. | `1` |
| `usage` | [`paperless_document_usage`](#paperless-document-usage) | The intended usage of the document. | Optional. If provided must be a valid [`paperless_document_usage`](#paperless-document-usage) value. If not provided, should default to `electronic_trade` | `0..1` |

</div>

### Paperless Document JSON Example

This object allows a customer to supply documents that relate to existing `shipments`:

```json
{
  "file_format": "pdf",
  "document_type": "commercial_invoice",
  "expiration": "2021-09-01T06:00:00+00:00",
  "file_content": "XlhBCgpeRlggRGlzcGxheXMgY29ycmVjdGx5IGFzIDZ4NCBhdCAzMDBkcGkKXkNGMCw2MApeRk81MCw1MF5HQjEwMCwxMDAsMTAwXkZTCl5GTzc1LDc1XkZSXkdCMTAwLDEwMCwxMDBeRlMKXkZPODgsODheR0I1MCw1MCw1MF5GUwpeRk8yMjAsNTBeRkRFYXN0ZXIgU2hpcHBpbmcgQ28uXkZTCl5DRjAsNDAKXkZPMjIwLDEwMF5GRDEyMyBSYWJiaXQgTGFuZV5GUwpeRk8yMjAsMTM1XkZEU2hlbGJ5dmlsbGUgVE4gMzgxMDJeRlMKXkZPMjIwLDE3MF5GRFVuaXRlZCBTdGF0ZXMgKFVTQSleRlMKXkZPNTAsMjUwXkdCNzAwLDEsM15GUwoKXkNGQSwzMApeRk81MCwzMDBeRkRNYXJ5IE1hcnleRlMKXkZPNTAsMzQwXkZEMTAwIExpdHRsZSBMYW1iIFN0cmVldF5GUwpeRk81MCwzODBeRkRTcHJpbmdmaWVsZCBUTiAzOTAyMV5GUwpeRk81MCw0MjBeRkRVbml0ZWQgU3RhdGVzIChVU0EpXkZTCl5DRkEsMTUKXkZPNjAwLDMwMF5HQjE1MCwxNTAsM15GUwpeRk82MzgsMzQwXkZEUGVybWl0XkZTCl5GTzYzOCwzOTBeRkQ4ODg0NzReRlMKXkZPNTAsNTAwXkdCNzAwLDEsM15GUwoKXkJZNSwyLDI3MApeRk8xMDAsNTUwXkJDXkZEc3BfMTAwMTQ0MTg2OTI1NDY5NTMyMTZeRlMKCl5GTzUwLDkwMF5HQjgwMCwyNTAsM15GUwpeRk81MDAsOTAwXkdCMSwyNTAsM15GUwpeQ0YwLDQwCl5GTzEwMCw5NjBeRkRTaGlwcGluZyBDdHIuIFgzNEItMV5GUwpeRk8xMDAsMTAxMF5GRFJFRjEgRjAwQjQ3XkZTCl5GTzEwMCwxMDYwXkZEUkVGMiBCTDRIOF5GUwpeQ0YwLDE5MApeRk81NjAsOTY1XkZERkZeRlMKCl5YWg==",
  "usage": "electronic_trade"
}
```

## Paperless Document Type

The following types of paperless document are supported.

> [!TIP]
> This is not to be confused with [`paperless_file_format`](#paperless-file-format) which essentially denotes the *format* of the file (e.g. `pdf`)

| Value                         | Description                                                 |
|-------------------------------|-------------------------------------------------------------|
| `commercial_invoice`          | A commercial invoice document                               |
| `certificate_of_origin`       | A certificate of origin                                     |
| `nafta_certificate_of_origin` | A North American Free Trade Agreement certificate of origin |
| `pro_forma_invoice`           | A pro-forma invoice                                         |
| `authorisation_form`          | An authorisation form                                       |
| `export_document`             | An export document                                          |
| `export_licence`              | An export licence                                           |
| `import_permit`               | An import permit                                            |
| `power_of_attorney`           | A power of attorney document                                |
| `packing_list`                | A packing list                                              |
| `sed_document`                | A shipper's export (SED) document                           |
| `letter_of_instruction`       | A letter of instruction                                     |
| `customs_declaration`         | A customs declaration                                       |
| `air_waybill`                 | An air waybill                                              |
| `invoice`                     | An invoice                                                  |
| `other`                       | Any other type of document                                  |

## Paperless Document Usage

The following types of paperless document usage are supported:

> [!NOTE]
> Where a specific usage is not supported by a carrier, the user's value might be ignored.

| Value                  | Description                                                       |
|------------------------|-------------------------------------------------------------------|
| `electronic_trade`     | The document is used specifically for electronic/paperless trade  |
| `customer_information` | The document contains information relating to or for the customer |
| `pricing`              | The document contains pricing details or data                     |

## Paperless Documents

This object is returned as part of an [Allocate Result](#allocate-result) and indicates how Sorted have used any applicable paperless documents when allocating a `shipment` with a carrier.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `sent_to_carrier` | `bool` | Specifies whether or not the paperless documents were transmitted to the carrier. | `1` |
| `usage_type` | [`paperless_usage_type`](#paperless-usage-type) | Specifies how the result should be handled. | `1` |

</div>

## Paperless File Format

The following types of paperless file are supported:

| Value | Description                    |
|-------|--------------------------------|
| `pdf` | PDF (Portable Document Format) |
| `png` | PNG image                      |
| `jpg` | JPG/JPEG image                 |
| `gif` | GIF image                      |

## Paperless Usage Type

The following values specify how paperless file uploads should be handled following a successful allocation.

| Value                     | Description                                                                                            |
|---------------------------|--------------------------------------------------------------------------------------------------------|
| `electronic_only`         | The carrier supports electronic-only trade. I.e. there is no need to send physical copies              |
| `electronic_and_physical` | The carrier support electronic documents, but physical copies must accompany the `shipment(s)`         |
| `not_applicable`          | Paperless documents are not applicable for this `shipment` (e.g. the route does not require documents) |
| `not_supported`           | The carrier (or Sorted's integration with the carrier) does not support paperless documents            |

## Physical Form

Represents the physical form of the goods.

| Value    | Description                                            |
|----------|--------------------------------------------------------|
| `other`  | The goods are in a form not covered by any other value |
| `gas`    | The goods are in gas form                              |
| `liquid` | The goods are in liquid form                           |
| `solid`  | The goods are in solid form                            |

## Physical Form Rules

This object allows a customer to specify which physical forms of goods are explicitly included or excluded from a `ruleset`.

> [!NOTE]
> If no physical form rules are provided, then any physical group is permitted according to this ruleset.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `include` | List of [`physical_form`](#physical-form) | The physical form(s) to include in this `ruleset` (allow) | Optional. If provided, must be a valid `physical_form`. If `exclude` is provided, then `include` must be `null` or empty. | `0..4` |
| `exclude` | List of [`physical_form`](#physical-form) | The physical form(s) to exclude from this `ruleset` (disallow) | Optional. If provided, must be a valid `physical_form`. If `include` is provided, then `exclude` must be `null` or empty. | `0..4` |

</div>

## Price

The `price` object provides details of the net and gross price for a service, including currency and tax details.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `net` | `decimal` | The price for this service exclusive of tax, in the provided `currency` | `1` |
| `gross` | `decimal` | The price for this service inclusive of tax, in the provided `currency` | `1` |
| `taxes` | List of [`tax`](#tax) | The applicable `tax` for this `price`. | `0..n` |
| `currency` | `string` | The 3-character ISO code of the currency | `1` |

</div>

## Quantity Rules

> [!TIP]
> This contract applies to [dangerous_goods_rulesets](#dangerous-goods-rules) and is not a general allocation rule.

This object allows a customer to specify the number of "items" that are permitted in a `ruleset`. For example, if a customer wishes to ship with a specific carrier only when the number of items included within a `shipment` is greater than or equal to `10`, this rule can be utilised.

> [!NOTE]
> If no quantity rules are provided, then any quantity of goods is permitted according to this ruleset.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `operator` | `string` | The relation [`operator`](#operator) indicating how the `value` should be used. | Required. Must be a valid [`operator`](#operator). | `1` |
| `value` | `integer` | The `value` to be used in conjunction with the `operator` | Required. Must be a valid positive `integer`. | `1` |

</div>

## Quote

A `quote` contains details of the carrier and service that have been confirmed as being capable of handling the `shipment`.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | A unique reference for this specific `quote`. This is used when allocating with a `quote`. | `1` |
| `shipment_reference` | `string` | The reference of the `shipment` that this `quote` relates to. It is not possible to allocate a `shipment` with a quote for another `shipment`. | `1` |
| `carrier` | [`carrier_details`](#carrier-details) | Details of the carrier and carrier service for this `quote`. | `1` |
| `collection_date` | [`date_range`](#date-range) | The date and time that collection of this `shipment` will take place. See Date Range. | `1` |
| `delivery_date` | [`date_range`](#date-range) | The date and time that the `shipment` will be delivered. See Date Range. | `1` |
| `price` | [`price`](#price) | The [`price`](#price) for this `quote`. | 1 |
| `surcharges` | List of [`surcharge`](#surcharge) | Details of any applicable [`surcharge(s)`](#surcharge) for this `quote`. | `0..n` |
| `created` | `ISO8601 Date Time` | The date and time that this `quote` was created. | `1` |
| `expires` | `ISO8601 Date Time` | The date and time that this `quote` expires. Once a quote has expired, it can no longer be used for allocation. | `1` |
| `applicable_documents` | List of [`applicable_document`](#applicable-documents) | Provides details of which documents (e.g. `cn22`) apply to the `shipment` | `0..n` |
| `_links` | List of [`link`](#link) | Links to any other related resources. | `1` |

</div>

## Quote Result

A `quote_result` is returned when you request `quotes` for a `shipment`. Each `quote` includes a unique reference which can be used to allocate a `shipment` with the `quote` at a later stage.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | A unique reference for this collection of `quotes`. | `1` |
| `message` | `string` | A plain-text message providing a summary of the results. | `1` |
| `shipment` | [`shipment_summary`](#shipment-summary) | A summary version of the `shipment` relating to this `quote`. | `1` |
| `quotes` | List of [`quote`](#quote) | Details of the carrier, service, and [`price`](#price) for this `quote`. | `0..n` |
| `excluded_services` | List of [`excluded_services`](#excluded-service) | Details of active services within the customer's account that could not provide a `quote`, including reasons. | `0..n` |

</div>

### Quote Result JSON Example

A `quote_result` is returned in response to a `quote_request`:

```json
{
    "reference": "qr_10014418679662051328888909056211",
    "message": "Quote for sp_10014418868640612447876776802355",
    "shipment": {
        "reference": "sp_10014418868640612447876776802355",
        "addresses": [
            {
                "address_type": "origin",
                "shipping_location_reference": "SLOC001"
            },
            {
                "address_type": "destination",
                "shipping_location_reference": null,
                "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
                "contact": {
                    "reference": "co_99530352905354608658788999097654",
                    "title": "Mr",
                    "first_name": "Steve",
                    "last_name": "Kingston",
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
                "address_line_1": "Norbert Road",
                "address_line_2": "Bertwistle",
                "address_line_3": null,
                "locality": "Preston",
                "region": "Lancashire",
                "postal_code": "PR4 5LE",
                "country_iso_code": "GB",
                "lat_long": null
            }
        ],
        "custom_reference": "f81aa086-f2c8-4e85-b7ac-b9ada6442f95",
        "_links": [
            {
                "rel": "shipment",
                "href": "https://api.sorted.com/pro/shipments/sp_10014418868640612447876776802355",
                "reference": "sp_10014418868640612447876776802355",
                "type": "shipment"
            }
        ]
    },
    "quotes": [
        {
            "reference": "qu_10014418868640618745676788980009",
            "shipment_reference": "sp_10014418868640612447445456769801",
            "carrier": {
                "reference": "NQT",
                "name": "NQT Super",
                "service_reference": "NQTXPR",
                "service_name": "NQT Super Express"
            },
            "collection_date": {
                "start": "2019-05-03T08:42:32+01:00",
                "end": "2019-05-03T08:42:38+01:00"
            },
            "delivery_date": {
                "start": "2019-05-03T08:32:39+01:00",
                "end": "2019-05-03T08:32:45+01:00"
            },
            "price": {
                "net": 10.0,
                "gross": 12.0,
                "taxes": [
                    {
                        "rate": {
                            "reference": "gb_standard",
                            "country_iso_code": "GB",
                            "type": "standard",
                            "value": 0.2
                        },
                        "amount": 2.0
                    }
                ]
            },
            "surcharges": null,
            "created": "2019-05-03T08:34:50+01:00",
            "expires": "2019-05-03T08:35:01+01:00",
            "applicable_documents": [
                {
                  "type": "cn22",
                  "applicable": true
                }
            ],
            "_links": null
        }
    ],
    "excluded_services": [
        {
            "carrier": {
                "reference": "NQT",
                "name": "NQT Slow",
                "service_reference": "NQTSLW",
                "service_name": "NQT Slow Express"
            },
            "exclusion": {
                "reason": "The carrier service has no availability that satisfies the selected date(s)",
                "code": "ex_availability"
            }
        }
    ]
}
```

## Radioactivity

Represents the radioactivity level of the goods.

| Value | Description |
|------ | ------------|
| `none` | The goods are not radioactive |
| `surface_reading` | The goods have a surface reading of radioactivity |
| `transport_index` | The goods are assigned a value of radioactivity according to the Transport Index |
| `criticality_safety_index` | The goods are assigned a value of radioactivity according to the Criticality Safety Index |

## Radioactivity Rules

This object allows a customer to specify which type(s) of radioactive goods are explicitly included or excluded from this `ruleset`.

> [!NOTE]
> If no radioactivity rules are provided, then any form of radioactive goods are permitted according to this ruleset.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `include` | List of [`radioactivity`](#radioactivity) | The radioactivity value(s) to include in this `ruleset` (allow) | Optional. If provided, must be a valid `radioactivity`. If `exclude` is provided, then `include` must be `null` or empty. | `0..4` |
| `exclude` | List of [`radioactivity`](#radioactivity) | The radioactivity value(s) to exclude from this `ruleset` (disallow) | Optional. If provided, must be a valid `radioactivity`. If `include` is provided, then `exclude` must be `null` or empty. | `0..4` |

</div>

## Reservation

The reservation object is used to provide details of reservations such as those for click and collect options. For customers who obtain their own click and collect reservations, these details can be provided when creating a `shipment` as part of the address property. Where such a reservation is obtained by Sorted, the relevant address property of the `shipment` will be updated by Sorted.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | The unique reference generated by Sorted for this reservation | Optional. Not applicable for requests to create `shipments`. | `0..1` |
| `location_reference` | `string` | The reference of the location to which this reservation applies | Optional. | `0..1` |
| `booking_reference` | `string` | The reference of the booking for this reservation, if applicable. | Optional. | `0..1` |
| `external_reference` | `string` | An external reference for this reservation. For example, a reservation reference generated by a carrier. | Optional. | `0..1` |
| `carrier` | [`carrier_details`](#carrier-details) | Details of the carrier that this reservation applies to. | Optional. If the reservation is provided as part of the request to link to an existing external click and collect order, carrier details are required. | `0..1` |

</div>

### Reservation JSON Example

A `reservation` object provides details of a `reservation`. This usually relates to a specific pick-up location for a `shipment` (i.e. the location from which the recipient of the `shipment` will collect it):

```json
{
    "reservation": {
        "reference": "rs_9953035320600231936000987899097",
        "location_reference": "8BDSF43555",
        "external_reference": "d6bc18f4-1d48-45fb-9586-8111db7ab827"
    }
}
```

## Resource Result

A `resource_result` is generally returned for all successful requests to create or modify resources.

> [!NOTE]
> This object also includes some optional properties such as `errors` and `version`. These properties should be completely excluded from the response when serialising if they are `null` as the properties do not apply to all types of resource.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this resource generated by Sorted at the point of creation. | `1` |
| `custom_reference` | `string` | Your own custom reference for this object, if applicable. | `0..1` |
| `message` | `string` | An optional message relating to the result of the operation. | `0..1` |
| `errors` | List of [`api_error_message`](#api-error-message) | Any error(s) relating to the operation | `0..n` |
| `version` | `integer` | An optional `version` for this resource | `0..1` |
| `_links` | List of [`link`](#link) | Links to the current resource and any related resources, if applicable. | `1..n` |

</div>

### Resource Result JSON Example

A `resource_result` is returned when a resource is created or modified:

```json
{
    "reference": "sp_10014417580150423552888900098766",
    "custom_reference": "6c8f8e21-bc4a-438d-8e48-85f6b4a65bcc",
    "message": "Shipment sp_10014417580150423552888900098766 created successfully",
    "_links": [
        {
            "rel": "shipment",
            "href": "https://api.sorted.com/pro/shipments/sp_10014417580150423552888900098766",
            "type": "shipment",
            "reference": "sp_10014417580150423552888900098766"
        }
    ]
}
```

This object can also contain additional properties, such as errors, if there is a mixed status response. If there are no errors in a response, the errors property will be `null` or excluded completely:

```json
{
    "reference": "sg_00013464648946915264789208891778",
    "custom_reference": "TRAILER_XPD0092",
    "version": 79,
    "message": "Shipment group created successfully",
    "errors": [
        {
            "property": "shipments",
            "code": "invalid_reference_format",
            "message": "{ref} is not a valid shipment reference"
        }
    ],
    "_links": [] //omitted for brevity
}

```

## Resource Type

The following resource types are currently supported in Sorted's APIs:

> [!NOTE]
> This list may be extended at any time. Existing resource types may **not** be changed.

| Value | Description |
|------ | ------------|
| `shipment` | The `link` points to a `shipment` |
| `label` | The `link` points to a `label` |
| `customs_documents` | The `link` points to `customs_documents` |
| `document` | The `link` points to a `document` |
| `self` | The `link` points to the containing object |
| `paperless_document` | The `link` points to a [`paperless_document`](#paperless-document) |
| `other` | The `link` points to something else |

## Service Capabilities

This object is used to provide details of specific capabilities that a carrier service should have in order to be allocated with.

> [!NOTE]
> This object is designed to allow the allocation to be decoupled from the creation of the [`shipment`](#shipment).

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `type` | `string` | The `type` of [`service_capability`](#service-capability) | Required. Must be a valid [`service_capability`](#service-capability) `type` | `1` |
| `value` | `string` | The `value` for the provided `type`. | Required. Must be a valid [`service_capability`](#service-capability) `value` | `1` |

</div>

## Service Capability

This section lists the supported capabilities, including the supported types and configuration options.

### Proof of Delivery

The `proof_of_delivery` service capability has the following permitted `values`:

| Value | Description |
| ----- | ----------- |
| `require` | Will only allocate with a carrier service that has proof of delivery capabilities |
| `prefer` | Will *prefer* carrier services that provide proof of delivery, but will not prevent allocation with services that do not have the capability, if no capable services are available |
| `prevent` | Will *prevent* allocation with carrier services that have a proof of delivery requirement. |

## Shipment

A `shipment` is created using a `create_shipment_request` and Sorted will conduct all operations on the `shipment` object.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The reference assigned by Sorted for this `shipment`. This will be unique for all `shipments`. See [Unique References](./unique-id-generation.md). | `1` |
| `state` | [`shipment_state`](#shipment-state) | The current `state` of the `shipment`. | `1` |
| `created` | `ISO8601 Date Time` | The date and time that the `shipment` was created. | `1` |
| `updated` | `ISO8601 Date Time` | The date and time that the `shipment` was last updated. | `0..1` |
| `shipping_date` | [`date_range`](#date-range) | The assigned shipping date for the `shipment` based on the active allocation (if allocated). | `0..1` |
| `required_shipping_date` | [`date_range`](#date-range) | The `required_shipping_date` provided when the `shipment` was created, if applicable. | `0..1` |
| `expected_delivery_date` | [`date_range`](#date-range) | The expected date(s) for delivery based on the current active allocation, if applicable. | `0..1` |
| `required_delivery_date` | [`date_range`](#date-range) | The required dates for delivery provided by the customer, if applicable. | `0..1` |
| `actual_delivery_date` | `ISO8601 Date Time` | The actual date and time that the `shipment` was delivered, if applicable. | `0..1` |
| `allocation` | [`allocation`](#allocation) | Details of the active allocated carrier/service for the `shipment`, if applicable. | `0..1` |
| `label_details` | [`label-details`](#label-details) | Details of labels. | `0..1` |
| `custom_reference` | `string` | The custom reference provided for this `shipment`, if applicable. | `0..1` |
| `tags` | List of `string` | The tags provided for this `shipment`, if applicable. | `0..10` |
| `order_date` | `ISO8601 Date Time` | The order date for this `shipment`, if applicable. | `0..1` |
| `metadata` | List of [`metadata`](#metadata) | The [`metadata`](#metadata) for this `shipment`, if applicable. | `0..10` |
| `customs_documentation` | [`customs_documentation`](#customs-documentation) | The [`customs_documentation`](#customs-documentation) for this `shipment`, if applicable. | `0..1` |
| `direction` | [`direction`](#direction) | The [`direction`](#direction) of the shipment. | `1` |
| `shipment_type` | [`shipment_type`](#shipment-type) | Indicates the type of `shipment`. See [`shipment_type`](#shipment-type). | `1` |
| `contents` | List of [`shipment_contents`](#shipment-contents) | Details of the contents of the `shipment`. See [`shipment_contents`](#shipment-contents). | `1..n` |
| `addresses` | List of [`address`](#address) | The `addresses` for the `shipment`. | `2..n` |
| `label_properties` | List of [`label_property`](#label-property) | Additional properties used to decorate labels. | `0..10` |
| `source` | `string` | The source of the `shipment`. | `1` |
| `reservation` | [`reservation`](#reservation) | Details of any reservation for the `shipment`, if applicable. | `0..1` |
| `_links` | List of [`link`](#link) | Links to any related resources | `0..n` |
| `tenant` | `string` | The `tenant` that the `shipment` is linked to, if applicable. | `0..1` |
| `channel` | `string` | The `channel` that the `shipment` is linked to, if applicable | `0..1` |

</div>

### Shipment JSON Example

A `shipment` has more properties than a `create_shipment_request`, because Sorted will populate properties based on the operations conducted on the `shipment`. For example, Sorted will assign a unique reference to the `shipment`, and once the `shipment` is allocated it will contain details of the allocation:

```json
{
    "reference": "sp_9953035299125395456009822134452",
    "state": "allocated",
    "custom_reference": "0af07451-cf80-43cb-af24-acdfdbd41a14",
    "created": "2019-04-25T16:12:14+01:00",
    "shipping_date": {
        "start": "2019-04-26T12:45:00+01:00",
        "end": "2019-04-26T16:45:00+01:00"
    },
    "required_shipping_date": {
        "start": "2019-04-26T00:00:00+01:00",
        "end": "2019-04-26T23:59:59+01:00"
    },
    "expected_delivery_date": {
        "start": "2019-04-28T09:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "required_delivery_date": { 
        "start": "2019-04-27T07:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "actual_delivery_date": null,
    "allocation": {
        "carrier": {
            "reference": "ABQ",
            "name": "ABQ Worldwide",
            "service_reference": "ABQ48",
            "service_name": "ABQ 48 Express"
        },
        "allocation_date": "2019-04-25T16:27:22+01:00",
        "price": {
            "net": 10.0,
            "gross": 12.0,
            "taxes": [
                {
                    "rate": {
                        "reference": "gb_standard",
                        "country_iso_code": "GB",
                        "type": "standard",
                        "value": 0.2
                    },
                    "amount": 2.0
                }
            ],
            "currency": "GBP",
            "tracking_references": [
                "TRK987987345"
            ],
            "_links": []
        }
    },
    "label_details": {
        "date_first_retrieved": "2019-04-25T16:27:23+01:00",
        "retrieval_count": 1,
        "_links": [
            {
                "href": "https://api.sorted.com/pro/labels/sp_9953035299125395456000008989766/zpl",
                "rel": "label",
                "reference": null,
                "type": "label"
            }
        ]
    },
    "tags": [
        "b&w",
        "T2"
    ],
    "order_date": "2019-04-05T09:34:55+01:00",
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string"
        },
        {
            "key": "refundable",
            "value": "false",
            "type": "boolean"
        }
    ],
    "customs_documentation": {
        "designated_person_responsible": "John McBride",
        "importers_vat_number": "0234555",
        "category_type": "gift",
        "shippers_customs_reference": "CREF0001",
        "importers_tax_code": "TC001",
        "importers_telephone": "+441772611444",
        "importers_fax": null,
        "importers_email": "jmcb@tilda.net",
        "cn23_comments": "Some comments here",
        "attached_invoice_references": [
            "63bc2ad5-dbff-4d30-a9b2-8081607d9921"
        ],
        "attached_certificate_references": [
            "bbc0eaa5-1a1d-4b56-b33a-a360680c1270"
        ],
        "attached_licence_references": [
            "0e5084d6-6509-4ff3-9771-66e63f452eb9"
        ],
        "category_type_explanation": "Free text",
        "declaration_date": "2019-04-26T14:57:54+01:00",
        "reason_for_export": "sale",
        "shipping_terms": "fca",
        "shippers_vat_number": "98798273434",
        "receivers_tax_code": "TC8793847",
        "receivers_vat_number": "9879879878675",
        "invoice_date": "2019-04-26T15:01:45+01:00"
    },
    "direction": "outbound",
    "shipment_type": "on_demand",
    "contents": [
        {
            "reference": "sc_10014418860050677760000090908111",
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
                "currency": "GBP",
                "discount": 0.0
            },
            "sku": "SKU09876",
            "model": "MOD-009",
            "country_of_origin": "PO",
            "harmonisation_code": "09.02.10",
            "quantity": 2,
            "unit": "Box",
            "dangerous_goods": {
                "hazard_classes": [
                    { "code": "2.1" }
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
            "shipping_location_reference": null,
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865000090903324",
                "title": "Mr",
                "first_name": "Steve",
                "last_name": "Kingston",
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
            "address_line_1": "Norbert Road",
            "address_line_2": "Bertwistle",
            "address_line_3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ],
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ],
    "reservation": {
        "reference": "rs_9953035320600231936990900087888",
        "location_reference": "8BDSF43555",
        "external_reference": "d6bc18f4-1d48-45fb-9586-8111db7ab827"
    },
    "source": "WMS",
    "tenant": "TEN001",
    "channel": "CHAN002"
}

```

## Shipment Contents

All `shipments` in SortedPRO require at least one `shipment_contents` object. This object represents the contents of the `shipment`. For example, a `shipment` of a pair of shoes will contain one `shipment_contents` object which defines the properties of the pair of shoes (e.g. `dimensions`, `weight`, etc.).

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | Unique reference generated by Sorted | N/A. Provided in responses only. | `0` |
| `custom_reference` | `string` | The customer's own custom reference for these contents. | Optional. If provided, must be `>= 1` and `<= 50` characters | `0..1` |
| `package_size_reference` | `string` | The reference of an existing pre-defined package size within SortedPRO. If provided, `weight` and `dimensions` are not required. | If provided, must be a valid reference for an existing package size within SortedPRO. | `0..1` |
| `weight` | [`weight`](#weight) | The [`weight`](#weight) of the contents. | Required unless `package_size_reference` has been specified. | `0..1` |
| `dimensions` | [`dimensions`](#dimensions) | The [`dimensions`](#dimensions) of the package. | Required unless `package_size_reference` has been specified. | `0..1` |
| `value` | [`value`](#value) | The [`value`](#value) of the contents. | Required. | `1` |
| `sku` | `string` | The stock-keeping unit of the contents. | Optional. If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `model` | `string` | The model of the contents. | Optional. If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `country_of_origin` | `string` | The ISO code representing the country of origin of the contents. | If provided, must be a valid 2-letter ISO code. | `0..1` |
| `harmonisation_code` | `string` | The harmonisation code for the `shipment_contents`. | If provided, must be a valid format of harmonisation code including dots, e.g. `09.02.10` | `0..1` |
| `shipping_terms` | [`shipping_terms`](#shipping-terms) | The [`shipping_terms`](#shipping-terms) according to the Incoterms rules. | Optional. If provided, must be a valid `shipping_terms` value. | `0..1` |
| `quantity` | `integer` | The quantity of these contents. | If not provided, will default to `1`. If provided, must be a valid positive integer. | `0..1` |
| `unit` | `string` | The unit of packing of these contents, e.g. box | If provided, must be `>= 1` and `<= 50` characters. | `0..1` |
| `dangerous_goods` | [`dangerous_goods`](#dangerous-goods) | Properties used to describe dangerous goods, if applicable. | Optional. | `0..1` |
| `metadata` | List of [`metadata`](#metadata) | Additional properties to apply to `shipment_contents`. Additional functionality can be linked to properties specified in `metadata`. | Optional. A maximum of 10 [`metadata`](#metadata) values can be provided per `shipment_contents`. | `0..10` |
| `label_properties` | List of [`label_property`](#label-property) | Values to be used in the generation or decoration of labels at contents level. | Optional. | `0..10` |
| `description` | `string` | A description of the contents. Used for display purposes and for inclusion in customs documents. | Required. Must be `<= 100` characters. | `1` |
| `contents` | List of [`shipment_contents`](#shipment-contents) | The contents of this `shipment` contents, if applicable. | Optional. If provided, a maximum "depth" of 2 is permitted, i.e. `shipment_contents` can contain `shipment_contents`, but those `shipment_contents` cannot additionally contain `shipment_contents`. | `0..n` |

</div>

## Shipment Group

A `shipment_group` is used to group together `shipments` booked with the same carrier service. This object is used to manage a `shipment_group` that has already been created.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference applied to this `shipment_group` by Sorted. | `1` |
| `shipments` | List of `string` | The references of the `shipments` in this group. | `1..10,000` |
| `custom_reference` | `string` | The custom reference applied to this `shipment_group`. | `0..1` |
| `version` | `integer` | The version as related to the `custom_reference` for this `shipment_group` | `0..1` |
| `state` | [`shipment_group_state`](#shipment-group-state) | The current state of this `shipment_group`. | `1` |
| `created` | `ISO8601 Date Time` | The date and time that this `shipment_group` was created. | `1` |
| `locked` | `ISO8601 Date Time` | The date and time that this `shipment_group` was `locked`, if applicable. | `0..1` |
| `closed` | `ISO8601 Date Time` | The date and time that this `shipment_group` was `closed`, if applicable. | `0..1` |
| `updated` | `ISO8601 Date Time` | The date and time that this `shipment_group` was last updated. | `0..1` |

</div>

### Shipment Group JSON Example

A `shipment_group` is created as a result of a `create_shipment_group_request` and includes the unique reference assigned by Sorted and the current state of the `shipment_group`:

```json
{
    "reference": "sg_10014417970992447488787654333231",
    "shipments": [
        "sp_00013473827456470532303387361290",
        "sp_09830498509898987009909000543435"
    ],
    "custom_reference": "5988920e-4609-4658-ae97-11f44ea14c6f",
    "state": "open",
    "created": "2019-05-03T17:00:23+01:00"
}

```

## Shipment Group State

The following table lists the possible `state` values for a [`shipment_group`](#shipment-group).

| Value | Description |
|------ | ------------|
| `open` | The `shipment_group` is open and additional `shipments` can be added to or removed from the group. The `shipment_group` may not be used to retrieve a `collection_note` whilst in this `state`. |
| `locked` | The `shipment_group` is `locked`, and no further `shipments` can be added to or removed from the group. The `collection_note` may now be generated. |
| `closed` | The `shipment_group` has been `closed`. No further operations may be conducted on the `shipment_group`, but the `collection_note` and `shipment_group` details may still be retrieved. |

## Shipment Group Summary

The `shipment_group_summary` object provides summary details of a [`shipment_group`](#shipment-group).

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference applied to this `shipment_group` by Sorted | `1` |
| `custom_reference` | `string` | The `custom_reference` applied to this group by the customer | `0..1` |
| `version` | `integer` | The `version` as relates to the `custom_reference` for this `shipment_group` | `0..1` |
| `_links` | List of [`link`](#link) | A list of `links` that provides pointers to related resources | `1..n` |

</div>

### Shipment Group Summary JSON Example

This object provides summary details of a `shipment_group` to allow users to access details of all `shipment_groups` with a specific `custom_reference`:

```json
[
    {
        "reference": "sg_00013464648946915264789208891778",
        "custom_reference": "trl_009",
        "version": 1,
        "_links": [
            {
                "rel": "self",
                "href": "/pro/shipment_groups/sg_{ref}"
            },
            {
                "rel": "version",
                "href": "/pro/shipment_groups/custom_reference/trl_009/1"
            }
        ]
    },
    {
        "reference": "sg_00013464648946915264789208891788",
        "custom_reference": "trl_009",
        "version": 2,
        "_links": [
            {
                "rel": "self",
                "href": "/pro/shipment_groups/sg_{ref}"
            },
            {
                "rel": "version",
                "href": "/pro/shipment_groups/custom_reference/trl_009/2"
            }
        ]
    }
]

```

## Shipment List

The `shipment_list` object provides the details of one or more matching [`shipments`](#shipment).

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `shipments` | List of [`shipment`](#shipment) | A list of matching `shipments` | `0..10` |
| `total_results` | `int` | The total number of matching results | `1` |
| `take` | `int` | The number of `shipments` that were requested | `1` |
| `skip` | `int` | The number of `shipments` that were skipped | `1` |
| `_links` | List of [`link`](#link) | Lists any related resources | `0..n` |

</div>

## Shipment State

Every `shipment` in Sorted has a `state` associated with it. Sorted manages `shipment` `states` by virtue of a set of rules that determine transition rules between `states`.

| Value | Description |
|------ | ------------|
| `unallocated` | This is the default initial state. The shipment has not been booked with a carrier. |
| `allocating` | The shipment is in the process of being allocated and is locked from further state transitions until allocation completes or fails. |
| `allocation_failed` | The most recent attempt to allocate the shipment failed. |
| `allocated` | The shipment is currently allocated to a carrier service. |
| `manifesting` | The shipment is in the process of being manifested and is locked from further state transition until manifesting completes or fails. |
| `manifested` | The shipment has been manifested with the carrier successfully. |
| `manifest_failed` | The most recent attempt to manifest the shipment failed. |
| ~~`booking`~~ | ~~The shipment is in the process of being booked and is locked from further state transitions until allocation completes or fails.~~ |
| ~~`booked`~~ | ~~The shipment has been successfully booked with a service that does not required Manifesting.~~ |
| ~~`booking_failed`~~ | ~~The most recent attempt to book the shipment with the carrier failed.~~ |
| `collection_booking_pending` | A booking for a collection (for `on_demand` `shipments` only) is queued but has neither failed or succeeded. |
| `collection_booked` | A booking for a collection (for `on_demand` `shipments` only) was successful |
| `collection_booking_failed` | A booking for a collection (for `on_demand` `shipments` only) was not successful |
| `dispatched` | The shipment has been dispatched. This state is normally used when the carrier does not or cannot provide tracking events. |
| `awaiting_drop_off` | The carrier is waiting for the customer to drop off the shipment. |
| `at_drop_off_point` | The shipment is at the point of drop off and is waiting to be picked up. |
| `in_transit` | The shipment is currently being transported and has not yet been delivered. |
| `delayed` | The shipment is delayed and is likely to be late. |
| `out_for_delivery` | The shipment is out for delivery. |
| `delivery_failed` | Delivery of the shipment failed. |
| `delivery_failed_card_left` | Delivery of the shipment failed, and the driver left a card. |
| `delivered` | The shipment has been delivered successfully. |
| `partially_delivered` | One or more parts of the shipment have been delivered, but there are remaining constituent parts of the shipment which have not yet been delivered. |
| `at_collection_point` | The shipment is at a collection point waiting to be collected. |
| `returned_to_sender` | The shipment has been returned to the sender. |
| `action_required` | Action is required with the shipment in order to effect successful delivery. |
| `missing` | The shipment is missing. |
| `lost` | The shipment has been lost. |
| `damaged` | The shipment has been damaged. |
| `destroyed` | The shipment has been destroyed by the carrier (either because it was dangerous, or it was too damaged) |
| `cancelling` | The shipment is in the process of being cancelled and is locked from further state transitions until cancellation succeeds or fails. |
| `cancelled` | The shipment has been cancelled. No further changes may be made to the shipment. |
| `in_transit_waiting` | The shipment is in transit and is waiting for further action from the carrier. |
| `held_by_carrier` | The shipment is currently being held by the carrier. |
| `exchange_failed` | An exchange of the shipment between carriers failed. |
| `at_customs` | The shipment is at customs. |
| `cleared_customs` | The shipment has cleared customs. |
| `delivered_damaged` | The shipment was delivered but in a damaged condition. |
| `ready_to_ship` | The shipment is ready to be shipped. This is a pre-manifest state. |
| `carrier_collected` | The shipment has been collected by the carrier (usually on_demand carriers) |
| `carrier_changed` | The shipment has been handed over to a new carrier |
| `customer_collected` | The shipment has been collected by the customer (e.g. from a pick-up location) |
| `carrier_collection_failed` | The carrier failed to collect the shipment. |
| `customer_collection_failed` | The customer failed to collect the shipment. |
| `at_customer_collection_point` | The shipment been delivered to the collection point. |

## Shipment State Change Request

A `shipment_state_change_request` can be used to modify the `state` of a `shipment` manually. Only certain `state` transitions are permitted. This functionality should be used in exceptional circumstances when Sorted is unable to transition a `state` automatically (e.g. due to unavailable tracking details).

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | The reference of the `shipment` to change | Required. Must be a valid `shipment` reference for an existing `shipment`. | `1` |
| `state` | [`shipment_state`](#shipment-state) | The desired [`shipment_state`](#shipment-state). | Required. Must be a valid [`shipment_state`](#shipment-state). | `1` |
| `reason` | `string` | The reason for the change. This forms part of the `shipment's` audit history. | Required. Length `>= 5` and `<= 100` characters. | `1` |

</div>

### Shipment State Change Request JSON Example

A `shipment_state_change_request` is used to change the state of a `shipment`:

```json
{
    "shipment_reference": "sp_10014418735496626176778765666898",
    "state": "delivered",
    "reason": "Manually tracked by customer support"
}
```

## Shipment State Summary

A `shipment_state_summary` provides key properties of a `shipment` as it relates to a manifest.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this `shipment`. | `1` |
| `state` | `shipment_state` | The current state of the `shipment`. | `1` |
| `_links` | List of [`link`](#link) | Provides links to related resources. | `0..n` |

</div>

## Shipment Summary

A `shipment_summary` is returned in a [`quote`](#quote) and provides summary details of the `shipment` that a `quote` relates to.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this `shipment`. | `1` |
| `addresses` | List of [`address`](#address) | The addresses relating to this `shipment`. | `2..7` |
| `custom_reference` | `string` | The custom reference applied by the customer for this `shipment`. | `0..1` |
| `_links` | List of [`link`](#link) | Provides [`links`](#link) to any related resources. | `0..n` |

</div>

## Shipment Type

The `shipment_type` property indicates whether the `shipment` is intended to be allocated with an on-demand service or with a scheduled service, or both.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `on_demand` | The `shipment` is intended to be allocated to an on-demand service. An on-demand service is one which does not have a regular, scheduled collection from a pre-defined location. |
| `scheduled` | The `shipment` is intended to be allocated to a scheduled service. This is a service which has a predefined, scheduled time (or times) of collection from a specific location. |

The `shipment_type` property is used to determine which type(s) of carrier service to use when retrieving quotes or allocating a `shipment`. If you know before creation whether a `shipment` will be an on-demand or scheduled `shipment`, you should always prefer to specify the specific `shipment_type`. However, SortedPRO allows multiple `shipment_type` values to be specified by supplying multiple values separated by a comma. This means that you can indicate that a `shipment` should be eligible for both on-demand and scheduled collections.

> [!WARNING]
> Note that the more stringent validation rules will apply when specifying both `shipment_types`. For instance, a `shipping_location_reference` is required when using a type of `scheduled`, but not when specifying a type of `on_demand`. Therefore, if you specify `on_demand, scheduled` for this property then a `shipping_location_reference` will be required.

## Shipping Terms

The following values are permissible as `shipping_terms` when populating the [`customs_documentation`](#customs-documentation) property of a `shipment`.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `exw` | Ex Works (named place of delivery) |
| `fca` | Free Carrier (named place of delivery) |
| `cpt` | Carriage Paid To (name place of destination) |
| `cip` | Carriage Insurance Paid to (named place of destination) |
| `dat` | Delivered at Terminal (named terminal at port or place of destination) |
| `ap` | Delivered at Place (named place of destination) |
| `ddp` | Delivery Duty Paid (named place of destination) |
| `fas` | Free Alongside Ship (named port of shipment) |
| `fob` | Free on Board (named port of shipment) |
| `cfr` | Cost and Freight (named port of destination) |
| `cif` | Cost, Insurance and Freight (named port of destination) |

## Surcharge

A `surcharge` can be applied when generating a `quote` for a carrier service. There are many types of `surcharge` applied by carriers and this object provides details of any applicable `surcharges` applied when calculating the total `price` for a specific carrier service.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this `surcharge`. | `1` |
| `currency` | `string` | The 3-character ISO code for the currency of this `surcharge`. | `1` |
| `value` | `decimal` | The value of this `surcharge` in the applied currency. | `1` |
| `application_type` | [`application_type`](#application-type) | Identifies how this `surcharge` applies. See [`application_type`](#application-type). | `1` |
| `type` | [`surcharge_type`](#surcharge-type) | Identifies the type of this `surcharge`. See [`Surcharge Type`](#surcharge-type). | `1` |
| `base_application` | [`base_application`](#base-application) | Identifies whether this `surcharge` applies to the base cost. See [`base_application`](#base-application). | `1` |
| `calculation_model` | [`calculation_model`](#calculation-model) | Identifies the [`calculation_model`](#calculation-model) of this `surcharge`. | `1` |
| `incremental_unit_factor` | `decimal` | The incremental unit factor applied when calculating the `quote`, if applicable. | `0..1` |
| `incremental_unit_price` | `decimal` | The incremental unit price applied when calculating the `quote`, if applicable. | `0..1` |
| `minimum_value` | `decimal` | The minimum value of this `surcharge`, if applicable. | `0..1` |
| `maximum_value` | `decimal` | The maximum value of this `surcharge`, if applicable. | `0..1` |
| `label` | `string` | A plain-text label for this `surcharge`. | 1 |
| `description` | `string` | A plain-text description for this `surcharge`. | 1 |

</div>

## Surcharge Type

The `surcharge_type` value identifies the type of `surcharge` which determines how the final `surcharge` value is calculated.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `additive` | The value of the `surcharge` is fixed and added to the total cost. |
| `variable` | The value of the `surcharge` is calculated as a proportion of the overall cost. |

## Tax

The `tax` object provides details of any applicable taxes, including the type and amount of `tax`.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `rate` | [`tax_rate`](#tax-rate) | The rate of `tax` | `1` |
| `amount` | `decimal` | The amount of `tax` | `1` |

</div>

## Tax Rate

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | Sorted's unique reference for this `tax_rate` | `1` |
| `country_iso_code` | `string` | The 2-character ISO code for the country to which this rate applies | `1` |
| `type` | `string` | The type of rate, e.g. `standard`. See [`tax_rate_type`](#tax-rate-type) | `1` |
| `value` | `decimal` | The value element of the `tax_rate`. This is expressed as a proportion of 1 | `1` |

</div>

## Tax Rate Type

The following tax rate types are supported in Sorted:

| Value | Description |
|------ | ------------|
| `standard` | A standard rate of tax |
| `reduced` | A reduced rate of tax |
| `zero` | A zero rate of tax |

</div>

## Tracking Contents Response

A `tracking_contents_response` is available when a carrier provides "package-level" tracking events.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `shipment_reference` | `string` | The unique reference of the `shipment` that this response relates to | `1` |
| `custom_reference` | `string` | The customer's own `custom_reference` for this `shipment`, if applicable | `0..1` |
| `carrier` | [`carrier_details`](#carrier-details) | The details of the carrier and carrier service for this `shipment` | `1` |
| `shipment_contents` | List of [`contents_tracking_event`](#contents-tracking-event) | The details of the tracking events for the `shipment` contents | `0..n` |
| `expected_delivery_date` | `ISO8601 Date Time` | The updated expected delivery date, if applicable | `0..1` |
| `_links` | List of [`link`](#link) | Links to related resources | `0..n` |

</div>

### Tracking Contents Response JSON Example

A `tracking_contents_response` contains content-level tracking events for a `shipment`:

```json
{
    "shipment_reference": "sp_00076976827069691057723959934976",
    "carrier": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
    },
    "shipment_contents": [
        {
            "carrier_references": [
                "5805984057422232"
            ],
            "reference": "sc_00076982052497331561502355750928",
            "events": [
                {
                    "reference": "tr_00076982052571118537797193957408",
                    "timestamp": "2019-07-23T17:42:00+01:00",
                    "received_timestamp": "2019-07-23T16:45:44+00:00",
                    "event_code": "delivered",
                    "description": "The parcel was handed to the resident",
                    "signee": "P. Jones",
                    "location": "23 Baker Road, Wilmslow, Manchester",
                    "lat_long": null
                },
                {
                    "reference": "tr_00076980765301976842123553538056",
                    "timestamp": "2019-07-23T12:00.00+01:00",
                    "received_timestamp": "2019-07-23T11:02:31+00:00",
                    "event_code": "out_for_delivery",
                    "description": "The shipment is out for delivery",
                    "signee": null,
                    "location": null,
                    "lat_long": null
                },
                {
                    "reference": "tr_00076982052589565281870903508993",
                    "timestamp": "2019-07-22T19:33:54+01:00",
                    "received_timestamp": "2019-07-22T18:34:21+00:00",
                    "event_code": "collected",
                    "description": "The shipment has been collected",
                    "signee": null,
                    "location": null,
                    "lat_long": null
                }
            ]
        }
    ],
    "expected_delivery_date": null,
    "_links": [
        {
            "rel": "self",
            "href": "https://api.sorted.com/tracking/sp_00076976827069691057723959934976/shipment_contents",
            "type": "tracking",
            "reference": "sp_00076976827069691057723959934976"
        }
    ]
}
```

## Tracking Contents Response List

The `tracking_contents_response_list` provides one or more [`tracking_contents_responses`](#tracking-contents-response). This object is generally returned in response to a query to retrieve contents-level tracking that may match more than one `shipment`.

> [!TIP]
> This object exists to ensure consistency of handling of JSON objects and to allow future extensibility. A simple array could be returned, but then it would not be possible to extend the response for an applicable API without introducing a breaking change.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `tracking_contents_responses` | List of [`tracking_contents_response`](#tracking-contents-response) | The list of matching `tracking_contents_response` objects. | `0..n` |
| `total_results` | `int` | The total number of matching results | `1` |
| `take` | `int` | The number of `tracking_contents_responses` that were requested | `1` |
| `skip` | `int` | The number of `tracking_contents_responses` that were skipped | `1` |
| `_links` | List of [`link`](#link) | Lists any related resources | `0..n` |

</div>

## Tracking Details

This object provides details of tracking provided by the carrier at the point of allocation. Depending on the carrier, tracking references may be provided for the whole `shipment`, or for the whole `shipment` and/or for individual `shipment_contents`.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `shipment` | [`tracking_references`](#tracking-references) | The top-level tracking reference(s) for the `shipment`. Normally this will contain a single reference | `1` |
| `contents` | List of [`tracking_references`](#tracking-references) | The tracking reference(s), if applicable, for the `shipment_contents` | `0..n` |

</div>

## Tracking Event

Contains the details of a tracking event. All tracking events received from carriers will be "normalised" by Sorted into standardised language and codes.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference of this `event` | `1` |
| `timestamp` | `ISO8601 Date Time` | The timestamp of when this `event` occurred as provided by the carrier | `1` |
| `received_timestamp` | `ISO8601 Date Time` | The date and time that this `event` was received and processed by Sorted | `1` |
| `event_code` | `string` | The tracking event code for this `event`. See [Tracking Event Codes](#tracking-event-code) | `1` |
| `description` | `string` | A plain text description of this `event` | `1` |
| `signee` | `string` | Details of the `signee` of an `event`, if applicable | `0..1` |
| `location` | `string` | A summarised version of the location of an `event`, if provided | `0..1` |
| `lat_long` | [`lat_long`](#latlong) | The `latitude` and `longitude` of the location at which the `event` took place, if provided | `0..1` |

</div>

## Tracking Event Code

Each tracking event received from a carrier will be mapped to a specific Sorted tracking event code. This means that the response from Sorted will always be consistent, regardless of the different types of tracking events returned by various carriers.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `action_required` | The carrier should be contacted |
| `at_customs` | The `shipment` is being cleared through customs |
| `awaiting_drop_off` | The carrier is waiting for the customer to drop off the `shipment` |
| `carrier_changed` | The `shipment` has been handed over to a new carrier |
| `cleared_through_customs` | The `shipment` has been cleared through customs |
| `collected_by_carrier` | The `shipment` was collected by the carrier |
| `collection_failed` | The carrier was unable to collect the `shipment` |
| `damaged` | The `shipment` was damaged in transit |
| `delayed` | The `shipment` is delayed |
| `delivered` | The `shipment` was delivered successfully |
| `delivered_damaged` | The `shipment` was delivered in a damaged state |
| `delivery_failed` | The `shipment` could not be delivered |
| `delivery_failed_card_left` | The `shipment` could not be delivered but the carrier left a calling card |
| `destroyed` | The `shipment` was destroyed by the carrier (e.g. because it was too damaged or because it was dangerous) |
| `dropped_off` | The `shipment` was dropped off by the customer |
| `exchange_failed` | An exchange between carriers or parties was unsuccessful |
| `exchange_succeeded` | An exchange between carriers or parties was successful |
| `failed_to_collect` | The customer did not collect their `shipment` from the collection location |
| `for_information` | Informational messages that do not affect `shipment` states |
| `held_by_carrier` | The `shipment` is being held by the carrier |
| `in_transit` | The `shipment` is in transit |
| `in_transit_waiting` | The carrier is waiting until transit can be resumed (e.g. due to Force Majeure) |
| `lost` | The carrier lost the `shipment`, or it was stolen |
| `missing` | The carrier is attempting to locate the `shipment` |
| `out_for_delivery` | The `shipment` is out for delivery |
| `partially_delivered` | Part of a multi-part `shipment` was delivered |
| `returned_to_sender` | The `shipment` has been returned to the sender |

## Tracking References

This object provides details of tracking references for a `shipment` or `shipment_contents`.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `reference` | `string` | The unique reference for this object. For a `shipment`, this will be the reference of the `shipment`. | `1` |
| `tracking_references` | List of `string` | The tracking reference(s) assigned by the carrier. | `0..n` |
| `_links` | List of [`link`](#link) | Any applicable `links` for this object. | `0..n` |

</div>

## Tracking Response

A `tracking_response` provides details of tracking events for a `shipment`.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `shipment_reference` | `string` | The unique reference of the `shipment` that this response relates to | `1` |
| `custom_reference` | `string` | The customer's own `custom_reference` for this `shipment`, if applicable | `0..1` |
| `carrier_references` | List of `string` | The tracking reference(s) assigned to this `shipment` by the carrier | `1..n` |
| `carrier` | [`carrier_details`](#carrier-details) | The details of the carrier and carrier service for this `shipment` | `1` |
| `events` | List of [`tracking_event`](#tracking-event) | The details of the tracking event | `0..n` |
| `expected_delivery_date` | `ISO8601 Date Time` | The updated expected delivery date, if applicable | `0..1` |
| `_links` | List of [`link`](#link) | Links to related resources | `0..n` |

</div>

### Tracking Response JSON Example

A `tracking_response` contains details of tracking events for a `shipment`:

```json
{
    "shipment_reference": "sp_00076976827069691057723959934976",
    "carrier_references": [
        "5605984057422227"
    ],
    "custom_reference": "3c48aee67b6c4662b5884b9ceec8e3c8",
    "carrier": {
        "reference": "DNQ",
        "name": "DNQ Worldwide",
        "service_reference": "DNQWW72",
        "service_name": "DNQ Worldwide 72-Hour Express"
    },
    "events": [
       {
           "reference": "tr_00076982052571118537797193957408",
           "timestamp": "2019-07-23T17:42:00+01:00",
           "received_timestamp": "2019-07-23T16:45:44+00:00",
           "event_code": "delivered",
           "description": "The parcel was handed to the resident",
           "signee": "P. Jones",
           "location": "23 Baker Road, Wilmslow, Manchester",
           "lat_long": null
       },
       {
           "reference": "tr_00076980765301976842123553538056",
           "timestamp": "2019-07-23T12:00.00+01:00",
           "received_timestamp": "2019-07-23T11:02:31+00:00",
           "event_code": "out_for_delivery",
           "description": "The shipment is out for delivery",
           "signee": null,
           "location": null,
           "lat_long": null
       },
       {
           "reference": "tr_00076982052589565281870903508993",
           "timestamp": "2019-07-22T19:33:54+01:00",
           "received_timestamp": "2019-07-22T18:34:21+00:00",
           "event_code": "collected",
           "description": "The shipment has been collected by the carrier",
           "signee": null,
           "location": null,
           "lat_long": null
       }
    ],
    "expected_delivery_date": null,
    "_links": [
        {
            "rel": "self",
            "href": "https://api.sorted.com/tracking/sp_00076976827069691057723959934976",
            "type": "tracking",
            "reference": "sp_00076976827069691057723959934976"
        },
        {
            "rel": "shipment",
            "href": "https://api.sorted.com/shipments/sp_00076976827069691057723959934976",
            "type": "shipment",
            "reference": "sp_00076976827069691057723959934976"
        }
    ]
}
```

## Tracking Response List

The `tracking_response_list` provides one or more [`tracking_responses`](#tracking-response). This object is generally returned in response to a query to retrieve tracking that may match more than one `shipment`.

> [!TIP]
> This object exists to ensure consistency of handling of JSON objects and to allow future extensibility. A simple array could be returned, but then it would not be possible to extend the response for an applicable API without introducing a breaking change.

<div class="contract">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `tracking_responses` | List of [`tracking_response`](#tracking-response) | The list of matching `tracking_response` objects. | `0..n` |
| `total_results` | `int` | The total number of matching results | `1` |
| `take` | `int` | The number of `tracking_responses` that were requested | `1` |
| `skip` | `int` | The number of `tracking_responses` that were skipped | `1` |
| `_links` | List of [`link`](#link) | Lists any related resources | `0..n` |

</div>

## Update Shipment Group Request

An `update_shipment_group_request` is used to update an existing `shipment_group` by modifying the `shipments` that the group contains.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | The unique reference applied to this `shipment_group` by Sorted. | Required. Must be a valid reference of an existing `shipment_group`. | `1` |
| `add_shipments` | List of `string` | References of `shipments` to add to the `shipment_group` | Optional. If provided, must contain at least 1 valid existing `shipment` reference that is not currently a member of the `shipment_group` and is not a member of any other *open* `shipment_group`. | `1..10,000` |
| `remove_shipments` | List of `string` | References of `shipments` to remove from the `shipment_group` | Optional. If provided, must contain at least 1 valid existing `shipment` reference that *is currently a member* of the `shipment_group` and is *not* a member of any other *open* `shipment_group`. | `1..10,000` |

</div>

### Update Shipment Group Request JSON Example

An `update_shipment_group_request` is used to update an existing `shipment_group`:

```json
{
    "reference": "sg_10014417970992447488009090008112",
    "custom_reference": "5988920e-4609-4658-ae97-11f44ea14c6f",
    "add_shipments": [
        "sp_00013473827456470532303387361290"
    ],
    "remove_shipments": null,
}

```

## Update Shipment Request

The `update_shipment_request` is used to update an existing shipment.

> [!WARNING]
> All properties in an `update_shipment_request` should be provided when updating the `shipment` i.e. customers should provide the full details of the `shipment` rather than just including properties they wish to update. The properties provided will replace the *entire* `shipment` object. There are some system-generated properties of a `shipment` that cannot be modified, such as `allocation` and `_links`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `reference` | `string` | The unique Sorted reference of the `shipment` | Required. Must be a valid `shipment` reference. | `1` |
| `custom_reference` | `string` | Custom reference provided by the customer | Optional. If provided, limited to `50` characters. | `0..1` |
| `required_delivery_date` | [`date_range`](#date-range) | A [`date_range`](#date-range) used to specify the required delivery date | Optional. | `0..1` |
| `required_shipping_date` | [`date_range`](#date-range) | A [`date_range`](#date-range) used to specify the required shipping date | Optional. | `0..1` |
| `tags` | List of `string` | Custom `tags` to apply to the `shipment`. | Optional. If provided, each `tag` is limited to 50 characters and there is a limit of 10 `tags` per `shipment`. | `0..10` |
| `order_date` | `ISO8601 DateTime` | The date that the items in the `shipment` were ordered. This can be used to track `shipments` vs. order dates in customers' own systems. | Optional. If provided, must be a valid ISO8601 date time including offset. Sorted will not validate the logic of the date compared to other relevant dates. | `0..1` |
| `metadata` | List of [`metadata`](#metadata) | Additional properties to apply to a `shipment`. Additional functionality can be linked to properties specified in `metadata`. | Optional. A maximum of 10 `metadata` values can be provided per `shipment`. | `0..10` |
| `customs_documentation` | [`customs_documentation`](#customs-documentation) | Properties used to generate customs document(s) for this `shipment`. | Optional. See [`customs_documentation`](#customs-documentation) | `0..1` |
| `direction` | [`direction`](#direction) | Indicates the `direction` of the `shipment`. | Optional. Will default to `outbound` if not specified | `0..1` |
| `shipment_type` | [`shipment_type`](#shipment-type) | Indicates the `type` of `shipment`. | Required. See [`shipment_type`](#shipment-type) | `1` |
| `contents` | List of [`shipment_contents`](#shipment-contents) | The contents of the `shipment`. | At least one `shipment_contents` required. | `1..n` |
| `addresses` | List of [`address`](#address) | The addresses for this shipment. | Required. Must contain at least an `origin` and `destination` [`address`](#address). | `2..7` |
| `label_properties` | List of [`label_property`](#label-property) | Values to be used in the generation or decoration of labels. | Optional. See [`label_property`](#label-property). | `0..10` |
| `source` | `string` | Indicates the source of the `shipment`. | Optional. If not provided, will default to `api`. If provided, the maximum length is `50` characters. | `0..1` |
| `tenant` | `string` | Indicates the `tenant` that the `shipment` belongs to. | Optional. If provided, must be a valid pre-existing `tenant` reference for the customer. | `0..1` |
| `channel` | `string` | Indicates the `channel` that the `shipment` belongs to. | Optional. If provided, must be a valid pre-existing `channel` for the provided `tenant`. Must only be provided when `tenant` is provided. | `0..1` |

</div>

### Update Shipment Request JSON Example

An `update_shipment_request` allows you to update the properties of an existing `shipment`:

> [!WARNING]
> The `update_shipment_request` requires you to pass all properties that you wish the `shipment` to have, including any existing properties. If you do not pass existing properties and those properties do not require a value, the existing values will be removed from the `shipment`.

```json
{
    "reference": "sp_99530352690606243847878799090009",
    "custom_reference": "0af07451-cf80-43cb-af24-acdfdbd41a14",
    "required_delivery_date": { 
        "start": "2019-04-27T07:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "required_shipping_date": {
        "start": "2019-04-26T00:00:00+01:00",
        "end": "2019-04-26T23:59:59+01:00"
    },
    "tags": [
        "b&w",
        "T2"
    ],
    "order_date": "2019-04-05T09:34:55+01:00",
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string"
        }
    ],
    "customs_documentation": {
        "designated_person_responsible": "John McBride",
        "importers_vat_number": "0234555",
        "category_type": "gift",
        "shippers_customs_reference": "CREF0001",
        "importers_tax_code": "TC001",
        "importers_telephone": "+441772611444",
        "importers_fax": null,
        "importers_email": "jmcb@tilda.net",
        "cn23_comments": "Some comments here",
        "attached_invoice_references": [
            "63bc2ad5-dbff-4d30-a9b2-8081607d9921"
        ],
        "attached_certificate_references": [
            "bbc0eaa5-1a1d-4b56-b33a-a360680c1270"
        ],
        "attached_licence_references": [
            "0e5084d6-6509-4ff3-9771-66e63f452eb9"
        ],
        "category_type_explanation": "Free text",
        "declaration_date": "2019-04-26T14:57:54+01:00",
        "reason_for_export": "sale",
        "shipping_terms": "fca",
        "shippers_vat_number": "98798273434",
        "receivers_tax_code": "TC8793847",
        "receivers_vat_number": "9879879878675",
        "invoice_date": "2019-04-26T15:01:45+01:00"
    },
    "direction": "outbound",
    "shipment_type": "on_demand",
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
                "currency": "GBP",
                "discount": 0.0
            },
            "sku": "SKU09876",
            "model": "MOD-009",
            "country_of_origin": "PO",
            "harmonisation_code": "09.02.10",
            "quantity": 2,
            "unit": "Box",
            "dangerous_goods": {
                "hazard_classes": [
                    { "code": "2.1" }
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
            "shipping_location_reference": null,
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865666767651123",
                "title": "Mr",
                "first_name": "Steve",
                "last_name": "Kingston",
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
            "address_line_1": "Norbert Road",
            "address_line_2": "Bertwistle",
            "address_line_3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ],
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ],
    "source": "WMS",
    "tenant": "TENANT_001",
    "channel": "CHAN_001"
}
```

## Value

Represents the `value` of `contents` within a `shipment`. The va`lue property includes both the amount and the currency of the value.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `amount` | `decimal` | The amount in the specified units. | Required. Must be a valid positive `decimal`. Values are saved by SortedPRO with a precision of up to 5 `decimal` places. | `1` |
| `currency` | `string` | The ISO code of the currency (3 characters). | Required. Must be a valid 3-character ISO code. | `1` |
| `discount_rate` | `decimal` | Used to indicate the proportion of discount. A value of `100` indicates `100%` discount. | Optional. If not provided, will default to `0`. If provided, must be a valid `decimal` between `0` and `100` representing the percentage discount e.g. `10.5` means `10.5%`. | `0..1` |

</div>

### Value JSON Examples

The following examples show how `value` can be expressed in different currencies:

```json
{
    "value": {
        "amount": 8.99,
        "currency": "GBP"
    }
}
```

```json
{
    "value": {
        "amount": 9.99,
        "currency": "USD"
    }
}
```

```json
{
    "value": {
        "amount": 11.00,
        "currency": "EUR"
    }
}
```

It is also possible to apply a discount to the `value` of goods. This is useful if the goods have no effective `value` or cost to the customer. Customs documentation and carriers may still require a `value` greater than `0` to be provided. The `discount` property is designed to allow customers to indicate *actual* and *effective* `values`:

```json
{
    "value": {
        "amount": 11.00,
        "currency": "EUR",
        "discount": 90
    }
}
```

To indicate a value of `100%`, a value of `100` should be provided for the `discount` property:

```json
{
    "value": {
        "amount": 11.00,
        "currency": "EUR",
        "discount": 100
    }
}
```

## Weight

The `weight` object is used to define the `weight` of items within a `shipment`. `Weight` contains both the value and the unit of measurement.

> [!WARNING]
> All units specified within a single `shipment` must be the same, i.e. you cannot combine `weight_unit` values within a single `shipment`.

<div class="contract">

| Property | Type | Description | Validation | Occurrence |
| -------- | ---- | ----------- | ---------- | :--------: |
| `value` | `decimal` | The value in the specified units. | Required. Must be a valid positive `decimal`. Values are saved by SortedPRO with a precision of up to `5` decimal places. | `1` |
| `unit` | [`weight_unit`](#weight-unit) | The unit of measurement. | Required. Must be a valid [`weight_unit`](#weight-unit). | `1` |

</div>

### Weight JSON Examples

The following example shows how a standard `weight` objects can be defined in `JSON`. The item weighs `2.4kg`:

```json
{
    "weight": {
        "value": 2.40,
    "unit": "kg"
    }
}
```

By specifying an alternative `unit`, the `weight` can be expressed in `pounds`:

```json
{
    "weight": {
        "value": 5.29,
        "unit": "lb"
    }
}
```

## Weight Unit

Represents the weight units recognised by SortedPRO.

> [!NOTE]
> This list of values may be extended at any time without prior notice. Your application should not be coded in such a way that an addition to the list causes a breaking change.

| Value | Description |
| ----- | ----------- |
| `kg` | Kilograms |
| `lb` | Pounds |

> [!TIP]
> *Metric and imperial combinations*
>
> When defining the `weight` and `dimensions` of a `shipment`, customers must either use **all** imperial or **all** metric units, i.e. it is **not** possible to combine a `weight_unit` of `lb` and a `dimension_unit` of `cm`. The current accepted combinations are:
>
>
> | Dimension Unit | Weight Unit |
> | -------------- | ----------- |
> | `cm` | `kg` |
> | `in` | `lb` |

## Additional Information

The following additional information relates to data contracts:

- [Error Codes](./error-codes.md)
