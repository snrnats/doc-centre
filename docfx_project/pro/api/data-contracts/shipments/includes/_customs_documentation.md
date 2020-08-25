
<div class="property">
    <div class="name"><code>designated_person_responsible</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The name of the person responsible for the shipment of the contents</div>
    <div class="validation">Optional. If provided, must be between less than 100 characters</div>
</div>
<div class="property">
    <div class="name"><code>importers_vat_number</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The VAT number of the importer, if applicable.</div>
    <div class="validation">Optional. If provided, must be &lt;= 50 characters</div>            
</div>
<div class="property">
    <div class="name"><code>category_type</code></div>
    <div class="type">category type</div>
    <div class="occurs">1</div>
    <div class="description">Indicates the category of goods for customs purposes</div>
    <div class="validation">Required. Must be a valid category type</div>     
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show values</button>
        <div class="dropdown-content">

[!include[_category_type](_category_type.md)]
</div>
    </div>              
</div>
<div class="property">
    <div class="name"><code>category_type_explanation</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">Free text explanation indicating the reason for the selection of the category_type.</div>
    <div class="validation">Optional. If provided, must be &lt;= 100 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>shippers_customs_reference</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The shipper's customs reference, if known</div>
    <div class="validation">Optional. If provided, must be &lt;= 50 characters</div>            
</div>
<div class="property">
    <div class="name"><code>importers_tax_code</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The importer's tax code, if known.</div>
    <div class="validation">Optional. If provided, must be &lt;= 25 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>importers_telephone</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The importer's telephone number, if known.</div>
    <div class="validation">Optional. If provided, must be &lt;= 25 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>importers_fax</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The importer’s fax number, if known.</div>
    <div class="validation">Optional. If provided, must be &lt;= 25 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>importers_email</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The importer’s email address, if known.</div>
    <div class="validation"> address, if known.	Optional. If provided, must be &lt;= 100 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>invoice_number</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The invoice number, if applicable</div>
    <div class="validation">Optional. If provided, must be &lt;= 50 characters</div>            
</div>
<div class="property">
    <div class="name"><code>office_of_origin</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The office of origin (Madrid Protocol) if applicable</div>
    <div class="validation">Optional. If provided, must be &lt;= 50 characters</div>            
</div>
<div class="property">
    <div class="name"><code>cn23_comments</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">Comments used to populate section 11 of CN23 customs documentation.</div>
    <div class="validation">Optional. If provided, must be &lt;= 500 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>attached_invoice_references</code></div>
    <div class="type">List of string</div>
    <div class="occurs">0..20</div>
    <div class="description">A list of 0 or more attached invoice references.</div>
    <div class="validation">Optional. If provided, each reference must be &lt;= 50 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>attached_certificate_references</code></div>
    <div class="type">List of string</div>
    <div class="occurs">0..20</div>
    <div class="description">A list of 0 or more attached certificate references.</div>
    <div class="validation">Optional. If provided, each reference must be &lt;= 50 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>attached_licence_references</code></div>
    <div class="type">List of string</div>
    <div class="occurs">0..20</div>
    <div class="description">A list of 0 or more attached licence references.</div>
    <div class="validation">Optional. If provided, each reference must be &lt;= 50 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>declaration_date</code></div>
    <div class="type">ISO8601 Date Time</div>
    <div class="occurs">0..1</div>
    <div class="description">The date and time of the declaration.</div>
    <div class="validation">Optional. If not provided, this will default to the date and time at which the shipment is created.</div>            
</div>
<div class="property">
    <div class="name"><code>reason_for_export</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The reason for the export of the goods contained in the shipment.</div>
    <div class="validation">Optional. If provided, must be &lt;= 100 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>shippers_vat_number</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The shipper’s VAT number.	</div>
    <div class="validation">Optional. If provided, must be &lt;= 50 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>receivers_tax_code	</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The receiver’s tax code.</div>
    <div class="validation">Optional. If provided, must be &lt;= 25 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>receivers_vat_number</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The receiver’s VAT number	</div>
    <div class="validation">Optional. If provided, must be &lt;= 50 characters.</div>            
</div>
<div class="property">
    <div class="name"><code>invoice_date</code></div>
    <div class="type">ISO8601 Date Time	</div>
    <div class="occurs">0..1</div>
    <div class="description">The date and time of the invoice for the goods.</div>
    <div class="validation">Optional. If not provided, will default to the date and time of the creation of the shipment.</div>            
</div>
<div class="property">
    <div class="name"><code>eori_number</code></div>
    <div class="type">string</div>
    <div class="occurs">0..1</div>
    <div class="description">The sender's EORI number</div>
    <div class="validation">Optional. If provided, must be &gt;= 1 and &lt;= 15 characters</div>            
</div>
