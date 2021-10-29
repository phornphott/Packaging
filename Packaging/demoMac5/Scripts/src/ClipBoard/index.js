angular.module('AceApp').controller('ClipBoardIndexController', ['$scope', '$rootScope', '$stateParams', '$http',
    function ($scope, $rootScope, $stateParams, $http) {
        $scope.valueForm1 = {
            Weight1: "0.00",
            Weight2: "0.00",
            Weight3: "0.00",
            Weight4: "0.00",
            Weight5: "0.00",
            Weight6: null,
            Weight7: null,
            Weight8: null,
            Weight9: null
        }
        //$scope.LoadForm({});
        //$scope.LoadForm1({
        //    Weight1: "0.00",
        //    Weight2: "0.00",
        //    Weight3: "0.00",
        //    Weight4: "0.00",
        //    Weight5: "0.00",
        //    Weight6: null,
        //    Weight7: null,
        //    Weight8: null,
        //    Weight9: null
        //});
        //$scope.LoadGrid({});
        //$scope.LoadGrid1({});
        //$scope.calData();
        //$scope.RadioBagIn = "0";
        $scope.RadioPlasticCoating = "0";
        $scope.RadioFlexo = "0";
        $scope.RadioCoatedCaviar = "0";
        $scope.RadioPrintCaviar = "0";
        $scope.RadioTag = "0";
        $scope.RadioSewing = "0";
        $scope.RadioEyeletPunch = "0";
        $scope.RadioAlbelle = "0";
        $scope.RadioWearBagIn = "0";

        $scope.SelectHandle = 0;
        $scope.SelectTag = 0;
        $scope.SelectSewing = 0;
        $scope.SelectEyelet = 0;
        $scope.SelectBell = 0;
        $scope.SelectBagin2 = 0;
        
        $("#txtBenef").text("0.00");
        $scope.cancel = function() {
            window.location = "#/ClipBoard/Dashboard";
        }

        $scope.Edit = function (id) {

            var url = "../ClipBoard/GetClipBoard/" + id
            $.get(url)
                .done(function (res) {
                    if (res.success == true) {
                        //res.data[0].Clipboard_Date = new Date(res.data[0].Clipboard_Date_Str);
                        if (res.data[0].Clipboard_Date_Text !== null) {
                            res.data[0].Clipboard_Date = new Date(res.data[0].Clipboard_Date_Text);
                        }
                        res.data[0].Delivery_Id = res.data[0].Delivery_Id;
                        $scope.LoadForm(res.data[0])
                        $scope.LoadGrid(res.data[0]);
                        $scope.calData();
                    } else {
                        DevExpress.ui.notify(res.errMsg);
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });

                    }

                });

        }

        //$scope.LoadForm1({
        //    Weight1: "0.00",
        //    Weight2: "0.00",
        //    Weight3: "0.00",
        //    Weight4: "0.00",
        //    Weight5: "0.00",
        //    Weight6: null,
        //    Weight7: null,
        //    Weight8: null,
        //    Weight9: null
        //});

        if ($("#TempId").val() > 0) {
            $scope.Edit($("#TempId").val())
        }
        else {
            if ($("#TempId").val() <= 0) {
                var url = "../ClipBoard/GetLastClipBoard/0"
                $.get(url)
                    .done(function (res) {
                        if (res.success == true) {
                            if (res.data[0].Clipboard_Date_Text !== null) {
                                res.data[0].Clipboard_Date = new Date(res.data[0].Clipboard_Date_Text);
                            }
                            $scope.LoadForm(res.data[0])
                        }
                    });
            }
        }

        var HandleClipBoard = [];
        
        $scope.LoadForm = function(data) {

            var list_province = (function () {
                var json = null;
                $.ajax({
                    'async': false,
                    'global': false,
                    'url': "../Wage/GetProvince/0",
                    'dataType': "json",
                    'success': function (data) {
                        json = data.data;
                    }
                });
                return json;
            })();
            
            $("#form-container").dxForm({
                colCount: 3,
                formData: data,
                showColonAfterLabel: true,
                showValidationSummary: true,
                items: [{
                    dataField: "Clipboard_Nos",
                    label: {
                        text: "เลขที่",
                    },
                    editorOptions: {
                        disabled: true
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ เลขที่"
                    }]
                },
                {
                    dataField: "Clipboard_Quantity",
                    label: {
                        text: "จำนวน (ใบ) "
                    },
                    editorOptions: {
                        disabled: false
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ จำนวน (ใบ)"
                    }]
                },
                {
                    dataField: "Clipboard_Desc",
                    editorType: "dxTextArea",
                    label: {
                        text: "รายละเอียด",
                    },
                    editorOptions: {
                        disabled: false
                    }

                },
                {
                    dataField: "Clipboard_Date",
                    label: {
                        text: "วันที่",
                    },
                    editorType: "dxDateBox",
                    editorOptions: {
                        disabled: false,
                        displayFormat: "dd/MM/yyyy"
                    },
                    onValueChanged: function (data) {
                        console.log(data)
                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดระบุ วันที่"
                    }]
                },
                {
                    dataField: "Delivery_Id",

                    label: {
                        text: "สถานที่จัดส่งของ",
                    },
                    width: 200,
                    editorType: "dxSelectBox",
                    editorOptions: {
                        dataSource: list_province,
                        valueExpr: 'PROVINCE_ID',
                        displayExpr: 'PROVINCE_NAME',
                        disabled: false

                    },
                    validationRules: [{
                        type: "required",
                        message: "โปรดเลือกสถานที่จัดส่งของ"
                    }]
                },
                //{
                //    editorType: "dxButton",
                //    editorOptions: {
                //        disabled: false,
                //        type: "success",
                //        text: "Load data",
                //        //     icon:"calculator",
                //        onClick: function (e) {

                //            //calData();
                //            RecalculateData();
                //        }
                //    }
                //},
                {
                    editorType: "dxButton",
                    editorOptions: {
                        disabled: false,
                        type: "success",
                        text: "Recalculate",
                        //     icon:"calculator",
                        onClick: function (e) {

                            //calData();
                            $scope.RecalculateData();
                        }
                    }
                },
                ],
                //onFieldDataChanged: function (e) {
                //    var dataObj = {
                //        "Clipboard_Date_Str": convertDate(e.value)
                //    };

                //    var url = "../ClipBoard/GetAllCodeHandle/";
                //    //var url1 = "../ClipBoard/GetCodeTagClipBoard/";
                //    //var url2 = "../ClipBoard/GetCodeSewingClipBoard/";
                //    //var url3 = "../ClipBoard/GetCodeEyeletClipBoard/";
                //    //var url4 = "../ClipBoard/GetCodeBellClipBoard/";
                //    //var url5 = "../ClipBoard/GetCodeBagin2ClipBoard/";

                //    $.get(url, dataObj)
                //        .done(function (data) {
                //            console.log(data)
                //            var HandleClipBoard = data.data;
                //            $("#grid-container").dxDataGrid({
                //                columns: [
                //                    {
                //                        dataField: "col1",
                //                        alignment: 'center',
                //                        allowEditing: false,
                //                        width: 50,
                //                        cellTemplate: function (container, options) {
                //                            if (String(options.data.col1) == "1") {
                //                                $("<div>")
                //                                    .append("<input type='radio'  name='vehicle" + options.data.col6 + "'  value='0' checked='true' /> ")
                //                                    .appendTo(container);

                //                            } else if (String(options.data.col1) == "0") {
                //                                $("<div>")
                //                                    .append("<input type='radio' name='vehicle" + options.data.col6 + "' value='1'  /> ")
                //                                    .appendTo(container);
                //                            }
                //                            else {
                //                                $("<div>")
                //                                    .append(options.data.col1)
                //                                    .appendTo(container);
                //                            }

                //                        }
                //                    },
                //                    {
                //                        dataField: "col2",
                //                        allowEditing: false,
                //                    },
                //                    {
                //                        dataField: "col3",
                //                        alignment: 'center',
                //                        width: 100,
                //                        showEditorAlways: true,
                //                        editCellTemplate: function ($cell, cellData) {
                //                            console.log(cellData)
                //                            if (cellData.data.col2 === "ติด") {
                //                                var $selectBox = $("<div>").dxSelectBox({
                //                                    dataSource: HandleClipBoard,
                //                                    displayExpr: 'Handle_Desc',
                //                                    valueExpr: 'Handle_Id',
                //                                    value: 0,
                //                                    onItemClick: function (item) {
                //                                        console.log(item);

                //                                    }
                //                                });
                //                                $cell.append($selectBox);
                //                            }
                //                            else if (cellData.data.col2 === "ติด Tag") {
                //                                var $selectBox = $("<div>").dxSelectBox({
                //                                    dataSource: HandleClipBoard,
                //                                    displayExpr: 'Handle_Desc',
                //                                    valueExpr: 'Handle_Id',
                //                                    value: 0,
                //                                    onItemClick: function (item) {
                //                                        console.log(item);

                //                                    }
                //                                });
                //                                $cell.append($selectBox);
                //                            }
                //                            else if (cellData.data.col2 === "เย็บ") {
                //                                var $selectBox = $("<div>").dxSelectBox({
                //                                    dataSource: HandleClipBoard,
                //                                    displayExpr: 'Handle_Desc',
                //                                    valueExpr: 'Handle_Id',
                //                                    value: 0,
                //                                    onItemClick: function (item) {
                //                                        console.log(item);

                //                                    }
                //                                });
                //                                $cell.append($selectBox);
                //                            }
                //                            else if (cellData.data.col2 === "เจาะ") {
                //                                var $selectBox = $("<div>").dxSelectBox({
                //                                    dataSource: HandleClipBoard,
                //                                    displayExpr: 'Handle_Desc',
                //                                    valueExpr: 'Handle_Id',
                //                                    value: 0,
                //                                    onItemClick: function (item) {
                //                                        console.log(item);

                //                                    }
                //                                });
                //                                $cell.append($selectBox);
                //                            }
                //                            else if (cellData.data.col2 === "อัดเบลล์") {
                //                                var $selectBox = $("<div>").dxSelectBox({
                //                                    dataSource: HandleClipBoard,
                //                                    displayExpr: 'Handle_Desc',
                //                                    valueExpr: 'Handle_Id',
                //                                    value: 0,
                //                                    onItemClick: function (item) {
                //                                        console.log(item);

                //                                    }
                //                                });
                //                                $cell.append($selectBox);
                //                            }
                //                            else if (cellData.data.col2 === "สวมถุงใน") {
                //                                var $selectBox = $("<div>").dxSelectBox({
                //                                    dataSource: HandleClipBoard,
                //                                    displayExpr: 'Handle_Desc',
                //                                    valueExpr: 'Handle_Id',
                //                                    value: 0,
                //                                    onItemClick: function (item) {
                //                                        console.log(item);

                //                                    }
                //                                });
                //                                $cell.append($selectBox);
                //                            }
                //                        }
                //                    },
                //                    {
                //                        dataField: "col4",
                //                        alignment: 'center',
                //                        width: 80,
                //                    },
                //                    {
                //                        dataField: "col5",
                //                        alignment: 'center',
                //                        width: 120,
                //                        allowEditing: true,
                //                    },
                //                ]
                //            });
                //        });
                //}
            });
        }
        
        $scope.LoadForm1 = function(data) {
            $("#form-container1").dxForm({
                colCount: 3,
                dataSource: data,
                items: [{
                    dataField: "Weight1",
                    label: {
                        text: " นน.กระสอบ(กรัม)",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight1
                    },

                },
                {
                    dataField: "Weight2",
                    label: {
                        text: "นน.เคลือบ(กรัม) "
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight2

                    },

                },
                {
                    dataField: "Weight3",
                    label: {
                        text: "นน.สุทธิ(กรัม)",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight3
                    }
                },

                {
                    dataField: "Weight4",

                    label: {
                        text: "นน.ถุงใน(กรัม)",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight4
                    }
                },
                {
                    dataField: "Weight5",

                    label: {
                        text: "นน.กาเวียร์(กรัม)",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight5
                    }
                },
                ]
            }).dxForm("instance");

            $("#form-container2").dxForm({
                colCount: 2,
                dataSource: data,
                items: [{
                    dataField: "Weight6",
                    editorType: "dxTextArea",
                    label: {
                        text: "การบรรจุหีบห่อ",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight6
                    }
                }, {
                    dataField: "Weight7",
                    editorType: "dxTextArea",
                    label: {
                        text: "สถานที่ส่งมอบ",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight7
                    }
                }, {
                    dataField: "Weight8",
                    editorType: "dxTextArea",
                    label: {
                        text: "วันที่ส่งมอบ",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight8
                    }
                }, {
                    dataField: "Weight9",
                    editorType: "dxTextArea",
                    label: {
                        text: "หมายเหตุ",
                    },
                    editorOptions: {
                        disabled: false,
                        value: data.Weight9
                    }
                }
                ]
            }).dxForm("instance");
        }

        $scope.calData = function() {
            var objA = $("#form-container").dxForm("instance").option('formData');
            var gridA = $('#grid-container').dxDataGrid('instance').getDataSource()._items;

            var ex = 0;
            var area = 0;
            var weig = 0;
            var size = 0;
            var miconweig = 0;
            var plastic_micron = 0;
            var sizeSack = "";
            var structure = "";
            //var a = JSON.parse(gridA);
            //console.log(a);
            if (gridA.length > 0) {

                // ขนาดกระสอบ 
                sizeSack = Number(gridA[1].col3).toFixed(2) + " x " + Number(gridA[2].col3).toFixed(2);
                structure = Number(gridA[6].col4).toFixed(2) + " x " + Number(gridA[7].col4).toFixed(2);
                ////////  ค่า EX
                ex = ((
                    (Number(gridA[6].col3) * Number(gridA[6].col4)) + (Number(gridA[7].col3) * Number(gridA[7].col4))) * 40) / 9000;

                console.log(" ค่า EX  : " + ex);
                // พื้นที่กระสอบ
                area = ((((Number(gridA[1].col3) + Number(gridA[4].col3)) * 2) * 2.54) / 100) * (((Number(gridA[2].col3) + Number(gridA[3].col3)) * 2.54) / 100);
                console.log(" ค่าพื้นที่กระสอบ  : " + area);
                // น.น. กรัม /ใบ
                weig = ex * area;
                gridA[8].col3 = weig.toFixed(2);

                $('#grid-container').dxDataGrid("option", "dataSource", gridA);
                
                // คำนวณ นน ถุงใน
                miconweig = ((Number(gridA[1].col3) + Number(gridA[4].col3)) * (Number(gridA[2].col3) + Number(gridA[3].col3))) * Number(gridA[11].col4) * 0.00059;

                // คำนวนงานเคลือบ
                plastic_micron = ((Number(gridA[1].col3) + Number(gridA[4].col3)) * (Number(gridA[2].col3) + Number(gridA[3].col3))) * Number(gridA[16].col4) * 0.00059
                if (Number(gridA[15].col4) == 1) {
                    plastic_micron = plastic_micron / 2;
                }

                // งานพิมพ์
            }



            var data1 = [{
                'col1': 'ขนาดกระสอบ(ใบ)',
                'col2': sizeSack,
                'col3': 'โครงสร้างผ้า',
                'col4': structure,
                'col5': '',
            },
            {
                'col1': 'นน.กระสอบ',
                'col2': weig.toFixed(2),
                'col3': 'ราคาเม็ด PP',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'นน.ถุงใน(กรัม/ใบ)',
                'col2': miconweig.toFixed(2),
                'col3': 'ราคาเม็ด PE',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'นน.เคลือบ(กรัม/ใบ)',
                'col2': plastic_micron.toFixed(2),
                'col3': 'ราคาเม็ดเคลือบ',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'เม็ดสี',
                'col2': '',
                'col3': 'ราคาเพิ่มเม็ดสี',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'งานพิมพ์ Flexo',
                'col2': 'ไม่พิมพ์',
                'col3': '',
                'col4': '',
                'col5': '',
            },
            {
                'col1': 'งานพิมพ์การ์เวียร์',
                'col2': 'พิมพ์',
                'col3': 'ราคา ตรม. ละ',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'หูหิ้ว',
                'col2': '1',
                'col3': 'ราคาคู่ละ',
                'col4': 'ไม่ติด',
                'col5': '',
            },

            {
                'col1': 'TAG',
                'col2': 'ติด',
                'col3': 'ราคาคู่ละ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'งานเย็บ',
                'col2': 'เย็บวนปาก',
                'col3': 'ค่าเย็บ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'เจาะตาไก่',
                'col2': 'เจาะ',
                'col3': 'ค่าเจาะ (ร)',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'อัลเบลล์',
                'col2': 'อัลเบลล์',
                'col3': 'ราคาใบละ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'สวมถุงใน',
                'col2': 'อัลเบลล์',
                'col3': 'ราคาสวมใบละ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'ค่า Conversion',
                'col2': '',
                'col3': 'งานถุงไม่เคลือบ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': '',
                'col2': '',
                'col3': 'งานถุงเคลือบ',
                'col4': '',
                'col5': '',
            },
            {
                'col1': '',
                'col2': '',
                'col3': '',
                'col4': '',
                'col5': '',
            },
            {
                'col1': 'ระยะทาง',
                'col2': '',
                'col3': '',
                'col4': '',
                'col5': '',
            },

            {
                'col1': '',
                'col2': '',
                'col3': '',
                'col4': '',
                'col5': '',
            },
            {
                'col1': 'รูปแบบราคาขาย',
                'col2': 'สตางค์/ใบ',
                'col3': '0.00',
                'col4': '',
                'col5': '',
            },
            ];
            $scope.LoadGrid1(data1);
            // alert("success");
        }

        $scope.LoadGrid = function(res) {
            var data;
            if ($("#TempId").val() > 0) {

                data = [{
                    'col1': '1.1',
                    'col2': 'ลักษณะของถุงกระสอบ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'ความกว้างของถุง',
                    'col3': res.Bag_Width,
                    'col4': 'นิ้ว',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'ความยาวของถุง',
                    'col3': res.Bag_Lenght,
                    'col4': 'นิ้ว',
                    'col5': '',
                },

                {
                    'col1': '',
                    'col2': 'เพิ่มความยาวเผื่อเย็บ',
                    'col3': res.Bag_Lenght_Add,
                    'col4': 'นิ้ว',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'เพิ่มความกว้างเผื่อเคลือบ',
                    'col3': res.Bag_Width_Add,
                    'col4': 'นิ้ว',
                    'col5': '',
                },


                {
                    'col1': '',
                    'col2': '',
                    'col3': 'ดีเนียร์',
                    'col4': 'Mech',
                    'col5': 'ความกว้างของเส้น',
                },
                {
                    'col1': '',
                    'col2': 'ด้ายยืน',
                    'col3': res.Warpyarn_Denier,
                    'col4': res.Warpyarn_Mech,
                    'col5': res.Warpyarn_Width,
                },
                {
                    'col1': '',
                    'col2': 'ด้ายพุ่ง',
                    'col3': res.Fillingyarn_Denier,
                    'col4': res.Fillingyarn_Mech,
                    'col5': res.Fillingyarn_Width,
                },
                {
                    'col1': '',
                    'col2': 'น.น. กรัม/ใบ',
                    'col3': '0',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1.2',
                    'col2': 'ถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Bagin_Use == 0 ? '1' : '0',
                    'col2': 'ไม่สวม',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '1'
                },

                {
                    'col1': res.Bagin_Use == 1 ? '1' : '0',
                    'col2': 'สวม',
                    'col3': 'ความกว้าง (นิ้ว)',
                    'col4': res.Bagin_Width,
                    'col5': '',
                    'col6': '1'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'ความยาว (นิ้ว)',
                    'col4': res.Bagin_Lenght,
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'ไมครอน/ใบ',
                    'col4': res.Bagin_Micron,
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'นน.กรัม/ใบ',
                    'col4': res.Bagin_Weight,
                    'col5': '',
                },
                {
                    'col1': '1.3',
                    'col2': 'งานเคลือบพลาสติก',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Plastic_Use == 0 ? '1' : '0',
                    'col2': 'ไม่เคลือบ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '2'
                },
                {
                    'col1': res.Plastic_Use == 1 ? '1' : '0',
                    'col2': 'เคลือบ',
                    'col3': 'จำนวนหน้า',
                    'col4': '0',
                    'col5': '0',
                    'col6': '2'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'ไมครอน/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },

                {
                    'col1': '',
                    'col2': '',
                    'col3': 'นน.กรัม/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },
                {
                    'col1': '1.4',
                    'col2': 'สีของถุง',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'ให้เลือกว่าเป็น',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1.5',
                    'col2': 'งานพิมพ์ Flexo',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Print_Flexo_Use == 0 ? '1' : '0',
                    'col2': 'ไม่พิมพ์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '3'
                },
                {
                    'col1': res.Print_Flexo_Use == 1 ? '1' : '0',
                    'col2': 'พิมพ์',
                    'col3': 'จำนวนสี',
                    'col4': '0',
                    'col5': 'หน้า',
                    'col6': '3'
                },
                {
                    'col1': '1.6',
                    'col2': 'งานเคลือบการ์เวียร์',
                    'col3': '',
                    'col4': '',
                    'col5': '',

                },
                {
                    'col1': res.Gravure_Use == 0 ? '1' : '0',
                    'col2': 'ไม่เคลือบ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '4'
                },
                {
                    'col1': res.Gravure_Use == 1 ? '1' : '0',
                    'col2': 'เคลือบ',
                    'col3': 'ไมครอน/ใบ',
                    'col4': '0.00',
                    'col5': '',
                    'col6': '4'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'นน.กรัม/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },
                {
                    'col1': '1.7',
                    'col2': 'งานพิมพ์การ์เวียร์',
                    'col3': '',
                    'col4': '',
                    'col5': 'ตรม.',
                },
                {
                    'col1': '1.8',
                    'col2': 'หูหิ้ว',
                    'col3': '',
                    'col4': '',
                    'col5': '',

                },
                {
                    'col1': res.Handle_Use == 0 ? '1' : '0',
                    'col2': 'ไม่ติด',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '5'
                },
                {
                    'col1': res.Handle_Use == 1 ? '1' : '0',
                    'col2': 'ติด',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '5'
                },
                {
                    'col1': '1.9',
                    'col2': 'Tag',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Tag_Use == 0 ? '1' : '0',
                    'col2': 'ไม่ติด Tag',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '6'
                },
                {
                    'col1': res.Tag_Use == 1 ? '1' : '0',
                    'col2': 'ติด Tag',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '6'
                },
                {
                    'col1': '2.0',
                    'col2': 'งานเย็บ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Sewing_Use == 0 ? '1' : '0',
                    'col2': 'ไม่เย็บ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '7'
                },
                {
                    'col1': res.Sewing_Use == 1 ? '1' : '0',
                    'col2': 'เย็บ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '7'
                },
                {
                    'col1': '2.1',
                    'col2': 'เจาะตาไก่',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Eyelet_Use == 0 ? '1' : '0',
                    'col2': 'ไม่เจาะ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '8'
                },
                {
                    'col1': res.Eyelet_Use == 1 ? '1' : '0',
                    'col2': 'เจาะ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '8'
                },
                {
                    'col1': '2.2',
                    'col2': 'อัลเบลล์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Bell_Use == 0 ? '1' : '0',
                    'col2': 'ไม่อัดเบลล์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '9'
                },
                {
                    'col1': res.Bell_Use == 1 ? '1' : '0',
                    'col2': 'อัดเบลล์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '9'
                },
                {
                    'col1': '2.3',
                    'col2': 'สวมถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': res.Bagin_Use2 == 0 ? '1' : '0',
                    'col2': 'ไม่สวมถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '10'
                },
                {
                    'col1': res.Bagin_Use2 == 1 ? '1' : '0',
                    'col2': 'สวมถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '10'
                },
                ];
            }
            else {
                data = [{
                    'col1': '1.1',
                    'col2': 'ลักษณะของถุงกระสอบ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'ความกว้างของถุง',
                    'col3': '0',
                    'col4': 'นิ้ว',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'ความยาวของถุง',
                    'col3': '0',
                    'col4': 'นิ้ว',
                    'col5': '',
                },

                {
                    'col1': '',
                    'col2': 'เพิ่มความยาวเผื่อเย็บ',
                    'col3': '0',
                    'col4': 'นิ้ว',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'เพิ่มความกว้างเผื่อเคลือบ',
                    'col3': '0',
                    'col4': 'นิ้ว',
                    'col5': '',
                },


                {
                    'col1': '',
                    'col2': '',
                    'col3': 'ดีเนียร์',
                    'col4': 'Mech',
                    'col5': 'ความกว้างของเส้น',
                },
                {
                    'col1': '',
                    'col2': 'ด้ายยืน',
                    'col3': '0',
                    'col4': '0',
                    'col5': '0',
                },
                {
                    'col1': '',
                    'col2': 'ด้ายพุ่ง',
                    'col3': '0',
                    'col4': '0',
                    'col5': '0',
                },
                {
                    'col1': '',
                    'col2': 'น.น. กรัม/ใบ',
                    'col3': '0.00',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1.2',
                    'col2': 'ถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่สวม',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '1'
                },

                {
                    'col1': '0',
                    'col2': 'สวม',
                    'col3': 'ไมครอน/ใบ',
                    'col4': '0.00',
                    'col5': '',
                    'col6': '1'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'นน.กรัม/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },
                {
                    'col1': '1.3',
                    'col2': 'งานเคลือบพลาสติก',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่เคลือบ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '2'
                },
                {
                    'col1': '0',
                    'col2': 'เคลือบ',
                    'col3': 'จำนวนหน้า',
                    'col4': '0',
                    'col5': '',
                    'col6': '2'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'ไมครอน/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },

                {
                    'col1': '',
                    'col2': '',
                    'col3': 'นน.กรัม/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },
                {
                    'col1': '1.4',
                    'col2': 'สีของถุง',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '',
                    'col2': 'ให้เลือกว่าเป็น',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1.5',
                    'col2': 'งานพิมพ์ Flexo',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่พิมพ์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '3'
                },
                {
                    'col1': '0',
                    'col2': 'พิมพ์',
                    'col3': 'จำนวนหน้า',
                    'col4': '0',
                    'col5': 'หน้า',
                    'col6': '3'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'จำนวนสี',
                    'col4': '0',
                    'col5': 'สี',
                    'col6': '3'
                },
                {
                    'col1': '1.6',
                    'col2': 'งานเคลือบการ์เวียร์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่เคลือบ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '4'
                },
                {
                    'col1': '0',
                    'col2': 'เคลือบ',
                    'col3': 'ไมครอน/ใบ',
                    'col4': '0.00',
                    'col5': '',
                    'col6': '4'
                },
                {
                    'col1': '',
                    'col2': '',
                    'col3': 'นน.กรัม/ใบ',
                    'col4': '0.00',
                    'col5': '',
                },
                {
                    'col1': '1.7',
                    'col2': 'งานพิมพ์การ์เวียร์',
                    'col3': '',
                    'col4': '',
                    'col5': 'ตรม.',
                },
                {
                    'col1': '1.8',
                    'col2': 'หูหิ้ว',
                    'col3': '',
                    'col4': '',
                    'col5': '',

                },
                {
                    'col1': '1',
                    'col2': 'ไม่ติด',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '5'
                },
                {
                    'col1': '0',
                    'col2': 'ติด',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '5'
                },
                {
                    'col1': '1.9',
                    'col2': 'Tag',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่ติด Tag',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '6'
                },
                {
                    'col1': '0',
                    'col2': 'ติด Tag',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '6'
                },
                {
                    'col1': '2.0',
                    'col2': 'งานเย็บ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่เย็บ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '7'
                },
                {
                    'col1': '0',
                    'col2': 'เย็บ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '7'
                },
                {
                    'col1': '2.1',
                    'col2': 'เจาะตาไก่',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่เจาะ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '8'
                },
                {
                    'col1': '0',
                    'col2': 'เจาะ',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '8'
                },
                {
                    'col1': '2.2',
                    'col2': 'อัลเบลล์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่อัดเบลล์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '9'
                },
                {
                    'col1': '0',
                    'col2': 'อัดเบลล์',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '9'
                },
                {
                    'col1': '2.3',
                    'col2': 'สวมถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                },
                {
                    'col1': '1',
                    'col2': 'ไม่สวมถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '10'
                },
                {
                    'col1': '0',
                    'col2': 'สวมถุงใน',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                    'col6': '10'
                },
                {
                    'col1': '2.4',
                    'col2': 'ค่า Conversion',
                    'col3': '',
                    'col4': '',
                    'col5': '',
                }
                ];

            }

            var dataGrid = $("#grid-container").dxDataGrid({
                dataSource: data,
                showBorders: true,
                showRowLines: false,
                rowAlternationEnabled: false,
                showColumnHeaders: false,
                paging: {
                    enabled: true
                },
                
                scrolling: {
                    columnRenderingMode: "standard",
                    mode: "standard",
                    preloadEnabled: false,
                    rowRenderingMode: "standard",
                    scrollByContent: true,
                    scrollByThumb: false,
                    showScrollbar: "onScroll",
                    useNative: null
                },
                editing: {
                    mode: "cell",
                    allowUpdating: true
                },

                width: 100 + "%",
                height: '600px',
                searchPanel: {
                    visible: false,
                    width: 240,
                    placeholder: "ค้นหา..."
                },
                columnHidingEnabled: true,
                filterRow: {
                    visible: false,
                    applyFilter: "auto"
                },

                columns: [
                    {
                        dataField: "col1",
                        alignment: 'center',
                        allowEditing: false,
                        width: 50,
                        cellTemplate: function (container, options) {
                            console.log(options)
                            if (String(options.data.col1) === "1") {
                                $("<div>")
                                    .append("<input type='radio' name='vehicle" + options.data.col6 + "' value='0' onclick='changeRadioClipBoard(" + options.data.col6 + ", 0)' checked='true'/> ")
                                    .appendTo(container);

                            } else if (String(options.data.col1) == "0") {
                                $("<div>")
                                    .append("<input type='radio' name='vehicle" + options.data.col6 + "' value='1' onclick='changeRadioClipBoard(" + options.data.col6 + ", 1)'/> ")
                                    .appendTo(container);
                            }
                            else {
                                $("<div>")
                                    .append(options.data.col1)
                                    .appendTo(container);
                            }
                        }
                    },
                    {
                        dataField: "col2",
                        allowEditing: false,
                    },
                    {
                        dataField: "col3",
                        alignment: 'center',
                        width: 80,
                        showEditorAlways: true,
                        editCellTemplate: function ($cell, cellData) {
                            if (cellData.data.col2 === "เย็บ" && cellData.data.col6 === "7") {
                                var dataObj = {
                                    "Clipboard_Date_Str": convertDate(new Date())
                                };

                                var url = "../ClipBoard/GetAllCodeHandle/";

                                $.get(url, dataObj)
                                    .done(function (data) {
                                        $("<div />").dxSelectBox({
                                            dataSource: data.data.ListSewing,
                                            displayExpr: "Sewing_Desc",
                                            valueExpr: "Cost_E_Id",
                                            value: $scope.SelectSewing,
                                            onItemClick: function (data) {
                                                $scope.SelectSewing = data.itemData.Cost_E_Id;
                                            }
                                        }).appendTo($cell);
                                    });
                            }
                            else if (cellData.data.col2 === "ติด" && cellData.data.col6 === "5") {
                                var dataObj = {
                                    "Clipboard_Date_Str": convertDate(new Date())
                                };

                                var url = "../ClipBoard/GetAllCodeHandle/";

                                $.get(url, dataObj)
                                    .done(function (data) {
                                        $("<div />").dxSelectBox({
                                            dataSource: data.data.ListHandle,
                                            displayExpr: "Handle_Desc",
                                            valueExpr: "Handle_Id",
                                            value: 1,
                                            onItemClick: function (data) {
                                                $scope.SelectHandle = data.itemData.Handle_Id;
                                            }
                                        }).appendTo($cell);
                                    });
                            }
                            else if (cellData.data.col2 === "ติด Tag" && cellData.data.col6 === "6") {
                                var dataObj = {
                                    "Clipboard_Date_Str": convertDate(new Date())
                                };

                                var url = "../ClipBoard/GetAllCodeHandle/";

                                $.get(url, dataObj)
                                    .done(function (data) {
                                        $("<div />").dxSelectBox({
                                            dataSource: data.data.ListTag,
                                            displayExpr: "Tag_Desc",
                                            valueExpr: "Tag_Id",
                                            value: 1,
                                            onItemClick: function (data) {
                                                $scope.SelectTag = data.itemData.Tag_Id;
                                            }
                                        }).appendTo($cell);
                                    });
                            }
                            else if (cellData.data.col2 === "เจาะ" && cellData.data.col6 === "8") {
                                var dataObj = {
                                    "Clipboard_Date_Str": convertDate(new Date())
                                };

                                var url = "../ClipBoard/GetAllCodeHandle/";

                                $.get(url, dataObj)
                                    .done(function (data) {
                                        $("<div />").dxSelectBox({
                                            dataSource: data.data.ListEyelet,
                                            displayExpr: "Eyelet_Desc",
                                            valueExpr: "Eyelet_Id",
                                            value: 1,
                                            onItemClick: function (data) {
                                                $scope.SelectEyelet = data.itemData.Eyelet_Id;
                                            }
                                        }).appendTo($cell);
                                    });
                            }
                            else if (cellData.data.col2 === "อัดเบลล์" && cellData.data.col6 === "9") {
                                var dataObj = {
                                    "Clipboard_Date_Str": convertDate(new Date())
                                };

                                var url = "../ClipBoard/GetAllCodeHandle/";

                                $.get(url, dataObj)
                                    .done(function (data) {
                                        $("<div />").dxSelectBox({
                                            dataSource: data.data.ListBell,
                                            displayExpr: "Bell_Desc",
                                            valueExpr: "Bell_Id",
                                            value: 1,
                                            onItemClick: function (data) {
                                                $scope.SelectBell = data.itemData.Bell_Id;
                                            }
                                        }).appendTo($cell);
                                    });
                            }
                            else if (cellData.data.col2 === "สวมถุงใน" && cellData.data.col6 === "10") {
                                var dataObj = {
                                    "Clipboard_Date_Str": convertDate(new Date())
                                };

                                var url = "../ClipBoard/GetAllCodeHandle/";

                                $.get(url, dataObj)
                                    .done(function (data) {
                                        $("<div />").dxSelectBox({
                                            dataSource: data.data.ListBagin2,
                                            displayExpr: "Bagin2_Desc",
                                            valueExpr: "Bagin2_Id",
                                            value: 1,
                                            onItemClick: function (data) {
                                                $scope.SelectBagin2 = data.itemData.Bagin2_Id;
                                            }
                                        }).appendTo($cell);
                                    });
                            }
                            else {
                                $("<div />").dxTextBox({
                                    //value: null,
                                    onValueChanged: function (data) {
                                        
                                    }
                                }).appendTo($cell);
                            }
                        }
                    },
                    {
                        dataField: "col4",
                        alignment: 'center',
                        width: 80,
                    },
                    {
                        dataField: "col5",
                        alignment: 'center',
                        width: 120,
                        allowEditing: true,
                    },
                ]
            });
        }

        $scope.LoadGrid1 = function(data1) {
            $("#grid-container1").dxDataGrid({
                dataSource: data1,
                showBorders: true,
                showRowLines: false,
                rowAlternationEnabled: false,
                showColumnHeaders: false,
                paging: {
                    enabled: false
                },

                editing: {
                    mode: "cell",
                    allowUpdating: true
                },
                width: 100 + "%",
                height: '600',
                searchPanel: {
                    visible: false,
                    width: 240,
                    placeholder: "ค้นหา..."
                },
                filterRow: {
                    visible: false,
                    applyFilter: "auto"
                },

                columns: [
                    {
                        dataField: "col1",
                        allowEditing: false,
                        width: 150,
                    },
                    {
                        dataField: "col2",

                        allowEditing: false,
                    },
                    {
                        dataField: "col3",
                        width: 150,
                        allowEditing: false,

                    },
                    {
                        dataField: "col4",
                        alignment: 'center',

                        allowEditing: false,
                    },

                ],



            });

        }

        $scope.RecalculateData = function() {
            var obj = $('#form-container').dxForm("instance").option('formData');
            var gridA = $('#grid-container').dxDataGrid('instance').getDataSource()._items;
            var gridB = $('#grid-container1').dxDataGrid('instance').getDataSource()._items;

            var dataObj = {
                "Clipboard_Date": obj.Clipboard_Date,
                "Clipboard_Date_Str": convertDate(obj.Clipboard_Date),
                "Clipboard_Desc": obj.Clipboard_Desc,                       //รายละเอียดกระดานทด
                "Clipboard_Nos": obj.Clipboard_Nos,                         //เลขที่ดกระดานทด
                "Delivery_Id": obj.Delivery_Id,                             // Id จังหวัด
                "Clipboard_Delivery_Desc": $("#form-container").dxForm("instance").getEditor("Delivery_Id").option("displayValue"),     //จังหวัด
                "Delivery_Id": obj.Delivery_Id,                             // Id จังหวัด
                "Bag_Width": Number(gridA[1].col3),                         // ความกว้างของถุง
                "Bag_Width_Add": Number(gridA[4].col3),                     // ความกว้างเผื่อเคลือบ
                "Bag_Lenght": Number(gridA[2].col3),                        // ความยาวของถุง
                "Bag_Lenght_Add": Number(gridA[3].col3),                    // ความยาวเผื่อเย็บ
                "Warpyarn_Denier": Number(gridA[6].col3),                   // ด้ายยืน ดีเนียร์
                "Warpyarn_Mech": Number(gridA[6].col4),                     // ด้ายยืน Mech
                "Warpyarn_Width": Number(gridA[6].col5),                    // ด้ายยืน ความกว้างของเส้น
                "Fillingyarn_Denier": Number(gridA[7].col3),                // ด้ายพุ่ง ดีเนียร์
                "Fillingyarn_Mech": Number(gridA[7].col4),                  // ด้ายพุ่ง Mech
                "Fillingyarn_Width": Number(gridA[7].col5),                 // Fillingyarn_Width
                "Bag_Weight": Number(gridA[8].col3),                        // น้ำหนัก กรัม/ใบ
                "Bagin_Use": $("input[name='vehicle1']:checked").val(),     // ใช้ถุงใน
                "Bagin_Micron": Number(gridA[11].col4),
                "Bagin_Weight": Number(gridA[12].col4),
                "Plastic_Use": $("input[name='vehicle2']:checked").val(),
                "Plastic_Quantity": Number(gridA[15].col4),
                "Plastic_Micron": Number(gridA[16].col4),
                "Plastic_Weight": Number(gridA[17].col4),
                //    "Gravure_Use": Number(grid1[8].col3),
                "Gravure_Quantity": Number(gridA[8].col3),
                "Gravure_Micron": Number(gridA[8].col3),
                "Gravure_Weight": Number(gridA[8].col3),
            };

            //var list_handle = (function () {
            //    var json = null;
            //    $.ajax({
            //        'async': false,
            //        'global': false,
            //        'url': "../ClipBoard/GetCodeHandleClipBoard/'01/03/2019'",
            //        'dataType': "json",
            //        'success': function (data) {
            //            json = data.data;
            //        }
            //    });
            //    return json;
            //})();
            
            //+ convertDate(obj.Clipboard_Date)


            var url = "../ClipBoard/RecalculateClipBoard/";
            $.get(url, dataObj)
                .done(function (data) {

                    if (data.success == true) {


                        //$scope.LoadGrid(data.data);


                    } else {
                        DevExpress.ui.notify(data.errMsg);
                        $("#loadIndicator").dxLoadIndicator({
                            visible: false
                        });

                    }

                });

            var ex = 0;
            var area = 0;
            var weig = 0;
            var size = 0;
            var miconweig = 0;
            var plastic_micron = 0;
            var sizeSack = "";
            var structure = "";
            //var a = JSON.parse(gridA);
            //console.log(a);
            if (gridA.length > 0) {

                // ขนาดกระสอบ 
                sizeSack = Number(gridA[1].col3).toFixed(2) + " x " + Number(gridA[2].col3).toFixed(2);
                structure = Number(gridA[6].col4).toFixed(2) + " x " + Number(gridA[7].col4).toFixed(2);
                ////////  ค่า EX
                ex = ((
                    (Number(gridA[6].col3) * Number(gridA[6].col4)) + (Number(gridA[7].col3) * Number(gridA[7].col4))) * 40) / 9000;

                console.log(" ค่า EX  : " + ex);
                // พื้นที่กระสอบ
                area = ((((Number(gridA[1].col3) + Number(gridA[4].col3)) * 2) * 2.54) / 100) * (((Number(gridA[2].col3) + Number(gridA[3].col3)) * 2.54) / 100);
                console.log(" ค่าพื้นที่กระสอบ  : " + area);
                // น.น. กรัม /ใบ
                weig = ex * area + 5;
                gridA[8].col3 = weig.toFixed(2);

                $('#grid-container').dxDataGrid("option", "dataSource", gridA);


                console.log(" น.น. กรัม /ใบ  : " + weig);

                // คำนวณ นน ถุงใน
                miconweig = ((Number(gridA[1].col3) + Number(gridA[4].col3)) * (Number(gridA[2].col3) + Number(gridA[3].col3))) * Number(gridA[11].col4) * 0.00059;
                console.log(" ค่า นน ถุงใน  : " + miconweig);

                // คำนวนงานเคลือบ
                plastic_micron = ((Number(gridA[1].col3) + Number(gridA[4].col3)) * (Number(gridA[2].col3) + Number(gridA[3].col3))) * Number(gridA[16].col4) * 0.00059
                if (Number(gridA[15].col4) == 1) {
                    plastic_micron = plastic_micron / 2;
                }

                // งานพิมพ์
            }

            //Grid ฝั่งซ้าย


            //Grid ฝั่งขวา
            var data1 = [{
                'col1': 'ขนาดกระสอบ(ใบ)',
                'col2': sizeSack,
                'col3': 'โครงสร้างผ้า',
                'col4': structure,
                'col5': '',
            },
            {
                'col1': 'นน.กระสอบ',
                'col2': weig.toFixed(2),
                'col3': 'ราคาเม็ด PP',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'นน.ถุงใน(กรัม/ใบ)',
                'col2': miconweig.toFixed(2),
                'col3': 'ราคาเม็ด PE',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'นน.เคลือบ(กรัม/ใบ)',
                'col2': plastic_micron.toFixed(2),
                'col3': 'ราคาเม็ดเคลือบ',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'เม็ดสี',
                'col2': '',
                'col3': 'ราคาเพิ่มเม็ดสี',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'งานพิมพ์ Flexo',
                'col2': 'ไม่พิมพ์',
                'col3': '',
                'col4': '',
                'col5': '',
            },
            {
                'col1': 'งานพิมพ์การ์เวียร์',
                'col2': 'พิมพ์',
                'col3': 'ราคา ตรม. ละ',
                'col4': '0.00',
                'col5': '',
            },
            {
                'col1': 'หูหิ้ว',
                'col2': '1',
                'col3': 'ราคาคู่ละ',
                'col4': 'ไม่ติด',
                'col5': '',
            },

            {
                'col1': 'TAG',
                'col2': 'ติด',
                'col3': 'ราคาคู่ละ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'งานเย็บ',
                'col2': 'เย็บวนปาก',
                'col3': 'ค่าเย็บ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'เจาะตาไก่',
                'col2': 'เจาะ',
                'col3': 'ค่าเจาะ (ร)',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'อัลเบลล์',
                'col2': 'อัลเบลล์',
                'col3': 'ราคาใบละ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'สวมถุงใน',
                'col2': 'อัลเบลล์',
                'col3': 'ราคาสวมใบละ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': 'ค่า Conversion',
                'col2': '',
                'col3': 'งานถุงไม่เคลือบ',
                'col4': '0',
                'col5': '',
            },
            {
                'col1': '',
                'col2': '',
                'col3': 'งานถุงเคลือบ',
                'col4': '',
                'col5': '',
            },
            {
                'col1': '',
                'col2': '',
                'col3': '',
                'col4': '',
                'col5': '',
            },
            {
                'col1': 'ระยะทาง',
                'col2': '',
                'col3': '',
                'col4': '',
                'col5': '',
            },

            {
                'col1': '',
                'col2': '',
                'col3': '',
                'col4': '',
                'col5': '',
            },
            {
                'col1': 'รูปแบบราคาขาย',
                'col2': 'สตางค์/ใบ',
                'col3': '0.00',
                'col4': '',
                'col5': '',
            },
            ];
            $scope.LoadGrid1(data1);
            // alert("success");
        }

        $scope.save = function() {
            if ($("#form-container").dxForm("instance").validate().isValid) {
                var obj = $("#form-container").dxForm("instance").option('formData');
                var grid1 = $('#grid-container').dxDataGrid('instance').getDataSource()._items;

                var dataObj = {
                    "Clipboard_Date_Str": convertDate(obj.Clipboard_Date),      //วันที่กระดานทด
                    "Clipboard_Desc": obj.Clipboard_Desc,                       //รายละเอียดกระดานทด
                    "Clipboard_Nos": obj.Clipboard_Nos,                         //เลขที่ดกระดานทด
                    "Clipboard_Quantity": obj.Clipboard_Quantity,
                    "Clipboard_Delivery_Desc": $("#form-container").dxForm("instance").getEditor("Delivery_Id").option("displayValue"),     //จังหวัด
                    "Delivery_Id": obj.Delivery_Id,                             // Id จังหวัด
                    "Bag_Width": Number(grid1[1].col3),                         // ความกว้างของถุง
                    "Bag_Width_Add": Number(grid1[4].col3),                     // ความกว้างเผื่อเคลือบ
                    "Bag_Lenght": Number(grid1[2].col3),                        // ความยาวของถุง
                    "Bag_Lenght_Add": Number(grid1[3].col3),                    // ความยาวเผื่อเย็บ
                    "Warpyarn_Denier": Number(grid1[6].col3),                   // ด้ายยืน ดีเนียร์
                    "Warpyarn_Mech": Number(grid1[6].col4),                     // ด้ายยืน Mech
                    "Warpyarn_Width": Number(grid1[6].col5),                    // ด้ายยืน ความกว้างของเส้น
                    "Fillingyarn_Denier": Number(grid1[7].col3),
                    "Fillingyarn_Mech": Number(grid1[7].col4),
                    "Fillingyarn_Width": Number(grid1[7].col5),
                    "Bag_Weight": Number(grid1[8].col3),
                    "Bagin_Use": $("input[name='vehicle1']:checked").val(),
                    "Bagin_Micron": Number(grid1[11].col4),
                    "Bagin_Weight": Number(grid1[12].col4),
                    "Plastic_Use": $("input[name='vehicle2']:checked").val(),
                    "Plastic_Quantity": Number(grid1[15].col4),
                    "Plastic_Micron": Number(grid1[16].col4),
                    "Plastic_Weight": Number(grid1[17].col4),
                    //    "Gravure_Use": Number(grid1[8].col3),
                    "Gravure_Quantity": Number(grid1[8].col3),
                    "Gravure_Micron": Number(grid1[8].col3),
                    "Gravure_Weight": Number(grid1[8].col3),
                };

                var url = "../ClipBoard/InsertClipBoard/";

                if ($("#TempId").val() > 0) {
                    dataObj.Clipboard_Id = $("#TempId").val();
                    url = "../ClipBoard/UpdateClipBoard/";
                    $.post(url, dataObj)
                        .done(function (data) {
                            if (data.success == true) {
                                DevExpress.ui.notify(data.data);
                            } else {
                                DevExpress.ui.notify(data.data);
                            }
                        });

                } else {

                    $.post(url, dataObj)
                        .done(function (data) {
                            if (data.success == true) {
                                DevExpress.ui.notify(data.data);

                            } else {
                                DevExpress.ui.notify(data.data);
                            }
                        });
                }
            }
        }
    }
]);

function changeRadioClipBoard(COL, ID) {
    var radioValue = $("input[name='vehicle" + COL + "']:checked").val();
    $("input[name='vehicle" + COL + "'][value=" + radioValue + "]").prop('checked', true);
    //$scope.RadioBagIn = ID;
}

//function checkedRadio0(ID) {
//    $scope.RadioBagIn = true;
//}