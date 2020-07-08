angular.module('AceApp').controller('UserIndexReportController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $("#gridContainer").hide();
        $("#btnAdd").hide();
        $("#showAdd").hide();
        
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

            $.post("../User/InsertUSR", obj
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

            var url = "../User/UpdateUSR";

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

        $scope.Refresh = function() {
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();
            CallData();
        }
    }
]);

function CallData() {
    var url = "../User/GetUSR/0";
    $("#gridContainer").show();
    $("#btnAdd").show();

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                LoadGrid(data.data);


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
                dataField: "USR_Id",
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
                dataField: "USR_Code",
                caption: "User log-in",
                width: 150,
            }, {
                dataField: "USR_NameT",
                caption: "ชื่อไทย",

            }, {
                dataField: "USR_NameE",
                caption: "ชื่ออังกฤษ",

            },


            {
                dataField: "USR_Id",
                caption: "แก้ไขข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                fixed: true,
                fixedPosition: 'right',
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a  onclick='Edit(" + options.key.USR_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                        .appendTo(container);
                }

            },
            {
                dataField: "USR_Id",
                caption: "ลบข้อมูล",
                alignment: 'center',
                allowFiltering: false,
                fixed: true,
                fixedPosition: 'right',
                width: 100,
                cellTemplate: function (container, options) {
                    $("<div>")
                        .append("<a onclick='Delete(" + options.data.USR_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
                        .appendTo(container);
                }

            },]
    });

}

function Edit(id) {




    $("#gridContainer").hide();
    $("#btnAdd").hide();
    $("#showAdd").show();
    $("#btnEditDEG").show();
    $("#btnAddDEG").hide();
    // load api
    var url = "../User/GetUSR/" + id;

    $.get(url)
        .done(function (data) {

            if (data.success == true) {
                //  LoadGrid(data.data);

                LoadForm(data.data[0]);
            } else {
                DevExpress.ui.notify(data.data);
                $("#loadIndicator").dxLoadIndicator({
                    visible: false
                });

            }

        });

}

function Delete(id) {

    var r = confirm("ต้องการลบหรือไม่ !!!");
    if (r == true) {
        $.post("../User/Delete_USR",
            {
                Plastic_Id: id,
                Plastic_DeleteUser: 0
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
    data.USR_Pwd_Old = data.USR_Pwd_Old;
    $("#form-container").dxForm({
        colCount: 1,
        formData: data,
        width: 500,
        showColonAfterLabel: true,
        showValidationSummary: true,
        items: [{
            dataField: "USR_Code",
            label: {
                text: "User log-in",
            },
            editorOptions: {
                disabled: false
            },
            validationRules: [{
                type: "required",
                message: "โปรดระบุ User log-in"
            }]
        },
        {
            dataField: "USR_NameT",
            label: {
                text: "ชื่อไทย"
            },
            editorOptions: {
                disabled: false
            },
            validationRules: [{
                type: "required",
                message: "โปรดระบุ ชื่อไทย"
            }]
        },
        {
            dataField: "USR_NameE",

            label: {
                text: "ชื่ออังกฤษ",
            },
            editorOptions: {
                disabled: false
            }
        },
        {
            dataField: "USR_Pwd",

            label: {
                text: "รหัสผ่าน",
            },
            editorOptions: {
                mode: "password",
                disabled: false
            }
            ,
            validationRules: [{
                type: "required",
                message: "โปรดระบุ รหัสผ่าน"
            }]
        },

        {
            dataField: "USR_Level",

            label: {
                text: "ระดับ",
            },
            editorOptions: {
                disabled: false
            },
            validationRules: [{
                type: "pattern",
                pattern: "^[a-zA-Z]+$",
                message: "The name should not contain digits"
            }]

        },

        {
            dataField: "USR_Email",

            label: {
                text: "อีเมล์",
            },
            editorOptions: {
                disabled: false
            }
        },

        ]
    });

}