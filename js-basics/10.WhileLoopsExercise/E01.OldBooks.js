function Main(args) {
    let requiredBook = args[0];
    let checkedBooks = 0;
    let iterator = 1;
    while (args[iterator] !== requiredBook) {
        if (args[iterator] === "No More Books") {
            console.log("The book you search is not here!");
            console.log(`You checked ${checkedBooks} books.`);
            return;
        }
        checkedBooks++;
        iterator++;
    }

    console.log(`You checked ${checkedBooks} books and found it.`);
}