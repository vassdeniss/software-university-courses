function Main(args) {
    let openTabs = Number(args[0]);
    let salary = Number(args[1]); 

    for (let i = 0; i < openTabs; i++) {
        let website = args[i + 2];
        switch (website) {
            case "Facebook": salary -= 150; break;
            case "Instagram": salary -= 100; break;
            case "Reddit": salary -= 50; break;
        }

        if (salary <= 0) {
            console.log("You have lost your salary.");
            return;
        }
    }

    console.log(salary);
}