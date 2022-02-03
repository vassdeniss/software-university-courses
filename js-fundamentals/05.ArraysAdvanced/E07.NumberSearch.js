function main(firstArr, secondArr) {
    let toTake = secondArr[0];
    let toDelete = secondArr[1];
    let search = secondArr[2];

    firstArr = firstArr.slice(0, toTake);
    firstArr = firstArr.slice(toDelete);
    
    let total = 0;
    for (let n of firstArr) if (n === search) total++;
    console.log(`Number ${search} occurs ${total} times.`);
}
