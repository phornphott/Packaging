angular.module('AceApp').controller('ExpensesController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $("#gridContainer").hide();
        $("#btnAdd").hide();
        $("#showAdd").hide();
        $("#showAdd1").hide();
        

        $scope.CallData = function() {
            var url = "../Expenses/GetExpenses_HEADER/0";
            $("#gridContainer").show();
            $("#btnAdd").show();

            $.get(url)
                .done(function (data) {

                    if (data.success == true) {
                        var b = data.data;

                        for (var a of b) {
                            //a.Expenses_DateStart = new Date(a.Expenses_DateStart_Input);
                            //a.Expenses_DateStart_Input = convertDate(a.Expenses_DateStart);
                            //a.Expenses_DateEnd = new Date(a.Expenses_DateEnd_Input);
                            //a.Expenses_DateEnd_Input = convertDate(a.Expenses_DateEnd);
                            if (a.Expense_DateStart_Text !== null) {
                                a.Expense_DateStart = new Date(a.Expense_DateStart_Text);
                            }
                            else {
                                a.Expense_DateStart = new Date(a.Expense_DateStart);
                            }
                            if (a.Expense_DateEnd_Text !== null) {
                                a.Expense_DateEnd = new Date(a.Expense_DateEnd_Text);
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
                columns: [
                    {
                        dataField: "Expenses_Id",
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
                        dataField: "Expenses_Name",
                        caption: "รหัสรูปแบบ",
                        width: 150,
                        alignment: 'center',
                    },

                    {
                        dataField: "Expenses_Use",
                        caption: "ใช้รูปแบบนี้",
                        width: 120,
                        alignment: 'center',
                        cellTemplate: function (container, options) {
                            if (options.data.Expenses_Use == 1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.Expenses_Use == 0) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }
                    },
                    {
                        dataField: "Expenses_UseDate",
                        caption: "ไม่กำหนดระยะเวลา",
                        width: 120,
                        alignment: 'center',
                        cellTemplate: function (container, options) {
                            if (options.data.Expenses_UseDate == 1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.Expenses_UseDate == 0) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }
                    },
                    {
                        dataField: "Expenses_DateStart_Text",
                        caption: "ระยะเวลาเริ่มต้น",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: "center",
                    }, {
                        dataField: "Expenses_DateEnd_Text",
                        caption: "ระยะเวลาสิ้นสุด",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: "center",
                    }, {
                        dataField: "Expenses_Desc",
                        caption: "คำอธิบาย",

                    },
                    {
                        dataField: "Expenses_Id",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: true,
                        fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a  onclick='Edit(" + options.key.Expenses_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-pencil',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    $("#ExpenseID").val(options.key.Expenses_Id)
                                    $("#showAdd1").show();
                                    CallData1(options.key.Expenses_Id);


                                    $("#gridContainer").hide();
                                    $("#btnAdd").hide();
                                    $("#showAdd").show();
                                    $("#btnEditDEG").show();
                                    $("#btnAddDEG").hide();
                                    // load api
                                    var url = "../Expenses/GetExpenses_HEADER/" + options.key.Expenses_Id;

                                    $.get(url)
                                        .done(function (data) {

                                            if (data.success == true) {
                                                //  LoadGrid(data.data);
                                                var a = data.data[0];
                                                //a.Expenses_DateStart = new Date(a.Expenses_DateStart_Input);
                                                //a.Expenses_DateEnd = new Date(a.Expenses_DateEnd_Input);
                                                if (a.Expenses_DateStart_Text !== null) {
                                                    a.Expenses_DateStart = new Date(a.Expenses_DateStart_Text);
                                                }
                                                if (a.Expenses_DateEnd_Text !== null) {
                                                    a.Expenses_DateEnd = new Date(a.Expenses_DateEnd_Text);
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
                            //    .append("<a onclick='Delete(" + options.data.Expenses_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-trash',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    var r = confirm("ต้องการลบเม็ดพลาสติกนี้หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../Expenses/DeleteExpenses_HEADER",
                                            {
                                                Expenses_Id: options.data.Expenses_Id,
                                                Expenses_DeleteUser: 0
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
                width: 500,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [{
                    dataField: "Expenses_Name",
                    label: {
                        text: "รหัสรูปแบบ",
                    },
                    editorOptions: {
                        disabled: false,
                        Maxlenght: 100,
                    },
                    isRequired: true,
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ รหัสรูปแบบ"
                    }]
                },
                {
                    dataField: "Expenses_Use",
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
                    dataField: "Expenses_UseDate",

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
                    dataField: "Expenses_DateStart",
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
                    dataField: "Expenses_DateEnd",
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
                    dataField: "Expenses_Desc",
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
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").show();
            $("#btnEditDEG").hide();
            $("#btnAddDEG").show();
            var item = {}

            $scope.LoadForm(item)

        }

        $scope.Insert = function () {
            if ($("#form-container").dxForm("instance").validate().isValid) {

                $("#gridContainer").hide();
                $("#btnAdd").hide();
                $("#showAdd").hide();


                var obj = $("#form-container").dxForm("instance").option('formData');
                obj.Expenses_DateStart_Input = convertDate(obj.Expenses_DateStart);
                obj.Expenses_DateEnd_Input = convertDate(obj.Expenses_DateEnd);
                $.post("../Expenses/InsertExpenses_HEADER", obj
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

            var url = "../Expenses/UpdateExpenses_HEADER/";

            var obj = $("#form-container").dxForm("instance").option('formData');
            obj.Expenses_DateStart_Input = convertDate(obj.Expenses_DateStart);
            obj.Expenses_DateEnd_Input = convertDate(obj.Expenses_DateEnd);

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
            $("#gridContainer").hide();
            $("#btnAdd").hide();
            $("#showAdd").hide();
            $scope.CallData();

        }
    }
]);
