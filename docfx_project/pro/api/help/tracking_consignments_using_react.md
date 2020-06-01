# Tracking PRO Consignments Using REACT

SortedPRO integrates seamlessly with REACT, Sorted's dedicated shipment tracking platform. PRO can automatically register shipments with REACT, and share carrier and tracking information. This page explains how PRO and REACT can interact with each other, and the benefits this brings.

> <span class="note-header">Note:</span>
>
> For integration guides and user help on REACT, see the [REACT](/react/help/overview.html) section of this site.

---

## Why Use REACT?

PRO's native tracking API enables you to build simple tracking pages that a consumer can access to check the status of their order. REACT, on the other hand, offers a full suite of tracking tools, giving you much more flexibility in the way that you supply tracking updates to your customers. REACT offers:

* Custom webhooks that notify you of shipping events proactively. Whenever a shipment enters a selected state, REACT will send that shipment’s data to you, thereby enabling you to build services such as push notifications as email alerts.
* A tracking dashboard that gives you advanced shipment monitoring features, and enables administrators to configure the system.
* Customisable shipment state labels, enabling you to to communicate tracking information to your customers in your brand’s tone of voice or in an alternative language, as opposed to using default tracking state names.
* Customisable web-based tracking pages that can be published with no development work needed.
* Calculated events, whereby shipment properties are changes based on REACT's internal processing rather than a carrier update. For example, REACT can automatically flag a shipment as late if it passes its expected delivery date. 

## Integrating PRO and REACT

When you sign up to REACT as a PRO customer, your REACT and PRO accounts are automatically linked. You do not need to do any additional configuration beyond the regular configuration processes for each product.

REACT uses carrier connectors to keep shipments from a particular carrier up to date. Carrier connectors contain configuration that enables REACT to obtain carrier tracking data. Ordinarily, you would need to configure carrier connectors yourself as part of the REACT setup process. However, when you sign up to REACT as a PRO customer, REACT takes your carrier configuration from PRO, enabling you to use your existing carrier integrations in REACT without needing to provide any additional details.

To use your PRO carriers with REACT, navigate to **Settings** > **Carrier Connectors** within the REACT UI, and click **Connect**.

## Registering PRO Consignments in REACT

Once PRO and REACT have been linked, PRO will automatically create new REACT shipments from manifested consignments. The process is as follows:

1. PRO tells REACT that a consignment has been manifested and sends the details of that consignment to REACT.
2. REACT validates the consignment details and generates a new REACT shipment object from it.
3. REACT registers the shipment via its [Register Shipments](/react/help/registering-shipments.html) API.

At this point, the shipment can now be tracked in the same way as any other REACT shipment.

### Mapping Table

This table shows how the properties in a PRO consignment resource map to the properties in a REACT shipment resource.

<table>
  <tr>
    <th>REACT</th>
    <th>PRO</th>
  </tr>
  <tr>
    <td>customer_id</td>
    <td>CustomerReference</td>
  </tr>
  <tr>
    <td>carrier</td>
    <td>Carrier</td>
  </tr>
  <tr>
    <td>carrier_service</td>
    <td>CarrierService</td>
  </tr>
  <tr>
    <td>shipped_date</td>
    <td>DateShipped</td>
  </tr>
  <tr>
    <td>promised_date.start</td>
    <td>EarliestDeliveryDate</td>
  </tr>
  <tr>
    <td>promised_date.end</td>
    <td>LatestDeliveryDate</td>
  </tr>
  <tr>
    <td>expected_deliver_date.start</td>
    <td>EarliestDeliveryDate</td>
  </tr>
  <tr>
    <td>expected_deliver_date.end</td>
    <td>LatestDeliveryDate</td>
  </tr>
  <tr>
    <td>retailer</td>
    <td>Retailer</td>
  </tr>
  <tr>
    <td>shipment_type</td>
    <td>ShipmentType</td>
  </tr>
  <tr>
    <td>address.address_type</td>
    <td>AddressType</td>
  </tr>
  <tr>
    <td>address.reference</td>
    <td>Reference</td>
  </tr>
  <tr>
    <td>address.property_number</td>
    <td>PropertyNumber</td>
  </tr>
  <tr>
    <td>address.property_name</td>
    <td>PropertyName</td>
  </tr>
  <tr>
    <td>address.address_line1</td>
    <td>AddressLine1</td>
  </tr>
  <tr>
    <td>address.address_line2</td>
    <td>AddressLine2</td>
  </tr>
  <tr>
    <td>address.address_line3</td>
    <td>AddressLine3</td>
  </tr>
  <tr>
    <td>address.locality</td>
    <td>Locality</td>
  </tr>
  <tr>
    <td>address.region</td>
    <td>Region</td>
  </tr>
  <tr>
    <td>address.postal_code</td>
    <td>PostalCode</td>
  </tr>
  <tr>
    <td>address.country_iso_code</td>
    <td>CountryIsoCode</td>
  </tr>
  <tr>
    <td>tracking_references</td>
    <td>ShipmentTrackingReferences</td>
  </tr>
  <tr>
    <td>metadata</td>
    <td>ShipmentMetaData</td>
  </tr>
  <tr>
    <td>tags</td>
    <td>Consignment Tags</td>
  </tr>
  <tr>
    <td>custom_reference</td>
    <td>ShipmentCustomReferences</td>
  </tr>
  <tr>
    <td>consumer.email</td>
    <td>Consumer.Email</td>
  </tr>
  <tr>
    <td>consumer.phone</td>
    <td>Phone</td>
  </tr>
  <tr>
    <td>consumer.mobile_phone</td>
    <td>MobilePhone</td>
  </tr>
  <tr>
    <td>consumer.first_name</td>
    <td>FirstName</td>
  </tr>
  <tr>
    <td>consumer.last_name</td>
    <td>LastName</td>
  </tr>
  <tr>
    <td>consumer.middle_name</td>
    <td>MiddleName</td>
  </tr>
  <tr>
    <td>consumer.title</td>
    <td>Title</td>
  </tr>
</table>

### Mapping Example

This example shows a PRO consignment and a REACT shipment that has been generated from that consignment at the point it was manifested.

<div class="tab">
    <button class="staticTabButton">Example PRO Consignment</button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'PROmapping')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="PROmapping" class="staticTabContent" onclick="CopyToClipboard(this, 'PROmapping')">

```json
{
    "ConsignmentLegs": [
        {
            "Leg": 1,
            "TrackingReferences": [
                "1Z9A80W5D991115692"
            ],
            "CarrierReference": "UPS",
            "CarrierServiceReference": "UPSHSADCS",
            "CarrierName": "UPS"
        }
    ],
    "CollectionDate": "2020-04-08T00:00:00+01:00",
    "DateDelivered": null,
    "FirstAttemptedDeliveryDate": null,
    "DateReturned": null,
    "DateShipped": null,
    "DateCollected": null,
    "AttemptedDeliveryDate": null,
    "MetaData": [],
    "Allocation": {
        "CarrierServiceGroupReference": "",
        "MpdCarrierServiceGroupName": null,
        "MpdCarrierServiceReference": "EDC5_UPSHSADCS",
        "MpdCarrierServiceName": "UPS SAVER (Delivery Confirmation Signature Required)",
        "AllocationDate": "2020-04-08T08:57:20.0959259+00:00",
        "Price": {
            "Net": 22.99,
            "Gross": 22.99,
            "TaxRate": {
                "Reference": null,
                "CountryIsoCode": "GB",
                "Type": "Standard",
                "Rate": 0.0000
            },
            "VatAmount": 0.00,
            "Currency": {
                "Name": null,
                "IsoCode": "GBP"
            }
        }
    },
    "FailedAllocation": null,
    "Source": "Api",
    "LabelCount": 0,
    "LabelsPrinted": false,
    "DateLabelsWereFirstPrinted": null,
    "IsLate": false,
    "LateForCustomer": false,
    "CustomerReference": "338a3524-5a17-44dd-a601-1527574f1a5d",
    "Weight": {
        "Value": 2.00000,
        "Unit": "Kg"
    },
    "Value": {
        "Amount": 20.00,
        "Currency": {
            "Name": "United States dollars",
            "IsoCode": "USD"
        }
    },
    "Direction": "Outbound",
    "Tags": [],
    "Reference": "EC-000-05E-BKJ",
    "ConsignmentState": "Manifested",
    "DateCreated": "2020-04-08T08:57:17.5970788+00:00",
    "ShippingDate": "2020-04-08T17:00:00+01:00",
    "RequestedDeliveryDate": {
        "Date": "2020-04-10T00:00:00+00:00",
        "DeliveryWindow": {
            "Start": "00:00:00",
            "End": "00:00:00",
            "UtcOffset": null
        },
        "IsToBeExactlyOnTheDateSpecified": true
    },
    "EarliestDeliveryDate": "2020-04-10T00:00:00-04:00",
    "LatestDeliveryDate": "2020-04-10T23:30:00-04:00",
    "ConsignmentReferenceProvidedByCustomer": "PostDeploymentTest_API_v1.1_UKtoUS_NonGBP",
    "Addresses": [
        {
            "AddressType": "Origin",
            "ShopLocationReference": null,
            "Contact": {
                "Reference": null,
                "Title": "Miss",
                "FirstName": "Laura",
                "LastName": "Somebody",
                "Position": null,
                "Telephone": "01234 567 890",
                "Mobile": "01234 567 890",
                "LandLine": "",
                "Email": "laura.somebody@mpd-group.com"
            },
            "CompanyName": null,
            "ShippingLocationReference": "Sorted1",
            "CustomerName": null,
            "AddressLine1": "Third Floor",
            "AddressLine2": "Merchant Exchange",
            "AddressLine3": "Whitworth Street West",
            "Town": "Manchester",
            "Region": "",
            "Postcode": "M1 5WG",
            "Country": {
                "Name": "United Kingdom",
                "IsoCode": {
                    "TwoLetterCode": "GB"
                }
            },
            "RegionCode": "",
            "SpecialInstructions": "",
            "LatLong": null,
            "IsCached": false
        },
        {
            "AddressType": "Destination",
            "ShopLocationReference": null,
            "Contact": {
                "Reference": null,
                "Title": "",
                "FirstName": "Robert",
                "LastName": "Smith",
                "Position": null,
                "Telephone": "07495747394",
                "Mobile": "07495747394",
                "LandLine": "0161111454",
                "Email": "robert.smith@email.com"
            },
            "CompanyName": "",
            "ShippingLocationReference": null,
            "CustomerName": null,
            "AddressLine1": "400 N Calhoun Street",
            "AddressLine2": "",
            "AddressLine3": "",
            "Town": "Leeds",
            "Region": "West Yorks",
            "Postcode": "LS1 6TH",
            "Country": {
                "Name": "United Kingdom",
                "IsoCode": {
                    "TwoLetterCode": "GB"
                }
            },
            "RegionCode": "IA",
            "SpecialInstructions": null,
            "LatLong": null,
            "IsCached": false
        }
    ],
    "Packages": [
        {
            "ConsignmentLegs": [
                {
                    "Leg": 1,
                    "TrackingReferences": [
                        "1Z9A80W5D991115692"
                    ],
                    "CarrierReference": "UPS",
                    "CarrierServiceReference": null,
                    "CarrierName": null
                }
            ],
            "Items": [
                {
                    "Reference": "099681e6c66d47c982c86e1e5aaa803c",
                    "Sku": "sku",
                    "Model": "model",
                    "Description": "desc",
                    "CountryOfOrigin": {
                        "Name": "United Kingdom",
                        "IsoCode": {
                            "TwoLetterCode": "GB"
                        }
                    },
                    "HarmonisationCode": "h code",
                    "Weight": {
                        "Value": 0.34000,
                        "Unit": "Kg"
                    },
                    "Dimensions": {
                        "Unit": "Cm",
                        "Width": 1.10000,
                        "Length": 1.10000,
                        "Height": 1.10000
                    },
                    "Value": {
                        "Amount": 10.0000,
                        "Currency": {
                            "Name": "United States dollars",
                            "IsoCode": "USD"
                        }
                    },
                    "ItemReferenceProvidedByCustomer": "Sorted Package 1 Item 1 Referene",
                    "Barcode": {
                        "Code": "code",
                        "BarcodeType": "AztecCode"
                    },
                    "Quantity": 0,
                    "Unit": null,
                    "HarmonisationKeyWords": [
                        "one",
                        "two"
                    ],
                    "Status": null,
                    "ContentClassification": "Unrestricted",
                    "ContentClassificationDetails": "NotSpecified"
                }
            ],
            "Charges": [],
            "Reference": "EP-000-05G-CAH",
            "PackageReferenceProvidedByCustomer": "",
            "Weight": {
                "Value": 2.00000,
                "Unit": "Kg"
            },
            "Dimensions": {
                "Unit": "Cm",
                "Width": 5.00000,
                "Length": 10.00000,
                "Height": 1.00000
            },
            "Description": "test description",
            "Value": {
                "Amount": 20.0000,
                "Currency": {
                    "Name": "United States dollars",
                    "IsoCode": "USD"
                }
            },
            "PackageSizeReference": null,
            "Barcode": {
                "Code": "010101",
                "BarcodeType": "AustraliaPostalCode"
            }
        }
    ]
}
```

</div>

<div class="tab">
    <button class="staticTabButton">Corresponding REACT Shipment </button>
    <div class="copybutton" onclick="CopyToClipboard(this, 'REACTmapping')"><span class='glyphicon glyphicon-copy'></span><span class='copy'>Copy</span></div>
</div>

<div id="REACTmapping" class="staticTabContent" onclick="CopyToClipboard(this, 'REACTmapping')">

```json
{
  "shipments": [
    {
      "tags": [],
      "tracking_references": [
        "1Z9A80W5D991115692"
      ],
      "carrier": "UPS",
      "carrier_service": "UPS SAVER (Delivery Confirmation Signature Required)",
      "shipped_date": null,
      "promised_date": {
        "start": "2020-04-10T00:00:00-04:00",
        "end": "2020-04-10T23:30:00-04:00"
      },
      "expected_deliver_date": {
        "start": "2020-04-10T00:00:00-04:00",
        "end": "2020-04-10T23:30:00-04:00"
      },
      "addresses": [
        {
            "address_type": "Origin",
            "reference": "Sorted1",            
            "address_line1": "Third Floor",
            "address_line2": "Merchant Exchange",
            "address_line3": "Whitworth Street West",
            "region": "",
            "postal_code": "M1 5WG",
            "country_iso_code": "GB"
        },
        {
            "address_type": "Destination",
            "address_line1": "400 N Calhoun Street",
            "address_line2": "",
            "address_line3": "",
            "region": "West Yorks",
            "postal_code": "LS1 6TH",
            "country_iso_code": "GB"
        }
      ],
      "metadata": []
    }
  ]
}
```

</div>

> <span class="note-header">More Information:</span>
>
> * For more information on the structure of a REACT shipment, see the [Register Shipments](https://docs.sorted.com/react/api/#RegisterShipments) section of the REACT API reference and the [Registering Shipments](/react/help/registering-shipments.html) page of the REACT help.
> * For more information on the structure of a PRO consignment, see the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) page of the PRO API reference and the [Creating New Consignments](/pro/api/help/creating_new_consignments.html) page of the PRO help.

## After Registration

Once a PRO consignment has been registered as a REACT shipment, PRO automatically keeps REACT updated of any changes. Whenever PRO downloads a new carrier file, it updates any shipments in that file that you have registered with REACT accordingly. 

## Next Steps

* View the [REACT User Guide](/react/help/overview.html) for a full overview of how to use REACT.
* Learn how to get customs docs and invoices for international shipments at the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page.
* Learn how to manifest consignments at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>