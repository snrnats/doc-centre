---
uid: react-help-error-codes
title: Error Codes
tags: react,api,errors,codes
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Error Codes

This page lists the errors that REACT's APIs can return and suggests potential fixes. For an explanation of the structure of the error response itself, see the [REACT Error Structure](/react/help/error-codes.html#react-error-structure) section.

---

## 400 - Validation Error

* **Parent Error Code** - `validation_error`
* **Parent Error Message** - "One or more validation error(s) occurred."

### Child Errors

| Error Code                   | Message                                                                                                                                                                                                  | How to Resolve                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| property\_invalid_empty       | "{PropertyName} must not be empty." <p>Returned by **Register Shipments** and **Update Shipment**</p>                                                                                                    | Returned when REACT receives a request in which a mandatory property has been left empty. Enter a value for the relevant property.                                                                                                                                                                                                              |
| property\_invalid_null        | "{PropertyName} must not be null." <p>Returned by **Register Shipments** and **Update Shipment**</p>                                                                                                     | Returned when REACT receives a request in which a mandatory property has been set to null. Enter a value for the relevant property.                                                                                                                                                                                                             |
| parameter_missing            | "At least one value for Tracking Reference or Custom Reference should be provided." <p>Returned by **Get Shipments**</p>                                                                                 | Returned when REACT receives a request in which neither `tracking_references` or `custom_references` have been provided. Enter a value for `tracking_references`, `custom_references`, or both.                                                                                                                                         |
| parameter_missing            | “Please provide both date range parameters or none of them.” <p>Returned by **Get Shipment Events**</p>                                                                      | Returned when REACT receives a request that has a `start` date but no `end` date, or vice versa. Date searches cannot be open-ended. Either enter a value for both `start` and `end`, or remove both parameters.                                                                                                                                              |
| parameter_missing            | "At least one search parameter should be provided." <p>Returned by all GET endpoints</p>                                                                                                                 | Returned when REACT receives a request that does not have any search parameters. Enter at least one parameter and re-send the request.                                                                                                                                                                                                          |
| parameter_missing            | "The shipment_id must be provided." <p>Returned by the **Get Tracking Events by Shipment ID** endpoint</p>                                                                                                                 | Returned when REACT receives a **Get Tracking Events by Shipment ID** request that does not have a shipment `id` path parameter. Re-send the request in the format `GET https://api.sorted.com/react/tracking/search?id`, where `id` is the REACT ID of the shipment you want to search on.                                                                                                                                                                                                          |
| invalid\_date_range           | "The difference between start and end dates should not exceed 14 days." <p>Returned by **Get Shipment Events**</p>                                                           | Returned when REACT receives a request with `start` and `end` dates that are more than 14 days apart. Enter start and end dates that are within 14 days of each other.                                                                                                                                                                          |
| invalid_format               | "Format of the data provided is invalid." <p>Returned by **Register Shipments**, **Update Shipments** and **Get Shipment Events**</p> | Returned when REACT receives a request in which the data entered into a particular property is of the wrong type (for example, a string entered into an INT property). Enter data in the format that the property accepts. For a list of the data formats accepted by each property, see the [API Reference](https://docs.sorted.com/react/api). |
| invalid\_date_format          | "“Format of the date provided is invalid. Must be in the format `YYYY-MM-DDThh:mm:ss+|-hh:mm1`” | Ensure that all dates are entered in the format `YYYY-MM-DDThh:mm:ss+|-hh:mm` and re-send the request.                                                                                                                                                                                                                                                                                                            |
| too\_short_value              | "The length of {PropertyName} must be at least {MinLength} characters. You entered {TotalLength} characters." <p>Returned by **Register Shipments** and **Update Shipment**</p>                          | Returned when REACT receives a request in which a particular property is shorter than the minimum length for that property. Enter a string that is longer than the minimum length for the property.                                                                                                                           |
| too\_long_value               | "The length of {PropertyName} must be {MaxLength} characters or fewer. You entered {TotalLength} characters." <p>Returned by **Register Shipments** and **Update Shipment**</p>                          | Returned when REACT receives a request in which a particular property is longer than the maximum length for that property. Enter a string that is shorter than the maximum length for the property.                                                                                                                           |
| too\_small_value              | "The value of '{PropertyName}' must be at least {ComparisonValue}. You entered {PropertyValue}."                                                                                                         | Returned when REACT receives a request in which a particular property is shorter than the minimum length for that property. Enter a string that is longer than or equal to the minimum length for the property.                                                                                                               |
| too\_big_value                | "The value of '{PropertyName}' must be {ComparisonValue} or less. You entered {PropertyValue}."                                                                                                          | Returned when REACT receives a request in which a particular property is longer than the maximum length for that property. Enter a string that is shorter than or equal to the maximum length for the property.
| invalid_length                | "{PropertyName} must be {ExactLength} characters in length. You entered {TotalLength} characters."                                                                                                          | Returned when REACT receives a request in which the data entered into a particular property does not match the exact length required for that property. Enter a string of the required length.                                                                                                                 |
| duplicate\_address_type       | "Only one shipment address of each type is allowed." <p>Returned by **Register Shipments** and **Update Shipment**</p>                                                                                   | Returned when REACT receives a request that contains two addresses of the same `address_type`. Ensure that each address in the request has a unique `address_type`.                                                                                                                                                                             |
| duplicate\_metadata_key       | "Each metadata key provided should be unique within a shipment." <p>Returned by **Register Shipments** and **Update Shipment**</p>                                                                       | Returned when REACT receives a request containing two metadata items with the same `key`. Ensure that each metadata item in the request has a unique `key`.                                                                                                                                                                                  |
| incorrect\_number\_of_elements | "{PropertyName} must contain {ElementsExactCount} items. The list contains {TotalElements} element(s)." <p>Returned by **Register Shipments** and **Update Shipment**</p>                                | Returned when REACT receives a request in which a particular array does not contain the required number of elements. Enter the required number of elements.                                                                                                                                                                 |
| incorrect\_range\_of_elements  | "{PropertyName} must contain more than {MinElements} and less than {MaxElements} items. The list contains {TotalElements} element(s)." <p>Returned by **Register Shipments** and **Update Shipment**</p> | Returned when REACT receives a request in which the number of elements in a particular array is not within the acceptable range for that property. Enter a number of elements that is within the required range.                                                                                                                                |
| incorrect\_id_format          | _Message varies per resource_ <p>Returned by all endpoints</p>                                                                                                                                           | Returned when REACT receives a request for a resource ID that is not in the correct format (for example, a Shipment resource that does not begin with the prefix "sp\_"). Enter a valid resource ID.                                                                                                                                            |

## 401 - Unauthorized

* **Parent Error Code** - `unauthorized`
* **Parent Error Message** - “Provided credentials are invalid.”

### Child Errors

| Error Code      | Message                                                            | How to Resolve                                                                                   |
| --------------- | ------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------ |
| api\_key_invalid | “Access denied due to missing subscription key. Make sure to include subscription key when making requests to an API.” <p>Returned by all endpoints</p> | Returned when REACT receives a request that does not have a valid API key in the header. Ensure that your request includes an `x-api-key` header with a valid REACT API key as its value. |

## 404 - Not Found

* **Parent Error Code** - `not_found`
* **Parent Error Message** - “No {ResourceName} with the id {ResourceId} could be found.”

### Child Errors

| Error            | Message                                                                                   | How to Resolve                                                                                                                                                  |
| ---------------- | ----------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| resource_missing | 1. “No {ResourceName} with the id {ResourceId} could be found”<p>2. “No data found based on the parameters provided.”</p><p>Returned by all endpoints except **Register Shipments**</p> | Returned when REACT receives a request for a resource that could not be found.</p>  |

## 500 - Internal

* **Parent Error Code** - `server_error`
* **Parent Error Message** - "Internal server error occurred."

### Child Errors

| Error    | Message                                                                                                                                                     | How to Resolve |
| -------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------- |
| Internal | “It’s broken but it’s not your fault. Please try again or feel free to contact support@sorted.com if the problem persists.”<p>Returned by all endpoints</p> | Returned in the event of a server error. Retry or contact the email address provided.     |

## REACT Error Structure

REACT errors are split into parent and child error codes. The parent error indicates the HTTP error code that was returned, while the child error is a REACT-specific error intended to give more detail on the source of the problem.

The error object contains the following information:

* **ID** - A unique identifier for the error.
* **Code** - The "parent" error code (e.g. *400 - Validation Error*).
* **Message** - A summary of the error.
* **CorrelationId** - A unique identifier to correlate this error with any other related errors.
* **Details.Property** - The path to the affected property, where applicable.
* **Details.Code** - The "child" error (e.g. *Incorrect Number of Elements*).
* **Details.Message** - A message providing further details on the error.
* **Links** - A link to the information presented on the previous section of this page.

### Example Validation Error

# [Code 400 Error](#tab/code-400-error)

```json
{
  "id": "er_2287452498019024896",
  "code": "validation_error",
  "message": "One or more validation error(s) occurred.",
  "correlation_id": "0HLJHA9CG61RM:00000001",
  "details": [
    {
      "property": "tracking_references",
      "code": "property_invalid_empty",
      "message": "'tracking_references' must not be empty."
    },
    {
      "property": "tracking_references",
      "code": "incorrect_number_of_elements",
      "message":
        "'tracking_references' must contain 1 items. The list contains 0 element(s)."
    }
  ],
  "links": [
    {
      "href": "https://docs.sorted.com/react/error-codes/",
      "rel": "Error codes"
    }
  ]
}
```
---

## Next Steps

Learn more about integrating with REACT:

* [Registering Shipments](/react/help/registering-shipments.html)
* [Retrieving Shipment and Event Data](/react/help/retrieving-data.html)
* [Updating Shipments](/react/help/updating-shipments.html)