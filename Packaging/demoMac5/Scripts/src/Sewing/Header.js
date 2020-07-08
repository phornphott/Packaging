angular.module('AceApp').controller('SewingHeaderController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $("#gridContainer").hide();
        $("#btnAdd").hide();
        $("#showAdd").hide();

        $("#showAdd1").hide();
        
        CallData()
        
        $scope.Add = function() {


            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").show();
            $("#btnEditDEG").hide();
            $("#btnAddDEG").show();
            var item = {}

            LoadForm(item)

        }
        
        $scope.Insert = function() {
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();


            var obj = $("#form-container").dxForm("instance").option('formData');
            obj.Sewing_DateStart_Input = convertDate(obj.Sewing_DateStart);
            obj.Sewing_DateEnd_Input = convertDate(obj.Sewing_DateEnd);
            $.post("../Sewing/InsertSewing_HEADER", obj
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
                        DevExpress.ui.notify(data.data);
                    }

                });


        }

        $scope.Update = function() {
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();

            var url = "../Sewing/UpdateSEWING_HEADER";

            var obj = $("#form-container").dxForm("instance").option('formData');
            obj.Sewing_DateStart_Input = convertDate(obj.Sewing_DateStart);
            obj.Sewing_DateEnd_Input = convertDate(obj.Sewing_DateEnd);

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

        $scope.Refresh = function() {
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();
            CallData();
            $("#showAdd1").hide();
        }
    }
]);

function CallData() {
    var url = "../Sewing/GetSewing_HEADER/0";
    $("#gridContainer").show();
    $("#btnAdd").show();

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                var b = data.data;

                for (var a of b) {
                    //a.Sewing_DateStart = new Date(a.Sewing_DateStart_Input);
                    //a.Sewing_DateStart_Input = convertDate(a.Sewing_DateStart);
                    //a.Sewing_DateEnd = new Date(a.Sewing_DateEnd_Input);
                    //a.Sewing_DateEnd_Input = convertDate(a.Sewing_DateEnd);
                    if (a.Sewing_DateStart_Text !== null) {
                        a.Sewing_DateStart = new Date(a.Sewing_DateStart_Text);
                    }
                    else
                    {
                        a.Sewing_DateStart = new Date(a.Sewing_DateStart);
                    }
                    if (a.Sewing_DateEnd_Text !== null) {
                        a.Sewing_DateEnd = new Date(a.Sewing_DateEnd_Text);
                    }
                }
                console.log(b)
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

    $("#gridContainer").dxDataGrid({
        dataSource: data,
        allowColumnReordering: true,
        allowColumnResizing: true,
        columnAutoWidth: true,
        showColumnLines: true,
        showRowLines: true,
        showBorders: true,
        rowAlternationEnabled: true,
        height: 600,
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
            dataField: "Sewing_Id",
            caption: "ลำดับ",
            width: 100,
            alignment: 'center',
            allowFiltering: false,
            fixed: false,
            fixedPosition: 'left',
            cellTemplate: function (container, options) {

                rownum = rownum + 1;
                $("<div>")
                    .append(rownum)
                    .appendTo(container);
            }
        }, {
            dataField: "Sewing_Name",
            caption: "รหัสรูปแบบ",
            width: 180,
            alignment: "center",
        },

        {
            dataField: "Sewing_Use",
            caption: "ใช้รูปแบบนี้",
            width: 100,
            alignment: 'center',        
            cellTemplate: function (container, options) {
                if (options.data.Sewing_Use == 1) {
                    $("<div>")
                        .append("<h5><span class='fa fa-check'></span></h5>")
                        .appendTo(container);

                } else if (options.data.Sewing_Use == 0) {
                    $("<div>")
                        .append("<h5><span class='fa fa-close'></span></h5>")
                        .appendTo(container);
                }

            }
            
        },
        {
            dataField: "Sewing_UseDate",
            caption: "ไม่กำหนดระยะเวลา",
            width: 130,
            alignment: 'center',
            cellTemplate: function (container, options) {
                if (options.data.Sewing_UseDate == 1) {
                    $("<div>")
                        .append("<h5><span class='fa fa-check'></span></h5>")
                        .appendTo(container);

                } else if (options.data.Sewing_UseDate == 0) {
                    $("<div>")
                        .append("<h5><span class='fa fa-close'></span></h5>")
                        .appendTo(container);
                }

            }
        },
        {
            //dataField: "Sewing_DateStart_Input",
            dataField: "Sewing_DateStart_Text",
            caption: "ระยะเวลาเริ่มต้น",
            width: 150,
            dataType: "date",
            format: 'dd/MM/yyyy',
            alignment: "center",
        }, {
            //dataField: "Sewing_DateEnd_Input",
            dataField: "Sewing_DateEnd_Text",
            caption: "ระยะเวลาสิ้นสุด",
            width: 150,
            dataType: "date",
            format: 'dd/MM/yyyy',
            alignment: "center",
        }, {
            dataField: "Sewing_Desc",
            caption: "คำอธิบาย",

        },
        {
            dataField: "Sewing_Id",
            caption: "แก้ไขข้อมูล",
            alignment: 'center',
            allowFiltering: false,
            fixed: true,
            fixedPosition: 'right',
            width: 100,
            cellTemplate: function (container, options) {
                $("<div>")
                    .append("<a  onclick='Edit(" + options.key.Sewing_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                    .appendTo(container);
            }

        },
        {
            dataField: "Plastic_Id",
            caption: "ลบข้อมูล",
            alignment: 'center',
            allowFiltering: false,
            fixed: true,
            fixedPosition: 'right',
            width: 100,
            cellTemplate: function (container, options) {
                $("<div>")
                    .append("<a onclick='Delete(" + options.data.Sewing_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
                    .appendTo(container);
            }

        },]
    });

}

function Edit(id) {


    $("#SewingID").val(id)
    CallData1(id);
    CallData2(id);

    $("#showAdd1").show();

    $("#gridContainer").hide();
    $("#btnAdd").hide();
    $("#showAdd").show();
    $("#btnEditDEG").show();
    $("#btnAddDEG").hide();
    // load api
    var url = "../Sewing/GetSewing_HEADER/" + id;

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                //  LoadGrid(data.data);
                var a = data.data[0];
                //a.Sewing_DateStart = new Date(a.Sewing_DateStart_Input);
                //a.Sewing_DateEnd = new Date(a.Sewing_DateEnd_Input);
                if (a.Sewing_DateStart_Text !== null) {
                    a.Sewing_DateStart = new Date(a.Sewing_DateStart_Text);
                }
                if (a.Sewing_DateEnd_Text !== null) {
                    a.Sewing_DateEnd = new Date(a.Sewing_DateEnd_Text);
                }
                LoadForm(a);
            } else {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });

}
function Delete(id) {

    var r = confirm("ต้องการลบเม็ดพลาสติกนี้หรือไม่ !!!");
    if (r == true) {
        $.post("../Sewing/DeleteSewing_HEADER",
            {
                Sewing_Id: id,
                Sewing_DeleteUser: 0
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
function LoadForm(data) {

    $("#form-container").dxForm({
        colCount: 1,
        width: 500,
        formData: data,
        items: [{
            dataField: "Sewing_Name",
            label: {
                text: "รหัสรูปแบบ",
                Maxlenght:100,
            },
            editorOptions: {
                disabled: false
            },
            validationRules: [{
                type: "required",
                message: "โปรดระบุ รหัสรูปแบบ"
            }]
        },
        {
            dataField: "Sewing_Use",
            label: {
                text: "ใช้รูปแบบนี้"
            },
            editorOptions: {
                disabled: false,
                value:true,
            },
            editorType: "dxCheckBox",
        },
        {
            dataField: "Sewing_UseDate",

            label: {
                text: "ไม่กำหนดระยะเวลา",
            },
            editorType: "dxCheckBox",
            editorOptions: {
                disabled: false,
                value:false
            }
        },
        {
            dataField: "Sewing_DateStart",
            label: {
                text: "ระยะเวลาเริ่มต้น",
            },
            editorType: "dxDateBox",
            editorOptions: {
                disabled: false,
                displayFormat: "dd/MM/yyyy"
            }
        },
        {
            dataField: "Sewing_DateEnd",
            label: {
                text: "ระยะเวลาสิ้นสุด",
            },
            editorType: "dxDateBox",
            editorOptions: {
                disabled: false,
                displayFormat: "dd/MM/yyyy"
            }
        },

        {
            dataField: "Sewing_Desc",
            editorType: "dxTextArea",
            label: {
                text: "คำอธิบาย",
            },
            editorOptions: {
                disabled: false
            }
        },


        ]
    });

}