function Main(args) {
    let actorNmae = args[0];
    let academyPoints = Number(args[1]);
    let juryQty = Number(args[2]);

    let indexer = 3;
    for (let i = 0; i < juryQty; i++) {
        if (academyPoints > 1250.5) break;
        let juryName = String(args[indexer]);
        let juryPoints = Number(args[indexer + 1]);
        academyPoints += juryPoints * juryName.length / 2;
        indexer += 2;
    }

    if (academyPoints > 1250.5)
        console.log(`Congratulations, ${actorNmae} got a nominee for leading role with ${academyPoints.toFixed(1)}!`);
    else
        console.log(`Sorry, ${actorNmae} you need ${(1250.5 - academyPoints).toFixed(1)} more!`);
}