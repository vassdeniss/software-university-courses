function main(str) {
    let mid = Math.floor(str.length / 2);

    let firstHalf = str.substr(0, mid).split('').reverse().join('');
    let secondHalf = str.substr(mid).split('').reverse().join('');

    console.log(firstHalf);
    console.log(secondHalf);
}
