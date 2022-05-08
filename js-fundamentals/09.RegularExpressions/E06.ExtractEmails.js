function main(str) {
    str.match(/(^|\s)(?<user>[A-Za-z\d]+([_.-]*\w+)+)@(?<host>[A-Za-z]+([.-]\w+)+\b)/gm).forEach(x => console.log(x));
}
