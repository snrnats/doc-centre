<div class="property">
    <div class="name"><code>hazard_classes</code></div>
    <div class="type">List of <code>hazard_class</code> properties</div>
    <div class="occurs">0..</div>
    <div class="description">The IATA hazard classes assigned to the contents</div>
    <div class="validation">Optional. Each entry must be a valid hazard_class</div>
</div>
<div class="property">
    <div class="name"><code>packing_group</code></div>
    <div class="type"><code>packing_group</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">The packing_group for the contents</div>
    <div class="validation">Optional. If provided, must be a valid packing_group. If not provided will default to i (high).</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_packing_group](_packing_group.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>id_number</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The UN code / ID code or NA code of the contents</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>proper_shipping_name</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The Proper Shipping Name for the goods</div>
    <div class="validation">Optional. If provided, must be &lt;= 255 characters</div>
</div>
<div class="property">
    <div class="name"><code>technical_name</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The Technical Name for the goods.	</div>
    <div class="validation">Optional. If provided, must be &lt;= 255 characters</div>
</div>
<div class="property">
    <div class="name"><code>physical_form</code></div>
    <div class="type"><code>physical_form</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">The physical_form of the goods</div>
    <div class="validation">Optional. If not provided, will default to other. If provided, must be a valid physical_form</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_physical_form](_physical_form.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>radioactivity</code></div>
    <div class="type"><code>radioactivity</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">The radioactivity of the goods</div>
    <div class="validation">Optional. If not provided, will default to None. If provided, must be a valid radioactivity</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_radioactivity](_radioactivity.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>accessibility</code></div>
    <div class="type"><code>accessibility</code> object </div>
    <div class="occurs">0..1</div>
    <div class="description">The accessibility of the goods during transit</div>
    <div class="validation">Optional. If not provided, will default to inaccessible. If provided, must be a valid accessibility</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_accessibility](_accessibility.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>custom_label_text</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Custom text to be displayed on labels for these goods</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 255 characters</div>
</div>