function main(str) {
    let words = [];

    let curr = str[0];
    for (let i = 1; i < str.length; i++) {
        if (str[i].toUpperCase() == str[i]) {
            words.push(curr);
            curr = str[i];
        } else {
            curr += str[i];
        }
    }

    words.push(curr);
    console.log(words.join(', '));
}
