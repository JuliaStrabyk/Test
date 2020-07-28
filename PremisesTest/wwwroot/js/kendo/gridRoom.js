'use strict';
function GetRoom() {
    var dataSourceRoom = new kendo.data.DataSource({
        serverPaging: false,
        serverSorting: true,
        serverFiltering: false,
        pageSize: 6,
        transport:
        {
            read: function (options) {
                if (window.buildingId) {
                    kendo.ui.progress($('.myclassselector'), true);
                    $.ajax({
                        url: "/Home/RowData/",
                        dataType: "json",
                        type: "GET",
                        traditional: true,
                        data: JSON.stringify({ buildingId: window.buildingId }),
                        cache: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (result) {
                            kendo.ui.progress($('.myclassselector'), false);
                            if (result && result.success) {
                                options.success(result);
                                $("#lbGridURoles").show();
                            } else {
                                window.popupNotification.show("Ошибка при получении данных Roles / Error Rows", "error");
                            }
                        },
                        error: function (response) {
                            window.popupNotification.show("Ошибка при получении данных Roles/ Error Rows", "error");
                        }
                    });
                }
            },
        },
        batch: true,
        schema: {
            total: "data.length",
            data: "data",
            model:
            {
                id: "RoleId",
                fields:
                {
                    RoleId: {
                        type: "string",
                        editable: false
                    },
                    RoleName: {
                        type: "string",
                        editable: false
                    },
                    buildingId: {
                        type: "string",
                        editable: false
                    }
                }
            }
        }
    });

    $("#gridRomm").kendoGrid({
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 20,
            pageSize: 20
        },
        dataSource: dataSourceRoom,
        edit: function (e) {
            $(".k-grid-update").removeClass("k-button k-primary").addClass("btn btn-success btn-sm marginRigh");
            $(".k-grid-cancel").removeClass("k-button").addClass("btn btn-danger btn-sm marginRigh");
        },
        //dataBound: onDataBoundRole,
        selectable: "row",
        scrollable: true,
        height: 250,
        //filterable: { mode: "row" },
        columns: [{
            field: "roomId",
            title: 'ID',
            filterable: false
        },
            {
                field: "roomName",
                title: "Name",
            },
            {
                field: "buildingId",
                title: "buildingId",
            }
        ],
        editable: "inline"
    });
     
            //dataSource: {
            //    type: "json",
            //    transport: {
            //        read: function (options) {
            //            $.ajax({
            //                url: "/Home/RowData/",
            //                dataType: "json",
            //                type: "GET",
            //                //data:JSON.stringify{buildingId:}
            //                cache: false,
            //                contentType: "application/json; charset=utf-8",
            //                success: function (result) {
            //                    options.success(result)
            //                },
            //                error: function (response) {
            //                    window.popupNotification.show("Ошика при получении данных / Error get date", "error");
            //                }
            //            });
            //        },
            //    },
            //    schema: {
            //        model: {
            //            fields: {
            //                roomId: { type: "string" },
            //                roomName: { type: "string" },
            //            }
            //        }
            //    },
}