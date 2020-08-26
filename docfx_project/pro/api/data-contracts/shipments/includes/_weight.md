<div class="property">
    <div class="name"><code>value</code></div>
    <div class="type">

[!include[_datatype_decimal](_datatype_decimal.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The value in the specified units</div>
    <div class="validation">Required. Must be a valid positive decimal. Values are saved by SortedPRO with a precision of up to 5 decimal places</div>
</div>
<div class="property">
    <div class="name"><code>unit</code></div>
    <div class="type">weight_unit object</div>
    <div class="occurs">1</div>
    <div class="description">The unit of measurement</div>
    <div class="validation">Required. Must be a valid weight_unit. All units specified within a single shipment must be the same, i.e. you cannot combine weight_unit values within a single shipment.</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_weight_unit](_weight_unit.md)]
</div>
    </div>              
</div>