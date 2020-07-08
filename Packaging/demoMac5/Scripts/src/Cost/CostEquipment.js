$("#showAdd1").hide();


var listEquipment = (function () {
    var json = null;
    $.ajax({
        'async': false,
        'global': false,
        'url': "../Material/GetMEquipment/0",
        'dataType': "json",
        'success': function (data) {
            json = data;
        }
    });
    return json;
})();

function CallData1(id) {

    var url2 = "../COST/GetCOST_EQUIPMENT/" + id;
    $("#gridContainer1").show();
    $("#btnAdd").show();

    $.get(url2)
        .done(function (data) {

            if (data.success == true) {
                LoadGrid1(data.data);


            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });
}
function LoadGrid1(data) {


    var listCostHeader = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': '../Cost/GetCOST_HEADER/' + $("#costID").val(),
            'dataType': "json",
            'success': function (data) {
                json = data;
            }
        });
        return json;
    })();


    $("#gridContainer1").dxDataGrid({
        dataSource: data,
        allowColumnReordering: true,
        allowColumnResizing: true,
        columnAutoWidth: true,
        showColumnLines: true,
        showRowLines: true,
        showBorders: true,
        rowAlternationEnabled: true,
        height: 200,
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: "ค้นหา..."
        },
        columnChooser: {
            enabled: false
        },
        columnFixing: {
            enabled: true
        },
        editing: {
            mode: "row",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true
        },
        columns: [{
            dataField: "Cost_E_Listno",
            caption: "ลำดับ",
            width: 100,
            alignment: 'center',
            allowFiltering: false,
            fixed: false,
            fixedPosition: 'left',
            allowEditing: false,
            showEditorAlways: false,
            //cellTemplate: function (container, options) {

            //    rownum = rownum + 1;
            //    $("<div>")
            //        .append(rownum)
            //        .appendTo(container);
            //}
        },
        {
            dataField: "Cost_Id",
            caption: "ต้นทุนวัตถุดิบส่วนหัว",
            validationRules: [{ type: "required" }],
            lookup: {
                dataSource: listCostHeader.data,
                valueExpr: 'Cost_Id',
                displayExpr: 'Cost_Name',
            },
            allowEditing: true,
            showEditorAlways: false,
            width: 150,
        },
        {
            dataField: "Cost_E_Code",
            caption: "รหัสอุปกรณ์",
            validationRules: [{ type: "required" }],
            lookup: {
                dataSource: listEquipment.data,
                valueExpr: 'Equipment_Id',
                displayExpr: 'Equipment_Code',
            },

            width: 150,
        },

        {
            dataField: "Cost_E_Desc",
            caption: "รายละเอียดอุปกรณ์",
            validationRules: [{ type: "required" }],
            width: 180,
        },
        {
            dataField: "Cost_E_Uname",
            caption: "หน่วยนับ",
            validationRules: [{ type: "required" }],
            width: 150,
        },
        {
            dataField: "Cost_E_Uprice",
            caption: "ต้นทุนต่อหน่วย",
            width: 150,
            validationRules: [{ type: "required" }],
            alignment: "center",
        }, {
            dataField: "Cost_E_Memo",
            caption: "หมายเหตุ",

        },

        ],

        onEditingStart: function (e) {
            console.log(e);
            console.log("EditingStart");
        },
        onInitNewRow: function (e) {
            console.log(e);
            console.log("InitNewRow");
        },
        onRowInserting: function (e) {
            console.log(e);
            console.log("RowInserting");
        },
        onRowInserted: function (e) {

            Insert1(e.key)
            console.log("RowInserted");
        },
        onRowUpdating: function (e) {
            console.log(e);
            console.log("RowUpdating");
        },
        onRowUpdated: function (e) {

            Update1(e.key)
            console.log("RowUpdated");
        },
        onRowRemoving: function (e) {
            console.log(e);
            console.log("RowRemoving");
        },
        onRowRemoved: function (e) {
            console.log(e);
            Delete1(e.key)
            console.log("RowRemoved");
        },
        onEditorPreparing: function (e) {
            var component = e.component,
                rowIndex = e.row && e.row.rowIndex;
            if (e.dataField === "Cost_E_Code") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listEquipment.data.length > 0) {
                        angular.forEach(listEquipment.data, function (value) {
                            if (value.Equipment_Id === e.row.data.Cost_E_Code) {
                                component.cellValue(rowIndex, "Cost_E_Desc", value.Equipment_NameT);
                                component.cellValue(rowIndex, "Cost_E_Uname", value.Equipment_UnamePrice);
                            }
                        })
                    }
                }
            }
        },
    });

}
function Delete1(obj) {

    $.post("../COST/DeleteCOST_EQUIPMENT", obj
    )
        .done(function (data) {

            if (data.success == true) {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                CallData1(obj.Cost_Id);
            } else {
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                DevExpress.ui.notify(data.errMsg);
                CallData1(obj.Cost_Id);
            }

        });


}
function Insert1(obj) {

    //var obj = $("#form-container").dxForm("instance").option('formData');

    $.post("../COST/InsertCOST_EQUIPMENT", obj
    )
        .done(function (data) {

            if (data.success == true) {
                DevExpress.ui.notify(data.data);

                CallData1(obj.Cost_Id);
            } else {
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                DevExpress.ui.notify(data.data);
            }

        });


}
function Update1(obj) {
    //$("#gridContainer1").hide();
    //$("#btnAdd").hide();


    var url = "../COST/UpdateCOST_EQUIPMENT/";

    //var obj = $("#form-container").dxForm("instance").option('formData');


    $.post(url, obj)
        .done(function (data) {

            if (data.success == true) {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                CallData1(obj.Cost_Id);
            } else {
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                DevExpress.ui.notify(data.data);
            }

        });


}