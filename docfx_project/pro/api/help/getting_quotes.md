# Getting Quotes

This page explains how got get delivery quotes based on consignment details.

---

## Sending a Get Quotes Request

The **Get Quotes** endpoint enables you to get quotes based on the details of an as-yet nonexistent consignment. 

To call **Get Quotes**, send a `POST` request to `https://api.electioapp.com/quotes/`. The body of the request should contain a consignment object.

As a minimum, the **Get Quotes** endpoint requires you to send package weights and dimensions, origin address, and destination address data. You can either specify package weights and dimension via the `Weight` and `Dimensions` properties, or by supplying a `PackageSizeReference`. 

> <span class="note-header">Note:</span>
>  A <code>PackageSizeReference</code> is a unique identifier for a pre-defined, standardised package size. 
>
> To configure standard package sizes, use the <strong><a href="https://www.electioapp.com/Configuration/packagingsizes">Configuration > Packaging Sizes</a></strong> page of the PRO UI. You can also view a list of your available standard package sizes by making a call to the <a href="https://docs.electioapp.com/#/api/GetPackageSizes">Get Package Sizes</a> API.

Either the consignment's `destination` address, its `origin` address (if it has one), or both, must include a valid <code>ShippingLocationReference</code>. For information on how to obtain a list of your organisation's shipping locations, see the <strong><a href="https://docs.electioapp.com/#/api/GetShippingLocations">Get Shipping Locations</a></strong> page of the API reference.

There are lots of optional properties you can send when getting quotes for a consignment, including:

* Your own consignment reference.
* Details of the specific items inside the consignment's packages.
* The consignment's source.
* Shipping and delivery dates.
* Customs documentation.
* The consignment's direction of travel.
* Metadata. PRO metadata enables you to us custom fields to record additional data about a consignment. For more information on using metadata in PRO, see <span class="highlight">[LINK HERE]</span>.
* Tags. Allocation tags enable you to filter the list of carrier services that a particular consignment could be allocated to. For more information on allocation tags, see <span class="highlight">[LINK HERE]</span>.

Adding optional properties can help to improve the relevance and accuracy of the quote results that you get back from PRO.

## The Get Quotes Response

Once it has received the request, PRO

## Next Steps



<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>