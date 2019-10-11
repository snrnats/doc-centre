# Filters and Options

By default, reports display all available data for a specific customer. Filters enable you to fine-tune the information a report displays by selecting the specific data that you want to view. For example, you might filter a report so that it only takes into account consignments shipped in the last month, rather than taking all consignments into account.

## Filters

You can filter reports either at a report-wide or visual-specific level.

* Report-wide filters can be selected from the panel on the left-hand side. Filters selected from this panel affect all visuals on the report.
* Visual filters can be applied by clicking a filter and selecting options from the **Filters** panel on the right-hand side. Filters selected in this way only apply to the selected visual.

> <span class="note-header">Note:</span>
>
> The list of filters available differs between reports. For information on a report's specific filters, see that report's documentation page in the [Using Reports](reports.md) section.

You can combine multiple filters if you need to. For example, say you want to see a graph charting how many shipments you sent with DPD and UPS between 30/07/2019 and 30/08/2019. To view this information this you could:

1. Open the **Volumes by Carrier** report.

    <a href="../images/reports/by-carrier.png" target="_blank">
    <img src="../images/reports/by-carrier.png"/>
    </a>

2. Use the **Date Shipped** selector on the left-hand panel to select only consignments shipped between 30/07/2019 and 30/08/2019. The report filters all visuals so that only consignments shipped between those dates are taken into account.

    <a href="../images/reports/by-carrier-date-filter.png" target="_blank">
    <img src="../images/reports/by-carrier-date-filter.png"/>
    </a>

3. Select the **Consignments Shipped by Carrier Over Time** chart and click the **Carrier** drop-down on the right-hand **Filters** panel. A list of available carriers is displayed. 

    <a href="../images/reports/carrier-filters-panel.png" target="_blank">
    <img src="../images/reports/carrier-filters-panel.png"/>
    </a>

4. Select the carriers that you want to filter the visual by (in this case, UPS and DPD). The report filters the chart so that it only takes into account consignments that were shipped by either UPS or DPD _AND_ meet the existing report filter criteria (that is, they were shipped between 30/07/2019 and 30/08/2019).

    <a href="../images/reports/filtered-carrier-chart.png" target="_blank">
    <img src="../images/reports/filtered-carrier-chart.png"/>
    </a>  

> <span class="note-header">Note: </note>
> 
> While the report-wide date filter affects all of the report's visuals, the visual-specific carrier filter only applies to the **Consignments Shipped by Carrier Over Time** chart.

To reset a report's filters back to default, click the **Reset to Default** button on Power BI's toolbar.

<a href="../images/reports/reset-to-default.png" target="_blank">
    <img src="../images/reports/reset-to-default.png"/>
</a>

### Filtering Visuals

Each visual has various filterable properties. The PRO reports use four types of filter, depending on whether the property in question is a numerical field, text field, or date field:

* **Numerical** - Used on numerical fields, enables you to specify a required number range.
* **Basic** - Used on text fields, enables you to select simple values (such as individual carrier names) from a list.
* **Advanced** - Used on text fields, enables you to select values based on custom selection criteria (such as selecting all carrier services that have names beginning with "UPS").
* **Relative Date** - Used on date fields, enables you to specify a required date range.

#### Using Numerical Filters

Numerical filters enable you to specify a number range to a numerical field. Once applied, the visual is filtered so that it only takes into account records in which the value of the filtered field meets the criteria you specified. 

For example, suppose that you are viewing the data table on the **Shipped Consignments by Destination Country** report, but you are only interested in countries to which you have shipped more than 1000 consignments. You could apply a numerical filter to the **Consignments** field so that the table only shows country records where the value of **Consignments** (that is, the total number of consignments shipped to that particular country) was above 1000. 

<a href="../images/reports/num-filter-gif.gif" target="_blank">
    <img src="../images/reports/num-filter-gif.gif"/>
</a>

To apply a numerical filter to a visual:

1. Ensure that the **Filters** panel is displayed and select the visual. A list of available filters is displayed

    <a href="../images/reports/num-filter-1.png" target="_blank">
    <img src="../images/reports/num-filter-1.png"/>
    </a>

2. Click the drop-down menu for the numerical field you want to filter. Editable filter options are displayed.

    <a href="../images/reports/num-filter-2.png" target="_blank">
    <img src="../images/reports/num-filter-2.png"/>
    </a>

3. Select an operator and enter a value. The following operators are available:
    * Is Less Than
    * Is Less Than or Equal To
    * Is Greater Than
    * Is Greater Than or Equal To
    * Is
    * Is Not
    * Is Blank
    * Is Not Blank

    <a href="../images/reports/num-filter-3.png" target="_blank">
    <img src="../images/reports/num-filter-3.png"/>
    </a>    

4. If required, select either **And** or **Or** radio button and repeat step 3 to add a secondary filter. If you do not want to add a secondary filter, leave the value box blank.

    <a href="../images/reports/num-filter-4.png" target="_blank">
    <img src="../images/reports/num-filter-4.png"/>
    </a>

5. Click **Apply Filter** to save your changes.

Using the example given earlier, if you wanted to filter the **Shipped Consignments by Destination Country** report's **Consignments** field so that only countries to which you have shipped 1000 or more consignments were displayed, you would select **Is Greater Than or Equal To** from the operator drop-down and enter 1000 into the value box.

If you wanted to modify that filter so that only countries to which you have shipped between 1000 and 2000 consignments were displayed, you would select the **And** radio button and enter **Is Less Than or Equal To** / **2000** from the secondary filter.

#### Using Basic Filters

Basic filters enable you to select individual text values. Once applied, the visual is filtered so that it only takes into account records in which the value of the filtered field meets the criteria you specified.

For example, suppose that you are viewing the **Delivery Type by Carrier** visual on the **Delivery Experience** report, but you only want to view the delivery types used in shipments by DPD and UPS, rather than your entire suite of carriers. You could use basic filtering to select those two carriers specifically.

<a href="../images/reports/basic-filter-gif.gif" target="_blank">
    <img src="../images/reports/basic-filter-gif.gif"/>
</a>

To apply basic filtering to a visual:

1. Ensure that the **Filters** panel is displayed and select the visual. A list of available filters is displayed.

    <a href="../images/reports/basic-filter-1.png" target="_blank">
    <img src="../images/reports/basic-filter-1.png"/>
    </a>

2. Click the drop-down menu for the text field you want to filter.
3. Ensure that **Basic Filtering** is selected from the **Filter Type** drop-down menu. A list of selectable values is displayed.

    <a href="../images/reports/basic-filter-2.png" target="_blank">
    <img src="../images/reports/basic-filter-2.png"/>
    </a>

4. Use the check boxes to select the values that you want to filter by. Power BI filters the visual automatically.

    <a href="../images/reports/basic-filter-3.png" target="_blank">
    <img src="../images/reports/basic-filter-3.png"/>
    </a>

#### Using Advanced Filters

Advanced filters enable you to select all text values that meet certain criteria, rather than selecting individual values themselves.

For example, suppose that you are viewing the **% of Total Consignments by Carrier Service** visual on the **Shipping Consignments by Carrier Service** report. However, rather than viewing data for all of your carrier services, you only want to view your UPS carrier services. In this case you could use an Advanced filter on the *Carrier Service* field to filter out all carrier services other than those whose names start with "UPS".

<a href="../images/reports/adv-filter-gif.gif" target="_blank">
    <img src="../images/reports/adv-filter-gif.gif"/>
</a>

To apply advanced filtering to a visual:

1. Ensure that the **Filters** panel is displayed and select the visual. A list of available filters is displayed.

    <a href="../images/reports/adv-filter-1.png" target="_blank">
    <img src="../images/reports/adv-filter-1.png"/>
    </a>

2. Click the drop-down menu for the field you want to filter and select **Advanced filtering** from the **Filter Type** drop-down menu. The panel displays filter controls.

    <a href="../images/reports/adv-filter-2.png" target="_blank">
    <img src="../images/reports/adv-filter-2.png"/>
    </a>

3. Select an operator from the **Show items when the value:** drop-down menu. The following operators are available:
    * Contains
    * Does Not Contain
    * Starts With
    * Does Not Start With
    * Is
    * Is Not
    * Is Blank
    * Is Not Blank

    <a href="../images/reports/adv-filter-3.png" target="_blank">
    <img src="../images/reports/adv-filter-3.png"/>
    </a>

4. Enter a value into the text box. Returning to the previous example, you would need to select *Starts with* from the drop-down menu and then enter *UPS* into the text box in order to filter out all carrier services other than those whose names start with "UPS"

    <a href="../images/reports/adv-filter-4.png" target="_blank">
    <img src="../images/reports/adv-filter-4.png"/>
    </a>

5. If required, select either **And** or **Or** radio button and repeat steps 4 and 5 to enter additional criteria.

    <a href="../images/reports/adv-filter-4.png" target="_blank">
    <img src="../images/reports/adv-filter-4.png"/>
    </a>

6. Click **Apply Filter** to save your changes.

#### Using Relative Date Filters

Relative date filtering is only available on date fields. It enables you to filter visuals by providing a date range that is relative to the current date and time.

For example, suppose that you are viewing the **Consignments Shipped By Carrier Over Time** visual of the **Shipped Consignments by Carrier** report, but you only want to view data for the late two weeks. You could use a relative date filter on the `DateShippedOnly` field to select only those consignments that were shipped in the last two weeks.

<a href="../images/reports/date-filter-gif.gif" target="_blank">
    <img src="../images/reports/date-filter-gif.gif"/>
</a>

To apply a relative date filter:

1. Ensure that the **Filters** panel is displayed and select the visual. A list of available filters is displayed.

    <a href="../images/reports/date-filter-1.png" target="_blank">
    <img src="../images/reports/date-filter-1.png"/>
    </a>

2. Click the drop-down menu for the field you want to filter and select **Relative date filtering** from the **Filter Type** drop-down menu. The panel displays date controls.

    <a href="../images/reports/date-filter-2.png" target="_blank">
    <img src="../images/reports/date-filter-2.png"/>
    </a>

3. Enter your filter criteria: 
    1. Select an operator from the **Show items when the value:** drop-down menu. The available options are **Is In The Last**, **Is In This**, and **Is In The Next**.
    2. Enter a value into the text box.
    3. Select a unit from the bottom drop-down box. The available options are **Days**, **Weeks**, **Calendar Weeks**, **Months**, **Calendar Months**, **Years**, and **Calendar Years**.
    4. If required, select the **Include Today** check box to include the current date in your calculations.  
4. Click **Apply Filter** to save your changes.

Using the example given earlier, if you wanted to filter the **Consignments Shipped By Carrier Over Time** visual of the **Shipped Consignments by Carrier** report to only display consignments shipped in the last two weeks, you would select *Is In The Last*, *14*, and *Days* when filtering the `DateShippedOnly` field. 

## Visual Options

Each visual has a **More Options** drop-down menu, enabling you to perform additional actions relating to its data. To access the **More Options** menu, select a visual and click the **More Options** button in the top-right of the panel.

<a href="../images/reports/more-options.png" target="_blank">
    <img src="../images/reports/more-options.png"/>
</a>

The following options are available:

### Open Comments

Opens Power BI's **Comments** panel, from where you and your team can leave comments on individual visuals.

<a href="../images/reports/open-comments.png" target="_blank">
    <img src="../images/reports/open-comments.png"/>
</a> 

> <span class="note-header">More information:</span> 
>
> For more information on using Power BI's **Comments** panel, see the [Power BI docs](https://docs.microsoft.com/en-us/power-bi/consumer/end-user-comment).

### Export Data

Enables you to save a visual's underlying data as a .CSV or .XLSX file.

<a href="../images/reports/export-data.png" target="_blank">
    <img src="../images/reports/export-data.png"/>
</a> 

> <span class="note-header">More information:</span> 
>
> For more information on exporting data from Power BI, see the [Power BI docs](https://docs.microsoft.com/en-us/power-bi/visuals/power-bi-visualization-export-data).

### Show Data

Displays a summary of the data that was used to generate that particular visual.

<a href="../images/reports/show-data.png" target="_blank">
    <img src="../images/reports/show-data.png"/>
</a> 

### Spotlight

Highlights the selected visual on the page.

<a href="../images/reports/spotlight.png" target="_blank">
    <img src="../images/reports/spotlight.png"/>
</a>

### Sort (Descending / Ascending / Sort By)

Enables you to specify how the visual's data should be sorted.

<a href="../images/reports/sort-by.png" target="_blank">
    <img src="../images/reports/sort-by.png"/>
</a>

> <span class="note-header">Note:</span>
>
> Not all options are available to all visuals. For information on a visual's specific options, see that report's documentation page in the [Reports](reports.md) section.

## Viewing Records

Some types of visual enable you to click through to view the raw records in the dataset that the visual was generated from. The **Using Reports** section explains which visuals you can view records for.

<a href="../images/reports/view-records.png" target="_blank">
    <img src="../images/reports/view-records.png"/>
</a>

To view records for a visual, right click on that visual and select **View Records** from the pop-up menu.

<a href="../images/reports/view-records-option.png" target="_blank">
    <img src="../images/reports/view-records-option.png"/>
</a>

## Next Steps

For further details on the reports themselves, see the [Reports](reports.md) section.
