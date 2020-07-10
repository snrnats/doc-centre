All PRO endpoints that queue multiple shipments for allocation return an Allocate Shipments result. The Allocate Shipments result includes a list of all shipments that were successfully queued and details of all shipments that were rejected for allocation, including the references of those shipments and the reason for rejection.

<span class="highlight">AT WHAT POINT ARE QUEUED SHIPMENTS ALLOCATED? DOES IT RETURN A CONFIRMATION OR SOMETHING AT THAT POINT?</span>

> [!NOTE]
> When you make a request to allocate multiple shipments simultaneously, PRO queues those shipments to be allocated at a later time rather than allocating them straight away. This helps to optimise performance. PRO then allocates queued shipments via an automated background process. 
>
> If you only need to allocate a single shipment, you should use one of PRO's allocation endpoints for individual shipments (**Allocate Shipment**, **Allocate Shipment with Carrier Service**, **Allocate Shipment with Service Group** and **Allocate Shipment with Quote**) rather than a bulk allocation endpoint. Using an individual endpoint means that the shipment is allocated straight away.