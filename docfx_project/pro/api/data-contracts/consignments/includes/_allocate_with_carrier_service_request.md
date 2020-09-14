<div class="property">
    <div class="name">shipments</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">1..100</div>
    <div class="description">The reference(s) of the shipment(s) to be allocated</div>
    <div class="validation">Required. At least one valid reference must be provided. A maximum of 100 shipments can be allocated at once using this method. This is to ensure continued optimal performance of the Sorted platform</div>
</div>
<div class="property">
    <div class="name">carrier_service_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The reference of the carrier service to allocate the shipments with</div>
    <div class="validation">Required. Must be a valid reference for an existing carrier_service within your account</div>
</div>
<div class="property">
    <div class="name">capabilities</div>
    <div class="type"><code>service_capabilities</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">Any specific capabilities that are required as part of the allocation</div>
    <div class="validation">Optional</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_service_capabilities](_service_capabilities.md)]
</div>
    </div>    
</div>