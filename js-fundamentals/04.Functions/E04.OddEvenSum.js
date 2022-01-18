function main(n) {
    function sumEvenOdd(n) {
        let num = n.toString();
        let odd = 0;
        let even = 0;
    
        for (let i = 0; i < num.length; i++) {
            let curr = Number(num[i]);
            if (curr % 2 == 0) even += curr;
            else odd += curr;
        }

        return `Odd sum = ${odd}, Even sum = ${even}`;
    }

    console.log(sumEvenOdd(n));
}
