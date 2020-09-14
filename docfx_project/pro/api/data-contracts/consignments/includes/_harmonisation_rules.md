<div class="property">
    <div class="name">include</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..n</div>
    <div class="description">The harmonisation code(s) to include in this ruleset (allow)</div>
    <div class="validation">Optional. If provided, must be a valid format of harmonisation code including dots, e.g. 90.02.10. If exclude is provided, then include must be null or empty</div>
</div>
<div class="property">
    <div class="name">exclude</div>
    <div class="type">

[!include[_datatype_list_of_string](_datatype_list_of_string.md)]
</div>
    <div class="occurs">0..n</div>
    <div class="description">The harmonisation code(s) to exclude from this ruleset (disallow)</div>
    <div class="validation">Optional. If provided, must be a valid format of harmonisation code including dots e.g. 09.02.10. If include is provided, then exclude must be null or empty</div>
</div>