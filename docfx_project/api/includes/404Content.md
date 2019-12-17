<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <td>Code</td>
        <td>string</td>
        <td>The PRO error code returned. Note that this is an internal code, and not a HTTP status code</td>
        <td>1</td>
    </tr>
    <tr>
        <td>Message</td>
        <td>string</td>
        <td>An explanation of the error code</td>
        <td>1</td>
    </tr>
    <tr>
        <td>CorrelationId</td>
        <td>string</td>
        <td>A unique identifier for the individual error</td>
        <td>1</td>
    </tr>
</table>

<div class="copyheader">
    
<h3>Example</h3>
<div class="copybutton" onclick="CopyToClipboard('400example')">Click to Copy</div>

</div>

<div id="400example" class="copycontent" onclick="CopyToClipboard('400example')">

```json
{
  "Code": "SampleErrorCode",
  "Message": "Item {reference} not found",
  "CorrelationId": "f94c7dbc-c542-40b9-b6da-bd98aa110939"
}
```