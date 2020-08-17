---
uid: shipments-error-codes
title: Shipments Error Codes
tags: shipments,data-contracts,errors,error-codes
contributors: michael.rose@sorted.com
created: 30/04/2020
---
# Error Codes

The following API error codes have been defined for the Sorted APIs:

| Parent Error | HTTP Status Code | Child Error Code | Description |
| ------------ | :--------------: | ---------------- | ----------- |
| `allocation_failed` | `521` | `allocation_failed` | The `shipment(s)` could not be allocated. The response will include details of the allocation failure. |
| `allocation_failed` | `521` | `carrier_service_not_found` | The request carrier service did not match a carrier service within your account
| `allocation_failed` | `521` | `carrier_service_shipment_mismatch` | The type of `shipment` (e.g. `on_demand`, `scheduled`) is not compatible with the requested carrier service
| `allocation_failed` | `521` | `shipment_invalid_state` | The `shipment` was not in a valid state to be allocated
| `allocation_failed` | `521` | `shipment_not_found` | The provided reference did not match a `shipment` within your account
| `conflict` | `429` | `rule_conflict` | The properties of the request conflict with an existing object. The request or existing record must be modified before the operation can succeed
| `internal_server_error` | `500` | `internal_server_error` | An unexpected error occurred
| `method_not_supported` | `405` | `method_not_supported` | The path is valid, but the method used was not valid. E.g. you used a `POST` verb for a `GET` endpoint.
| `no_quotes_available` | `531` | `no_quotes_available` | No quotes could be generated for the `shipment`. The response will include details of the exclusion reason for each carrier/carrier service.
| `not_found` | `404` | `not_found` | The provided path was invalid, or no resource was found with the specified reference
| `not_found` | `404` | `shipment_not_found` | A `shipment` with the provided reference could not be found
| `status_code_error` | `*` | `status_code_error` | An unexpected status code was returned.
| `unauthorised` | `401` | `invalid_api_key` | The API key was invalid or was not provided
| `unauthorised` | `401` | `missing_api_key_header` | The `x-api-key` header was not provided.
| `unauthorised` | `401` | `unauthorised` | The provided credentials were invalid
| `validation_error` | `400` | `-` | One or more validation errors occurred. The response body will include details of the invalid value(s).
| `validation_error` | `400` | `address_type_required` | You did not supply a required `address_type`. The detail will inform you as to the `address_type` that was missing.
| `validation_error` | `400` | `conflicting_properties` | The values of two or more properties conflict.
| `validation_error` | `400` | `date_in_past` | A provided date is in the past and is not valid for the current operation
| `validation_error` | `400` | `duplicate_address_type` | Your request included two or more addresses with the same `address_type` value.
| `validation_error` | `400` | `duplicate_metadata_key` | Your request included one or more duplicate `metadata` keys.
| `validation_error` | `400` | `duplicate_references` | One or more collections of references includes 2 or more duplicates.
| `validation_error` | `400` | `duplicate_tags` | One or more duplicate `tags` were provided
| `validation_error` | `400` | `duplicate_values` | A list that should contain unique properties included two or more duplicate values.
| `validation_error` | `400` | `invalid_accessibility` | The provided `accessibility` is not valid or not recognised.
| `validation_error` | `400` | `invalid_address_type` | The provided `address_type` is not valid or not recognised.
| `validation_error` | `400` | `invalid_carrier_service` | One or more provided carrier service references are not valid.
| `validation_error` | `400` | `invalid_category_type` | The value provided for `category_type` was invalid or not recognised.
| `validation_error` | `400` | `invalid_hazard_class` | The provided `hazard_class` is not valid or not recognised.
| `validation_error` | `400` | `invalid_contents_reference` | The provided contents reference is invalid
| `validation_error` | `400` | `invalid_country_code` | The value specified for `country_iso_code` is invalid or not recognised.
| `validation_error` | `400` | `invalid_cron_expression` | The provided CRON expression is invalid or does not meet the rules of SortedPRO
| `validation_error` | `400` | `invalid_currency` | The provided `currency` is not valid or not recognised.
| `validation_error` | `400` | `invalid_date_range` | The values in the provided `date_range` were not valid (e.g. the end precedes the start)
| `validation_error` | `400` | `invalid_dimension_unit` | The provided `dimension_unit` is invalid or not recognised.
| `validation_error` | `400` | `invalid_direction` | The value supplied was not a valid `direction`.
| `validation_error` | `400` | `invalid_email` | The provided email is not valid.
| `validation_error` | `400` | `invalid_format` | The supplied value did not match the required format.
| `validation_error` | `400` | `invalid_metadata_type` | The type provided for a `metadata` item was invalid or not recognised.
| `validation_error` | `400` | `invalid_package_size_reference` | The provided `package_size_reference` is invalid or was not found
| `validation_error` | `400` | `invalid_packing_group` | The value provided for `packing_group` was invalid or not recognised.
| `validation_error` | `400` | `invalid_physical_form` | The provided `physical_form` is not valid or not recognised.
| `validation_error` | `400` | `invalid_postal_code` | The provided `postal_code` is not valid or not recognised.
| `validation_error` | `400` | `invalid_radioactivity` | The provided `radioactivity` is not valid or not recognised.
| `validation_error` | `400` | `invalid_reference_format` | A provided reference was not in the correct format.
| `validation_error` | `400` | `invalid_region` | The provided region is not valid or not recognised.
| `validation_error` | `400` | `invalid_request` | There was an error in your request. The details property will provide further information.
| `validation_error` | `400` | `invalid_shipment_state` | One or more `shipment_state` values provided did not match a known or valid `shipment_state`.
| `validation_error` | `400` | `invalid_shipment_type` | The value supplied was not a valid shipment_type.
| `validation_error` | `400` | `invalid_shipping_terms` | The shipping_terms value provided was invalid or not recognised.
| `validation_error` | `400` | `invalid_state_for_operation` | The `state` provided is not valid for the current operation; e.g. you are attempting to allocate a manifested `shipment`
| `validation_error` | `400` | `invalid_sub_division` | The provided `sub_division` is not valid or not recognised.
| `validation_error` | `400` | `invalid_value` | The value provided for a property is not valid.
| `validation_error` | `400` | `invalid_weight_unit` | The provided `weight_unit` is invalid or not recognised.
| `validation_error` | `400` | `required_property_missing` | A required property was not provided or was provided without a value
| `validation_error` | `400` | `system_shipment_state` | You attempted to use a `shipment_state` that is reserved for system use.
| `validation_error` | `400` | `system_use_only` | You provided one or more properties that are reserved for system use only
| `validation_error` | `400` | `too_few_elements` | There were not enough elements in the collection. For example, where at least 2 addresses are required, you only provided one.
| `validation_error` | `400` | `too_many_elements` | There were too many elements in the collection. E.g. where 10 tags are permitted, you submitted 11 or more.
| `validation_error` | `400` | `unit_mismatch` | One or more unit values do not match or are incompatible
| `validation_error` | `400` | `value_too_large` | A provided value is larger than the permitted maximum.
| `validation_error` | `400` | `value_too_long` | The provided value was longer than the permitted maximum.
| `validation_error` | `400` | `value_too_short` | The provided value was shorted than the permitted minimum.
| `validation_error` | `400` | `value_too_small` | The provided value was smaller than the minimum permitted value
| `version_header_error` | `400` | `version_header_error` | The provided `x-api-version` was not valid.
| `version_header_missing` | `400` | `version_header_missing` | The `x-api-version` header was not provided.
| `validation_error` | `400` | `file_too_large` | The provided file was greater than the permitted maximum file size |
| `validation_error` | `400` | `non_unique_reference` | The provided reference matches more than one entity, e.g. it matches both a specific carrier service *and* and carrier service group when allocating with a "virtual" carrier service. |
| `validation_error` | `400` | `virtual_service_not_found` | The provided reference does not match *either* a carrier service or a carrier service group when allocating with a "virtual" carrier service . |