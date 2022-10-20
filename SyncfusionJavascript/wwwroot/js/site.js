//ej.base.enableRipple(window.ripple)

//ej.base.L10n.load({
//    'fa-IR': {
//        'grid': {
//            'EmptyRecord': 'هیچ رکوردی برای نمایش وجود ندارد',
//            'Columnchooser': 'ستون',
//            'ChooseColumns': 'ستون ها را انتخاب کنید',
//            'SelectAll': 'انتخاب همه',
//            'Search': 'جستجو',
//            'ClearButton': 'پاک کردن',
//            'FilterButton': 'فیلتر',
//            'OKButton': 'اعمال',
//            'CancelButton': 'بستن',
//            'Pdfexport': 'خروجی PDF',
//            'Excelexport': 'خروجی Excele',
//            'Wordexport': 'خروجی Worde',
//            'Csvexport': 'خروجی Csvex',
//            'Save': 'ذخیره',
//        },
//        'querybuilder': {
//            'Equal': 'برابر',
//            'NotEqual': 'نا برابر',
//            'StartsWith': 'شروع می شود با',
//            'EndsWith': 'به پایان می رسد با',
//            'Contains': 'شامل',
//            'AND': 'و',
//            'OR': 'یا',
//            'AddGroup': 'اضافه کردن گروه',
//            'AddCondition': 'اضافه کردن شرط',
//            'DeleteRule': 'این شرایط را حذف کنید',
//            'DeleteGroup': 'حذف گروه',
//            'Edit': 'برای ویرایش',
//            'SelectField': 'یک مورد را انتخاب کنید',
//            'SelectOperator': 'نوع عملیات را انتخاب کنید',
//            'LessThan': 'کمتر از',
//            'LessThanOrEqual': 'کمتر یا مساوی',
//            'GreaterThan': 'بزرگتر از',
//            'GreaterThanOrEqual': 'بزرگتر یا مساوی با',
//            'Between': 'در بین',
//            'NotBetween': 'در این بین نباشد',
//            'In': 'در',
//            'NotIn': 'نباشد در',
//            'Remove': 'پاک کردن',
//            'ValidationMessage': 'این فیلد الزامی است',
//            'IsEmpty': 'خالی باشد',
//            'IsNotEmpty': 'خالی نباشد',
//            'IsNull': 'مقدار نداشته باشد',
//            'IsNotNull': 'مقدار داشته باشد',
//        },
//        'pager': {
//            'currentPageInfo': '{0} از {1} صفحه',
//            'totalItemsInfo': '({0} پست)',
//            'firstPageTooltip': 'به صفحه اول',
//            'lastPageTooltip': 'تا صفحه آخر',
//            'nextPageTooltip': 'به صفحه بعد',
//            'previousPageTooltip': 'بازگشت به صفحه آخر',
//            'nextPagerTooltip': 'به صفحه بعدی',
//            'previousPagerTooltip': 'به صفحه قبلی بروید',
//            'currentPageInfo': '',
//            'totalItemsInfo': '{1} to {2} of {0}',
//        }
//    }
//});
//var data = [
//    {
//        "orderId": 10001,
//        "customerName": "ALFKI",
//        "employeeName": "emName 1",
//        "freight": 1,
//        "shipName": "ShiPName 1",
//        "verified": false,
//        "orderDate": "1991-05-15T00:00:00"
//    },
//    {
//        "orderId": 10002,
//        "customerName": "ANATR",
//        "employeeName": "emName 2",
//        "freight": 3,
//        "shipName": "ShiPName 2",
//        "verified": true,
//        "orderDate": "1990-04-04T00:00:00"
//    },
//    {
//        "orderId": 10003,
//        "customerName": "ANTON",
//        "employeeName": "emName 3",
//        "freight": 2,
//        "shipName": "ShiPName 3",
//        "verified": true,
//        "orderDate": "1957-11-30T00:00:00"
//    },
//    {
//        "orderId": 10004,
//        "customerName": "BLONP",
//        "employeeName": "emName 4",
//        "freight": 4,
//        "shipName": "ShiPName 4",
//        "verified": false,
//        "orderDate": "1930-10-22T00:00:00"
//    },
//    {
//        "orderId": 10005,
//        "customerName": "BOLID",
//        "employeeName": "emName 5",
//        "freight": 5,
//        "shipName": "ShiPName 5",
//        "verified": true,
//        "orderDate": "1953-02-18T00:00:00"
//    },
//    {
//        "orderId": 10006,
//        "customerName": "ALFKI",
//        "employeeName": "emName 1",
//        "freight": 2,
//        "shipName": "ShiPName 1",
//        "verified": false,
//        "orderDate": "1991-05-15T00:00:00"
//    },
//    {
//        "orderId": 10007,
//        "customerName": "ANATR",
//        "employeeName": "emName 2",
//        "freight": 4,
//        "shipName": "ShiPName 2",
//        "verified": true,
//        "orderDate": "1990-04-04T00:00:00"
//    },
//    {
//        "orderId": 10008,
//        "customerName": "ANTON",
//        "employeeName": "emName 3",
//        "freight": 3,
//        "shipName": "ShiPName 3",
//        "verified": true,
//        "orderDate": "1957-11-30T00:00:00"
//    },
//    {
//        "orderId": 10009,
//        "customerName": "BLONP",
//        "employeeName": "emName 4",
//        "freight": 5,
//        "shipName": "ShiPName 4",
//        "verified": false,
//        "orderDate": "1930-10-22T00:00:00"
//    },
//    {
//        "orderId": 10010,
//        "customerName": "BOLID",
//        "employeeName": "emName 5",
//        "freight": 6,
//        "shipName": "ShiPName 5",
//        "verified": true,
//        "orderDate": "1953-02-18T00:00:00"
//    },
//    {
//        "orderId": 10011,
//        "customerName": "ALFKI",
//        "employeeName": "emName 1",
//        "freight": 3,
//        "shipName": "ShiPName 1",
//        "verified": false,
//        "orderDate": "1991-05-15T00:00:00"
//    },
//    {
//        "orderId": 10012,
//        "customerName": "ANATR",
//        "employeeName": "emName 2",
//        "freight": 5,
//        "shipName": "ShiPName 2",
//        "verified": true,
//        "orderDate": "1990-04-04T00:00:00"
//    },
//    {
//        "orderId": 10007,
//        "customerName": "ANATR",
//        "employeeName": "emName 2",
//        "freight": 4,
//        "shipName": "ShiPName 2",
//        "verified": true,
//        "orderDate": "1990-04-04T00:00:00"
//    },
//    {
//        "orderId": 10008,
//        "customerName": "ANTON",
//        "employeeName": "emName 3",
//        "freight": 3,
//        "shipName": "ShiPName 3",
//        "verified": true,
//        "orderDate": "1957-11-30T00:00:00"
//    },
//    {
//        "orderId": 10009,
//        "customerName": "BLONP",
//        "employeeName": "emName 4",
//        "freight": 5,
//        "shipName": "ShiPName 4",
//        "verified": false,
//        "orderDate": "1930-10-22T00:00:00"
//    },
//    {
//        "orderId": 10010,
//        "customerName": "BOLID",
//        "employeeName": "emName 5",
//        "freight": 6,
//        "shipName": "ShiPName 5",
//        "verified": true,
//        "orderDate": "1953-02-18T00:00:00"
//    },
//    {
//        "orderId": 10011,
//        "customerName": "ALFKI",
//        "employeeName": "emName 1",
//        "freight": 3,
//        "shipName": "ShiPName 1",
//        "verified": false,
//        "orderDate": "1991-05-15T00:00:00"
//    },
//    {
//        "orderId": 10012,
//        "customerName": "ANATR",
//        "employeeName": "emName 2",
//        "freight": 5,
//        "shipName": "ShiPName 2",
//        "verified": true,
//        "orderDate": "1990-04-04T00:00:00"
//    },
//    {
//        "orderId": 10013,
//        "customerName": "ANTON",
//        "employeeName": "emName 3",
//        "freight": 4,
//        "shipName": "ShiPName 3",
//        "verified": true,
//        "orderDate": "1957-11-30T00:00:00"
//    },
//    {
//        "orderId": 10014,
//        "customerName": "BLONP",
//        "employeeName": "emName 4",
//        "freight": 6,
//        "shipName": "ShiPName 4",
//        "verified": false,
//        "orderDate": "1930-10-22T00:00:00"
//    },
//    {
//        "orderId": 10015,
//        "customerName": "BOLID",
//        "employeeName": "emName 5",
//        "freight": 7,
//        "shipName": "ShiPName 5",
//        "verified": true,
//        "orderDate": "1953-02-18T00:00:00"
//    },
//    {
//        "orderId": 10016,
//        "customerName": "ALFKI",
//        "employeeName": "emName 1",
//        "freight": 4,
//        "shipName": "ShiPName 1",
//        "verified": false,
//        "orderDate": "1991-05-15T00:00:00"
//    },
//    {
//        "orderId": 10017,
//        "customerName": "ANATR",
//        "employeeName": "emName 2",
//        "freight": 6,
//        "shipName": "ShiPName 2",
//        "verified": true,
//        "orderDate": "1990-04-04T00:00:00"
//    },
//    {
//        "orderId": 10018,
//        "customerName": "ANTON",
//        "employeeName": "emName 3",
//        "freight": 5,
//        "shipName": "ShiPName 3",
//        "verified": true,
//        "orderDate": "1957-11-30T00:00:00"
//    },
//    {
//        "orderId": 10019,
//        "customerName": "BLONP",
//        "employeeName": "emName 4",
//        "freight": 7,
//        "shipName": "ShiPName 4",
//        "verified": false,
//        "orderDate": "1930-10-22T00:00:00"
//    },
//    {
//        "orderId": 10020,
//        "customerName": "BOLID",
//        "employeeName": "emName 5",
//        "freight": 8,
//        "shipName": "ShiPName 5",
//        "verified": true,
//        "orderDate": "1953-02-18T00:00:00"
//    }
//];

 


var grid = new ej.grids.Grid(
    {
        allowPaging: true,
        pageSettings: { currentPage: 1, pageSize: 5, pageCount: 5, pageSizes: false },
        locale: 'fa-IR',
        enableRtl: true,
    });
grid.appendTo('#Grid');


 
