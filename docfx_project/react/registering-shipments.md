# Registering Shipments

SortedREACT can only work with the shipments you register. This page explains how to register shipment details using the Shipments API and REACT's SFTP bulk upload service, and how to get the most out of REACT by registering additional shipment information.

---

## Registering Shipments by API

The [Register Shipments](https://docs.sorted.com/react/api/#RegisterShipments) API endpoint enables you to send shipment details to REACT. REACT then uses these details to create a shipment record on the system. 

### Sending the Request

To register a shipment, send a <span class="text--green text--bold">POST</span> request to `https://api.sorted.com/react/shipments`. There are lots of properties you can send when you register, but only the (carrier) `tracking_references` array is mandatory. REACT treats the value of the `tracking_references` array as the shipment's primary reference.

Currently, you can only provide one tracking reference in the `tracking_references` array, although multiple references may be supported in a future enhancement to REACT. If you add additional references, REACT returns an error. You can add additional references for the shipment - including your own internal reference numbers - in the `custom_references` array.

> <span class="note-header">Note:</span>
>
> As with other REACT APIs, you'll need to include JSON `Content-Type` and `Accept` headers and a valid API key in order to use the **Register Shipments** endpoint. You can get an API key from the **Settings > API Keys** page of the REACT UI. 
>
> For more information on obtaining an API key, see the [Getting an API Key](https://docs.sorted.com/react/quick-start/#registering-a-shipment) section of the Quick Start guide.

**Examples**

This example shows the body of a simple **Register Shipments** request, in which the user has not provided any information other than a carrier tracking reference:

```json
{
  "shipments": [{
    "tracking_references": ["TRACKING-DEMO-REFERENCE"]
  }]
}
```

<span class="text--caption text--center">Register Shipments request with tracking reference only.</span>

The following example shows two simple shipments registered in a single API call:

```json
{
  "shipments": [{
    "tracking_references": ["MULTI-SHIPMENT-1"]
	},
	{
    "tracking_references": ["MULTI-SHIPMENT-2"]
	}]
}
```

<span class="text--caption text--center">Register Shipments request with two shipments, both with tracking reference only.</span>

### Register Shipments Response

When REACT receives the request, it creates a new shipment record and returns a **201 Created** response. The body of this response contains the shipment's `id` - a REACT-generated identifier for the shipment that can be used to recall data throughout REACT's APIs. 

```json
{
  "id": "sp_TRACKING-DEMO-ID",
  "message": "Shipment record 'sp_TRACKING-DEMO-ID' with tracking reference ["TRACKING-DEMO-REFERENCE"] registered successfully.",
  "tracking_references": [
    "TRACKING-DEMO-REFERENCE"
  ],
  "_links": [
    {
      "href": "https://api.sorted.com/react/shipments/sp_TRACKING-DEMO-ID",
      "rel": "self"
    }
  ]
}
```

<span class="text--caption text--center">Successful Register Shipments response.</span>

And that's it! REACT will look out for the tracking reference you provided in the carrier data it receives from its carrier connectors, and will update the shipment's information as new events come in. You can use the carrier tracking reference or `{id}` to get updates on the shipment using REACT's APIs. The newly-registered shipment can also trigger any webhooks you have configured.

REACT assigns an initial shipment state of *Registered* to all newly-registered shipments. For a full list of REACT shipment states, see the [Shipment States](https://docs.sorted.com/react/shipment-states/) page.

## Registering Shipments by SFTP

The Register Shipments API is ideal if you need to register shipments individually or in small groups. However, if you have a large number of shipments to register you might find it more practical to use REACT's SFTP upload facility.

### Prerequisites

In order to upload to the REACT SFTP service, you will need:

* A REACT SFTP login
* A	REACT SFTP passphrase
* A	private key file

You can request these details from Sorted. Note that your SFTP username and passphrase are not the same as the username and password you use to log into the REACT UI.

> <span class="note-header">Note:</span>
>
> REACT private keys are provided in OpenSSH format. If your SFTP client does not support OpenSSH keys you will need to convert the key provided into the appropriate format. Consult your SFTP client's documentation for further information. 

The shipment data you want to upload should be stored in either a JSON or CSV file. The shipment data in this file should be structured in the same way as the data accepted by the **Register Shipments** endpoint, with one exception: when uploading a CSV file, the property that accepts tracking references should be called `tracking_reference`, rather than `tracking_references` (plural) as is the case when uploading a JSON file or making a direct request to the **Register Shipments** endpoint. 

> <span class="note-header">More Information:</span>
>
> For more information on representing shipment data in CSV format, see the [CSV File Structure](https://docs.sorted.com/react/registering-shipments#csv-file-structure) section.
>
> For more information on the data structure of the **Register Shipments** requests, see the [API Reference](https://docs.sorted.com/react/api/#RegisterShipments). 

This example shows the body of a simple CSV upload, in which the user has registered the carrier tracking references of five shipments, along with the carriers and carrier services used for those shipments:

```
"tracking_reference","carrier","carrier_service"
"TRACKING-DEMO-REFERENCE1","A Carrier","A Carrier Service"
"TRACKING-DEMO-REFERENCE2","Another Carrier","Another Carrier Service"
"TRACKING-DEMO-REFERENCE3","A Carrier","A Carrier Service"
"TRACKING-DEMO-REFERENCE4","Another Carrier","Another Carrier Service"
"TRACKING-DEMO-REFERENCE5","A Carrier","A Carrier Service"
```

<span class="text--caption text--center">CSV upload with five shipments.</span>

### Uploading

To upload shipments to REACT via SFTP: 

1. Save the private key to the machine you will be uploading the files from.
2. From that machine, open an SFTP client and start a new SFTP session. You'll need the following login details:
   * **File Protocol:** SFTP
   * **Host Name:** sftp://react-sftp.sorted.com
   * **Port Number:** 22
   * Your REACT SFTP **username** and **passphrase**.
3. Upload the shipment file as per your SFTP client's instructions.

### SFTP Upload Results

Once you have uploaded the file, REACT processes the shipment data sent. The system takes each individual shipment object in the file and attempts to register is using the data supplied. As the shipments are processed, REACT writes the result of each registration attempt to a JSON file. 

Once REACT has attempted to register every shipment in the file, the original file is deleted and the results file is uploaded to your SFTP directory. The completed file gives a full breakdown of how many shipments were successfully registered, how many could not be registered, and any errors that were returned.

The results file has two arrays of errors:

* `validation_errors`: Generated if the shipment could not be registered due to its data failing REACT's validation checks.
* `registration_errors`: Generated if the shipment passed REACT's validation but still could not be registered. (i.e. REACT's response to the shipment had a status code of something other than **201 Created** or  **400 Bad Request**.)

### Example SFTP Result Files

* The file contained a single shipment, which was successfully uploaded.

```json
{
  "result_message":"Results for processing file shipments-1-valid.json",
  "original_filename":"shipments-1-valid.json",
  "total_lines":1,
  "successful_shipment_registrations":1,
  "unsucessful_shipment_registrations":0,
  "validation_errors":[

  ],
  "registration_errors":[

  ],
  "error_message":null,
  "process_start":"2018-11-13T10:49:40.7613486+00:00",
  "process_end":"2018-11-13T10:49:41.0246588+00:00"
}
```

<span class="text--caption text--center">Successful SFTP upload response for a single shipment.</span>

* The file contained four shipments. One was registered successfully, one failed due to a validation error (in this case, duplicate `tracking_reference` values), and two failed due to errors during the registration process.

```json
{
  "result_message":"Results for processing file EXAMPLE-FILENAME",
  "original_filename":"EXAMPLE-FILENAME",
  "total_lines":4,
  "successful_shipment_registrations":1,
  "unsucessful_shipment_registrations":3,
  "validation_errors":
  [
    {
      "tracking_reference":"trackRef2",
      "message":"1 or more validation error(s) occurred",
      "error_messages":
        [
          {
            "property":"shipments._tracking_reference",
            "message":"Only one Tracking Reference should be provided"
          }
        ]
    }
  ],
  "registration_errors":
  [
    {
      "tracking_reference":"trackRef3",
      "error_message":"We were unable to register this shipment status was Ambiguous" 
    },
    {
      "tracking_reference":"trackRef4",
      "error_message":"We could not register this shipment as an error occured"
    }
  ],
  "error_message":null,
  "process_start":"2018-11-08T11:01:41.989049+00:00",
  "process_end":"2018-11-08T11:01:42.0460531+00:00"
}
```

<span class="text--caption text--center">SFTP upload response with one successful upload, one validation error, and two registration errors.</span>

* The file could not be parsed at all, most likely due to an invalid structure:

```json
{
  "result_message":"There was a problem processing the file shipments-1-valid.csv",
  "original_filename":"shipments-1-valid.csv",
  "total_lines":0,
  "successful_shipment_registrations":0,
  "unsucessful_shipment_registrations":0,
  "validation_errors":[

  ],
  "registration_errors":[

  ],
  "error_message":"Error parsing header from location cu-17583829045847028000-sorted-copy/shipments-1-valid-636777032692975629.csv for customer cu_17583829045847028000",
  "process_start":"2018-11-13T10:54:30.7505662+00:00",
  "process_end":"2018-11-13T10:54:34.2508169+00:00"
}
```

<span class="text--caption text--center">SFTP upload response for unparseable file.</span>

You can upload multiple shipment files at the same time as long as the files have different names. If you attempt to upload two shipment files with the same name at the same time, or upload a file before another file of the same name has finished processing, then REACT will only process one file. 

However, REACT will process files that have the same name as a file that has been previously uploaded, as long as it has already finished processing the first file.

## Registering Extra Shipment Information

Registering shipments with a carrier tracking reference alone is enough to get started with REACT's tracking features, but REACT works best when you give it more shipment data to use. 

> <span class="note-header">More Information:</span>
>
>This section gives an overview of the extra information you can provide when registering a shipment. For full details of all the properties accepted by the **Register Shipments** endpoint, and the structure you should use when making the request, see the [API Reference](https://docs.sorted.com/react/api/#RegisterShipments).

The **Register Shipments** endpoint enables you to register:

* **References** - As well as the mandatory carrier tracking reference array, you can also register additional `custom_references` for the shipment. Custom references do not need to be unique (i.e. you can register the same custom reference for multiple shipments if required), but we would recommend that you use unique custom references where possible to help you retrieve shipment data easily.
* **Tags** - Tags enable you to associate related shipments (such as all shipments of a particular product, or all shipments of products on special offer) with each other. You can also use tags to select the shipments that go into your shipment filters.

   > <span class="note-header">Note:</span>
   >
   > You can add up to 20 tags to a shipment, and each tag must be between three and 30 characters long. If you attempt to add more than 20 tags then only the first 20 are stored. Tags are not case-sensitive, and you cannot add duplicate tags within the same shipment.
* **Carrier Details** - If required, you can register `carrier`  and `carrier_service` details.
* **Dates** - The `order_date`, `shipped_date` and `promised_date` properties enable you to record when a shipment was ordered and shipped, and when the customer was told that it would be delivered.
* **Addresses** - The `addresses` array enables you to record multiple addresses against a single shipment. You can record origin, destination, return, billing, delivery hub, and alternative delivery addresses.
* **Consumer Info** - The `consumer` array enables you to record your customer's contact details. 
* **Custom Metadata** - You can specify custom metadata properties using the `metadata` array. Each property requires a `key`, `value`, and data `type`. 
* **Shipment Types** - The `shipment_type` property enables you to record whether a shipment is a delivery, return, pick up, drop off, combined drop off / pick up, or return drop off. 

### Why Register Additional Information?

If you only provide a carrier reference when registering then REACT is limited to reporting back on what the carrier says about that particular shipment. Providing additional information enables REACT to do the following:

* **Offer flexible retrieval options** - Some of REACT's API endpoints enable you to retrieve shipments, events or tracking events based on criteria other than REACT `{id}` numbers or carrier references. For example, you can use the [Get Shipments](https://docs.sorted.com/react/api/#GetShipments) endpoint to retrieve shipment details based on custom references, such as your own internal order number for the shipment in    question. However, REACT can only return a shipment via custom reference if you've previously supplied a custom reference for that shipment.

   Also, adding `tags` to your shipments enables you to fine-tune the list of shipments that you receive webhooks for. For example, you might have a "Special-Offer" tag that you would apply to shipments of products in a particular sale. You could then set up a shipment filter including only those shipments with your "Special-Offer" tag. This shipment filter could in turn be used to power a webhook sending branded offer-specific delivery communications to customers who have purchased products in the sale.   

* **Provide rich webhook and API results** - Adding additional shipment data enables REACT's webhooks and APIs to return richer results. When triggered, webhooks send a `ShipmentEvents` object to you. As well as event details, this object contains a `ShipmentSummary` - an overview of the data REACT holds on the shipment in question. The more information REACT holds on the shipment, the more useful this `ShipmentSummary` will be. 

* **Offer enhanced UI functionality** - You will need to provide additional shipment information in order to use the Dashboard's data filters. You can filter Dashboard data by carrier, state, country of origin, destination country, important dates, and shipment type, but only for those shipments that have the relevant information recorded. In addition, shipments will only show up on the **States** dashboard map if they have an address with an `address_type` of *Origin*. 

* **Use Calculated Properties** - If you add a `promised_date` to your shipments then REACT can automatically mark shipments as late where required. Likewise, adding a `country_iso_code` for both destination and origin addresses enables REACT to perform `may_be_missing` calculations, in which it marks a shipment as potentially missing if that shipment is not updated for a set period of time.

### Example Detailed JSON Request

The following example shows a shipment registered with additional detail on tags, dates, consumer information, and custom tracking references. For full details of all the properties accepted by the **Register Shipments** endpoint, see the [API Reference](https://docs.sorted.com/react/api/#RegisterShipments)

```json
{
  "shipments": [
    {
      "tags": [
        "Special_Offer",
        "BRAND_X",
        "DTWD"
      ],
      "tracking_references": [
        "TRK098JKH54ADD"
      ],
      "custom_references": [
        "fb60aa0f3e2d4247b8e01c659d621b8e",
        "HB-003"
      ],
      "carrier": "Carrier X",
      "carrier_service": "Next Day Priority",
      "shipped_date": "2018-11-12T00:00:00+00:00",
      "order_date": "2018-11-12T00:00:00+00:00",
      "promised_date": {
        "start": "2018-11-19T09:00:00+00:00",
        "end": "2018-11-19T12:00:00+00:00"
      },
      "addresses": [
        {
          "address_type": "origin",
          "reference": "555d66aa24864fbdae58d8c13afb51e0"
        },
        {
          "address_type": "destination",
          "postal_code": "N2 3FD",
          "country_iso_code": "GB"
        }
      ],
      "consumer": {
        "reference": "JYvkxEdlxE2Xeiv2W5W8TA",
        "email": "frankie_smith100@outlook.com",
        "phone": "+44161559844",
        "mobile_phone": "+447395654853",
        "first_name": "Francesca",
        "last_name": "Smith",
        "middle_name": "Helena",
        "title": "Ms"
      },
      "metadata": [
        {
          "key": "warehouse_identifier",
          "value": "WHF-0099282323A6",
          "type": "String"
        },
        {
          "key": "refundable",
          "value": "false",
          "type": "Boolean"
        },
        {
          "key": "expiration_date",
          "value": "2025-10-03T00:00",
          "type": "DateTime"
        }
      ],
      "retailer": "Smith & Gold GmbH",
      "shipment_type": "delivery"
    }
  ]
}
```

<span class="text--caption text--center">Detailed Register Shipments request.</span>

This example has values specified in the `custom_references` array. These could be internal order numbers, customer references, or anything else you choose. Now that REACT has been given this data, you could use these references to retrieve information via the **Get Shipment Events** and **Get Shipments** endpoints. 

In this case, the metadata array has been used to add a warehouse SKU, indicate whether the shipment is refundable, and provide an expiration data for the shipment contents.

REACT validates all **Register Shipment** requests in line with the rules set out in the API reference. Where an uploaded shipment does not meet this validation, REACT returns an error.

## CSV File Structure

Adding additional information when registering shipments via SFTP may require you to represent complex objects in your CSV. CSV objects are represented as `[object name]/[property name]`. Objects can be nested within objects using the syntax `[Parent object name]/[Child object name]/[property name]`.

Where an object can take multiple records (such as the `addresses` object, which can be used to record multiple addresses against a single shipment), a record number is added directly after each instance of the object in question. Record numbers should start from 0. 

For example, multiple `addresses` could be represented as:

```
""addresses/0/address_type","addresses/0/postal_code","addresses/0/lat_long/latitude","addresses/0/lat_long/longitude","addresses/1/address_type","addresses/1/postal_code","addresses/1/lat_long/latitude","addresses/1/lat_long/longitude"
"origin","ST4 4EG","123","456","destination","M33 5EW","789","012"

```

<span class="text--caption text--center">Nested address objects in CSV format.</span>

### Examples

The following examples represent the same data structure:

**JSON**

```json
{
  "shipments": [
    {
      "tracking_references": [
        "TRK098JKH54ADD"
      ],
      "custom_references": [
        "29ab72c406a94efb8e0797deb309ee4d",
        "HB-003"
      ],
      "carrier": "Carrier X",
      "carrier_service": "Next Day Priority",
      "addresses": [
        {
          "address_type": "origin",
          "postal_code": "ST4 4EG",
          "lat_long": {
            "latitude": "80",
            "longitude": "179"
          }, 
        },
        {
          "address_type": "destination",
          "postal_code": "N2 3FD",
          "country_iso_code": "GB"
        }
      ],
    }
  ]
}
```

**CSV**

```
"tracking_reference","custom_references/0","custom_references/1","carrier","carrier_service","addresses/0/address_type","addresses/0/postal_code","addresses/0/lat_long/latitude","addresses/0/lat_long/longitude","addresses/1/address_type","addresses/1/postal_code","addresses/1/country_iso_code"
"TRK098JKH54ADD","29ab72c406a94efb8e0797deb309ee4d","HB-003","Carrier X","Next Day Priority","origin","ST4 4EG","123","456","destination","N2 3FD","GB"
```

<span class="text--caption text--center">The same shipment data represented in JSON and CSV formats.</span>

### Downloadable CSV File

Click the button below to download an example CSV file showing a detailed shipment registration.

<a className="button button--grey-outline" href="shipments-1-valid.csv">Example CSV file</a><br/><br/> 

## Next Steps

Learn more about integrating with REACT:

* [Retrieving Shipment and Event Data](https://docs.sorted.com/react/retrieving-data/)
* [Updating Shipments](https://docs.sorted.com/react/updating-shipments/)
* [Error Codes](https://docs.sorted.com/react/error-codes/)