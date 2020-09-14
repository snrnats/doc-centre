<div class="property">
    <div class="name">direction</div>
    <div class="type"><code>direction</code> object</div>
    <div class="occurs">1</div>
    <div class="description">The direction property of the carrier services to select</div>
    <div class="validation">Required. Must be a valid direction</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_direction](_direction.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">tags</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..10</div>
    <div class="description">Filters carrier services to exclude any services that do not have a 100% tag match. All tags will be considered, and a service must have all the provided tags</div>
    <div class="validation">Optional. If provided, must contain >= 1 and <= 10 tags.	</div>
</div>
<div class="property">
    <div class="name">pickup</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Indicates whether to include pick-up services or not (i.e. services where the consumer will collect the shipment from a location)</div>
    <div class="validation">Optional. Will default to false if not provided</div>
</div>
<div class="property">
    <div class="name">drop_off</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Indicates whether to include drop-off services or not (i.e. services where the consumer will receive the shipment to their location)</div>
    <div class="validation">Optional. Will default to true if not provided</div>
</div>