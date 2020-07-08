angular.module('AceApp').controller('CommissionReportController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        LoadGrid({});
        LoadForm();
        $scope.CallData = function() {
            
            $.get(url)
                .done(function (data) {

                    if (data.success == true) {
                        var b = data.data;

                        for (var a of b) {
                            a.Shipping_DateStart = new Date(a.Shipping_DateStart_Input);
                            a.Shipping_DateStart_Input = convertDate(a.Shipping_DateStart);
                            a.Shipping_DateEnd = new Date(a.Shipping_DateEnd_Input);
                            a.Shipping_DateEnd_Input = convertDate(a.Shipping_DateEnd);
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
                        caption: "No",
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
                        dataField: "",
                        caption: "วันที่ใบสำคัญ",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "",
                        caption: "เลขใบสำคัญ",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "",
                        caption: "รหัสลูกหนี้",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "",
                        caption: "รหัสสินค้า",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "",
                        caption: "ชื่อสินค้า",
                        width: 150,
                        alignment: 'center',
                    },

                    {
                        dataField: "",
                        caption: "ปริมาณขาย",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "",
                        caption: "หน่วยนับ",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "",
                        caption: "ราคาขาย/หน่วย",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "Shipping_DateStart_Input",
                        caption: "ยอดขาย",
                        width: 150,
                        alignment: "center",
                    }, {
                        dataField: "Shipping_DateEnd_Input",
                        caption: "ต้นทุนขาย",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "Shipping_DateEnd_Input",
                        caption: "ยอดต้นทุนขาย",
                        width: 150,
                        alignment: 'center',
                    },
                    {
                        dataField: "Shipping_Desc",
                        caption: "กำไรขาดทุน",

                    },
                    {
                        dataField: "Shipping_Desc",
                        caption: "ค่าคอมมิชชั่น",

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

            LoadForm(item)

        }
        
        function LoadForm() {

            $("#form-container").dxForm({
                colCount: 2,
                formData: {},
                items: [
                    {
                        dataField: "Shipping_DateStart",
                        label: {
                            text: "จากวันที่",
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
                            text: "ถึงวันที่",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"
                        }
                    },
                    {
                        dataField: "Shipping_Use",
                        label: {
                            text: "รหัสพนักงาน"
                        },
                        editorOptions: {
                            disabled: false
                        },

                    },
                    {
                        dataField: "รหัสลูกค้า",

                        label: {
                            text: "รหัสลูกค้า",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },


                    //{

                    //    editorType: "dxButton",
                    //    editorOptions: {
                    //        disabled: false,
                    //        type: "success",
                    //        text: "",
                    //        //     icon:"calculator",
                    //        onClick: function (e) {


                    //        }
                    //    }
                    //},
                ]
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

