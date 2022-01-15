function Main(arr) {
    let result = "";
    for (let i = 0; i < arr.length; i++) {
        let maxNum = true;
        for (let j = i + 1; j < arr.length; j++) {
            if (arr[i] <= arr[j]) {
                maxNum = false;
                break;
            }
        }

        if (maxNum) result += `${arr[i]} `;
    }

    console.log(result);
}
