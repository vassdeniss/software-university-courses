function Main(args) {
    let floors = Number(args[0]);
    let rooms = Number(args[1]);

    for (let i = floors; i > 0; i--) {
        let print = "";
        for (let j = 0; j < rooms; j++) {
            if (i == floors) {
                print += `L${i}${j} `;
                continue;
            }

            if (i % 2 == 0) print += `O${i}${j} `;
            else print += `A${i}${j} `;
        }
        console.log(print);
    }
}