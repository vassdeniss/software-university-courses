function main(args) {
    let words = {};
    args[0].split(' ').forEach(x => words[x] = 0);
    
    for (let i = 1; i < args.length; i++) {
        const el = args[i];
        
        if (Object.prototype.hasOwnProperty.call(words, el)) {
            const curr = words[el];
            words[el] = curr + 1;
        }
    }

    let sortedWords = Object.entries(words).sort((a, b) => b[1] - a[1]);
    for (const [key, value] of sortedWords) {
        console.log(`${key} - ${value}`);
    }
}
