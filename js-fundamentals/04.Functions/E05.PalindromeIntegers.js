function main(args) {
    function reverse(n) {
        return n.toString().split("").reverse().join("");
    }

    function isPalindrome(n)
    {
        let compare = reverse(n);

        if (n == compare) return "true";
        return "false";
    }

    while (args.length > 0) {
        console.log(isPalindrome(args.shift()));
    }
}
