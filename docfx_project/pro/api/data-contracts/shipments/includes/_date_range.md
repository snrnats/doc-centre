<div class="property">
    <div class="name">start</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The start of the date period, inclusive</div>
    <div class="validation">Optional. If provided, must be prior to or equal to the end</div>
</div>
<div class="property">
    <div class="name">end</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The end of the date period, inclusive</div>
    <div class="validation">Optional. If provided, must be later than or equal to the start</div>
</div>
<div class="property">
    <div class="name">has_value</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">Indicates whether the object has a value or not</div>
    <div class="validation">Not applicable to requests</div>
</div>