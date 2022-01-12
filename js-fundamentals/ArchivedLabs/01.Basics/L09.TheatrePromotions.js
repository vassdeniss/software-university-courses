function Main(day, age) {
    if (0 <= age && age <= 18) {
        switch (day) {
            case "Weekday": console.log("12$"); break;
            case "Weekend": console.log("15$"); break;
            case "Holiday": console.log("5$"); break;
        }
    } else if (18 < age && age <= 64) {
        switch (day) {
            case "Weekday": console.log("18$"); break;
            case "Weekend": console.log("20$"); break;
            case "Holiday": console.log("12$"); break;
        }
    } else if (64 < age && age <= 122) {
        switch (day) {
            case "Weekday": console.log("12$"); break;
            case "Weekend": console.log("15$"); break;
            case "Holiday": console.log("10$"); break;
        }
    } else {
        console.log("Error!");
    }
}