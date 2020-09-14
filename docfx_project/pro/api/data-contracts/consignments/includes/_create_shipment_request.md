
<div class="property">
    <div class="name"><code>custom_reference</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Custom reference provided by the customer</div>
    <div class="validation">Optional. If provided, limited to 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>required_delivery_date</code></div>
    <div class="type"><code>date_range</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">A date range used to specify the required delivery date</div>
    <div class="validation">Optional</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>
</div>
<div class="property">
    <div class="name"><code>required_shipping_date</code></div>
    <div class="type"><code>date_range</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">A date range used to specify the required shipping date</div>
    <div class="validation">Optional</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>        
</div>
<div class="property">
    <div class="name"><code>tags</code></div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..10</div>
    <div class="description">Custom tags to apply to the shipment</div>
    <div class="validation"> Optional. If provided, each tag is limited to 50 characters and there is a limit of 10 tags per shipment</div>
</div>
<div class="property">
    <div class="name"><code>order_date</code></div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The date that the items in the `shipment` were ordered. This can be used to track `shipments` vs. order dates in customers' own systems.</div>
    <div class="validation"> Optional. If provided, must be a valid ISO8601 date time including offset. Sorted will not validate the logic of the date compared to other relevant dates.</div>
</div>
<div class="property">
    <div class="name"><code>metadata</code></div>
    <div class="type">List of <code>metadata</code> objects</div>
    <div class="occurs">0..10</div>
    <div class="description">Additional properties to apply to a `shipment`. Additional functionality can be linked to properties specified in `metadata`</div>
    <div class="validation">Optional. A maximum of 10 `metadata` values can be provided per `shipment</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_metadata](_metadata.md)]
</div>
    </div>               
</div> 
<div class="property">
    <div class="name"><code>customs_documentation</code></div>
    <div class="type"><code>customs_documentation</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">Properties used to generate customs document(s) for this `shipment`</div>
    <div class="validation">Optional</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_customs_documentation](_customs_documentation.md)]
</div>           
    </div>
</div> 
<div class="property">
    <div class="name"><code>direction</code></div>
    <div class="type"><code>direction</code> property</div>
    <div class="occurs">0..1</div>
    <div class="description">Indicates the `direction` of the `shipment`</div>
    <div class="validation">Optional. Will default to `outbound` if not specified</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_direction](_direction.md)]
</div>           
    </div>            
</div>
<div class="property">
    <div class="name"><code>shipment_type</code></div>
    <div class="type"><code>shipment_type</code> property</div>
    <div class="occurs">1</div>
    <div class="description">Indicates the type of `shipment`</div>
    <div class="validation">Required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_shipment_type](_shipment_type.md)]
</div>           
    </div>             
</div> 
<div class="property">
    <div class="name"><code>contents</code></div>
    <div class="type">List of <code>shipment_contents</code> objects</div>
    <div class="occurs">1..n</div>
    <div class="description">The contents of the `shipment`</div>
    <div class="validation">At least one `shipment_contents` required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_shipment_contents](_shipment_contents.md)]
</div>           
    </div>               
</div> 
<div class="property">
    <div class="name"><code>addresses</code></div>
    <div class="type">List of <code>address</code> objects</div>
    <div class="occurs">2..n</div>
    <div class="description">The addresses for this `shipment`</div>
    <div class="validation">Required. Must contain at least an `origin` and `destination` address</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_address](_address.md)]
</div>           
    </div>              
</div> 
<div class="property">
    <div class="name"><code>label_properties</code></div>
    <div class="type">List of <code>label_property</code> objects</div>
    <div class="occurs">0..10</div>
    <div class="description">Values to be used in the generation or decoration of labels</div>
    <div class="validation">Optional</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_label_property](_label_property.md)]
</div>           
    </div>              
</div> 
<div class="property">
    <div class="name"><code>source</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>            
    <div class="description"> Indicates the source of the `shipment`</div>
    <div class="validation">Optional. If not provided, will default to `api`. If provided, maximum length is 50 characters</div>
</div> 
<div class="property">
    <div class="name"><code>tenant</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>            
    <div class="description">Indicates the tenant that the `shipment` belongs to</div>
    <div class="validation">Optional. If provided, must be a valid pre-existing `tenant` reference for the customer</div>
</div>
<div class="property">
    <div class="name"><code>channel</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Indicates the channel for the `shipment`</div>
    <div class="validation">Optional. If provided, must be a valid pre-existing `channel` for the provided `tenant`. Must **only** be provided when `tenant` is provided</div>
</div>                         