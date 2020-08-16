angular.module('AceApp').controller('CustomerGroupController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $scope.data = {};
        $("#showAdd").hide();
        $("#btnEditDEG").hide();

        $scope.CallData = function() {
            $("#btnEditDEG").hide();
            $("#btnAddDEG").hide();
            $("#showAdd").hide();
            $("#btnAdd").show();
            $("#grid-container").show();

            var url = "../BasicCode/GetDEG/0";

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
            $("#grid-container").dxDataGrid({
                dataSource: data,
                showBorders: true,
                showRowLines: true,
                rowAlternationEnabled: true,

                paging: {
                    enabled: false
                },

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
                        dataField: "DEGid",
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
                        dataField: "DEGcode",
                        caption: "รหัสกลุ่มลูกค้า",

                    },
                    {
                        dataField: "DEGdescT",
                        caption: "รายละเอียดไทย",

                    },
                    {
                        dataField: "DEGdescE",
                        caption: "รายละเอียดอังกฤษ",

                    },
                    {
                        dataField: "DEGid",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a  onclick='ShowForm(" + options.key.DEGid + ")' title='แก้ไขข้อมูล' class='btn btn-primary btn-circle btn-sm' ><i class='fa fa-pencil'></i></a>")
                            //    .appendTo(container);
                            $("<div />").dxButton({
                                icon: 'fa fa-pencil',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    $("#showAdd").show();
                                    $("#btnEditDEG").show();
                                    $("#btnAddDEG").hide();
                                    $("#btnAdd").hide();
                                    $("#grid-container").hide();

                                    var url = "../BasicCode/GetDEG/" + options.key.DEGid;

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
                        dataField: "DEGid",
                        caption: "ลบข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a onclick='DeleteDEG(" + options.data.DEGid + ")' title='ลบข้อมูล' class='btn btn-primary btn-circle btn-sm' ><i class='fa fa-trash'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-trash',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    var r = confirm("ต้องการลบกลุ่มลูกค้านี้หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../BasicCode/DeleteDEG",
                                            {
                                                DEGid: options.data.DEGid,

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
                    dataField: "DEGcode",
                    label: {
                        text: "รหัสกลุ่มลูกค้า",
                    },
                    editorOptions: {
                        disabled: false,
                        inputAttr: { 'style': "text-transform: uppercase" },
                        maxLength: 10,
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ รหัสกลุ่มลูกค้า"
                    }]
                },
                {
                    dataField: "DEGdescT",
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
                    dataField: "DEGdescE",

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
        
        $scope.InsertDEG = function() {

            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                $.post("../BasicCode/InsertDEG",
                    {
                        DEGcode: obj.DEGcode,
                        DEGdescT: obj.DEGdescT,
                        DEGdescE: obj.DEGdescE,
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
            $("#btnEditDEG").hide();
            $("#btnAddDEG").show();
            $("#showAdd").hide();
            $("#btnAdd").show();
            $("#grid-container").show();

            $scope.LoadForm({});
        }

        $scope.SubmitEditProductGroup = function() {

            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');

                $.post("../BasicCode/UpdateDEG",
                    {
                        DEGid: obj.DEGid,
                        DEGcode: obj.DEGcode,
                        DEGdescT: obj.DEGdescT,
                        DEGdescE: obj.DEGdescE,
                    }
                )
                    .done(function (data) {

                        if (data.success == true) {
                            DevExpress.ui.notify(data.data);
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            $scope.CallData();
                            //  Refresh();
                        } else {
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            DevExpress.ui.notify(data.data);
                        }

                    });
            }


        }
        
        $scope.Add = function() {
            $("#showAdd").show();
            $scope.LoadForm($scope.data)
            $("#btnAddDEG").show();
            $("#btnAdd").hide();
            $("#grid-container").hide();
        }
    }
]);