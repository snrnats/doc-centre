All of PRO's manifest endpoints return a Manifest Response detailing the outcome of the manifest request. 

The Manifest Response contains a `manifest_result` object, which in turn contains the following information:

* A unique reference for the manifest attempt
* Details of the carrier and service that the shipment(s) were manifested or queued to be manifested with. <span class="highlight">I'M GUESSING THIS WORKS IN THE SAME WAY AS THE ALLOCATION ENDPOINTS WHERE BULK ENDPOINTS QUEUE AND SINGLE ENDPOINTS MANIFEST IN-PROCESS? NEED TO CONFIRM THAT</span>
* A message providing details of the result.
* The current state of the shipment as a result of the manifest operation. Ordinarily, this would be _manifesting_.
* The number of shipments that PRO attempted to manifest.
* A link to the generated manifest.