angular.module('AceApp').controller('CostHeaderController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $("#gridContainer").hide();
        $("#btnAdd").hide();
        $("#showAdd").hide();

        $("#showAdd1").hide();
        
        $scope.CallData = function() {
            var urlheader = "../Cost/GetCOST_HEADER/0";
            $("#gridContainer").show();
            $("#btnAdd").show();

            $.get(urlheader)
                .done(function (data) {

                    if (data.success == true) {
                        var b = data.data;

                        for (var a of b) {
                            //a.Cost_DateStart = new Date(a.Cost_DateStart_Input);
                            //a.Cost_DateStart_Input = convertDate(a.Cost_DateStart);
                            //a.Cost_DateEnd = new Date(a.Cost_DateEnd_Input);
                            //a.Cost_DateEnd_Input = convertDate(a.Cost_DateEnd);
                            if (a.Cost_DateStart_Text !== null) {
                                a.Cost_DateStart = new Date(a.Cost_DateStart_Text);
                            }
                            else {
                                a.Cost_DateStart = new Date(a.Cost_DateStart);
                            }
                            if (a.Cost_DateEnd_Text !== null) {
                                a.Cost_DateEnd = new Date(a.Cost_DateEnd_Text);
                            }
                        }
                        $scope.LoadGrid(b);

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
                    dataField: "Cost_Id",
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
                    dataField: "Cost_Name",
                    caption: "รหัสรูปแบบ",
                    width: 150,
                    alignment: "center",
                },

                {
                    dataField: "Cost_Use",
                    caption: "ใช้รูปแบบนี้",
                    width: 120,
                    alignment: 'center',
                    cellTemplate: function (container, options) {
                        if (options.data.Cost_Use == 1) {
                            $("<div>")
                                .append("<h5><span class='fa fa-check'></span></h5>")
                                .appendTo(container);

                        } else if (options.data.Cost_Use == 0) {
                            $("<div>")
                                .append("<h5><span class='fa fa-close'></span></h5>")
                                .appendTo(container);
                        }

                    }
                },
                {
                    dataField: "Cost_UseDate",
                    caption: "ไม่กำหนดระยะเวลา",
                    width: 120,
                    alignment: 'center',
                    cellTemplate: function (container, options) {
                        if (options.data.Cost_UseDate == 1) {
                            $("<div>")
                                .append("<h5><span class='fa fa-check'></span></h5>")
                                .appendTo(container);

                        } else if (options.data.Cost_UseDate == 0) {
                            $("<div>")
                                .append("<h5><span class='fa fa-close'></span></h5>")
                                .appendTo(container);
                        }

                    }
                },


                {
                    //dataField: "Cost_DateStart_Input",
                    dataField: "Cost_DateStart_Text",
                    caption: "ระยะเวลาเริ่มต้น",
                    width: 150,
                    dataType: "date",
                    format: 'dd/MM/yyyy',
                    alignment: "center",
                }, {
                    //dataField: "Cost_DateEnd_Input",
                    dataField: "Cost_DateEnd_Text",
                    caption: "ระยะเวลาสิ้นสุด",
                    width: 150,
                    dataType: "date",
                    format: 'dd/MM/yyyy',
                    alignment: "center",
                }, {
                    dataField: "Cost_Desc",
                    caption: "คำอธิบาย",


                },
                {
                    dataField: "Cost_Id",
                    caption: "แก้ไขข้อมูล",
                    alignment: 'center',
                    allowFiltering: false,
                    fixed: true,
                    fixedPosition: 'right',
                    width: 100,
                    cellTemplate: function (container, options) {
                        //$("<div>")
                        //    .append("<a  onclick='Edit(" + options.key.Cost_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary' style='color:white' ><i class='fa fa-pencil'></i></a>")
                        //    .appendTo(container);

                        $("<div />").dxButton({
                            icon: 'fa fa-pencil',
                            type: 'default',
                            disabled: false,
                            onClick: function (e) {
                                $("#costID").val(options.key.Cost_Id)
                                // alert($("#costID").val());
                                CallData1(options.key.Cost_Id);
                                CallData2(options.key.Cost_Id);
                                CallData3(options.key.Cost_Id);
                                CallData4(options.key.Cost_Id);
                                CallData5(options.key.Cost_Id);

                                $("#showAdd1").show();
                                $("#gridContainer").hide();
                                $("#btnAdd").hide();
                                $("#showAdd").show();
                                $("#btnEditDEG").show();
                                $("#btnAddDEG").hide();
                                // load api
                                var url = "../Cost/GetCOST_HEADER/" + options.key.Cost_Id;

                                $.get(url)
                                    .done(function (data) {

                                        if (data.success == true) {
                                            //  LoadGrid(data.data);
                                            var a = data.data[0];
                                            //a.Cost_DateStart = new Date(a.Cost_DateStart_Input);
                                            //a.Cost_DateEnd = new Date(a.Cost_DateEnd_Input);
                                            if (a.Cost_DateStart_Text !== null) {
                                                a.Cost_DateStart = new Date(a.Cost_DateStart_Text);
                                            }
                                            if (a.Cost_DateEnd_Text !== null) {
                                                a.Cost_DateEnd = new Date(a.Cost_DateEnd_Text);
                                            }
                                            $scope.LoadForm(a);
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
                    dataField: "Plastic_Id",
                    caption: "ลบข้อมูล",
                    alignment: 'center',
                    allowFiltering: false,
                    fixed: true,
                    fixedPosition: 'right',
                    width: 100,
                    cellTemplate: function (container, options) {
                        //$("<div>")
                        //    .append("<a onclick='Delete(" + options.data.Cost_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary' style='color:white' ><i class='fa fa-trash'></i></a>")
                        //    .appendTo(container);


                        $("<div />").dxButton({
                            icon: 'fa fa-trash',
                            type: 'default',
                            disabled: false,
                            onClick: function (e) {
                                var r = confirm("ต้องการลบรูปแบบต้นทุนนี้หรือไม่ !!!");
                                if (r == true) {
                                    $.post("../Cost/DeleteCOST_HEADER",
                                        {
                                            Cost_Id: options.data.Cost_Id,
                                            Cost_DeleteUser: 0
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
                width: 500,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [{
                    dataField: "Cost_Name",
                    label: {
                        text: "รหัสรูปแบบ",
                    },

                    editorOptions: {
                        disabled: false,
                        Maxleght: 100
                    },
                    isRequired: true,
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ รหัสรูปแบบ"
                    }]
                },
                {
                    dataField: "Cost_Use",
                    label: {
                        text: "ใช้รูปแบบนี้"
                    },
                    editorType: "dxCheckBox",
                    editorOptions: {
                        disabled: false,
                        value: true,
                    },

                },
                {
                    dataField: "Cost_UseDate",

                    label: {
                        text: "ไม่กำหนดระยะเวลา",
                    },

                    editorType: "dxCheckBox",
                    editorOptions: {
                        value: false,
                        disabled: false
                    }
                },
                {
                    dataField: "Cost_DateStart",
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
                    dataField: "Cost_DateEnd",
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
                    dataField: "Cost_Desc",
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
        
        $scope.Add = function() {
            $("#btnAdd").hide();
            $("#showAdd").show();
            $("#btnEditDEG").hide();
            $("#btnAddDEG").show();
            $("#gridContainer").hide();
            //$("#form-container").show();

            //$("#form-container").dxForm({
            //    colCount: 1,
            //    width: 500,
            //    formData: data,
            //    showColonAfterLabel: true,
            //    showValidationSummary: true,
            //    items: [{
            //        dataField: "Cost_Name",
            //        label: {
            //            text: "รหัสรูปแบบ",
            //        },

            //        editorOptions: {
            //            disabled: false,
            //            Maxleght: 100
            //        },
            //        validationRules: [{
            //            type: "required",
            //            message: "โปรดระบุ รหัสรูปแบบ"
            //        }]
            //    },
            //    {
            //        dataField: "Cost_Use",
            //        label: {
            //            text: "ใช้รูปแบบนี้"
            //        },
            //        editorType: "dxCheckBox",
            //        editorOptions: {
            //            disabled: false,
            //            value: true,
            //        },

            //    },
            //    {
            //        dataField: "Cost_UseDate",

            //        label: {
            //            text: "ไม่กำหนดระยะเวลา",
            //        },

            //        editorType: "dxCheckBox",
            //        editorOptions: {
            //            value: false,
            //            disabled: false
            //        }
            //    },
            //    {
            //        dataField: "Cost_DateStart",
            //        label: {
            //            text: "ระยะเวลาเริ่มต้น",
            //        },
            //        editorType: "dxDateBox",
            //        editorOptions: {
            //            disabled: false,

            //            displayFormat: "dd/MM/yyyy"
            //        }
            //    },
            //    {
            //        dataField: "Cost_DateEnd",
            //        label: {
            //            text: "ระยะเวลาสิ้นสุด",
            //        },
            //        editorType: "dxDateBox",
            //        editorOptions: {
            //            disabled: false,
            //            displayFormat: "dd/MM/yyyy"
            //        }
            //    },

            //    {
            //        dataField: "Cost_Desc",
            //        editorType: "dxTextArea",
            //        label: {
            //            text: "คำอธิบาย",
            //        },
            //        editorOptions: {
            //            disabled: false
            //        }
            //    },


            //    ]
            //});

            var item = {
                Cost_Use: true,
                Cost_UseDate: false
            }

            $scope.LoadForm(item)

        }
        
        $scope.Insert = function () {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                $("#gridContainer").hide();
                $("#btnAdd").hide();
                $("#showAdd").hide();


                var obj = $("#form-container").dxForm("instance").option('formData');
                obj.Cost_DateStart_Input = convertDate(obj.Cost_DateStart);
                obj.Cost_DateEnd_Input = convertDate(obj.Cost_DateEnd);

                $.post("../Cost/InsertCOST_HEADER", obj
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
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();

            var url = "../Cost/UpdateCOST_HEADER/";

            var obj = $("#form-container").dxForm("instance").option('formData');
            obj.Cost_DateStart_Input = convertDate(obj.Cost_DateStart);
            obj.Cost_DateEnd_Input = convertDate(obj.Cost_DateEnd);

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
                        DevExpress.ui.notify(data.data);
                    }

                });


        }

        $scope.Refresh = function() {
            $scope.CallData();
            $("#gridContainer").show();
            $("#btnAdd").show();
            $("#showAdd").hide();

            $("#showAdd1").hide();
        }
    }
]);

