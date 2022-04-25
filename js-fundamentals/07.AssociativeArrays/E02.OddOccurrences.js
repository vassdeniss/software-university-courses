function main(args) {
    let splitArgs = args.split(' ');

    let dic = {};
    for (let word of splitArgs) {
        word = word.toLocaleLowerCase();
        
        if (Object.prototype.hasOwnProperty.call(dic, word)) {
            dic[word]++;
        } else {
            dic[word] = 1;
        }
    }

    let filtered = Object.entries(dic).filter(x => x[1] % 2 == 1).map(x => x[0]).join(' ');
    console.log(filtered);
}
