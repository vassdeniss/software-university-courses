function Main(arr) {
    for (let i = 0; i < arr.length; i++) {
        let left = 0;
        for (let j = i - 1; j >= 0; j--) left += arr[j];

        let right = 0;
        for (let k = i + 1; k < arr.length; k++) right += arr[k];

        if (left == right)
        {
            console.log(i);
            return;
        }
    }

    console.log("no");
}
