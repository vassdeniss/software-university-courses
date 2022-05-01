function main(textAndArray) {
    let text = textAndArray[0].split(' ');
    let words = textAndArray[1];

    for (let i = 0; i< text.length; i++) {
        if (text[i].startsWith('_')) {
            const lenght = text[i].endsWith(',') || text[i].endsWith('.')
                ? text[i].length - 1 
                : text[i].length;
            const word = words.find(x => x.length == lenght);
            words.splice(words.indexOf(word), 1);
            text[i] = text[i].replace('_'.repeat(word.length), word);
        }
    }

    console.log(text.join(' '));
}
