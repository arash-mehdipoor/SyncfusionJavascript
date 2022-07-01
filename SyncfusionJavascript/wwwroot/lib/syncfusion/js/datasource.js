////const getTradeData = function(dataCount) {
////    var check = [true, false];
////    var Employees = [
////        'Michael', 'Kathryn', 'Tamer', 'Martin', 'Davolio', 'Nancy', 'Fuller', 'Leverling', 'Peacock',
////        'Margaret', 'Buchanan', 'Janet', 'Andrew', 'Callahan', 'Laura', 'Dodsworth', 'Anne',
////        'Bergs', 'Vinet', 'Anton', 'Fleet', 'Zachery', 'Van', 'King', 'Jack', 'Rose'
////    ];
////    var Designation = ['Manager', 'CFO', 'Designer', 'Developer', 'Program Directory', 'System Analyst', 'Project Lead'];
////    var Mail = ['sample.com', 'arpy.com', 'rpy.com', 'mail.com', 'jourrapide.com'];
////    var category = ['Energy', 'Financial', 'Technology', 'Industrial'];
////    var Location = ['UK', 'USA', 'Sweden', 'France', 'Canada', 'Argentina', 'Austria', 'Germany', 'Mexico'];
////    var Status = ['Active', 'Inactive'];
////    var Trustworthiness = ['Perfect', 'Sufficient', 'Insufficient'];
////    var tradeData = [];
////    var Address = ["59 rue de l'Abbaye"];

////    var EmployeeImg = ['usermale', 'userfemale'];
////    if (typeof dataCount === 'string') {
////        dataCount = parseInt(dataCount);
////    }
////    for (var i = 1; i <= dataCount; i++) {
////        var code = 0;
////        tradeData.push({
////            'check': check[Math.floor(Math.random() * check.length)],
////            'EmployeeID': code + i,
////            'Employees': Employees[Math.floor(Math.random() * Employees.length)] + ' ' + Employees[Math.floor(Math.random() * Employees.length)],
////            'Designation': Designation[Math.floor(Math.random() * Designation.length)],
////            'Location': Location[Math.floor(Math.random() * Location.length)],
////            'Status': Status[Math.floor(Math.random() * Status.length)],
////            'Trustworthiness': Trustworthiness[Math.floor(Math.random() * Trustworthiness.length)],
////            'Rating': Math.floor(Math.random() * 5),
////            'Software': Math.floor(Math.random() * 100),
////            'EmployeeImg': EmployeeImg[Math.floor(Math.random() * EmployeeImg.length)],
////            'CurrentSalary': Math.floor((Math.random() * 100000)),
////            'Address': Address[Math.floor(Math.random() * Address.length)],
////        });
////        var emp = tradeData[i - 1].Employees;
////        var sName = emp.substr(0, emp.indexOf(' ')).toLowerCase();
////        tradeData[i - 1].Mail = sName + (Math.floor(Math.random() * 100) + 10) + '@' + Mail[Math.floor(Math.random() * Mail.length)];
////    }
////    return tradeData;
////};

