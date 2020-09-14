<div class="property">
    <div class="name">reference</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The unique reference for this ruleset provided by Sorted</div>
    <div class="validation">Required. Must be a valid reference for an existing ruleset</div>
</div>
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
    <div class="name">validity</div>
    <div class="type"><code>date_range</code> object</div>
    <div class="occurs">0..1</div>
    <div class="description">The validity of this ruleset, i.e. when the ruleset should apply</div>
    <div class="validation">Optional. If not provided, the ruleset will be effective immediately and will be effective until deleted or a validity period is added. If a ruleset has an existing validity and no validity is provided on update, the existing validity should be removed</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_date_range](_date_range.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">active</div>
    <div class="type">

[!include[_datatype_boolean](_datatype_boolean.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Indicates whether the ruleset is active or not</div>
    <div class="validation">Optional. If not provided, will default to true</div>
</div>
<div class="property">
    <div class="name">rules</div>
    <div class="type"><code>dangerous_goods_rules</code> object</div>
    <div class="occurs">1</div>
    <div class="description">The rules that apply</div>
    <div class="validation">Required</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_dangerous_goods_rules](_dangerous_goods_rules.md)]
</div>
    </div>    
</div>
<div class="property">
    <div class="name">updated</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">0</div>
    <div class="description">The date that the ruleset was last updated</div>
    <div class="validation">Not applicable for updates. Set by Sorted as a result of an update operation</div>
</div>
<div class="property">
    <div class="name">updated_by</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0</div>
    <div class="description">The identifier of the user that last updated the ruleset</div>
    <div class="validation">Not applicable for updates. Set by Sorted as a result of an update operation</div>
</div>
<div class="property">
    <div class="name">created</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">0</div>
    <div class="description">The date that the ruleset was created</div>
    <div class="validation">Not applicable for updates. Set by Sorted as a result of a create operation</div>
</div>
<div class="property">
    <div class="name">created_by</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0</div>
    <div class="description">The identifier of the user that created the ruleset</div>
    <div class="validation">Not applicable for updates. Set by Sorted as a result of a create operation</div>
</div>
<div class="property">
    <div class="name">version</div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0</div>
    <div class="description">The version of the ruleset</div>
    <div class="validation">Not applicable for updates. Set by Sorted as a result of a create or update operation</div>
</div>
<div class="property">
    <div class="name">carrier_service_links</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0</div>
    <div class="description">The references of the carrier services this ruleset is linked to</div>
    <div class="validation">Not applicable for updates</div>
</div>