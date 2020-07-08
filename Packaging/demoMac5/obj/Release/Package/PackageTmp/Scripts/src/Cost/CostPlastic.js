
var listPlastic = (function () {
    var json = null;
    $.ajax({
        'async': false,
        'global': false,
        'url': '../Material/GetMPlastic/0',
        'dataType': "json",
        'success': function (data) {
            json = data;
        }
    });
    return json;
})();


function CallData2(id) {

    var url2 = "../Cost/GetCOST_PLASTIC/" + id

    $("#gridContainer2").show();

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
                width: 150,
                allowEditing: true,
                showEditorAlways: false,
                lookup: {
                    dataSource: listCostHeader.data,
                    valueExpr: 'Cost_Id',
                    displayExpr: 'Cost_Name',
                },
                validationRules: [{ type: "required" }],
            },
            
            {
                dataField: "Cost_P_Code",
                caption: "รหัสเม็ดพลาสติก",
                width: 150,
                lookup: {
                    dataSource: listPlastic.data,
                    valueExpr: 'Plastic_Id',
                    displayExpr: 'Plastic_Code',
                },
                validationRules: [{ type: "required" }],
            },
            {
                dataField: "Cost_P_Desc",
                caption: "รายละเอียดเม็ดพลาสติก",
                width: 180,
                validationRules: [{ type: "required" }],
            },
            {
                dataField: "Cost_P_Uname",
                caption: "หน่วยนับ",
                width: 150,
                validationRules: [{ type: "required" }],
            },

            {
                dataField: "Cost_P_Uprice",
                caption: "ต้นทุนต่อหน่วย",
                width: 150,
                validationRules: [{ type: "required" }],

            },
            {
                dataField: "Cost_P_Memo",
                caption: "หมายเหตุ",
                width: 150,
            },

            //{
            //    dataField: "Cost_P_Listno",
            //    caption: "ลำดับรายการ",
            //    width: 150,
            //},
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
            if (e.dataField === "Cost_P_Code") {
                e.editorOptions.onValueChanged = function (args) {
                    e.setValue(args.value);
                    if (listPlastic.data.length > 0) {
                        angular.forEach(listPlastic.data, function (value) {
                            if (value.Plastic_Id === e.row.data.Cost_P_Code) {
                                component.cellValue(rowIndex, "Cost_P_Desc", value.Plastic_NameT);
                                component.cellValue(rowIndex, "Cost_P_Uname", value.Plastic_UnamePrice);
                            }
                        })
                    }
                }
            }
        },
    });

}



//function Add() {


//    $("#gridContainer").hide();
//    $("#btnAdd").hide();
//    $("#showAdd").show();
//    $("#btnEditDEG").hide();
//    $("#btnAddDEG").show();
//    var item = { Plastic_Id: 0 }

//    LoadForm(item)

//}

//function Edit(id) {




//    $("#gridContainer").hide();
//    $("#btnAdd").hide();
//    $("#showAdd").show();
//    $("#btnEditDEG").show();
//    $("#btnAddDEG").hide();
//    // load api
//    var url = "../Cost/GetCOST_PLASTIC/" + id;

//    $.get(url)
//        .done(function (data) {

//            if (data.success == true) {
//                //  LoadGrid(data.data);
//                var a = data.data[0];
//                a.Cost_DateStart = new Date(a.Cost_DateStart_Input);
//                a.Cost_DateEnd = new Date(a.Cost_DateEnd_Input);
//                LoadForm(a);
//            } else {
//                DevExpress.ui.notify(data.data);
//                $("#loadIndicator").dxLoadIndicator({
//                    visible: false
//                });

//            }

//        });

//}

function Delete2(obj) {

    $.post("../Cost/DeleteCOST_PLASTIC", obj
           
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
                CallData2(obj.Cost_Id);
            });
    }


function Insert2(obj) {
    //$("#gridContainer").hide();
    //$("#btnAdd").hide();
    //$("#showAdd").hide();
    
    //var obj = $("#form-container").dxForm("instance").option('formData');
    obj.Cost_DateStart_Input = convertDate(obj.Cost_DateStart);
    obj.Cost_DateEnd_Input = convertDate(obj.Cost_DateStart);
    $.post("../Cost/InsertCOSTHEADER", obj
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
            CallData2(obj.Cost_Id);
        });


}

function Update2(obj) {
    //$("#gridContainer").hide();
    //$("#btnAdd").hide();
    //$("#showAdd").hide();

    var urlUp2 = "../Cost/UpdateCOST_PLASTIC/";

    //var obj = $("#form-container").dxForm("instance").option('formData');
    //obj.Cost_DateStart_Input = convertDate(obj.Cost_DateStart);
    //obj.Cost_DateEnd_Input = convertDate(obj.Cost_DateStart);

    $.post(urlUp2, obj)
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
            CallData2(obj.Cost_Id);

        });


}
