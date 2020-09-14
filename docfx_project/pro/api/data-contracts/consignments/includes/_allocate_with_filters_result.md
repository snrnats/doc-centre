<div class="property">
    <div class="name">reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A unique reference for this result</div>
</div>
<div class="property">
    <div class="name">shipments</div>
    <div class="type">list of<code>link</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Provides the references of (and links to) the shipments identified by the filters. Each shipment will have been submitted for allocation.</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_links](_links.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">message</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A plain-text message describing the result of the operation</div>
</div>