function Main(missingString, filLChar, match) {
    let fixedString = missingString.replace('_', filLChar);
    let result = fixedString === match ? "Matched" : "Not Matched";
    console.log(result);
}