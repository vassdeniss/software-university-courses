function main(str) {
    let unique = '';
    for (let i = 0; i < str.length; i++) {
        const curr = str.charAt(i);
        const next = str.charAt(i + 1);
        if (curr !== next) {
            unique += curr;
        }
    }

    console.log(unique);
}
