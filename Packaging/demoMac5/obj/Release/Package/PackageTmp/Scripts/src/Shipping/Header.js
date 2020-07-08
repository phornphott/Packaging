angular.module('AceApp').controller('ShippingController', ['$scope', '$rootScope', '$stateParams', '$http',
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
            obj.Shipping_DateStart_Input = convertDate(obj.Shipping_DateStart);
            obj.Shipping_DateEnd_Input = convertDate(obj.Shipping_DateEnd);
            $.post("../Shipping/InsertShipping_HEADER", obj
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

            var url = "../Shipping/UpdateShipping_HEADER/";

            var obj = $("#form-container").dxForm("instance").option('formData');
            console.log(obj)
            obj.Shipping_DateStart_Input = convertDate(obj.Shipping_DateStart);
            obj.Shipping_DateEnd_Input = convertDate(obj.Shipping_DateEnd);

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
            $("#showAdd1").hide();
            CallData();

        }
    }
]);

function CallData() {
    var url = "../Shipping/GetShipping_HEADER/0";
    $("#gridContainer").show();
    $("#btnAdd").show();

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                var b = data.data;

                for (var a of b) {
                    //a.Shipping_DateStart = new Date(a.Shipping_DateStart_Input);
                    //a.Shipping_DateStart_Input = convertDate(a.Shipping_DateStart);
                    //a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Input);
                    //a.Shipping_DateEnd_Input = convertDate(a.Shipping_DateEnd);
                    if (a.Shipping_DateStart_Text !== null) {
                        a.Shipping_DateStart = new Date(a.Shipping_DateStart_Text);
                    }
                    else {
                        a.Shipping_DateStart = new Date(a.Shipping_DateStart);
                    }
                    if (a.Shipping_DateEnd_Text !== null) {
                        a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Text);
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
        columns: [
            {
                dataField: "Shipping_Id",
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
            },
            {
                dataField: "Shipping_Name",
                caption: "รหัสรูปแบบ",
                width: 150,
                alignment: 'center',
            },

            {
                dataField: "Shipping_Use",
                caption: "ใช้รูปแบบนี้",
                width: 120,
                alignment: 'center',
                cellTemplate: function (container, options) {
                    if (options.data.Shipping_Use == 1) {
                        $("<div>")
                            .append("<h5><span class='fa fa-check'></span></h5>")
                            .appendTo(container);

                    } else if (options.data.Shipping_Use == 0) {
                        $("<div>")
                            .append("<h5><span class='fa fa-close'></span></h5>")
                            .appendTo(container);
                    }

                }
            },
            {
                dataField: "Shipping_UseDate",
                caption: "ไม่กำหนดระยะเวลา",
                width: 120,
                alignment: 'center',
                cellTemplate: function (container, options) {
                    if (options.data.Shipping_UseDate == 1) {
                        $("<div>")
                            .append("<h5><span class='fa fa-check'></span></h5>")
                            .appendTo(container);

                    } else if (options.data.Shipping_UseDate == 0) {
                        $("<div>")
                            .append("<h5><span class='fa fa-close'></span></h5>")
                            .appendTo(container);
                    }

                }
            },


            {
                dataField: "Shipping_DateStart_Text",
                caption: "ระยะเวลาเริ่มต้น",
                width: 150,
                dataType: "date",
                format: 'dd/MM/yyyy',
                alignment: "center",
            }, {
                dataField: "Shipping_DateEnd_Text",
                caption: "ระยะเวลาสิ้นสุด",
                width: 150,
                dataType: "date",
                format: 'dd/MM/yyyy',
                alignment: 'center',
            }, {
                dataField: "Shipping_Desc",
                caption: "คำอธิบาย",

            },
            {
                dataField: "Shipping_Id",
                caption: "แก้ไขข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                fixed: true,
                fixedPosition: 'right',
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a  onclick='Edit(" + options.key.Shipping_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white'  ><i class='fa fa-pencil'></i></a>")
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
                        .append("<a onclick='Delete(" + options.data.Shipping_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white'  ><i class='fa fa-trash'></i></a>")
                        .appendTo(container);
                }

            },]
    });

}

function Edit(id) {
    
    $("#ShippingID").val(id)
    $("#showAdd1").show();
    CallData15(id);
    
    $("#gridContainer").hide();
    $("#btnAdd").hide();
    $("#showAdd").show();
    $("#btnEditDEG").show();
    $("#btnAddDEG").hide();
    // load api
    var url = "../Shipping/GetShipping_HEADER/" + id;

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                //  LoadGrid(data.data);
                var a = data.data[0];
                //a.Shipping_DateStart = new Date(a.Shipping_DateStart_Input);
                //a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Input);
                if (a.Shipping_DateStart_Text !== null) {
                    a.Shipping_DateStart = new Date(a.Shipping_DateStart_Text);
                }
                if (a.Shipping_DateEnd_Text !== null) {
                    a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Text);
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
        $.post("../Shipping/DeleteShipping_HEADER",
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

function LoadForm(data) {

    $("#form-container").dxForm({
        colCount: 1,
        width: 500,
        formData: data,
        items: [{
            dataField: "Shipping_Name",
            label: {
                text: "รหัสรูปแบบ",
            },
            editorOptions: {
                disabled: false,
                Maxlenght: 100,
            },
            validationRules: [{
                type: "required",
                message: "โปรดระบุ รหัสรูปแบบ"
            }]
        },
        {
            dataField: "Shipping_Use",
            label: {
                text: "ใช้รูปแบบนี้"
            },
            editorOptions: {
                disabled: false,
                value: true,
            },
            editorType: "dxCheckBox",
        },
        {
            dataField: "Shipping_UseDate",

            label: {
                text: "ไม่กำหนดระยะเวลา",
            },
            editorType: "dxCheckBox",
            editorOptions: {
                disabled: false,
                value: false,
            }
        },
        {
            dataField: "Shipping_DateStart",
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
            dataField: "Shipping_DateEnd",
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
            dataField: "Shipping_Desc",
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