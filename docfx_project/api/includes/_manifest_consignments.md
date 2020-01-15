> Manifest Consignments Endpoint
```
PUT https://api.electioapp.com/consignments/manifest
```
> Example Manifest Consignment Request

```json
{
  "ConsignmentReferences": [
    "EC-000-05A-Z6S",
    "EC-000-083-45D",
    "EC-000-A04-0DV"
  ]
}
```
```xml
<?xml version="1.0" encoding="utf-8"?>
<ManifestConsignmentsRequest xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
  <ConsignmentReferences>
    <string>EC-000-05A-Z6S</string>
    <string>EC-000-083-45D</string>
    <string>EC-000-A04-0DV</string>
  </ConsignmentReferences>
</ManifestConsignmentsRequest>
```

> Example Manifest Consignment Response

```json
[
  {
    "IsSuccess": true,
    "Message": "Consignment EC-000-002-5FG has been manifested successfully.",
    "Data": "EC-000-002-5FG",
    "ApiLinks": [
      {
        "Rel": "Link",
        "Href": "https://api.electioapp.com/consignments/EC-000-002-5FG"
      }
    ]
  },
  {
    "IsSuccess": true,
    "Message": "Consignment EC-000-002-5FG has been manifested successfully.",
    "Data": "EC-000-002-5FG",
    "ApiLinks": [
      {
        "Rel": "Link",
        "Href": "https://api.electioapp.com/consignments/EC-000-002-5FG"
      }
    ]
  },
  {
    "IsSuccess": true,
    "Message": "Consignment EC-000-002-5FG has been manifested successfully.",
    "Data": "EC-000-002-5FG",
    "ApiLinks": [
      {
        "Rel": "Link",
        "Href": "https://api.electioapp.com/consignments/EC-000-002-5FG"
      }
    ]
  }
]
```
```xml
<?xml version="1.0" encoding="utf-8"?>
<ArrayOfWithMessageOfString xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <WithMessageOfString>
    <IsSuccess xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">true</IsSuccess>
    <Message xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Consignment EC-000-002-5FG has been manifested successfully.</Message>
    <Data xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">EC-000-002-5FG</Data>
    <ApiLinks xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
      <ApiLink>
        <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Link</Rel>
        <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://api.electioapp.com/consignments/EC-000-002-5FG</Href>
      </ApiLink>
    </ApiLinks>
  </WithMessageOfString>
  <WithMessageOfString>
    <IsSuccess xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">true</IsSuccess>
    <Message xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Consignment EC-000-002-5FG has been manifested successfully.</Message>
    <Data xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">EC-000-002-5FG</Data>
    <ApiLinks xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
      <ApiLink>
        <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Link</Rel>
        <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://api.electioapp.com/consignments/EC-000-002-5FG</Href>
      </ApiLink>
    </ApiLinks>
  </WithMessageOfString>
  <WithMessageOfString>
    <IsSuccess xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">true</IsSuccess>
    <Message xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">Consignment EC-000-002-5FG has been manifested successfully.</Message>
    <Data xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">EC-000-002-5FG</Data>
    <ApiLinks xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Consignments">
      <ApiLink>
        <Rel xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">Link</Rel>
        <Href xmlns="http://electioapp.com/schemas/v1.1/MPD.Electio.SDK.DataTypes.Common">https://api.electioapp.com/consignments/EC-000-002-5FG</Href>
      </ApiLink>
    </ApiLinks>
  </WithMessageOfString>    
</ArrayOfWithMessageOfString>
```

Once you've created a consignment, allocated it to a carrier service and printed labels for it, you're ready to manifest it. To manifest a consignment, use the **[Manifest Consignments](https://docs.electioapp.com/#/api/ManifestConsignments)** endpoint.

<aside class="info">
  In the context of SortedPRO, the term "manifest" refers to advising the carrier of all the consignments/packages to be collected from the shipper.
</aside>

The **Manifest Consignments** endpoint can be used to manifest multiple consignments at once. The request should contain an array of `{consignmentReference}`s, corresponding to the consignments to be manifested. 

All the consignments you provide in the request should be in a state of either _Allocated_ or _Manifest Failed_. If you attempt to manifest a consignment that is not in one of these states then PRO returns an error.

Once PRO has received the request and attempted to manifest the consignments, the **Manifest Consignments** endpoint returns an array of messages indicating whether each individual consignment was successfully manifested or not.

<aside class="note">
  For full reference information on the <strong>Manifest Consignments</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/ManifestConsignments">Manifest Consignments</a></strong> page of the API Reference. 
</aside>

### Examples

The example to the right shows a request to manifest three consignments. The response indicates that all three consignments were successfully manifested.