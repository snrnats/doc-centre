# Tracking Consignments Using REACT

---

Fundamentally does three things:

1. Automatically takes PRO consignments that have been manifested and makes REACT shipments out of them
2. Populates REACT carrier connectors with PRO carriers
3. Consumes PRO tracking events

PRO consignments automatically added to REACT at manifest?

* PRO tells REACT shipment is manifested
* REACT converts consignment details into shipment object
* REACT registers shipment

For REACT + PRO customers, Carrier Connector screen is populated by REACT making a call to PRO

The basic assumption here is that if a PRO customer wants to use a carrier integration, which is already present in PRO, then they don’t need to provide any details for using that carrier integration. They can simply choose the option of ‘using PRO’s carrier integration’ and REACT will fetch those details from PRO on its own, for that customer. If they are a PRO customer, then they can only use the carrier integrations/carrier services which are available in PRO. 

Please note that for all PRO customers, if PRO integration exists for a carrier, then the customer should NOT have the option to choose REACT’s integration. This is to make sure that within Sorted we are not duplicating the carrier integration efforts. 

Whenever PRO downloads a new carrier file, it will publish a TrackingFileInStorage message on the sorted service bus. This message is consumed by the new service within REACT, called Storage File Broker. This message should have details about: 

Carrier_service_reference: mapped to tracking_service_reference in Tracking Configuration database.  

account_reference: maps to the account_number property within Tracking Configuration API. 


## Linking REACT and PRO



## Mapping Consignments to REACT Shipments



<script src="../../scripts/requesttabs.js"></script>
<script src="../../scripts/responsetabs.js"></script>
<script src="../../scripts/copy.js"></script>