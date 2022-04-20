function main(args) {
    let dictionary = {};
    for (const str of args) {
        let prop = JSON.parse(str);
        dictionary = Object.assign(dictionary, prop);
    }

    let sortedDic = Object.keys(dictionary);
    sortedDic.sort((a, b) => a.localeCompare(b));
    for (let term of sortedDic) {
        console.log(`Term: ${term} => Definition: ${dictionary[term]}`);
    }
}
