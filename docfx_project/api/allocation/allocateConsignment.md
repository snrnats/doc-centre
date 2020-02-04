# Allocate Consignment

`PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote`

Allocates a single consignment to the cheapest eligible carrier service.

## Request

<div class="tab">
    <button class="requestTabLinks" onclick="openRequestTab(event, 'headers')">Headers</button>
    <button class="requestTabLinks" onclick="openRequestTab(event, 'path')" id="defaultRequest">Path (delete if not required)</button>
    <button class="requestTabLinks" onclick="openRequestTab(event, 'body')">Body (delete if not required)</button>
</div>

<div id="headers"  class="requestTabContent">

[!include[apiheaders](../includes/apiheaders.md)]

</div>

<div id="path"  class="requestTabContent">

<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Validation</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Validation</th>
        <th>Occurrence</th>
    </tr>
</table> 

<div class="copyheader">

### Example
<div class="copybutton" onclick="CopyToClipboard('pathExample')">Click to Copy</div>

</div>

<div id="pathExample" class="copycontent"onclick="CopyToClipboard('pathExample')">

```
[Example endpoint path in here]
```
</div>

</div>

<div id="body"  class="requestTabContent">

<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Validation</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Validation</th>
        <th>Occurrence</th>
    </tr>
</table> 

<div class="copyheader">

### Example
<div class="copybutton" onclick="CopyToClipboard('bodyExample')">Click to Copy</div>

</div>

<div id="bodyExample" class="copycontent"onclick="CopyToClipboard('bodyExample')">

```
[Example request body in here]
```
</div>

</div>

## Responses

<div class="tab">
  <button class="responseTabLinks" onclick="openCity(event, '200')" id="defaultResponse">200 (OK)</button>
  <button class="responseTabLinks" onclick="openCity(event, '404')">404 (Not Found)</button>
</div>

<div id="200"  class="responseTabContent">

<table>
    <tr>
        <th>Property</th>
        <th>Type</th>
        <th>Description</th>
        <th>Occurrence</th>
    </tr>
    <tr>
        <td>Property</td>
        <td>Type</td>
        <td>Description</td>
        <td>Occurrence</td>
    </tr> 
</table> 

<div class="copyheader">
    
<h3>Example</h3>
<div class="copybutton" onclick="CopyToClipboard('200example')">Click to Copy</div>

</div>

<div id="200example" class="copycontent" onclick="CopyToClipboard('200example')">

```
[Example 200 response]
```
</div>

</div>

<div id="404"  class="responseTabContent">

[!include[404Content](../includes/404Content.md)]

</div>

</div>

## More Information

The **Allocate Consignment** endpoint uses Carrier Service Rules to determine which carrier services are eligible for a particular consignment. Carrier Service Rules enable you to configure business rules - such as physical package size, consignment value, and geographical availability - against individual carrier services. You can configure them via the  <a href="https://www.electioapp.com/Configuration/EditCarrierService/acceptanceTestCarrier_f8fe"><strong>Manage Carrier Service Rules</strong></a> page of the PRO UI. 

> <span class="note-header">Note:</span>
> For more information on configuring allocation rules, see the _Configure Allocation Rules_ section of the PRO Admin Portal User Guide.

<!-- Include for tab and copy scripts. DO NOT DELETE THE BELOW -->

[!include[scripts](../includes/scripts.md)]