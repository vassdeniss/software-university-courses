function main(args) {
    let carSet = new Set();

    for (const carArr of args) {
        let [cmd, number] = carArr.split(', ');
        if (cmd == 'IN') {
            carSet.add(number);
        } else if (cmd == 'OUT') {
            carSet.delete(number);
        }
    }

    let sorted = Array.from(carSet).sort((a, b) => a.localeCompare(b));
    if (sorted.length == 0) {
        console.log('Parking Lot is Empty');
    } else {
        sorted.forEach(x => console.log(x));
    }
}
