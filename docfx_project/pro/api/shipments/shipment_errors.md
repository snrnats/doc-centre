---
uid: pro-api-shipments-shipment-errors
title: Shipment Error Codes
tags: v2,pro,api,shipments,errors
contributors: andy.walton@sorted.com
created: 07/10/2020
---
# Shipment Error Codes

Errors in SortedPRO can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing. This section provides an explanation of the PRO API error object and a reference list of the errors that PRO can return.

> [!NOTE]
> This page provides help and support for PRO version 2 (Shipments). As PRO v2 is currently in development, content may be removed or edited without warning.
>
> For support on PRO v1 (Consignments), [click here](/pro/api/help/introduction.html).  

---

## Error Structure in PRO

Errors codes in PRO have two levels - a top-level code corresponding to standard HTTP error codes and a "child" code giving more detail on the specifics of the problem.

> [!NOTE]
> For a detailed breakdown of the error codes that PRO can return, see the [List of Error Codes](#list-of-error-codes) section.

When an API request encounters an error, PRO returns an API Error object. The API Error object contains the following information:

* `correlation_id` - A unique reference for the error.
* `code` - The top-level error code.
* `message ` - A plain-text message explaining the top-level error code returned. 
* `details` - An object indicating the affected shipment `property` (where applicable), child error `code`, and an explanatory `message`.
* `links` - Links to relevant resources.

> [!NOTE]
> The explanatory `message` properties should not be considered part of PRO's data contract and no logic should be programmed against them, as they are subject to change at any time.

### Example API Error Object

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

## List of Error Codes

PRO can return the following error codes:

### 531

* [531 - No Quotes Available](errors/531_no_quotes_available.md)    

### 521

* [521 - Allocation Failed](errors/521_allocation_failed.md)
* [521 - Carrier Service Not Found    ](errors/521_carrier_service_not_found.md)
* [521 - Carrier Service Shipment Mismatch](errors/521_carrier_service_shipment_mismatch.md)
* [521 - Shipment Invalid State](errors/521_shipment_invalid_state.md)
* [521 - Shipment Not Found](errors/521_shipment_not_found.md)

### 500

* [500 - Internal Server Error](errors/500_internal_server_error.md)   

### 429

* [429 - Rule Conflict](errors/429_rule_conflict.md)

### 410

* [410 - Resource Quarantined](errors/410_resource_quarantined.md)
* [410 - Resource Removed](errors/410_resource_removed.md)

### 405

* [405 - Method Not Supported](errors/405_method_not_supported.md)

### 404

* [404 - Not Found](errors/404_not_found.md)
* [404 - Shipment No Found](errors/404_shipment_not_found.md)
* [404 - Processing](errors/404_processing.md)

### 401

* [401 - Invalid API Key](errors/401_invalid_api_key.md)
* [401 - Missing API Key Header](errors/401_missing_api_key_header.md)
* [401 - Unauthorised](errors/401_unauthorised.md)

### 400

* [400 - Validation Error](errors/400_validation_error.md)
* [400 - Address Type Required](errors/400_address_type_required.md)
* [400 - Conflicting Properties](errors/400_conflicting_properties.md)
* [400 - Date In Past](errors/400_date_in_past.md)
* [400 - Duplicate Address Type](errors/400_duplicate_address_type.md)
* [400 - Duplicate Metadata Key](errors/400_duplicate_metadata_key.md)
* [400 - Duplicate References](errors/400_duplicate_references.md)
* [400 - Duplicate Tags](errors/400_duplicate_tags.md)
* [400 - Duplicate Values](errors/400_duplicate_values.md)
* [400 - Invalid Accessibility](errors/400_invalid_accessibility.md)
* [400 - Invalid Address Type](errors/400_invalid_address_type.md)
* [400 - Invalid Carrier Service](errors/400_invalid_carrier_service.md)
* [400 - Invalid Category Type](errors/400_invalid_category_type.md)
* [400 - Invalid Hazard Class](errors/400_invalid_hazard_class.md)
* [400 - Invalid Contents Reference](errors/400_invalid_contents_reference.md)
* [400 - Invalid Country Code](errors/400_invalid_country_code.md)
* [400 - Invalid Cron Expression](errors/400_invalid_cron_expression.md)
* [400 - Invalid Currency](errors/400_invalid_currency.md)
* [400 - Invalid Date Range](errors/400_invalid_date_range.md)
* [400 - Invalid Dimension Unit](errors/400_invalid_dimension_unit.md)
* [400 - Invalid Direction](errors/400_invalid_direction.md)
* [400 - Invalid Email](errors/400_invalid_email.md)
* [400 - Invalid Format](errors/400_invalid_format.md)
* [400 - Invalid Metadata Type](errors/400_invalid_metadata_type.md)
* [400 - Invalid Package Size Reference](errors/400_invalid_package_size_reference.md)
* [400 - Invalid Packing Group](errors/400_invalid_packing_group.md)
* [400 - Invalid Physical Form](errors/400_invalid_physical_form.md)
* [400 - Invalid Postal Code](errors/400_invalid_postal_code.md)
* [400 - Invalid Radioactivity](errors/400_invalid_radioactivity.md)
* [400 - Invalid Reference Format](errors/400_invalid_reference_format.md)
* [400 - Invalid Region](errors/400_invalid_region.md)
* [400 - Invalid Request](errors/400_invalid_request.md)
* [400 - Invalid Shipment State](errors/400_invalid_shipment_state.md)
* [400 - Invalid Shipment Type](errors/400_invalid_shipment_type.md)
* [400 - Invalid Shipping Terms](errors/400_invalid_shipping_terms.md)
* [400 - Invalid State For Operation](errors/400_invalid_state_for_operation.md)
* [400 - Invalid Sub Division](errors/400_invalid_sub_division.md)
* [400 - Invalid Value](errors/400_invalid_value.md)
* [400 - Invalid Weight Unit](errors/400_invalid_weight_unit.md)
* [400 - Required Property Missing](errors/400_required_property_missing.md)
* [400 - System Shipment State](errors/400_system_shipment_state.md)
* [400 - System Use Only](errors/400_system_use_only.md)
* [400 - Too Few Elements](errors/400_too_few_elements.md)
* [400 - Too Many Elements](errors/400_too_many_elements.md)
* [400 - Unit Mismatch](errors/400_unit_mismatch.md)
* [400 - Value Too Large](errors/400_value_too_large.md)
* [400 - Value Too Long](errors/400_value_too_long.md)
* [400 - Value Too Short](errors/400_value_too_short.md)
* [400 - Value Too Small](errors/400_value_too_small.md)
* [400 - Version Header Error](errors/400_version_header_error.md)
* [400 - Version Header Missing](errors/400_version_header_missing.md)
* [400 - File Too Large](errors/400_file_too_large.md)
* [400 - Non-Unique Reference](errors/400_non_unique_reference.md)
* [400 - Virtual Service Not Found](errors/400_virtual_service_not_found.md)

### Status Code Error

* [Status Code Error](errors/status_code_error.md)
  
