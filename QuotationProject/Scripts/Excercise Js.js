var Employee = (function () {
    function Employee() {
        this.salary = 0
    }

    Employee.prototype.increasingSalary = function () {
        this.salary = this.salary + 1000;
    }

    Employee.prototype.displayData = function () {
        return this.firstName + " - " + this.lastName + " - " + this.salary
    }
}());

var emp = new Employee();
console.log(emp.displayData());

multiplyBy = function (a, b, c) {
    return a * b * c;
};

getLongItem = function (array) {
    if (array !== null && Array.isArray(array)) {
        var longer = 0;
        var itemLonger = -1; 
        for (var i; i < array.length; i++) {
            if (array[i].length > longer) {
                itemLonger = i;
            }            
        }
        return array[itemLonger];
    } else {
        return 'it is not array'
    }
}

removeColor = function (index) {
    var select = document.getElementById("colorSelect");
    select.remove(select.selectedIndex);
}

insert_Row = function () {
    var table = document.getElementById("sampleTable");
    var row = table.insertRow(0);    
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);    
    cell1.innerHTML = "row3 cell1";
    cell2.innerHTML = "row3 cell2";
}
