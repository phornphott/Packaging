angular.module('AceApp').config(function ($stateProvider, $urlRouterProvider, $ocLazyLoadProvider, $qProvider, $locationProvider) {
    $urlRouterProvider.otherwise("/");
    $qProvider.errorOnUnhandledRejections(false);
    $locationProvider.hashPrefix('');

    $stateProvider
        .state('/', {
            name: "Dashboard",
            url: "/",
            templateUrl: '\Home/Dashboard',
            controller: 'DashboardController'
        })
        .state('/BasicCode/ProductGroup', {
            url: "/BasicCode/ProductGroup",
            templateUrl: '\StaticViews/BasicCode/ProductGroup.html',
            controller: 'ProductGroupController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/productgroup.js'
                            ]
                        }])
                }]
            }
        })
        .state('/BasicCode/Product', {
            url: "/BasicCode/Product",
            templateUrl: '\StaticViews/BasicCode/Product.html',
            controller: 'ProductController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/products.js'
                            ]
                        }])
                }]
            }
        })
        .state('/BasicCode/CustomerGroup', {
            url: "/BasicCode/CustomerGroup",
            templateUrl: '\StaticViews/BasicCode/CustomerGroup.html',
            controller: 'CustomerGroupController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/customerGroup.js'
                            ]
                        }])
                }]
            }
        })
        .state('/BasicCode/Customer', {
            url: "/BasicCode/Customer",
            templateUrl: '\StaticViews/BasicCode/Customer.html',
            controller: 'CustomerController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/customer.js'
                            ]
                        }])
                }]
            }
        })
        .state('/BasicCode/Employee', {
            url: "/BasicCode/Employee",
            templateUrl: '\StaticViews/BasicCode/Employee.html',
            controller: 'EmployeeController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/employee.js'
                            ]
                        }])
                }]
            }
        })
        .state('/BasicCode/Job', {
            url: "/BasicCode/Job",
            templateUrl: '\StaticViews/BasicCode/Job.html',
            controller: 'JobController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/job.js'
                            ]
                        }])
                }]
            }
        })
        .state('/BasicCode/Department', {
            url: "/BasicCode/Department",
            templateUrl: '\StaticViews/BasicCode/Department.html',
            controller: 'DepartmentController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/BasicCode/department.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Material/MaterialList', {
            url: "/Material/MaterialList",
            templateUrl: '\StaticViews/Material/MaterialList.html',
            controller: 'MaterialListController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Material/MaterialList.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Material/WorkPrint', {
            url: "/Material/WorkPrint",
            templateUrl: '\StaticViews/Material/WorkPrint.html',
            controller: 'WorkPrintController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Material/WorkPrint.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Material/Apparatus', {
            url: "/Material/Apparatus",
            templateUrl: '\StaticViews/Material/Apparatus.html',
            controller: 'ApparatusController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Material/Apparatus.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Wage/MSew', {
            url: "/Wage/MSew",
            templateUrl: '\StaticViews/Wage/MSew.html',
            controller: 'MSewController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Wage/MSew.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Wage/Province', {
            url: "/Wage/Province",
            templateUrl: '\StaticViews/Wage/Province.html',
            controller: 'ProvinceController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Wage/Province.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Wage/MExpense', {
            url: "/Wage/MExpense",
            templateUrl: '\StaticViews/Wage/MExpense.html',
            controller: 'MExpenseController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Wage/MExpense.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Wage/MOverhead', {
            url: "/Wage/MOverhead",
            templateUrl: '\StaticViews/Wage/MOverhead.html',
            controller: 'MExpenseController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Wage/MOverhead.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Cost/Index', {
            url: "/Cost/Index",
            templateUrl: '\StaticViews/Cost/Index.html',
            controller: 'CostHeaderController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Cost/CostHeader.js',
                                'Scripts/src/Cost/CostEquipment.js',
                                'Scripts/src/Cost/CostPlastic.js',
                                'Scripts/src/Cost/CostPrint.js',
                                'Scripts/src/Cost/CostPrintAdd1.js',
                                'Scripts/src/Cost/CostPrintAdd2.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Sewing/Index', {
            url: "/Sewing/Index",
            templateUrl: '\StaticViews/Sewing/Index.html',
            controller: 'SewingHeaderController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Sewing/Header.js',
                                'Scripts/src/Sewing/Detail.js',
                                'Scripts/src/Sewing/Other.js'
                            ]
                        }])
                }]
            }
        })
        .state('/OverHead/Index', {
            url: "/OverHead/Index",
            templateUrl: '\StaticViews/OverHead/Index.html',
            controller: 'OverHeadController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/OverHead/Header.js',
                                'Scripts/src/OverHead/Detail.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Shipping/Index', {
            url: "/Shipping/Index",
            templateUrl: '\StaticViews/Shipping/Index.html',
            controller: 'ShippingController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Shipping/Header.js',
                                'Scripts/src/Shipping/Detail.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Expenses/Index', {
            url: "/Expenses/Index",
            templateUrl: '\StaticViews/Expenses/Index.html',
            controller: 'ExpensesController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Expenses/Header.js',
                                'Scripts/src/Expenses/Detail.js'
                            ]
                        }])
                }]
            }
        })
        .state('/ClipBoard/Dashboard', {
            url: "/ClipBoard/Dashboard",
            templateUrl: '\StaticViews/ClipBoard/Dashboard.html',
            controller: 'ClipBoardDashboardController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/ClipBoard/Dashboard.js'
                            ]
                        }])
                }]
            }
        })
        .state('/ClipBoard/Index', {
            url: "/ClipBoard/Index",
            templateUrl: '\StaticViews/ClipBoard/Index.html',
            controller: 'ClipBoardIndexController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/ClipBoard/index.js'
                            ]
                        }])
                }]
            }
        })
        .state('/ClipBoard/Sales_Requestion', {
            url: "/ClipBoard/Sales_Requestion",
            templateUrl: '\StaticViews/ClipBoard/Sales_Requisition.html',
            controller: 'SalesRequisitionController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/ClipBoard/Sales_Requisition.js'
                            ]
                        }])
                }]
            }
        })
        .state('/ClipBoard/Sales_Requestion/:id', {
            url: "/ClipBoard/Sales_Requestion/:id",
            templateUrl: '\StaticViews/ClipBoard/Modify_Sales_Requisition.html',
            controller: 'ModifySalesRequisitionController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/ClipBoard/Modify_Sales_Requisition.js'
                            ]
                        }])
                }]
            }
        })
        .state('/ClipBoard/Job_Order', {
            url: "/ClipBoard/Job_Order",
            templateUrl: '\StaticViews/ClipBoard/Job_Order.html',
            controller: 'JobOrderController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/ClipBoard/Job_Order.js'
                            ]
                        }])
                }]
            }
        })
        .state('/ClipBoard/Job_Order/PrintJobOrder', {
            url: "/ClipBoard/Job_Order/PrintJobOrder",
            templateUrl: '\StaticViews/ClipBoard/Print_Job_Order.html',
            controller: 'JobOrderController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/ClipBoard/Job_Order.js'
                            ]
                        }])
                }]
            }
        })
        .state('/Report/CommissionReport', {
            url: "/Report/CommissionReport",
            templateUrl: '\StaticViews/Report/CommissionReport.html',
            controller: 'CommissionReportController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/Report/commission.js'
                            ]
                        }])
                }]
            }
        })
        .state('/User/Index', {
            url: "/User/Index",
            templateUrl: '\StaticViews/User/Index.html',
            controller: 'UserIndexReportController',
            resolve: {
                lazyLoad: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            name: 'AceApp',
                            files: [
                                'Scripts/src/User/User.js'
                            ]
                        }])
                }]
            }
        })
});