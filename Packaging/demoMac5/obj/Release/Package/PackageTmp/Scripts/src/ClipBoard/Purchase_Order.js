angular.module('AceApp').controller('ProductGroupController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {

    }
]);

LoadGrid();
$("#popup").dxPopup({
    title: "โหลดใบอนุมัติการขาย",
    visible: false,
    width: 600,
    height: 520,
});

function LoadFile() {

    $("#popup").dxPopup({
        title: "โหลดใบอนุมัติการขาย",
        visible: true,
        width: 520,
        height: 520,
    });

    $.get("../PurchaseOrder/GetSalesRequestion")
        .done(function (res) {
            console.log(res);
            if (res.success == true) {

    $("#gridContainer2").dxDataGrid({
        dataSource: res.data,
        showBorders: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        paging: {
            enabled: false
        },
        selection: {
            mode: "multiple"
        },
        width: "auto",
        width: 500,
        height: 300,
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: "ค้นหา..."
        },
        filterRow: {
            visible: false,
            applyFilter: "auto"
        },
        selection: {
            mode: "multiple"
        },
        keyExpr: "Sales_Id",
        columns: [

            {
                dataField: "Sales_Nos",
                caption: "เลขที่",

            },
            {
                dataField: "Sales_Date_Text",
                caption: "วันที่",

            },
            {
                dataField: "Sales_Quantity",
                caption: "จำนวน(ใบ)",

            },
            {
                dataField: "Sales_Delivery_Desc",
                caption: "สถานที่จัดส่ง",

            },

        ],



    });
            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });

}



function LoadGrid() {
    $.get("../PurchaseOrder/GetPurchaseOrder/0")
        .done(function (res) {
            console.log(res);
            if (res.success == true) {
    var rownum = 0;
    $("#gridContainer").dxDataGrid({
        dataSource: res.data,
        showBorders: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        paging: {
            enabled: false
        },
        width: "auto",
        height: 600,
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: "ค้นหา..."
        },
        filterRow: {
            visible: true,
            applyFilter: "auto"
        },

        columns: [
            {
                dataField: "Purchase_Id",
                caption: "ลำดับ",
                width: 100,
                alignment: 'center',
                allowFiltering: false,
                fixed: false,
                fixedPosition: 'left',
                cellTemplate: function (container, options) {
                    rownum = rownum + 1;
                    console.log(rownum);
                    $("<div>")
                        .append(rownum)
                        .appendTo(container);
                }
            },
            {
                dataField: "Purchase_Status",
                caption: "อนุมัติ",
                alignment: 'center',
                cellTemplate: function (container, options) {

                    if (options.key.Purchase_Status == 0) {
                        $("<div>")
                            .append("รออนุมัติ")
                            .appendTo(container);

                    }
                    else if (options.key.Purchase_Status == 1) {
                        $("<div>")
                            .append("ไม่อนุมัติ")
                            .appendTo(container);

                    }
                    else if (options.key.Purchase_Status == 2) {
                        $("<div>")
                            .append("อนุมัติ")
                            .appendTo(container);

                    }
                }
            },
            {
                dataField: "Purchase_Nos",
                caption: "เลขที่",
                alignment: 'center',
            },
            {
                dataField: "Purchase_Date_Text",
                caption: "วันที่",
                alignment: 'center',

            },
            {
                dataField: "Purchase_Quantity",
                caption: "จำนวน(ใบ)",

            },
            {
                dataField: "Purchase_Delivery_Desc",
                caption: "สถานที่จัดส่ง",

            },
            {
                dataField: "PERid",
                caption: "ชื่อพนักงาน",
                alignment: 'center',
            },
            {
                dataField: "DEBid",
                caption: "ชื่อลูกค้า",
                alignment: 'center',
            },
            {
                dataField: "Purchase_Id",
                caption: "แก้ไขข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                fixed: true,
                fixedPosition: 'right',
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a  onclick='ShowForm(" + options.key.Purchase_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white'><i class='fa fa-pencil'></i></a>")
                        .appendTo(container);
                }

            },
            {
                dataField: "Purchase_Id",
                caption: "ลบข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                fixed: true,
                fixedPosition: 'right',
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a onclick='DeleteSTG(" + options.data.Purchase_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary' style='color:white'><i class='fa fa-trash'></i></a>")
                        .appendTo(container);
                }

            },
        ],



    });
            }
        });

}


function LoadSalesRequest(){
   
    $("#popup").dxPopup({
        title: "โหลดใบอนุมัติการขาย",
        visible: false,
        width: 520,
        height: 520,
    });
    var a = $("#gridContainer2").dxDataGrid("instance").option('selectedRowKeys');
    console.log(" value = >> " + a);
    $.ajax({
        url: "../PurchaseOrder/PostLoadSalesRequestion",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(a),
        success: function (data) {
            if (data.success == true) {

                LoadGrid();
                DevExpress.ui.notify("โหลดใบอนุมัติการขายแล้ว ");
            } else {


            }
        },
        error: function () {
            console.log("error");
        }
    });


}