function main(args) {
    let regular = [];
    let vip = [];

    let partyStarted = false;
    for (const guest of args) {
        if (partyStarted) {
            if (isVip(guest)) {
                const idx = vip.indexOf(guest);
                vip.splice(idx, 1);
            } else {
                const idx = regular.indexOf(guest);
                regular.splice(idx, 1);
            }
            
            continue;
        }

        if (guest == 'PARTY') {
            partyStarted = true;
        } else if (isVip(guest)) {
            vip.push(guest);
        } else {
            regular.push(guest);
        }
    }

    console.log(regular.length + vip.length);
    vip.forEach(x => console.log(x));
    regular.forEach(x => console.log(x));

    function isVip(guest) {
        return guest[0] >= '0' && guest[0] <= '9';
    }
}
