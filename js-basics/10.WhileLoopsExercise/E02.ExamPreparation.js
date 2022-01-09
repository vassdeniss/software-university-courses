function Main(args) {
    let badGrades = 0, totalGrades = 0, totalGradesNumber = 0, totalProblems = 0;
    let maxBadGrades = Number(args[0]);
    let lastProblem;
    
    let iterator = 1;
    while (args[iterator] != "Enough") {
        let grade = Number(args[iterator + 1]);
        totalGrades++; totalProblems++; totalGradesNumber += grade;
        if (grade <= 4) badGrades++;
        if (badGrades == maxBadGrades) {
            console.log(`You need a break, ${badGrades} poor grades.`);
            return;
        }
        lastProblem = args[iterator];
        iterator += 2;
    }

    console.log(`Average score: ${(totalGradesNumber / totalGrades).toFixed(2)}`);
    console.log(`Number of problems: ${totalProblems}`);
    console.log(`Last problem: ${lastProblem}`);
}