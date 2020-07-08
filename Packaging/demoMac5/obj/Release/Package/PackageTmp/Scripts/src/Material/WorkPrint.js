angular.module('AceApp').controller('WorkPrintController', ['$scope', '$rootScope', '$stateParams', '$http',
  function ($scope, $rootScope, $stateParams, $http) {
    $("#gridContainer").hide();
    $("#btnAdd").hide();
    $("#showAdd").hide();

    var url = "../Material/GetMPrint/0";

    $scope.CallData = function () {

      $("#gridContainer").show();
      $("#btnAdd").show();

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

    $scope.LoadGrid = function (data) {

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
          dataField: "Print_Id",
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
          dataField: "Print_Code",
          caption: "รหัสงานพิมพ์",
          width: 150,
        }, {
          dataField: "Print_NameT",
          caption: "รายละเอียด (ไทย)",

        }, {
          dataField: "Print_NameE",
          caption: "รายละเอียด (อังกฤษ)",

        },

        {
          dataField: "Print_Id",
          caption: "แก้ไขข้อมูล",
          alignment: 'center',
          allowFiltering: false,
          fixed: true,
          fixedPosition: 'right',
          width: 100,
          cellTemplate: function (container, options) {
            //$("<div>")
            //    .append("<a  onclick='Edit(" + options.key.Print_Id + ")' title='แก้ไขข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-pencil'></i></a>")
            //    .appendTo(container);
            $("<div />").dxButton({
              icon: 'fa fa-pencil',
              type: 'default',
              disabled: false,
              onClick: function (e) {
                $("#gridContainer").hide();
                $("#btnAdd").hide();
                $("#showAdd").show();
                $("#btnEditDEG").show();
                $("#btnAddDEG").hide();
                // load api
                var url = "../Material/GetMPrint/" + options.key.Print_Id;

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
          dataField: "Print_Id",
          caption: "ลบข้อมูล",
          alignment: 'center',
          allowFiltering: false,
          fixed: true,
          fixedPosition: 'right',
          width: 100,
          cellTemplate: function (container, options) {
            //$("<div>")
            //    .append("<a onclick='Delete(" + options.data.Print_Id + ")' title='ลบข้อมูล' class='btn btn-icons btn-rounded btn-primary'  style='color:white' ><i class='fa fa-trash'></i></a>")
            //    .appendTo(container);

            $("<div />").dxButton({
              icon: 'fa fa-trash',
              type: 'default',
              disabled: false,
              onClick: function (e) {
                var r = confirm("ต้องการลบหรือไม่ !!!");
                if (r == true) {
                  $.post("../Material/DeleteMPrint",
                    {
                      Print_Id: options.data.Print_Id
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

    $scope.LoadForm = function (data) {

      $("#form-container").dxForm({
        colCount: 1,
        formData: data,
        showColonAfterLabel: true,
        showValidationSummary: true,
        items: [

          {
            dataField: "Print_Code",
            label: {
              text: "รหัสงานพิมพ์",
            },
            editorOptions: {
              disabled: false,
              attr: { 'style': "text-transform: uppercase" },
              Maxleght: 15,
            },
            validationRules: [{
              type: "required",
              message: "โปรดระบุ รหัสงานพิมพ์"
            }]
          },
          {
            dataField: "Print_NameT",
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
            dataField: "Print_NameE",

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

    $scope.Add = function () {


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

        $.post("../Material/InsertMPrint", obj
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

    $scope.Update = function () {

      if ($("#form-container").dxForm("instance").validate().isValid) {
        $("#gridContainer").hide();
        $("#btnAdd").hide();
        $("#showAdd").hide();

        var url = "../Material/UpdateMPrint";

        var obj = $("#form-container").dxForm("instance").option('formData');


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
              DevExpress.ui.notify(data.data, "error");
              $scope.CallData();
            }

          });

      }

    }

    $scope.Refresh = function () {
      $("#gridContainer").hide();
      $("#btnAdd").hide();
      $("#showAdd").hide();
      $scope.CallData();

    }
  }
]);

