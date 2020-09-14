<div class="property">
    <div class="name">date_first_retrieved	</div>
    <div class="type">

[!include[_datatype_datetime](_datatype_datetime.md)]
</div>
    <div class="occurs">0..1</div>
    <div class="description">The date and time that the label for this allocation was first retrieved</div>
</div>
<div class="property">
    <div class="name">retrieval_count</div>
    <div class="type">

[!include[_datatype_integer](_datatype_integer.md)]
</div>
    <div class="occurs">1</div>
    <div class="description">The number of times that the label for this allocation has been retrieved</div>
</div>
<div class="property">
    <div class="name">_links</div>
    <div class="type">list of <code>link</code> objects</div>
    <div class="occurs">0..n</div>
    <div class="description">Links to retrieve the label(s)	</div>
    <div class="dropdown"> 
        <button onclick="dropFunction(this)">Show child properties</button>
        <div class="dropdown-content">

[!include[_links](_links.md)]
</div>
    </div>    
</div>