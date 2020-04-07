# Tracking Consignments Using REACT

SortedPRO integrates seamlessly with REACT, Sorted's dedicated shipment tracking platform. PRO can automatically register shipments with REACT, and share carrier and tracking information. This page explains how PRO and REACT can interact with each other, and the benefits this brings.

> <span class="note-header">Note:</span>
>
> For integration guides and user help on REACT, see the [REACT](/react/help/overview.html) section of this site.

---

## Benefits Of Using REACT



## Integrating PRO and REACT

When you sign up to REACT as a PRO customer, your REACT and PRO accounts are automatically linked. You do not need to do any additional configuration beyond the regular configuration processes for each product.

REACT uses carrier connectors to keep shipments from a particular carrier up to date. Carrier connectors contain configuration that enables REACT to obtain carrier tracking data. Ordinarily, you would need to configure carrier connectors yourself as part of the REACT setup process. However, when you sign up to REACT as a PRO customer, REACT takes your carrier configuration from PRO, enabling you to use your existing carrier integrations in REACT without needing to provide any additional details.

To use your PRO carriers with REACT, navigate to **Settings** > **Carrier Connectors** within the REACT UI, and click **Connect**.

## Registering PRO Consignments In REACT

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

> <span class="note-header">More Information:</span>
>
> * For more information on the structure of a REACT shipment, see the [Register Shipments](https://docs.sorted.com/react/api/#RegisterShipments) section of the REACT API reference and the [Registering Shipments](/react/help/registering_shipments.html) page of the REACT help.
> * For more information on the structure of a PRO consignment, see the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) page of the PRO API reference and the [Creating New Consignments](/pro/api/help/creating_new_consignments.html) page of the PRO help.

## After Registration

Once a PRO consignment has been registered as a REACT shipment, PRO automatically keeps REACT updated of any changes. Whenever PRO downloads a new carrier file, it updates any shipments in that file that you have registered with REACT accordingly. 

## Next Steps

* Learn how to get customs docs and invoices for international shipments at the [Getting Customs Docs and Invoices](/pro/api/help/getting_customs_docs_and_invoices.html) page.
* View the [REACT User Guide](/react/help/overview.html).
* Learn how to manifest consignments at the [Manifesting Consignments](/pro/api/help/manifesting_consignments.html) page.

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>