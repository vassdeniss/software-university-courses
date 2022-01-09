function Main(args) {
    let judges = Number(args.shift());
    let totalGrade = 0, grades = 0;

    let presentation = args.shift();
    while (presentation !== "Finish") {
        let grade = 0;
        for (let i = 0; i < judges; i++) {
            let add = Number(args.shift());
            grade += add; totalGrade += add; grades++;
        }

        let average = grade / judges;
        console.log(`${presentation} - ${average.toFixed(2)}.`);
        presentation = args.shift();
    }

    let totalAverage = totalGrade / grades;
    console.log(`Student's final assessment is ${totalAverage.toFixed(2)}.`);
}