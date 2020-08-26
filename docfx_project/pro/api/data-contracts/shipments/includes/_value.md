<div class="property">
    <div class="name"><code>amount</code></div>
    <div class="type">

[!include[_datatype_decimal](_datatype_decimal.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The amount in the specified units</div>
    <div class="validation">Required. Must be a valid positive decimal. Values are saved by SortedPRO with a precision of up to 5 decimal places</div>
</div>
<div class="property">
    <div class="name"><code>currency</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The ISO code of the currency (3 characters)</div>
    <div class="validation">Required. Must be a valid 3-character ISO code</div>
</div>
<div class="property">
    <div class="name"><code>discount_rate</code></div>
    <div class="type">

[!include[_datatype_decimal](_datatype_decimal.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Used to indicate the proportion of discount. A value of 100 indicates 100% discount</div>
    <div class="validation">Optional. If not provided, will default to 0. If provided, must be a valid decimal between 0 and 100 representing the percentage discount e.g. 10.5 means 10.5%</div>
</div>