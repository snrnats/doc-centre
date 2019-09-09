# Using PRO Reports

Each PRO report is a collection of data visualisations (such as charts, tables, and maps) that gives you a graphical overview of a particular aspect of your shipping performance. For example, the **Volumes by Carrier** report features a table listing how many consignments and packages each of your carriers has shipped, a pie chart showing the share of your total shipments each carrier has, and a chart showing each carrier's total shipments over time. 

<a href="../images/reports/by-carrier.png" target="_blank">
  <img src="../images/reports/by-carrier.png"/>
</a>

These three visualisations enable you to get a picture of how much of your shipment volume each carrier is handing.

## Filters

By default, reports display all available data. Filters enable you to get a more granular view of your data by selecting the specific data that you want to view. For example, you might filter the **Volumes by Carrier** report so that it only shows consignments shipped by UPS and DPD, rather than all of your carriers.

The PRO reports use two types of filter, report-wide and visualisation

* **Report-wide** filters can be selected from the panel on the left-hand side. They affect all visualisations on the report.
* **Visualisation** filters can be applied by clicking a filter and selecting options from the **Filters** panel on the right-hand side. They only apply to the selected visualisation.

> <span class="note-header">Note:</span>
>
> The list of filters available differs between reports and visualisations. For information on a report's specific filters, see that report's documentation page.

You can combine filters in any way you choose. For example, say you want to see a graph charting how many shipments you sent with DPD and UPS between 30/07/2019 and 30/08/2019. To do this you could:

1. Open the **Volumes by Carrier** report.

    <a href="../images/reports/by-carrier.png" target="_blank">
    <img src="../images/reports/by-carrier.png"/>
    </a>

2. Use the **Date Shipped** selector on the left-hand panel to select only consignments shipped between 30/07/2019 and 30/08/2019. The report filters all visualisations so that only data from between those dates is displayed.

    <a href="../images/reports/by-carrier-date-filter.png" target="_blank">
    <img src="../images/reports/by-carrier-date-filter.png"/>
    </a>

3. Select the **Consignments Shipped by Carrier Over Time** chart and click the **Carrier** drop-down on the right-hand **Filters** panel. A list of available carriers is displayed. 

    <a href="../images/reports/carrier-filters-panel.png" target="_blank">
    <img src="../images/reports/carrier-filters-panel.png"/>
    </a>

4. Select the carriers that you want to filter the visualisation by (in this case, UPS and DPD). The report filters the chart so that only those two carriers are displayed.

    <a href="../images/reports/filtered-carrier-chart.png" target="_blank">
    <img src="../images/reports/filtered-carrier-chart.png"/>
    </a>  

Note that while the report-wide date filter affects all of the report's visualisations, the visualisation-specific carrier filter only applies to the **Consignments Shipped by Carrier Over Time** chart.

To reset a report's filters back to default, click the **Reset to Default** button on Power BI's top toolbar.

<a href="../images/reports/reset-to-default.png" target="_blank">
    <img src="../images/reports/reset-to-default.png"/>
</a>

## Visualisation Options

Each visualisation has a **More Options** drop-down menu, enabling you to perform additional actions relating to its data. To access the **More Options** menu, select a visualisation and click the **More Options** button in the top-right of the panel.

<a href="../images/reports/more-options.png" target="_blank">
    <img src="../images/reports/more-options.png"/>
</a>

The following options are available:

### Open Comments

Opens Power BI''s **Comments** panel, from where you and your team can leave comments on individual visualisations.

<a href="../images/reports/open-comments.png" target="_blank">
    <img src="../images/reports/open-comments.png"/>
</a> 

> <span class="note-header">More information:</span> 
>
> For more information on using Power BI's **Comments** panel, see the [Power BI docs](https://docs.microsoft.com/en-us/power-bi/consumer/end-user-comment).

### Export Data

Enables you to save a visualisation's underlying data as a .CSV or .XLSX file.

<a href="../images/reports/export-data.png" target="_blank">
    <img src="../images/reports/export-data.png"/>
</a> 

> <span class="note-header">More information:</span> 
>
> For more information on exporting data from Power BI, see the [Power BI docs](https://docs.microsoft.com/en-us/power-bi/visuals/power-bi-visualization-export-data).

### Show Data

Displays the dataset that was used to generate that particular visual.

<a href="../images/reports/show-data.png" target="_blank">
    <img src="../images/reports/show-data.png"/>
</a> 

### Spotlight

Highlights the selected visualisation on the page.

<a href="../images/reports/spotlight.png" target="_blank">
    <img src="../images/reports/spotlight.png"/>
</a>

### Sort (Descending / Ascending / Sort By)

Enables you to specify how the visualisation's data should be sorted.

<a href="../images/reports/sort-by.png" target="_blank">
    <img src="../images/reports/sort-by.png"/>
</a>

> <span class="note-header">Note:</span>
>
> Not all options are available to all visualisations. For information on a visualisation's specific options, see that report's documentation page.

## Report List

PRO offers the following reports

* [Traffic Profiles](traffic-profile.md) - Shows the number of consignments and packages your organisation is shipping.
* [Volumes by Carrier](by-carrier.md) - Shows shipping volumes broken down by carrier.
* [Volumes by Destination Country](by-country.md) - Shows shipping volumes broken down by destination country.
* [Carrier Performance](performance.md) - Shows how many of each carrier's shipments were late or failed, as well as a map showing the destinations of late shipments.
* [Delivery Experience](experience.md) - Shows delivery window and type statistics, delivery failures by carrier service, and what percentage of deliveries were on time.
* [Volumes by Carrier Service](by-carrier-service.md) - Shows shipping volumes broken down by carrier service.
* [Shipping Locations](location-performance.md) - Shows shipping volumes and performance for each of your organisation's shipping locations. 
* [Shipping Costs](costs.md) - Shows shipping costs broken down by carrier, time, company, and destination, as well as total costs as a percentage of sales value.
* [API Overview](api.md) - Shows API usage statistics and the number of teams PRO has returned each response code.
* [Support](support.md) - Shows a breakdown of current support tickets, as well as information on tickets logged over time. 
