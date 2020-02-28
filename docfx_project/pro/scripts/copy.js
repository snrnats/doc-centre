function CopyToClipboard(e, containerId) {
    ClearSelection();
    CopySection(e, containerId);
    ClearSelection();
}

function CopySection(e, containerId) {
    
    ClearSelection();
    
    if (document.selection) {
        var range = document.body.createTextRange();
        range.moveToElementText(document.getElementById(containerId));
        range.select().createTextRange();
        document.execCommand("copy");
        copySuccess(e);
    } else if (window.getSelection) {
        var range = document.createRange();
        range.selectNode(document.getElementById(containerId));
        window.getSelection().addRange(range);
        document.execCommand("copy");
        copySuccess(e);
    }
    
    ClearSelection();
}

function ClearSelection() {
    if (window.getSelection) {
        window.getSelection().removeAllRanges();
    } else if (document.selection) {
        document.selection.empty();
    }
}

function copySuccess(e) {
    e.classList.add("copy-success");
    var currentContent = e.innerHTML;
    e.innerHTML = "<span class='glyphicon glyphicon-ok'></span>";
    window.setTimeout(function () {
        e.classList.remove("copy-success");
        e.innerHTML = currentContent;
    }, 2500);
}