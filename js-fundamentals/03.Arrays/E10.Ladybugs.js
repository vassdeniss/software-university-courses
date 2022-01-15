function Main(arr) {
    let size = arr[0];
    let field = [];
	for (let i = 0; i < size; i++) field.push(0);

    let bugs = arr[1].split(" ").map(Number);
    for (let pos of bugs) if (pos >= 0 && pos < size) field[pos] = 1;

    for (let i = 2; i < arr.length; i++)
    {
        let commands = arr[i].split(" ");
        let idx = Number(commands[0]);
        let direction = commands[1]
        let jump = Number(commands[2]);

        if (field[idx] !== 1 || idx >= field.length || idx < 0) continue;

        field[idx] = 0;
        if (direction === "right") {
            let pos = idx + jump;
            if (field[pos] === 1) pos = pos + jump;
            if (pos <= field.length) field[pos] = 1;
        } else {
            let pos = idx - jump;
            if (field[pos] === 1) pos = pos - jump;
            if (pos >= 0) field[pos] = 1;
        }
    }

    console.log(field.join(" "));
}
