<div class="property">
    <div class="name"><code>length</code></div>
    <div class="type">

[!include[_datatype_decimal](_datatype_decimal.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The length in the specified units</div>
    <div class="validation">Required. Must be a valid positive decimal. Values are saved by SortedPRO with a precision of up to 5 decimal places. Length should be the longest of the three dimensions provided. Sorted will re-arrange dimensions if your request does not follow this rule</div>
</div>
<div class="property">
    <div class="name"><code>height</code></div>
    <div class="type">

[!include[_datatype_decimal](_datatype_decimal.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The height in the specified units</div>
    <div class="validation">Required. Must be a valid positive decimal</div>
</div>
<div class="property">
    <div class="name"><code>width</code></div>
    <div class="type">

[!include[_datatype_decimal](_datatype_decimal.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The width in the specified units</div>
    <div class="validation">Required. Must be a valid positive decimal</div>
</div>
<div class="property">
    <div class="name"><code>unit</code></div>
    <div class="type">dimension_unit object</div>
    <div class="occurs">1</div>
    <div class="description">The unit of measurement</div>
    <div class="validation">Required. Must be a valid dimension_unit. All units specified within a single shipment must be the same, i.e. customers cannot combine dimension_unit values within a single shipment</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_dimension_unit](_dimension_unit.md)]
</div>
    </div>              
</div>