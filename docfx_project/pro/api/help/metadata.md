---
uid: pro-api-help-metadata
title: Metadata
tags: v1,metadata,pro,api,consignments
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Metadata

PRO's Consignments object (and its related objects - Delivery Options, Pickup Options and Orders) includes a `MetaData` array. This array can be used to record additional data about the consignment in custom fields. This page explains how to do so.

---

## Metadata Overview

The `MetaData` array has two parts - the `KeyValue` and the metadata values. The `KeyValue` is the name of the property, while the metadata values are the data items themselves. The fields that should be used to store this data varies depending on the data types being stored. 

Metadata values can be stored in the following fields:

* `StringValue` - used to store data as a string.
* `IntValue` - used to store data as an integer.
* `DecimalValue` - used to store data as a decimal.
* `DateTimeValue` - used to store data as a DateTimeOffset.
* `BoolValue` - used to store data as a Boolean (true/false).

Each metadata object can contain multiple data items, but can only contain one data item of each type. For example, a `MetaData` array containing a `StringValue` and a `BoolValue` would be valid, but a `MetaData` array containing two `StringValue` keys would not.

## Metadata Example

The example shows a `MetaData` array that is being used to store a consignment's picking data. The `StringValue` property is being used to record the name of the picker, and the `DateTimeValue` is being used to record the date and time that the consignment was picked.

# [Metadata Property](#tab/metadata-property)

```json
"MetaData": [
   {
      "KeyValue": "Picked_On",
      "StringValue": "Josh Allen",
      "DateTimeValue": "2019-06-04T00:00:00+01:00"
   }
]
```
---
