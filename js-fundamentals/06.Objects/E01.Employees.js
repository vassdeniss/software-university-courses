function main(args) {
    for (let i = 0; i < args.length; i++) {
        let obj = {
            name: args[i],
            phoneNumber: args[i].length
        };

        console.log(`Name: ${obj.name} -- Personal Number: ${obj.phoneNumber}`);
    }
}
