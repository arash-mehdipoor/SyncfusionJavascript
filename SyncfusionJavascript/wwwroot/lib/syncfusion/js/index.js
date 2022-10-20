






ej.base.enableRipple(window.ripple)

ej.base.L10n.load({
    'fa-IR': {
        'grid': {
            'EmptyRecord': 'هیچ رکوردی برای نمایش وجود ندارد',
            'Columnchooser': 'ستون',
            'ChooseColumns': 'ستون ها را انتخاب کنید',
            'SelectAll': 'انتخاب همه',
            'Search': 'جستجو',
            'ClearButton': 'پاک کردن',
            'FilterButton': 'فیلتر',
            'OKButton': 'اعمال',
            'CancelButton': 'بستن',
            'Pdfexport': 'خروجی PDF',
            'Excelexport': 'خروجی Excele',
            'Wordexport': 'خروجی Worde',
            'Csvexport': 'خروجی Csvex',
            'Save': 'ذخیره',
        },
        'querybuilder': {
            'Equal': 'برابر',
            'NotEqual': 'نا برابر',
            'StartsWith': 'شروع می شود با',
            'EndsWith': 'به پایان می رسد با',
            'Contains': 'شامل',
            'AND': 'و',
            'OR': 'یا',
            'AddGroup': 'اضافه کردن گروه',
            'AddCondition': 'اضافه کردن شرط',
            'DeleteRule': 'این شرایط را حذف کنید',
            'DeleteGroup': 'حذف گروه',
            'Edit': 'برای ویرایش',
            'SelectField': 'یک مورد را انتخاب کنید',
            'SelectOperator': 'نوع عملیات را انتخاب کنید',
            'LessThan': 'کمتر از',
            'LessThanOrEqual': 'کمتر یا مساوی',
            'GreaterThan': 'بزرگتر از',
            'GreaterThanOrEqual': 'بزرگتر یا مساوی با',
            'Between': 'در بین',
            'NotBetween': 'در این بین نباشد',
            'In': 'در',
            'NotIn': 'نباشد در',
            'Remove': 'پاک کردن',
            'ValidationMessage': 'این فیلد الزامی است',
            'IsEmpty': 'خالی باشد',
            'IsNotEmpty': 'خالی نباشد',
            'IsNull': 'مقدار نداشته باشد',
            'IsNotNull': 'مقدار داشته باشد',
        },
        'pager': {
            'currentPageInfo': '{0} از {1} صفحه',
            'totalItemsInfo': '({0} پست)',
            'firstPageTooltip': 'به صفحه اول',
            'lastPageTooltip': 'تا صفحه آخر',
            'nextPageTooltip': 'به صفحه بعد',
            'previousPageTooltip': 'بازگشت به صفحه آخر',
            'nextPagerTooltip': 'به صفحه بعدی',
            'previousPagerTooltip': 'به صفحه قبلی بروید',
            'currentPageInfo': '',
            'totalItemsInfo': '{1} to {2} of {0}',
        }
    }
});

var searchText = document.getElementById('searchText');

var grid = new ej.grids.Grid({
    dataSource: getData(),
    allowSelection: true,
    allowFiltering: true,
    allowSorting: true,
    allowPaging: true,
    allowResizing: true,
    allowRowDragAndDrop: true,
    pageSettings: { currentPage: 1, pageSize: 5, pageCount: 5, pageSizes: true },
    locale: 'fa-IR',
    enableRtl: true,
    gridLines: 'Both',
    //allowTextWrap: true,
    toolbar: ['Search'],
    enableStickyHeader: true,
    //enableVirtualization: true,
    //enableColumnVirtualization: true,
    //showColumnChooser: true,
    //enableAdaptiveUI: true,
    enableVirtualization: false,
    allowExcelExport: true,
    allowPdfExport: true,
    toolbar: ['ExcelExport', 'PdfExport', 'Search', 'ColumnChooser'],
    filterSettings: { type: 'Menu' },
    editSettings: { allowEditing: false, allowAdding: false, allowDeleting: false, mode: 'Batch' },
    selectionSettings: { persistSelection: true },
    enableHover: true,
    enableHeaderFocus: true,
    //height: 480,
    rowHeight: 60,
    columns: getColumns(),
    queryCellInfo: queryCellInfo,
    dataBound: Bound,
    actionBegin: begin,
    actionComplete: complete
});

var columns2 = [
    { field: 'firstName', label: 'firstName', type: 'string', visible: true, headerText: 'نام', width: '60', clipMode: 'EllipsisWithTooltip', filter: { type: 'CheckBox' }, textAlign: 'center' }
]




document.getElementById("searchButton").addEventListener('click', () => {
    getData();
});

let cleaeBtn = new ej.buttons.Button();
cleaeBtn.appendTo('#clearButton')

document.getElementById("clearButton").addEventListener('click', () => {
    searchText.value = ''
    getData();
});

var dReady = false;
var dtTime = false;
var isDataBound = true;
var isDataChanged = true;
var intervalFun;
var clrIntervalFun;
var clrIntervalFun1;
var clrIntervalFun2;
var ddObj;
var dropSlectedIndex = null;
var stTime;
stTime = performance.now();
grid.appendTo('#Grid');
grid.on('data-ready', function () {
    dReady = true;
});

// excel
grid.toolbarClick = function (args) {
    if (args.item.id === 'Grid_pdfexport') {
        grid.pdfExport(getPdfExportProperties());
    }
    if (args.item.id === 'Grid_excelexport') {
        grid.excelExport(getExcelExportProperties());
    }
    if (args.item.id === 'Grid_csvexport') {
        grid.csvExport();
    }
};
var date = '';
date += ((new Date()).getMonth().toString()) + '/' + ((new Date()).getDate().toString());
date += '/' + ((new Date()).getFullYear().toString());



function getExcelExportProperties() {
    return {
        header: {
            headerRows: 7,
            rows: [
                { index: 1, cells: [{ index: 1, colSpan: 5, value: 'INVOICE', style: { fontColor: '#C25050', fontSize: 25, hAlign: 'Center', bold: true } }] },
                {
                    index: 3,
                    cells: [
                        { index: 1, colSpan: 2, value: "Advencture Traders", style: { fontColor: '#C67878', fontSize: 15, bold: true } },
                        { index: 4, value: "INVOICE NUMBER", style: { fontColor: '#C67878', bold: true } },
                        { index: 5, value: "DATE", style: { fontColor: '#C67878', bold: true }, width: 150 }
                    ]
                },
                {
                    index: 4,
                    cells: [{ index: 1, colSpan: 2, value: "2501 Aerial Center Parkway" },
                    { index: 4, value: 2034 }, { index: 5, value: date, width: 150 }

                    ]
                },

                {
                    index: 5,
                    cells: [
                        { index: 1, colSpan: 2, value: "Tel +1 888.936.8638 Fax +1 919.573.0306" },
                        { index: 4, value: "CUSOTMER ID", style: { fontColor: '#C67878', bold: true } }, { index: 5, value: "TERMS", width: 150, style: { fontColor: '#C67878', bold: true } }

                    ]
                },
                {
                    index: 6,
                    cells: [

                        { index: 4, value: 564 }, { index: 5, value: "Net 30 days", width: 150 }
                    ]
                }
            ]
        },

        footer: {
            footerRows: 8,
            rows: [
                { cells: [{ colSpan: 6, value: "Thank you for your business!", style: { fontColor: '#C67878', hAlign: 'Center', bold: true } }] },
                { cells: [{ colSpan: 6, value: "!Visit Again!", style: { fontColor: '#C67878', hAlign: 'Center', bold: true } }] }
            ]
        },

        fileName: "exceldocument.xlsx"
    };
}

function getPdfExportProperties() {
    return {
        header: {
            fromTop: 0,
            height: 120,
            contents: [
                {
                    type: 'Text',
                    value: 'INVOICE',
                    position: { x: 280, y: 0 },
                    style: { textBrushColor: '#C25050', fontSize: 25 },
                },
                {
                    type: 'Text',
                    value: 'INVOICE NUMBER',
                    position: { x: 500, y: 30 },
                    style: { textBrushColor: '#C67878', fontSize: 10 },
                },
                {
                    type: 'Text',
                    value: 'Date',
                    position: { x: 600, y: 30 },
                    style: { textBrushColor: '#C67878', fontSize: 10 },
                }, {
                    type: 'Text',
                    value: '223344',
                    position: { x: 500, y: 50 },
                    style: { textBrushColor: '#000000', fontSize: 10 },
                },
                {
                    type: 'Text',
                    value: date,
                    position: { x: 600, y: 50 },
                    style: { textBrushColor: '#000000', fontSize: 10 },
                },
                {
                    type: 'Text',
                    value: 'CUSTOMER ID',
                    position: { x: 500, y: 70 },
                    style: { textBrushColor: '#C67878', fontSize: 10 },
                },
                {
                    type: 'Text',
                    value: 'TERMS',
                    position: { x: 600, y: 70 },
                    style: { textBrushColor: '#C67878', fontSize: 10 },
                }, {
                    type: 'Text',
                    value: '223',
                    position: { x: 500, y: 90 },
                    style: { textBrushColor: '#000000', fontSize: 10 },
                },
                {
                    type: 'Text',
                    value: 'Net 30 days',
                    position: { x: 600, y: 90 },
                    style: { textBrushColor: '#000000', fontSize: 10 },
                },
                {
                    type: 'Text',
                    value: 'Adventure Traders',
                    position: { x: 20, y: 30 },
                    style: { textBrushColor: '#C67878', fontSize: 20 }
                },
                {
                    type: 'Text',
                    value: '2501 Aerial Center Parkway',
                    position: { x: 20, y: 65 },
                    style: { textBrushColor: '#000000', fontSize: 11 }
                },
                {
                    type: 'Text',
                    value: 'Tel +1 888.936.8638 Fax +1 919.573.0306',
                    position: { x: 20, y: 80 },
                    style: { textBrushColor: '#000000', fontSize: 11 }
                },
            ]
        },
        footer: {
            fromBottom: 160,
            height: 100,
            contents: [
                {
                    type: 'Text',
                    value: 'Thank you for your business !',
                    position: { x: 250, y: 20 },
                    style: { textBrushColor: '#C67878', fontSize: 14 }
                },
                {
                    type: 'Text',
                    value: '! Visit Again !',
                    position: { x: 300, y: 45 },
                    style: { textBrushColor: '#C67878', fontSize: 14 }
                }
            ]
        },

        fileName: "pdfdocument.pdf"
    };
}
// excel

function complete(args) {
    if (args.requestType === "filterchoicerequest") {
        if (args.filterModel.options.field === "Trustworthiness" || args.filterModel.options.field === "Rating" || args.filterModel.options.field === "Status") {
            var span = args.filterModel.dialogObj.element.querySelectorAll('.e-selectall')[0];
            if (!ej.base.isNullOrUndefined(span)) {
                ej.base.closest(span, '.e-ftrchk').classList.add("e-hide");
            }
        }
    }
}

window.trustTemp = function (e) {
    if (e.Trustworthiness === "Select All") {
        return '';
    }
    return '<img style="width: 31px; height: 24px" src="//ej2.syncfusion.com/javascript/demos/src/grid/images/' + e.Trustworthiness + '.png" /> <span id="Trusttext">' + e.Trustworthiness + '</span>';
};
window.ratingDetail = function (e) {
    var grid = document.querySelector(".e-grid").ej2_instances[0];
    var div = document.createElement('div');
    div.className = 'rating';
    var span;
    if (e.Rating === "Select All") {
        return '';
    }
    for (var i = 0; i < 5; i++) {
        if (i < e.Rating) {
            span = document.createElement('span');
            span.className = 'star checked';
            div.appendChild(span);
        } else {
            span = document.createElement('span');
            span.className = 'star';
            div.appendChild(span);
        }
    }
    return div.outerHTML;
};
window.statusDetail = function (e) {
    var grid = document.querySelector(".e-grid").ej2_instances[0];
    var div = document.createElement('div');
    var span;
    if (e.Status === "Select All") {
        return 'Select All';
    }
    span = document.createElement('span');
    if (e.Status === "Active") {
        span.className = 'statustxt e-activecolor';
        span.textContent = "Active";
        div.className = 'statustemp e-activecolor';
    }
    if (e.Status === "Inactive") {
        span = document.createElement('span');
        span.className = 'statustxt e-inactivecolor';
        span.textContent = "Inactive";
        div.className = 'statustemp e-inactivecolor';
    }
    div.appendChild(span);
    return div.outerHTML;
};
function queryCellInfo(args) {

    if (args.column.field === 'status') {
        args.cell.querySelector(".statusButton").textContent = args.data.status === true ? "فعال" : "غیرفعال";
        if (args.data.status === true) {
            args.cell.querySelector(".statusButton").classList.add("btn-success");
        }
        else {
            args.cell.querySelector(".statusButton").classList.add("btn-danger");
        }
    }
}
function startTimer(args) {
    clearTimeout(clrIntervalFun);
    clearInterval(intervalFun);
    dtTime = true;
}
function valueChange() {
    listObj.closePopup();
    grid.showSpinner();
    dropSlectedIndex = null;
    var index = listObj.value;
    clearTimeout(clrIntervalFun2);
    clrIntervalFun2 = setTimeout(function () {
        isDataChanged = true;
        stTime = null;
        var contentElement = grid.contentModule.getPanel().firstChild;
        contentElement.scrollLeft = 0;
        contentElement.scrollTop = 0;
        grid.pageSettings.currentPage = 1; 
        stTime = performance.now();
        grid.dataSource = getTradeData(index);
        grid.hideSpinner();
    }, 100);
}




document.getElementById('Grid').addEventListener('DOMSubtreeModified', function () {
    if (dReady && stTime && isDataChanged) {
        var msgEle = document.getElementById('msg');
        var val = (performance.now() - stTime).toFixed(0);
        stTime = null;
        dtTime = false;
        dReady = false;
        isDataChanged = false;
        msgEle.innerHTML = 'Load Time: ' + "<b>" + val + "</b>" + '<b>ms</b>';
        msgEle.classList.remove('e-hide');
    }


});



function Bound(e) {
    var pager = document.getElementsByClassName('e-gridpager')[0].ej2_instances[0];
    pager.click = function (args) {
         
        var skip = (args.currentPage - 1) * grid.pageSettings.pageSize;
        var take = grid.pageSettings.pageSize;


        var validRule = qryBldrObj.getValidRules(qryBldrObj.rule);
        var predicate = qryBldrObj.getPredicate(validRule);
        getData(predicate, take, skip);
    };
}


// paging
function begin(args) {
     
}
var importRules = {
    condition: 'and',
    rules: []
};

var qryBldrObj = new ej.querybuilder.QueryBuilder({
    width: '100%',
    dataSource: getData(),
    columns: getColumns(),
    locale: 'fa-IR',
    rule: importRules
});
qryBldrObj.appendTo('#querybuilder');

document.getElementById('getdata').onclick = function () {
    var validRule = qryBldrObj.getValidRules(qryBldrObj.rule);
    var predicate = qryBldrObj.getPredicate(validRule);
    predicate.field.toUpperCase();
    predicate.ignoreCase = false;
    getData(predicate);
}









function getData(predicate, take = 10, skip = 0) {
     
    var tdata = [];

    var query = new ej.data.Query();



    if (searchText.value.length != 0) {
        query.search(searchText.value, ['firstName']).sortBy("Id");
    }

    if (predicate != null) {
        query.where(predicate);
    }

    var dataSource = new ej.data.DataManager({
        url: `/Home/SyncfusionData`,
        adaptor: new ej.data.UrlAdaptor(),
        crossDomain: true
    }).executeQuery(query.skip(skip).take(take)).then((e) => {
        e.result.result.forEach(function (item) {
            tdata.push(item);
        });
        tdata.length = e.result.count;
        grid.dataSource = tdata;
    });
}

// paging

