function Main(input) {
    let shape = input[0];

    let result;
    let num = Number(input[1]);
    switch (shape) {
        case "square":
            result = Math.pow(num, 2);
            break;
        case "rectangle":
            let side = Number(input[2]);
            result = num * side;
            break;
        case "circle":
            result = Math.pow(num, 2) * Math.PI;
            break;
        case "triangle":
            let height = Number(input[2]);
            result = (num * height) / 2;
            break;
    }
    console.log(result.toFixed(3));
} 