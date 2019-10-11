# Shipped Consignments by Destination Country

The **Shipped Consignments by Destination Country** report enables you to see the volume of consignments you have shipped to each of your destination countries. 

It comprises a consignment data table, a **Consignment Volumes By Country** chart with the shipment data plotted on a map, and a **% of Consignment Volume by Destination Country** bar chart.

<a href="../images/reports/by-country.png" target="_blank">
    <img src="../images/reports/by-country.png"/>
</a>

> <span class="note-header">Note:</span>
>
> In order for the data in this chart to be accurate, your consignments must have the correct destination country recorded. 
>
> For more information on recording consignment data in PRO, see the [Create Consignment](https://docs.electioapp.com/#/api/CreateConsignment) page of the API reference.

## Report Filters

The **Shipped Consignments by Destination Country** report offers the following report-wide filters:

* **Date Shipped** - enables you to select consignments that were shipped within a given date range.
* **Company** - where applicable, enables you to select consignments that were shipped by a particular company within your group. You can select multiple companies if required.
* **Shipping Location** - where applicable, enables you to select consignments that were shipped from a particular shipping location.
* **Carrier** - enables you to select consignments that were shipped via a particular carrier.
* **Carrier Service** - enables you to select consignments that were shipped via a particular carrier service.
* **Delivery Type** - enables you to select consignments that were shipped as a particular delivery type (i.e. *Delivery* or *Click and Collect*).

<a href="../images/reports/by-country-left-filter.png" target="_blank">
    <img src="../images/reports/by-country-left-filter.png"/>
</a>

## Consignments Table

The consignments table shows how many consignments and packages were shipped to each of your destination countries (with any report filters taken into account):

<a href="../images/reports/by-country-table.png" target="_blank">
    <img src="../images/reports/by-country-table.png"/>
</a>

### Visual Filters

You can filter the list of countries displayed on the consignments table using the following filters:

* **Consignments** ([Numerical](/reports/filters-options.html#using-numerical-filters)) - enables you to filter by number of consignments shipped. For example, if you were to filter on *is greater than 5000*, then only those countries to which you had shipped 5001 or more consignments would be displayed.
* **Destination Country** ([Basic](/reports/filters-options.html#using-basic-filters) and [Advanced](/reports/filters-options.html#using-advanced-filters)) - enables you to select a specific country or countries to view.
* **Packages** ([Numerical](/reports/filters-options.html#using-numerical-filters)) - enables you to filter by number of packages shipped. For example, if you were to filter on *is greater than 5000*, then only those countries to which you had shipped 5001 or more packages would be displayed.

### More Options

The following options are available from the **More Options** menu:

* [Open Comments](/reports/filters-options.html#open-comments)
* [Export Data](/reports/filters-options.html#export-data)
* [Show Data](/reports/filters-options.html#show-data)
* [Spotlight](/reports/filters-options.html#spotlight)
* [Sort Descending](/reports/filters-options.html#sort-descending--ascending--sort-by)
* [Sort Ascending](/reports/filters-options.html#sort-descending--ascending--sort-by)
* [Sort by](/reports/filters-options.html#sort-descending--ascending--sort-by) Destination Country / Consignments / Packages


## Consignment Volumes by Country

The **Consignment Volumes by Country** chart displays the countries your organisation has shipped to on a map. The countries you ship to most frequently are displayed in blue tones, while the countries you ship to least frequently are displayed in green tones.

<a href="../images/reports/by-country-volumes.png" target="_blank">
    <img src="../images/reports/by-country-volumes.png"/>
</a>

If required, you can search for countries and locations using the search bar at the top of the panel.

### Visual Filters

You can filter the countries displayed on the **Consignment Volumes by Country** chart via the following filters: 

* **Consignments** ([Numerical](/reports/filters-options.html#using-numerical-filters)) - enables you to filter by number of consignments shipped. For example, if you were to filter on *is greater than 5000*, then only those countries to which you had shipped 5001 or more consignments would be displayed.
* **MapBox** ([Basic](/reports/filters-options.html#using-basic-filters) and [Advanced](/reports/filters-options.html#using-advanced-filters)) - enables you to select a specific country or countries to view.

### More Options

The following options are available from the **More Options** menu:

* [Open Comments](/reports/filters-options.html#open-comments)
* [Export Data](/reports/filters-options.html#export-data)
* [Show Data](/reports/filters-options.html#show-data)
* [Spotlight](/reports/filters-options.html#spotlight)

### Viewing Data

<a href="../images/reports/by-country-volumes-data.png" target="_blank">
    <img src="../images/reports/by-country-volumes-data.png"/>
</a>

The **Consignment Volumes by Country** chart's **View Data** option shows the number of consignments that you shipped to each destination country.

## % of Consignment Volume by Destination Country

The **% of Consignment Volume by Destination Country** bar chart shows each destination country's share of your total shipments. Click on a bar to view the corresponding country on the **Consignment Volumes by Country** map.

<a href="../images/reports/by-country-top-10.png" target="_blank">
    <img src="../images/reports/by-country-top-10.png"/>
</a>

### More Options

The following options are available from the **More Options** menu:

* [Open Comments](/reports/filters-options.html#open-comments)
* [Export Data](/reports/filters-options.html#export-data)
* [Show Data](/reports/filters-options.html#show-data)
* [Spotlight](/reports/filters-options.html#spotlight)
* [Sort Descending](/reports/filters-options.html#sort-descending--ascending--sort-by)
* [Sort Ascending](/reports/filters-options.html#sort-descending--ascending--sort-by)
* [Sort by](/reports/filters-options.html#sort-descending--ascending--sort-by) Country / %GT Count of ConsignmentReference

### Viewing Data

<a href="../images/reports/by-country-top-10-data.png" target="_blank">
    <img src="../images/reports/by-country-top-10-data.png"/>
</a>

The **% of Consignment Volume by Destination Country** chart's **View Data** option shows each destination country's percentage share of your total shipments.