<div class="property">
    <div class="name"><code>key</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The key of this metadata item</div>
    <div class="validation">Required. Each metadata key must be unique within a metadata collection. The length of the key must be &gt;= 1 and &lt;= 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>value</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The value of this metadata item</div>
    <div class="validation">Required. The length of the value must be &gt;=1 and &lt;= 100 characters</div>            
</div>
<div class="property">
    <div class="name"><code>type</code></div>
    <div class="type"><code>metadata_type</code> object </div>
    <div class="occurs">1</div>
    <div class="description">The type of this metadata item.</div>
    <div class="validation">Optional. If not provided, will default to string</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_metadata_type](_metadata_type.md)]
</div>
    </div>              
</div>
