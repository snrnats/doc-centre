<div class="property">
    <div class="name">address</div>
    <div class="type"><code>address</code> object</div>
    <div class="occurs">1</div>
    <div class="description">Allows you to identify shipments by their address</div>
    <div class="validation">Required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_address](_address.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">carrier</div>
    <div class="type"><code>carrier_details</code> object</div>
    <div class="occurs">1</div>
    <div class="description">Allows you to provide references to identify a carrier</div>
    <div class="validation">Required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_carrier_details](_carrier_details.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">shipment_states</div>
    <div class="type"><code>shipment_state</code> object</div>
    <div class="occurs">1..n</div>
    <div class="description">Identify one or more states to find matching shipments</div>
    <div class="validation">Required. Must contain at least one valid shipment_state</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_shipment_state](_shipment_state.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">labels_printed</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Allows you to filter shipments by whether or not labels have been printed</div>
    <div class="validation">Optional. Will default to null if not provided</div>
</div>
<div class="property">
    <div class="name">shipping_date</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">Allows you to filter by specific date/time windows</div>
    <div class="validation">Optional. If provided, the period must be within the same calendar day. If not provided, will default to the start of the current day to the current date and time (UTC)</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>