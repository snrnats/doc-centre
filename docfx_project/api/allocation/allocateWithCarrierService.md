# Allocate With Carrier Service

`PUT https://api.electioapp.com/allocation/allocatewithcarrierservice`

Allocates one or more consignments to the specified carrier service.

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

The **Allocate With Carrier Service** request body contains an array of one or more `{consignmentReference}`s to be allocated and the `{MpdCarrierServiceReference}` of the carrier service that they should be allocated to. 

Once the request is received, SortedPRO attempts to allocate the consignments to the specified carrier service. It then returns an array of Allocation Summaries, one for each allocated consignment. 

If PRO is unable to allocate the consignment to the specified carrier service, it puts the consignment into a state of _Allocation Failed_ and takes no further action. For information on dealing with failed allocations, see the _Manage NOT SHIPPED Consignments_ section of the PRO UI User Manual.

<!-- Include for tab and copy scripts. DO NOT DELETE THE BELOW -->

[!include[scripts](../includes/scripts.md)]