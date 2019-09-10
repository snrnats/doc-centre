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

### Filtering Visualisations

Different visualisation fields use different types of filter, depending on the nature of the data being filtered. There are four visualisation filter types in the PRO reports:

* **Numerical** - Used on numerical fields, enables you to specify a number range.
* **Basic** - Used on text fields, enables you to select simple values (such as carrier names) from a list.
* **Advanced** - Used on text fields, enables you to select values based on custom selection criteria.
* **Relative Date** - Used on date fields, enables you to specify a range of dates you want to view data for.

#### Using Numerical Filters

Numerical filters enable you to specify a number range to a particular numerical field. Once applied, the visualisation is filtered so that it only displays records in which the value of the filtered field meets the criteria you specified. 

For example, suppose that you are viewing the data table on the **Shipped Consignments by Destination Country** report, but you are only interested in countries to which you have shipped more than 1000 consignments. You could apply a numerical filter to the **Consignments** field so that the table only shows records where the value of **Consignments** (that is, the total number of consignments shipped to that particular country) was above 1000. 

To apply a numerical filter to a visualisation:

1. Ensure that the **Filters** panel is displayed and select the visualisation. A list of available filters is displayed
2. Click the drop-down menu for the field you want to filter.
3. Select an operator and enter a value. The following operators are available:
    * Is Less Than
    * Is Less Than or Equal To
    * Is Greater Than
    * Is Greater Than or Equal To
    * Is
    * Is Not
    * Is Blank
    * Is Not Blank
4. If required, select either **And** or **Or** radio button and repeat step 3 to add a secondary filter. If you do not want to add a secondary filter, leave the value box blank.
5. Click **Apply Filter** to save your changes.

Using the example given earlier, if you wanted to filter the **Shipped Consignments by Destination Country** report's **Consignments** field so that only countries to which you have shipped 1000 or more consignments were displayed, you would select **Is Greater Than or Equal To** from the operator drop-down and enter 1000 into the value box.

If you wanted to modify that filter so that only countries to which you have shipped between 1000 and 2000 consignments were displayed, you would select the **And** radio button and enter **Is Less Than or Equal To** / **2000** from the secondary filter.

#### Using Basic Filters

Basic filters enable you to select discrete text values. Once applied, the visualisation is filtered so that it only displays records in which the value of the filtered field meets the criteria you specified.

For example, suppose that you are viewing the **Delivery Type by Carrier** visualisation on the **Delivery Experience** report, but you only want to view the delivery types of Carrier X and Carrier Y, rather than your entire suite of carriers. You could use basic filtering to select those two carriers specifically.

To apply basic filtering to a visualisation:

1. Ensure that the **Filters** panel is displayed and select the visualisation. A list of available filters is displayed
2. Click the drop-down menu for the field you want to filter.
3. Ensure that **Basic Filtering** is selected from the **Filter Type** drop-down menu. A list of selectable values is displayed.
4. Use the check boxes to select the values that you want to filter by.
5. Click **Apply Filter** to save your changes.

#### Using Advanced Filters

Advanced filters enable you to select all text values that meet certain criteria, rather than selecting individual values themselves.

For example, suppose that you are viewing the **% of Total Consignments by Carrier Service** visualisation on the **Shipping Consignments by Carrier Service** report. However, rather than viewing data for all of your carrier services, you only want to view your UPS carrier services. In this case you could use an Advanced filter on the *Carrier Service* field to filter out all carrier services other than those whose names start with "UPS".

To apply advanced filtering to a visualisation:

1. Ensure that the **Filters** panel is displayed and select the visualisation. A list of available filters is displayed
2. Click the drop-down menu for the field you want to filter.
3. Select **Advanced filtering** from the **Filter Type** drop-down menu. The panel displays filter controls.
4. Select an operator from the **Show items when the value:** drop-down menu. The following operators are available:
    * Contains
    * Does Not Contain
    * Starts With
    * Does Not Start With
    * Is
    * Is Not
    * Is Blank
    * Is Not Blank
5. Enter a value into the text box. Returning to the previous example, you would need to select *Starts with* from the drop-down menu and then enter *UPS* into the text box in order to filter out all carrier services other than those whose names start with "UPS"
6. If required, select either **And** or **Or** radio button and repeat steps 4 and 5 to enter additional criteria.
7. Click **Apply Filter** to save your changes.

#### Using Relative Date Filters

Relative date filtering is only available on date fields. It enables you to filter visualisations by providing a date range that is relative to the current date and time (that is, a certain period of time before or after now).

For example, suppose that you are viewing the **Consignments Shipped By Carrier Over Time** visualisation of the **Shipped Consignments by Carrier** report, but you only want to view data for the late two weeks. You could use a relative date filter on the `DateShippedOnly` field to select only those consignments that were shipped in the last two weeks.

To apply a relative date filter:

1. Ensure that the **Filters** panel is displayed and select the visualisation. A list of available filters is displayed
2. Click the drop-down menu for the field you want to filter.
3. Select **Relative date filtering** from the **Filter Type** drop-down menu. The panel displays date controls.
4. Enter your filter criteria: 
    1. Select an operator from the **Show items when the value:** drop-down menu. The available options are **Is In The Last**, **Is In This**, and **Is In The Next**.
    2. Enter a value into the text box.
    3. Select a unit from the bottom drop-down box. The available options are **Days**, **Weeks**, **Calendar Weeks**, **Months**, **Calendar Months**, **Years**, and **Calendar Years**.
    4. If required, select the **Include Today** check box to include the current date in your calculations.
5. Click **Apply Filter** to save your changes.

Using the example given earlier, if you wanted to filter the **Consignments Shipped By Carrier Over Time** visualisation of the **Shipped Consignments by Carrier** report to only display consignments shipped in the last two weeks, you would select *Is In The Last*, *14*, and *Days* when filtering the `DateShippedOnly` field. 

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
