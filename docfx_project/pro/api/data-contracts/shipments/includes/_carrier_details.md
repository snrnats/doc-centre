<div class="property">
    <div class="name">reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The Sorted reference for this carrier</div>
    <div class="validation">Optional. If not provided in a request, service_reference must be provided. Will be provided in responses</div>
</div>
<div class="property">
    <div class="name">name</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The name of this carrier</div>
    <div class="validation">Optional. Will be provided in responses but is not required in requests</div>
</div>
<div class="property">
    <div class="name">service_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The Sorted reference for this carrier service. Customers will have a service_reference per account</div>
    <div class="validation">Optional. If not provided in a request, reference must be provided. Will be provided in responses</div>
</div>
<div class="property">
    <div class="name">service_name</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The friendly name for this carrier service</div>
    <div class="validation">Optional. Will be provided in responses but is not required in requests</div>
</div>
<div class="property">
    <div class="name">tags</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..n</div>
    <div class="description">Any tags that apply to this carrier service</div>
    <div class="validation">Optional. Will be provided in responses but it not applicable to requests</div>
</div>