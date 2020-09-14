<div class="property">
    <div class="name">class_division</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The class division of the goods according to the IATA standards e.g. 2 (Gas)</div>
    <div class="validation">Required. Must be a valid IATA class division</div>
</div>
<div class="property">
    <div class="name">class_sub_divisions</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..10</div>
    <div class="description">The sub-division(s) according to the IATA standards. E.g. 1 combined with a class_division of 1 results in an overall class_division of 2.1 (flammable gas)</div>
    <div class="validation">Optional. If provided, must be a valid sub-division of the class provided in class_division</div>
</div>