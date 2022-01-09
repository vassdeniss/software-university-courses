function Main(args) {
    let total = 0;
    let student = 0, kid = 0, standard = 0;
    
    let movie = args.shift();
    while (movie !== "Finish") {
        let seats = Number(args.shift());
        let people = 0;
        let ticket = args.shift();
        while (ticket !== "End") {
            switch (ticket) {
                case "standard": standard++; break;
                case "student": student++; break;
                case "kid": kid++; break;
            }

            total++; people++;
            if (people >= seats) break;
            ticket = args.shift();
        }

        console.log(`${movie} - ${((people / seats) * 100).toFixed(2)}% full.`);
        movie = args.shift();
    }

    console.log(`Total tickets: ${total}`);
    console.log(`${((student / total) * 100).toFixed(2)}% student tickets.`);
    console.log(`${((standard / total) * 100).toFixed(2)}% standard tickets.`);
    console.log(`${((kid / total) * 100).toFixed(2)}% kids tickets.`);
}