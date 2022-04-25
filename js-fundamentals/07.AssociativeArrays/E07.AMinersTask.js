function main(args) {
    let resources = {};
    let prev;
    for (let i = 0; i < args.length; i++) {
        if (i % 2 == 0) {
            if (!Object.hasOwnProperty.call(resources, args[i])) {
                resources[args[i]] = 0;
            }
            
            prev = args[i];
        } else {
            resources[prev] += parseInt(args[i]);
        }
    }

    for (const key in resources) {
        console.log(`${key} -> ${resources[key]}`);
    }
}
