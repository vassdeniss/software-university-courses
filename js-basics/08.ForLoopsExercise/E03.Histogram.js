function Main(args) {
    let qty = Number(args[0]);

    let groupOne = 0, groupTwo = 0, groupThree = 0, groupFour = 0, groupFive = 0;
    for (let i = 0; i < qty; i++) {
        let number = Number(args[i + 1]);
        if (number < 200) groupOne++; 
        else if (number >= 200 && number <= 399) groupTwo++;
        else if (number >= 400 && number <= 599) groupThree++;
        else if (number >= 600 && number <= 799) groupFour++;
        else if (number >= 800) groupFive++;
    }

    console.log(`${((groupOne / qty) * 100).toFixed(2)}%`);
    console.log(`${((groupTwo / qty) * 100).toFixed(2)}%`);
    console.log(`${((groupThree / qty) * 100).toFixed(2)}%`);
    console.log(`${((groupFour / qty) * 100).toFixed(2)}%`);
    console.log(`${((groupFive / qty) * 100).toFixed(2)}%`);
}