function main(arr) {
    let array = arr;
    let result = [];

    array.sort((a, b) => a - b);
    while (array.length !== 0) {
        result.push(array.pop());
        result.push(array.shift());
    }

    console.log(result.join(" "));
}
