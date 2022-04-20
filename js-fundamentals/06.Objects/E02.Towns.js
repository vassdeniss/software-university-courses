function main(args) {
    for (let i = 0; i < args.length; i++) {
        let props = args[i].split(' | ');

        let obj = {
            town: props[0],
            latitude: Number(props[1]).toFixed(2),
            longitude: Number(props[2]).toFixed(2),
        };

        console.log(obj);
    }
}
