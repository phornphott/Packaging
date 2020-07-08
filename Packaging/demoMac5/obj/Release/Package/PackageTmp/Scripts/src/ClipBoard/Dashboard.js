angular.module('AceApp').controller('ClipBoardDashboardController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $scope.Add = function () {
            window.location = "#/ClipBoard/Index";
            $("#TempId").val(0)
        }
        
        CallData()
    }
]);

LoadGrid({});

function CallData() {
    var url = "../ClipBoard/GetClipBoard/0";
    $("#grid-container").show();
    $("#btnAdd").show();

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                console.log(data)
                var b = data.data;
                if (b.Clipboard_Date_Text !== null) {
                    b.Clipboard_Date = new Date(b.Clipboard_Date_Text);
                }
                else {
                    b.Clipboard_Date = new Date(b.Clipboard_Date);
                }
                LoadGrid(b);


            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });
}
function LoadGrid(data) {

    var rownum = 0;
    $("#grid-container").dxDataGrid({
        dataSource: data,
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
                dataField: "Clipboard_Id",
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
                dataField: "Clipboard_Nos",
                caption: "เลขที่",
            },
            {
                dataField: "Clipboard_Date_Text",
                caption: "วันที่",
                dataType: "date",
                format: 'dd/MM/yyyy',
                alignment: "center",
            },
            {
                dataField: "Clipboard_Quantity",
                caption: "จำนวน(ใบ)",
            },
            {
                dataField: "Clipboard_Delivery_Desc",
                caption: "สถานที่จัดส่ง",
            },
            {
                dataField: "Clipboard_Id",
                caption: "แก้ไขข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a  onclick='Edit(" + options.data.Clipboard_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white'><i class='fa fa-pencil'></i></a>")
                        .appendTo(container);
                }

            },
            {
                dataField: "Clipboard_Id",
                caption: "ลบข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary' style='color:white'><i class='fa fa-trash'></i></a>")
                        .appendTo(container);
                }

            },
        ],



    });


}

function Edit(id) {
    $("#TempId").val(id);
    window.location = "#/ClipBoard/Index";
    $('.content').load(ref);

}