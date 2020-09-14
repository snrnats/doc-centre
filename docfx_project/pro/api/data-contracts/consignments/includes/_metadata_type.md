<div class="property">
    <div class="name"><code>string</code></div>
    <div class="description">The metadata value is a string. The provided value must have a length between 1 and 100 inclusive. No further validation will be performed on the provided value</div>
</div>
<div class="property">
    <div class="name"><code>bool</code></div>
    <div class="description">The metadata value indicates a boolean value. The provided value must be one of true | false. The value can be provided in any case (e.g. FALSE, false, False) but will be converted to lowercase by SortedPRO when saved</div>
</div>
<div class="property">
    <div class="name"><code>date_time_offset</code></div>
    <div class="description">The metadata value is an ISO8601 Date Time (including offset). The provided value will be validated to ensure that it is a valid ISO8601 Date Time value</div>
</div>
<div class="property">
    <div class="name"><code>integer</code></div>
    <div class="description">The metadata value is an integer. The provided value will be validated to ensure that is it a valid integer between -2,147,483,648 and 2,147,483,647</div>
</div>
<div class="property">
    <div class="name"><code>decimal</code></div>
    <div class="description">	The metadata value is a decimal. The provided value will be validated to ensure that it is a valid decimal number</div>
</div>
<div class="property">
    <div class="name"><code>url</code></div>
    <div class="description">A URL provided as a string</div>
</div>