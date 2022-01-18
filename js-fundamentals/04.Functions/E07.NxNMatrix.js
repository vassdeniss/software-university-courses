function main(n) {
    function printMatrix(n) {
        let result = "";

        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                result += `${n} `
            }
            
            result += "\n";
        }

        return result;
    }

    console.log(printMatrix(n));
}
