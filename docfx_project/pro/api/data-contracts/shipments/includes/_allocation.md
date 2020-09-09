<div class="property">
    <div class="name">carrier</div>
    <div class="type"><code>carrier_details</code> object</div>
    <div class="occurs">1</div>
    <div class="description">Details of the carrier and service to which this allocation is linked</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_carrier_details](_carrier_details.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">allocation_date</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The date and time at which this allocation was created</div>
</div>
<div class="property">
    <div class="name">price</div>
    <div class="type"><code>price</code> object</div>
    <div class="occurs">1</div>
    <div class="description">Details of the price for the allocation</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_price](_price.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">tracking_references</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..n</div>
    <div class="description">The tracking reference(s) assigned by the carrier for this shipment. Ordinarily, carriers will only ever assign a single reference. However, some carriers may assign multiple references</div>
</div>
<div class="property">
    <div class="name">links</div>
    <div class="type">list of <code>link</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Links to related resources, such as labels</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_links](_links.md)]
</div>
    </div>    
</div>