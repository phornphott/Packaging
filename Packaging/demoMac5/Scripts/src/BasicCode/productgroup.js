angular.module('AceApp').controller('ProductGroupController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $scope.data = {};
        
        $("#showAdd").hide();
        
        $("#btnEditSTG").hide();

        $scope.CallData = function() {
            $("#btnEditSTG").hide();
            $("#btnAddSTG").hide();
            $("#showAdd").hide();
            $("#btnAdd").show();
            $("#grid-container").show();
            var url = "../BasicCode/GetSTG/0";

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

        $scope.LoadGrid = function (data) {
            var rownum = 0;
            $("#grid-container").dxDataGrid({
                dataSource: data,
                showBorders: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                paging: {
                    enabled: false
                },
                width: "auto",
                height: 600,
                searchPanel: {
                    visible: true,
                    width: 240,
                    placeholder: "ค้นหา..."
                },
                filterRow: {
                    visible: true,
                    applyFilter: "auto"
                },

                columns: [
                    {
                        dataField: "STGid",
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
                        dataField: "STGcode",
                        caption: "รหัสกลุ่มสินค้า",

                    },
                    {
                        dataField: "STGdescT",
                        caption: "รายละเอียดไทย",

                    },
                    {
                        dataField: "STGdescE",
                        caption: "รายละเอียดอังกฤษ",

                    },
                    {
                        dataField: "STGid",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        //fixed: true,
                        //   fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            $("<div />").dxButton({
                                icon: 'fa fa-pencil',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    $("#showAdd").show();
                                    $("#btnEditSTG").show();
                                    $("#btnAddSTG").hide();
                                    $("#btnAdd").hide();
                                    $("#grid-container").hide();

                                    var url = "../BasicCode/GetSTG/" + options.key.STGid;

                                    $.get(url)
                                        .done(function (data) {
                                            if (data.success == true) {
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
                        dataField: "STGid",
                        caption: "ลบข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        // fixed: true,
                        //  fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            $("<div />").dxButton({
                                icon: 'fa fa-trash',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    var r = confirm("ต้องการลบกลุ่มสินค้านี้หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../BasicCode/DeleteSTG",
                                            {
                                                STGid: options.data.STGid,

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

                    },
                ],
            });
        }

        $scope.LoadForm = function(data) {
            $("#form-container").dxForm({
                colCount: 1,
                width: 500,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,

                items: [{
                    dataField: "STGcode",
                    label: {
                        text: "รหัสกลุ่มสินค้า",
                    },
                    editorOptions: {
                        disabled: false,
                        inputAttr: { 'style': "text-transform: uppercase" },
                        maxLength: 10,
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ รหัสกลุ่มสินค้า"
                    }]
                },
                {
                    dataField: "STGdescT",
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
                    dataField: "STGdescE",

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
        
        $scope.InsertSTG = function() {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                $.post("../BasicCode/InsertSTG",
                    {
                        STGcode: obj.STGcode,
                        STGdescT: obj.STGdescT,
                        STGdescE: obj.STGdescE,
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
                            DevExpress.ui.notify(data.data);
                        }

                    });

            }

        }
        
        $scope.Refresh = function() {
            $("#btnEditSTG").hide();
            $("#btnAddSTG").show();
            $("#showAdd").hide();
            $("#btnAdd").show();
            $("#grid-container").show();

            $scope.LoadForm({});
        }
        
        $scope.SubmitEditProductGroup = function() {
            var obj = $("#form-container").dxForm("instance").option('formData');
            $.post("../BasicCode/UpdateSTG",
                {
                    STGid: obj.STGid,
                    STGcode: obj.STGcode,
                    STGdescT: obj.STGdescT,
                    STGdescE: obj.STGdescE,
                }
            )
                .done(function (data) {
                    if (data.success == true) {
                        DevExpress.ui.notify(data.data);
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });
                        //   Refresh();
                        $scope.CallData();

                    } else {
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });
                        DevExpress.ui.notify(data.data);
                    }

                });



        }
        
        $scope.Add = function() {
            $("#showAdd").show();
            $scope.LoadForm($scope.data)
            $("#btnAddSTG").show();
            $("#btnAdd").hide();
            $("#grid-container").hide();
        }
    }
]);

