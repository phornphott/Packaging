
$("#showAdd1").hide();

function CallData4(id) {

    var url4 = "../COST/GetCOST_PRINT_ADD1/" + id


    $.get(url4)
        .done(function (data) {

            if (data.success == true) {
                LoadGrid4(data.data);


            } else {
                DevExpress.ui.notify(data.errMsg);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });
}

function LoadGrid4(data) {



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
    $("#gridContainer4").dxDataGrid({
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
                validationRules: [{ type: "required" }],
                lookup: {
                    dataSource: listCostHeader.data,
                    valueExpr: 'Cost_Id',
                    displayExpr: 'Cost_Name',
                },
                allowEditing: true,
                showEditorAlways: false,
                width: 150,
        }, {
            dataField: "Cost_P_Range",
            caption: "ปริมาณ จาก-ถึง",
            validationRules: [{ type: "required" }],
        }, {
                dataField: "Cost_P_Uprice",
                caption: "ต้นทุนคิดเพิ่ม",
                validationRules: [{ type: "required" }],
        }, {
                
                dataField: "Cost_P_Uname",
                caption: "หน่วยนับ",
                validationRules: [{ type: "required" }],
                alignment: "center",
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

            Insert4(e.key)
            console.log("RowInserted");
        },
        onRowUpdating: function (e) {
            console.log(e);
            console.log("RowUpdating");
        },
        onRowUpdated: function (e) {

            Update4(e.key)
            console.log("RowUpdated");
        },
        onRowRemoving: function (e) {
            console.log(e);
            console.log("RowRemoving");
        },
        onRowRemoved: function (e) {
            console.log(e);
            Delete4(e.key)
            console.log("RowRemoved");
        }
    });

}

function Insert4(obj) {
    //$("#gridContainer").hide();
    //$("#btnAdd").hide();
    //$("#showAdd").hide();


    //var obj = $("#form-container").dxForm("instance").option('formData');

    $.post("../COST/InsertCOST_PRINT_ADD1", obj
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
            CallData4(obj.Cost_Id);
        });


}

function Update4(obj) {
  

    var url4 = "../COST/UpdateCOST_PRINT_ADD1/";

    $.post(url4, obj)
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

            CallData4(obj.Cost_Id);
        });


}

function Delete4(obj) {
    
        $.post("../COST/DeleteCOST_PRINT_ADD1", obj
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
                CallData4(obj.Cost_Id);
            });
    


}
