function main(n1, n2, n3) {
    function sum(n1, n2) {
        return n1 + n2;
    }

    function subtract (n1, n2) {
        return n1 - n2;
    }

    let sumNums = sum(n1, n2);
    let subNums = subtract(sumNums, n3); 

    console.log(subNums);
}
