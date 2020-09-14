<div class="property">
    <div class="name">reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The unique reference for this manifest</div>
</div>
<div class="property">
    <div class="name">shipments</div>
    <div class="type">list of <code>shipment_state_summary</code> objects</div>
    <div class="occurs">1..n</div>
    <div class="description">Provides the shipment reference and current state of the shipment</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_shipment_state_summary](_shipment_state_summary.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">created</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The date and time that the manifest was created</div>
</div>