'use strict';
$(document).ready(
    function () {
        $("#grid").kendoGrid({
            columns: [{
                field: "buildingId",
                title: 'ID',
                filterable: false
            },
            {
                field: "nameBuilding",
                title: "Name",
            }
            ],
            dataSource: {
                type: "json",
                transport: {
                    read: function (options) {
                        $.ajax({
                            url: "/Home/Data",
                            dataType: "json",
                            type: "GET",
                            //data:JSON.stringify{buildingId:}
                            cache: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (result) {
                                options.success(result)
                            },
                            error: function (response) {
                                window.popupNotification.show("Ошика при получении данных / Error get date", "error");
                            }
                        });
                    },
                },
                schema: {
                    model: {
                        fields: {
                            buildingId: { type: "string" },
                            nameBuilding: { type: "string" },
                        }
                    }
                },
            },
            height: 350,
            pageable: true,
            sortable: true,
            groupable: true,
            selectable: "row",
            //change: function (e) {
            //    if (e) {
            //                 var selected = this.select();
            //    var selectedDataItems = [];
            //    for (var i = 0; i < selected.length; i++) {
            //        var dataItem = this.dataItem($(selected[i]).closest("tr"));
            //        selectedDataItems.push(dataItem);
            //        //window.buildingId = this.dataItem(this.select()).buildingId;
            //        //if (window.buildingId) {
            //        //    GetRoom();
            //        }
            //    }
            //},

            //change: function (e) {
            //    var selected = this.select();
            //    var selectedDataItems = [];
            //    for (var i = 0; i < selected.length; i++) {
            //        var dataItem = this.dataItem($(selected[i]).closest("tr"));
            //        selectedDataItems.push(dataItem);
            //    }
            //}
        });

//        $("#cellSelection").kendoGrid({
//        dataSource: {
//        type: "json",
//        transport: {
//            read: function (options) {
//                $.ajax({
//                    url: "/Home/Data",
//                    dataType: "json",
//                    type: "GET",
//                    //data:JSON.stringify{buildingId:}
//                    cache: false,
//                    contentType: "application/json; charset=utf-8",
//                    success: function (result) {
//                        options.success(result)
//                    },
//                    error: function (response) {
//                        window.popupNotification.show("Ошика при получении данных / Error get date", "error");
//                    }
//                });
//            },
//        },
//    selectable: "multiple cell",
//    pageable: {
//        buttonCount: 5
//    },
//    scrollable: false,
//    navigatable: true,
//    columns: [
//        {
//            field: "buildingId",
//            title: 'ID',
//        }
//    ]
//});
});