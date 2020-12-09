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

Ordinarily, REACT shipments are updated by external communication from carriers. When the system receives a carrier communication that includes changes to one of your registered shipments, then REACT creates a shipment event and updates the shipment details as necessary.

However, it may sometimes be necessary for REACT to generate its own events. For example, you may be in the process of integrating with REACT's **Get Shipment Events** or **Get Tracking Events** endpoints, and need some non-live test data to work with.

Simulated tracking is a means of generating dummy tracking events as part of a **Register Shipment** API call. When you register a dummy shipment (that is, a shipment that does not correspond with a real-life delivery) that has a `simulated_tracking` property, then REACT creates its own standardised tracking and shipment events in the same way that it would if it had received "real" carrier tracking events for the shipment. You can then use these simulated tracking events for testing or demonstration purposes.

## Using Simulated Tracking

REACT can simulate tracking events from the following carriers:

* Yodel
* DPD UK
* DPD Local
* Lineten

Before you can receive tracking events from a particular simulated carrier, you will first need to setup a connector for that simulated carrier.  

<span class="highlight"> WHAT IS THE PROCESS HERE? ARE THE DETAILS REQUIRED THE SAME AS FOR A STANDARD CARRIER? WHAT DO CUSTOMERS PROVIDE FOR LOGIN REQUIREMENTS ETC</span>

Once you have set up a connector for the carrier whose tracking events you want to simulate, you can use simulated tracking by registering a shipment with a `simulated_tracking` property. The `simulated_tracking` property has two sub-properties:

* `simulation_type` is the
* `carrier_reference` is the 


      "simulated_tracking": {
          "simulation_type": "random",
          "carrier_reference": "dpd_local"
      }

Set up carrier connector

Register simulated_tracking property

After a short delay REACT generates tracking events & associated shipment events & returns them

Returned events can be used as POC or as means of testing integrations set up to receive tracking / shipment events

Prod examples: sp_4238450550120644608, sp_4253405941824815104, tracking_ref "sim_tracking_test"

## Next Steps

Learn more about integrating with REACT:

* [Retrieving Shipment and Event Data](/react/help/retrieving-data.html)
* [Updating Shipments](/react/help/updating-shipments.html)
* [Error Codes](/react/help/error-codes.html)