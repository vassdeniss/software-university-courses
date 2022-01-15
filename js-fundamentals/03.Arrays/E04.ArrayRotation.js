function Main(arr, rotations) {
    for (let i = 0; i < rotations; i++) {
        let end = arr[0];
        arr.shift();
        arr.push(end);
    }

    console.log(arr.join(" "));
}
