This object is returned by Sorted whenever an error occurs during a request. Errors can have many causes, such as badly-formed requests, incorrect permissions, or unforeseen issues during request processing.

<div class="dc-row">
    <div class="dc-column">
        <h4>Properties</h4>
        <div class="property">
            <div class="name"><code>correlation_id</code></div>
            <div class="type">string</div>
            <div class="occurs">1</div>
            <div class="description">A unique reference for this error. Customers can use this when reporting errors to Sorted, if applicable	</div>
        </div>
        <div class="property">
            <div class="name"><code>code</code></div>
            <div class="type">string</div>
            <div class="occurs">1</div>
            <div class="description">A pre-defined code for this error</div>
        </div>
        <div class="property">
            <div class="name"><code>message</code></div>
            <div class="type">string</div>
            <div class="occurs">1</div>
            <div class="description">A plain text summary of the error</div>
        </div>
        <div class="property">
            <div class="name"><code>details</code></div>
            <div class="type">List of api_error_message</div>
            <div class="occurs">0..n</div>
            <div class="description">Provides further details of the error(s) if applicable.</div>
            <div class="dropdown" onclick="dropFunction(this)">Show child properties
                <!--<button onclick="dropFunction(this)" class="dropbtn">Show child properties</button>-->
                <div id="apiError_propertyChild" class="dropdown-content">

[!include[_api_error_message](_api_error_message.md)]
</div>
            </div>            
        </div>
        <div class="property">
            <div class="name"><code>links</code></div>
            <div class="type">List of link</div>
            <div class="occurs">0..n</div>
            <div class="description">Provides links to further relevant information of operations, if applicable.</div>
            <div class="dropdown">
                <button onclick="dropFunction('apiError_linksChild')" class="dropbtn">Show child properties</button>
                <div id="apiError_linksChild" class="dropdown-content">

[!include[_links](_links.md)]
</div>
            </div>            
        </div>                                
    </div>      

<div class="dc-column">
<h4>Example</h4>

```json
{
    "correlation_id": "6c4e6a77-feab-42ab-9d7b-f559dc1b90ca",
    "code": "validation_error",
    "message": "A provided property has an invalid format",
    "details": [
        {
            "property": "addresses[0].contact.contact_details.email",
            "code": "invalid_format",
            "message": "'test@something' is not a valid email address"
        }
    ],
    "_links": null
}
```

</div>
</div>

> [!NOTE]
> Although errors from the API include string-based messages, the message content should not be considered part of the data contract. Customers are strongly-advised not to program any application logic based on the content of an error message. Always prefer the code property, which can be considered part of a data contract, i.e. Sorted will not change error codes and will only introduce new codes.