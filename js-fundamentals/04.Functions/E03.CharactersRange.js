function main(first, second) {
    let smaller = Math.min(first.charCodeAt(0), second.charCodeAt(0));
    let bigger = Math.max(first.charCodeAt(0), second.charCodeAt(0));
    
    let result = [];
    for (let i = smaller + 1; i < bigger; i++) {
        result.push(String.fromCharCode(i));
    }

    console.log(result.join(" "));
}
