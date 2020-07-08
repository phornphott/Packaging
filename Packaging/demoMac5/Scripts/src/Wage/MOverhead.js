angular.module('AceApp').controller('MExpenseController', ['$scope', '$rootScope', '$stateParams', '$http',
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

            if ($("#form-container").dxForm("instance").validate().isValid) {
                $("#gridContainer").show();
                $("#btnAdd").show();
                $("#showAdd").hide();


                var obj = $("#form-container").dxForm("instance").option('formData');

                $.post("../Wage/Insert_MOverhead", obj
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

        }

        $scope.Update = function() {

            if ($("#form-container").dxForm("instance").validate().isValid) {

                $("#gridContainer").hide();
                $("#btnAdd").hide();
                $("#showAdd").hide();

                var url = "../Wage/Update_MOverhead";

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

        $scope.Refresh = function() {
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();
            CallData();

        }
    }
]);

function CallData() {
    var url = "../Wage/GetMOverhead/0";
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
        columns: [{
            dataField: "Overhead_Id",
            caption: "ลำดับ",
            width: 100,
            alignment: 'center',
            allowFiltering: false,
            fixed: false,
            fixedPosition: 'left',
            cellTemplate: function (container, options) {
                rownum = rownum + 1;
                console.log(rownum)
                $("<div>")
                    .append(rownum)
                    .appendTo(container);
            }
        }, {
            dataField: "Overhead_Code",
            caption: "รหัสโสหุ้ยการผลิต",
            width: 150,
        }, {
            dataField: "Overhead_NameT",
            caption: "รายละเอียด (ไทย)",

        }, {
            dataField: "Overhead_NameE",
            caption: "รายละเอียด (อังกฤษ)",

        },

        {
            dataField: "Overhead_Id",
            caption: "แก้ไขข้อมูล",
            alignment: 'center',
            allowFiltering: false,
            fixed: true,
            fixedPosition: 'right',
            width: 100,
            cellTemplate: function (container, options) {
                $("<div>")
                    .append("<a  onclick='Edit(" + options.key.Overhead_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                    .appendTo(container);
            }

        },
        {
            dataField: "Overhead_Id",
            caption: "ลบข้อมูล",
            alignment: 'center',
            allowFiltering: false,
            fixed: true,
            fixedPosition: 'right',
            width: 100,
            cellTemplate: function (container, options) {
                $("<div>")
                    .append("<a onclick='Delete(" + options.data.Overhead_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
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
    var url = "../Wage/GetMOverhead/" + id;

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
        $.post("../Wage/Delete_MOverhead",
            {
                Overhead_Id: id,
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
        showColonAfterLabel: true,
        showValidationSummary: true,
        items: [{
            dataField: "Overhead_Code",
            label: {
                text: "รหัสโสหุ้ยการผลิต",
            },
            editorOptions: {
                disabled: false,
                attr: { 'style': "text-transform: uppercase" },
                Maxleght: 50,
            },
            validationRules: [{
                type: "required",
                message: "โปรดระบุ รหัสโสหุ้ยการผลิต"
            }]
        },
        {
            dataField: "Overhead_NameT",
            label: {
                text: "รายละเอียดไทย"
            },
            editorOptions: {
                disabled: false
            },
            validationRules: [{
                type: "required",
                message: "โปรดระบุ รายละเอียดไทย"
            }]
        },
        {
            dataField: "Overhead_NameE",

            label: {
                text: "รายละเอียดอังกฤษ",
            },
            editorOptions: {
                disabled: false
            }
        },

        ]
    });

}