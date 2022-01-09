function Main(input) {
    let checker = "s3cr3t!P@ssw0rd";
    let password = input[0];

    if (password === checker) {
        console.log("Welcome");
    } else {
        console.log("Wrong password!");
    }
}