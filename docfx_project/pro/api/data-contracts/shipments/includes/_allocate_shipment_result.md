<div class="property">
    <div class="name">message</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A plain text message describing the result of the operation</div>
</div>
<div class="property">
    <div class="name">queued</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..n</div>
    <div class="description">The references of the shipments that have been successfully queued for allocation</div>
</div>
<div class="property">
    <div class="name">rejected</div>
    <div class="type">list of <code>allocation_rejection</code></div>
    <div class="occurs">0..n</div>
    <div class="description">Details of shipments that have been rejected for allocation</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_allocation_rejection](_allocation_rejection.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">_links</div>
    <div class="type">list of <code>link</code></div>
    <div class="occurs">0..n</div>
    <div class="description">Links to any relevant resources</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_links](_links.md)]
</div>
    </div>    
</div>
