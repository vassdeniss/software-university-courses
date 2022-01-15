function Main(arr) {
    let longestSequence = [];
    let leftMostIndex = 0;

    for (let i = 0; i < arr.length; i++) {
        let curr = Number(arr[i]);
        let currSequence = [curr];

        for (let j = i + 1; j < arr.length; j++) {
            let next = Number(arr[j]);
            if (next == curr) currSequence.push(next);
            else break;
        }

        if (currSequence.length > longestSequence.length) {
            longestSequence = [];
            for (let n of currSequence) {
                longestSequence.push(n);
            }
        } else if (currSequence.length == longestSequence.length) {
            if (i < leftMostIndex) {
                leftMostIndex = i;
            }
        }
    }

    console.log(longestSequence.join(" "));
}
