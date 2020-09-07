<div class="property">
    <div class="name">state</div>
    <div class="type"><code>shipment_state</code> object</div>
    <div class="occurs">1</div>
    <div class="description">The state of the shipment following the request to allocate</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_shipment_state](_shipment_state.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">price</div>
    <div class="type"><code>price</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">The price of the allocation with this carrier and service</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_price](_price.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">message</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A plain-text message describing the result of the allocation attempt. This should not be used for application logic - use shipment_state to determine the success of the operation</div>
</div>
<div class="property">
    <div class="name">carrier</div>
    <div class="type"><code>carrier_details</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">Details of the carrier and service for the allocation. In the case of a failed allocation, this property may be null</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_carrier_details](_carrier_details.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">tracking_details</div>
    <div class="type"><code>tracking_details</code> object</div>
    <div class="occurs">0..n</div>
    <div class="description">The details of tracking reference(s) for this allocation. The tracking reference(s) are issued by the carrier (or by Sorted according to the carrier's conventions) following a successful allocation</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_tracking_details](_tracking_details.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">shipment_reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The reference of the shipment that this result relates to</div>
</div>
<div class="property">
    <div class="name">_links</div>
    <div class="type">list of <code>link</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Lists any related resources such as labels or the shipment</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_links](_links.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">excluded_services</div>
    <div class="type">list of <code>excluded_service</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Details of active services within your account that could not provide a quote, including the reason(s)</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_excluded_service](_excluded_service.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">shipping_date</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">The shipping date range for this allocation, if applicable</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">expected_delivery_date</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">The expected delivery date range for this allocation, if applicable</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">paperless_documents</div>
    <div class="type"><code>paperless_documents</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">Provides details of how to handle paperless documents, if applicable</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_paperless_documents](_paperless_documents.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">applicable_documents</div>
    <div class="type"><code>applicable_documents</code> object</div>
    <div class="occurs">0..n</div>
    <div class="description">Provides details of which documents (e.g. cn22) apply to the shipment</div>

    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_applicable_documents](_applicable_documents.md)]
</div>
    </div>    
</div>