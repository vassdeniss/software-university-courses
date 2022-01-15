function Main(arr1, arr2) {
    for (let s of arr1) {
        if (arr2.includes(s)) {
            console.log(s);
        }
    }
}
