angular.module('AceApp').controller('DepartmentController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $("#gridContainer").hide();
        $("#btnAdd").hide();
        $("#showAdd").hide();

        var url = "../Wage/GetMDepartment/0";

        $scope.CallData = function() {

            $("#gridContainer").show();
            $("#btnAdd").show();

            $.get(url)
                .done(function (data) {

                    if (data.success == true) {
                        $scope.LoadGrid(data.data);


                    } else {
                        DevExpress.ui.notify(data.errMsg);
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });

                    }

                });
        }

        $scope.LoadGrid = function(data) {

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
                    dataField: "Department_Id",
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
                    dataField: "Department_Code",
                    caption: "รหัสแผนก",
                    width: 150,
                }, {
                    dataField: "Department_NameT",
                    caption: "รายละเอียด (ไทย)",

                }, {
                    dataField: "Department_NameE",
                    caption: "รายละเอียด (อังกฤษ)",

                },

                {
                    dataField: "Department_Id",
                    caption: "แก้ไขข้อมูล",
                    alignment: 'center',
                    allowFiltering: false,
                    fixed: true,
                    fixedPosition: 'right',
                    width: 100,
                    cellTemplate: function (container, options) {
                        //$("<div>")
                        //    .append("<a  onclick='Edit(" + options.key.Department_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                        //    .appendTo(container);
                        $("<div />").dxButton({
                            icon: 'fa fa-pencil',
                            type: 'default',
                            disabled: false,
                            onClick: function (e) {
                                $("#gridContainer").hide();
                                $("#btnAdd").hide();
                                $("#showAdd").show();
                                $("#btnEditDEG").show();
                                $("#btnAddDEG").hide();
                                // load api
                                var url = "../Wage/GetMDepartment/" + options.key.Department_Id;

                                $.get(url)
                                    .done(function (data) {

                                        if (data.success == true) {
                                            //  LoadGrid(data.data);

                                            $scope.LoadForm(data.data[0]);
                                        } else {
                                            DevExpress.ui.notify(data.data);
                                            $("#loadIndicator").dxLoadIndicator({
                                                visible: false
                                            });

                                        }

                                    });
                            }
                        }).appendTo(container);
                    }

                },
                {
                    dataField: "Department_Id",
                    caption: "ลบข้อมูล",
                    alignment: 'center',
                    allowFiltering: false,
                    fixed: true,
                    fixedPosition: 'right',
                    width: 100,
                    cellTemplate: function (container, options) {
                        //$("<div>")
                        //    .append("<a onclick='Delete(" + options.data.Department_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
                        //    .appendTo(container);

                        $("<div />").dxButton({
                            icon: 'fa fa-trash',
                            type: 'default',
                            disabled: false,
                            onClick: function (e) {
                                var r = confirm("ต้องการลบหรือไม่ !!!");
                                if (r == true) {
                                    $.post("../Wage/Delete_MDepartment",
                                        {
                                            Department_Id: options.data.Department_Id
                                        }
                                    )
                                        .done(function (data) {

                                            if (data.success == true) {
                                                DevExpress.ui.notify(data.data);
                                                $("#loadIndicator").dxLoadIndicator({
                                                    visible: false
                                                });
                                                $scope.CallData();
                                            } else {
                                                $("#loadIndicator").dxLoadIndicator({
                                                    visible: false
                                                });
                                                DevExpress.ui.notify(data.errMsg);
                                            }

                                        });
                                }
                            }
                        }).appendTo(container);
                    }

                },]
            });

        }
        
        $scope.LoadForm = function(data) {

            $("#form-container").dxForm({
                colCount: 1,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [

                    {
                        dataField: "Department_Code",
                        label: {
                            text: "รหัสแผนก",
                        },
                        editorOptions: {
                            disabled: false,
                            attr: { 'style': "text-transform: uppercase" },
                            Maxleght: 15,
                        },
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ รหัสแผนก"
                        }]
                    },
                    {
                        dataField: "Department_NameT",
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
                        dataField: "Department_NameE",

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
        
        $scope.Add = function() {


            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").show();
            $("#btnEditDEG").hide();
            $("#btnAddDEG").show();
            var item = {}

            $scope.LoadForm(item)

        }
        
        $scope.Insert = function() {


            if ($("#form-container").dxForm("instance").validate().isValid) {
                $("#gridContainer").hide();
                $("#btnAdd").hide();
                $("#showAdd").hide();
                var obj = $("#form-container").dxForm("instance").option('formData');

                $.post("../Wage/Insert_MDepartment", obj
                )
                    .done(function (data) {

                        if (data.success == true) {
                            DevExpress.ui.notify(data.data);
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            $scope.CallData();
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

                var url = "../Wage/Update_MDepartment";

                var obj = $("#form-container").dxForm("instance").option('formData');


                $.post(url, obj)
                    .done(function (data) {

                        if (data.success == true) {
                            DevExpress.ui.notify(data.data);
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            $scope.CallData();
                        } else {
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            DevExpress.ui.notify(data.data, "error");
                            $scope.CallData();
                        }

                    });

            }

        }

        $scope.Refresh = function() {
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();
            $scope.CallData();

        }
    }
]);

