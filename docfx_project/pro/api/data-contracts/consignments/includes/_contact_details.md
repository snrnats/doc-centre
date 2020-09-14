<div class="property">
    <div class="name"><code>landline</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The landline telephone number of the contact</div>
    <div class="validation">Optional. At least one of landline or mobile must be provided. If provided, must be &gt;= 1 and &lt;= 100 characters</div>
</div>
<div class="property">
    <div class="name"><code>mobile</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The mobile telephone number of the contact</div>
    <div class="validation">Optional. At least one of landline or mobile must be provided. If provided, must be &gt;= 1 and &lt;= 100 characters</div>            
</div>
<div class="property">
    <div class="name"><code>email</code></div>
    <div class="type">

[!include[_datatype_string](_datatype_string.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The email address of the contact.	</div>
    <div class="validation">Required. Must be a valid format of email address. Maximum length of email is 255 characters</div>
</div>