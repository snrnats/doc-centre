<div class="property">
    <div class="name"><code>href</code></div>
    <div class="type">string</div>
    <div class="occurs">1</div>
    <div class="description">The URL of the resource</div>
</div>
<div class="property">
    <div class="name"><code>rel</code></div>
    <div class="type">string</div>
    <div class="occurs">1</div>
    <div class="description">A string representing the relationship of the linked resource to the current resource. For example, a link to a shipment will have a value of shipment. Links to the current object will have a rel of self</div>
</div>
<div class="property">
    <div class="name"><code>reference</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">When a link is a pointer to a resource with a unique reference, this property will contain the reference. For instance, a link for a shipment will contain the shipment's reference in this field indicates whether the object has a value or not</div>
</div>
<div class="property">
    <div class="name"><code>type</code></div>
    <div class="type">string</div>
    <div class="occurs">1</div>
    <div class="description">The type of resource that this link points to</div>
    <div class="dropdown">
        <button onclick="dropFunction('links_typeChild')" class="dropbtn">Show available values</button>
        <div id="links_typeChild" class="dropdown-content">

[!include[_resource_type](_resource_type.md)]
</div>
    </div>    
</div>