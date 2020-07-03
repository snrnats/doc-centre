---
uid: react-help-integration-guide
title: API User Guide
tags: react,api,integration
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# API User Guide

SortedREACT's APIs enable you to integrate REACT functionality into your own systems and sites. This section explains how to call REACT's API endpoints.

---

## REACT Endpoints

REACT offers the following API endpoints:

| Endpoint                                                                                               | Purpose                                                        |
| ------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------- |
| [Register Shipments](https://docs.sorted.com/react/api/#RegisterShipments)                             | Register shipments for tracking                                |
| [Get Shipment by Shipment ID](https://docs.sorted.com/react/api/#GetShipmentbyShipmentID)              | Retrieve shipment details by REACT Shipment ID                 |
| [Get Shipments](https://docs.sorted.com/react/api/#GetShipments)                                       | Retrieve shipment details by tracking or custom reference      |
| [Update Shipment](https://docs.sorted.com/react/api/#UpdateShipment)                                   | Update shipment details                                        |
| [Delete Shipment](https://docs.sorted.com/react/api/#DeleteShipment)                                   | Delete a shipment                                              |
| [Get Tracking Events by Shipment ID](https://docs.sorted.com/react/api/#GetTrackingEventsbyShipmentID) | Retrieve all shipment tracking events for a specified shipment |
| [Get Event](https://docs.sorted.com/react/api/#GetEvent)                                               | Retrieve events by REACT Event ID                              |
| [Get Shipment Events](https://docs.sorted.com/react/api/#GetShipmentEvents)                            | Retrieve events by date range, references and carrier          |
| [Get Shipment Events by Shipment ID](https://docs.sorted.com/react/api/#GetShipmentEventsbyShipmentID) | Retrieve event details by REACT Shipment ID                    |
| [Get Shipment States History](https://docs.sorted.com/react/api/#GetShipmentStatesHistory)             | Retrieve a shipment's shipment state history                   |

## Calling REACT's APIs

To call any of the APIs, you'll need an API key. You can create one from the **Settings** > **API Keys** tab in the REACT UI.

> [!NOTE]
>
> For more information on getting a REACT API key, see the [Setting up API keys](/react/help/settings.html#setting-up-api-keys) section of the **Settings** page.

To use your API key, include it in an `x-api-key` header when making an API call. We also recommend that you include JSON `Content-Type` and `Accept` headers too, as REACT only works with JSON data. 

## API User Guide Contents

* [Registering Shipments](registering-shipments.md) - Explains how to use the **Register Shipments** endpoint and the SFTP bulk upload service to add shipments to REACT. 
* [Retrieving Shipment and Event Data](retrieving-data.md) - Explains how to get data from the **Shipment**, **Tracking**, and **Events** APIs.
* [Updating Shipments](updating-shipments.md) - Explains how to use the **Update Shipment** API to update and existing shipment's details.
* [Error Codes](error-codes.md) - Explains the various error codes that REACT can return.
* [Calculated Events](calc-events.md) - Explains how REACT calculates events, and how those events affect shipments.