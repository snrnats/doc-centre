<div class="property">
    <div class="name"><code>reference</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">Your own reference for this contact, if applicable</div>
    <div class="validation">If provided, must be &gt;= 1 and &lt;= 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>title</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The title or salutation of the contact (e.g. Mr, Mrs, señor)</div>
    <div class="validation">If provided, must be &gt;= 1 and &lt;= 50 characters</div>            
</div>
<div class="property">
    <div class="name"><code>first_name</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The first name / forename of the contact</div>
    <div class="validation">Required. Must be &gt;= 1 and &lt;= 100 characters</div>
</div>
<div class="property">
    <div class="name"><code>last_name</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The last name / surname of the contact</div>
    <div class="validation">Required. Must be &gt;= 1 and &lt;= 100 characters</div>
</div>
<div class="property">
    <div class="name"><code>middle_name</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The middle name(s) of the contact, if applicable</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 100 characters</div>
</div>
<div class="property">
    <div class="name"><code>position</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The position / job title of the contact, if applicable</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 100 characters</div>            
</div>
<div class="property">
    <div class="name"><code>contact_details</code></div>
    <div class="type"><code>contact_details</code> object </div>
    <div class="occurs">1</div>
    <div class="description">The details used to contact the person</div>
    <div class="validation">Required</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_metadata_type](_metadata_type.md)]
</div>
    </div>              
</div>
