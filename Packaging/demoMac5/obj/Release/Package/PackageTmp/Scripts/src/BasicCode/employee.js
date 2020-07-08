angular.module('AceApp').controller('EmployeeController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $scope.CallData = function() {
            $("#btnAdd").show();
            $("#btnSubmitAdd").hide();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").hide();
            $("#grid-container").show();
            $("#form-container").hide();
            var url = "../BasicCode/GetPER/0"
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
                        dataField: "PERid",
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
                        dataField: "PERcode",
                        caption: "รหัสพนักงาน",
                        width: 150,
                        alignment: 'center'
                    },
                    {
                        dataField: "PERdep",
                        caption: "รหัสแผนก",
                        width: 150,
                        alignment: 'center'
                    },
                    {
                        dataField: "PERtaxnos",
                        caption: "เลขผู้เสียภาษี",
                        width: 150,
                        alignment: 'center'
                    },
                    {
                        dataField: "PERnameT",
                        caption: "ชื่อพนักงาน (ไทย)",
                        width: 150
                    },
                    {
                        dataField: "PERnameE",
                        caption: "ชื่อพนักงาน (อังกฤษ)",
                        width: 150
                    },
                    {
                        dataField: "PERbdate_Text",
                        caption: "วันเกิด",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'
                    },

                    {
                        dataField: "PERworkS_Text",
                        caption: "วันที่เริ่มทำงาน",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'
                    },
                    {
                        dataField: "PERworkF_Text",
                        caption: "วันที่เลิกการทำงาน",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'
                    },

                    {
                        dataField: "PERadd1",
                        caption: "ที่อยู่ บรรทัด 1",
                        width: 150,
                    },
                    {
                        dataField: "PERadd2",
                        caption: "ที่อยู่ บรรทัด 2",
                        width: 150,
                    },
                    {
                        dataField: "PERadd3",
                        caption: "ที่อยู่ บรรทัด 3",
                        width: 150,
                    },
                    {
                        dataField: "PERtel",
                        caption: "เบอร์โทรศัพท์",
                        width: 150,
                    },
                    {
                        dataField: "PERpositn",
                        caption: "ตำแหน่ง",
                        width: 150,
                    },
                    {
                        dataField: "PERstatus",
                        caption: "สถานะ โสด/สมรส/ม่าย",
                        width: 150,

                    },
                    {
                        dataField: "PERnchild",
                        caption: "จำนวนบุตร",
                        width: 150,
                    },

                    {
                        dataField: "PERcisstudy",
                        caption: "จำนวนบุตรที่เรียน",
                        width: 150,
                    },
                    {
                        dataField: "PERnotstudy",
                        caption: "จำนวนบุตรที่ไม่เรียน",
                        width: 150,
                    },

                    {
                        dataField: "PERsalary",
                        caption: "เงินเดือน",
                        width: 150,
                    },


                    {
                        dataField: "PERhide",
                        caption: "ซ่อนรหัสนี้",
                        width: 80,
                        alignment: 'center',
                        cellTemplate: function (container, options) {
                            if (options.data.PERhide == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.PERhide == 0) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }
                    },

                    {
                        dataField: "PERlock",
                        caption: "ล็อกรหัสนี้",
                        width: 80,
                        alignment: 'center',
                        cellTemplate: function (container, options) {
                            if (options.data.PERlock == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.PERlock == 0) {
                                $("<div>")
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'  ></span></h5>")
                                    .appendTo(container);
                            }

                        }

                    },
                    {
                        dataField: "PERmemo",
                        caption: "รายละเอียดเพิ่มเติม",
                        width: 150,

                    },
                    {
                        dataField: "PEReditLK_Text",
                        caption: "ล็อกการบันทึกชั่วคราว",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'
                    },
                    {
                        dataField: "PERrefWE",
                        caption: "อ้างอิง",
                        width: 150,

                    },
                    {
                        dataField: "PEReditDT_Text",
                        caption: "วันเวลาที่บันทึก",
                        width: 150,
                        dataType: "date",
                        format: 'dd/MM/yyyy',
                        alignment: 'center'

                    },
                    {


                        dataField: "PERid",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: true,
                        fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a  onclick='ShowForm(" + options.key.PERid + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-pencil',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    $("#btnAdd").hide();
                                    $("#btnSubmitAdd").hide();
                                    $("#btnSubmitEdit").show();
                                    $("#btnCancel").show();
                                    $("#grid-container").hide();
                                    $("#form-container").show();
                                    var url = "../BasicCode/GetPER/" + options.key.PERid;

                                    $.get(url)
                                        .done(function (data) {

                                            if (data.success == true) {
                                                //  LoadGrid(data.data);

                                                $scope.LoadEdit(data.data[0]);
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
                        dataField: "PERid",
                        caption: "ลบข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: true,
                        fixedPosition: 'right',
                        width: 100,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a onclick='Delete(" + options.data.PERid + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-trash',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    var r = confirm("ต้องการรหัสพนักงานนี้หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../BasicCode/DeletePER",
                                            {
                                                PERid: options.data.PERid,

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
                                                    DevExpress.ui.notify(data.errMsg, "error");
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
        
        $scope.LoadEdit = function(data) {
            if (data.PERworkF_Text !== null) {
                data.PERworkF = new Date(data.PERworkF_Text);
            }
            if (data.PERbdate_Text !== null) {
                data.PERbdate = new Date(data.PERbdate_Text);
            }
            if (data.PERworkS_Text !== null) {
                data.PERworkS = new Date(data.PERworkS_Text);
            }
            //data.PERworkF_Text = convertDate(data.PERworkF);
            //data.PERbdate_Text = convertDate(data.PERbdate);
            //data.PERworkS_Text = convertDate(data.PERworkS);
            //data.PEReditLK_Text = convertDate(data.PEReditLK);

            $("#form-container").dxForm({
                colCount: 2,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [

                    {
                        dataField: "PERcode",
                        label: {
                            text: "รหัสพนักงาน",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ รหัสพนักงาน"
                        }]
                    },
                    {
                        dataField: "PERdep",
                        label: {
                            text: "รหัสแผนก",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ รหัสแผนก"
                        }]
                    },
                    {
                        dataField: "PERtaxnos",
                        label: {
                            text: "เลขผู้เสียภาษี",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERnameT",

                        label: {
                            text: "ชื่อพนักงาน (ไทย)",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERnameE",
                        label: {
                            text: " ชื่อพนักงาน (อังกฤษ)",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERbdate",
                        label: {
                            text: "วันเกิด",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"
                        }
                    },

                    {
                        dataField: "PERworkS",
                        label: {
                            text: "วันที่เริ่มทำงาน",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"
                        }
                    },
                    {
                        dataField: "PERworkF",
                        label: {
                            text: "วันที่เลิกการทำงาน",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"
                        }
                    },

                    {
                        dataField: "PERadd1",

                        label: {
                            text: "ที่อยู่ บรรทัด 1",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERadd2",
                        label: {
                            text: "ที่อยู่ บรรทัด 2",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERadd3",
                        label: {
                            text: "ที่อยู่ บรรทัด 3",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERtel",
                        label: {
                            text: "เบอร์โทรศัพท์",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERpositn",
                        label: {
                            text: "ตำแหน่ง",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERstatus",

                        label: {
                            text: "สถานะ ",
                        },
                        editorType: "dxSelectBox",
                        editorOptions: {
                            items: [{
                                "ID": 1,
                                "NAME": "โสด"
                            }, {
                                "ID": 2,
                                "NAME": "สมรส"
                            }, {
                                "ID": 3,
                                "NAME": "ม่าย"
                            }],
                            valueExpr: 'ID',
                            displayExpr: 'NAME',
                            disabled: false

                        },
                    },
                    {
                        dataField: "PERnchild",
                        label: {
                            text: "จำนวนบุตร",
                        },
                        editorOptions: {
                            disabled: false,
                            width: 120
                        }
                    },

                    {
                        dataField: "PERcisstudy",
                        label: {
                            text: "จำนวนบุตรที่เรียน",
                        },
                        editorOptions: {
                            width: 120,
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERnotstudy",
                        label: {
                            text: "จำนวนบุตรที่ไม่เรียน",
                        },
                        editorOptions: {
                            disabled: false,
                            width: 120
                        },

                    },

                    {
                        dataField: "PERsalary",
                        label: {
                            text: "เงินเดือน",
                        },
                        editorOptions: {
                            width: 120,
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERhide",
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
                        dataField: "PERlock",

                        label: {
                            text: "ล๊อกรหัสนี้",
                        },
                        editorType: "dxCheckBox",
                        editorOptions: {
                            disabled: false,
                            value: false
                        },

                    },
                    {
                        dataField: "PERmemo",
                        label: {
                            text: "รายละเอียดเพิ่มเติม",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    //{
                    //    dataField: "PEReditLK",
                    //    label: {
                    //        text: "ล็อกการบันทึกชั่วคราว",
                    //    },
                    //    editorType: "dxDateBox",
                    //    editorOptions: {
                    //        disabled: false,
                    //        displayFormat: "dd/MM/yyyy"
                    //    }
                    //},
                    {
                        dataField: "PERrefWE",
                        label: {
                            text: "อ้างอิง",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                ]
            });
        }
        
        $scope.Add = function() {
            var data = {};
            $("#btnAdd").hide();
            $("#btnSubmitAdd").show();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").show();
            $("#grid-container").hide();
            $("#form-container").show();

            $("#form-container").dxForm({
                colCount: 2,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [

                    {
                        dataField: "PERcode",
                        label: {
                            text: "รหัสพนักงาน",
                        },
                        editorOptions: {
                            disabled: false
                        }
                        ,
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ รหัสพนักงาน"
                        }]
                    },
                    {
                        dataField: "PERdep",
                        label: {
                            text: "รหัสแผนก",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERtaxnos",
                        label: {
                            text: "เลขผู้เสียภาษี",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERnameT",

                        label: {
                            text: "ชื่อพนักงาน (ไทย)",
                        },
                        editorOptions: {
                            disabled: false
                        },
                        validationRules: [{
                            type: "required",
                            message: "โปรดระบุ ชื่อพนักงาน (ไทย)"
                        }]
                    },
                    {
                        dataField: "PERnameE",
                        label: {
                            text: " ชื่อพนักงาน (อังกฤษ)",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERbdate_Text",

                        label: {
                            text: "วันเกิด",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"

                        }
                    },

                    {
                        dataField: "PERworkS_Text",
                        label: {
                            text: "วันที่เริ่มทำงาน",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"
                        }
                    },
                    {
                        dataField: "PERworkF_Text",
                        label: {
                            text: "วันที่เลิกการทำงาน",
                        },
                        editorType: "dxDateBox",
                        editorOptions: {
                            disabled: false,
                            displayFormat: "dd/MM/yyyy"
                        }
                    },

                    {
                        dataField: "PERadd1",

                        label: {
                            text: "ที่อยู่ บรรทัด 1",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERadd2",
                        label: {
                            text: "ที่อยู่ บรรทัด 2",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERadd3",
                        label: {
                            text: "ที่อยู่ บรรทัด 3",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERtel",
                        label: {
                            text: "เบอร์โทรศัพท์",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERpositn",
                        label: {
                            text: "ตำแหน่ง",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERstatus",

                        label: {
                            text: "สถานะ ",
                        },
                        editorOptions: {
                            items: [{
                                "ID": 1,
                                "NAME": "โสด"
                            }, {
                                "ID": 2,
                                "NAME": "สมรส"
                            }, {
                                "ID": 3,
                                "NAME": "ม่าย"
                            }],

                            disabled: false,
                            valueExpr: 'ID',
                            displayExpr: 'NAME'
                        },

                    },
                    {
                        dataField: "PERnchild",
                        label: {
                            text: "จำนวนบุตร",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },

                    {
                        dataField: "PERcisstudy",
                        label: {
                            text: "จำนวนบุตรที่เรียน",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    {
                        dataField: "PERnotstudy",
                        label: {
                            text: "จำนวนบุตรที่ไม่เรียน",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },

                    {
                        dataField: "PERsalary",
                        label: {
                            text: "เงินเดือน",
                        },
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        dataField: "PERhide",
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
                        dataField: "PERlock",
                        editorType: "dxCheckBox",
                        label: {
                            text: "ล๊อกรหัสนี้",
                        },
                        editorOptions: {
                            disabled: false,
                            value: false
                        },

                    },
                    {
                        dataField: "PERmemo",
                        label: {
                            text: "รายละเอียดเพิ่มเติม",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                    //{
                    //    dataField: "PEReditLK_Text",
                    //    label: {
                    //        text: "ล็อกการบันทึกชั่วคราว",
                    //    },
                    //    editorType: "dxDateBox",
                    //    editorOptions: {
                    //        disabled: false,
                    //        displayFormat: "dd/MM/yyyy"
                    //    }

                    //},
                    {
                        dataField: "PERrefWE",
                        label: {
                            text: "อ้างอิง",
                        },
                        editorOptions: {
                            disabled: false
                        }

                    },
                ]
            });



        }

        $scope.SubmitAdd = function() {

            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                $.post("../BasicCode/InsertPER",
                    {

                        PERcode: obj.PERcode,
                        PERdep: obj.PERdep,
                        PERtaxnos: obj.PERtaxnos,
                        PERnameT: obj.PERnameT,
                        PERnameE: obj.PERnameE,
                        PERbdate_Input: convertDate(obj.PERbdate_Text),
                        PERworkS_Input: convertDate(obj.PERworkS_Text),
                        PERworkF_Input: convertDate(obj.PERworkF_Text),
                        PERadd1: obj.PERadd1,
                        PERadd2: obj.PERadd2,
                        PERadd3: obj.PERadd3,
                        PERtel: obj.PERtel,
                        PERpositn: obj.PERpositn,
                        PERstatus: obj.PERstatus,
                        PERnchild: obj.PERnchild,
                        PERcisstudy: obj.PERcisstudy,
                        PERnotstudy: obj.PERnotstudy,
                        PERsalary: obj.PERsalary,
                        PERhide: obj.PERhide,
                        PERlock: obj.PERlock,
                        PERmemo: obj.PERmemo,
                        //     PEReditLK_Input: convertDate(obj.PEReditLK_Text),
                        PERrefWE: obj.PERrefWE,
                        PEReditDT_Input: convertDate(obj.PEReditDT_Text),


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

        $scope.SubmitUpdate = function() {


            var obj = $("#form-container").dxForm("instance").option('formData');
            $.post("../BasicCode/UpdatePER",
                {

                    PERid: obj.PERid,
                    PERcode: obj.PERcode,
                    PERdep: obj.PERdep,
                    PERtaxnos: obj.PERtaxnos,
                    PERnameT: obj.PERnameT,
                    PERnameE: obj.PERnameE,
                    PERbdate_Input: convertDate(obj.PERbdate_Text),
                    PERworkS_Input: convertDate(obj.PERworkS_Text),
                    PERworkF_Input: convertDate(obj.PERworkF_Text),
                    PERadd1: obj.PERadd1,
                    PERadd2: obj.PERadd2,
                    PERadd3: obj.PERadd3,
                    PERtel: obj.PERtel,
                    PERpositn: obj.PERpositn,
                    PERstatus: obj.PERstatus,
                    PERnchild: obj.PERnchild,
                    PERcisstudy: obj.PERcisstudy,
                    PERnotstudy: obj.PERnotstudy,
                    PERsalary: obj.PERsalary,
                    PERhide: obj.PERhide,
                    PERlock: obj.PERlock,
                    PERmemo: obj.PERmemo,
                    //   PEReditLK_Input: convertDate(obj.PEReditLK_Text),
                    PERrefWE: obj.PERrefWE,
                    PEReditDT_Input: convertDate(obj.PEReditDT_Text),

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
]);

