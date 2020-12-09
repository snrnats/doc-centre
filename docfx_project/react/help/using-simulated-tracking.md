---
uid: react-help-using-simulated-tracking
title: Using Simulated Tracking
tags: react,api,shipments,registration,simulated tracking,fake tracking
contributors: andy.walton@sorted.com,michael.rose@sorted.com
created: 29/05/2020
---
# Using Simulated Tracking

Simulated tracking enables you to generate dummy tracking events for your registered shipments to help with testing or demonstrations. This page explains how to use simulated tracking in REACT.

---

## How Does Simulated Tracking Work?

Ordinarily, REACT shipments are updated by external communication from carriers. When the system receives a carrier tracking event that includes changes to one of your registered shipments, REACT creates a shipment event and updates the shipment details as necessary.

However, it may sometimes be necessary for REACT to generate its own tracking events. For example, you may be in the process of integrating with REACT's **Get Shipment Events** or **Get Tracking Events** endpoints, and need some non-live test data to work with.

Simulated tracking is a means of generating dummy tracking events as part of a **Register Shipment** API call. When you register a dummy shipment (that is, a shipment that does not correspond with a real-life delivery) that has a `simulated_tracking` property, REACT creates its own standardised tracking and shipment events in the same way that it would if it had received "real" carrier tracking events for the shipment. You can then use these simulated tracking events for testing or demonstration purposes.

## Using Simulated Tracking

Before you can receive tracking events from a particular simulated carrier, you will first need to setup a connector for that simulated carrier. REACT can simulate tracking events from the following carriers:

* Yodel
* DPD UK
* DPD Local
* Lineten

For more information on setting up carrier connectors, see the [Setting Up Carrier Connectors](/react/help/settings.html#setting-up-carrier-connectors) section of the **Settings** page.

Once you have set up a connector for the carrier whose tracking events you want to simulate, you can use simulated tracking by registering a shipment with a `simulated_tracking` property. 

> [!CAUTION]
> Simulated tracking should be used for testing and demonstration purposes only. Registering a `simulated_tracking` property for a live shipment could result in incorrect tracking data.

The `simulated_tracking` property has two sub-properties:

* `simulation_type` is the tracking scenario you want to simulate. At present, this property can either take a value of `delivered`, in which REACT generates tracking events simulating an issue-free delivery, or `random`, in which REACT generates a random tracking scenario.  
* `carrier_reference` is the name of the carrier you want to simulate tracking events for: `yodel`, `dpd_uk`, `dpd_local`, or `lineten`.

Shortly after you have registered a shipment with a `simulated_tracking` property, REACT generates dummy carrier tracking events for that shipment in line with the tracking scenario specified. The system treats these tracking events in the same way as it would a "regular" tracking event, creating corresponding shipment events and updating the shipment's properties accordingly. 

> [!NOTE]
> For more information on how REACT processes incoming tracking events, see the [How REACT Works](/react/help/overview.html#how-react-works) section of the **Overview** page.

## Example Simulated Tracking Call

The example below shows a simple shipment registered with a `simulated_tracking` property.

# [Register Shipment Request with Simulated Tracking](#tab/register-shipment-request-with-simulated-tracking)

```json

{
  "shipments": [
    {
      "tracking_references": [
          "sim_tracking_example"
      ],  
      "simulated_tracking": {
          "simulation_type": "random",
          "carrier_reference": "dpd_local"
      }
    }
  ]
}

```

## Next Steps

Learn more about integrating with REACT:

* [Retrieving Shipment and Event Data](/react/help/retrieving-data.html)
* [Updating Shipments](/react/help/updating-shipments.html)
* [Error Codes](/react/help/error-codes.html)