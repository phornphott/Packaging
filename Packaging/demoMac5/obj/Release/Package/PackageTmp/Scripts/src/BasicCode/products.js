angular.module('AceApp').controller('ProductController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        var productgroup = (function () {
            var json = null;
            $.ajax({
                'async': false,
                'global': false,
                'url': '../BasicCode/GetSTG/0',
                'dataType': "json",
                'success': function (data) {
                    json = data;
                }
            });
            return json;
        })();

        $scope.CallData = function() {
            $("#btnAdd").show();
            $("#btnAll").show();
            $("#btnSubmitAdd").hide();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").hide();
            $("#grid-container").show();
            $("#form-container").hide();
            var url = "../BasicCode/GetSTK/0"
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

        $scope.CallAllData = function() {
            $("#btnAdd").show();
            $("#btnAll").show();
            $("#btnSubmitAdd").hide();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").hide();
            $("#grid-container").show();
            $("#form-container").hide();
            var url = "api/Product/GetAllProduct"
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

        var productType = [{
            id: 1,
            name: "Item"
        },
        {
            id: 2,
            name: "Serial"
        },
        {
            id: 3,
            name: "Service"
        },
        {
            id: 4,
            name: "Lot_ID"
        },
        {
            id: 5,
            name: "Lot_NC"
        },]
        
        $scope.LoadForm = function(data) {

            $("#form-container").dxForm({
                colCount: 2,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [
                    {
                        dataField: "STKcode",
                        label: {
                            text: "รหัสสินค้า",
                        },
                        editorOptions: {
                            disabled: false,
                            attr: { 'style': "text-transform: uppercase" },
                            Maxleght: 25,
                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุรหัสสินค้า"
                        }],

                    },
                    {
                        dataField: "STKgroup",
                        label: {
                            text: "กลุ่มสินค้า",
                        },
                        //placeholder: "โปรดเลือกกลุ่มสินค้า",
                        //editorType: "dxSelectBox",
                        //editorOptions: {
                        //    items: productgroup.data,
                        //    valueExpr: 'STGid',
                        //    displayExpr: 'STGdescT',
                        //    disabled: false

                        //},
                        //isRequired: true,
                        //validationRules: [{
                        //    type: "required",
                        //    message: "โปรดเลือกกลุ่มสินค้า"
                        //}],
                    },
                    {
                        dataField: "STKcode2",
                        label: {
                            text: "รหัสสินค้ารอง",
                        },
                        //editorOptions: {
                        //    disabled: false
                        //},
                        //isRequired: false,
                        //validationRules: [{
                        //    type: "required",
                        //    message: "โปรดระบุรหัสสินค้ารอง"
                        //}],
                    },
                    {
                        dataField: "STKdescE1",

                        label: {
                            text: "คำอธิบาย (อังกฤษ) 1",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "STKdescT1",

                        label: {
                            text: "ชื่อคำอธิบาย (ไทย) 1",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุชื่อคำอธิบาย (ไทย) 1"
                        }],

                    },
                    {
                        dataField: "STKdescE2",

                        label: {
                            text: "คำอธิบาย (อังกฤษ) 2",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "STKdescT2",

                        label: {
                            text: "ชื่อคำอธิบาย (ไทย) 2",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "STKdescE3",

                        label: {
                            text: "คำอธิบาย (อังกฤษ) 3",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "STKdescT3",

                        label: {
                            text: "ชื่อคำอธิบาย (ไทย) 3",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },




                    {
                        dataField: "STKmax",
                        label: {
                            text: " ปริมาณสูงสุด",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        //isRequired: true,
                        //validationRules: [{
                        //    type: "required",
                        //    message: "โปรดระบุปริมาณสูงสุด"
                        //}],
                    },
                    {
                        dataField: "STKmin",
                        label: {
                            text: "ปริมาณต่ำสุด",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        //isRequired: true,
                        //validationRules: [{
                        //    type: "required",
                        //    message: "โปรดระบุปริมาณต่ำสุด"
                        //}],
                    },

                    {
                        dataField: "STKunit1",
                        label: {
                            text: "หน่วยนับหลัก",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุหน่วยนับหลัก"
                        }],
                    },
                    {
                        dataField: "STKunit2",
                        label: {
                            text: "หน่วยนับรอง",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        //isRequired: true,
                        //validationRules: [{
                        //    type: "required",
                        //    message: "โปรดระบุหน่วยนับรอง"
                        //}],
                    },



                    {
                        dataField: "STKsnsv",
                        label: {
                            text: "ประเภทสินค้า",
                        },
                        editorType: "dxSelectBox",
                        editorOptions: {
                            items: productType,
                            valueExpr: 'id',
                            displayExpr: 'name',
                            disabled: false

                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุประเภทสินค้า"
                        }],

                    },
                    {
                        dataField: "STKuname1",
                        label: {
                            text: "ชื่อหน่วยนับ 1",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        isRequired: true,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุชื่อหน่วยนับ 1"
                        }],

                    },
                    {
                        dataField: "STKexpire",
                        label: {
                            text: "เป็นประเภทหมดอายุหรือไม่",
                        },
                        editorOptions: {
                            disabled: false,
                            value: false,
                            text: "ใช่"
                        },
                        editorType: "dxCheckBox",
                    },


                    {
                        dataField: "STKhide",
                        editorType: "dxCheckBox",
                        label: {
                            text: "ซ่อนรหัสนี้",
                        },
                        editorOptions: {
                            disabled: false,
                            value: false,
                            text: "ใช่"
                        },
                    },


                    {
                        dataField: "STKvat",
                        label: {
                            text: "อัตราภาษี",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },


                    {
                        dataField: "STKuse2",
                        editorType: "dxCheckBox",
                        label: {
                            text: "ใช้หน่วยนับขนานหรือไม่",

                        },
                        editorOptions: {
                            disabled: false,
                            value: false,
                            text: "ใช่"
                        },
                    },

                    {
                        dataField: "STKu2name",
                        label: {
                            text: "ชื่อหน่วยนับขนาน",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },


                    {
                        dataField: "STKmemo",
                        label: {
                            text: " คำอธิบายเพิ่มเติม",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },

                    //{
                    //    dataField: "STKeditLK",
                    //    label: {
                    //        text: "ล๊อกการบันทึกชั่วคราว",
                    //    },
                    //    editorOptions: {
                    //        disabled: false,

                    //    },
                    //},
                    {
                        dataField: "STKrefWE",
                        label: {
                            text: "อ้างอิงเอกสารอื่น",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },

                    {
                        dataField: "STKbarC1",
                        label: {
                            text: "รหัสแถบ บาร์โค้ด 1",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },
                    {
                        dataField: "STKstatus",
                        editorType: "dxCheckBox",
                        label: {
                            text: "สถานะ",
                        },
                        editorOptions: {
                            disabled: false,
                            value: false,
                            text: "ใช่งาน"
                        },
                    },
                    {
                        dataField: "STKbarC2",
                        label: {
                            text: "รหัสแถบ บาร์โค้ด 2",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },
                    {
                        dataField: "STKsto",
                        label: {
                            text: "กำหนดสโตร์พร้อมใช้",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },

                    {
                        dataField: "STKbarC3",
                        label: {
                            text: "รหัสแถบ บาร์โค้ด 3",
                        },
                        editorOptions: {
                            disabled: false,

                        },
                    },

                    //{
                    //    dataField: "STKsortNT",
                    //    label: {
                    //        text: "การจัดเรียงชื่อ (ไทย)",
                    //    },
                    //    editorOptions: {
                    //        disabled: false,

                    //    },
                    //},

                    //{
                    //    dataField: "STKsortNE",
                    //    label: {
                    //        text: "การจัดเรียงชื่อ (อังกฤษ)",
                    //    },
                    //    editorOptions: {
                    //        disabled: false,

                    //    },
                    //},
                ]
            });
        }
        
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
                        dataField: "STKid",
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
                        dataField: "STKcode",
                        caption: "รหัสสินค้า",
                        width: 150
                    },
                    {
                        dataField: "STKgroup",
                        caption: "กลุ่มสินค้า",
                        width: 150
                    },
                    {
                        dataField: "STKcode2",
                        caption: "รหัสสินค้ารอง",
                        width: 150,
                    },
                    {
                        dataField: "STKdescT1",
                        caption: "ชื่อคำอธิบาย (ไทย) 1",
                        width: 150
                    },

                    {
                        dataField: "STKdescT2",
                        caption: "ชื่อคำอธิบาย (ไทย) 2",
                        width: 150
                    },
                    {
                        dataField: "STKdescT3",
                        caption: "ชื่อคำอธิบาย (ไทย) 3",
                        width: 150
                    },

                    {
                        dataField: "STKdescE1",
                        caption: "คำอธิบาย (อังกฤษ) 1",
                        width: 150
                    },

                    {
                        dataField: "STKdescE2",
                        caption: "คำอธิบาย (อังกฤษ) 2",
                        width: 150
                    },

                    {
                        dataField: "STKdescT3",
                        caption: "ชื่อคำอธิบาย (ไทย) 3",
                        width: 150
                    },


                    {
                        dataField: "STKdescE3",
                        caption: "คำอธิบาย (อังกฤษ) 3",
                        width: 150
                    },
                    {
                        dataField: "STKmax",
                        caption: "ปริมาณสูงสุด",
                        width: 150,
                    },
                    {
                        dataField: "STKmin",
                        caption: "ปริมาณต่ำสุด",
                        width: 150,
                    },
                    {
                        dataField: "STKunit1",
                        caption: "หน่วยนับหลัก",
                        width: 150,
                    },
                    {
                        dataField: "STKunit2",
                        caption: "หน่วยนับรอง",
                        width: 150,
                    },
                    {
                        dataField: "STKlock",
                        caption: "ล็อกรหัสนี้",
                        width: 80,
                        cellTemplate: function (container, options) {
                            if (options.data.STKlock == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.STKlock == 0) {
                                $("<div>")
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }

                    },

                    {
                        dataField: "STKid",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: true,
                        fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a  onclick='Edit(" + options.key.STKid + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                            //    .appendTo(container);

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

                                    // load api
                                    var url = "../BasicCode/GetSTK/" + options.key.STKid;

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
                        dataField: "STKid",
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
                                    var r = confirm("ต้องการลบสินค้านี้หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../BasicCode/DeleteSTK",
                                            {
                                                STKid: options.data.STKid,

                                            }
                                        )
                                            .done(function (data) {

                                                if (data.success == true) {
                                                    DevExpress.ui.notify(data.data);
                                                    $("#loadIndicator").dxLoadIndicator({
                                                        visible: false
                                                    });
                                                    //CallData();
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
        
        $scope.SubmitAdd = function() {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                obj.STKexpire = obj.STKexpire == true ? -1 : 0;
                obj.STKhide = obj.STKhide == true ? -1 : 0;
                obj.STKuse2 = obj.STKuse2 == true ? -1 : 0;
                obj.STKstatus = obj.STKstatus == true ? -1 : 0;

                $.post("../BasicCode/InsertSTK", obj)
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
                        }

                    });

            }
        }

        $scope.SubmitUpdate = function() {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                obj.STKexpire = obj.STKexpire == true ? 0 : -1;
                obj.STKhide = obj.STKhide == true ? 0 : -1;
                obj.STKuse2 = obj.STKuse2 == true ? 0 : -1;
                obj.STKstatus = obj.STKstatus == true ? 0 : -1;
                $.post("../BasicCode/UpdateSTK", obj)
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
                        }

                    });

            }
        }

        $scope.Add = function() {
            var data = {};
            $("#btnAdd").hide();
            $("#btnAll").hide();
            $("#btnSubmitAdd").show();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").show();
            $("#grid-container").hide();
            $("#form-container").show();

            $scope.LoadForm(data)

        }
    }
]);



