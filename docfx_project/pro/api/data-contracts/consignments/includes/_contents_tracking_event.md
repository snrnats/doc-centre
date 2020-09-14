<div class="property">
    <div class="name">reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The unique reference of the shipment_contents that these events relate to</div>
</div>
<div class="property">
    <div class="name">custom_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The customer's own custom_reference for the shipment_contents, if applicable</div>
</div>
<div class="property">
    <div class="name">carrier_references</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">1..n</div>
    <div class="description">The tracking reference(s) provided by the carrier</div>
</div>
<div class="property">
    <div class="name">events</div>
    <div class="type">list of <code>tracking_event</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">The tracking event(s) for this shipment_contents</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_tracking_event](_tracking_event.md)]
</div>
    </div>    
</div>