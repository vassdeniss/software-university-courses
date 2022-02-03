function main(arr, commands) {
    for (let s of commands) {
        let [cmd, idx, el] = s.split(" ");

        if (cmd === "add") arr.splice(idx, 0, Number(el))
        else if (cmd === "addMany") arr = arr.slice(0, idx).concat(s.split(" ").slice(2).map(Number), arr.slice(idx));
        else if (cmd === "contains") console.log(arr.indexOf(Number(idx)));
        else if (cmd === "remove") arr.splice(idx, 1);
        else if (cmd === "shift") for (let i = 0; i < idx; i++) arr.push(arr.shift());
        else if (cmd === "sumPairs") {
            let summedArr = arr.reduce((total, el, idx) => {
                if (idx % 2 === 0) total.push(arr[idx] + (arr[idx + 1] || 0));
                return total;
            }, []);
            arr = summedArr;
        } else console.log(`[ ${arr.map(Number).join(", ")} ]`);
    }
}
