
function CallData15(id) {
    

    var url1 = "../Shipping/GetSHIPPING_DETAIL/" + id;

    $.get(url1)
        .done(function (data) {

            if (data.success == true) {
                //var b = data.data;

                //for (var a of b) {
                //    a.Shipping_DateStart = new Date(a.Shipping_DateStart_Input);
                //    a.Shipping_DateStart_Input = convertDate(a.Shipping_DateStart);
                //    a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Input);
                //    a.Shipping_DateEnd_Input = convertDate(a.Shipping_DateEnd);
                //}
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


    var listHEADER = (function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': "../Shipping/GetSHIPPING_HEADER/" + $("#ShippingID").val(),
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
            dataField: "Shipping_D_Id",
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
            dataField: "Shipping_Id",
            caption: "ค่าขนส่งส่วนหัว",
            lookup: {
                dataSource: listHEADER.data,
                valueExpr: 'Shipping_Id',
                displayExpr: 'Shipping_Name'
            },   
            width: 150,
            allowEditing: true,
            showEditorAlways: false,
            validationRules: [{ type: "required" }],
        }, 
        {
            dataField: "Shipping_D_Range",
            caption: "ปริมาณ จาก-ถึง",
            width: 150,
            allowEditing: true,
            showEditorAlways: false,
            validationRules: [{ type: "required" }],
        },
            {
            dataField: "Shipping_D_Uname",
            caption: "หน่วยนับ",
            width: 150,
                alignment: "center",
                allowEditing: true,
                showEditorAlways: false,
                validationRules: [{ type: "required" }],
        }, {
            dataField: "Shipping_D_Uprice",
                caption: "ต้นทุนคิดเพิ่ม",
                allowEditing: true,
                showEditorAlways: false,
                validationRules: [{ type: "required" }],

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
            console.log(e);
            Delete(e.key)
            console.log("RowRemoved");
        }
    });

}



function Add() {

    $("#gridContainer1").hide();
    $("#btnAdd").hide();
    $("#showAdd").show();
    $("#btnEditDEG").hide();
    $("#btnAddDEG").show();
    var item = {}

    LoadForm(item)

}

//function Edit(id) {

//    $("#gridContainer1").hide();
//    $("#btnAdd").hide();
//    $("#showAdd").show();
//    $("#btnEditDEG").show();
//    $("#btnAddDEG").hide();
//    // load api
//    var url = "../Shipping/GetSHIPPING_DETAIL/" + id;

//    $.get(url)
//        .done(function (data) {

//            if (data.success == true) {
//                //  LoadGrid(data.data);
//                var a = data.data[0];
//                a.Shipping_DateStart = new Date(a.Shipping_DateStart_Input);
//                a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Input);
//                LoadForm(a);
//            } else {
//                DevExpress.ui.notify(data.data);
//                $("#loadIndicator").dxLoadIndicator({
//                    visible: false
//                });

//            }

//        });

//}

function Delete(id) {

    var r = confirm("ต้องการลบค่าขนส่งนี้หรือไม่ !!!");
    if (r == true) {
        $.post("../Shipping/DeleteSHIPPING_DETAIL",
            {
                Shipping_Id: id,
                Shipping_DeleteUser: 0
            }
        )
            .done(function (data) {

                if (data.success == true) {
                    DevExpress.ui.notify(data.data);
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    CallData();
                } else {
                    $("#loadIndicator").dxLoadIndicator({
                        visible: false
                    });
                    DevExpress.ui.notify(data.errMsg);
                }

            });
    }


}
//function LoadForm(data) {
//    console.log(listHEADER.data)
//    $("#form-container").dxForm({
//        colCount: 1,
//        width: 500,
//        showColonAfterLabel: true,
//        showValidationSummary: true,
//        formData: data,
//        items: [
//            {
//                dataField: "Shipping_Id",
//                label: {
//                    text: "ค่าขนส่งส่วนหัว",
//                },
//                placeholder: "โปรดเลือกค่าขนส่งส่วนหัว",
//                editorType: "dxSelectBox",
//                editorOptions: {
//                    items: listHEADER.data,
//                    valueExpr: 'Shipping_Id',
//                    displayExpr: 'Shipping_Name',
//                    disabled: false

//                },
//                validationRules: [{
//                    type: "required",
//                    message: "โปรดเลือก ค่าขนส่งส่วนหัว"
//                }]
//            },{
//            dataField: "Shipping_D_Range",
//            label: {
//                text: "ปริมาณ จาก-ถึง",
//            },
//            editorOptions: {
//                disabled: false
//            },
//            validationRules: [{
//                type: "required",
//                message: "โปรดระบุ ปริมาณ จาก-ถึง"
//            }]
//        },
//        {
//            dataField: "Shipping_D_Uname",
//            label: {
//                text: "หน่วยนับ"
//            },
//            editorOptions: {
//                disabled: false
//            },
         
//        },
//        {
//            dataField: "Shipping_D_Uprice",

//            label: {
//                text: "ต้นทุนคิดเพิ่ม",
//            },
//            editorOptions: {
//                disabled: false
//            }
//        },
       


//        ]
//    });

//}

function Insert(obj) {
    //if ($("#form-container").dxForm("instance").validate().isValid) {
    //$("#gridContainer1").hide();
    //$("#btnAdd").hide();
    //$("#showAdd").hide();


    //var obj = $("#form-container").dxForm("instance").option('formData');

    $.post("../Shipping/InsertSHIPPING_DETAIL", obj
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
            CallData15(obj.Shipping_Id);
        });
}

function Update() {
        if ($("#form-container").dxForm("instance").validate().isValid) {
    $("#gridContainer1").hide();
    $("#btnAdd").hide();
    $("#showAdd").hide();

    var url = "../Shipping/UpdateSHIPPING_DETAIL/";

    var obj = $("#form-container").dxForm("instance").option('formData');

    $.post(url, obj)
        .done(function (data) {

            if (data.success == true) {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                CallData();
            } else {
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });
                DevExpress.ui.notify(data.data);
            }

        });
            }

}

function Refresh() {
    $("#gridContainer1").hide();
    $("#btnAdd").hide();
    $("#showAdd").hide();
    CallData();

}