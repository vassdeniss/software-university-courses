function main(word, text) {
    let lowerWord = word.toLowerCase();
    let lowerText = text.toLowerCase();
    let idx = lowerText.indexOf(lowerWord);
    if (idx !== -1) {
        console.log(text.substring(idx, word.length));
    } else {
        console.log(`${word} not found!`);
    }
}
