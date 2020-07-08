
var listworkprint = (function () {
    var json = null;
    $.ajax({
        'async': false,
        'global': false,
        'url': '../Material/GetMPrint/0',
        'dataType': "json",
        'success': function (data) {
            json = data;
        }
    });
    return json;
})();

function CallData3(id) {
 

    var url3 = "../Cost/GetCOST_PRINT/" + id

    $.get(url3)
        .done(function (data) {

            if (data.success == true) {
                LoadGrid3(data.data);


            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });
}

function LoadGrid3(data) {


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

    $("#gridContainer3").dxDataGrid({
        dataSource: data,
        allowColumnReordering: true,
        allowColumnResizing: true,
        columnAutoWidth: true,
        showColumnLines: true,
        showRowLines: true,
        showBorders: true,
        rowAlternationEnabled: true,
        height: 200,
        editing: {
            mode: "row",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true
        },
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
        columns: [{
            dataField: "Cost_P_Listno",
            caption: "ลำดับ",
            width: 100,
            alignment: 'center',
            allowFiltering: false,
            fixed: false,
            fixedPosition: 'left',
            allowEditing: false,
            showEditorAlways: false,
        }
            ,
            {
                dataField: "Cost_Id",
                caption: "ต้นทุนวัตถุดิบส่วนหัว",
                width: 150,
                allowEditing: true,
                showEditorAlways: false,
                lookup: {
                    dataSource: listCostHeader.data,
                    valueExpr: 'Cost_Id',
                    displayExpr: 'Cost_Name',
                },
                validationRules: [{ type: "required" }],
            },{
            dataField: "Cost_P_Code",
            caption: "รหัสงานพิมพ์",
            lookup: {
                dataSource: listworkprint.data,
                valueExpr: 'Print_Id',
                displayExpr: 'Print_Code',
                
            },
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_Desc",
            caption: "รายละเอียดงานพิมพ์",
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_Uname",
            caption: "หน่วยนับ",
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_UpriceR1",
            caption: "ต้นทุนกว้าง 12-20",
            validationRules: [{ type: "required" }],
            alignment: "center",
        }, {
            dataField: "Cost_P_UpriceR2",
            caption: "ต้นทุนกว้าง 21-30",
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_UpriceR3",
            caption: "ต้นทุนกว้าง 31-60",
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_Memo",
            caption: "หมายเหตุ",
            width: 150,
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

            Insert3(e.key)
            console.log("RowInserted");
        },
        onRowUpdating: function (e) {
            console.log(e);
            console.log("RowUpdating");
        },
        onRowUpdated: function (e) {

            Update3(e.key)
            console.log("RowUpdated");
        },
        onRowRemoving: function (e) {
            console.log(e);
            console.log("RowRemoving");
        },
        onRowRemoved: function (e) {
            console.log(e);
            Delete3(e.key)
            console.log("RowRemoved");
        },
        onEditorPreparing: function (e) {
            var component = e.component,
                rowIndex = e.row && e.row.rowIndex;
            if (e.dataField === "Cost_P_Code") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listworkprint.data.length > 0) {
                        angular.forEach(listworkprint.data, function (value) {
                            if (value.Print_Id === e.row.data.Cost_P_Code) {
                                component.cellValue(rowIndex, "Cost_P_Desc", value.Print_NameT);
                                component.cellValue(rowIndex, "Cost_P_Uname",value.Print_UnamePrice);
                            }
                        })
                    }
                }
            }
        },
    });

}

function Delete3(obj) {


    $.post("../Cost/DeleteCOST_PRINT", obj )
            .done(function (data) {

                if (data.success == true) {
                    DevExpress.ui.notify(data.data);
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    
                } else {
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    DevExpress.ui.notify(data.errMsg);
                }
                CallData3(obj.Cost_Id);
            });
    


}

function Insert3(obj) {

    $.post("../Cost/InsertCOST_PRINT", obj
    )
        .done(function (data) {

            if (data.success == true) {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
              
            } else {
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                DevExpress.ui.notify(data.data);
            }
            CallData3(obj.Cost_Id);
        });


}

function Update3(obj) {

    var url = "../COST/UpdateCOST_PRINT/";

    $.post(url, obj)
        .done(function (data) {

            if (data.success == true) {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
            } else {
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                DevExpress.ui.notify(data.data);
            }
            CallData3(obj.Cost_Id);
        });


}
