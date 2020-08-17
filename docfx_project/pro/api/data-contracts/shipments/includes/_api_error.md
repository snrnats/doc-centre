This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
<div class="dc-column">

| Property | Type | Description | Occurrence |
| -------- | ---- | ----------- | :--------: |
| `correlation_id` | `string` | A unique reference for this error. Customers can use this when reporting errors to Sorted, if applicable | `1` |
| `code` | `string` | A pre-defined code for this error. See [API Error Codes](../error-codes.md). | `1` |
| `message` | `string` | A plain text summary of the error. | `1` |
| `details` | List of [`api_error_message`](#api-error-message) | A collection of `api_error_messages` which provide further details of the error(s) if applicable. | `0..n` |
| `_links` | List of [`link`](#link) | Provides `links` to further relevant information of operations, if applicable. | `0..n` |

</div>
<div class="dc-column">

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

</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.