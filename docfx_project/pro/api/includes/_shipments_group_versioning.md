When you specify a `custom_reference` for a shipment group, PRO assigns that group a `version` number. Combined, the `custom_reference` and `version` provide a unique identifier for the group. A group's `version` number indicates how many times you have used that group's `custom_reference`. 

For example, suppose that you choose to use shipment groups to represent carrier trailers, so that you can manifest an entire trailer of shipments at once. To this end, you create a shipment group with a `custom_reference` of _CarrierX-PM_ to represent Carrier X's daily afternoon collection. 

The first time you create this group, the group has a `version` number of _1_. You add the relevant shipments to the group, manifest them using the **Manifest Shipments by Shipment Group** endpoint as they are picked up, and then close the shipment group.

The following day, you create a new shipment group for that day's collection. As before, you use a `custom_reference` of _CarrierX-PM_. This time, however, PRO responds with a `version` number of _2_, as this is the second time that that `custom_reference` has been used. 

You can now use the version number to point to the shipment group you want. _CarrierX-PM_ version _1_ points to the original (now closed) shipment group, while _CarrierX-PM_ version _2_ points to the new group. Note that both groups also have unique (PRO-generated) `references`.