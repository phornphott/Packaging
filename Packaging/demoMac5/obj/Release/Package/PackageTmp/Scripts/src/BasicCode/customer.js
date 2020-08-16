angular.module('AceApp').controller('CustomerController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {

        $scope.CusGroup = "";

        //$scope.CallData = function() {
        //    $("#btnAdd").show();
        //    $("#btnAll").show();
        //    $("#btnSubmitAdd").hide();
        //    $("#btnSubmitEdit").hide();
        //    $("#btnCancel").hide();
        //    $("#grid-container").show();
        //    $("#form-container").hide();
        //    var url = "../BasicCode/GetDEB/0"
        //    $.get(url)
        //        .done(function (data) {

        //            if (data.success == true) {


        //                $scope.LoadGrid(data.data);


        //            } else {
        //                DevExpress.ui.notify(data.errMsg);
        //                $("#loadIndicator").dxLoadIndicator({
        //                    visible: false
        //                });

        //            }

        //        });

        //}

        $scope.CallAllData = function () {
            $("#btnAdd").show();
            $("#btnAll").show();
            $("#btnSubmitAdd").hide();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").hide();
            $("#grid-container").show();
            $("#form-container").hide();
            var url = "api/Product/GetAllCustomer"
            $.get(url)
                .done(function (data) {
                    if (data.StatusCode == 1) {
                        $scope.LoadGrid(data.Results);
                    } else {
                        DevExpress.ui.notify(data.errMsg);
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });

                    }

                });

        }

        $scope.listDEG = function () {
            var json = null;
            $.ajax({
                'async': false,
                'global': false,
                'url': '../BasicCode/GetDEG/0',
                'dataType': "json",
                'success': function (data) {
                    json = data;
                }
            });
            return json;
        };

        $scope.LoadGrid = function(dataJob) {
            var rownum = 0;
            $("#grid-container").dxDataGrid({
                dataSource: dataJob,
                showBorders: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                paging: {
                    enabled: false
                },
                paging: {
                    pageSize: 200
                },
                pager: {
                    //showPageSizeSelector: true,
                    //allowedPageSizes: [100, 200, 500],
                    showInfo: true
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
                        dataField: "DEBid",
                        caption: "ลำดับ",
                        width: 100,
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: false,
                        visible:false,
                        fixedPosition: 'left',
                        summaryType: "count",
                        cellTemplate: function (container, options) {
                            rownum = rownum + 1;
                            $("<div>")
                                .append(rownum)
                                .appendTo(container);
                        }
                    },
                    {
                        dataField: "DEBrow",
                        caption: "ลำดับ",
                        width: 100,
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: false,
                        fixedPosition: 'left',
                    },
                    {
                        dataField: "DEBcode",
                        caption: "รหัสลูกหนี้",
                        width: 150,
                        alignment: 'center'
                    },
                    {
                        dataField: "DEBgroup",
                        caption: "รหัสกลุ่มลูกหนี้",
                        width: 150,
                        alignment: 'center'
                    },
                    {
                        dataField: "DEBnameT",
                        caption: "ชื่อลูกหนี้ (ไทย)",
                        width: 150,
                        alignment: 'center'
                    },
                    {
                        dataField: "DEBnameT",
                        caption: "ชื่อลูกหนี้ (อังกฤษ)",
                        width: 150
                    },
                    {
                        dataField: "DEBtel",
                        caption: "เบอร์โทร",
                        width: 150
                    },
                    {
                        dataField: "DEBhide",
                        caption: "ซ่อนรหัสนี้",
                        width: 80,
                        alignment: 'center',
                        cellTemplate: function (container, options) {
                            if (options.data.DEBhide == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.DEBhide == 0) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }
                    }, {
                        dataField: "DEBlock",
                        caption: "ล็อกรหัสนี้",
                        width: 80,
                        alignment: 'center',
                        cellTemplate: function (container, options) {
                            if (options.data.DEBlock == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.DEBlock == 0) {
                                $("<div>")
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'  ></span></h5>")
                                    .appendTo(container);
                            }
                        }
                    },
                    {
                        dataField: "DEBmemo",
                        caption: "รายละเอียดเพิ่มเติม",
                        width: 150,
                    },
                    {
                        dataField: "DEBeditLK_Text",
                        caption: "ล็อกการบันทึกชั่วคราว",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'
                    },
                    {
                        dataField: "DEBrefWE",
                        caption: "อ้างอิง",
                        width: 150,
                    },
                    {
                        dataField: "DEBeditDT_Text",
                        caption: "วันเวลาที่บันทึก",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'
                    },
                    {
                        dataField: "DEBid",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: true,
                        fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            $("<div />").dxButton({
                                icon: 'fa fa-pencil',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    $("#btnAdd").hide();
                                    $("#btnAll").hide();
                                    $("#btnSubmitAdd").hide();
                                    $("#btnSubmitEdit").show();
                                    $("#btnCancel").show();
                                    $("#grid-container").hide();
                                    $("#form-container").show();
                                    var url = "../BasicCode/GetDEB/" + options.key.DEBid;

                                    $.get(url)
                                        .done(function (data) {
                                            
                                            if (data.success == true) {
                                                //  LoadGrid(data.data);
                                                data.data[0].DEBpaytype = "ไม่กำหนดเฉพาะวัน";
                                                data.data[0].DEBbgrtype = "ไม่กำหนดเฉพาะวัน";
                                                var DEBdata = data.data[0];
                                                var url = "api/Product/GetAllCustomerGroup"
                                                $.get(url)
                                                    .done(function (data) {
                                                        if (data.StatusCode == 1) {
                                                            $scope.CusGroup = data.Results;
                                                            console.log($scope.CusGroup);
                                                            $scope.LoadEdit(DEBdata);
                                                            
                                                        }

                                                    });
                                                
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
                        dataField: "DEBid",
                        caption: "ลบข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: true,
                        fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a onclick='Delete(" + options.data.STKid + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-trash',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    var r = confirm("ต้องการลบลูกค้านี้ใช่หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../BasicCode/DeleteDEB",
                                            {
                                                DEBid: options.data.DEBid,

                                            }
                                        )
                                            .done(function (data) {

                                                if (data.success == true) {
                                                    DevExpress.ui.notify(data.data);
                                                    $("#loadIndicator").dxLoadIndicator({
                                                        visible: false
                                                    });
                                                    //CallData();
                                                    //$scope.CallData();
                                                    $scope.CallAllData();
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
                summary: {
                    totalItems: [{
                        column: "DEBid",
                        summaryType: "count",
                        displayFormat: "{0} รายการ",
                    },
                    ]
                }
            });
        }

        $scope.LoadEdit = function(data) {

            $("#form-container").dxForm({
                colCount: 2,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [
                    {
                        dataField: "DEBcode",
                        label: {
                            text: "รหัสลูกหนี้",
                        },
                        editorOptions: {
                            disabled: false,
                            inputAttr: { 'style': "text-transform: uppercase" },
                            maxLength: 15,
                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ รหัสลูกหนี้"
                        }]
                    },
                    {
                        dataField: "DEBgroup",
                        label: {
                            text: "รหัสกลุ่มลูกหนี้",
                        },
                        editorType: "dxSelectBox",
                        editorOptions: {
                            items: $scope.CusGroup,
                            valueExpr: 'DEGcode',
                            displayExpr: 'DEGcode',
                            disabled: false,
                        }
                    }, {
                        dataField: "DEBnameT",
                        label: {
                            text: "ชื่อลูกหนี้ (ไทย)",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ รายละเอียดไทย"
                        }]
                    },
                    {
                        dataField: "DEBnameE",

                        label: {
                            text: "ชื่อลูกหนี้ (อังกฤษ)",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "DEBcontactT",
                        label: {
                            text: " ชื่อผู้ติดต่อ (ไทย)",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "DEBcontactE",
                        label: {
                            text: "ชื่อผู้ติดต่อ (อังกฤษ)",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },

                    {
                        dataField: "DEBadd1AT",
                        label: {
                            text: "ที่อยู่บริษัท (ไทย) บรรทัดที่1",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBadd2AT",
                        label: {
                            text: "ที่อยู่บริษัท (ไทย) บรรทัดที่2",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBadd3AT",
                        label: {
                            text: "ที่อยู่บริษัท (ไทย) บรรทัดที่3",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBadd1AE",
                        label: {
                            text: "ที่อยู่บริษัท (อังกฤษ) บรรทัดที่1",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBadd2AE",
                        label: {
                            text: "ที่อยู่บริษัท (อังกฤษ) บรรทัดที่2",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBadd3AE",
                        label: {
                            text: "ที่อยู่บริษัท (อังกฤษ) บรรทัดที่3",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBtel",
                        label: {
                            text: "เบอร์โทรศัพท์",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBtaxnos",
                        label: {
                            text: "เลขผู้เสียภาษี",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBzone",
                        label: {
                            text: "รหัสเขต",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBgrade",
                        label: {
                            text: "เกรด",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBlimit",
                        label: {
                            text: "วงเงิน",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBtaxclass",
                        label: {
                            text: "อัตราภาษี",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    //{
                    //    dataField: "DEBgoodsDef",
                    //    label: {
                    //        text: "จำนวนสินค้าที่ผูกกับลูกหนี้",
                    //    },
                    //    editorOptions: {
                    //        disabled: false,
                    //    }
                    //},
                    {
                        dataField: "DEBcreditTerm",
                        label: {
                            text: "เครดิต - วัน",
                        },
                        editorOptions: {
                            disabled: false,
                        }
                    },
                    {
                        dataField: "DEBpaytype",

                        label: {
                            text: "ประเภทการจ่ายเงิน",
                            value: " ไม่กำหนดเฉพาะวัน"
                        },
                        editorOptions: {
                            disabled: true
                        }
                    },
                    {
                        dataField: "DEBbgrtype",
                        label: {
                            text: "ประเภทการรับวางบิล",
                            value: " ไม่กำหนดเฉพาะวัน"
                        },
                        editorOptions: {
                            disabled: true
                        }

                    },
                    //{
                    //    dataField: "DEBbgrday",
                    //    label: {
                    //        text: "วันรับวางบิล",
                    //    },
                    //    // editorType: "dxDateBox",
                    //    editorOptions: {
                    //        disabled: false,
                    //        //   displayFormat: "dd/MM/yyyy"
                    //    }


                    //},
                    //{
                    //    dataField: "DEBdate",
                    //    label: {
                    //        text: "วันที่ติดต่อครั้งแรก",
                    //    },
                    //    editorType: "dxDateBox",
                    //    editorOptions: {
                    //        disabled: false,
                    //        displayFormat: "dd/MM/yyyy"
                    //    }

                    //},
                    {
                        dataField: "DEBfax",
                        label: {
                            text: "เบอร์แฟกซ์",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "DEBemail",

                        label: {
                            text: "อีเมล์ ",
                        },

                    },
                    {
                        dataField: "DEBtarget",
                        label: {
                            text: "เป้ายอดขาย",
                        },
                        editorOptions: {
                            disabled: false,
                            width: 120
                        }
                    },

                    {
                        dataField: "DEBmemo",
                        label: {
                            text: "รายละเอียดเพิ่มเติม",
                        },
                        editorType: "dxTextArea",
                        editorOptions: {
                            width: 120,
                            disabled: false
                        }

                    },
                    {
                        dataField: "DEBac",
                        label: {
                            text: "รหัสบัญชี",
                        },
                        editorOptions: {
                            disabled: false,
                            width: 120
                        },

                    },

                    {
                        dataField: "DEBoName",
                        label: {
                            text: "ชื่อเรียกอื่นๆ",
                        },
                        editorOptions: {
                            width: 120,
                            disabled: false
                        }
                    },
                    {
                        dataField: "DEBprice",
                        label: {
                            text: "ราคาสินค้า A-Z",
                        },
                        editorOptions: {
                            width: 120,
                            disabled: false
                        }
                    },
                    //{
                    //    label: {
                    //        text: "จำนวนวันที่วางบิลหลังส่งสินค้า",
                    //    },
                    //    editorOptions: {
                    //        width: 120,
                    //        disabled: false
                    //    }
                    //},
                    {
                        dataField: "DEBsalesP",
                        label: {
                            text: "รหัสพนักงานขาย",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "DEBhide",
                        editorType: "dxCheckBox",
                        label: {
                            text: "ซ่อนรหัสนี้",
                        },
                        editorOptions: {
                            disabled: false,
                            value: false
                        },
                    },

                    {
                        dataField: "DEBlock",
                        editorType: "dxCheckBox",
                        label: {
                            text: "ล๊อกรหัสนี้",
                        },
                        editorOptions: {
                            disabled: false,
                            value: false
                        },

                    },
                ]
            });
        }
        
        $scope.Add = function() {
            var data = {};
            var url = "api/Product/GetAllCustomerGroup"
            $.get(url)
                .done(function (data) {
                    if (data.StatusCode == 1) {
                        $scope.CusGroup = data.Results;
                        console.log($scope.CusGroup);
                        $("#btnAdd").hide();
                        $("#btnAll").hide();
                        $("#btnSubmitAdd").show();
                        $("#btnSubmitEdit").hide();
                        $("#btnCancel").show();
                        $("#grid-container").hide();
                        $("#form-container").show();
                        $scope.LoadEdit({
                            DEBpaytype: "ไม่กำหนดเฉพาะวัน",
                            DEBbgrtype: "ไม่กำหนดเฉพาะวัน"
                        });
                    } 

                });

            


        }

        $scope.SubmitAdd = function () {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                //obj.DEBbgrday_Input = convertDate(obj.DEBbgrday);
                //obj.DEBdate_Input = convertDate(obj.DEBdate);



                $.post("../BasicCode/InsertDEB",
                    obj
                )
                    .done(function (data) {

                        if (data.success == true) {
                            DevExpress.ui.notify(data.data);
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            $scope.CallAllData();
                        } else {
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            DevExpress.ui.notify(data.data);
                        }

                    });
            }

        }

        $scope.SubmitUpdate = function () {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                obj.DEBbgrday_Input = convertDate(obj.DEBbgrday);
                obj.DEBdate_Input = convertDate(obj.DEBdate);

                $.post("../BasicCode/UpdateDEB",
                    obj
                )
                    .done(function (data) {

                        if (data.success == true) {
                            DevExpress.ui.notify(data.data);
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            $scope.CallAllData();
                        } else {
                            $("#loadIndicator").dxLoadIndicator({
                                visible: false
                            });
                            DevExpress.ui.notify(data.data);
                        }

                    });
            }
        }
    }
]);