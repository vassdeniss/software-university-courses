function main(arr) {
    let inv = arr[0].split(" ");

    let commands = arr.slice(1);
    for (let s of commands) {
        let [cmd, equipment] = s.split(" ");
        if (cmd === "Buy" && inv.indexOf(equipment) === -1) {
            inv.push(equipment);
        } else if (cmd === "Trash") {
            let idx = inv.indexOf(equipment);
            if (idx != -1) inv.splice(idx, 1);
        } else if (cmd === "Repair") {
            let idx = inv.indexOf(equipment);
            if (idx != -1) inv.splice(idx, 1) && inv.push(equipment);
        } else if (cmd === "Upgrade") {
            let weaponUpgrade = equipment.split("-");
            let idx = inv.indexOf(weaponUpgrade[0]);
            if (idx != -1) inv.splice(idx + 1, 0, `${weaponUpgrade[0]}:${weaponUpgrade[1]}`);
        }
    }

    console.log(inv.join(" "));
}
