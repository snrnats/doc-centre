# Consignment States

<table>
    <tr>
        <th>Consignment State</th>
        <th>Description</th>
        <th>User Action(s)</th>        
    </tr>
    <tr>
        <td>Unallocated</td>
        <td>Consignment Created, no carrier allocated</td>
        <td>
            <p>Allocate consignment</p>
            <p>Cancel consignment</p>
            <p>Edit consignment details</p>
            <p>Add / Edit Package</p>
        </td>
    </tr>
    <tr>
        <td>Allocating</td>
        <td>Trying to allocate a carrier service</td>
        <td>N/A</td>        
    </tr>
    <tr>
        <td>Allocation Failed </td>
        <td>Attempt to allocate a carrier service failed</td>
        <td>
            <p>Allocate consignment</p>
            <p>Cancel consignment</p>
            <p>Edit consignment details</p>
            <p>Add / Edit Package</p>
        </td>        
    </tr>
    <tr>
        <td>Allocated</td>
        <td>Carrier service was successfully allocated</td>
        <td>
            <p>De-allocate consignment</p> 
            <p>Print labels</p> 
            <p>Manifest with Carrier</p> 
            <p>Cancel consignment</p> 
        </td>        
    </tr>
    <tr>
        <td>Manifesting</td>
        <td>Attempting to manifest consignment</td>
        <td>N/A</td>        
    </tr>
    <tr>
        <td>Manifested</td>
        <td>Consignment successfully manifested</td>
        <td>
            <p>De-allocate consignment</p> 
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
            <p>Mark as Dispatched</p> 
        </td>        
    </tr>
    <tr>
        <td>Manifest Failed</td>
        <td>Manifest attempt failed</td>
        <td>
            <p>De-allocate consignment</p> 
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
            <p>Manifest with Carrier</p> 
        </td>        
    </tr>
    <tr>
        <td>Cancelling</td>
        <td>Shipment is being cancelled</td>
        <td>N/A</td>        
    </tr>
    <tr>
        <td>Cancelled</td>
        <td>Shipment was cancelled</td>
        <td>N/A</td>        
    </tr>
    <tr>
        <td>Dispatched </td>
        <td>Shipment has been dispatched from its origin location</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>        
    </tr>
    <tr>
        <td>Collection Failed </td>
        <td>Collection failed because of customer's exceptions</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>      
    </tr>
    <tr>
        <td>Carrier Unable To Collect</td>
        <td>Collection failed because of carrier's operational issues</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>
    <tr>
        <td>Exchange Failed</td>
        <td>Exchange service failed</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>        
    </tr>
    <tr>
        <td>Collected</td>
        <td>Shipment was collected</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>At Drop Off Point</td>
        <td>Shipment was dropped-off at a shop by consumer</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>
    <tr>
        <td>In Transit</td>
        <td>Shipment is in transit</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>           
    </tr>
    <tr>
        <td>In Transit - Waiting</td>
        <td>Carrier is either waiting until transit can be resumed due to force majeure event OR delivery delayed on customer's request</td>
        <td>Print labels</td>        
    </tr>
    <tr>
        <td>At Customs</td>
        <td>Shipment is being cleared through customs</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>  
    </tr>
    <tr>
        <td>Action Required</td>
        <td>Carrier requires additional information</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>Delayed</td>
        <td>Shipment is delayed</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>Held By Carrier</td>
        <td>Shipment is held by the carrier</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>Missing</td>
        <td>Carrier cannot locate the shipment</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>
    <tr>
        <td>Lost</td>
        <td>Shipment lost</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>Damaged</td>
        <td>Shipment was damaged</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>Out For Delivery</td>
        <td>Shipment is out for delivery</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>
    <tr>
        <td>Delivered Damaged</td>
        <td>Shipment delivered, but it was damaged</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>
    <tr>
        <td>Partially Delivered</td>
        <td>Part of the shipment was delivered</td>
        <td>
            <p>Print labels</p>
        </td>        
    </tr>
    <tr>
        <td>At Collection Point</td>
        <td>Shipment is at a pickup shop</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>
    <tr>
        <td>Delivered</td>
        <td>Shipment Delivered</td>
        <td>
            <p>Print labels</p> 
        </td>       
    </tr>
    <tr>
        <td>Delivery Failed Card Left</td>
        <td>Delivery failed, but carrier left a calling card</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>          
    </tr>
    <tr>
        <td>Delivery Failed</td>
        <td>Delivery failed</td>
        <td>
            <p>Print labels</p> 
        </td>         
    </tr>
    <tr>
        <td>Return to Sender</td>
        <td>Shipment will be returned to sender</td>
        <td>
            <p>Print labels</p> 
            <p>Cancel consignment</p> 
        </td>         
    </tr>

<table>
    <tr>
        <th>User Action</th>  
        <th>Consignment State</th>      
    </tr>
    <tr>
        <td>Allocate consignment</td>
        <td>
            <p>Unallocated</p>
            <p>Allocation Failed</p>  
        </td>        
    </tr>
    <tr>
        <td>Edit consignment details </td>
        <td>
            <p>Unallocated</p>
            <p>Allocation Failed</p>  
        </td> 
    </tr>
    <tr>
        <td>Add / Edit Package</td>
        <td>
            <p>Unallocated</p>
            <p>Allocation Failed</p>  
        </td> 
    </tr>  
    <tr>
        <td>De-allocate</td>
        <td>
            <p>Allocated</p>  
            <p>Manifested</p>
            <p>Manifest Failed</p>  
        </td>
    </tr>  
    <tr>
        <td>Manifest with Carrier</td>
        <td>
            <p>Allocated</p>  
            <p>Manifest Failed</p>  
        </td>
    </tr>  
    <tr>
        <td>Mark as Dispatched </td>
        <td>
            <p>Manifested</p>
        </td>
    </tr>  
    <tr>
        <td>Print Labels</td>
        <td>
            <p>Allocated</p>  
            <p>Manifested</p>  
            <p>Manifest Failed</p>  
            <p>Dispatched</p>  
            <p>Collection Failed</p>  
            <p>Carrier Unable To Collect</p>  
            <p>Exchange Failed</p>  
            <p>Collected</p>  
            <p>At Drop Off Point</p>  
            <p>In Transit</p>  
            <p>In Transit - Waiting</p>  
            <p>At Customs</p>  
            <p>Action Required</p>  
            <p>Delayed</p>  
            <p>Held By Carrier</p>  
            <p>Missing</p>  
            <p>Lost</p>  
            <p>Damaged</p>  
            <p>Out For Delivery</p>  
            <p>Delivered Damaged</p>  
            <p>Partially Delivered</p>  
            <p>At Collection Point</p>  
            <p>Delivered</p>  
            <p>Delivery Failed Card Left</p>  
            <p>Delivery Failed</p>  
            <p>Return to Sender</p>
        </td>
    </tr>
    <tr>
        <td>Cancel consignment</td>
        <td>
            <p>Unallocated</p>  
            <p>Allocation Failed</p>  
            <p>Allocated</p>  
            <p>Manifested</p>  
            <p>Manifest Failed</p>  
            <p>Dispatched</p>  
            <p>Collection Failed</p>  
            <p>Carrier Unable To Collect</p>  
            <p>Exchange Failed</p>  
            <p>Collected</p>  
            <p>At Drop Off Point</p>  
            <p>In Transit</p>  
            <p>At Customs</p>  
            <p>Action Required</p>  
            <p>Delayed</p>  
            <p>Held By Carrier</p>  
            <p>Missing</p>  
            <p>Lost</p>  
            <p>Damaged</p>  
            <p>Out For Delivery</p>  
            <p>Delivered Damaged</p>  
            <p>At Collection Point</p>  
            <p>Delivery Failed Card Left</p>  
            <p>Delivery Failed</p>  
            <p>Return to Sender</p>  
        </td>
    </tr>            
</table>

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>