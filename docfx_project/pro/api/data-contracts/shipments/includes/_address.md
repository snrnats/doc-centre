<div class="property">
    <div class="name"><code>address_type</code></div>
    <div class="type">Address type</div>
    <div class="occurs">1</div>
    <div class="description">Indicates the type of address, e.g. origin or destination	</div>
    <div class="validation">Required. All addresses must include a valid address_type value. All shipments must have at least an origin and a destination address. Only one address of each type may be included in any shipment.</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_address_type](_address_type.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>shipping_location_reference</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">Used to reference a pre-defined shipping location	</div>
    <div class="validation">Optional for on_demand shipments but required for scheduled shipments. If provided, must be a valid existing shipping location.</div>
</div>
<div class="property">
    <div class="name"><code>custom_reference</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">Your own reference for this address, if applicable</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>contact</code></div>
    <div class="type">Contact</div>
    <div class="occurs">0..1</div>
    <div class="description">Details of the contact at the address. This should be used to specify the name of the recipient, for example.	</div>
    <div class="validation">Required when shipping_location_reference is not provided.</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_contact](_contact.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>company_name</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The name of the company, if applicable	</div>
    <div class="validation">Optional. If provided, must be &gt;=1 and &lt;= 100 characters</div>
</div>
<div class="property">
    <div class="name"><code>property_number</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The number of the property, if applicable.	</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>property_name</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The name of the property, if applicable</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 50 characters</div>
</div>
<div class="property">
    <div class="name"><code>address_line_1</code></div>
    <div class="type">string</div>
    <div class="occurs">1</div>
    <div class="description">The first line of the address</div>
    <div class="validation">Required. Must be &gt;= 1 and &lt;= 255 characters</div>
</div>
<div class="property">
    <div class="name"><code>address_line_2</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The second line of the address</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 255 characters</div>
</div>
<div class="property">
    <div class="name"><code>address_line_3</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The third line of the address</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 255 characters</div>
</div>
<div class="property">
    <div class="name"><code>locality</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The locality of the address. This may be, for example, a city or town</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 255 characters</div>
</div>
<div class="property">
    <div class="name"><code>region</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The region of the address. This could be a county (for the UK) or a state (for the US) for example</div>
    <div class="validation">Required for some countries, e.g. US, CA, IE, AU. If provided for a required country, Sorted will accept either official abbreviations or full names and will convert between values as required. For example, the values AL or Alabama would be accepted for the country US</div>
</div>
<div class="property">
    <div class="name"><code>postal_code</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The postal code / zip code of the address</div>
    <div class="validation">Required for countries with official postcode systems. The postcode provided must be in a valid format for the country provided</div>
</div>
<div class="property">
    <div class="name"><code>country_iso_code</code></div>
    <div class="type">string</div>
    <div class="occurs">1</div>
    <div class="description">The ISO 3166 Alpha 2 code for the country of the location.	</div>
    <div class="validation">Required. The value provided must be exactly 2-characters and be a valid country ISO 3166 Alpha-2 code</div>
</div>
<div class="property">
    <div class="name"><code>lat_long</code></div>
    <div class="type">lat_long object</div>
    <div class="occurs">0..1</div>
    <div class="description">The latitude and longitude of the location, if known and applicable</div>
    <div class="validation">Optional</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_lat_long](_lat_long.md)]
</div>
    </div>              
</div>