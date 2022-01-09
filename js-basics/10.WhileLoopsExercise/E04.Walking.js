function Main(args) {
    const STEP_GOAL = 10000;
    let totalSteps = 0;
    
    let iterator = 0;
    while (true) {
        let input = args[iterator];

        if (totalSteps >= STEP_GOAL) {
            console.log("Goal reached! Good job!");
            console.log(`${totalSteps - STEP_GOAL} steps over the goal!`);
            return;
        }

        if (input === "Going home") {
            totalSteps += Number(args[iterator + 1]);
            if (totalSteps >= STEP_GOAL) {
                console.log("Goal reached! Good job!");
                console.log(`${totalSteps - STEP_GOAL} steps over the goal!`);
            } else console.log(`${STEP_GOAL - totalSteps} more steps to reach goal.`);
            return;
        }

        totalSteps += Number(input);
        iterator++;
    }
}