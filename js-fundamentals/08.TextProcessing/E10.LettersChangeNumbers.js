function main(strings) {
    let sequences = strings.trim().split(/\s+/);

    let sum = 0;
    for (const sequence of sequences) {
        const first = sequence[0];
        const number = parseInt(sequence.substring(1, sequence.length - 1));
        const last = sequence[sequence.length - 1];

        const firstPos = parseInt(alphabetPosition(first));
        const lastPos = parseInt(alphabetPosition(last));
        sum += first.toUpperCase() == first 
            ? number / firstPos 
            : number * firstPos;
        sum += last.toUpperCase() == last 
            ? -lastPos 
            : lastPos;
    }

    console.log(`${sum.toFixed(2)}`);

    function alphabetPosition(text) {
        let result = '';
        for (let i = 0; i < text.length; i++) {
            const code = text.toUpperCase().charCodeAt(i);
            if (code > 64 && code < 91) result += (code - 64) + ' ';
        }

        return result.slice(0, result.length - 1);
    }
}
