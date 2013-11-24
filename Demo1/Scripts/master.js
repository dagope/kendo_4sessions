
function setProgressDemo(value) {
    var pb = $("#profileCompleteness").kendoProgressBar({
        type: "chunk",
        chunkCount: 5,
        min: 0,
        max: 5,
        value: value
    }).data("kendoProgressBar");
}

