function Main(input) {
    let tax = Number(input[0]);
    let sneakersPrice = tax * 0.6;
    let outfitPrice = sneakersPrice * 0.8;
    let ballPrice = outfitPrice / 4;
    let accessoriesPrice = ballPrice / 5;

    console.log((tax + sneakersPrice + outfitPrice + ballPrice + accessoriesPrice).toFixed(2));
}