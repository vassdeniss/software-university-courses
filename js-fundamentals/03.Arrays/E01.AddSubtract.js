function Main(arr) {
    let oldSum = 0;
    for (let i = 0; i < arr.length; i++) {
        oldSum += arr[i];
        if (arr[i] % 2 == 0) {
            arr[i] += i; 
        } else {
            arr[i] -= i;
        }
    }

    let newSum = 0;
    for (let n of arr) {
        newSum += n;
    }

    console.log(`[ ${arr.join(", ")} ]`);
    console.log(oldSum);
    console.log(newSum);
}
