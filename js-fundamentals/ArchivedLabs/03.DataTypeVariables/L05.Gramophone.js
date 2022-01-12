function Main(band, album, song) {
    let seconds = (band.length * album.length) * song.length / 2;

    let rotations = 0;
    while (seconds > 0) {
        rotations++;
        seconds -= 2.5;
    }

    console.log(`The plate was rotated ${Math.ceil(rotations)} times.`);
}