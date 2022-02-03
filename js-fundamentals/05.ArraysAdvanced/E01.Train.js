function main(arr) {
    let wagons = arr.slice(0, 1);
    wagons = wagons[0].split(" ").map(Number);
    let max = Number(arr.slice(1, 2));

    let cmds = arr.slice(2);
    while (cmds.length != 0) {
        let cmd = cmds.shift().split(" ");
        if (cmd[0] === "Add") {
            wagons.push(Number(cmd[1]));
        } else {
            for (let i = 0; i < wagons.length; i++) {
                let toAdd = Number(cmd[0]);
                if (wagons[i] + toAdd <= max) {
                    wagons[i] += toAdd;
                    break;
                }
            }
        }
    }

    console.log(wagons.join(" "));
}
