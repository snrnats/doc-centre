# Shipped Consignments by Destination Country

The **Shipped Consignments by Destination Country** report enables you to see how many consignments you have sent to each of your destination countries. It comprises a table listing consignment and package data, a **Consignment Volumes By Country** chart with the shipment data plotted on a map, and a **% of Consignment Volume by Destination Country** bar chart.

<a href="../images/reports/by-country.png" target="_blank">
    <img src="../images/reports/by-country.png"/>
</a>

> <span class="note-header">Note:</span>
>
> In order for the data in this chart to be accurate, your consignments must have a destination country correctly recorded. Specifically, they must have a valid `Address` object that has an `AddressType` of `Destination` and the relevant two-letter country code in the `Address.Country.IsoCode.TwoLetterCode` field.
>
> For more information on recording consignment data in PRO, see the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) page of the API reference.

## Report Filters

The **Shipped Consignments by Destination Country** report offers the following report-wide filters:

* **Date Shipped** - enables you to select only those consignments that were shipped within a given date range.
* **Company Name** - where applicable, enables you to select only those consignments that were shipped by a particular company within your group. You can select multiple companies if required.
* **Shipping Location** - where applicable, enables you to select only those consignments that were shipped from a particular shipping location.
* **Carrier** - enables you to select only those consignments that were shipped via a particular carrier.
* **Carrier Service** - enables you to select only those consignments that were shipped via a particular carrier service.
* **Delivery Type** - enables you to select only those consignments that were shipped as a particular delivery type (i.e. *Delivery* or *Click and Collect*).

## Data Table

The data table shows how many consignments and packages were shipped to each of your destination countries (with any report filters taken into account:

<a href="../images/reports/by-country-table.png" target="_blank">
    <img src="../images/reports/by-country-table.png"/>
</a>

### Visualisation Filters

* **Consignments** ([Numerical](/reports/reports.html#using-numerical-filters))
* **Destination Country** ([Basic](/reports/reports.html#using-basic-filters) and [Advanced](/reports/reports.html#using-advanced-filters))
* **Packages** ([Numerical](/reports/reports.html#using-numerical-filters))

### More Options

The data table has the following options available from its **More Options** menu:

* [Open Comments](/reports/reports.html#open-comments)
* [Export Data](/reports/reports.html#export-data)
* [Show Data](/reports/reports.html#show-data)
* [Spotlight](/reports/reports.html#spotlight)
* [Sort Descending](/reports/reports.html#sort-descending--ascending--sort-by)
* [Sort Ascending](/reports/reports.html#sort-descending--ascending--sort-by)
* [Sort by](/reports/reports.html#sort-descending--ascending--sort-by) Destination Country / Consignments / Packages


## Consignment Volumes by Country

The **Consignment Volumes by Country** chart displays the countries your organisation has shipped to on a map. The countries you ship to most frequently are displayed in blue, while your least frequently shipped-to countries are displayed in green.

<a href="../images/reports/by-country-volumes.png" target="_blank">
    <img src="../images/reports/by-country-volumes.png"/>
</a>

If required, you can search for countries and locations using the search bar at the top of the panel.

### Visualisation Filters

* **Consignments** ([Numerical](/reports/reports.html#using-numerical-filters))
* **MapBox** ([Basic](/reports/reports.html#using-basic-filters) and [Advanced](/reports/reports.html#using-advanced-filters))

### More Options

The **Consignment Volumes by Country** chart has the following options available from its **More Options** menu:

* [Open Comments](/reports/reports.html#open-comments)
* [Export Data](/reports/reports.html#export-data)
* [Show Data](/reports/reports.html#show-data)
* [Spotlight](/reports/reports.html#spotlight)

## % of Consignment Volume by Destination Country

The **% of Consignment Volume by Destination Country** bar chart shows each destination country's share of your total shipments. Click on a bar to view the corresponding country on the **Consignment Volumes by Country** map.

<a href="../images/reports/by-country-top-10.png" target="_blank">
    <img src="../images/reports/by-country-top-10.png"/>
</a>

### Visualisation Filters

* **%GT Count of ConsignmentReference** ([Numerical](/reports/reports.html#using-numerical-filters))

### More Options

The **% of Consignment Volume by Destination Country** chart has the following options available from its **More Options** menu:

* [Open Comments](/reports/reports.html#open-comments)
* [Export Data](/reports/reports.html#export-data)
* [Show Data](/reports/reports.html#show-data)
* [Spotlight](/reports/reports.html#spotlight)
* [Sort Descending](/reports/reports.html#sort-descending--ascending--sort-by)
* [Sort Ascending](/reports/reports.html#sort-descending--ascending--sort-by)
* [Sort by](/reports/reports.html#sort-descending--ascending--sort-by) Country / %GT Count of ConsignmentReference