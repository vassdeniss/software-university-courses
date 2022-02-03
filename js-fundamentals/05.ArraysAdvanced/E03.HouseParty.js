function main(arr) {
    let guests = [];

    let cmds = arr;
    while (cmds.length != 0) {
        let cmd = cmds.shift().split(" ");

        let name = cmd[0];
        if (cmd.length === 3) {
            if (guests.includes(name)) {
                console.log(`${name} is already in the list!`);
            } else {
                guests.push(name);
            }
        } else {
            if (!guests.includes(name)) {
                console.log(`${name} is not in the list!`);
            } else {
                let idx = guests.indexOf(name);
                if (idx > -1) {
                    guests.splice(idx, 1);
                }
            }
        }
    }

    for (let guest of guests) {
        console.log(guest);
    }
}
