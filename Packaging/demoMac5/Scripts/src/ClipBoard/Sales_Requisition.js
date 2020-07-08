angular.module('AceApp').controller('SalesRequisitionController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $scope.selectedKeys = [];

        $("#popup").dxPopup({
            title: "โหลดกระดาษทด",
            visible: false,
            width: 600,
            height: 520,
        });

        $scope.loadClipBoard = function () {

            $("#popup").dxPopup({
                title: "โหลดกระดาษทด",
                visible: true,
                width: 520,
                height: 520,
            });

            $.get("../SalesRequestion/GetClipBoard")
                .done(function (res) {
                    if (res.success == true) {
                        $('#clipBoardGrid').dxDataGrid({
                            dataSource: res.data,
                            showBorders: true,
                            showRowLines: true,
                            rowAlternationEnabled: true,
                            paging: {
                                enabled: false
                            },
                            selection: {
                                mode: "multiple",
                                showCheckBoxesMode: "always"
                            },
                            keyExpr: "Clipboard_Id",
                            width: "auto",
                            width: 500,
                            height: 300,
                            searchPanel: {
                                visible: true,
                                width: 240,
                                placeholder: "ค้นหา..."
                            },
                            filterRow: {
                                visible: false,
                                applyFilter: "auto"
                            },

                            columns: [
                                {
                                    dataField: "Clipboard_Nos",
                                    caption: "เลขที่",
                                    width: 150
                                },
                                {
                                    dataField: "Clipboard_Date_Text",
                                    caption: "วันที่",

                                },
                                {
                                    dataField: "Clipboard_Quantity",
                                    caption: "จำนวน(ใบ)",

                                },
                                {
                                    dataField: "Clipboard_Delivery_Desc",
                                    caption: "สถานที่จัดส่ง",

                                },

                            ],
                            onSelectionChanged: function (e) {
                                $scope.selectedKeys = e.selectedRowKeys;
                            }
                        });
                    } else {
                        DevExpress.ui.notify(data.errMsg);
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });
                    }
                });

        }

        $scope.loadSaleRequisition = function () {
            $.get("../SalesRequestion/GetSalesRequestion/0")
                .done(function (res) {
                    if (res.success == true) {
                        $('#saleRequisitionGrid').dxDataGrid({
                            dataSource: res.data,
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
                                    dataField: "Sales_Id",
                                    caption: "ลำดับ",
                                    width: 100,
                                    alignment: 'center',
                                    allowFiltering: false,
                                    fixed: false,
                                    fixedPosition: 'left',
                                    cellTemplate: function (container, item) {
                                        var data = item.data,
                                            markup = "<p>" + (item.rowIndex + 1) + "</p>";
                                        container.append(markup);
                                    }
                                },
                                {
                                    dataField: "Sales_Status",
                                    caption: "อนุมัติ",
                                    alignment: 'center',
                                    cellTemplate: function (container, options) {

                                        if (options.key.Sales_Status == 0) {
                                            $("<div>")
                                                .append("รออนุมัติ")
                                                .appendTo(container);

                                        }
                                        else if (options.key.Sales_Status == 1) {
                                            $("<div>")
                                                .append("ไม่อนุมัติ")
                                                .appendTo(container);

                                        }
                                        else if (options.key.Sales_Status == 2) {
                                            $("<div>")
                                                .append("อนุมัติ")
                                                .appendTo(container);

                                        }
                                    }
                                },
                                {
                                    dataField: "Sales_Nos",
                                    caption: "เลขที่",
                                    alignment: 'center',
                                },
                                {
                                    dataField: "Sales_Date_Text",
                                    caption: "วันที่",
                                    alignment: 'center',

                                },
                                {
                                    dataField: "Sales_Quantity",
                                    caption: "จำนวน(ใบ)",

                                },
                                {
                                    dataField: "Sales_Delivery_Desc",
                                    caption: "สถานที่จัดส่ง",

                                },
                                {
                                    dataField: "PERid",
                                    caption: "ชื่อพนักงาน",
                                    alignment: 'center',
                                },
                                {
                                    dataField: "DEBid",
                                    caption: "ชื่อลูกค้า",
                                    alignment: 'center',
                                },
                                {
                                    caption: "อนุมัติเอกสาร",
                                    alignment: 'center',
                                    allowFiltering: false,
                                    width: 100,
                                    cellTemplate: function (container, item) {
                                        var data = item.data;
                                        $("<div />").dxButton({
                                            icon: 'fa fa-check',
                                            type: 'default',
                                            onClick: function (e) {
                                                DevExpress.ui.notify("แสดงการกระทำว่ากดอนุมัติเอกสาร");
                                            }
                                        }).appendTo(container);
                                    }
                                },
                                {
                                    caption: "แก้ไขข้อมูล",
                                    alignment: 'center',
                                    allowFiltering: false,
                                    width: 100,
                                    cellTemplate: function (container, item) {
                                        var data = item.data;
                                        $("<div />").dxButton({
                                            icon: 'fa fa-pencil',
                                            type: 'default',
                                            onClick: function (e) {
                                                parent.location = '#/ClipBoard/Sales_Requestion/' + data.Sales_Id;
                                            }
                                        }).appendTo(container);
                                    }
                                },
                                {
                                    caption: "ลบข้อมูล",
                                    alignment: 'center',
                                    allowFiltering: false,
                                    width: 100,
                                    cellTemplate: function (container, item) {
                                        var data = item.data;
                                        $("<div />").dxButton({
                                            icon: 'fa fa-trash',
                                            type: 'default',
                                            onClick: function (e) {
                                                //parent.location = '#/Loyalty/EditLoyaltyRedeemSetting/' + data.RedeemID;
                                            }
                                        }).appendTo(container);
                                    }

                                },
                            ],
                        });
                    }
                });
        }

        $scope.getClipBoard = function () {
            $("#popup").dxPopup({
                title: "โหลดกระดาษทด",
                visible: false,
                width: 520,
                height: 520,
            });

            var dataGrid = $("#clipBoardGrid").dxDataGrid("instance")
            $scope.selectedKeys = dataGrid.getSelectedRowKeys();

            $.post("../SalesRequestion/PostLoadClipBoard", selectedKeys)
                .done(function (data) {
                    if (data.success == true) {
                        $scope.loadSaleRequisition();
                        DevExpress.ui.notify("โหลดกระดาษทดแล้ว");
                    } else {

                    }
                })
        }
    }
]);