angular.module('AceApp').controller('JobController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $("#btnAdd").show();
        $("#btnSubmitAdd").hide();
        $("#btnSubmitEdit").hide();
        $("#btnCancel").hide();

        $scope.CallData = function () {
            $("#btnAdd").show();
            $("#btnSubmitAdd").hide();
            $("#btnSubmitEdit").hide();
            $("#btnCancel").hide();
            $("#grid-container").show();
            $("#form-container").hide();
            var url = "../BasicCode/GetJOB/0"
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

        //var dataJob = [{
        //    "JOBid": 1,
        //    "JOBcode": "JC",
        //    "JOBgroup": "DD",
        //    "JOBdescT": "งานเย็บ",
        //    "JOBdescE": "",
        //    "JOBhide": 1,
        //    "JOBlock": 1,
        //    "JOBrefWE": "",
        //    "JOBsortNT": "",
        //    "JOBsortNE": "",
        //    "JOBeditDT": "",
        //}];

        //function moveEditColumnToLeft(dataGrid) {
        //    dataGrid.columnOption("command:edit", {
        //        visibleIndex: -1
        //    });
        //}
        
        $scope.LoadGrid = function(dataJob) {
            var rownum = 0;
            $("#grid-container").dxDataGrid({
                dataSource: dataJob,
                showBorders: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                allowColumnResizing: true,
                columnAutoWidth: true,
                height: 600,
                paging: {
                    enabled: false
                },
                paging: {
                    pageSize: 20
                },
                pager: {
                    //showPageSizeSelector: true,
                    //allowedPageSizes: [5, 10, 20],
                    showInfo: true
                },

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
                        dataField: "JOBid",
                        caption: "ลำดับ",
                        width: 100,
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: false,
                        visible: false,
                        fixedPosition: 'left',
                        cellTemplate: function (container, options) {
                            rownum = rownum + 1;
                            $("<div>")
                                .append(rownum)
                                .appendTo(container);
                        }
                    },
                    {
                        dataField: "JOBrow",
                        caption: "ลำดับ",
                        width: 100,
                        alignment: 'center',
                        allowFiltering: false,
                        fixed: false,
                        fixedPosition: 'left',                        
                    },
                    {
                        dataField: "JOBcode",
                        caption: "รหัสงาน",

                    },
                    {
                        dataField: "JOBgroup",
                        caption: "กลุ่มงาน",

                    },
                    {
                        dataField: "JOBdescT",
                        caption: "รายละเอียดไทย",

                    },

                    {
                        dataField: "JOBdescE",
                        caption: "รายละเอียดอังกฤษ",

                    },
                    {
                        dataField: "JOBhide",
                        caption: "ซ่อนรหัสนี้",
                        alignment: "center",
                        cellTemplate: function (container, options) {
                            if (options.data.JOBhide == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.JOBhide == 0) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }
                    },

                    {
                        dataField: "JOBlock",
                        caption: "ล็อกรหัสนี้",
                        alignment: "center",
                        cellTemplate: function (container, options) {
                            if (options.data.JOBlock == -1) {
                                $("<div>")
                                    .append("<h5><span class='fa fa-check'></span></h5>")
                                    .appendTo(container);

                            } else if (options.data.JOBlock == 0) {
                                $("<div>")
                                $("<div>")
                                    .append("<h5><span class='fa fa-close'></span></h5>")
                                    .appendTo(container);
                            }

                        }

                    },
                    //{
                    //    dataField: "JOBrefWE",
                    //    caption: "อ้างอิง-บันทึกช่วยจำ",


                    //},
                    //{
                    //    dataField: "JOBsortNT",
                    //    caption: "จัดเรียงชื่อไทย",


                    //},
                    //{
                    //    dataField: "JOBsortNE",
                    //    caption: "จัดเรียงชื่ออังกฤษ",
                    //    width: 150,

                    //},
                    {
                        dataField: "JOBid",
                        caption: "แก้ไขข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a  onclick='ShowForm(" + options.key.JOBid + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
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
                                    var url = "../BasicCode/GetJOB/" + options.key.JOBid;

                                    $.get(url)
                                        .done(function (data) {

                                            if (data.success == true) {
                                                //  LoadGrid(data.data);

                                                $scope.LoadEditJob(data.data[0]);
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
                        dataField: "JOBid",
                        caption: "ลบข้อมูล",
                        alignment: 'center',
                        allowFiltering: false,
                        cellTemplate: function (container, options) {
                            //$("<div>")
                            //    .append("<a onclick='Delete(" + options.data.JOBid + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white'><i class='fa fa-trash'></i></a>")
                            //    .appendTo(container);

                            $("<div />").dxButton({
                                icon: 'fa fa-trash',
                                type: 'default',
                                disabled: false,
                                onClick: function (e) {
                                    var r = confirm("ต้องการรหัสงานนี้หรือไม่ !!!");
                                    if (r == true) {
                                        $.post("../BasicCode/DeleteJob",
                                            {
                                                JOBid: options.data.JOBid,

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
        
        $scope.LoadEditJob = function(data) {

            $("#form-container").dxForm({
                colCount: 2,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [{
                    dataField: "JOBcode",
                    label: {
                        text: "รหัสงาน",
                    },
                    editorOptions: {
                        disabled: false,
                        inputAttr: { 'style': "text-transform: uppercase" },
                        maxLength: 15,
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ รหัสงาน"
                    }]
                },
                {
                    dataField: "JOBgroup",
                    label: {
                        text: "กลุ่มงาน"
                    },
                    editorOptions: {
                        disabled: false
                    },
                    //validationRules: [{
                    //    type: "required",
                    //    message: "โปรดระบุ กลุ่มงาน"
                    //}]
                },
                {
                    dataField: "JOBdescT",

                    label: {
                        text: "รายละเอียดไทย",
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
                    dataField: "JOBdescE",

                    label: {
                        text: "รายละเอียดอังกฤษ",
                    },
                    editorOptions: {
                        disabled: false
                    }
                },
                {
                    dataField: "JOBhide",
                    editorType: "dxCheckBox",
                    label: {
                        text: "ซ่อนรหัสนี้",
                    },
                    editorOptions: {
                        disabled: false
                    }
                },
                {
                    dataField: "JOBlock",
                    editorType: "dxCheckBox",
                    label: {
                        text: "ล๊อกรหัสนี้",
                    },
                    editorOptions: {
                        disabled: false
                    }
                },
                {
                    dataField: "JOBrefWE",

                    label: {
                        text: "อ้างอิง-บันทึกช่วยจำ",
                    },
                    editorOptions: {
                        disabled: false
                    }
                },
                ]
            });
        }
        
        //var data = {};
        $scope.AddJob = function() {
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
                items: [{
                    dataField: "JOBcode",
                    label: {
                        text: "รหัสงาน",
                    },
                    editorOptions: {
                        disabled: false,
                        inputAttr: { 'style': "text-transform: uppercase" },
                        maxLength: 15,
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ รหัสงาน"
                    }]
                },
                {
                    dataField: "JOBgroup",
                    label: {
                        text: "กลุ่มงาน"
                    },
                    editorOptions: {
                        disabled: false,
                        inputAttr: { 'style': "text-transform: uppercase" },
                        maxLength: 10,
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ กลุ่มงาน"
                    }]
                },
                {
                    dataField: "JOBdescT",

                    label: {
                        text: "รายละเอียดไทย",
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
                    dataField: "JOBdescE",

                    label: {
                        text: "รายละเอียดอังกฤษ",
                    },
                    editorOptions: {
                        disabled: false
                    }
                },
                {
                    dataField: "JOBhide",
                    editorType: "dxCheckBox",
                    label: {
                        text: "ซ่อนรหัสนี้",
                    },
                    editorOptions: {
                        disabled: false,
                        value: false,
                    },
                },
                {
                    dataField: "JOBlock",
                    editorType: "dxCheckBox",
                    label: {
                        text: "ล๊อกรหัสนี้",
                    },
                    editorOptions: {
                        disabled: false,
                        value: false,
                    },
                },
                {
                    dataField: "JOBrefWE",
                    label: {
                        text: "อ้างอิง-บันทึกช่วยจำ",
                    },
                    editorOptions: {
                        disabled: false
                    }
                },
                {
                    dataField: "JOBautostk_Chk",
                    editorType: "dxCheckBox",
                    label: {
                        text: "สร้างรหัสสินค้าอัตโนมัติ",
                    },
                    editorOptions: {
                        disabled: false,
                        value: true,
                    },
                },


                ]
            });



        }

        $scope.SubmitJob = function() {

            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                //obj.JOBautostk_Chk = false;
                if ((obj.JOBautostk_Chk == -1) || (obj.JOBautostk_Chk == true)) obj.JOBautostk_Chk = true;
                obj.JOBhide_Chk = false;
                if ((obj.JOBhide == -1) || (obj.JOBhide == true)) obj.JOBhide_Chk = true;
                obj.JOBlock_Chk = false;
                if ((obj.JOBlock == -1) || (obj.JOBlock == true)) obj.JOBlock_Chk = true;
                $.post("../BasicCode/InsertJOB",obj
                    //{
                    //    JOBcode: obj.JOBcode,
                    //    JOBgroup: obj.JOBgroup,
                    //    JOBdescT: obj.JOBdescT,
                    //    JOBdescE: obj.JOBdescE,
                    //    JOBhide_Chk: obj.JOBhide_Chk,
                    //    JOBlock_Chk: obj.JOBlock_Chk,
                    //    JOBlock_Chk: obj.JOBlock_Chk,
                    //    JOBrefWEL: obj.JOBrefWEL,
                    //    JOBsortNT: obj.JOBsortNT,
                    //    JOBsortNE: obj.JOBsortNE
                    //}
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
                            DevExpress.ui.notify(data.data, "error");
                        }

                    });

            }
        }
        
        $scope.SubmitJobUpdate = function() {

            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                obj.JOBhide_Chk = false;
                if ((obj.JOBhide == -1) || (obj.JOBhide == true)) obj.JOBhide_Chk = true;
                obj.JOBlock_Chk = false;
                if ((obj.JOBlock == -1) || (obj.JOBlock == true)) obj.JOBlock_Chk = true;
                $.post("../BasicCode/UpdateJOB",
                    {
                        JOBid: obj.JOBid,
                        JOBcode: obj.JOBcode,
                        JOBgroup: obj.JOBgroup,
                        JOBdescT: obj.JOBdescT,
                        JOBdescE: obj.JOBdescE,
                        JOBhide_Chk: obj.JOBhide_Chk,
                        JOBlock_Chk: obj.JOBlock_Chk,
                        JOBrefWEL: obj.JOBrefWEL,
                        JOBsortNT: obj.JOBsortNT,
                        JOBsortNE: obj.JOBsortNE
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
                            DevExpress.ui.notify(data.data, "error");
                        }

                    });

            }
        }
    }
]);

