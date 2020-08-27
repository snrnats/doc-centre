
<div class="property">
    <div class="name"><code>correlation_id</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A unique reference for this error. Customers can use this when reporting errors to Sorted, if applicable	</div>
</div>
<div class="property">
    <div class="name"><code>code</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A pre-defined code for this error</div>
</div>
<div class="property">
    <div class="name"><code>message</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A plain text summary of the error</div>
</div>
<div class="property">
    <div class="name"><code>details</code></div>
    <div class="type">List of <code>api_error_message</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Provides further details of the error(s) if applicable.</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_api_error_message](_api_error_message.md)]
</div>
    </div>            
</div>
<div class="property">
    <div class="name"><code>links</code></div>
    <div class="type">List of <code>link</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Provides links to further relevant information of operations, if applicable.</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_links](_links.md)]
</div>
    </div>            
</div>                                