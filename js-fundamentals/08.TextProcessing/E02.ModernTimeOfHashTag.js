function main(sentence) {
    let words = sentence.split(' ');
    for (const word of words) {
        if (word.startsWith('#') && word.length > 1) {
            const ascii = word.charCodeAt(1);
            const isLetter = ascii >= 65 && ascii <= 90 ||
                ascii >= 97 && ascii <= 122;
            if (isLetter) {
                console.log(word.substring(1));
            }
        }
    }
}
