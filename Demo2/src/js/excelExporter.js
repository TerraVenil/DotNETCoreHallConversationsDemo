module.exports = function (result, orders) {

    var fs = require('fs');
    var officegen = require('officegen');
    var xlsx = officegen('xlsx');

    console.log('Orders count ' + orders.length);

    xlsx.on('finalize',
        function(written) {
            console.log('Finish to create an Excel file.\nTotal bytes created: ' + written + '\n');
        });

    xlsx.on('error',
        function(err) {
            console.log(err);
        });

    sheet = xlsx.makeNewSheet();
    sheet.name = 'Orders';

    var orderColumns = orders.map(x => {
        return { orderNumber: x.orderNumber, orderStatus: x.orderStatus.name, deadlineTime: x.deadlineTime, comment: x.comment, price: x.price, isUrgently: x.isUrgently }
    });

    var row = 0;
    var column = 0;
    sheet.data[row] = [];
    for (var key in orderColumns[row])
    {
        sheet.data[row][column] = key;
        column++;
    }

    for (var i = 0; i < orderColumns.length; i++) {
        sheet.data[i + 1] = [];
        var j = 0;
        for (var key in orderColumns[i])
        {
            sheet.data[i + 1][j] = orderColumns[i][key];
            j++;
        }
    }

    xlsx.generate(result.stream);
}