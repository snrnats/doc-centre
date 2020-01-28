PRO's Consignments object (and its related objects - Delivery Options, Pickup Options and Orders) includes a `MetaData` array. This array can be used to record additional data about the consignment in custom fields. 

The `MetaData` array has two parts - the `KeyValue` and the metadata values. The `KeyValue` is the name of the property, while the metadata values are the data items themselves. The fields that should be used to store this data varies depending on the data types being stored. 

Metadata values can be stored in the following fields:

* `StringValue` - used to store data as a string.
* `IntValue` - used to store data as an integer.
* `DecimalValue` - used to store data as a decimal.
* `DateTimeValue` - used to store data as a DateTimeOffset.
* `BoolValue` - used to store data as a Boolean (true/false).

Each metadata object can contain multiple data items, but can only contain one data item of each type. For example, a `MetaData` array containing a `StringValue` and a `BoolValue` would be valid, but a `MetaData` array containing two `StringValue` keys would not.

### Metadata Example

The example shows a `MetaData` array that is being used to store a consignment's picking data. The `StringValue` property is being used to record the name of the picker, and the `DateTimeValue` is being used to record the date and time that the consignment was picked.

<div class="tab">
    <button class="staticTabButton">Example MetaData array</button>
    <div class="copybutton" onclick="CopyToClipboard('metadataExample')">Click to Copy</div>
</div>

<div id="metadataExample" class="staticTabContent" onclick="CopyToClipboard('metadataExample')">

```json
"MetaData": [
   {
      "KeyValue": "Picked_On",
      "StringValue": "Josh Allen",
      "DateTimeValue": "2019-06-04T00:00:00+01:00"
   }
]
```

</div>