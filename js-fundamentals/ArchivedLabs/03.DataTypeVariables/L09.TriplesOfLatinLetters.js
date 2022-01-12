function Main(n) {
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            for (let k = 0; k < n; k++) {
                let letterOne = String.fromCharCode(97 + i);
                let letterTwo = String.fromCharCode(97 + j);
                let letterThree = String.fromCharCode(97 + k);

                console.log(`${letterOne}${letterTwo}${letterThree}`);
            }
        }
    }
}