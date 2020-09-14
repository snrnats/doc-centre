<div class="property">
    <div class="name">description</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">A user-provided description for this ruleset</div>
    <div class="validation">Required. The value must be >= 5 and <= 100 characters</div>
</div>
<div class="property">
    <div class="name">active</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Determines whether or not this ruleset should be active</div>
    <div class="validation">Optional. If not provided, will default to true</div>
</div>
<div class="property">
    <div class="name">validity</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">The validity of this ruleset, i.e. when the ruleset should apply</div>
    <div class="validation">Optional. If not provided, the ruleset will be effective immediately and will be effective until deleted or a validity period is added</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">rules</div>
    <div class="type"><code>dangerous_goods_rules</code> object</div>
    <div class="occurs">1</div>
    <div class="description">The rules that apply</div>
    <div class="validation">Required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_dangerous_goods_rules](_dangerous_goods_rules.md)]
</div>
    </div>    
</div>