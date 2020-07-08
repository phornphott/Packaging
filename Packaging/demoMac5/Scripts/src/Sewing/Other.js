
function CallData2(id) {

    var url2 = "../Sewing/GetSEWING_OTHER/" + id
  

    $.get(url2)
        .done(function (data) {

            if (data.success == true) {
                LoadGrid2(data.data);


            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });
}

function LoadGrid2(data) {

    var listSewing = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': '../Sewing/GetSewing_HEADER/' + $("#SewingID").val(),
            'dataType': "json",
            'success': function (data) {
                json = data;
            }
        });
        return json;
    })();

    var listSew = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': "../Wage/GetMSew/0",
            'dataType': "json",
            'success': function (data) {
                json = data;
            }
        });
        return json;
    })();
    $("#gridContainer2").dxDataGrid({
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
        //editing: {
        //    mode: "popup",
        //    allowUpdating: true,
        //    allowAdding: true,
        //    allowDeleting: true,
        //    popup: {
        //        title: "รหัสอื่น ๆ ",
        //        showTitle: true,
        //        width: 700,
        //        height: 345,
        //        position: {
        //            my: "top",
        //            at: "top",
        //            of: window
        //        }
        //    }
        //},
        columns: [{
            dataField: "Sewing_O_Listno",
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
                dataField: "Sewing_Id",
                caption: "ค่าจ้างเย็บด้ายและค่าสวมถุงในส่วนหัว",
                lookup: {
                    dataSource: listSewing.data,
                    valueExpr: 'Sewing_Id',
                    displayExpr: 'Sewing_Name',
                },
                allowEditing: true,
                showEditorAlways: false,
                alidationRules: [{ type: "required" }],
            },

            {
                dataField: "Sew_Id",
                caption: "รหัสงานอื่น ๆ",
                lookup: {
                    dataSource: listSew.data,
                    valueExpr: 'Sew_Id',
                    displayExpr: 'Sew_Code',
                },
                allowEditing: true,
                showEditorAlways: false,
                alidationRules: [{ type: "required" }],
            },
            {
                dataField: "Sewing_O_Code",
                caption: "รหัสงานอื่น ๆ",
                allowEditing: true,
                showEditorAlways: false,
                visible: false,
                //validationRules: [{ type: "required" }],
            },

        {
            dataField: "Sewing_O_Desc",
            caption: "รายละเอียดงานอื่น ๆ",
            allowEditing: true,
            showEditorAlways: false,
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Sewing_O_Uprice",
            caption: "ต้นทุนต่อหน่วย",
            width: 200,
            allowEditing: true,
            showEditorAlways: false,
            validationRules: [{ type: "required" }],
        },
        {
            dataField: "Sewing_O_Uname",
            caption: "หน่วยนับ",
             width: 200,
            alignment: 'center',
            allowEditing: true,
            showEditorAlways: false,
            validationRules: [{ type: "required" }],
        },
         {
            dataField: "Sewing_O_Memo",
            caption: "หมายเหตุ",
            width: 200,
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

            Insert2(e.key)
            console.log("RowInserted");
        },
        onRowUpdating: function (e) {
            console.log(e);
            console.log("RowUpdating");
        },
        onRowUpdated: function (e) {

            Update2(e.key)
            console.log("RowUpdated");
        },
        onRowRemoving: function (e) {
            console.log(e);
            console.log("RowRemoving");
        },
        onRowRemoved: function (e) {
            console.log(e);
            Delete2(e.key)
            console.log("RowRemoved");
        },
        onEditorPreparing: function (e) {
            var component = e.component,
                rowIndex = e.row && e.row.rowIndex;
            if (e.dataField === "Sew_Id") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listSew.data.length > 0) {
                        angular.forEach(listSew.data, function (value) {
                            if (value.Sew_Id === e.row.data.Sew_Id) {
                                component.cellValue(rowIndex, "Sewing_O_Code", value.Sew_Code);
                                component.cellValue(rowIndex, "Sewing_O_Desc", value.Sew_NameT);
                                component.cellValue(rowIndex, "Sewing_O_Uprice", value.Sew_UnamePrice);
                            }
                        })
                    }
                }
            }
        },
    });

}



//function LoadForm(data) {

//    var form =  $("#form-container").dxForm({
//        colCount: 1,
//        width: 500,
//        formData: data,
//        showColonAfterLabel: true,
//        showValidationSummary: true,
//        items: [{
//            dataField: "Sewing_Id",
//            label: {
//                text: "ค่าจ้างเย็บด้ายและสวมถุงในส่วนหัว",
//            },
//            placeholder: "โปรดเลือกค่าจ้างเย็บด้ายและสวมถุงในส่วนหัว",
//            editorType: "dxSelectBox",
//            editorOptions: {
//                items: listSewing.data,
//                valueExpr: 'Sewing_Id',
//                displayExpr: 'Sewing_Name',
//                disabled: false

//            },
//        }, {
//            dataField: "Sew_Id",
//            label: {
//                text: "เลือกรหัสงานเย็บ",
//            },
//            placeholder: "โปรดเลือกรหัสงานเย็บ",
//            editorType: "dxSelectBox",
//            editorOptions: {
//                items: listSew.data,
//                valueExpr: 'Sew_Id',
//                displayExpr: 'Sew_Code',
//                disabled: false

//            },
//        },{
//            dataField: "Sewing_O_Code",
//            label: {
//                text: "รหัสงานเย็บ",
//            },
//            editorOptions: {
//                disabled: true
//            },
//            validationRules: [{
//                type: "required",
//                message: "โปรดระบุ รหัสงานเย็บ"
//            }]
//        },
//        {
//            dataField: "Sewing_O_Desc",
//            label: {
//                text: "รายละเอียดงานเย็บ"
//            },
//            editorOptions: {
//                disabled: false
//            },
//        },
//        {
//            dataField: "Sewing_O_Uname",

//            label: {
//                text: "หน่วยนับ",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
//        {
//            dataField: "Sewing_O_Uprice",
//            label: {
//                text: "ต้นทุนต่อหน่วย",
//            },
//            editorOptions: {
//                disabled: false,
//            }
//        },
//        {
//            dataField: "Sewing_O_Memo",
//            label: {
//                text: "หมายเหตุ",
//            },
//            editorType: "dxTextArea",
//            editorOptions: {
//                disabled: false,
//            }
//        },
        
//        ],
//        onFieldDataChanged: function (data) {

//            if (data.dataField === "Sew_Id") {
//                this.updateData("Sewing_O_Code", form.getEditor("Sew_Id").option("selectedItem").Sew_Code);
//                this.updateData("Sewing_O_Desc", form.getEditor("Sew_Id").option("selectedItem").Sew_NameT);
//            }
//        },
//    }).dxForm("instance");

//}

function Insert2(obj) {
     $.post("../Sewing/InsertSEWING_OTHER", obj
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
                CallData2(obj.Sewing_Id);
            });

    
}

function Update2(obj) {
 

        var url = "../Sewing/UpdateSEWING_OTHER/";

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
                CallData2(obj.Sewing_Id);
            });

    
}


function Delete2(obj) {

    $.post("../Sewing/DeleteSEWING_OTHER", obj

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
            CallData2(obj.Sewing_Id);

        });



}
