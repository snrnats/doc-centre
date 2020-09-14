<div class="property">
    <div class="name">code</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The error code that indicates why the collection of shipments was rejected for allocation</div>
</div>
<div class="property">
    <div class="name">message</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A plain text message describing the error code</div>
</div>
<div class="property">
    <div class="name">references</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">1..n</div>
    <div class="description">The list of shipment references that were rejected due to the specified code</div>
</div>