
function setProgressDemo(value) {
    var pb = $("#profileCompleteness").kendoProgressBar({
        type: "chunk",
        chunkCount: 3,
        min: 0,
        max: 3,
        value: value
    }).data("kendoProgressBar");
}

