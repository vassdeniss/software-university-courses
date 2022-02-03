function main(arr) {
    let filtered = arr.filter((value, idx, self) => self.indexOf(value) === idx);
    console.log(filtered.join(" "));
}
