let movies = [];

fetch('http://localhost:65512/movie')
    .then(x => x.json())
    .then(y => {
        movies = y;
        console.log(movies);
        display();
    });

function display() {
    movies.forEach(t => {
        console.log(t.name);
    });

}