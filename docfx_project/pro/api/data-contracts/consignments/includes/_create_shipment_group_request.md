<div class="property">
    <div class="name">shipments</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">1..10,000</div>
    <div class="description">The reference(s) of the shipment(s) to be added to the group</div>
    <div class="validation">Required. Must contain at least one valid shipment reference. All references included must be valid existing shipment references. All shipments must be in a valid state</div>
</div>
<div class="property">
    <div class="name">custom_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The customer's own reference for this shipment_group</div>
    <div class="validation">Optional. If provided, length must be >= 5 and <= 50 characters. The reference must be unique within your account for open shipment_groups – you cannot have multiple open shipment_groups with the same custom_reference</div>
</div>