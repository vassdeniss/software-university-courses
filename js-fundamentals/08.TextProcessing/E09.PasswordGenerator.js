function main(words) {
    let concatedWord = words[0].concat(words[1]).toLowerCase().split('');
    let thirdWord = words[2];

    let idx = 0;
    for (let i = 0; i < concatedWord.length; i++) {
        if (['a', 'e', 'i', 'o', 'u'].indexOf(concatedWord[i].toLowerCase()) != -1) {
            concatedWord[i] = thirdWord[idx++].toUpperCase();
            if (idx >= thirdWord.length) idx = 0;
        }
    }

    console.log(`Your generated password is ${concatedWord.reverse().join('')}`);
}
