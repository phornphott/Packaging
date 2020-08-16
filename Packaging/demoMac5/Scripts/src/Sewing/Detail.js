
function CallData1(id) {

    var url1 = "../Sewing/GetSEWING_DETAIL/" + id;
    $.get(url1)
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


    var listSew = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': "../Wage/GetMSew/0" ,
            'dataType': "json",
            'success': function (data) {
                json = data;
            }
        });
        return json;
    })();


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

  

    $("#gridContainer1").dxDataGrid({
        dataSource: data,
        allowColumnReordering: true,
        allowColumnResizing: true,
        columnAutoWidth: true,
        showColumnLines: true,
        showRowLines: true,
        showBorders: true,
        rowAlternationEnabled: true,
        height: 300,
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
                dataField: "Sewing_D_Listno",
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
                   validationRules: [{ type: "required" }],
                },

              {
                  dataField: "Sew_Id",
                  caption: "รหัสงานเย็บ",
                  lookup: {
                      dataSource: listSew.data,
                      valueExpr: 'Sew_Id',
                     displayExpr: 'Sew_Code',
                  },
                  allowEditing: true,
                  showEditorAlways: false,
                  validationRules: [{ type: "required" }],
              },

        {
            dataField: "Sewing_D_Code",
            caption: "รหัสงานเย็บ",
            allowEditing: true,
            showEditorAlways: false,
            visible: false,
            validationRules: [{ type: "required" }],
        },

        {
            dataField: "Sewing_D_Desc",
            caption: "รายละเอียดงานเย็บ",
            alignment: 'center',
            validationRules: [{ type: "required" }],
            
        },
        {
            dataField: "Sewing_D_Uname",
            caption: "หน่วยนับ",
            validationRules: [{ type: "required" }],
            alignment: 'center',
            
           
        },
        {
            dataField: "Sewing_D_Uprice",
            caption: "ต้นทุนต่อหน่วย",
            alignment: "center",
            validationRules: [{ type: "required" }],
        }, {
            dataField: "Sewing_D_Memo",
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
            if (e.dataField === "Sew_Id") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listSew.data.length > 0) {
                        angular.forEach(listSew.data, function (value) {
                            if (value.Sew_Id === e.row.data.Sew_Id) {
                                component.cellValue(rowIndex, "Sewing_D_Code", value.Sew_Code);
                                component.cellValue(rowIndex, "Sewing_D_Desc", value.Sew_NameT);
                                component.cellValue(rowIndex, "Sewing_D_Uname", value.Sew_UnamePrice);
                            }
                        })
                    }
                }
            }
        },
    
    });

}

function Delete(obj) {

    $.post("../Sewing/DeleteSEWING_DETAIL", obj
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
                CallData1(obj.Sewing_Id);
            });
    


}

//function LoadForm(data) {

//  var form = $("#form-container").dxForm({
//          colCount: 1,
//          width: 500,
//        formData: data,
//        items: [
//            {
//                dataField: "Sewing_Id",
//                label: {
//                    text: "ค่าจ้างเย็บด้ายและสวมถุงในส่วนหัว",
//                },
//                placeholder: "โปรดเลือกค่าจ้างเย็บด้ายและสวมถุงในส่วนหัว",
//                editorType: "dxSelectBox",
//                editorOptions: {
//                    items: listSewing.data,
//                    valueExpr: 'Sewing_Id',
//                    displayExpr: 'Sewing_Name',
//                    disabled: false

//                },
//                validationRules: [{
//                    type: "required",
//                    message: "โปรดเลือก ค่าจ้างเย็บด้ายและสวมถุงในส่วนหัว"
//                }]
//            }, {
//                dataField: "Sew_Id",
//                label: {
//                    text: "เลือกรหัสงานเย็บ",
//                },
//                placeholder: "โปรดเลือกรหัสงานเย็บ",
//                editorType: "dxSelectBox",
//                editorOptions: {
//                    items: listSew.data,
//                    valueExpr: 'Sew_Id',
//                    displayExpr: 'Sew_Code',
//                    disabled: false

//                },
//                validationRules: [{
//                    type: "required",
//                    message: "โปรดระบุ รหัสงานเย็บ"
//                }]
//            },

//            {
//            dataField: "Sewing_D_Code",
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
//            dataField: "Sewing_D_Desc",
//            label: {
//                text: "รายละเอียดงานเย็บ"
//            },
//            editorOptions: {
//                disabled: false
//            },
//        },
//        {
//            dataField: "Sewing_D_Uname",

//            label: {
//                text: "หน่วยนับ",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
//        {
//            dataField: "Sewing_D_Uprice",
//            label: {
//                text: "ต้นทุนต่อหน่วย",
//            },
//            editorOptions: {
//                disabled: false,
//            }
//        },
//        {
//            dataField: "Sewing_D_Memo",
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
//                this.updateData("Sewing_D_Code", form.getEditor("Sew_Id").option("selectedItem").Sew_Code);
//                this.updateData("Sewing_D_Desc", form.getEditor("Sew_Id").option("selectedItem").Sew_NameT);

//            }
//        }
//    }).dxForm("instance");


//}

function Insert1(obj) {


        $.post("../Sewing/InsertSEWING_DETAIL", obj
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
                CallData1(obj.Sewing_Id);
            });
    

}

function Update1(obj) {
        var url1 = "../Sewing/UpdateSEWING_DETAIL/";
        $.post(url1, obj)
            .done(function (data) {

                if (data.success == true) {
                    DevExpress.ui.notify(data.data);
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    CallData1(obj.Sewing_Id);
                } else {
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    DevExpress.ui.notify(data.data);
                }

            });
    }



