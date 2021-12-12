function Main(input) {
    let word = String(input[0]);
    
    let sum = 0;
    for (let i = 0; i < word.length; i++) {
        switch (word[i]) {
            case 'a': sum++; break;
            case 'e': sum += 2; break;
            case 'i': sum += 3; break;
            case 'o': sum += 4; break;
            case 'u': sum += 5; break;
        }
    }

    console.log(sum);
}