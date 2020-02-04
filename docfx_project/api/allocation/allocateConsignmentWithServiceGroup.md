# Allocate Consignment With Service Group

`PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithservicegroup/{mpdCarrierServiceGroupReference}`

Allocates the specified consignment to the cheapest available carrier service in a particular carrier service group

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

SortedPRO carrier service groups are user-defined pools of carrier services that help you allocate your consignments to the best possible service. For example, you might set up a group containing all services that will ship dangerous goods. You would then allocate within that group for all consignments involving dangerous items. 

The **Allocate Consignment With Service Group** endpoint takes the `{consignmentReference}` of the consignment you want to allocate and the `{mpdCarrierServiceGroupReference}` of the service group you want to allocate from as path parameters, and returns an Allocation Summary with details of the service that was allocated. 

> <note class="note-header">Note:</span>
>
> To configure carrier service groups, use the <strong><a href="https://www.electioapp.com/Configuration/CarrierServiceGroups">Configuration - Carrier Service Groups</a></strong> UI page. 

The `{mpdCarrierServiceGroupReference}` is a unique identifier for each carrier service group. To find the `{mpdCarrierServiceGroupReference}` for a particular group, log in to the PRO UI, navigate to the **[Configuration - Carrier Service Groups](https://www.electioapp.com/Configuration/CarrierServiceGroups)** page, and locate the tile for that group. The `{mpdCarrierServiceGroupReference}` is shown in the **Code** field.

<!-- Include for tab and copy scripts. DO NOT DELETE THE BELOW -->

[!include[scripts](../includes/scripts.md)]