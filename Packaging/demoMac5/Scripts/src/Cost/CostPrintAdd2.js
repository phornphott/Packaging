
$("#showAdd1").hide();


var listPrint = (function () {
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

function CallData5(id) {

    var url = "../Cost/GetCOST_PRINT_ADD2/" + id;

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                LoadGrid5(data.data);


            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });
}

function LoadGrid5(data) {

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

    $("#gridContainer5").dxDataGrid({
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
        columns: [
            {
                dataField: "Cost_P_Listno",
                caption: "ลำดับ",
                width: 100,
                alignment: 'center',
                allowFiltering: false,
                fixed: false,
                fixedPosition: 'left',
                allowEditing: false,
                showEditorAlways: false,
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
                validationRules: [{ type: "required" }],
            },
            {
                dataField: "Cost_P_Code",
                caption: "รหัสงานพิมพ์",
                alignment: "center",
                validationRules: [{ type: "required" }],
                lookup: {
                    dataSource: listPrint.data,
                    valueExpr: 'Print_Id',
                    displayExpr: 'Print_Code',
                    onSelectionChanged: function (selectedItems) {
                        var data = selectedItems.selectedRowsData[0];

                        console.log(data)
                    }


                },
                allowEditing: true,
                showEditorAlways: false,
                width: 150,
                validationRules: [{ type: "required" }],
            },
             {
            dataField: "Cost_P_Desc",
            caption: "รายละเอียดงานพิมพ์",
            width: 150,
            alignment: "center",
        }, {
            dataField: "Cost_P_Uname",
            caption: "หน่วยนับ",
            validationRules: [{ type: "required" }],
        }, {
                dataField: "Cost_P_UpriceR1",
                caption: "ต้นทุนกว้าง 12-20",
                alignment: "center",
                validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_UpriceR2",
            caption: "ต้นทุนกว้าง 21-30",
            alignment: "center",
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_UpriceR3",
            caption: "ต้นทุนกว้าง 31-60",
            alignment: "center",
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Cost_P_Memo",
            caption: "หมายเหตุ",
            alignment: "center",
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

            Insert5(e.key)
            console.log("RowInserted");
        },
        onRowUpdating: function (e) {
            console.log(e);
            console.log("RowUpdating");
        },
        onRowUpdated: function (e) {

            Update5(e.key)
            console.log("RowUpdated");
        },
        onRowRemoving: function (e) {
            console.log(e);
            console.log("RowRemoving");
        },
        onRowRemoved: function (e) {
            console.log(e);
            Delete5(e.key)
            console.log("RowRemoved");
        },
        onEditorPreparing: function (e) {
            var component = e.component,
                rowIndex = e.row && e.row.rowIndex;
            if (e.dataField === "Cost_P_Code") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listPrint.data.length > 0) {
                        angular.forEach(listPrint.data, function (value) {
                            if (value.Print_Id === e.row.data.Cost_P_Code) {
                                component.cellValue(rowIndex, "Cost_P_Desc", value.Print_NameT);
                                component.cellValue(rowIndex, "Cost_P_Uname", value.Print_UnamePrice);
                            }
                        })
                    }
                }
            }
        },
        

    });

}

//function LoadForm(data) {

//   var form = $("#form-container").dxForm({
//       colCount: 1,
//       width: 500,
//        formData: data,
//        items: [
//            {
//                dataField: "Cost_Id",
//                label: {
//                    text: "ต้นทุนวัตถุดิบส่วนหัว",
//                },
//                placeholder: "โปรดเลือกต้นทุนวัตถุดิบส่วนหัว",
//                editorType: "dxSelectBox",
//                editorOptions: {
//                    items: listCostHeader.data,
//                    valueExpr: 'Cost_Id',
//                    displayExpr: 'Cost_Name',
//                    disabled: false

//                },
//            },
//            {
//                dataField: "Print_Id",
//                label: {
//                    text: "เลือกงานพิมพ์",
//                },
//                placeholder: "โปรดเลือกงานพิมพ์",
//                editorType: "dxSelectBox",
//                editorOptions: {
//                    items: listPrint.data,
//                    valueExpr: 'Print_Id',
//                    displayExpr: 'Print_Code',
//                    disabled: false

//                },
//            },{
//            dataField: "Cost_P_Code",
//            label: {
//                text: "รหัสงานพิมพ์",
//            },
//            editorOptions: {
//                disabled: true
//            },
//            validationRules: [{
//                type: "required",
//                message: "โปรดระบุ รหัสงานพิมพ์"
//            }]
//        },
//        {
//            dataField: "Cost_P_Desc",
//            label: {
//                text: "รายละเอียดงานพิมพ์"
//            },
//            editorOptions: {
//                disabled: false
//            },
//            validationRules: [{
//                type: "required",
//                message: "โปรดระบุ รายละเอียดงานพิมพ์"
//            }]
//        },
//        {
//            dataField: "Cost_P_Uname",

//            label: {
//                text: "หน่วยนับ",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
//        {
//            dataField: "Cost_P_UpriceR1",

//            label: {
//                text: "ต้นทุนกว้าง 12-20",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
//        {
//            dataField: "Cost_P_UpriceR2",

//            label: {
//                text: "ต้นทุนกว้าง 21-30",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
//        {
//            dataField: "Cost_P_UpriceR3",

//            label: {
//                text: "ต้นทุนกว้าง 31-60",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
//        {
//            dataField: "Cost_P_Memo",
//            editorType: "dxTextArea",
//            label: {
//                text: "หมายเหตุ",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },



//        ],
//        onSelectionChanged: function (data) {
//            if (data.dataField === "Print_Id") {
//                this.updateData("Cost_P_Code", form.getEditor("Print_Id").option("selectedItem").Print_Code);
//                this.updateData("Cost_P_Desc", form.getEditor("Print_Id").option("selectedItem").Print_NameT);
//            }
//        },
//    }).dxForm("instance");

//}

function Insert5(obj) {

    $.post("../COST/InsertCOST_PRINT_ADD2", obj
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

        });
    CallData5(obj.Cost_Id);

}

function Update5(obj) {


    var url = "../COST/UpdateCOST_PRINT_ADD2/";


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
            CallData5(obj.Cost_Id);
        });


}

function Delete5(obj) {

    $.post("../COST/DeleteCOST_PRINT_ADD2",
        obj
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
                DevExpress.ui.notify(data.errMsg);
            }
            CallData5(obj.Cost_Id);
        });



}