function main(args) {
    let companies = {};
    for (const el of args) {
        const [company, id] = el.split(' -> ');
        if (!Object.hasOwnProperty.call(companies, company)) {
            companies[company] = {};
        }

        companies[company][id] = id;
    }

    let ordered = Object.entries(companies).sort((a, b) => a[0].localeCompare(b[0]));
    for (const [company, ids] of ordered) {
        console.log(company);
        for (const id in ids) {
            console.log(`-- ${id}`);
        }
    }
}
