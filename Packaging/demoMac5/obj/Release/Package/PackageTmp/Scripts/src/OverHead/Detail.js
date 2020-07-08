
function CallData1(id) {

    var url1 = "../Overhead/GetOVERHEAD_DETAIL/" + id;



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
    var listdepartment = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': "../Wage/GetMDepartment/0",
            'dataType': "json",
            'success': function (data) {
                json = data;
            }
        });
        return json;
    })();

    var listHEADER = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': "../OVERHEAD/GetOVERHEAD_HEADER/"+$("#OverheadID").val(),
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
            dataField: "Overhead_D_Listno",
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

                dataField: "Overhead_Id",
                caption: "ค่าโสหุ้ยส่วนหัว",
                width: 150,
                lookup: {
                    dataSource: listHEADER.data,
                    valueExpr: 'Overhead_Id',
                    displayExpr: 'Overhead_Name',
                },
                allowEditing: true,
                showEditorAlways: false,
                validationRules: [{ type: "required" }],
            },
            {
                dataField: "Deparment_Id",
                caption: "รหัสแผนก",
                lookup: {
                    dataSource: listdepartment.data,
                    valueExpr: 'Department_Id',
                    displayExpr: 'Department_Code',
                  
                },
                validationRules: [{
                    type: "required",
                    message: "โปรดเลือกรหัสแผนก"
                }]
            },
            {

                dataField: "Overhead_D_Code",
                caption: "รหัสแผนก",
                width: 150,
                visible: false,
            },

            {
                dataField: "Overhead_D_Desc",
                caption: "รายละเอียด",
                width: 200,
            },
            {
                dataField: "Overhead_D_Uprice",
                caption: "ต้นทุนต่อหน่วย",
                width: 150,
                alignment: "center",
            },
            {
                dataField: "Overhead_D_Uname",
                caption: "หน่วยนับ",
                width: 80,
                alignment: 'center',
           
            },
            {
                dataField: "Overhead_D_Memo",
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

            Insert(e.key)
            console.log("RowInserted");
        },
        onRowUpdating: function (e) {
            console.log(e);
            console.log("RowUpdating");
        },
        onRowUpdated: function (e) {

            Update(e.key)
            console.log("RowUpdated");
        },
        onRowRemoving: function (e) {
            console.log(e);
            console.log("RowRemoving");
        },
        onRowRemoved: function (e) {
            Delete1(e.key)
        },
        onEditorPreparing: function (e) {
            var component = e.component,
                rowIndex = e.row && e.row.rowIndex;
            if (e.dataField === "Deparment_Id") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listdepartment.data.length > 0) {
                        angular.forEach(listdepartment.data, function (value) {
                            if (value.Department_Id === e.row.data.Deparment_Id) {
                                component.cellValue(rowIndex, "Overhead_D_Desc", value.Department_NameT);
                                component.cellValue(rowIndex, "Overhead_D_Uname", value.Department_Uname);
                            }
                        })
                    }
                }
            }
        },
    });

}




function Delete(obj) {
    
    $.post("../Overhead/DeleteOVERHEAD_DETAIL", obj
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
                CallData1(obj.Overhead_Id);
            });
    


}
//function LoadForm(data) {

//  var form =  $("#form-container").dxForm({
//      colCount: 1,
//      width: 500,
//      showColonAfterLabel: true,
//      showValidationSummary: true,
//        formData: data,
//        items: [{
//            dataField: "Overhead_Id",
//            label: {
//                text: "ค่าโสหุ้ยส่วนหัว",
//            },
//            placeholder: "โปรดเลือกค่าโสหุ้ยส่วนหัว",
//            editorType: "dxSelectBox",
//            editorOptions: {
//                items: listHEADER.data,
//                valueExpr: 'Overhead_Id',
//                displayExpr: 'Overhead_Name',
//                disabled: false
//            },
//            validationRules: [{
//                type: "required",
//                message: "โปรดเลือกค่าโสหุ้ยส่วนหัว"
//            }]
//        },
//            {
//                dataField: "Deparment_Id",
//                label: {
//                    text: "เลือกรหัสแผนก",
//                },
//                placeholder: "โปรดเลือก",
//                editorType: "dxSelectBox",
//                editorOptions: {
//                    items: listM_DEPARTMENT.data,
//                    valueExpr: 'Department_Id',
//                    displayExpr: 'Department_Code',
//                    disabled: false
//                },
//                validationRules: [{
//                    type: "required",
//                    message: "โปรดเลือกรหัสแผนก"
//                }]
//            },
//            {
//            dataField: "Overhead_D_Code",
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
//            dataField: "Overhead_D_Desc",
//            label: {
//                text: "รายละเอียดงานเย็บ"
//            },
//            editorOptions: {
//                disabled: false
//            },
//            validationRules: [{
//                type: "required",
//                message: "โปรดระบุ รายละเอียดงานเย็บ"
//            }]
//        },
//        {
//            dataField: "Overhead_D_Uname",

//            label: {
//                text: "หน่วยนับ",
//            },
         
//        },
//        {
//            dataField: "Overhead_D_Uprice",
//            label: {
//                text: "ต้นทุนต่อหน่วย",
//            },
          
//        },
//        {
//            dataField: "Overhead_D_Memo",
//            label: {
//                text: "หมายเหตุ",
//            },
//            editorType: "dxTextArea",
//        },
        

//        ],
//        onFieldDataChanged: function (data) {
//            if (data.dataField === "Deparment_Id") {
//                this.updateData("Overhead_D_Code", form.getEditor("Deparment_Id").option("selectedItem").Department_Code);
//                this.updateData("Overhead_D_Desc", form.getEditor("Deparment_Id").option("selectedItem").Department_NameT);
//            }
//        },
//    }).dxForm("instance");
//}

function Insert(obj) {

        $.post("../Overhead/InsertOVERHEAD_DETAIL", obj
        )
            .done(function (data) {

                if (data.success == true) {
                    DevExpress.ui.notify(data.data);
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    CallData1(obj.Overhead_Id);
                } else {
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    DevExpress.ui.notify(data.data);
                }

            });
    

}

function Update(obj) {
 
        var url = "../Overhead/UpdateOVERHEAD_DETAIL/";

      
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
                CallData1(obj.Overhead_Id);
            });
    
        
}
