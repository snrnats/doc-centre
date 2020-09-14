<div class="property">
    <div class="name">reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The unique reference for this ruleset provided by Sorted</div>
</div>
<div class="property">
    <div class="name">description</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The description for this ruleset set by the customer</div>
</div>
<div class="property">
    <div class="name">validity</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">The validity period for this ruleset, if applicable</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">active</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">Indicates whether this ruleset is active or not</div>
</div>
<div class="property">
    <div class="name">linked_carrier_services</div>
    <div class="type">

[!include[_datatype_integer](_datatype_integer.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The number of carrier services that this ruleset is linked to</div>
</div>