function Main(args) {
    let studentName = args[0];
    let year = 1;
    let fails = 0;
    let averageGrade = 0;

    let iterator = 1;
    while (year <= 12) {
        let yearGrade = Number(args[iterator]);
        averageGrade += yearGrade;
        if (yearGrade < 4) {
            fails++;
            if (fails > 1) {
                console.log(`${studentName} has been excluded at ${year} grade`);
                return;
            }
            continue;
        }
        year++;
        iterator++;
    }

    averageGrade /= 12;
    console.log(`${studentName} graduated. Average grade: ${averageGrade.toFixed(2)}`);
}