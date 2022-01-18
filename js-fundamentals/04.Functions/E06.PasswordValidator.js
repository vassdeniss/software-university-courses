function main(pass) {
    function validatePasswordLength(pass) {
        return pass.length >= 6 && pass.length <= 10;            
    }

    function validatePasswordText(pass) {
        for (let c of pass) {
            let code = c.charCodeAt();

            if (!(code >= 48 && code <= 57) &&
                !(code >= 65 && code <= 90) &&
                !(code >= 97 && code <= 122)) {
                return false;
            }
        }

        return true;
    }

    function validatePasswordDigits(pass) {
        let count = 0;

        for (let c of pass) {
            let code = c.charCodeAt();
            if (code >= 48 && code <= 57) count++;
            if (count >= 2) return true;
        }

        return false;
    }

    let isLengthValid = validatePasswordLength(pass);
    let isTextValid = validatePasswordText(pass);
    let isDigitsValid = validatePasswordDigits(pass);

    if (isLengthValid && isTextValid && isDigitsValid) {
        console.log("Password is valid");
    }

    if (!isLengthValid) {
        console.log("Password must be between 6 and 10 characters");
    }

    if (!isTextValid)
        console.log("Password must consist only of letters and digits");

    if (!isDigitsValid)
        console.log("Password must have at least 2 digits");
}
