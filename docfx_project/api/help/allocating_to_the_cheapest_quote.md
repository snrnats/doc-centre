# Allocating To The Cheapest Quote

> Allocate Consignment Endpoint
```
PUT https://api.electioapp.com/allocation/{consignmentReference}/allocatewithcheapestquote
```

To allocate a single consignment to the cheapest available carrier service, use the **[Allocate Consignment](https://docs.electioapp.com/#/api/AllocateConsignment)** endpoint. Once the **Allocate Consignment** request is received and validated, SortedPRO checks for quotes to ship the consignment in question, and allocates the consignment to the cheapest service. 

This endpoint takes a `{consignmentReference}` as a path parameter, and returns an Allocation Summary.

> Example Allocate Consignment Request
```
PUT https://api.electioapp.com/allocation/EC-000-05A-Z6S/allocatewithcheapestquote
```
### Example

The example shows a request to allocate a consignment with a `{consignmentReference}` of _EC-000-05A-Z6S_ via the **Allocate Consignment** endpoint. 

<aside class="note">
  For full reference information on the <strong>Allocate Consignment</strong> endpoint, see the <strong><a href="https://docs.electioapp.com/#/api/AllocateConsignment">Allocate Consignment</a></strong> page of the API reference. 
</aside>

<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>