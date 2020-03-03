---
title: Shipment States
slug: "/shipment-states/"
member: "Reference Info"
order: 6
description: "Start your React integration in just a few simple steps."
keywords: "delivery, states, delivery-states, shipment, shipment-states, condition, tracking, progress, status, statuses, shipping"
---

This table displays available REACT shipment states and indicates which carriers have tracking events mapped to each state.

<div class="table-1">

| Shipment Delivery State        | Description                                                                                                            | Carriers with Mapped Events        |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------- | ------------------------------- |
| Action Required </br><div class="tred">(Red)</div>                | The carrier should be contacted                                                                                      | Yodel (File), Hermes, DPD, Arrow XL, Parcel Force, FedEX (API), DHL Parcel UK, DHL Express, P2P Trackpak (API), DPD Local UK |
| Arrived at destination country </br><div class="tgreen">(Green)</div> | The shipment has arrived at the destination country                                                                    | Yodel (File), Hermes, DPD, P2P Trackpak (API), DPD Local UK |
| At customs</br><div class="tgreen">(Green)</div>                     | The shipment is being cleared through customs                                                                          | Yodel (File), Hermes, DPD, FedEX (API), DHL Express, P2P Trackpak (API), DPD Local UK|
| Awaiting drop-off</br><div class="tgreen">(Green)</div>              | Carrier is waiting for the customer to drop off the shipment                                                           | Hermes, P2P Trackpak (API) |
| Carrier changed</br><div class="tgreen">(Green)</div>                | The shipment has been handed over to a new carrier                                                                     | Hermes, Arrow XL, Parcel Force, DHL Express, P2P Trackpak (API) |
| Carrier refused to collect</br><div class="tred">(Red)</div>     | Collection failed because of customer’s expectations or because there was nothing to collect                           | Yodel (File), DPD, Arrow XL, Parcel Force, DHL Parcel UK, DPD Local UK|
| Carrier unable to collect</br><div class="tamber">(Amber)</div>      | Collection failed due to the carrier’s operational issues                                                              | Yodel (File), DPD, Arrow XL, Parcel Force, DPD Local UK  |
| Cleared through customs</br><div class="tgreen">(Green)</div>        | The shipment has been cleared through customs                                                                          | Yodel (File), Hermes, DPD, P2P Trackpak (API), DPD Local UK|
| Collected by carrier</br><div class="tgreen">(Green)</div>           | The shipment was collected by the carrier                                                                              | Yodel (File), Hermes, DPD, Parcel Force, FedEX (API), DHL Parcel UK, DPD Local UK |
| Collection reminder</br><div class="tgreen">(Green)</div>           | Reminder for the customer to collect their shipment or it will be returned to sender                                   | Hermes, ASDA To You |
| Collection rescheduled</br><div class="tgreen">(Green)</div>        | The shipment collection has been rescheduled                                                                           | Hermes, Arrow XL |
| Collection scheduled</br><div class="tgreen">(Green)</div>           | The carrier will collect the shipment from the customer                                                                | Hermes, Arrow XL, FedEX (API), DHL Express |
| Customs charges due</br><div class="tamber">(Amber)</div>          | The shipment is being held by the carrier awaiting payment of customs charges                                          | Yodel (File), Arrow XL, FedEX (API), P2P Trackpak (API) |
| Damaged</br><div class="tred">(Red)</div>                      | The shipment was damaged in transit                                                                                    | Yodel (File), Hermes, DPD, Arrow XL, Parcel Force, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API)     |
| Delayed</br><div class="tamber">(Amber)</div>                     | The shipment is delayed                                                                                                | Yodel (File), Hermes, DPD, Parcel Force, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API)   |
| Delivered</br><div class="tgreen">(Green)</div>                  | The shipment has been delivered                                                                                        | Yodel (File), Hermes, DPD, Arrow XL, Parcel Force, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API) |
| Delivered damaged</br><div class="tred">(Red) </div>             | The shipment was delivered, but it was damaged                                                                         | Yodel (File), Hermes, Arrow XL, ASDA To You, DHL Express     |
| Delivered to neighbour</br><div class="tgreen">(Green) </div>        | The shipment was delivered to a neighbour                                                                              | Yodel (File), Hermes, Parcel Force, P2P Trackpak (API)  |
| Delivered to reception</br><div class="tgreen">(Green) </div>        | The shipment was delivered to reception                                                                                | Hermes |
| Delivered to safe location</br><div class="tgreen">(Green) </div>    | The shipment was left in a safe location                                                                               | Yodel (File), Hermes, Parcel Force, FedEX (API) |
| Delivery address changed </br><div class="tgreen">(Green) </div>     | The delivery address has changed                                                                                       | Hermes, FedEX (API) |
| Delivery attempted</br><div class="tgreen">(Green)  </div>           | The carrier attempted to deliver the shipment                                                                          | Hermes, Parcel Force, FedEX (API), P2P Trackpak (API) |
| Delivery failed</br><div class="tred">(Red)  </div>              | Delivery failed                                                                                                        | Yodel (File), Hermes, DPD, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API)     |
| Delivery failed card left</br><div class="tgreen">(Green) </div>     | Delivery failed, but the carrier left a calling card                                                                   | Yodel (File), Hermes, DPD, Arrow XL, DHL Parcel UK, DHL Express, P2P Trackpak (API) |
| Delivery refused</br><div class="tred">(Red)</div>           | The shipment delivery was refused                                                                                      | Yodel (File), Hermes, DPD, Arrow XL, Parcel Force, FedEX (API), DHL Parcel UK, DHL Express, P2P Trackpak (API)     |
| Delivery rescheduled</br><div class="tgreen">(Green)</div>         | The delivery date and/or time has been changed                                                                         | Yodel (File), DPD, Arrow XL, FedEX (API) |
| Delivery scheduled</br><div class="tgreen">(Green)</div>           | Delivery has been scheduled with the customer                                                                          | Yodel (File), Hermes, DPD, Arrow XL, Parcel Force, FedEX (API), P2P Trackpak (API) |
| Destroyed</br><div class="tred">(Red)</div>                   | The shipment was destroyed by the carrier (e.g. because it was too damaged, or it was dangerous)                       | Hermes, Arrow XL, Parcel Force, DHL Express, P2P Trackpak (API)     |
| Dispatched</br><div class="tgreen">(Green)</div>                   | The shipment has been dispatched (registered)                                                                          | Yodel (File), Hermes, DPD, Arrow XL, Parcel Force, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API), DPD Local UK |
| Dropped-off</br><div class="tgreen">(Green)</div>                  | The shipment was dropped off by the customer                                                                           | Yodel (File) |
| Exchange failed</br><div class="tred">(Red)</div>             | Exchange was unsuccessful                                                                                              | Yodel (File), DPD     |
| Exchange successful</br><div class="tgreen">(Green)</div>          | Exchange was successful                                                                                                | |
| Failed to collect</br><div class="tamber">(Amber)</div>             | The customer did not collect the shipment from the collection location                                                 | Yodel (File), Hermes, DPD, Parcel Force  |
| Final collection reminder</br><div class="tgreen">(Green)</div>      | Final reminder for the customer to collect their shipment or it will be returned to sender                             | Hermes, ASDA To You |
| Final delivery attempt</br><div class="tamber">(Amber)</div>       | The carrier attempted to deliver for the last time                                                                     | Hermes |
| Held by carrier</br><div class="tamber">(Amber)</div>                | The shipment is being held by the carrier                                                                              | Yodel (File), Hermes, DPD,      |
| In transit</br><div class="tgreen">(Green)</div>                  | The shipment is in transit                                                                                             | Yodel (File), Hermes, DPD, Parcel Force, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API) |
| In transit, waiting</br><div class="tamber">(Amber)</div>         | The carrier is either waiting until transit can resume (e.g. due to Force Majeure or 1 cm of snow)                     | Yodel (File), Hermes, DPD, FedEX (API), DHL Parcel UK, DHL Express, P2P Trackpak (API) |
| Incorrect Label</br><div class="tred">(Red)</div>             | The shipment was labelled incorrectly and so was sent to the wrong place.                                              | Yodel (File), Hermes, DPD, DHL Express |
| Lost</br><div class="tred">(Red)</div>                       | The carrier lost the shipment (or it was stolen)                                                                       | Hermes, Arrow XL, ASDA To You, DHL Parcel UK     |
| Misrouted</br><div class="tamber">(Amber)</div>                   | The shipment was labelled correctly but was sent to the wrong place due to incorrect handling                          | Hermes, DPD, Parcel Force, FedEX (API), DHL Express, P2P Trackpak (API) |
| Missing</br><div class="tred">(Red)</div>                     | The carrier is trying to locate the shipment                                                                           | Yodel (File), Hermes, DPD, Arrow XL, ASDA To You, DHL Express    |
| Missing manifest</br><div class="tred">(Red)</div>             | The shipment was not manifested with the carrier                                                                       | Hermes     |
| Out for delivery</br><div class="tgreen">(Green)</div>             | The shipment is out for delivery                                                                                       | Yodel (File), Hermes, DPD, Parcel Force, FedEX (API), ASDA To You, DHL Parcel UK, DHL Express, P2P Trackpak (API) |
| Partially delivered</br><div class="tamber">(Amber)</div>          | Part of the shipment was delivered                                                                                     | Parcel Force, DHL Parcel UK, P2P Trackpak (API)|
| Proof of delivery available</br><div class="tgreen">(Green)</div>  | Proof of delivery is available                                                                                         | FedEX (API) |
| Ready for collection</br><div class="tgreen">(Green)</div>        | The shipment is ready to be collected by the customer                                                                  | Yodel (File), Hermes, DPD, Parcel Force, FedEX (API), ASDA To You, P2P Trackpak (API)|
| Refunded</br><div class="tgreen">(Green)</div>                   | The shipment has been refunded                                                                                         |  |
| Returned to sender</br><div class="tgreen">(Green)</div>          | The shipment has been returned to the sender                                                                           | Yodel (File), Hermes, FedEX (API), DHL Parcel UK, P2P Trackpak (API) |
| Shipment issue</br><div class="tamber">(Amber)</div>               | There is an issue with the shipment (e.g. it is over-sized). The carrier will still transport it, but may charge extra | Hermes |
| Unable to track</br><div class="tred">(Red)</div>               | REACT cannot track the shipment due to an error                                                                        |      |
| Will be returned to sender</br><div class="tamber">(Amber)</div>   | The shipment will be returned to sender                                                                                | Hermes, Arrow XL, Parcel Force, FedEX (API), DHL Parcel UK, DHL Express, P2P Trackpak (API)|

</div>

> <span class="note-header">Note: </span>
>
> The **Carriers with Mapped Events** column displays the carriers that have a tracking event mapped for each shipment state. If a carrier does not have an event mapped for a particular state then shipments with that carrier can never assume that state, because the carrier does not have any events that correspond to it.
> 
> You should bear this information in mind when setting up shipment filters, in order to avoid setting up a filter for an state that your carriers do not use. For more information on configuring shipment filters, see [Managing Your Shipment Filters](https://docs.sorted.com/react/managing-webhooks/#managing-your-shipment-filters). 
