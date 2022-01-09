function Main(input) {
    let month = input[0];
    let period = Number(input[1]);

    let totalStudio = 0;
    let totalApartment = 0;
    switch (month) {
        case "May":
        case "October":
            totalStudio += period * 50;
            totalApartment += period * 65;
            if (period > 14) {
                totalStudio *= 0.7;
                totalApartment *= 0.9;
            } else if (period > 7) totalStudio *= 0.95;
            break;
        case "June":
        case "September":
            totalStudio += period * 75.20;
            totalApartment += period * 68.70;
            if (period > 14) {
                totalStudio *= 0.8;
                totalApartment *= 0.9;
            }
            break;
        case "July":
        case "August":
            totalStudio += period * 76;
            totalApartment += period * 77;
            if (period > 14) totalApartment *= 0.9;
            break;
    }

    console.log(`Apartment: ${totalApartment.toFixed(2)} lv.`);
    console.log(`Studio: ${totalStudio.toFixed(2)} lv.`);
}