$("#subjects-filter-input").change(function () {
    const filterValue = $("#subjects-filter-input").val();
    $.get("/Subject/Index", $.param({ filterValue: filterValue }), function (resultData) {
        $(".subjects-table-data").html(resultData);
    });
});

$("#students-filter-input").change(function () {
    const filterValue = $("#students-filter-input").val();
    $.get("/Student/Index", $.param({ filterValue: filterValue }), function (resultData) {
        $(".students-table-data").html(resultData);
    });
});