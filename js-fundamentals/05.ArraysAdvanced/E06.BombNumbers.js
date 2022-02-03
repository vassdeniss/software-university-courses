function main(bombsArr, powerArr) {
    for (let i = 0; i < bombsArr.length; i++) {
        let special = powerArr[0];
        if (bombsArr[i] == special) {
            let power = powerArr[1];
            let start = i - power, end = i + power;

            if (start < 0) start = 0;
            if (end > bombsArr.length - 1) end = bombsArr.length - 1;

            bombsArr.splice(start, end - start + 1);
            i = start - 1;
        }
    }

    console.log(bombsArr.reduce((a, b) => a + b, 0));
}
