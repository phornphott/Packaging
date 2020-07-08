var products = [{
    id: "1",
    text: "ระบบการตั้งรหัส",
    url: "",
    expanded: true,
    items: [{
        id: "1_1",
        text: "รหัสพื้นฐาน",
        url: "",
        items: [{
            id: "1_1_1",
            text: "กลุ่มสินค้า",
            url: "#/BasicCode/ProductGroup"
        }, {
            id: "1_1_2",
            text: "สินค้า",
            url: "#/BasicCode/Product"

        }, {
            id: "1_1_3",
            text: "กลุ่มลูกค้า",
            url: "#/BasicCode/CustomerGroup"
        },
        {
            id: "1_1_4",
            text: "ลูกค้า",
            url: "#/BasicCode/Customer"
        },

        {
            id: "1_1_5",
            text: "พนักงาน",
            url: "#/BasicCode/Employee"
        },
        {
            id: "1_1_6",
            text: "งาน",
            url: "#/BasicCode/Job"
        },
        {
            id: "1_1_7",
            text: "แผนก",
            url: "#/BasicCode/Department"
        }]
    }, {
        id: "1_2",
        text: "รหัสวัตถุดิบ",
        url: "",
        items: [{
            id: "1_2_1",
            text: "เม็ดพลาสติก",
            url: "#/Material/MaterialList"
        },
        {
            id: "1_2_2",
            text: "งานพิมพ์",
            url: "#/Material/WorkPrint"
        },
        {
            id: "1_2_3",
            text: "อุปกรณ์",
            url: "#/Material/Apparatus"
        },
        ]

    }, {
        id: "1_3",
        text: "รหัสค่าแรง",
        url: "",
        items: [{
            id: "1_3_1",
            text: "งานเย็บหรือสวมถุงใน",
            url: "#/Wage/MSew",
        },
        {
            id: "1_3_3",
            text: "จังหวัดและระยะทาง",
            url: "#/Wage/Province",
        },
        {
            id: "1_3_4",
            text: "ค่าใช้จ่ายขายและการบริหาร",
            url: "#/Wage/MExpense",
        },
        {
            id: "1_3_5",
            text: "โสหุ้ยการผลิต",
            url: "#/Wage/MOverhead",
        },
        ]
    }]
}, {
    id: "2",
    text: "กำหนดต้นทุนและค่าแรง",
    expanded: true,
    url: "",
    items: [
        {
            id: "2.1.10",
            text: "ต้นทุนวัตถุดิบ",
            url: "#/Cost/Index"
        },
        //    {

        //    id: "2.1",
        //    text: "ต้นทุนวัตถุดิบ",
        //    url: "",
        //    items: [{
        //        id: "2.1.1",
        //        text: "ต้นทุนส่วนหัว",
        //        url: "#/Cost/CostHeader"
        //    }, {
        //        id: "2.1.2",
        //        text: "ส่วนรายการเม็ดพลาสติก",
        //        url: "#/Cost/CostPlastic"
        //        },
        //    {
        //        id: "2.1.3",
        //        text: "ส่วนรายการอุปกรณ์",
        //        url: "#/Cost/CostEquipment"
        //    },
        //    {
        //        id: "2.1.4",
        //        text: "ส่วนรายการงานพิมพ์",
        //        url: "#/Cost/CostPrint"
        //    },
        //    {
        //        id: "2.1.5",
        //        text: "ส่วนรายการราคาเพิ่ม",
        //        url: "#/Cost/CostPrintAdd1"
        //    },
        //    {
        //        id: "2.1.6",
        //        text: "ส่วนรายการค่าฟิล์ม OOP",
        //        url: "#/Cost/CostPrintAdd2"
        //    },
        //    ],
        //},
        {
            id: "2.2",
            text: "ค่าจ้างเย็บด้ายและสวมถุงใน",
            url: "#/Sewing/Index"
            //items: [{
            //    id: "2.2.1",
            //    text: "ส่วนหัว",
            //    url: "#/Sewing/SewingHeader"
            //    },
            //    {
            //        id: "2.2.2",
            //        text: "ส่วนงานเย็บ",
            //        url: "#/Sewing/SewingDetail"
            //    },
            //    {
            //        id: "2.2.3",
            //        text: "ส่วนรายการงานอื่น",
            //        url: "#/Sewing/SewingOther"
            //    },
            //],
        },
        {
            id: "2.3",
            text: "โสหุ้ยการผลิต",
            url: "#/OverHead/Index",
            //items: [{
            //    id: "2.3.1",
            //    text: "ค่าโสหุ้ยส่วนหัว",
            //    url: "#/OverHead/Header"
            //},
            //{
            //    id: "2.3.2",
            //    text: "ค่าโสหุ้ยส่วนรายการ",
            //    url: "#/OverHead/Detail"
            //},

            //],
        },
        {
            id: "2.4",
            text: "ค่าขนส่ง",
            url: "#/Shipping/Index"
            //items: [{
            //    id: "2.4.1",
            //    text: "ค่าขนส่งส่วนหัว",
            //    url: "#/Shipping/Header"
            //},
            //{
            //    id: "2.4.2",
            //    text: "ค่าขนส่งส่วนรายการ",
            //    url: "#/Shipping/Detail"
            //},

            //],
        },
        {
            id: "2.5",
            text: "ค่าใช้จ่ายขายและการบริหาร",
            url: "#/Expenses/Index"
            //items: [{
            //    id: "2.5.1",
            //    text: "ส่วนหัว",
            //    url: "#/Expenses/Header"
            //},
            //{
            //    id: "2.5.2",
            //    text: "ส่วนรายการ",
            //    url: "#/Expenses/Detail"
            //},

            //],
        },
    ]
},
{
    id: "3",
    text: "ระบบขาย",
    expanded: true,
    url: "",
    items: [{
        id: "3.1",
        text: "กระบวนการ",
        url: "",
        items: [{
            id: "3.1.1",
            text: "กระดาษทดคำนวณต้นทุน",
            url: "#/ClipBoard/Dashboard"
        }, {
            id: "3.1.2",
            text: "ใบขออนุมัติการขาย",
            url: "#/ClipBoard/Sales_Requestion"
        }, {
            id: "3.1.3",
            text: "ใบแจ้งการผลิต",
            url: "#/ClipBoard/Job_Order"
        },

        ]
    },

    {
        id: "3.2",
        text: "รายงาน",
        url: "",
        items: [{
            id: "3.2.1",
            text: "รายงานค่าคอมมิชชั่น",
            url: "#/Report/CommissionReport"
        },]
    }
    ]
},

{
    id: "4",
    text: "ระบบรหัสผ่านและสิทธิ",
    expanded: true,
    url: "",
    items: [{
        id: "4.2",
        text: "ตั้งค่ารหัสผ่านและสิทธิ",
        url: "#/User/Index"
    }]
}
];

$("#treeview").dxTreeView({
    dataSource: products,
    searchEnabled: true,
    selectionMode: "single",
    selectByClick: true,
    onItemSelectionChanged: function (e) {
        if (e.itemData.url !== "") {
            window.location = e.itemData.url;
        }
    }
});
