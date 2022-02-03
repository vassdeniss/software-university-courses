function main(arr) {
    let result = arr;
    result.sort((a, b) => a.localeCompare(b));
    result.sort((a, b) => a.length - b.length);

    for (let s of result) {
        console.log(s);
    }
}
