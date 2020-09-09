<div class="property">
    <div class="name">shipments</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">1..100</div>
    <div class="description">The references of the shipments to be allocated</div>
    <div class="validation">Required. At least one valid reference must be provided. A maximum of 100 shipments can be allocated at once using this method. This is to ensure continued optimal performance of the Sorted platform</div>
</div>
<div class="property">
    <div class="name">filters</div>
    <div class="type"><code>allocation_filters</code> object</div>
    <div class="occurs">1</div>
    <div class="description">A series of filters used to select one or more matching carrier services</div>
    <div class="validation">Required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_allocation_filters](_allocation_filters.md)]
</div>
    </div>    
</div>