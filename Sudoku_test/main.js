validSolution([
    [2, 9, 4, 7, 5, 3, 8, 1, 6],
    [5, 7, 8, 4, 9, 1, 3, 6, 2],
    [3, 6, 1, 2, 8, 6, 9, 7, 5],
    [1, 8, 6, 9, 3, 7, 2, 5, 4],
    [7, 3, 2, 6, 4, 5, 1, 9, 8],
    [9, 4, 5, 8, 1, 2, 6, 3, 7],
    [4, 5, 3, 1, 7, 8, 2, 9, 3],
    [6, 2, 9, 5, 3, 4, 7, 8, 1],
    [8, 1, 7, 3, 2, 9, 5, 4, 6]
]);

function arraysEqual(arr1, arr2) {
    if (arr1.length !== arr2.length) return false;

    return arr1.every(function (item, index) { 
        return item === arr2[index];
    });
}

function validSolution(arr) {

    let arr1 = Array.from({ length: 9 }, (_, i) => i + 1);

    //Проверка строк
    for (let i = 0; i < 9; i++) {
        let row = [];
        for (let j = 0; j < 9; j++) {
            row.push(arr[i][j]);
        }
        row.sort(function (a, b) {
            return a - b;
        });
        if (!arraysEqual(arr1, row)) {
            console.log("Неправильная строка: " + ++i)
            return false;
        }
    }


    //Проверка столбцов
    for (let j = 0; j < 9; j++) {
        let column = [];
        for (let i = 0; i < 9; i++) {
            column.push(arr[i][j]);
        }
        column.sort(function (a, b) {
            return a - b;
        });
        if (!arraysEqual(arr1, column)) {
            console.log("Неправильный столбец: " + ++j)

            return false;
        }
    }

    //Проверка блоков 3x3
    for (let i = 0; i < 9; i += 3) {
        for (let j = 0; j < 9; j += 3) {
            let block = [];
            for (let x = i; x < i + 3; x++) {
                for (let y = j; y < j + 3; y++) {
                    block.push(arr[x][y]);
                }
            }
            block.sort(function (a, b) {
                return a - b;
            });
            if (!arraysEqual(arr1, block)) {
                console.log("Неправильный блок 3х3")

                return false;
            }
        }
    }


    return true;
}