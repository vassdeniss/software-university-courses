function main(args) {
    let movies = [];
    for (let el of args) {
        if (el.includes('addMovie')) {
            let name = el.split('addMovie ')[1];
            movies.push({name});
        } else if (el.includes('directedBy')) {
            let [name, director] = el.split(' directedBy ');
            let movie = movies.find(x => x.name == name);
            if (typeof movie != 'undefined') movie.director = director;
        } else if (el.includes('onDate')) {
            let [name, date] = el.split(' onDate ');
            let movie = movies.find(x => x.name == name);
            if (typeof movie != 'undefined') movie.date = date;
        }
    }

    movies.forEach(x => {
        if (x.name && x.director && x.date) {
            console.log(JSON.stringify(x));
        }
    });
}
