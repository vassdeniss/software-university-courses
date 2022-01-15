function Main(arr) {
    let health = 100;
    let coins = 0;
    let bestRoom = 0;

    let rooms = arr[0].split("|");
    for (let i = 0; i < rooms.length; i++) {
        let room = rooms[i].split(" ");
        bestRoom++;
        if (room[0] === "potion") {
            let potion = Number(room[1]);
            if (health + potion > 100) {
                potion = 100 - health;
                health = 100;
            } else health += potion

            console.log(`You healed for ${potion} hp.`);
            console.log(`Current health: ${health} hp.`);
        } else if (room[0] === "chest") {
            let amount = Number(room[1]);
            coins += amount;
            console.log(`You found ${amount} coins.`);
        } else {
            let monster = room[0];
            let damage = Number(room[1]);
            
            health -= damage;
            if (health <= 0) {
                console.log(`You died! Killed by ${monster}.`);
                console.log(`Best room: ${bestRoom}`);
                return;
            }

            console.log(`You slayed ${monster}.`);
        }
    }

    console.log(`You've made it!\nCoins: ${coins}\nHealth: ${health}`);
}
