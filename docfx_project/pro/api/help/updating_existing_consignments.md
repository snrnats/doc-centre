# Updating Consignments and Packages

Customer requested a change of shipping address? Need to add a requested delivery date? Not a problem. This page explains how to use API calls to update consignment and package details in SortedPRO.

---

## Updating Consignments

The **Update Consignment** endpoint enables you to update one or more existing consignments. When you make an **Update Consignment** request for a particular consignment, SortedPRO overwrites the existing consignment details with new details provided in the body of the request.

To call **Update Consignment**, make a `PUT` request to `https://api.electioapp.com/consignments/`. The `consignmentReference` of the consignment to be updated is specified in the body of the request, but the structure of the **Update Consignment** request is otherwise identical to that of the **Create Consignment** request. You can add multiple consignment objects to the list if required.

PRO uses the following rules when updating consignment properties:

* `{Reference}` - Required property. Cannot be updated.
* `{Source}` - Ignored. Cannot be updated.
* `{ShippingDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{RequestedDeliveryDate}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{ConsignmentReferenceProvidedByCustomer}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{CustomsDocumentation}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{MetaData}` - PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted.
* `{Addresses}`	- PRO replaces the entire property with the updated values. If no value is provided, any existing value is deleted. You cannot update addresses after a consignment has been allocated.
* `{Packages}` - If any values are provided, then PRO attempts to replace the entire property with the updated values. You cannot update packages after a consignment has been allocated. If no values are provided, PRO makes no changes to the consignment.
* `{Tags}` - If any values are provided, then PRO replaces the entire property with the updated values. If no values are provided, PRO makes no changes to the consignment.

Once the consignment is updated, PRO returns a link to the consignment object.

> [!NOTE]
>
>  For full reference information on the <strong>Update Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/UpdateConsignment">Update Consignment</a></strong> page of the API reference.

### Update Consignments Example

The example shows an  **Update Consignment** request for a single shipment that has a `{ConsignmentReference}` of _EC-000-087-01A_. For a further example of an **Update Consignment** request (including packages being updated), see the [API Reference](https://docs.electioapp.com/#/api/UpdateConsignment).

<div class="tab">
    <button class="staticTabButton">Example Update Consignment Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateConsRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateConsRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'updateConsRequest')">

```json
{
  "ShippingDate": "2019-06-02T00:00:00+01:00",
  "Reference": "EC-000-087-01A",
  "RequestedDeliveryDate": {
    "Date": "2019-06-05T00:00:00+01:00",
    "IsToBeExactlyOnTheDateSpecified": false
  },
  "ConsignmentReferenceProvidedByCustomer": "Your Reference",
  "CustomsDocumentation": {
    "DesignatedPersonResponsible": "Peter McPetersson",
    "ImportersVatNumber": "02345555",
    "CategoryType": "Other",
    "ShipperCustomsReference": "CREF0001",
    "ImportersTaxCode": "TC001",
    "ImportersTelephone": "0161123456",
    "ImportersFax": "01611124547",
    "ImportersEmail": "peter.mcpetersson@test.com",
    "CN23Comments": "Comments",
    "ReferencesOfAttachedInvoices": [
      "INV001"
    ],
    "ReferencesOfAttachedCertificates": [
      "CERT001"
    ],
    "ReferencesOfAttachedLicences": [
      "LIC001"
    ],
    "CategoryTypeExplanation": "Explanation",
    "DeclarationDate": "2019-05-31T00:00:00+01:00",
    "OfficeOfPosting": "Manchester",
    "ReasonForExport": "Sale",
    "ShippingTerms": "CFR",
    "ShippersVatNumber": "874541414",
    "ReceiversTaxCode": "TC5454",
    "ReceiversVatNumber": "8745474",
    "InvoiceDate": "2019-05-31T00:00:00+01:00"
  },
  "Addresses": [
    {
      "AddressType": "Origin",
      "ShippingLocationReference": "Shipping_Location_Reference",
      "IsCached": false
    },
    {
      "AddressType": "Destination",
      "Contact": {
        "Title": "Mr",
        "FirstName": "Peter",
        "LastName": "McPetersson",
        "Telephone": "07702123456",
        "Mobile": "07702123456",
        "LandLine": "0161544123",
        "Email": "peter.mcpetersson@test.com"
      },
      "CompanyName": "Test Company (UK) Ltd.",
      "AddressLine1": "13 Porter Street",
      "AddressLine2": "Pressington",
      "AddressLine3": "Carlsby",
      "Town": "Manchester",
      "Region": "Greater Manchester",
      "Postcode": "M1 5WG",
      "Country": {
        "Name": "Great Britain",
        "IsoCode": {
          "TwoLetterCode": "GB"
        }
      },
      "SpecialInstructions": "Gate code: 4454",
      "LatLong": {
        "Latitude": 53.474220,
        "Longitude": -2.246049
      },
      "IsCached": false
    }
  ],
  "MetaData": [
    {
      "KeyValue": "Updated_Key",
      "StringValue": "Updated_Value"
    }
  ],
  "Tags": [
    "TagC"
  ]
}
```
</div>

<div class="tab">
    <button class="staticTabButton">Example Update Consignment Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'updateConsResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="updateConsResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'updateConsResponse')">

```json
[
  {
    "Rel": "Link",
    "Href": "https://api.electioapp.com/consignments/EC-000-087-01A"
  }
]
```

</div>

## Adding Packages

If you just want to add a package to a single existing consignment, you could use the **Add Package** endpoint rather than **Update Consignment**.

> [!NOTE]
>
> You can only add packages to consignments that are in a status of either _Unallocated_ or _Allocation Failed_. If you need to add a package to a consignment that has been allocated, you will need to first deallocate that consignment. For more information on deallocating consignments, see the [Deallocating Consignments](/pro/api/help/deallocating_consignments.html) page.

To call **Add Package**, send a `POST` request to `https://api.electioapp.com/consignments/{consignmentReference}/addpackage`. The body of the request should contain the details of the package that you want to add, structured in the same way as the `package` property in a **Create Consignment** request. The package's `weight`, `dimensions`, `description` and `value` are mandatory, but all other package properties are optional. 

Once it receives the request, PRO adds a new package with the supplied details to the specified consignment, and returns the full package object. Note that this object now includes the package's `Reference`. A package reference is a unique identifier for each package in PRO, and takes the format _EP-xxx-xxx-xxx_. 

> [!NOTE]
>
> For full reference information on the **Add Package** endpoint, see the <a href="https://docs.electioapp.com/#/api/AddPackage">API reference</a>.

### Add Package Example

The below example shows a simple package object being added to a consignment. PRO creates the package and returns the full package object, including a newly-generated `Reference` of _EP-000-05F-0CY_.

For an example of a more detailed **Add Package** request, see the [API reference](https://docs.electioapp.com/#/api/AddPackage).

<div class="tab">
    <button class="staticTabButton">Example Add Package Request</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'addPckgRequest')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="addPckgRequest" class="staticTabContent" onclick="CopyToClipboard(this, 'addPckgRequest')">

```json

{
  "Weight": {
    "Value": 0.5,
    "Unit": "Kg"
  },
  "Dimensions": {
    "Unit": "Cm",
    "Width": 10.0,
    "Length": 10.0,
    "Height": 10.0
  },
  "Description": "Updated Description",
  "Value": {
    "Amount": 5.99,
    "Currency": {
      "IsoCode": "GBP"
    }
  }
}

```
</div>

<div class="tab">
    <button class="staticTabButton">Example Add Package Response</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'addPckgResponse')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="addPckgResponse" class="staticTabContent" onclick="CopyToClipboard(this, 'addPckgResponse')">

```json

{
    "ConsignmentLegs": [],
    "Items": [],
    "Charges": [],
    "Reference": "EP-000-05F-0CY",
    "PackageReferenceProvidedByCustomer": "",
    "Weight": {
        "Value": 0.5,
        "Unit": "Kg"
    },
    "Dimensions": {
        "Unit": "Cm",
        "Width": 10.0,
        "Length": 10.0,
        "Height": 10.0
    },
    "Description": "Updated Description",
    "Value": {
        "Amount": 5.99,
        "Currency": {
            "Name": "Pound Sterling",
            "IsoCode": "GBP"
        }
    },
    "PackageSizeReference": null,
    "Barcode": null,
    "MetaData": []
}

```
</div>

## Deleting Packages

You can delete a package from its associated consignment using the **Delete Package** endpoint. To call **Delete Package**, send a `DELETE` request to `https://api.electioapp.com/packages/{packageReference}`. PRO deletes the supplied package, and returns a code 200 response with no body.

You can only delete packages from consignments that are in a status of either _Unallocated_ or _Allocation Failed_. If you need to add a package to a consignment that has been allocated, you will need to first deallocate that consignment. For more information on deallocating consignments, see the [Deallocating Consignments](/pro/api/help/deallocating_consignments.html) page.

You cannot delete the last package in a consignment. If you attempt to do so, PRO returns an error.

> [!NOTE]
>
> For full reference information on the **Delete Package** endpoint, see the <a href="https://docs.electioapp.com/#/api/DeletePackage">API reference</a>.

## Next Steps

* Learn how to allocate consignments at the [Allocating Consignments to Carriers](/pro/api/help/allocating_consignments.html) page.
* Learn how to get and print delivery labels at the [Getting Labels](/pro/api/help/getting_labels.html) page.
* Learn how to add consignments to a carrier manifest at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>