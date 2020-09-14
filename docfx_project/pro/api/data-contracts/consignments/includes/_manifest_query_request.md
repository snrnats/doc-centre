<div class="property">
    <div class="name">shipping_locations</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..10</div>
    <div class="description">A list of shipping location references used to identify shipments. Only shipments originating from these location(s) will be selected</div>
    <div class="validation">Optional. If provided, must include valid existing shipping location references. If provided, must include at least 1 and no more than 10 shipping location references</div>
</div>
<div class="property">
    <div class="name">address_custom_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">A specific address reference used to identify shipments. When creating shipments, you can specify an optional custom_reference. Only shipments originating from matching addresses will be selected</div>
    <div class="validation">Optional. If provided, must be >= 1 and <= 50 characters</div>
</div>
<div class="property">
    <div class="name">shipment_states</div>
    <div class="type">list of <code>shipment_state</code> objects</div>
    <div class="occurs">0..5</div>
    <div class="description">A list of shipment_state. Only shipments in these states will be selected</div>
    <div class="validation">Optional. If provided, must contain only valid shipment_state and all shipment_state must be eligible for manifesting. A maximum of 5 states can be provided</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_shipment_state](_shipment_state.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">labels_retrieved</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">If provided, will only match shipments where labels have been retrieved. If not provided, this property will be ignored, and shipments will be matched regardless of whether labels have been retrieved or not</div>
    <div class="validation">Optional. If not provided, will default to null</div>
</div>
<div class="property">
    <div class="name">required_shipping_date</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">A date_range used to filter shipments with a matching required_shipping_date property. If provided, all shipments where the required_shipping_date range of the shipment is wholly within the provided range will be selected</div>
    <div class="validation">Optional</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">carrier_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The reference of the carrier to manifest with</div>
    <div class="validation">If carrier_reference and carrier_service_reference are both provided, they must be compatible</div>
</div>
<div class="property">
    <div class="name">carrier_service_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The reference of the carrier service to manifest with</div>
    <div class="validation">If carrier_reference and carrier_service_reference are both provided, they must be compatible</div>
</div>