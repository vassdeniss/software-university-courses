function Main(arr, num) {
    for (let i = 0; i < arr.length - 1; i++) {
        for (let j = i + 1; j < arr.length; j++) {
            if (arr[i] + arr[j] == num) {
                console.log(`${arr[i]} ${arr[j]}`);
            }
        }
    }
}
