<div class="property">
    <div class="name"><code>x-api-key</code></div>
    <div class="type"><span class="type-name">API header</span></div>
    <div class="occurs">1</div>
    <div class="description">Your PRO API key</div>
    <div class="validation">Required</div>
</div>
<div class="property">
    <div class="name"><code>Content-Type</code></div>
    <div class="type"><span class="type-name">API header</span></div>
    <div class="occurs">0..1</div>        
    <div class="description">The type of data being sent</div>
    <div class="validation">Optional. Where provided, must have a value of <code>application/json</code></div>    
</div>
<div class="property">
    <div class="name"><code>Accept</code></div>
    <div class="type"><span class="type-name">API header</span></div>
    <div class="occurs">0..1</div>        
    <div class="description">The type of data PRO should return</div>
    <div class="validation">Optional. Where provided, must have a value of <code>application/json</code></div>   
</div>
<div class="property">
    <div class="name"><code>Accept-Encoding</code></div>
    <div class="type"><span class="type-name">API header</span></div>
    <div class="occurs">0..1</div>        
    <div class="description">The encoding type PRO should use in its response</div>
    <div class="validation">Optional. Where provided, must have a value of <code>gzip</code></div>    
</div>
<div class="property">
    <div class="name"><code>x-api-version</code></div>
    <div class="type"><span class="type-name">API header</span></div>
    <div class="occurs">1</div>        
    <div class="description">The PRO API version to use</div>
    <div class="validation">Required. The current API version is <code>1.1</code></div>
</div>